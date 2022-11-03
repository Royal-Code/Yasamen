using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IShow<TComponent>
    where TComponent : class, IComponent
{
    void Create(IShowDescriptionBuilder<TComponent> builder);
}
