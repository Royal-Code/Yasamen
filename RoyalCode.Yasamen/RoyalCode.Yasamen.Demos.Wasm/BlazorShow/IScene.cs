namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IScene
{
    IShowDescription Show { get; }

    bool IsDefault { get; }

    string? Name { get; }

    string? Description { get; }

    ShowRenderKind? RenderKind { get; set; }

    FrameOptions FrameOptions { get; }

    IEnumerable<IScenePropertyDescription> SceneProperties { get; }

    string GetRoute();
}

public interface IScene<TComponent> : IScene
{

}