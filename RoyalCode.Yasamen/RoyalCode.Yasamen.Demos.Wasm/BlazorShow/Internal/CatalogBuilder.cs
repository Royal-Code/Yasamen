namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

public class CatalogBuilder : ICatalogBuilder
{
    private readonly Catalog catalog;

    public CatalogBuilder(Catalog catalog)
    {
        this.catalog = catalog;
    }

    ICatalogBuilder ICatalogBuilder.AddShow<TShow, TComponent>()
    {
        var description = new ShowDescription(typeof(TComponent));
        var builder = new ShowDescriptionBuilder<TComponent>(description);
        var show = new TShow();
        show.Create(builder);

        catalog.AddShowDescription(description);

        return this;
    }
}