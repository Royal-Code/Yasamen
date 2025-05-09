namespace RoyalCode.Yasamen.BlazorShow;

public interface ICatalog
{
    public IEnumerable<IShowDescription> ShowDescriptions { get; }
}
