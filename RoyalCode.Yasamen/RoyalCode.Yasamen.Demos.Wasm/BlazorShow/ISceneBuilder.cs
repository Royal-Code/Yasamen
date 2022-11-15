using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface ISceneBuilder<TComponent>
    where TComponent : class, IComponent
{
    ISceneBuilder<TComponent> Default();

    ISceneBuilder<TComponent> Name(string name);

    ISceneBuilder<TComponent> Description(string description);

    ISceneBuilder<TComponent> RenderInFrame(Action<FrameOptions>? configure = null);

    ISceneBuilder<TComponent> Properties(Action<ISceneProperties<TComponent>> configure);
}
