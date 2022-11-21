using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
using RoyalCode.Yasamen.Demos.Wasm.Shows.ValueSets;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Layouts;

public class BoxShow : IShow<Box>
{
    public void Create(IShowDescriptionBuilder<Box> builder)
    {
        builder.Group("Layout")
            .Name("Box")
            .Description("A box layout.")
            .RenderInFrame()
            .Properties(p =>
            {
                p.Property(b => b.Border).HasValueSet<BorderValueSet>();
            })
            .AddScene(sb =>
            {
                sb.Default().RenderInFrame(o => o.CentralizeContent = false)
                .Properties(ps =>
                {
                    ps.Property(p => p.ChildContent)
                        .RenderComponent<RawText>(d => d.Property(r => r.Text).SetValue("Box content"));
                });
            });
    }
}

public class RawText : ComponentBase
{
    [Parameter]
    public string Text { get; set; } = "Raw Text";

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenRegion(0);
        builder.AddContent(1, Text);
        builder.CloseRegion();
    }
}