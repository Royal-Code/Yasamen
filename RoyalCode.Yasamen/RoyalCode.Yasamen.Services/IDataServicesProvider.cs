namespace RoyalCode.Yasamen.Services;

public interface IDataServicesProvider
{
    IModelFinder<TModel> GetFinder<TModel>(string? alias = null)
        where TModel: class;

    IModelLoader<TModel> GetLoader<TModel>(string? alias = null)
        where TModel : class;
}

public interface IModelSearch<TModel>
{
    Task<IEnumerable<TModel>> FilterByAsync(object? filter, CancellationToken token = default);
}
