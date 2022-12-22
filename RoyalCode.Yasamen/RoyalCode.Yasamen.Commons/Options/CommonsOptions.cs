
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Commons.Options;

public static class CommonsOptions
{
    private static readonly Dictionary<Type, object> options = new();
    
    public static CommonsOptionsBuilder<TComponent> Configure<TComponent>()
        where TComponent : IComponent
    {
        if(!options.TryGetValue(typeof(TComponent), out var obj) || obj is not CommonOptions<TComponent> value)
        {
            value = new CommonOptions<TComponent>();
            options.Add(typeof(TComponent), value);
        }

        return new CommonsOptionsBuilder<TComponent>(value);
    }

    public static ICommonOptions<TComponent> Get<TComponent>()
        where TComponent: IComponent
    {
        if (options.TryGetValue(typeof(TComponent), out var obj))
            return (ICommonOptions<TComponent>)obj;
        else
            return new CommonOptions<TComponent>();
    }
}
