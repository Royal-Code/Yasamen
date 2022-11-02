namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IScene
{

}

public interface IScene<TComponent> : IScene
{

}

public interface ISceneBuilder
{
    ISceneBuilder Default();
}