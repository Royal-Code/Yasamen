using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface ISceneBuilder<TComponent>
    where TComponent : class, IComponent
{
    ISceneBuilder<TComponent> Default();

    ISceneBuilder<TComponent> Name(string name);

    ISceneBuilder<TComponent> Description(string description);

    ISceneBuilder<TComponent> RenderInFrame(Action<FrameOptions>? configure = null);
}
