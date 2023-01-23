namespace RoyalCode.Yasamen.Services;

public interface IModelFinder<TModel>
    where TModel: class 
{
    Task<TModel?> FindAsync(object? filter, CancellationToken token = default);
}
