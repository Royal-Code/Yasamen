namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IScene
{
    bool IsDefault { get; }

    string? Name { get; }
}

public interface IScene<TComponent> : IScene
{

}

public interface ISceneBuilder
{
    ISceneBuilder Default();
}