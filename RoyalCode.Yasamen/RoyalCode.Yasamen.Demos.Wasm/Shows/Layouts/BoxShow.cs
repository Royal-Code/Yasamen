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
                sb.Default();
            });
    }
}
