using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Razor.Styles;

/// <summary>
/// Utility to create CSS classes for components.
/// </summary>
public static partial class Css
{
    public static BgBuilder Background => BgBuilder.Default;
}

public readonly struct BgBuilder
{
    private readonly BgColor color;
    private readonly BgClip clip;

    public BgBuilder(BgColor color, BgClip clip)
    {
        this.color = color;
        this.clip = clip;
    }

    public static BgBuilder Default => new(BgColor.Default, BgClip.Default);

    public BgColorBuilder Color => new(this);

    public BgClipBuilder Clip => new(this);

    public BgBuilder With(BgColor color) => new(color, clip);

    public BgBuilder With(BgClip clip) => new(color, clip);

    public static implicit operator string(BgBuilder builder) => builder.ToString();

    public override string ToString()
        => color == BgColor.Default && clip == BgClip.Default
            ? string.Empty
            : string.Join(' ', AllCssClasses().Where(s => s != string.Empty));

    public override bool Equals([NotNullWhen(true)] object? obj)
        {
        return obj is BgBuilder builder && this == builder;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(color, clip);
    }

    public static bool operator ==(BgBuilder left, BgBuilder right)
    {
        return left.color == right.color && left.clip == right.clip;
    }

    public static bool operator !=(BgBuilder left, BgBuilder right)
    {
        return !(left == right);
    }

    private IEnumerable<string> AllCssClasses()
    {
        yield return color;
        yield return clip.ToCssClass();
    }
}

public readonly struct BgColorBuilder
{
    private readonly BgBuilder builder;

    public BgColorBuilder(BgBuilder builder)
    {
        this.builder = builder;
    }

    public BgBuilder Default() => builder.With(BgColor.Default);

    public BgBuilder Transparent() => builder.With(BgColor.Transparent);

    public BgBuilder White() => builder.With(BgColor.White);

    public BgBuilder Black() => builder.With(BgColor.Black);

    public BgGradientBuilder Primary() => new BgGradientBuilder(builder, Themes.Primary);

    public BgGradientBuilder Secondary() => new BgGradientBuilder(builder, Themes.Secondary);

    public BgGradientBuilder Tertiary() => new BgGradientBuilder(builder, Themes.Tertiary);

    public BgGradientBuilder Info() => new(builder, Themes.Info);

    public BgGradientBuilder Highlight() => new(builder, Themes.Highlight);

    public BgGradientBuilder Success() => new(builder, Themes.Success);

    public BgGradientBuilder Warning() => new(builder, Themes.Warning);

    public BgGradientBuilder Alert() => new(builder, Themes.Alert);

    public BgGradientBuilder Danger() => new(builder, Themes.Danger);

    public BgGradientBuilder Light() => new(builder, Themes.Light);

    public BgGradientBuilder Dark() => new(builder, Themes.Dark);
}

public readonly struct BgGradientBuilder
{
    private readonly BgBuilder builder;
    private readonly Themes theme;

    public BgGradientBuilder(BgBuilder builder, Themes theme)
    {
        this.builder = builder;
        this.theme = theme;
    }

    public static implicit operator BgBuilder(BgGradientBuilder builder) => builder.Default();

    public BgBuilder Default() => builder.With(new BgColor(theme, Gradients.Default));

    public BgBuilder White() => builder.With(new BgColor(theme, Gradients.White));

    public BgBuilder Lightest() => builder.With(new BgColor(theme, Gradients.Lightest));

    public BgBuilder Lighter() => builder.With(new BgColor(theme, Gradients.Lighter));

    public BgBuilder Light() => builder.With(new BgColor(theme, Gradients.Light));

    public BgBuilder Normal() => builder.With(new BgColor(theme, Gradients.Normal));

    public BgBuilder Dark() => builder.With(new BgColor(theme, Gradients.Dark));

    public BgBuilder Darker() => builder.With(new BgColor(theme, Gradients.Darker));

    public BgBuilder Darkest() => builder.With(new BgColor(theme, Gradients.Darkest));

    public BgBuilder Black() => builder.With(new BgColor(theme, Gradients.Black));
}

public readonly struct BgClipBuilder
{
    private readonly BgBuilder builder;

    public BgClipBuilder(BgBuilder builder)
    {
        this.builder = builder;
    }

    public BgBuilder Default() => builder.With(BgClip.Default);

    public BgBuilder Border() => builder.With(BgClip.Border);

    public BgBuilder Padding() => builder.With(BgClip.Padding);

    public BgBuilder Content() => builder.With(BgClip.Content);

    public BgBuilder Text() => builder.With(BgClip.Text);
}