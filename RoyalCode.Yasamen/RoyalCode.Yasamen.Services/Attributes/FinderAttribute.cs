using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RoyalCode.Yasamen.Commons.DependencyInjection;

namespace RoyalCode.Yasamen.Services.Attributes;

public class FinderAttribute : SubscribesAttribute
{
    public override void AddServices(IServiceCollection services, MethodInfo method)
    {
        
    }
}