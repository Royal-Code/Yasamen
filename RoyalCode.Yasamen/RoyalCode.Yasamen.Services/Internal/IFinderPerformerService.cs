namespace RoyalCode.Yasamen.Services.Internal;

internal interface IFinderPerformerService<TModel>
    where TModel : class
{
    Task<TModel?> PerformAsync(object filter, CancellationToken cancellationToken);
}
