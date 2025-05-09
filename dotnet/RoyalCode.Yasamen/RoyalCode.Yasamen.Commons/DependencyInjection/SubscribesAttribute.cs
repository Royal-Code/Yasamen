using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RoyalCode.Yasamen.Commons.DependencyInjection;

/// <summary>
/// Attribute for register services in the <see cref="IServiceCollection"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public abstract class SubscribesAttribute : Attribute
{
    public abstract void AddServices(IServiceCollection services, MethodInfo method);
}
