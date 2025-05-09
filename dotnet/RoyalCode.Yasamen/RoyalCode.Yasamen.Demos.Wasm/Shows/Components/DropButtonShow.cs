using RoyalCode.Yasamen.BlazorShow;
using RoyalCode.Yasamen.Components;
using RoyalCode.Yasamen.Demos.Wasm.Shows.Contents;
using RoyalCode.Yasamen.Icons.Bootstrap;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Components;

public class DropButtonShow : IShow<DropButton>
{
    public void Create(IShowDescriptionBuilder<DropButton> builder)
    {
        builder.Group("Components")
            .Name("DropButton")
            .Route("drop-button")
            .Description("The DropButton component is a button that can be clicked and has a drop-down menu.")
            .Properties(cfg =>
            {
                cfg.Property(p => p.Label)
                    .Description("The label shown on the button.");
                cfg.Property(p => p.ChildContent)
                    .Description("The itens of the drop menu");
                cfg.Property(p => p.Icon).HasEnumValues<BsIconNames>()
                    .Description("The icon shown on the button.");
            })
            .AddScene(s =>
            {
                s.Default()
                    .Properties(sp =>
                    {
                        sp.Property(p => p.Label).DefaultValue("Click to open the menu");
                        sp.Property(p => p.Icon).DefaultValue(null);
                        sp.Property(p => p.Style).DefaultValue(ButtonStyles.Primary);
                        sp.Property(p => p.ChildContent).RenderComponent<DropMenuSample>();
                    });
            });
    }
}
