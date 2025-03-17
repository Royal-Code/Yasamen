
namespace RoyalCode.Yasamen.Commons;

public record Borders
{
    public static class Standards
    {
        public static readonly BorderPositions DefaultPositions = BorderPositions.Default;
        public static readonly Themes DefaultColor = Themes.Default;
        public static readonly BorderWidth DefaultWidth = BorderWidth.One;
        public static readonly BorderStyles DefaultStyle = BorderStyles.Default;
        public static readonly BorderRound DefaultRound = BorderRound.None;
        public static readonly BorderRadius DefaultRadius = BorderRadius.Default;
        public static readonly Shadows DefaultShadow = Shadows.Default;

        public static readonly BorderRound DefaultBorderRounded = BorderRound.Default;

        public static readonly Shadows DefaultBorderWithShadow = Shadows.Small;

        public static readonly BorderPositions DefaultHeaderStyle = BorderPositions.Bottom;
        public static readonly BorderPositions DefaultFooterStyle = BorderPositions.Top;
    }

    private static Borders? _default;
    private static Borders? _defaultWithShadow;
    private static Borders? _defaultRounded;
    private static Borders? _defaultRoundedWithShadow;
    private static Borders? _defaultForHeaders;
    private static Borders? _defaultForFooters;
    private static Borders? _none;

    public static Borders Default => _default ??= new Borders
    {
        Positions = Standards.DefaultPositions,
        Color = Standards.DefaultColor,
        Width = Standards.DefaultWidth,
        Style = Standards.DefaultStyle,
        Round = Standards.DefaultRound,
        Radius = Standards.DefaultRadius,
        Shadow = Standards.DefaultShadow
    };

    public static Borders DefaultRounded => _defaultRounded ??= (Default with
    {
        Round = Standards.DefaultBorderRounded,
    });

    public static Borders DefaultWithShadow => _defaultWithShadow ??= (Default with
    {
        Shadow = Standards.DefaultBorderWithShadow
    });

    public static Borders DefaultRoundedWithShadow => _defaultRoundedWithShadow ??= (DefaultRounded with
    {
        Shadow = Standards.DefaultBorderWithShadow
    });

    public static Borders DefaultRoundedLightWithShadow => _defaultRoundedWithShadow ??= (DefaultRoundedWithShadow with
    {
        Color = Themes.Light
    });

    public static Borders DefaultForHeaders => _defaultForHeaders ??= (Default with
    {
        Positions = Standards.DefaultHeaderStyle
    });

    public static Borders DefaultForFooters => _defaultForFooters ??= (Default with
    {
        Positions = Standards.DefaultFooterStyle
    });

    public static Borders DefaultNone => _none ??= (Default with
    {
        Positions = BorderPositions.None
    });

    private string? cssClasses;

    public BorderPositions Positions { get; init; }

    public Themes Color { get; init; }

    public BorderWidth Width { get; init; }

    public BorderStyles Style { get; set; }

    public BorderRound Round { get; init; }

    public BorderRadius Radius { get; init; }

    public Shadows Shadow { get; init; }

    public string CssClasses => cssClasses ??=
        Positions == BorderPositions.None
            ? string.Empty
            : string.Join(' ', AllCssClasses().Where(s => s != string.Empty));

    private IEnumerable<string> AllCssClasses()
    {
        yield return Positions.ToBorderCssClasses();
        yield return Color.ToBorderCssClasses();
        yield return Width.ToBorderCssClasses();
        yield return Style.ToBorderCssClasses();
        yield return Round.ToBorderCssClasses();
        yield return Radius.ToBorderCssClasses();
        yield return Shadow.ToCssClass();
    }

}

public static class BordersExtensions
{
    public static string ToBorderCssClasses(this BorderPositions style)
    {
        return style switch
        {
            BorderPositions.None => "border-0",
            BorderPositions.Default => "border",
            BorderPositions.Top => "border-top",
            BorderPositions.End => "border-end",
            BorderPositions.Bottom => "border-bottom",
            BorderPositions.Start => "border-start",
            BorderPositions.NotAtTop => "border border-top-0",
            BorderPositions.NotAtEnd => "border border-end-0",
            BorderPositions.NotAtBottom => "border border-bottom-0",
            BorderPositions.NotAtStart => "border border-start-0",
            BorderPositions.TopEnd => "border-top border-end",
            BorderPositions.TopBottom => "border-top border-bottom",
            BorderPositions.TopStart => "border-top border-start",
            BorderPositions.EndBottom => "border-end border-bottom",
            BorderPositions.EndStart => "border-end border-start",
            BorderPositions.BottomStart => "border-bottom border-start",
            _ => string.Empty
        };
    }

    public static string ToBorderCssClasses(this Themes color)
    {
        return color switch
        {
            Themes.Primary => "border-primary",
            Themes.Secondary => "border-secondary",
            Themes.Tertiary => "border-tertiary",
            Themes.Info => "border-info",
            Themes.Highlight => "border-highlight",
            Themes.Success => "border-success",
            Themes.Warning => "border-warning",
            Themes.Alert => "border-alert",
            Themes.Danger => "border-danger",
            Themes.Light => "border-light",
            Themes.Dark => "border-dark",
            _ => string.Empty
        };
    }

    public static string ToBorderCssClasses(this BorderWidth width)
    {
        return width switch
        {
            BorderWidth.One => "border-1",
            BorderWidth.Two => "border-2",
            BorderWidth.Three => "border-3",
            BorderWidth.Four => "border-4",
            BorderWidth.Five => "border-5",
            BorderWidth.Six => "border-6",
            BorderWidth.Seven => "border-7",
            BorderWidth.Eight => "border-8",
            BorderWidth.Nine => "border-9",
            _ => string.Empty
        };
    }

    public static string ToBorderCssClasses(this BorderStyles style)
    {
        return style switch
        {
            BorderStyles.Solid => "border-solid",
            BorderStyles.Dashed => "border-dashed",
            BorderStyles.DotDashed => "border-dot-dashed",
            BorderStyles.DotDotDashed => "border-dot-dot-dashed",
            BorderStyles.Dotted => "border-dotted",
            BorderStyles.Double => "border-double",
            BorderStyles.Groove => "border-groove",
            BorderStyles.Hidden => "border-hidden",
            BorderStyles.Inset => "border-inset",
            BorderStyles.Outset => "border-outset",
            BorderStyles.Ridge => "border-ridge",
            BorderStyles.Wave => "border-wave",
            BorderStyles.Revert => "border-revert",
            BorderStyles.None => "border-none",
            _ => string.Empty
        };
    }

    public static string ToBorderCssClasses(this BorderRound round)
    {
        return round switch
        {
            BorderRound.None => "round-0",
            BorderRound.Default => "round",
            BorderRound.Top => "round-top",
            BorderRound.End => "round-end",
            BorderRound.Bottom => "round-bottom",
            BorderRound.Start => "round-start",
            BorderRound.TopStart => "round-top-start",
            BorderRound.TopEnd => "round-top-end",
            BorderRound.BottomStart => "round-bottom-start",
            BorderRound.BottomEnd => "round-bottom-end",
            BorderRound.Circle => "round-circle",
            BorderRound.Pill => "round-pill",
            BorderRound.Ellipse => "round-ellipse",
            _ => string.Empty
        };
    }

    public static string ToBorderCssClasses(this BorderRadius radius)
    {
        return radius switch
        {
            BorderRadius.One => "round-1",
            BorderRadius.Two => "round-2",
            BorderRadius.Three => "round-3",
            BorderRadius.Four => "round-4",
            BorderRadius.Five => "round-5",
            BorderRadius.Six => "round-6",
            BorderRadius.Seven => "round-7",
            BorderRadius.Eight => "round-8",
            BorderRadius.Nine => "round-9",
            _ => string.Empty
        };
    }
}

[Flags]
public enum BorderPositions
{
    None = 0,
    Top = 1,
    End = 2,
    Bottom = 4,
    Start = 8,

    Default = Top | End | Bottom | Start,

    NotAtTop = End | Bottom | Start,
    NotAtEnd = Top | Bottom | Start,
    NotAtBottom = Top | End | Start,
    NotAtStart = Top | End | Bottom,

    TopEnd = Top | End,
    TopBottom = Top | Bottom,
    TopStart = Top | Start,
    EndBottom = End | Bottom,
    EndStart = End | Start,
    BottomStart = Bottom | Start,
}

public enum BorderWidth
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine
}

public enum BorderStyles
{
    Default,
    Solid,
    Dashed,
    DotDashed,
    DotDotDashed,
    Dotted,
    Double,
    Groove,
    Hidden,
    Inset,
    Outset,
    Ridge,
    Wave,
    Revert,
    None
}

[Flags]
public enum BorderRound
{
    None = 0,
    Top = 1,
    End = 2,
    Bottom = 4,
    Start = 8,
    Circle = 16,
    Pill = 32,
    Ellipse = 64,

    Default = 15,

    TopStart = Top | Start,
    TopEnd = Top | End,
    BottomStart = Bottom | Start,
    BottomEnd = Bottom | End
}

public enum BorderRadius
{
    Default,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine
}

public interface IBorderBuilder
{
    IBorderStyleBuilder Style { get; }

    IBorderColorBuilder Color { get; }

    IBorderWidthBuilder Width { get; }

    IBorderRoundBuilder Radius { get; }

    IBorderShadowBuilder Shadow { get; }

    Borders Build();
}

public interface IBorderStyleBuilder
{
    IBorderBuilder Style(BorderPositions style);

    IBorderBuilder Default();

    IBorderBuilder Top();

    IBorderBuilder End();

    IBorderBuilder Bottom();

    IBorderBuilder Start();

    IBorderBuilder NotAtTop();

    IBorderBuilder NotAtEnd();

    IBorderBuilder NotAtBottom();

    IBorderBuilder NotAtStart();

    IBorderBuilder None();
}

public interface IBorderColorBuilder
{
    IBorderBuilder Color(Themes color);

    IBorderBuilder Default();

    IBorderBuilder Primary();

    IBorderBuilder Secondary();

    IBorderBuilder Tertiary();

    IBorderBuilder Info();

    IBorderBuilder Highlight();

    IBorderBuilder Success();

    IBorderBuilder Warning();

    IBorderBuilder Alert();

    IBorderBuilder Danger();

    IBorderBuilder Light();

    IBorderBuilder Dark();

}

public interface IBorderWidthBuilder
{
    IBorderBuilder Size(BorderWidth width);

    IBorderBuilder One();

    IBorderBuilder Two();

    IBorderBuilder Three();

    IBorderBuilder Four();

    IBorderBuilder Five();

    IBorderBuilder Six();

    IBorderBuilder Seven();

    IBorderBuilder Eight();

    IBorderBuilder Nine();
}

public interface IBorderRoundBuilder
{
    IBorderRadiusBuilder All();

    IBorderRadiusBuilder Top();

    IBorderRadiusBuilder End();

    IBorderRadiusBuilder Bottom();

    IBorderRadiusBuilder Start();

    IBorderRadiusBuilder TopStart();

    IBorderRadiusBuilder TopEnd();

    IBorderRadiusBuilder BottomStart();

    IBorderRadiusBuilder BottomEnd();

    IBorderBuilder Circle();

    IBorderBuilder Pill();

    IBorderBuilder Ellipse();

    IBorderBuilder None();
}

public interface IBorderRadiusBuilder
{
    IBorderBuilder Default();

    IBorderBuilder One();

    IBorderBuilder Two();

    IBorderBuilder Three();

    IBorderBuilder Four();

    IBorderBuilder Five();

    IBorderBuilder Six();

    IBorderBuilder Seven();

    IBorderBuilder Eight();

    IBorderBuilder Nine();
}

public interface IBorderShadowBuilder
{
    IBorderBuilder Shadow(Shadows shadow);

    IBorderBuilder None();

    IBorderBuilder Smallest();

    IBorderBuilder Small();

    IBorderBuilder Medium();

    IBorderBuilder Large();

    IBorderBuilder Largest();
}

internal class BorderBuilder(Borders borders) : IBorderBuilder
{
    public BorderBuilder() : this(Borders.Default) { }

    public IBorderStyleBuilder Style => new BorderStyleBuilder(borders);

    public IBorderColorBuilder Color => new BorderColorBuilder(borders);

    public IBorderWidthBuilder Width => new BorderWidthBuilder(borders);

    public IBorderRoundBuilder Radius => new BorderRoundBuilder(borders);

    public IBorderShadowBuilder Shadow => new BorderShadowBuilder(borders);

    public Borders Build() => borders;
}

internal class BorderShadowBuilder(Borders borders) : IBorderShadowBuilder
{
    public IBorderBuilder Shadow(Shadows shadow)
    {
        return new BorderBuilder(borders with
        {
            Shadow = shadow
        });
    }

    public IBorderBuilder None() => Shadow(Shadows.None);

    public IBorderBuilder Smallest() => Shadow(Shadows.Smallest);

    public IBorderBuilder Small() => Shadow(Shadows.Small);

    public IBorderBuilder Medium() => Shadow(Shadows.Medium);

    public IBorderBuilder Large() => Shadow(Shadows.Large);

    public IBorderBuilder Largest() => Shadow(Shadows.Largest);
}

internal class BorderRadiusBuilder(Borders borders) : IBorderRadiusBuilder
{
    public IBorderBuilder RoundedSize(BorderRadius roundedSize)
    {
        return new BorderBuilder(borders with
        {
            Radius = roundedSize
        });
    }

    public IBorderBuilder Default() => RoundedSize(BorderRadius.Default);

    public IBorderBuilder One() => RoundedSize(BorderRadius.One);

    public IBorderBuilder Two() => RoundedSize(BorderRadius.Two);

    public IBorderBuilder Three() => RoundedSize(BorderRadius.Three);

    public IBorderBuilder Four() => RoundedSize(BorderRadius.Four);

    public IBorderBuilder Five() => RoundedSize(BorderRadius.Five);

    public IBorderBuilder Six() => RoundedSize(BorderRadius.Six);

    public IBorderBuilder Seven() => RoundedSize(BorderRadius.Seven);

    public IBorderBuilder Eight() => RoundedSize(BorderRadius.Eight);

    public IBorderBuilder Nine() => RoundedSize(BorderRadius.Nine);
}

internal class BorderRoundBuilder(Borders borders) : IBorderRoundBuilder
{
    public IBorderRadiusBuilder Radius(BorderRound radius)
    {
        return new BorderRadiusBuilder(borders with
        {
            Round = radius
        });
    }

    private IBorderBuilder RadiusStyle(BorderRound radius)
    {
        return new BorderBuilder(borders with
        {
            Round = radius
        });
    }

    public IBorderRadiusBuilder All() => Radius(BorderRound.Default);

    public IBorderRadiusBuilder Top() => Radius(BorderRound.Top);

    public IBorderRadiusBuilder End() => Radius(BorderRound.End);

    public IBorderRadiusBuilder Bottom() => Radius(BorderRound.Bottom);

    public IBorderRadiusBuilder Start() => Radius(BorderRound.Start);

    public IBorderRadiusBuilder TopStart() => Radius(BorderRound.TopStart);

    public IBorderRadiusBuilder TopEnd() => Radius(BorderRound.TopEnd);

    public IBorderRadiusBuilder BottomStart() => Radius(BorderRound.BottomStart);

    public IBorderRadiusBuilder BottomEnd() => Radius(BorderRound.BottomEnd);

    public IBorderBuilder Circle() => RadiusStyle(BorderRound.Circle);

    public IBorderBuilder Pill() => RadiusStyle(BorderRound.Pill);

    public IBorderBuilder Ellipse() => RadiusStyle(BorderRound.Ellipse);

    public IBorderBuilder None() => RadiusStyle(BorderRound.None);
}

internal class BorderWidthBuilder(Borders borders) : IBorderWidthBuilder
{
    public IBorderBuilder Size(BorderWidth width)
    {
        return new BorderBuilder(borders with
        {
            Width = width
        });
    }

    public IBorderBuilder One() => Size(BorderWidth.One);

    public IBorderBuilder Two() => Size(BorderWidth.Two);

    public IBorderBuilder Three() => Size(BorderWidth.Three);

    public IBorderBuilder Four() => Size(BorderWidth.Four);

    public IBorderBuilder Five() => Size(BorderWidth.Five);

    public IBorderBuilder Six() => Size(BorderWidth.Six);

    public IBorderBuilder Seven() => Size(BorderWidth.Seven);

    public IBorderBuilder Eight() => Size(BorderWidth.Eight);

    public IBorderBuilder Nine() => Size(BorderWidth.Nine);
}

internal class BorderColorBuilder(Borders borders) : IBorderColorBuilder
{
    public IBorderBuilder Color(Themes color)
    {
        return new BorderBuilder(borders with
        {
            Color = color
        });
    }

    public IBorderBuilder Default() => Color(Themes.Default);

    public IBorderBuilder Primary() => Color(Themes.Primary);

    public IBorderBuilder Secondary() => Color(Themes.Secondary);

    public IBorderBuilder Tertiary() => Color(Themes.Tertiary);

    public IBorderBuilder Info() => Color(Themes.Info);

    public IBorderBuilder Highlight() => Color(Themes.Highlight);

    public IBorderBuilder Success() => Color(Themes.Success);

    public IBorderBuilder Warning() => Color(Themes.Warning);

    public IBorderBuilder Alert() => Color(Themes.Alert);

    public IBorderBuilder Danger() => Color(Themes.Danger);

    public IBorderBuilder Light() => Color(Themes.Light);

    public IBorderBuilder Dark() => Color(Themes.Dark);
}

internal class BorderStyleBuilder(Borders borders) : IBorderStyleBuilder
{
    public IBorderBuilder Style(BorderPositions style)
    {
        return new BorderBuilder(borders with
        {
            Positions = style
        });
    }

    public IBorderBuilder Default() => Style(BorderPositions.Default);

    public IBorderBuilder Top() => Style(BorderPositions.Top);

    public IBorderBuilder End() => Style(BorderPositions.End);

    public IBorderBuilder Bottom() => Style(BorderPositions.Bottom);

    public IBorderBuilder Start() => Style(BorderPositions.Start);

    public IBorderBuilder NotAtTop() => Style(BorderPositions.NotAtTop);

    public IBorderBuilder NotAtEnd() => Style(BorderPositions.NotAtEnd);

    public IBorderBuilder NotAtBottom() => Style(BorderPositions.NotAtBottom);

    public IBorderBuilder NotAtStart() => Style(BorderPositions.NotAtStart);

    public IBorderBuilder None() => Style(BorderPositions.None);
}