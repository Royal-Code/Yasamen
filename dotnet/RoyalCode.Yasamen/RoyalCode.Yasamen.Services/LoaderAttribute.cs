using Microsoft.Extensions.DependencyInjection;
using RoyalCode.Yasamen.Commons.DependencyInjection;
using RoyalCode.Yasamen.Commons.Extensions;
using RoyalCode.Yasamen.Services.Infrastructure.Internal;
using RoyalCode.Yasamen.Services.Infrastructure.Performers;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;

namespace RoyalCode.Yasamen.Services;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class LoaderAttribute : SubscribesAttribute
{
    /// <summary>
    /// The name of the loader. Optional.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="LoaderAttribute"/>.
    /// </summary>
    /// <param name="name">The name of the loader. Optional.</param>
    public LoaderAttribute(string? name = null)
    {
        Name = name;
    }

    public override void AddServices(IServiceCollection services, MethodInfo method)
    {
        var parameters = method.GetParameters();
        if (parameters.Length > 2)
            throw new InvalidOperationException(
                $"The {nameof(LoaderAttribute)} requires a method with 0 or 1 or 2 parameters," +
                " when there are no filters, only one parameter is accepted, optional, which is the cancellation token," +
                " when there are filters, the first is the filter and the second the cancellation token, the latter optional.");

        if (!method.ReturnType.ImplementsGeneric(typeof(Task<>), out var taskGenerics)
            || !taskGenerics[0].ImplementsGeneric(typeof(IEnumerable<>), out var resultGenerics))
            throw new InvalidOperationException($"The {nameof(FinderAttribute)} method must return a Task<IEnumerable<TValue>>");

        var hasFilter = parameters.Length > 0 && parameters[0].ParameterType != typeof(CancellationToken);
        var hasCancellationToken = parameters.Length == 1 && parameters[0].ParameterType == typeof(CancellationToken)
            || parameters.Length == 2;

        if (hasCancellationToken && parameters[1].ParameterType != typeof(CancellationToken))
        {
            throw new InvalidOperationException(
                $"The second parameter of {nameof(LoaderAttribute)} method must be a cancellation token");
        }

        var tmodel = resultGenerics[0];
        var tservice = method.DeclaringType!;

        if (hasFilter)
        {
            var tfilter = parameters[0].ParameterType!;

            var @delegate = CreateDelegate(tservice, tmodel, tfilter, method, hasCancellationToken);
            if (Name is not null)
            {
                NamedLoaders.AddDelegate(Name, tmodel, tfilter, @delegate);

                var serviceType = typeof(NamedLoaderPerformer<,,>).MakeGenericType(tmodel, tfilter, tservice);
                services.AddTransient(serviceType);
                NamedLoaders.AddServiceType(Name, tmodel, serviceType);
            }
            else
            {
                services.AddSingleton(@delegate.GetType(), @delegate);

                var serviceType = typeof(LoaderPerformer<,,>).MakeGenericType(tmodel, tfilter, tservice);
                services.AddTransient(typeof(ILoaderPerformer<,>).MakeGenericType(tmodel, tfilter), serviceType);
            }
        }
        else
        {
            var @delegate = CreateDelegate(tservice, tmodel, method, hasCancellationToken);
            if (Name is not null)
            {
                NamedLoaders.AddDelegate(Name, tmodel, @delegate);

                var serviceType = typeof(NamedLoaderPerformer<,>).MakeGenericType(tmodel, tservice);
                services.AddTransient(serviceType);
                NamedLoaders.AddServiceType(Name, tmodel, serviceType);
            }
            else
            {
                services.AddSingleton(@delegate.GetType(), @delegate);

                var serviceType = typeof(LoaderPerformer<,>).MakeGenericType(tmodel, tservice);
                services.AddTransient(typeof(ILoaderPerformer<>).MakeGenericType(tmodel), serviceType);
            }
        }

    }

    private static Delegate CreateDelegate(Type tservice, Type tmodel, Type tfilter, MethodInfo method, bool hasCancellationToken)
    {
        var serviceParam = Expression.Parameter(tservice, "service");
        var filterParam = Expression.Parameter(tfilter, "filter");
        var tokenParam = Expression.Parameter(typeof(CancellationToken), "token");

        var call = hasCancellationToken
            ? Expression.Call(serviceParam, method, filterParam, tokenParam)
            : Expression.Call(serviceParam, method, filterParam);

        var delegateType = typeof(LoaderDelegate<,,>).MakeGenericType(tservice, tfilter, tmodel);

        var lambda = Expression.Lambda(delegateType, call, serviceParam, filterParam, tokenParam);
        return lambda.Compile();
    }

    private static Delegate CreateDelegate(Type tservice, Type tmodel, MethodInfo method, bool hasCancellationToken)
    {
        var serviceParam = Expression.Parameter(tservice, "service");
        var tokenParam = Expression.Parameter(typeof(CancellationToken), "token");

        var call = hasCancellationToken
            ? Expression.Call(serviceParam, method, tokenParam)
            : Expression.Call(serviceParam, method);

        var delegateType = typeof(LoaderDelegate<,>).MakeGenericType(tservice, tmodel);

        var lambda = Expression.Lambda(delegateType, call, serviceParam, tokenParam);
        return lambda.Compile();
    }
}
