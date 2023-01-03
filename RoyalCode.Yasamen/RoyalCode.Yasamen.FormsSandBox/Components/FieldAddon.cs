
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class FieldAddon : ComponentBase
{
    /// <summary>
    /// Specifies the content to be rendered inside this component.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? AdditionalClasses { get; set; }
    
    /// <summary>
    /// Gets or sets a collection of additional attributes that will be applied to the created element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "span");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        if (string.IsNullOrEmpty(AdditionalClasses))
        {
            builder.AddAttribute(2, "class", "input-group-text");
        }
        else
        {
            builder.AddAttribute(2, "class", $"input-group-text {AdditionalClasses}");
        }
        builder.AddAttribute(3, "b-input-field");
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
