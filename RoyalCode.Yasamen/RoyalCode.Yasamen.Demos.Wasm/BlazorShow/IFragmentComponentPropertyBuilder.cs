using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IFragmentComponentPropertyBuilder<TFragmentComponent, TProperty>
    where TFragmentComponent : class, IComponent
{
    void RenderComponent<T>(
        Action<IFragmentComponentBuilder<T>>? configure = null)
        where T : class, IComponent;

    void SetValue(TProperty value);
}