using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RoyalCode.Yasamen.Commons.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class SubscribesExtensions
{

    public static IServiceCollection Subscribes<TService>(this IServiceCollection services, 
        ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        var type = typeof(TService);
        
        services.TryAdd(ServiceDescriptor.Describe(type, type, lifetime));

        var methods = type.GetTypeInfo().GetRuntimeMethods().Where(m => !m.IsStatic && m.IsPublic);
        foreach (var method in methods)
        {
            foreach (var attribute in method.GetCustomAttributes<SubscribesAttribute>(true))
            {
                attribute.AddServices(services, method);
            }
        }
        
        return services;
    }
}