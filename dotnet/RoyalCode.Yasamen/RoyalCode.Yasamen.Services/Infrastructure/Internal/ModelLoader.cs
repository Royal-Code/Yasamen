using Microsoft.Extensions.DependencyInjection;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Services.Infrastructure.Performers;
using System.Collections;

namespace RoyalCode.Yasamen.Services.Infrastructure.Internal;

internal class ModelLoader<TModel> : IModelLoader<TModel>
{
    private readonly IServiceProvider? provider;
    private readonly string? loaderName;
    private LinkedList<Func<IModelLoader<TModel>, ValueTask>>? callbacks;
    private bool? any;

    public ModelLoader(IReadOnlyList<TModel> values)
    {
        Values = values ?? throw new ArgumentNullException(nameof(values));
        NotLoaded = false;
    }

    public ModelLoader(IServiceProvider provider, string? loaderName)
    {
        Values = [];
        NotLoaded = true;
        IsFirstLoad = true;
        this.provider = provider;
        this.loaderName = loaderName;
    }

    public bool NotLoaded { get; private set; }

    public bool IsLoading { get; private set; }

    public bool IsFirstLoad { get; private set; }

    public bool HasError => LoadException is not null;

    public Exception? LoadException { get; private set; }

    public IReadOnlyList<TModel> Values { get; private set; }

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
        if (loaderName is null)
            await ExecuteAsync(token);
        else
            await ExecuteNamedAsync(token);

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
    
    private async Task ExecuteNamedAsync(CancellationToken token)
    {
        var loaderType = NamedLoaders.GetServiceType(loaderName!, typeof(TModel));

        if (loaderType is null)
        {
            Tracer.Write("ModelLoader", "ExecuteNamedAsync", "The name loader performer service type was not found for the type {0} and name {1}",
                typeof(TModel).FullName!,
                loaderName);

            return;
        }

        Tracer.Write("ModelLoader", "ExecuteNamedAsync", "locate service: {0}<{1}>",
            loaderType.Name,
            typeof(TModel).FullName!);

        var performer = provider!.GetService(loaderType);
        if (performer is not INamedLoaderPerformer<TModel> namedPerformer)
        {
            Tracer.Write("ModelLoader", "ExecuteNamedAsync", "The service '{0}<{1}>' is null or not is a INamedLoaderPerformer<{2}>, returning.",
                loaderType.Name,
                typeof(TModel).FullName!,
                typeof(TModel).Name!);

            return;
        }

        Tracer.Write("ModelLoader", "ExecuteNamedAsync", "Calling LoadAsync");

        try
        {
            Values = await namedPerformer.LoadAsync(loaderName, token);
            Tracer.Write("ModelLoader", "ExecuteNamedAsync", "load performed");
        }
        catch (Exception ex)
        {
            Tracer.Write("ModelLoader", "ExecuteNamedAsync", "Exception: {0}", ex);
            OnError(ex);
        }
    }

    private ValueTask BeginLoadAsync()
    {
        any = null;
        IsLoading = true;
        LoadException = null;
        Values = [];

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