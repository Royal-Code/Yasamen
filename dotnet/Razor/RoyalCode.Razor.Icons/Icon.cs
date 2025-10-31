using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Razor.Icons.Factory;

namespace RoyalCode.Razor.Icons;

public class Icon : ComponentBase
{
    [Parameter, EditorRequired]
    public Enum Kind { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter]
    public string? AdditionalClasses { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (Kind is null)
        {
            builder.AddContent(0, "Icon not informed");
            return;
        }

        var factory = IconContentFactories.Get(Kind.GetType());
        var iconFragment = factory.GetFragment(Kind); // returns IconFragment delegate
        var renderFragment = iconFragment(AdditionalClasses, AdditionalAttributes);
        renderFragment(builder);
    }
}
