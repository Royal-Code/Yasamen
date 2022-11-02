namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IShowDescription
{
    public Type ComponentType { get; }

    IEnumerable<IScene> Scenary { get; }
}
