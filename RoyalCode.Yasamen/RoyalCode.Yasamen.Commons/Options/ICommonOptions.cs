
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Commons.Options;

public interface ICommonOptions<TComponent>
    where TComponent: IComponent
{
    bool TryGet<T>(string key, out T? value);
}
