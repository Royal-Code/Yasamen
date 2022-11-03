namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface ICatalog
{
    public IEnumerable<IShowDescription> ShowDescriptions { get; }
}
