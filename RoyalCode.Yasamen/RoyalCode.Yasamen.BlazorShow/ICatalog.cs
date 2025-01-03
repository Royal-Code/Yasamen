namespace RoyalCode.YasamenBlazorShow;

public interface ICatalog
{
    public IEnumerable<IShowDescription> ShowDescriptions { get; }
}
