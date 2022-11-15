namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IScenePropertyDescription : IShowPropertyDescription
{
    object? DefaultValue { get; }

    bool HasComponents { get; }
}
