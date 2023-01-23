using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace RoyalCode.Yasamen.Forms.Components;

public class SelectModelField<TModel, TValue> : SelectFieldBase<TValue>
{
    
    protected virtual RenderFragment<TModel> DefaultContent { get; }

    [Parameter]
    public IEnumerable<TModel> Values
    {
        get => _valuesAsModelLoader?.Values;
        set => _valuesAsModelLoader = value.AsModelLoader();
    }


    
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

    
}
