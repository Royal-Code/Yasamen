using RoyalCode.Yasamen.BlazorShow;
using RoyalCode.Yasamen.Components;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Components
{
    public class ProgressStackedShow : IShow<ProgressStacked>
    {
        public void Create(IShowDescriptionBuilder<ProgressStacked> builder)
        {
            builder.Group("Components")
            .Name("Progress stacked")
            .Route("progress-stacked")
            .Description("Multiples progress bars can be stacked together to show multiple progress.")
            .Properties(cfg =>
            {

            })
            .AddScene(s =>
            {
                s.Default()
                    .Properties(ps =>
                    {
                        ps.Property(p => p.MaxValue).DefaultValue(180);
                        ps.Property(p => p.ChildContent)
                            .RenderComponent<ProgressBar>(b =>
                            {
                                b.Property(p => p.Stacked).SetValue(true);
                                b.Property(p => p.Striped).SetValue(true);
                                b.Property(p => p.Animated).SetValue(true);
                                b.Property(p => p.MinValue).SetValue(0);
                                b.Property(p => p.MaxValue).SetValue(100);
                                b.Property(p => p.CurrentValue).SetValue(50);
                                b.Property(p => p.Style).SetValue(ProgressBarStyles.Danger);
                            })
                            .RenderComponent<ProgressBar>(b =>
                            {
                                b.Property(p => p.Stacked).SetValue(true);
                                b.Property(p => p.Striped).SetValue(true);
                                b.Property(p => p.Animated).SetValue(true);
                                b.Property(p => p.MinValue).SetValue(0);
                                b.Property(p => p.MaxValue).SetValue(20);
                                b.Property(p => p.CurrentValue).SetValue(15);
                                b.Property(p => p.Style).SetValue(ProgressBarStyles.Warning);
                            })
                            .RenderComponent<ProgressBar>(b =>
                            {
                                b.Property(p => p.Stacked).SetValue(true);
                                b.Property(p => p.Striped).SetValue(true);
                                b.Property(p => p.Animated).SetValue(true);
                                b.Property(p => p.MinValue).SetValue(0);
                                b.Property(p => p.MaxValue).SetValue(60);
                                b.Property(p => p.CurrentValue).SetValue(50);
                                b.Property(p => p.Style).SetValue(ProgressBarStyles.Success);
                            });
                    });
            });
        }
    }
}
