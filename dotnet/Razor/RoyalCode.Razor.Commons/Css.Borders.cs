using RoyalCode.Razor.Commons.Styles;
using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Yasamen.Commons;

#pragma warning disable S2325 // make methods and properties static (CssBorders)

public partial class Css
{
    public static DefaultBorders Border => new();
}

public readonly struct DefaultBorders
{
    public BorderBuilder None() => BorderBuilder.None();
    public BorderBuilder Box() => BorderBuilder.Box();
    public BorderBuilder BoxRounded() => BorderBuilder.BoxRounded();
    public BorderBuilder BoxWithShadow() => BorderBuilder.BoxWithShadow();
    public BorderBuilder BoxRoundedWithShadow() => BorderBuilder.BoxRoundedWithShadow();
    public BorderBuilder Header() => BorderBuilder.Header();
    public BorderBuilder HeaderWithShadow() => BorderBuilder.HeaderWithShadow();
    public BorderBuilder Footer() => BorderBuilder.Footer();
    public BorderBuilder FooterWithShadow() => BorderBuilder.FooterWithShadow();
}

public readonly struct BorderClasses
{
    private readonly BorderPositions positions;
    private readonly Themes theme;
    private readonly BorderWidth width;
    private readonly BorderStyles style;
    private readonly BorderRound round;
    private readonly BorderRadius radius;
    private readonly Shadows shadow;

    public BorderClasses(
        BorderPositions positions,
        Themes theme,
        BorderWidth width,
        BorderStyles style,
        BorderRound round,
        BorderRadius radius,
        Shadows shadow)
    {
        this.positions = positions;
        this.theme = theme;
        this.width = width;
        this.style = style;
        this.round = round;
        this.radius = radius;
        this.shadow = shadow;
    }

    public override string ToString()
    {
        return positions == BorderPositions.None
            ? string.Empty
            : string.Join(' ', AllCssClasses().Where(s => s != string.Empty));
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is BorderClasses border && this == border;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(positions, theme, width, style, round, radius, shadow);
    }

    public static bool operator ==(BorderClasses left, BorderClasses right)
    {
        return left.positions == right.positions
            && left.theme == right.theme
            && left.width == right.width
            && left.style == right.style
            && left.round == right.round
            && left.radius == right.radius
            && left.shadow == right.shadow;
    }

    public static bool operator !=(BorderClasses left, BorderClasses right)
    {
        return !(left == right);
    }

    public static implicit operator string(BorderClasses builder) => builder.ToString();

    private IEnumerable<string> AllCssClasses()
    {
        yield return positions.ToBorderCssClasses();
        yield return theme.ToBorderCssClasses();
        yield return width.ToBorderCssClasses();
        yield return style.ToBorderCssClasses();
        yield return round.ToBorderCssClasses();
        yield return radius.ToBorderCssClasses();
        yield return shadow.ToCssClass();
    }
}

public readonly struct BorderBuilder
{
    private readonly BorderPositions positions;
    private readonly Themes theme;
    private readonly BorderWidth width;
    private readonly BorderStyles style;
    private readonly BorderRound round;
    private readonly BorderRadius radius;
    private readonly Shadows shadow;

    public BorderBuilder() { }

    public BorderBuilder(
        BorderPositions positions,
        Themes theme,
        BorderWidth width,
        BorderStyles style,
        BorderRound round,
        BorderRadius radius,
        Shadows shadow)
    {
        this.positions = positions;
        this.theme = theme;
        this.width = width;
        this.style = style;
        this.round = round;
        this.radius = radius;
        this.shadow = shadow;
    }

    public static BorderBuilder None()
    {
        return new BorderBuilder(
            BorderPositions.None,
            Themes.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Default
        );
    }

    public static BorderBuilder Box()
    {
        return new BorderBuilder(
            BorderPositions.Default,
            Themes.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Default
        );
    }

    public static BorderBuilder BoxRounded()
    {
        return new BorderBuilder(
            BorderPositions.Default,
            Themes.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.Default,
            BorderRadius.Default,
            Shadows.Default
        );
    }

    public static BorderBuilder BoxWithShadow()
    {
        return new BorderBuilder(
            BorderPositions.Default,
            Themes.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Three
        );
    }

    public static BorderBuilder BoxRoundedWithShadow()
    {
        return new BorderBuilder(
            BorderPositions.Default,
            Themes.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.Default,
            BorderRadius.Default,
            Shadows.Three
        );
    }

    public static BorderBuilder Header()
    {
        return new BorderBuilder(
            BorderPositions.Bottom,
            Themes.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Default
        );
    }

    public static BorderBuilder HeaderWithShadow()
    {
        return new BorderBuilder(
            BorderPositions.Bottom,
            Themes.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Three
        );
    }

    public static BorderBuilder Footer()
    {
        return new BorderBuilder(
            BorderPositions.Top,
            Themes.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Default
        );
    }

    public static BorderBuilder FooterWithShadow()
    {
        return new BorderBuilder(
            BorderPositions.Top,
            Themes.Default,
            BorderWidth.One,
            BorderStyles.Default,
            BorderRound.None,
            BorderRadius.Default,
            Shadows.Three
        );
    }

    public BorderPositionsBuilder Position => new BorderPositionsBuilder(this);

    public BorderThemesBuilder Theme => new BorderThemesBuilder(this);

    public BorderWidthBuilder Width => new BorderWidthBuilder(this);

    public BorderStylesBuilder Style => new BorderStylesBuilder(this);

    public BorderRoundBuilder Round => new BorderRoundBuilder(this);

    public BorderRadiusBuilder Radius => new BorderRadiusBuilder(this);

    public BorderShadowsBuilder Shadow => new BorderShadowsBuilder(this);

    public BorderBuilder With(BorderPositions positions)
    {
        return new BorderBuilder(
            positions,
            theme,
            width,
            style,
            round,
            radius,
            shadow
        );
    }

    public BorderBuilder With(Themes theme)
    {
        return new BorderBuilder(
            positions,
            theme,
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
            positions,
            theme,
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
            positions,
            theme,
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
            positions,
            theme,
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
            positions,
            theme,
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
            positions,
            theme,
            width,
            style,
            round,
            radius,
            shadow
        );
    }

    public BorderClasses Build() => new(positions, theme, width, style, round, radius, shadow);

    public override string ToString() => Build();

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is BorderBuilder builder && this == builder;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(positions, theme, width, style, round, radius, shadow);
    }

    public static bool operator ==(BorderBuilder left, BorderBuilder right)
    {
        return left.positions == right.positions
            && left.theme == right.theme
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

    public static implicit operator string(BorderBuilder builder) => builder.ToString();

    public static implicit operator BorderClasses(BorderBuilder builder) => builder.Build();
}

public readonly struct BorderPositionsBuilder
{
    private readonly BorderBuilder builder;

    public BorderPositionsBuilder(BorderBuilder builder)
    {
        this.builder = builder;
    }

    public BorderBuilder Top()
    {
        return builder.With(BorderPositions.Top);
    }

    public BorderBuilder End()
    {
        return builder.With(BorderPositions.End);
    }

    public BorderBuilder Bottom()
    {
        return builder.With(BorderPositions.Bottom);
    }

    public BorderBuilder Start()
    {
        return builder.With(BorderPositions.Start);
    }

    public BorderBuilder TopEnd()
    {
        return builder.With(BorderPositions.TopEnd);
    }

    public BorderBuilder TopBottom()
    {
        return builder.With(BorderPositions.TopBottom);
    }

    public BorderBuilder TopStart()
    {
        return builder.With(BorderPositions.TopStart);
    }

    public BorderBuilder EndBottom()
    {
        return builder.With(BorderPositions.EndBottom);
    }

    public BorderBuilder EndStart()
    {
        return builder.With(BorderPositions.EndStart);
    }

    public BorderBuilder BottomStart()
    {
        return builder.With(BorderPositions.BottomStart);
    }

    public BorderBuilder NotAtTop()
    {
        return builder.With(BorderPositions.NotAtTop);
    }

    public BorderBuilder NotAtEnd()
    {
        return builder.With(BorderPositions.NotAtEnd);
    }

    public BorderBuilder NotAtBottom()
    {
        return builder.With(BorderPositions.NotAtBottom);
    }

    public BorderBuilder NotAtStart()
    {
        return builder.With(BorderPositions.NotAtStart);
    }

    public BorderBuilder Default()
    {
        return builder.With(BorderPositions.Default);
    }

    public BorderBuilder None()
    {
        return builder.With(BorderPositions.None);
    }
}

public readonly struct BorderThemesBuilder
{
    private readonly BorderBuilder builder;

    public BorderThemesBuilder(BorderBuilder builder)
    {
        this.builder = builder;
    }

    public BorderBuilder Primary()
    {
        return builder.With(Themes.Primary);
    }

    public BorderBuilder Secondary()
    {
        return builder.With(Themes.Secondary);
    }

    public BorderBuilder Tertiary()
    {
        return builder.With(Themes.Tertiary);
    }

    public BorderBuilder Info()
    {
        return builder.With(Themes.Info);
    }

    public BorderBuilder Highlight()
    {
        return builder.With(Themes.Highlight);
    }

    public BorderBuilder Success()
    {
        return builder.With(Themes.Success);
    }

    public BorderBuilder Warning()
    {
        return builder.With(Themes.Warning);
    }

    public BorderBuilder Alert()
    {
        return builder.With(Themes.Alert);
    }

    public BorderBuilder Danger()
    {
        return builder.With(Themes.Danger);
    }

    public BorderBuilder Light()
    {
        return builder.With(Themes.Light);
    }

    public BorderBuilder Dark()
    {
        return builder.With(Themes.Dark);
    }

    public BorderBuilder Default()
    {
        return builder.With(Themes.Default);
    }
}

public readonly struct BorderWidthBuilder
{
    private readonly BorderBuilder builder;

    public BorderWidthBuilder(BorderBuilder builder)
    {
        this.builder = builder;
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
}