using RoyalCode.Yasamen.BlazorShow;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Components;
using RoyalCode.Yasamen.Demos.Wasm.Shows.Contents;
using RoyalCode.Yasamen.Icons.Bootstrap;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Components;

public class DropIconShow : IShow<DropIcon>
{
    public void Create(IShowDescriptionBuilder<DropIcon> builder)
    {
        builder.Group("Components")
            .Name("DropIcon")
            .Route("drop-icon")
            .Description("The DropIcon component is an icon inside a button that can be clicked and has a drop-down menu.")
            .Properties(cfg =>
            {
                cfg.Property(p => p.ChildContent)
                    .Description("The itens of the drop menu");
                cfg.Property(p => p.Kind).HasEnumValues<BsIconNames>()
                        .Description("The icon shown on the button.");
            })
            .AddScene(s =>
            {
                s.Default()
                    .Description("The default scene.")
                    .Properties(sp =>
                    {
                        sp.Property(p => p.Kind).DefaultValue(BsIconNames.MenuAppFill);
                        sp.Property(p => p.ChildContent).RenderComponent<DropMenuSample>();
                    });
            })
            .AddScene(s =>
            {
                s.Name("Custom content type")
                    .Description("Drop icon with custom content type.")
                    .Properties(sp =>
                    {
                        sp.Property(p => p.Kind).DefaultValue(BsIconNames.MenuAppFill);
                        sp.Property(p => p.ChildContent).RenderComponent<DropContentSample>();
                        sp.Property(p => p.ContentType).DefaultValue(DropContentType.NotDefined);
                        sp.Property(p => p.MinWidth).DefaultValue(Sizes.Medium);
                        sp.Property(p => p.CloseBehavior).DefaultValue(DropCloseBehavior.CloseOnClickOutside);
                    });
            });
    }
}