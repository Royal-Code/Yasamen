namespace RoyalCode.Yasamen.Services.Performers;

public interface IFinderPerformer<TModel, in TFilter>
    where TModel : class
{
    Task<TModel?> FindAsync(TFilter filter, CancellationToken token = default);
}