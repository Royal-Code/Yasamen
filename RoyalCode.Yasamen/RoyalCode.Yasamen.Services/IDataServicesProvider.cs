using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Services;

public interface IDataServicesProvider
{
    IModelFinder<TModel> GetFinder<TModel>(string? alias = null)
        where TModel: class;
}

internal class DataServicesProvider : IDataServicesProvider
{
    private readonly IServiceProvider provider;

    public DataServicesProvider(IServiceProvider provider)
    {
        this.provider = provider;
    }

    public IModelFinder<TModel> GetFinder<TModel>(string? alias = null)
        where TModel: class
        => new ModelFinder<TModel>(provider);
}

public interface IModelFinder<TModel>
    where TModel: class 
{
    Task<TModel?> FindAsync(object? filter, CancellationToken token = default);
}

internal class ModelFinder<TModel> : IModelFinder<TModel>
    where TModel: class
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

        var type = typeof(FinderServiceExecutor<,>).MakeGenericType(typeof(TModel), filter.GetType());
        
        Tracer.Write("ModelFinder", "FindAsync", $"locate service: {type.FullName}");

        var service = provider.GetService(type);
        if (service is null)
        {
            Tracer.Write("ModelFinder", "FindAsync", "The service is null, returning default");

            return default;
        }

        Tracer.Write("ModelFinder", "FindAsync", $"Calling ExecuteAsync: {filter}");

        var executor = (IFinderServiceExecutor<TModel>) service;
        var result = await executor.ExecuteAsync(filter, token);

        Tracer.Write("ModelFinder", "FindAsync", $"Executed: {filter}");

        return result;
    }
}

internal interface IFinderServiceExecutor<TModel>
    where TModel: class
{
    Task<TModel?> ExecuteAsync(object filter, CancellationToken cancellationToken);
}

internal class FinderServiceExecutor<TModel, TFilter> : IFinderServiceExecutor<TModel>
    where TModel: class
{
    private readonly IFinder<TModel, TFilter> finder;

    public FinderServiceExecutor(IFinder<TModel, TFilter> finder)
    {
        this.finder = finder ?? throw new ArgumentNullException(nameof(finder));
    }

    public async Task<TModel?> ExecuteAsync(object filter, CancellationToken cancellationToken)
    {
        return await finder.FindAsync((TFilter)filter, cancellationToken);
    }
}

public interface IFinder<TModel, in TFilter>
    where TModel: class
{
    Task<TModel?> FindAsync(TFilter filter, CancellationToken token = default);
}