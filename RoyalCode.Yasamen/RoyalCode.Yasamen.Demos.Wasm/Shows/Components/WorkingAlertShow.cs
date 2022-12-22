using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Components;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Components
{
    public class WorkingAlertShow : IShow<WorkingAlert>
    {
        public void Create(IShowDescriptionBuilder<WorkingAlert> builder)
        {
            builder.Group("Components")
            .Name("Working Alert")
            .Route("working-alert")
            .Description("The Working Alert Component.")
            .Properties(cfg =>
            {
                cfg.Property(p => p.Text)
                    .Description("The text of the alert.");
                cfg.Property(p => p.ChildContent)
                    .Description("A custom content of the alert.");
            })
            .AddScene(s =>
            {
                s.Default()
                    .Align(Align.Start)
                    .Properties(ps =>
                    {
                        ps.Property(p => p.Text).DefaultValue("Your request is being processed.");
                    });
            });
        }
    }
}
