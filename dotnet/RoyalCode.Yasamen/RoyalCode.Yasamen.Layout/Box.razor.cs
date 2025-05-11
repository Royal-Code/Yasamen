using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Layout;

public partial class Box : YasamenBase
{
    [Parameter]
    public BorderClasses Border { get; set; } = Css.Border.Box();

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public Sizes MinHeight { get; set; }

    [Parameter]
    public ItemAlign Align { get; set; } = ItemAlign.Center;

    [Parameter]
    public ContentJustify Justify { get; set; } = ContentJustify.Start;

    [Parameter]
    public BoxStyles Style { get; set; }
}
