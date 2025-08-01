using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Razor.Styles;

public partial class Css
{
    public static OutlineBuilder Outline => OutlineBuilder.Default;
}

public readonly struct OutlineBuilder
{
    private readonly OutlineWidth width;
    private readonly OutlineStyle style;
    private readonly OutlineOffset offset;
    private readonly OutlineColor color;

    public OutlineBuilder(OutlineWidth width, OutlineStyle style, OutlineOffset offset, OutlineColor color)
    {
        this.width = width;
        this.style = style;
        this.offset = offset;
        this.color = color;
    }

    public static OutlineBuilder Default => new(OutlineWidth.Default, OutlineStyle.Default, OutlineOffset.Default, OutlineColor.Default);

    public OutlineWidthBuilder Width => new(this);

    public OutlineStyleBuilder Style => new(this);

    public OutlineOffsetBuilder Offset => new(this);

    public OutlineColorBuilder Color => new(this);

    public OutlineBuilder With(OutlineWidth width) => new (width, style, offset, color);

    public OutlineBuilder With(OutlineStyle style) => new (width, style, offset, color);

    public OutlineBuilder With(OutlineOffset offset) => new (width, style, offset, color);

    public OutlineBuilder With(OutlineColor color) => new (width, style, offset, color);

    public static implicit operator string(OutlineBuilder builder) => builder.ToString();

    public override string ToString()
        => width == OutlineWidth.Default
            ? string.Empty
            : string.Join(' ', AllCssClasses().Where(s => s != string.Empty));

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is OutlineBuilder builder && this == builder;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(width, style, offset, color);
    }

    public static bool operator ==(OutlineBuilder left, OutlineBuilder right)
    {
        return left.width == right.width &&
            left.style == right.style &&
            left.offset == right.offset &&
            left.color == right.color;
    }

    public static bool operator !=(OutlineBuilder left, OutlineBuilder right) => !(left == right);

    private IEnumerable<string> AllCssClasses()
    {
        yield return width.ToCssClass();
        yield return style.ToCssClass();
        yield return offset.ToCssClass();
        yield return color;
    }
}

public readonly struct OutlineWidthBuilder
{
    private readonly OutlineBuilder builder;
    
    public OutlineWidthBuilder(OutlineBuilder builder)
    {
        this.builder = builder;
    }

    public OutlineBuilder Default() => builder.With(OutlineWidth.Default);

    public OutlineBuilder One() => builder.With(OutlineWidth.One);

    public OutlineBuilder Two() => builder.With(OutlineWidth.Two);

    public OutlineBuilder Three() => builder.With(OutlineWidth.Three);

    public OutlineBuilder Four() => builder.With(OutlineWidth.Four);

    public OutlineBuilder Five() => builder.With(OutlineWidth.Five);

    public OutlineBuilder Six() => builder.With(OutlineWidth.Six);

    public OutlineBuilder Seven() => builder.With(OutlineWidth.Seven);

    public OutlineBuilder Eight() => builder.With(OutlineWidth.Eight);

    public OutlineBuilder Nine() => builder.With(OutlineWidth.Nine);

    public OutlineBuilder With(OutlineWidth width) => builder.With(width);
}

public readonly struct OutlineStyleBuilder
{
    private readonly OutlineBuilder builder;
    
    public OutlineStyleBuilder(OutlineBuilder builder)
    {
        this.builder = builder;
    }

    public OutlineBuilder Default() => builder.With(OutlineStyle.Default);

    public OutlineBuilder Solid() => builder.With(OutlineStyle.Solid);

    public OutlineBuilder Dashed() => builder.With(OutlineStyle.Dashed);

    public OutlineBuilder Dotted() => builder.With(OutlineStyle.Dotted);

    public OutlineBuilder Double() => builder.With(OutlineStyle.Double);

    public OutlineBuilder None() => builder.With(OutlineStyle.None);

    public OutlineBuilder Hidden() => builder.With(OutlineStyle.Hidden);

    public OutlineBuilder With(OutlineStyle style) => builder.With(style);
}

public readonly struct OutlineOffsetBuilder
{
    private readonly OutlineBuilder builder;
    
    public OutlineOffsetBuilder(OutlineBuilder builder)
    {
        this.builder = builder;
    }

    public OutlineBuilder Default() => builder.With(OutlineOffset.Default);

    public OutlineBuilder One() => builder.With(OutlineOffset.One);

    public OutlineBuilder Two() => builder.With(OutlineOffset.Two);

    public OutlineBuilder Three() => builder.With(OutlineOffset.Three);

    public OutlineBuilder Four() => builder.With(OutlineOffset.Four);

    public OutlineBuilder Five() => builder.With(OutlineOffset.Five);

    public OutlineBuilder Six() => builder.With(OutlineOffset.Six);

    public OutlineBuilder Seven() => builder.With(OutlineOffset.Seven);

    public OutlineBuilder Eight() => builder.With(OutlineOffset.Eight);

    public OutlineBuilder Nine() => builder.With(OutlineOffset.Nine);

    public OutlineBuilder With(OutlineOffset offset) => builder.With(offset);
}

public readonly struct OutlineColorBuilder
{
    private readonly OutlineBuilder builder;
    
    public OutlineColorBuilder(OutlineBuilder builder)
    {
        this.builder = builder;
    }

    public OutlineBuilder Default() => builder.With(OutlineColor.Default);

    public OutlineBuilder Transparent() => builder.With(OutlineColor.Transparent);

    public OutlineBuilder White() => builder.With(OutlineColor.White);

    public OutlineBuilder Black() => builder.With(OutlineColor.Black);

    public OutlineGradientBuilder Primary() => new(builder, Themes.Primary);

    public OutlineGradientBuilder Secondary() => new(builder, Themes.Secondary);

    public OutlineGradientBuilder Tertiary() => new(builder, Themes.Tertiary);

    public OutlineGradientBuilder Info() => new(builder, Themes.Info);

    public OutlineGradientBuilder Highlight() => new(builder, Themes.Highlight);

    public OutlineGradientBuilder Success() => new(builder, Themes.Success);

    public OutlineGradientBuilder Warning() => new(builder, Themes.Warning);

    public OutlineGradientBuilder Alert() => new(builder, Themes.Alert);

    public OutlineGradientBuilder Danger() => new(builder, Themes.Danger);

    public OutlineGradientBuilder Light() => new(builder, Themes.Light);

    public OutlineGradientBuilder Dark() => new(builder, Themes.Dark);
}

public readonly struct OutlineGradientBuilder
{
    private readonly OutlineBuilder builder;
    private readonly Themes theme;
    
    public OutlineGradientBuilder(OutlineBuilder builder, Themes theme)
    {
        this.builder = builder;
        this.theme = theme;
    }

    public static implicit operator OutlineBuilder(OutlineGradientBuilder builder) => builder.Default();

    public OutlineBuilder Default() => builder.With(new OutlineColor(theme, Gradients.Default));

    public OutlineBuilder White() => builder.With(new OutlineColor(theme, Gradients.White));

    public OutlineBuilder Lightest() => builder.With(new OutlineColor(theme, Gradients.Lightest));

    public OutlineBuilder Lighter() => builder.With(new OutlineColor(theme, Gradients.Lighter));

    public OutlineBuilder Light() => builder.With(new OutlineColor(theme, Gradients.Light));

    public OutlineBuilder Normal() => builder.With(new OutlineColor(theme, Gradients.Normal));

    public OutlineBuilder Dark() => builder.With(new OutlineColor(theme, Gradients.Dark));

    public OutlineBuilder Darker() => builder.With(new OutlineColor(theme, Gradients.Darker));

    public OutlineBuilder Darkest() => builder.With(new OutlineColor(theme, Gradients.Darkest));

    public OutlineBuilder Black() => builder.With(new OutlineColor(theme, Gradients.Black));
}