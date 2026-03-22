using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using RoyalCode.Razor.Components;
using RoyalCode.Razor.Icons.Factory;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Buttons.Tests;

public class ButtonGroupTests
{
    [Fact]
    public void ButtonGroup_Should_Render_Group_Role_And_Classes()
    {
        using var ctx = CreateContext();

        var cut = ctx.RenderComponent<ButtonGroup>(parameters => parameters
            .Add(p => p.AriaLabel, "Ações principais")
            .Add(p => p.ChildContent, ButtonContent("Salvar")));

        var group = cut.Find("div[role='group']");

        Assert.Contains("ya-btn-group", group.ClassList);
        Assert.Contains("ya-btn-group-horizontal", group.ClassList);
        Assert.Equal("Ações principais", group.GetAttribute("aria-label"));
    }

    [Fact]
    public void ButtonGroup_Should_Render_Vertical_Class()
    {
        using var ctx = CreateContext();

        var cut = ctx.RenderComponent<ButtonGroup>(parameters => parameters
            .Add(p => p.Orientation, ButtonGroupOrientation.Vertical)
            .Add(p => p.ChildContent, ButtonContent("Salvar")));

        Assert.Contains("ya-btn-group-vertical", cut.Find("div[role='group']").ClassList);
    }

    [Fact]
    public void ButtonGroup_Should_Inherit_Style_To_Button_When_Child_Uses_Default()
    {
        using var ctx = CreateContext();

        var cut = ctx.RenderComponent<ButtonGroup>(parameters => parameters
            .Add(p => p.Style, Themes.Danger)
            .Add(p => p.ChildContent, ButtonContent("Excluir")));

        Assert.Contains("ya-btn-danger", cut.Find("button.ya-btn").ClassList);
    }

    [Fact]
    public void ButtonGroup_Should_Inherit_Size_To_IconButton_When_Child_Uses_Default()
    {
        using var ctx = CreateContext();

        var cut = ctx.RenderComponent<ButtonGroup>(parameters => parameters
            .Add(p => p.Size, Sizes.Large)
            .Add(p => p.ChildContent, IconButtonContent()));

        Assert.Contains("ya-i-btn-lg", cut.Find("button.ya-i-btn").ClassList);
    }

    [Fact]
    public void ButtonGroup_Should_Disable_All_Supported_Children()
    {
        using var ctx = CreateContext();

        var cut = ctx.RenderComponent<ButtonGroup>(parameters => parameters
            .Add(p => p.Disabled, true)
            .Add(p => p.ChildContent, MixedContent()));

        Assert.All(cut.FindAll("button"), button => Assert.True(button.HasAttribute("disabled")));
        Assert.Contains("ya-btn-group-disabled", cut.Find("div[role='group']").ClassList);
    }

    [Fact]
    public void ButtonGroup_Should_Respect_Explicit_Child_Overrides()
    {
        using var ctx = CreateContext();

        var cut = ctx.RenderComponent<ButtonGroup>(parameters => parameters
            .Add(p => p.Style, Themes.Danger)
            .Add(p => p.Size, Sizes.Large)
            .Add(p => p.ChildContent, OverrideContent()));

        var buttons = cut.FindAll("button");

        Assert.Contains("ya-btn-primary", buttons[0].ClassList);
        Assert.DoesNotContain("ya-btn-danger", buttons[0].ClassList);
        Assert.Contains("ya-i-btn-sm", buttons[1].ClassList);
        Assert.DoesNotContain("ya-i-btn-lg", buttons[1].ClassList);
    }

    [Fact]
    public void ButtonGroup_Should_Render_Button_And_IconButton_Together()
    {
        using var ctx = CreateContext();

        var cut = ctx.RenderComponent<ButtonGroup>(parameters => parameters
            .Add(p => p.ChildContent, MixedContent()));

        Assert.Equal(2, cut.FindAll("button").Count);
        Assert.NotEmpty(cut.FindAll("span.ripple"));
    }

    private static TestContext CreateContext()
    {
        var ctx = new TestContext();

        ctx.Services.AddYasamenCommons();

        ctx.JSInterop
            .SetupModule("./_content/RoyalCode.Razor.Commons/ripple.js")
            .SetupVoid("ripple", _ => true);

        return ctx;
    }

    private static RenderFragment ButtonContent(string label) => builder =>
    {
        builder.OpenComponent<Button>(0);
        builder.AddAttribute(1, nameof(Button.Label), label);
        builder.CloseComponent();
    };

    private static RenderFragment IconButtonContent(
        Sizes size = Sizes.Default,
        Themes style = Themes.Default) => builder =>
    {
        builder.OpenComponent<IconButton>(0);
        builder.AddAttribute(1, nameof(IconButton.IconFragment), StubIconFragment);
        builder.AddAttribute(2, nameof(IconButton.Size), size);
        builder.AddAttribute(3, nameof(IconButton.Style), style);
        builder.CloseComponent();
    };

    private static RenderFragment MixedContent() => builder =>
    {
        builder.OpenComponent<Button>(0);
        builder.AddAttribute(1, nameof(Button.Label), "Salvar");
        builder.CloseComponent();

        builder.OpenComponent<IconButton>(2);
        builder.AddAttribute(3, nameof(IconButton.IconFragment), StubIconFragment);
        builder.CloseComponent();
    };

    private static RenderFragment OverrideContent() => builder =>
    {
        builder.OpenComponent<Button>(0);
        builder.AddAttribute(1, nameof(Button.Label), "Primário");
        builder.AddAttribute(2, nameof(Button.Style), Themes.Primary);
        builder.CloseComponent();

        builder.OpenComponent<IconButton>(3);
        builder.AddAttribute(4, nameof(IconButton.IconFragment), StubIconFragment);
        builder.AddAttribute(5, nameof(IconButton.Size), Sizes.Small);
        builder.CloseComponent();
    };

    private static readonly IconFragment StubIconFragment = (additionalClasses, additionalAttributes) => builder =>
    {
        builder.OpenElement(0, "span");

        if (!string.IsNullOrWhiteSpace(additionalClasses))
            builder.AddAttribute(1, "class", additionalClasses);

        if (additionalAttributes is not null)
        {
            var sequence = 2;

            foreach (var pair in additionalAttributes)
            {
                builder.AddAttribute(sequence++, pair.Key, pair.Value);
            }
        }

        builder.AddContent(100, "+");
        builder.CloseElement();
    };
}
