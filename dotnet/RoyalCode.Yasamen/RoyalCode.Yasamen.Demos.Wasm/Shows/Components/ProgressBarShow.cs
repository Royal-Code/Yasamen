using RoyalCode.Yasamen.BlazorShow;
using RoyalCode.Yasamen.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Components;

public class ProgressBarShow : IShow<ProgressBar>
{
    public void Create(IShowDescriptionBuilder<ProgressBar> builder)
    {
        builder.Group("Components")
            .Name("Progress bar")
            .Route("progress-bar")
            .Description("A progress bar is a component that shows the progress of a task.")
            .Properties(cfg =>
            {
                
            })
            .AddScene(s =>
            {
                s.Default()
                    .Properties(ps =>
                    {
                        ps.Property(p => p.Striped).DefaultValue(true);
                        ps.Property(p => p.Animated).DefaultValue(true);
                        ps.Property(p => p.MinValue).DefaultValue(0);
                        ps.Property(p => p.MaxValue).DefaultValue(100);
                        ps.Property(p => p.CurrentValue).DefaultValue(50);
                    });
            });
    }
}
