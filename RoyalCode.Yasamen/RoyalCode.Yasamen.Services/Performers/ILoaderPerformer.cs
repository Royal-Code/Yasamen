namespace RoyalCode.Yasamen.Services.Performers;

internal interface ILoaderPerformer<TModel>
{
    Task<IEnumerable<TModel>> LoadAsync(CancellationToken token = default);
}
