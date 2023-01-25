using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons.Extensions;
using RoyalCode.Yasamen.Services;

namespace RoyalCode.Yasamen.Forms.Components;

public class SelectModelField<TModel, TValue> : SelectFieldBase<TValue>
    where TModel : class
{
    private IModelLoader<TModel> loader = null!;
    private Func<TModel, object> description = null!;
    private Func<TModel, object> key = null!;

    public SelectModelField()
    {
        
    }
    
    protected virtual RenderFragment<TModel> DefaultContent { get; }

    [Inject]
    public IDataServicesProvider DataServicesProvider { get; set; }

    [Parameter]
    public IEnumerable<TModel>? Values { get; set; }

    [Parameter]
    public IModelLoader<TModel> Loader { get; set; }

    [Parameter]
    public RenderFragment<TModel> ChildContent { get; set; }

    [Parameter]
    public Func<TModel, object> Description { get; set; }

    [Parameter]
    public Func<TModel, object> Key { get; set; }
    
    protected override int RenderOptions(RenderTreeBuilder builder, int index)
    {
        foreach (var item in loader.Values)
        {
            if (ChildContent.IsNotEmptyFragment())
            {
                builder.AddContent(index, ChildContent, item);
            }
            else
            {
                object modelKey = key(item);
                builder.OpenElement(1 + index, "option");
                builder.AddAttribute(2 + index, "value", modelKey);
                builder.AddContent(3 + index, description(item));
                builder.SetKey(modelKey);
                builder.CloseElement();
            }
        }

        return index + 4;
    }

    protected override void OnParametersSet()
    {
        if (Values is not null)
        {
            loader = Values.ToModelLoader();
        }
        else if (Loader is not null)
        {
            loader = Loader;
        }
        else
        {
            loader = DataServicesProvider.GetLoader<TModel>();
        }

        description = Description ?? description ?? CreateDescription();
        key = Key ?? key ?? CreateKey();

        base.OnParametersSet();
    }

    private Func<TModel, object> CreateDescription()
    {
        return KeyAndDescriptionFunctionDelegates.GetModelDescription<TModel>();
    }

    private Func<TModel, object> CreateKey()
    {
        return KeyAndDescriptionFunctionDelegates.GetKeyFunction<TModel>();
    }
}
