using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
using RoyalCode.Yasamen.Demos.Wasm.Shows.ValueSets;
using RoyalCode.Yasamen.Layout;

namespace RoyalCode.Yasamen.Demos.Wasm.Shows.Layouts;

public class ArticleBoxShow : IShow<ArticleBox>
{
    public void Create(IShowDescriptionBuilder<ArticleBox> builder)
    {
        builder.Group("Layout")
            .Name("Article Box")
            .Description("A box layout with an article.")
            .RenderInFrame()
            .Properties(p =>
            {
                p.Property(b => b.ArticleBorder).HasValueSet<BorderValueSet>();
                p.Property(b => b.HeaderBorder).HasValueSet<BorderValueSet>();
                p.Property(b => b.FooterBorder).HasValueSet<BorderValueSet>();
            })
            .AddScene(sb =>
            {
                sb.Default().RenderInFrame(o => o.CentralizeContent = false)
                .Properties(ps =>
                {
                    ps.Property(p => p.MainContent)
                        .RenderComponent<RawText>(d => d.Property(r => r.Text).SetValue("Main content"));
                    ps.Property(p => p.HeaderContent)
                        .RenderComponent<RawText>(d => d.Property(r => r.Text).SetValue("Header content"));
                    ps.Property(p => p.FooterContent)
                        .RenderComponent<RawText>(d => d.Property(r => r.Text).SetValue("Footer content"));

                    ps.Property(b => b.ArticleBorder).DefaultValue(Borders.DefaultNone);
                    ps.Property(b => b.HeaderBorder).DefaultValue(Borders.DefaultForHeaders with { Shadow = Shadows.Small });
                    ps.Property(b => b.FooterBorder).DefaultValue(Borders.DefaultForFooters);

                    ps.Property(b => b.HeaderAdditionalClasses).DefaultValue(new List<string>() { "p-3", "mb-4" });
                    ps.Property(b => b.FooterAdditionalClasses).DefaultValue(new List<string>() { "p-3", "mt-4" });
                });
            });
    }
}
