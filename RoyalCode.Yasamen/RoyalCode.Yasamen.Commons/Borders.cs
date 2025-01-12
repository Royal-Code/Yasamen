
namespace RoyalCode.Yasamen.Commons;

public record Borders
{
    public static class Standards
    {
        public static readonly BorderStyle DefaultStyle = BorderStyle.Default;
        public static readonly Themes DefaultColor = Themes.Default;
        public static readonly Sizes DefaultWidth = Sizes.Default;
        public static readonly BorderRadius DefaultRadius = BorderRadius.None;
        public static readonly BorderRoundedSize DefaultRoundedSize = BorderRoundedSize.Default;
        public static readonly Shadows DefaultShadow = Shadows.Default;

        public static readonly BorderRadius DefaultRoundedBorderRadius = BorderRadius.Default;
        public static readonly BorderRoundedSize DefaultRoundedBorderRoundedSize = BorderRoundedSize.Medium;
        public static readonly Shadows DefaultBorderWithShadow = Shadows.Small;
        
        public static readonly BorderStyle DefaultHeaderStyle = BorderStyle.Bottom;
        public static readonly BorderStyle DefaultFooterStyle = BorderStyle.Top;
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
            Style = Standards.DefaultStyle,
            Color = Standards.DefaultColor,
            Width = Standards.DefaultWidth,
            Radius = Standards.DefaultRadius,
            RoundedSize = Standards.DefaultRoundedSize,
            Shadow = Standards.DefaultShadow
        };

    public static Borders DefaultRounded => _defaultRounded ??= (Default with
    {
        Radius = Standards.DefaultRoundedBorderRadius,
        RoundedSize = Standards.DefaultRoundedBorderRoundedSize
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
        Style = Standards.DefaultHeaderStyle
    });
    
    public static Borders DefaultForFooters => _defaultForFooters ??= (Default with
    {
        Style = Standards.DefaultFooterStyle
    });

    public static Borders DefaultNone => _none ??= (Default with
    {
        Style = BorderStyle.None
    });

    private string? cssClasses;
    
    public BorderStyle Style { get; init; }
    
    public Themes Color { get; init; }
    
    public Sizes Width { get; init; }
    
    public BorderRadius Radius { get; init; }
    
    public BorderRoundedSize RoundedSize { get; init; }
    
    public Shadows Shadow { get; init; }

    public string CssClasses => cssClasses ??=
        Style == BorderStyle.None 
            ? string.Empty 
            : string.Join(' ', AllCssClasses().Where(s => s != string.Empty));
    
    private IEnumerable<string> AllCssClasses()
    {
        yield return ToStyleCssClasses();
        yield return ToColorCssClasses();
        yield return ToWidthCssClasses();
        yield return ToRadiusCssClasses();
        yield return ToRoundedSizeCssClasses();
        yield return Shadow.ToCssClass();
    }

    private string ToStyleCssClasses()
    {
        return Style switch
        {
            BorderStyle.Default => "border",
            BorderStyle.Top => "border-top",
            BorderStyle.End => "border-end",
            BorderStyle.Bottom => "border-bottom",
            BorderStyle.Start => "border-start",
            BorderStyle.NotAtTop => "border-top-0",
            BorderStyle.NotAtEnd => "border-end-0",
            BorderStyle.NotAtBottom => "border-bottom-0",
            BorderStyle.NotAtStart => "border-start-0",
            _ => string.Empty
        };
    }

    private string ToColorCssClasses()
    {
        return Color switch
        {
            Themes.Default => string.Empty,
            Themes.Primary => "border-primary",
            Themes.Secondary => "border-secondary",
            Themes.Success => "border-success",
            Themes.Danger => "border-danger",
            Themes.Warning => "border-warning",
            Themes.Info => "border-info",
            Themes.Light => "border-light",
            Themes.Dark => "border-dark",
            Themes.White => "border-white",
            Themes.Main => "border-main",
            _ => string.Empty
        };
    }

    private string ToWidthCssClasses()
    {
        return Width switch
        {
            Sizes.Smallest => "border-1",
            Sizes.Small => "border-2",
            Sizes.Medium => "border-3",
            Sizes.Large => "border-4",
            Sizes.Largest => "border-5",
            _ => string.Empty
        };
    }

    private string ToRadiusCssClasses()
    {
        return Radius switch
        {
            BorderRadius.None => string.Empty,
            BorderRadius.Default => "rounded",
            BorderRadius.Top => "rounded-top",
            BorderRadius.End => "rounded-end",
            BorderRadius.Bottom => "rounded-bottom",
            BorderRadius.Start => "rounded-start",
            BorderRadius.Circle => "rounded-circle",
            BorderRadius.Pill => "rounded-pill",
            _ => string.Empty
        };
    }

    private string ToRoundedSizeCssClasses()
    {
        return RoundedSize switch
        {
            BorderRoundedSize.Default => string.Empty,
            BorderRoundedSize.None => "rounded-0",
            BorderRoundedSize.Small => "rounded-1",
            BorderRoundedSize.Medium => "rounded-2",
            BorderRoundedSize.Large => "rounded-3",
            _ => string.Empty
        };
    }
}

public enum BorderStyle
{
    None,
    Default,
    Top,
    End,
    Bottom,
    Start,
    NotAtTop,
    NotAtEnd,
    NotAtBottom,
    NotAtStart
}

public enum BorderRadius
{
    None,
    Default,
    Top,
    End,
    Bottom,
    Start,
    Circle,
    Pill
}

public enum BorderRoundedSize
{
    Default,
    None,
    Small,
    Medium,
    Large
}

public interface IBorderBuilder
{
    IBorderStyleBuilder Style { get; }

    IBorderColorBuilder Color { get; }

    IBorderWidthBuilder Width { get; }

    IBorderRadiusBuilder Radius { get; }

    IBorderShadowBuilder Shadow { get; }

    Borders Build();
}

public interface IBorderStyleBuilder
{
    IBorderBuilder Style(BorderStyle style);

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

    IBorderBuilder Success();

    IBorderBuilder Danger();

    IBorderBuilder Warning();

    IBorderBuilder Info();

    IBorderBuilder Light();

    IBorderBuilder Dark();

    IBorderBuilder White();

    IBorderBuilder Main();
}

public interface IBorderWidthBuilder
{
    IBorderBuilder Size(Sizes size);

    IBorderBuilder Smallest();

    IBorderBuilder Small();

    IBorderBuilder Medium();

    IBorderBuilder Large();

    IBorderBuilder Largest();
}

public interface IBorderRadiusBuilder
{
    IBorderRoundedSizeBuilder Radius(BorderRadius radius);

    IBorderRoundedSizeBuilder Default();

    IBorderRoundedSizeBuilder Top();

    IBorderRoundedSizeBuilder End();

    IBorderRoundedSizeBuilder Bottom();

    IBorderRoundedSizeBuilder Start();

    IBorderRoundedSizeBuilder Circle();

    IBorderRoundedSizeBuilder Pill();

    IBorderRoundedSizeBuilder None();
}

public interface IBorderRoundedSizeBuilder
{
    IBorderBuilder RoundedSize(BorderRoundedSize roundedSize);

    IBorderBuilder Default();

    IBorderBuilder None();

    IBorderBuilder Small();

    IBorderBuilder Medium();

    IBorderBuilder Large();
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

    public IBorderRadiusBuilder Radius => new BorderRadiusBuilder(borders);

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

internal class BorderRoundedSizeBuilder(Borders borders) : IBorderRoundedSizeBuilder
{
    public IBorderBuilder RoundedSize(BorderRoundedSize roundedSize)
    {
        return new BorderBuilder(borders with
        {
            RoundedSize = roundedSize
        });
    }

    public IBorderBuilder Default() => RoundedSize(BorderRoundedSize.Default);

    public IBorderBuilder None() => RoundedSize(BorderRoundedSize.None);

    public IBorderBuilder Small() => RoundedSize(BorderRoundedSize.Small);

    public IBorderBuilder Medium() => RoundedSize(BorderRoundedSize.Medium);

    public IBorderBuilder Large() => RoundedSize(BorderRoundedSize.Large);
}

internal class BorderRadiusBuilder(Borders borders) : IBorderRadiusBuilder
{
    public IBorderRoundedSizeBuilder Radius(BorderRadius radius)
    {
        return new BorderRoundedSizeBuilder(borders with
        {
            Radius = radius
        });
    }

    public IBorderRoundedSizeBuilder Default() => Radius(BorderRadius.Default);

    public IBorderRoundedSizeBuilder Top() => Radius(BorderRadius.Top);

    public IBorderRoundedSizeBuilder End() => Radius(BorderRadius.End);

    public IBorderRoundedSizeBuilder Bottom() => Radius(BorderRadius.Bottom);

    public IBorderRoundedSizeBuilder Start() => Radius(BorderRadius.Start);

    public IBorderRoundedSizeBuilder Circle() => Radius(BorderRadius.Circle);

    public IBorderRoundedSizeBuilder Pill() => Radius(BorderRadius.Pill);

    public IBorderRoundedSizeBuilder None() => Radius(BorderRadius.None);
}

internal class BorderWidthBuilder(Borders borders) : IBorderWidthBuilder
{
    public IBorderBuilder Size(Sizes size)
    {
        return new BorderBuilder(borders with
        {
            Width = size
        });
    }

    public IBorderBuilder Smallest() => Size(Sizes.Smallest);

    public IBorderBuilder Small() => Size(Sizes.Small);

    public IBorderBuilder Medium() => Size(Sizes.Medium);

    public IBorderBuilder Large() => Size(Sizes.Large);

    public IBorderBuilder Largest() => Size(Sizes.Largest);
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

    public IBorderBuilder Success() => Color(Themes.Success);

    public IBorderBuilder Danger() => Color(Themes.Danger);

    public IBorderBuilder Warning() => Color(Themes.Warning);

    public IBorderBuilder Info() => Color(Themes.Info);

    public IBorderBuilder Light() => Color(Themes.Light);

    public IBorderBuilder Dark() => Color(Themes.Dark);

    public IBorderBuilder White() => Color(Themes.White);

    public IBorderBuilder Main() => Color(Themes.Main);
}

internal class BorderStyleBuilder(Borders borders) : IBorderStyleBuilder
{
    public IBorderBuilder Style(BorderStyle style)
    {
        return new BorderBuilder(borders with
        {
            Style = style
        });
    }

    public IBorderBuilder Default() => Style(BorderStyle.Default);

    public IBorderBuilder Top() => Style(BorderStyle.Top);

    public IBorderBuilder End() => Style(BorderStyle.End);

    public IBorderBuilder Bottom() => Style(BorderStyle.Bottom);

    public IBorderBuilder Start() => Style(BorderStyle.Start);

    public IBorderBuilder NotAtTop() => Style(BorderStyle.NotAtTop);

    public IBorderBuilder NotAtEnd() => Style(BorderStyle.NotAtEnd);

    public IBorderBuilder NotAtBottom() => Style(BorderStyle.NotAtBottom);

    public IBorderBuilder NotAtStart() => Style(BorderStyle.NotAtStart);

    public IBorderBuilder None() => Style(BorderStyle.None);
}