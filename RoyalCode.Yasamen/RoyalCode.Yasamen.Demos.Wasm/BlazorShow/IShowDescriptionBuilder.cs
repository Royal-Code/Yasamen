using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IShowDescriptionBuilder<TComponent>
    where TComponent : class, IComponent
{
    IShowDescriptionBuilder<TComponent> Description(string description);
    IShowDescriptionBuilder<TComponent> Group(string groupName);
    IShowDescriptionBuilder<TComponent> Name(string name);
    IShowDescriptionBuilder<TComponent> Route(string route);
    IShowDescriptionBuilder<TComponent> AddScene(Action<ISceneBuilder> configure);
    IShowDescriptionBuilder<TComponent> Properties(Action<IShowProperties<TComponent>> configure);
}
