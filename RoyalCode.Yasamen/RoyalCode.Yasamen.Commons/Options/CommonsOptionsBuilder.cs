
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Commons.Options;

public class CommonsOptionsBuilder<TComponent>
    where TComponent : IComponent
{
    private readonly CommonOptions<TComponent> options;

    internal CommonsOptionsBuilder(CommonOptions<TComponent> options)
    {
        this.options = options;
    }

    public CommonsOptionsBuilder<TComponent> Set<TValue>(string key, TValue value)
    {
        options.Set(key, value);
        return this;
    }
}
