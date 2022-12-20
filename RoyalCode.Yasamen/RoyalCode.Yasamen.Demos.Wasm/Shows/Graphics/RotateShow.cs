using RoyalCode.Yasamen.Animations;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
using RoyalCode.Yasamen.Icons;
using RoyalCode.Yasamen.Icons.Bootstrap;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Graphics
{
    public class RotateShow : IShow<RotateAnimation>
    {
        public void Create(IShowDescriptionBuilder<RotateAnimation> builder)
        {
            builder.Group("Graphics")
                .Name("Rotate")
                .Route("rotate")
                .Description("A component that applies a rotation animation.")
                .Properties(cfg =>
                {
                
                })
                .AddScene(sceneBuilder =>
                {
                    sceneBuilder.Default()
                        .Properties(ps =>
                        {
                            ps.Property(p => p.ChildContent)
                                .RenderComponent<Icon>(d => d.Property(r => r.Kind).SetValue(BsIconNames.Box));
                        });
                });
        }
    }
}
