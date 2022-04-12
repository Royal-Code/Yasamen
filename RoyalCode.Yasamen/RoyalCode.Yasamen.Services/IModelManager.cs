namespace RoyalCode.Yasamen.Services;

public interface IModelManager
{

    IModelFinder<TModel, TFilter> GetFinder<TModel, TFilter>();
}

public interface IModelFinder<TModel, TFilter>
{
    Task<TModel> FindAsync(TFilter filter, CancellationToken token = default);
}