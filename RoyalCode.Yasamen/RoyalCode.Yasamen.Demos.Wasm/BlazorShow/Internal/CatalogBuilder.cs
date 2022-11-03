namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class CatalogBuilder : ICatalogBuilder
{
    private readonly Catalog catalog = new();

    ICatalogBuilder ICatalogBuilder.AddShow<TShow, TComponent>(TShow show)
    {
        var description = new ShowDescription(typeof(TShow));
        var builder = new ShowDescriptionBuilder<TComponent>(description);
        show.Create(builder);

        catalog.AddShowDescription(description);

        return this;
    }
}