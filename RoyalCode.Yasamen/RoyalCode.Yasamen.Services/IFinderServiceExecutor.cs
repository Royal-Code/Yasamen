namespace RoyalCode.Yasamen.Services;

internal interface IFinderServiceExecutor<TModel>
    where TModel: class
{
    Task<TModel?> ExecuteAsync(object filter, CancellationToken cancellationToken);
}
