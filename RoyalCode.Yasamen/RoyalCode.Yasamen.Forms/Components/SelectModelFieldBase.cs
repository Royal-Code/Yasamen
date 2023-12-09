using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons.Extensions;
using RoyalCode.Yasamen.Services;

namespace RoyalCode.Yasamen.Forms.Components;

public abstract class SelectModelFieldBase<TModel, TValue> : SelectFieldBase<TValue>
    where TModel : class
{
    private readonly Func<IModelLoader<TModel>, ValueTask> listener;

    private Func<TModel, object> descriptor = null!;
    private bool hasChildContent;
    private IModelLoader<TModel> loader = null!;

    protected SelectModelFieldBase()
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
    public string? EmptyDescription { get; set; }

    [Parameter]
    public TValue? EmptyValue { get; set; }

    [Parameter]
    public string? LoaderName { get; set; }

    protected abstract TValue GetKeyFromModel(TModel model);

    protected virtual object? GetModelDescriptor(TModel model) => descriptor(model);

    protected override bool IsLoading => loader.IsLoading || base.IsLoading;

    protected virtual IEnumerable<TModel> OptionsValues => loader.Values;

    protected virtual string? DefaultOptionValue { get; private set; }
    
    protected override int RenderOptions(RenderTreeBuilder builder, int index)
    {
        if (!hasChildContent)
        {
            TValue defaultKey = GetDefaultValue();

            builder.OpenElement(1 + index, "option");
            builder.AddAttribute(2 + index, "value", DefaultOptionValue);
            builder.AddContent(3 + index, EmptyDescription ?? string.Empty);
            builder.SetKey(defaultKey);
            builder.CloseElement();
        }

        foreach (var item in OptionsValues)
        {
            if (hasChildContent)
            {
                builder.AddContent(index, ChildContent, item);
            }
            else
            {
                TValue modelKey = GetKeyFromModel(item);
                string? value = FormatValue(modelKey);

                builder.OpenElement(1 + index, "option");
                builder.AddAttribute(2 + index, "value", value);
                builder.AddContent(3 + index, GetModelDescriptor(item));
                builder.SetKey(modelKey);
                builder.CloseElement();
            }
        }

        return index + 4;
    }

    protected virtual TValue GetDefaultValue() => EmptyValue ?? default!;

    protected override void OnParametersSet()
    {
        hasChildContent = ChildContent.IsNotEmptyFragment();

        if (hasChildContent && (Descriptor is not null || EmptyDescription is not null))
        {
            throw new InvalidOperationException($"{GetType()} has 'Descriptor' or 'EmptyDescription' and 'ChildContent' setted, but this is not allowed." +
                $"Use 'ChildContent' or 'Descriptor' and 'EmptyDescription'.");
        }

        if (!hasChildContent)
            descriptor = Descriptor ?? descriptor ?? KeyAndDescriptionFunctionDelegates.GetModelDescriptor<TModel>();

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
            var newLoader = DataServicesProvider.GetLoader<TModel>(LoaderName);
            newLoader.LoadAsync();
            Listen(newLoader);
            loader = newLoader;
        }

        DefaultOptionValue = FormatValue(GetDefaultValue()) ?? string.Empty;

        base.OnParametersSet();
    }
    
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

        return models?.Any(m => CurrentValue.Equals(GetKeyFromModel(m))) ?? false;
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
}
