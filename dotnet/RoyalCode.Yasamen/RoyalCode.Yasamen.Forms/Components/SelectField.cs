using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class SelectField<TValue> : SelectFieldBase<TValue>
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    protected override int RenderOptions(RenderTreeBuilder builder, int index)
    {
        builder.AddContent(index, ChildContent);
        return index + 1;
    }
}
