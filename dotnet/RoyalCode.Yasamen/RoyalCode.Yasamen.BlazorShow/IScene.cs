using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.BlazorShow;

public interface IScene
{
    IShowDescription Show { get; }

    bool IsDefault { get; }

    string? Name { get; }

    string? Description { get; }

    TextAlign Align { get; }

    ShowRenderKind? RenderKind { get; set; }

    FrameOptions FrameOptions { get; }

    IEnumerable<IScenePropertyDescription> SceneProperties { get; }

    string GetRoute();
}

public interface IScene<TComponent> : IScene
{

}