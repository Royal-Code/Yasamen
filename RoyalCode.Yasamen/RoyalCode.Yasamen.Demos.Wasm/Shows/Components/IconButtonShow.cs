using RoyalCode.Yasamen.Components;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
using RoyalCode.Yasamen.Icons.Bootstrap;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Components
{
    public class IconButtonShow : IShow<IconButton>
    {
        public void Create(IShowDescriptionBuilder<IconButton> builder)
        {
            builder.Group("Components")
                .Name("Icon Button")
                .Route("icon-button")
                .Description("The Icon Button component is a icon inside a button that can be clicked.")
                .Properties(cfg =>
                {
                    
                    cfg.Property(p => p.OnClick)
                        .Description("The event that is triggered when the button is clicked.");
                    cfg.Property(p => p.Kind).HasEnumValues<BsIconNames>()
                        .Description("The icon shown on the button.");
                })
                .AddScene(s =>
                {
                    s.Default()
                        .Properties(sp =>
                        {
                            sp.Property(p => p.NavigateTo).DefaultValue(string.Empty);
                            sp.Property(p => p.Kind).DefaultValue(BsIconNames.Pin);
                        });
                });
        }
    }
}
