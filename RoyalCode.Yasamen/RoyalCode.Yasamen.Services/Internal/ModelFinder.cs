using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Services.Internal;

internal class ModelFinder<TModel> : IModelFinder<TModel>
    where TModel : class
{
    private readonly IServiceProvider provider;

    public ModelFinder(IServiceProvider provider)
    {
        this.provider = provider;
    }

    public async Task<TModel?> FindAsync(object? filter, CancellationToken token = default)
    {
        if (filter is null)
        {
            Tracer.Write("ModelFinder", "FindAsync", "Filter is null, returning default");

            return default;
        }

        var type = typeof(FinderPerformerService<,>).MakeGenericType(typeof(TModel), filter.GetType());

        Tracer.Write("ModelFinder", "FindAsync", $"locate service: {type.FullName}");

        var service = provider.GetService(type);
        if (service is null)
        {
            Tracer.Write("ModelFinder", "FindAsync", "The service is null, returning default");

            return default;
        }

        Tracer.Write("ModelFinder", "FindAsync", $"Calling PerformAsync: {filter}");

        var executor = (IFinderPerformerService<TModel>)service;
        var result = await executor.PerformAsync(filter, token);

        Tracer.Write("ModelFinder", "FindAsync", $"Executed: {filter}");

        return result;
    }
}
