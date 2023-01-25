using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons.Extensions;
using RoyalCode.Yasamen.Services;

namespace RoyalCode.Yasamen.Forms.Components;

public class SelectModelField<TModel, TValue> : SelectFieldBase<TValue>
    where TModel : class
{
    private readonly Func<IModelLoader<TModel>, ValueTask> listener;

    private IModelLoader<TModel> loader = null!;
    private Func<TModel, object> descriptor = null!;
    private Func<TModel, TValue> key = null!;
    private bool hasChildContent;

    public SelectModelField()
    {
        listener = CheckSelectedValue;
    }

    [Inject]
    public IDataServicesProvider DataServicesProvider { get; set; } = null!;

    [Parameter]
    public IEnumerable<TModel>? Values { get; set; }

    [Parameter]
    public IModelLoader<TModel>? Loader { get; set; }

    [Parameter]
    public RenderFragment<TModel>? ChildContent { get; set; }

    [Parameter]
    public Func<TModel, object>? Descriptor { get; set; }

    [Parameter]
    public Func<TModel, TValue>? Key { get; set; }

    [Parameter]
    public string? EmptyDescription { get; set; }

    [Parameter]
    public TValue? EmptyValue { get; set; }

    protected override int RenderOptions(RenderTreeBuilder builder, int index)
    {
        if (!hasChildContent)
        {
            TValue defaultKey = EmptyValue ?? default!;
            string? value = FormatValue(defaultKey);

            builder.OpenElement(1 + index, "option");
            builder.AddAttribute(2 + index, "value", value ?? string.Empty);
            builder.AddContent(3 + index, EmptyDescription ?? string.Empty);
            builder.SetKey(defaultKey);
            builder.CloseElement();
        }
        
        foreach (var item in loader.Values)
        {
            if (hasChildContent)
            {
                builder.AddContent(index, ChildContent, item);
            }
            else
            {
                TValue modelKey = GetValueFromModel(item);
                string? value = FormatValue(modelKey);
                
                builder.OpenElement(1 + index, "option");
                builder.AddAttribute(2 + index, "value", value);
                builder.AddContent(3 + index, descriptor(item));
                builder.SetKey(modelKey);
                builder.CloseElement();
            }
        }

        return index + 4;
    }

    protected virtual TValue GetValueFromModel(TModel model) => key(model);

    protected virtual async ValueTask CheckSelectedValue(IModelLoader<TModel> loader)
    {
        if (!loader.IsLoading
            && !loader.IsFirstLoad
            && CurrentValueAsString is not null
            && !CheckIfContainsSelectedValue(loader.Values))
        {
            CurrentValue = default;
        }

        await InvokeAsync(StateHasChanged);
    }

    protected virtual bool CheckIfContainsSelectedValue(IEnumerable<TModel> models)
    {
        if (CurrentValue is null)
            return true;

        return models?.Any(m => CurrentValue.Equals(key(m))) ?? false;
    }

    protected override bool IsLoading => loader.IsLoading || base.IsLoading;

    protected override void OnParametersSet()
    {
        if (Values is not null)
        {
            loader = Values.ToModelLoader();
        }
        else if (Loader is not null && !ReferenceEquals(loader, Loader))
        {
            Listen(Loader);
            loader = Loader;
        }
        else if (loader is null)
        {
            var newLoader = DataServicesProvider.GetLoader<TModel>();
            newLoader.LoadAsync();
            Listen(newLoader);
            loader = newLoader;
        }

        hasChildContent = ChildContent.IsNotEmptyFragment();
        if (hasChildContent && (Descriptor is not null || EmptyDescription is not null))
        {
            throw new InvalidOperationException($"{GetType()} has 'Descriptor' or 'EmptyDescription' and 'ChildContent' setted, but this is not allowed." +
                $"Use 'ChildContent' or 'Descriptor' and 'EmptyDescription'.");
        }

        key = Key ?? key ?? CreateKey() ?? throw new InvalidOperationException(
            $"Could not get the Key of the model '{typeof(TModel).Name}' with the type '{typeof(TValue).Name}'.");
        
        if (!hasChildContent)
            descriptor = Descriptor ?? descriptor ?? CreateDescriptor();
        
        base.OnParametersSet();
    }
    
    protected override void Dispose(bool disposing)
    {
        loader?.RemoveListener(listener);

        base.Dispose(disposing);
    }

    private void Listen(IModelLoader<TModel> newLoader)
    {
        loader?.RemoveListener(listener);
        newLoader.AddListener(listener);
    }

    private Func<TModel, object> CreateDescriptor()
    {
        return KeyAndDescriptionFunctionDelegates.GetModelDescriptor<TModel>();
    }

    private Func<TModel, TValue>? CreateKey()
    {
        return KeyAndDescriptionFunctionDelegates.GetKeyFunction<TModel, TValue>();
    }
}
