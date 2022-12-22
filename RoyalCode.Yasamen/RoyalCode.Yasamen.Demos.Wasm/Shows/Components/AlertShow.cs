using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Components;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
using RoyalCode.Yasamen.Demos.Wasm.Shows.Layouts;
using RoyalCode.Yasamen.Icons;
using RoyalCode.Yasamen.Icons.Bootstrap;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Components;

public class AlertShow : IShow<Alert>
{
    public void Create(IShowDescriptionBuilder<Alert> builder)
    {
        builder.Group("Components")
            .Name("Alert")
            .Route("alert")
            .Description("The Alert Component.")
            .Properties(cfg =>
            {
                cfg.Property(p => p.Text)
                    .Description("The text of the alert.");
                cfg.Property(p => p.Title)
                    .Description("The title that is shown as the alert's header.");
                cfg.Property(p => p.ChildContent)
                    .Description("A custom content of the alert.");
            })
            .AddScene(s =>
            {
                s.Default()
                    .Align(Align.Start)
                    .Properties(ps =>
                    {
                        ps.Property(p => p.Text).DefaultValue("This is a simple alert.");
                        ps.Property(p => p.Title).DefaultValue(string.Empty);
                    });
            })
            .AddScene(s =>
            {
                s.Name("With Title")
                    .Align(Align.Start)
                    .Properties(ps =>
                    {
                        ps.Property(p => p.Text).DefaultValue("This is a simple alert.");
                        ps.Property(p => p.Title).DefaultValue("Alert Title");
                    });
            })
            .AddScene(s =>
            {
                s.Name("Custom content")
                    .Align(Align.Start)
                    .Properties(ps =>
                    {
                        ps.Property(p => p.Title).DefaultValue(string.Empty);
                        ps.Property(p => p.ChildContent)
                            .RenderComponent<Icon>(d => d.Property(r => r.Kind).SetValue(BsIconNames.Box))
                            .RenderComponent<RawText>(d => d.Property(r => r.Text).SetValue(" A custom alert with a icon, and "))
                            .RenderComponent<AlertLink>(d =>
                            {
                                d.Property(r => r.ChildContent)
                                    .RenderComponent<RawText>(d => d.Property(r => r.Text).SetValue("a link"));
                                d.Property(r => r.AdditionalAttributes).SetValue(new Dictionary<string, object>
                                {
                                    ["href"] = "/show/alert"
                                });
                            })
                            .RenderComponent<RawText>(d => d.Property(r => r.Text).SetValue(" inside."));
                    });
            });
    }
}
