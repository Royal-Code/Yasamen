using Microsoft.Extensions.DependencyInjection;
using RoyalCode.Razor.Components;

namespace RoyalCode.Razor.Buttons.Tests;

public class ButtonTests
{
    [Fact]
    public void Button_Render_Default()
    {
        using var ctx = new TestContext();
        
        ctx.Services.AddYasamenCommons();

        // Configura JS do ripple.
        ctx.JSInterop
            .SetupModule("./_content/RoyalCode.Razor.Commons/ripple.js")
            .SetupVoid("ripple", _ => true);

        var cut = ctx.RenderComponent<Button>(p => p.Add(c => c.Label, "OK"));

        // Assert: existe o botão
        var button = cut.Find("button");
        Assert.NotNull(button);

        // Assert: texto
        Assert.Equal("OK", button.TextContent.Trim());
        Assert.Contains("OK", button.TextContent);

        // Assert: atributos esperados
        Assert.Equal("button", button.GetAttribute("type"));
        Assert.False(button.HasAttribute("disabled"));

        // Assert: classes principais
        Assert.Contains("ya-btn", button.ClassName);

        // Assert: ripple presente
        var ripple = cut.Find("span.ripple");
        Assert.NotNull(ripple);

        // Assert: nenhum ícone (svg) presente por padrão
        Assert.Throws<ElementNotFoundException>(() => cut.Find("svg"));
    }
}
