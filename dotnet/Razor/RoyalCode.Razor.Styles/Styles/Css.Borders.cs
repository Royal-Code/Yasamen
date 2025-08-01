using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Razor.Styles;

#pragma warning disable S2325 // make methods and properties static (CssBorders)

/// <summary>
/// Utility to create CSS classes for components.
/// </summary>
public partial class Css
{
    public static DefaultBorders Border => new();
}

public readonly struct DefaultBorders
{
    public BorderBuilder Default() => BorderBuilder.Default;
    public BorderBuilder None() => BorderBuilder.None;
    public BorderBuilder Box() => BorderBuilder.Box;
    public BorderBuilder BoxRounded() => BorderBuilder.BoxRounded;
    public BorderBuilder BoxWithShadow() => BorderBuilder.BoxWithShadow;
    public BorderBuilder BoxRoundedWithShadow() => BorderBuilder.BoxRoundedWithShadow;
    public BorderBuilder Header() => BorderBuilder.Header;
    public BorderBuilder HeaderWithShadow() => BorderBuilder.HeaderWithShadow;
    public BorderBuilder Footer() => BorderBuilder.Footer;
    public BorderBuilder FooterWithShadow() => BorderBuilder.FooterWithShadow;
}

public readonly struct BorderBuilder
{
    private readonly BorderSide side;
    private readonly BorderColor color;
    private readonly BorderWidth width;
    private readonly BorderStyles style;
    private readonly BorderRound round;
    private readonly BorderRadius radius;
    private readonly Shadows shadow;

    public BorderBuilder() { }

    public BorderBuilder(
        BorderSide side,
        BorderColor color,
        BorderWidth width,
        BorderStyles style,
        BorderRound round,
        BorderRadius radius,
        Shadows shadow)
    {
        this.side = side;
        this.color = color;
        this.width = width;
        this.style = style;
        this.round = round;
        this.radius = radius;
        this.shadow = shadow;
    }

    public static BorderBuilder Default { get; } = new BorderBuilder(
        BorderSide.Default,
        BorderColor.Default,
        BorderWidth.Default,
        BorderStyles.Default,
        BorderRound.Default,
        BorderRadius.Default,
        Shadows.Default);

    public static BorderBuilder None { get; } = new BorderBuilder(
        BorderSide.None,
        BorderColor.Default,
        BorderWidth.Default,
        BorderStyles.Default,
        BorderRound.Default,
        BorderRadius.Default,
        Shadows.Default);

    public static BorderBuilder Box { get; } = new BorderBuilder(
        BorderSide.All,
        BorderColor.Default,
        BorderWidth.One,
        BorderStyles.Default,
        BorderRound.None,
        BorderRadius.Default,
        Shadows.Default);

    public static BorderBuilder BoxRounded { get; } = new BorderBuilder(
        BorderSide.All,
        BorderColor.Default,
        BorderWidth.One,
        BorderStyles.Default,
        BorderRound.All,
        BorderRadius.Default,
        Shadows.Default
    );

    public static BorderBuilder BoxWithShadow { get; } = new BorderBuilder(
            BorderSide.All,
            BorderColor.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Three
        );

    public static BorderBuilder BoxRoundedWithShadow { get; } = new BorderBuilder(
            BorderSide.All,
            BorderColor.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.All,
            BorderRadius.Default,
            Shadows.Three
        );

    public static BorderBuilder Header { get; } = new BorderBuilder(
            BorderSide.Bottom,
            BorderColor.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Default
        );

    public static BorderBuilder HeaderWithShadow { get; } = new BorderBuilder(
            BorderSide.Bottom,
            BorderColor.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Three
        );

    public static BorderBuilder Footer { get; } = new BorderBuilder(
            BorderSide.Top,
            BorderColor.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Default
        );

    public static BorderBuilder FooterWithShadow { get; } = new BorderBuilder(
            BorderSide.Top,
            BorderColor.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Three
        );

    public BorderSideBuilder Sides => new(this);

    public BorderThemeBuilder Color => new(this);

    public BorderWidthBuilder Width => new(this);

    public BorderStylesBuilder Style => new(this);

    public BorderRoundBuilder Round => new(this);

    public BorderRadiusBuilder Radius => new(this);

    public BorderShadowsBuilder Shadow => new(this);

    public BorderBuilder With(BorderSide side)
    {
        return new BorderBuilder(
            side,
            color,
            width,
            style,
            round,
            radius,
            shadow
        );
    }

    public BorderBuilder With(BorderColor color)
    {
        return new BorderBuilder(
            side,
            color,
            width,
            style,
            round,
            radius,
            shadow
        );
    }

    public BorderBuilder With(BorderWidth width)
    {
        return new BorderBuilder(
            side,
            color,
            width,
            style,
            round,
            radius,
            shadow
        );
    }

    public BorderBuilder With(BorderStyles style)
    {
        return new BorderBuilder(
            side,
            color,
            width,
            style,
            round,
            radius,
            shadow
        );
    }

    public BorderBuilder With(BorderRound round)
    {
        return new BorderBuilder(
            side,
            color,
            width,
            style,
            round,
            radius,
            shadow
        );
    }

    public BorderBuilder With(BorderRadius radius)
    {
        return new BorderBuilder(
            side,
            color,
            width,
            style,
            round,
            radius,
            shadow
        );
    }

    public BorderBuilder With(Shadows shadow)
    {
        return new BorderBuilder(
            side,
            color,
            width,
            style,
            round,
            radius,
            shadow
        );
    }

    public static implicit operator string(BorderBuilder builder) => builder.ToString();

    public override string ToString()
        => side == BorderSide.Default
            ? string.Empty
            : string.Join(' ', AllCssClasses().Where(s => s != string.Empty));

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is BorderBuilder builder && this == builder;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(side, color, width, style, round, radius, shadow);
    }

    public static bool operator ==(BorderBuilder left, BorderBuilder right)
    {
        return left.side == right.side
            && left.color == right.color
            && left.width == right.width
            && left.style == right.style
            && left.round == right.round
            && left.radius == right.radius
            && left.shadow == right.shadow;
    }

    public static bool operator !=(BorderBuilder left, BorderBuilder right)
    {
        return !(left == right);
    }

    private IEnumerable<string> AllCssClasses()
    {
        yield return side.ToCssClass();
        yield return color;
        yield return width.ToCssClass();
        yield return style.ToCssClass();
        yield return round.ToCssClass();
        yield return radius.ToCssClass();
        yield return shadow.ToCssClass();
    }
}

public readonly struct BorderSideBuilder
{
    private readonly BorderBuilder builder;

    public BorderSideBuilder(BorderBuilder builder)
    {
        this.builder = builder;
    }

    public BorderBuilder Top()
    {
        return builder.With(BorderSide.Top);
    }

    public BorderBuilder End()
    {
        return builder.With(BorderSide.End);
    }

    public BorderBuilder Bottom()
    {
        return builder.With(BorderSide.Bottom);
    }

    public BorderBuilder Start()
    {
        return builder.With(BorderSide.Start);
    }

    public BorderBuilder TopEnd()
    {
        return builder.With(BorderSide.TopEnd);
    }

    public BorderBuilder TopBottom()
    {
        return builder.With(BorderSide.TopBottom);
    }

    public BorderBuilder TopStart()
    {
        return builder.With(BorderSide.TopStart);
    }

    public BorderBuilder EndBottom()
    {
        return builder.With(BorderSide.EndBottom);
    }

    public BorderBuilder EndStart()
    {
        return builder.With(BorderSide.EndStart);
    }

    public BorderBuilder BottomStart()
    {
        return builder.With(BorderSide.BottomStart);
    }

    public BorderBuilder NotAtTop()
    {
        return builder.With(BorderSide.NotAtTop);
    }

    public BorderBuilder NotAtEnd()
    {
        return builder.With(BorderSide.NotAtEnd);
    }

    public BorderBuilder NotAtBottom()
    {
        return builder.With(BorderSide.NotAtBottom);
    }

    public BorderBuilder NotAtStart()
    {
        return builder.With(BorderSide.NotAtStart);
    }

    public BorderBuilder All()
    {
        return builder.With(BorderSide.All);
    }

    public BorderBuilder Default()
    {
        return builder.With(BorderSide.Default);
    }

    public BorderBuilder None()
    {
        return builder.With(BorderSide.None);
    }
}

public readonly struct BorderThemeBuilder
{
    private readonly BorderBuilder builder;

    public BorderThemeBuilder(BorderBuilder builder)
    {
        this.builder = builder;
    }

    public BorderColorBuilder Primary()
    {
        return new BorderColorBuilder(builder, Themes.Primary);
    }

    public BorderColorBuilder Secondary()
    {
        return new BorderColorBuilder(builder, Themes.Secondary);
    }

    public BorderColorBuilder Tertiary()
    {
        return new BorderColorBuilder(builder, Themes.Tertiary);
    }

    public BorderColorBuilder Info()
    {
        return new BorderColorBuilder(builder, Themes.Info);
    }

    public BorderColorBuilder Highlight()
    {
        return new BorderColorBuilder(builder, Themes.Highlight);
    }

    public BorderColorBuilder Success()
    {
        return new BorderColorBuilder(builder, Themes.Success);
    }

    public BorderColorBuilder Warning()
    {
        return new BorderColorBuilder(builder, Themes.Warning);
    }

    public BorderColorBuilder Alert()
    {
        return new BorderColorBuilder(builder, Themes.Alert);
    }

    public BorderColorBuilder Danger()
    {
        return new BorderColorBuilder(builder, Themes.Danger);
    }

    public BorderColorBuilder Light()
    {
        return new BorderColorBuilder(builder, Themes.Light);
    }

    public BorderColorBuilder Dark()
    {
        return new BorderColorBuilder(builder, Themes.Dark);
    }
}

public readonly struct BorderColorBuilder
{
    private readonly BorderBuilder builder;
    private readonly Themes theme;

    public BorderColorBuilder(BorderBuilder builder, Themes theme)
    {
        this.builder = builder;
        this.theme = theme;
    }

    public static implicit operator BorderBuilder(BorderColorBuilder builder)
    {
        return builder.builder.With(new BorderColor(builder.theme, Gradients.Default));
    }

    public BorderBuilder With(Gradients gradients)
    {
        return builder.With(new BorderColor(theme, gradients));
    }

    public BorderBuilder White()
    {
        return builder.With(new BorderColor(theme, Gradients.White));
    }

    public BorderBuilder Lightest()
    {
        return builder.With(new BorderColor(theme, Gradients.Lightest));
    }

    public BorderBuilder Lighter()
    {
        return builder.With(new BorderColor(theme, Gradients.Lighter));
    }

    public BorderBuilder Light()
    {
        return builder.With(new BorderColor(theme, Gradients.Light));
    }

    public BorderBuilder Normal()
    {
        return builder.With(new BorderColor(theme, Gradients.Normal));
    }

    public BorderBuilder Dark()
    {
        return builder.With(new BorderColor(theme, Gradients.Dark));
    }

    public BorderBuilder Darker()
    {
        return builder.With(new BorderColor(theme, Gradients.Darker));
    }

    public BorderBuilder Darkest()
    {
        return builder.With(new BorderColor(theme, Gradients.Darkest));
    }

    public BorderBuilder Black()
    {
        return builder.With(new BorderColor(theme, Gradients.Black));
    }
}

public readonly struct BorderWidthBuilder
{
    private readonly BorderBuilder builder;

    public BorderWidthBuilder(BorderBuilder builder)
    {
        this.builder = builder;
    }

    public BorderBuilder Default()
    {
        return builder.With(BorderWidth.Default);
    }

    public BorderBuilder One()
    {
        return builder.With(BorderWidth.One);
    }

    public BorderBuilder Two()
    {
        return builder.With(BorderWidth.Two);
    }

    public BorderBuilder Three()
    {
        return builder.With(BorderWidth.Three);
    }

    public BorderBuilder Four()
    {
        return builder.With(BorderWidth.Four);
    }

    public BorderBuilder Five()
    {
        return builder.With(BorderWidth.Five);
    }

    public BorderBuilder Six()
    {
        return builder.With(BorderWidth.Six);
    }

    public BorderBuilder Seven()
    {
        return builder.With(BorderWidth.Seven);
    }

    public BorderBuilder Eight()
    {
        return builder.With(BorderWidth.Eight);
    }

    public BorderBuilder Nine()
    {
        return builder.With(BorderWidth.Nine);
    }
}

public readonly struct BorderStylesBuilder
{
    private readonly BorderBuilder builder;

    public BorderStylesBuilder(BorderBuilder builder)
    {
        this.builder = builder;
    }

    public BorderBuilder Solid()
    {
        return builder.With(BorderStyles.Solid);
    }

    public BorderBuilder Dashed()
    {
        return builder.With(BorderStyles.Dashed);
    }

    public BorderBuilder Dotted()
    {
        return builder.With(BorderStyles.Dotted);
    }

    public BorderBuilder Double()
    {
        return builder.With(BorderStyles.Double);
    }

    public BorderBuilder Groove()
    {
        return builder.With(BorderStyles.Groove);
    }

    public BorderBuilder Ridge()
    {
        return builder.With(BorderStyles.Ridge);
    }

    public BorderBuilder Inset()
    {
        return builder.With(BorderStyles.Inset);
    }

    public BorderBuilder Outset()
    {
        return builder.With(BorderStyles.Outset);
    }

    public BorderBuilder Hidden()
    {
        return builder.With(BorderStyles.Hidden);
    }

    public BorderBuilder None()
    {
        return builder.With(BorderStyles.None);
    }

    public BorderBuilder Default()
    {
        return builder.With(BorderStyles.Default);
    }
}

public readonly struct BorderRoundBuilder
{
    private readonly BorderBuilder builder;

    public BorderRoundBuilder(BorderBuilder builder)
    {
        this.builder = builder;
    }

    public BorderBuilder None()
    {
        return builder.With(BorderRound.None);
    }

    public BorderBuilder All()
    {
        return builder.With(BorderRound.All);
    }

    public BorderBuilder Default()
    {
        return builder.With(BorderRound.Default);
    }

    public BorderBuilder Top()
    {
        return builder.With(BorderRound.Top);
    }

    public BorderBuilder End()
    {
        return builder.With(BorderRound.End);
    }

    public BorderBuilder Bottom()
    {
        return builder.With(BorderRound.Bottom);
    }

    public BorderBuilder Start()
    {
        return builder.With(BorderRound.Start);
    }

    public BorderBuilder Circle()
    {
        return builder.With(BorderRound.Circle);
    }

    public BorderBuilder Pill()
    {
        return builder.With(BorderRound.Pill);
    }

    public BorderBuilder Ellipse()
    {
        return builder.With(BorderRound.Ellipse);
    }

    public BorderBuilder TopStart()
    {
        return builder.With(BorderRound.TopStart);
    }

    public BorderBuilder TopEnd()
    {
        return builder.With(BorderRound.TopEnd);
    }

    public BorderBuilder BottomStart()
    {
        return builder.With(BorderRound.BottomStart);
    }

    public BorderBuilder BottomEnd()
    {
        return builder.With(BorderRound.BottomEnd);
    }
}

public readonly struct BorderRadiusBuilder
{
    private readonly BorderBuilder builder;
    
    public BorderRadiusBuilder(BorderBuilder builder)
    {
        this.builder = builder;
    }

    public BorderBuilder Default()
    {
        return builder.With(BorderRadius.Default);
    }

    public BorderBuilder One()
    {
        return builder.With(BorderRadius.One);
    }

    public BorderBuilder Two()
    {
        return builder.With(BorderRadius.Two);
    }

    public BorderBuilder Three()
    {
        return builder.With(BorderRadius.Three);
    }

    public BorderBuilder Four()
    {
        return builder.With(BorderRadius.Four);
    }

    public BorderBuilder Five()
    {
        return builder.With(BorderRadius.Five);
    }

    public BorderBuilder Six()
    {
        return builder.With(BorderRadius.Six);
    }

    public BorderBuilder Seven()
    {
        return builder.With(BorderRadius.Seven);
    }

    public BorderBuilder Eight()
    {
        return builder.With(BorderRadius.Eight);
    }

    public BorderBuilder Nine()
    {
        return builder.With(BorderRadius.Nine);
    }
}

public readonly struct BorderShadowsBuilder
{
    private readonly BorderBuilder builder;

    public BorderShadowsBuilder(BorderBuilder builder)
    {
        this.builder = builder;
    }

    public BorderBuilder None()
    {
        return builder.With(Shadows.None);
    }

    public BorderBuilder One()
    {
        return builder.With(Shadows.One);
    }

    public BorderBuilder Two()
    {
        return builder.With(Shadows.Two);
    }

    public BorderBuilder Three()
    {
        return builder.With(Shadows.Three);
    }

    public BorderBuilder Four()
    {
        return builder.With(Shadows.Four);
    }

    public BorderBuilder Five()
    {
        return builder.With(Shadows.Five);
    }

    public BorderBuilder Six()
    {
        return builder.With(Shadows.Six);
    }

    public BorderBuilder Seven()
    {
        return builder.With(Shadows.Seven);
    }

    public BorderBuilder Eight()
    {
        return builder.With(Shadows.Eight);
    }

    public BorderBuilder Nine()
    {
        return builder.With(Shadows.Nine);
    }

    public BorderBuilder Default()
    {
        return builder.With(Shadows.Default);
    }
}