using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace RoyalCode.Yasamen.Commons.Extensions;

public static class KeyAndDescriptionFunctionDelegates
{
    private static readonly ConcurrentDictionary<Type, object> KeyFunctions = new();
    private static readonly ConcurrentDictionary<Tuple<Type, Type>, object> TypedKeyFunctions = new();
    private static readonly ConcurrentDictionary<Type, object> DescriptionsFunctions = new();

    private static readonly MethodInfo StringFormatMethod = typeof(string).GetMethod(nameof(string.Format), new Type[] { typeof(string), typeof(object) })!;
    private static readonly MethodInfo StringBuilderAppendString = typeof(StringBuilder).GetMethod(nameof(StringBuilder.Append), new Type[] { typeof(string) })!;
    private static readonly MethodInfo StringBuilderAppendObject = typeof(StringBuilder).GetMethod(nameof(StringBuilder.Append), new Type[] { typeof(object) })!;
    private static readonly MethodInfo StringBuilderToString = typeof(StringBuilder).GetMethod(nameof(StringBuilder.ToString), new Type[0])!;

    public static readonly ICollection<Func<Type, PropertyInfo?>> KeyDiscoverers =
        new List<Func<Type, PropertyInfo?>>()
        {
            type =>
            {
                var attrs = type.GetPropertyAttributeList<KeyAttribute>().ToList();
                return attrs.Count is 1
                    ? attrs.First().Property
                    : null;
            }
        };

    public static readonly ICollection<Func<Type, TypeDescriptor[]?>> DescriptionDiscoverers =
        new List<Func<Type, TypeDescriptor[]?>>()
        {
            type =>
            {
                var propAttrs = type.GetPropertyAttributeList<DescriptorAttribute>().ToList();
                return propAttrs.Count > 0
                    ? propAttrs
                        .Select(pa => new TypeDescriptor()
                        {
                            Property = pa.Property,
                            StringFormat = pa.FirstAttribute.StringFormat,
                            Order = pa.FirstAttribute.Order,
                            Separetor = pa.FirstAttribute.Separetor
                        })
                        .ToArray()
                    : null;
            },
            type =>
            {
                var properties = type.GetRuntimeProperties()
                    .Where(p => CommonDescriptionNames.Contains(p.Name, StringComparer.OrdinalIgnoreCase))
                    .Select(p => new TypeDescriptor() { Property = p })
                    .ToArray();
                
                return properties.Length > 0 ? properties : null;
            }
        };

    public static readonly ICollection<string> CommonKeyNames = new List<string>()
    {
        "Id", "Key", "Guid", "Code"
    };

    public static readonly ICollection<string> CommonDescriptionNames = new List<string>()
    {
        "Description", "Name"
    };

    public static Func<TModel, object> GetKeyFunction<TModel>()
    {
        return (Func<TModel, object>)KeyFunctions.GetOrAdd(typeof(TModel), type =>
        {
            foreach (var discoverer in KeyDiscoverers)
            {
                var property = discoverer(type);
                if (property is null || property.GetMethod is null)
                    continue;

                return CreateDelegate<TModel>(property);
            }

            var properties = type.GetRuntimeProperties();
            foreach (var name in CommonKeyNames)
            {
                var property = properties
                    .FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (property is null || property.GetMethod is null)
                    continue;

                return CreateDelegate<TModel>(property);
            }

            return (Func<TModel, object>)(a => a!);
        });
    }

    public static Func<TModel, TValue>? GetKeyFunction<TModel, TValue>()
    {
        var key = new Tuple<Type, Type>(typeof(TModel), typeof(TValue));
        return (Func<TModel, TValue>)TypedKeyFunctions.GetOrAdd(key, k =>
        {
            var mType = k.Item1;
            var vType = k.Item2;
            foreach (var discoverer in KeyDiscoverers)
            {
                var property = discoverer(mType);
                if (property is null || property.PropertyType != vType)
                    continue;

                var getProperty = property.GetMethod;
                if (getProperty is not null)
                    return getProperty.CreateDelegate<Func<TModel, TValue>>();
            }

            var properties = mType.GetRuntimeProperties();
            foreach (var name in CommonKeyNames)
            {
                var property = properties
                    .Where(p => p.PropertyType == vType)
                    .FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                var getProperty = property?.GetMethod;
                if (getProperty is not null)
                    return getProperty.CreateDelegate<Func<TModel, TValue>>();
            }

            return null!; // !: the method can return null
        });
    }

    public static Func<TModel, object> GetModelDescription<TModel>()
    {
        return (Func<TModel, object>)DescriptionsFunctions.GetOrAdd(typeof(TModel), type =>
        {
            foreach (var discoverer in DescriptionDiscoverers)
            {
                var descriptors = discoverer(type);
                if (descriptors is null)
                    continue;

                var param = Expression.Parameter(type, "model");
                var sbParam = Expression.Parameter(typeof(StringBuilder), "sb");
                var ret = Expression.Parameter(typeof(string));

                List<Expression> body = new();
                body.Add(Expression.Assign(
                    sbParam,
                    Expression.New(typeof(StringBuilder))));

                Expression chain = sbParam;
                Expression defaultSeparator = Expression.Constant(" - ");

                foreach (var descriptor in descriptors)
                {
                    if (chain != sbParam)
                    {
                        var separator = descriptor.Separetor is null
                            ? defaultSeparator
                            : Expression.Constant(descriptor.Separetor);
                        chain = Expression.Call(chain, StringBuilderAppendString, separator);
                    }

                    var memberAccess = Expression.MakeMemberAccess(param, descriptor.Property);

                    if (descriptor.StringFormat is not null)
                    {
                        var callFormat = Expression.Call(StringFormatMethod, Expression.Constant(descriptor.StringFormat), memberAccess);
                        chain = Expression.Call(chain, StringBuilderAppendString, callFormat);
                    }
                    else
                    {
                        var method = typeof(StringBuilder)
                            .GetMethod(nameof(StringBuilder.Append), new Type[] { descriptor.Property.PropertyType })
                            ?? StringBuilderAppendObject;

                        chain = Expression.Call(chain, method, memberAccess);
                    }
                }

                body.Add(Expression.Assign(
                    ret,
                    Expression.Call(chain, StringBuilderToString)));
                body.Add(ret);

                var lambda = Expression.Lambda<Func<TModel, object>>(
                        Expression.Block(
                            typeof(object),
                            new ParameterExpression[] { sbParam, ret },
                            body),
                        param);

                return lambda.Compile();
            }

            return (Func<TModel, object>)(a => a);
        });
    }

    private static Delegate CreateDelegate<TModel>(PropertyInfo property)
    {
        var param = Expression.Parameter(typeof(TModel), "model");
        var lambda = Expression.Lambda<Func<TModel, object>>(
            Expression.Convert(
                Expression.MakeMemberAccess(param, property),
                typeof(object)),
            param);

        return lambda.Compile();
    }
}
