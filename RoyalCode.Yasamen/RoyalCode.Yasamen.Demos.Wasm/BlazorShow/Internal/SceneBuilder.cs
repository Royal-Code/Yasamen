using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class SceneBuilder<TComponent> : ISceneBuilder
    where TComponent: class, IComponent
{
    private readonly Scene<TComponent> scene;

    public SceneBuilder(Scene<TComponent> scene)
    {
        this.scene = scene;
    }

    public ISceneBuilder Default()
    {
        scene.IsDefault = true;
        scene.Name = "Default";
        scene.Description = "Default scene.";
        return this;
    }
}
