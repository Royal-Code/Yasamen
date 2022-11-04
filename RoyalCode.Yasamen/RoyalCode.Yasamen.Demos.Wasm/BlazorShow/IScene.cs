namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IScene
{
    bool IsDefault { get; }

    string? Name { get; }

    string? Description { get; }
}

public interface IScene<TComponent> : IScene
{

}

public interface ISceneBuilder
{
    ISceneBuilder Default();
}