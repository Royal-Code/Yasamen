namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class Catalog : ICatalog
{
    private readonly List<IShowDescription> showDescriptions = new();

    public IEnumerable<IShowDescription> ShowDescriptions => showDescriptions;

    public void AddShowDescription(IShowDescription showDescription) => showDescriptions.Add(showDescription);
}