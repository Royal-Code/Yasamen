
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Yasamen.Commons.Options;

internal class CommonOptions<TComponent> : ICommonOptions<TComponent>
    where TComponent : IComponent
{
    private readonly Dictionary<string, object> values = new();

    internal void Set<TValue>(string key, TValue? value)
    {
        if (value is not null)
            values[key] = value;
        else
            values.Remove(key);
    }

    bool ICommonOptions<TComponent>.TryGet<T>(string key,[NotNullWhen(true)] out T? value) 
        where T : default
    {
        if (values.TryGetValue(key, out var obj) && obj is T t)
        {
            value = t;
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }
}