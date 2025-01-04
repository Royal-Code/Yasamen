using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.BlazorShow;

public interface IFragmentComponentPropertyBuilder<TFragmentComponent, TProperty>
    where TFragmentComponent : class, IComponent
{
    void RenderComponent<T>(
        Action<IFragmentComponentBuilder<T>>? configure = null)
        where T : class, IComponent;

    void SetValue(TProperty value);
}