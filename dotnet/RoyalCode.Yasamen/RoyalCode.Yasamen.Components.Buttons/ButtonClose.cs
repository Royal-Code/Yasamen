using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Components;

public sealed class ButtonClose : ComponentBase
{
    private static readonly CssMap<ButtonClose> classes = Css.Map<ButtonClose>()
        .Add("btn-close")
        .Add(static c => c.AdditionalClasses)
        .Build();

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Parameter]
    public string? AdditionalClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "button");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", classes(this));
        builder.AddAttribute(3, "type", "button");
        builder.AddAttribute(4, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, OnClick));
        builder.AddAttribute(5, "aria-label", "Close");
        builder.CloseElement();
    }
}
