using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Yasamen.Commons.Extensions;

/// <summary>
/// Extensions methods for <c>System.Reflection</c> namespace.
/// </summary>
public static class ReflectionExtensions
{
    public static bool TryGetAttribute<TAttribute>(this MemberInfo member, out TAttribute? attribute)
        where TAttribute : Attribute
    {
        var attr = member?.GetCustomAttribute(typeof(TAttribute));

        if (attr is null)
        {
            attribute = null;
            return false;
        }

        attribute = (TAttribute)attr;
        return true;
    }

    public static string GetDefaultDisplayName(this MemberInfo member)
        => member.TryGetAttribute<DisplayNameAttribute>(out var displayName)
            ? displayName!.DisplayName
            : member.TryGetAttribute<DisplayAttribute>(out var display)
                ? display!.Name ?? member.Name
                : member.Name;

    public static string GetTypeName(this Type type)
    {
        var generics = type.GetGenericArguments();
        if (generics.Length == 0)
            return type.Name;

        return $"{type.Name.Replace($"`{generics.Length}", string.Empty)}<{string.Join(", ", generics.Select(t => t.Name))}>";
    }

    /// <summary>
    /// Checks if a data type is a certain generic type and returns the concrete generic type.
    /// Base copied from Stackoverflow.
    /// </summary>
    /// <param name="generic">The known and required generic type.</param>
    /// <param name="toCheck">The type to be checked that may implement the required generic type.</param>
    /// <returns>The concrete generic type, or null if it is not a generic subtype.</returns>
    public static Type? GetSubclassOfRawGeneric(this Type generic, Type toCheck)
    {
        // added, if it is an interface, it searches for interfaces of the type.
        if (generic.IsInterface)
        {
            foreach (var interfaceToCheck in toCheck.GetInterfaces())
            {
                var cur = interfaceToCheck.IsGenericType
                    ? interfaceToCheck.GetGenericTypeDefinition()
                    : interfaceToCheck;

                if (generic == cur)
                {
                    return interfaceToCheck;
                }
            }
        }

        while (true)
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
            {
                return toCheck;
            }

            if (toCheck.BaseType is null || toCheck.BaseType == typeof(object))
                return null;

            toCheck = toCheck.BaseType;
        }
    }

    /// <summary>
    /// <para>
    ///     Checks if <paramref name="type"/> implements <paramref name="other"/>,
    ///     the latter being a generic type and with generic parameters (open).
    /// </para>
    /// <para>
    ///     If you implement the type of <paramref name="other"/>, 
    ///     the generic parameter types are assigned to <paramref name="genericTypes"/>.
    /// </para>
    /// </summary>
    /// <param name="type">Type that should implement the other.</param>
    /// <param name="other">The type that the first should implement, being that it must be an open generic.</param>
    /// <param name="genericTypes">The types of the generic parameters, if <paramref name="type"/> implements <paramref name="other"/>, null otherwise.</param>
    /// <returns>True if <paramref name="type"/> implements <paramref name="other"/>, false otherwise.</returns>
    /// <summary>
    public static bool ImplementsGeneric(this Type type, Type other,[NotNullWhen(true)] out Type[]? genericTypes)
    {
        var closeGeneric = other.GetSubclassOfRawGeneric(type);

        if (closeGeneric is null)
        {
            genericTypes = null;
            return false;
        }

        genericTypes = closeGeneric.GetGenericArguments();
        return true;
    }

    /// <summary>
    /// Gets a listing of properties with a given attribute.
    /// </summary>
    /// <typeparam name="TAttribute">The type of the Attribute.</typeparam>
    /// <param name="type">The type (class) that you want to search for properties with attributes.</param>
    /// <returns>Listing of properties with attributes.</returns>
    public static IEnumerable<PropertyAttributeList<TAttribute>> GetPropertyAttributeList<TAttribute>(this Type type)
        where TAttribute : Attribute
    {
        var query = type.GetRuntimeProperties()
            .Select(p =>
            {
                var attrs = p.GetCustomAttributes<TAttribute>().ToList();
                return new PropertyAttributeList<TAttribute>(p, attrs, attrs.FirstOrDefault()!); // !: filter below
            })
            .Where(p => p.FirstAttribute is not null);

        return query;
    }
}
