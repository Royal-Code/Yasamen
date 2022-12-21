using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface ISceneBuilder<TComponent>
    where TComponent : class, IComponent
{
    ISceneBuilder<TComponent> Default();

    ISceneBuilder<TComponent> Name(string name);

    ISceneBuilder<TComponent> Description(string description);

    ISceneBuilder<TComponent> Align(Align align);

    ISceneBuilder<TComponent> RenderInFrame(Action<FrameOptions>? configure = null);

    ISceneBuilder<TComponent> Properties(Action<ISceneProperties<TComponent>> configure);
}
