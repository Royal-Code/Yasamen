using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
using RoyalCode.Yasamen.Icons;
using RoyalCode.Yasamen.Icons.Bootstrap;
using RoyalCode.Yasamen.Layout.Admin;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Layouts;

public class AppLayoutShow : IShow<AppLayout>
{
    public void Create(IShowDescriptionBuilder<AppLayout> builder)
    {
        builder.Group("Layout")
            .Name("App Layout")
            .Description("This is a layout for the application.")
            .RenderInFrame()
            .AddScene(s => s.Default()
                .RenderInFrame(o => o.CentralizeContent = false)
                .Properties(ps =>
                {
                    ps.Property(l => l.NavBarShadow).DefaultValue(true);
                    ps.Property(l => l.TopStart)
                        .RenderComponent<AppBrand>()
                        .RenderComponent<AppMenuButton>(b =>
                        {
                            b.Property(m => m.ChildContent)
                                .RenderComponent<Icon>(i => i.Property(ic => ic.Kind).SetValue(BsIconNames.List));
                        });
                }));
    }
}
