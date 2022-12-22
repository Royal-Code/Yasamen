using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class SceneBuilder<TComponent> : ISceneBuilder<TComponent>
    where TComponent: class, IComponent
{
    private readonly Scene<TComponent> scene;

    public SceneBuilder(Scene<TComponent> scene)
    {
        this.scene = scene;
    }

    public ISceneBuilder<TComponent> Default()
    {
        scene.IsDefault = true;
        scene.Name = "Default";
        scene.Description = "Default scene.";
        return this;
    }

    public ISceneBuilder<TComponent> Description(string description)
    {
        scene.Description = description;
        return this;
    }

    public ISceneBuilder<TComponent> Name(string name)
    {
        scene.Name = name;
        return this;
    }

    public ISceneBuilder<TComponent> Align(Align align)
    {
        scene.Align = align;
        return this;
    }

    public ISceneBuilder<TComponent> Properties(Action<ISceneProperties<TComponent>> configure)
    {
        var properties = new SceneProperties<TComponent>(scene);
        configure(properties);
        return this;
    }

    public ISceneBuilder<TComponent> RenderInFrame(Action<FrameOptions>? configure = null)
    {
        scene.RenderKind = ShowRenderKind.Frame;
        configure?.Invoke(scene.FrameOptions);
        return this;
    }
}
