﻿using Microsoft.AspNetCore.Components;

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

    public ISceneBuilder<TComponent> RenderInFrame(Action<FrameOptions>? configure = null)
    {
        scene.RenderKind = ShowRenderKind.Frame;
        configure?.Invoke(scene.FrameOptions);
        return this;
    }
}
