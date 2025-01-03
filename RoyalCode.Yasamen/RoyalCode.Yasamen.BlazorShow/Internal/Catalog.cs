namespace RoyalCode.YasamenBlazorShow.Internal;

public class Catalog : ICatalog
{
    private readonly List<IShowDescription> showDescriptions = new();

    public IEnumerable<IShowDescription> ShowDescriptions => showDescriptions;

    public void AddShowDescription(IShowDescription showDescription) => showDescriptions.Add(showDescription);
}