using RoyalCode.Yasamen.Components;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
using RoyalCode.Yasamen.Icons.Bootstrap;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Components
{
    public class ButtonShow : IShow<Button>
    {
        public void Create(IShowDescriptionBuilder<Button> builder)
        {
            builder.Group("Components")
                .Name("Button")
                .Route("button")
                .Description("The Button component is a simple button that can be clicked.")
                .Properties(cfg =>
                {
                    cfg.Property(p => p.Label)
                        .Description("The label shown on the button.");
                    cfg.Property(p => p.ChildContent)
                        .Description("A custom content of the button.");
                    cfg.Property(p => p.OnClick)
                        .Description("The event that is triggered when the button is clicked.");
                    cfg.Property(p => p.Icon).HasEnumValues<BsIconNames>()
                        .Description("The icon shown on the button.");
                })
                .AddScene(s =>
                {
                    s.Default()
                        .Properties(sp =>
                        {
                            sp.Property(p => p.Label).DefaultValue("Press the button");
                            sp.Property(p => p.NavigateTo).DefaultValue(string.Empty);
                            sp.Property(p => p.Icon).DefaultValue(null);
                        });
                });
        }
    }
}
