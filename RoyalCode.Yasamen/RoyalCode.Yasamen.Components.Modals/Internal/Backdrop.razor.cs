using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Components.Internal;

public partial class Backdrop : ComponentBase
{
    private static CssMap<Backdrop> classes = Css.Map<Backdrop>()
        .Add("modal-backdrop fade")
        .Add(b => b.Show, "show")
        .Build();

    private readonly RenderFragment render;

    public Backdrop()
    {
        render = Render;
    }

    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    [Parameter]
    public bool Show { get; set; }

    protected void Render(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", classes(this));
        builder.AddAttribute(2, "id", "modal-backdrop");
        builder.AddAttribute(3, "tabindex", "-1");
        if (Show)
        {
            builder.AddAttribute(4, "aria-modal", "true");
            builder.AddAttribute(5, "role", "dialog"); // TODO: move to dialog
        }
        else
        {
            builder.AddAttribute(6, "aria-hidden", "true");
        }

        builder.AddContent(7, ChildContent);

        builder.CloseElement();
    }
}
