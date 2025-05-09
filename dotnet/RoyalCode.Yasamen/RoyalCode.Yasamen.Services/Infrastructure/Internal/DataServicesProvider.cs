namespace RoyalCode.Yasamen.Services.Infrastructure.Internal;

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

    public IModelLoader<TModel> GetLoader<TModel>(string? alias = null) 
        where TModel : class
    {
        return new ModelLoader<TModel>(provider, alias);
    }
}