namespace RoyalCode.Yasamen.Services.Internal;

internal class DataServicesProvider : IDataServicesProvider
{
    private readonly IServiceProvider provider;

    public DataServicesProvider(IServiceProvider provider)
    {
        this.provider = provider;
    }

    public IModelFinder<TModel> GetFinder<TModel>(string? alias = null)
        where TModel : class
        => new ModelFinder<TModel>(provider);
}
