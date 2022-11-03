using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
using RoyalCode.Yasamen.Icons;
using RoyalCode.Yasamen.Icons.Bootstrap;

namespace RoyalCode.Yasamen.Demos.Wasm.Models;

public class IconShow : IShow<Icon>
{
    public void Create(IShowDescriptionBuilder<Icon> builder)
    {
        builder.Group("Graphics")
            .Name("Icon")
            .Route("icon")
            .Description("A component that represents an icon pre-defined by an enum")
            .Properties(cfg =>
            {
                cfg.Property(i => i.Kind)
                    .Name("Icon Kind")
                    .Description("Choose an icon kind, and the component will show the icon for the selected value")
                    .HasEnumValues<BsIconNames>();

                cfg.Property(i => i.AdditionalAttributes).HtmlAttributes();

                cfg.Property(i => i.AdditionalClasses).HtmlClasses();
            })
            .AddScene(sceneBuilder =>
            {
                sceneBuilder.Default();
            });
    }
}
