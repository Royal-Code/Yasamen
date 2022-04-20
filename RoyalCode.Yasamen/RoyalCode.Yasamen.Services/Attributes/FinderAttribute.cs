using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RoyalCode.Yasamen.Commons.DependencyInjection;
using RoyalCode.Yasamen.Commons.Extensions;
using RoyalCode.Yasamen.Services.Internal;

namespace RoyalCode.Yasamen.Services.Attributes;

public class FinderAttribute : SubscribesAttribute
{
    public override void AddServices(IServiceCollection services, MethodInfo method)
    {
        var parameters = method.GetParameters();
        if (parameters.Length < 1 || parameters.Length > 2)
            throw new InvalidOperationException(
                $"The {nameof(FinderAttribute)} requires a method with 1 or 2 parameters," +
                $" where the first is the filter and the second the CancellationToken, the latter optional.");

        if (!method.ReturnType.ImplementsGeneric(typeof(Task<>), out var taskGenerics))
            throw new InvalidOperationException($"The {nameof(FinderAttribute)} method must return a Task<TValue>");

        bool hasCancellationToken = parameters.Length == 2;
        
        if (hasCancellationToken && parameters[1].ParameterType != typeof(CancellationToken))
            throw new InvalidOperationException(
                $"The second parameter of {nameof(FinderAttribute)} method must be a CancellationToken");

        var tmodel = taskGenerics[0];
        var tservice = method.DeclaringType!;
        var tfilter = parameters[0].ParameterType;

        var @delegate = CreateDelegate(tservice, tfilter, tmodel, method, hasCancellationToken);
        services.AddSingleton(@delegate.GetType(), @delegate);

        var serviceType = typeof(InternalFinder<,,>).MakeGenericType(tmodel, tfilter, tservice);
        services.AddTransient(typeof(IFinder<,>).MakeGenericType(tmodel, tfilter), serviceType);
    }

    private Delegate CreateDelegate(Type tservice, Type tfilter, Type tmodel, MethodInfo method, bool hasCancellationToken)
    {
        var serviceParam = Expression.Parameter(tservice, "service");
        var filterParam = Expression.Parameter(tfilter, "filter");
        var tokenParam = Expression.Parameter(typeof(CancellationToken), "token");

        var call = hasCancellationToken
            ? Expression.Call(serviceParam, method, filterParam, tokenParam)
            : Expression.Call(serviceParam, method, filterParam);

        var delegateType = typeof(FinderDelegate<,,>).MakeGenericType(tservice, tfilter, tmodel);

        var lambda = Expression.Lambda(delegateType, call, serviceParam, filterParam, tokenParam);
        return lambda.Compile();
    }
}