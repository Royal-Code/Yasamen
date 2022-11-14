using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
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
            .Properties(p =>
            {
                
            })
            .AddScene(s => s.Default().RenderInFrame(o => o.CentralizeContent = false));
    }
}
