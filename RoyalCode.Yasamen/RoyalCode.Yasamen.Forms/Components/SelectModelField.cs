using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Services;

namespace RoyalCode.Yasamen.Forms.Components;

public class SelectModelField<TModel, TValue> : SelectFieldBase<TValue>
{
    private IModelLoader<TModel>? loader;

    public SelectModelField()
    {
        
    }
    
    protected virtual RenderFragment<TModel> DefaultContent { get; }

    [Parameter]
    public IEnumerable<TModel>? Values { get; set; }
    
    [Parameter]
    public RenderFragment<TModel> ChildContent { get; set; }

    [Parameter]
    public Func<TModel, string> Description { get; set; }

    [Parameter]
    public Func<TModel, TValue> Key { get; set; }
    
    protected override int RenderOptions(RenderTreeBuilder builder, int index)
    {

        
        
        throw new NotImplementedException();
    }

    protected override void OnParametersSet()
    {
        if (Values is not null)
        {
            loader = Values.ToModelLoader();
        }
        
        base.OnParametersSet();
    }
}
