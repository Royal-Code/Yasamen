using Microsoft.Extensions.DependencyInjection;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Services.Infrastructure.Performers;

namespace RoyalCode.Yasamen.Services.Infrastructure.Internal;

internal class ModelLoader<TModel> : IModelLoader<TModel>
//where TModel : class
{
    private readonly IServiceProvider? provider;
    private LinkedList<Func<IModelLoader<TModel>, ValueTask>>? callbacks;
    private bool? any;

    public ModelLoader(IEnumerable<TModel> values)
    {
        Values = values ?? throw new ArgumentNullException(nameof(values));
        NotLoaded = false;
    }

    public ModelLoader(IServiceProvider provider)
    {
        Values = Enumerable.Empty<TModel>();
        NotLoaded = true;
        IsFirstLoad = true;
        this.provider = provider;
    }

    public bool NotLoaded { get; private set; }

    public bool IsLoading { get; private set; }

    public bool IsFirstLoad { get; private set; }

    public bool HasError => LoadException is not null;

    public Exception? LoadException { get; private set; }

    public IEnumerable<TModel> Values { get; private set; }

    public bool Any
    {
        get
        {
            if (any.HasValue)
                return any.Value;

            if (NotLoaded)
                return false;

            if (IsLoading)
                return false;

            if (HasError)
                return false;

            any = Values.Any();
            return any.Value;
        }
    }

    public void AddListener(Func<IModelLoader<TModel>, ValueTask> callback)
    {
        callbacks ??= new LinkedList<Func<IModelLoader<TModel>, ValueTask>>();
        callbacks.AddLast(callback);
    }

    public void RemoveListener(Func<IModelLoader<TModel>, ValueTask> callback)
    {
        callbacks?.Remove(callback);
    }

    public async Task LoadAsync(CancellationToken token)
    {
        if (IsLoading)
            throw new InvalidOperationException("The data is already being loaded.");
        if (provider is null)
            return;

        await BeginLoadAsync();
        await ExecuteAsync(token);
        await EndLoadAsync();
    }

    private async Task ExecuteAsync(CancellationToken token)
    {
        Tracer.Write("ModelLoader", "ExecuteAsync", "locate service: {0}<{1}>",
            nameof(ILoaderPerformer<object>),
            typeof(TModel).FullName!);

        var performer = provider!.GetService<ILoaderPerformer<TModel>>();
        if (performer is null)
        {
            Tracer.Write("ModelLoader", "ExecuteAsync", "The service '{0}<{1}>' is null, returning.",
                nameof(ILoaderPerformer<object>),
                typeof(TModel).FullName!);

            return;
        }

        Tracer.Write("ModelLoader", "ExecuteAsync", "Calling LoadAsync");

        try
        {
            Values = await performer.LoadAsync(token);
            Tracer.Write("ModelLoader", "ExecuteAsync", "load performed");
        }
        catch (Exception ex)
        {
            Tracer.Write("ModelLoader", "ExecuteAsync", "Exception: {0}", ex);
            OnError(ex);
        }
    }

    private ValueTask BeginLoadAsync()
    {
        any = null;
        IsLoading = true;
        LoadException = null;
        Values = Enumerable.Empty<TModel>();

        return FireCallbacksAsync();
    }

    private ValueTask EndLoadAsync()
    {
        IsLoading = false;
        NotLoaded = false;
        IsFirstLoad = false;

        return FireCallbacksAsync();
    }

    private void OnError(Exception exception)
    {
        LoadException = exception;
    }

    private async ValueTask FireCallbacksAsync()
    {
        if (callbacks is null)
            return;

        foreach (var callback in callbacks)
        {
            try
            {
                await callback(this);
            }
            catch (Exception ex)
            {
                Tracer.Write("ModelLoader", "FireCallbacksAsync", "Error in callback: {0}", ex);
            }
        }
    }
}