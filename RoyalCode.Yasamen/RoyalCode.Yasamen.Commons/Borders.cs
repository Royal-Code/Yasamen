
namespace RoyalCode.Yasamen.Commons;

public record Borders
{
    public static class Standards
    {
        public static BorderStyle DefaultStyle = BorderStyle.Default;
        public static Themes DefaultColor = Themes.Default;
        public static Sizes DefaultWidth = Sizes.Default;
        public static BorderRadius DefaultRadius = BorderRadius.None;
        public static BorderRoundedSize DefaultRoundedSize = BorderRoundedSize.Default;
        public static Shadows DefaultShadow = Shadows.Default;

        public static BorderRadius DefaultRoundedBorderRadius = BorderRadius.Default;
        public static Shadows DefaultWithShadow = Shadows.Small;
        
        public static BorderStyle DefaultHeaderStyle = BorderStyle.Bottom;
        public static BorderStyle DefaultFooterStyle = BorderStyle.Top;
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

    public static Borders DefaultRounded => _defaultRounded ??= Default with
    {
        Radius = Standards.DefaultRoundedBorderRadius
    };
    
    public static Borders DefaultWithShadow => _defaultWithShadow ??= Default with
    {
        Shadow = Standards.DefaultWithShadow
    };
    
    public static Borders DefaultRoundedWithShadow => _defaultRoundedWithShadow ??= DefaultRounded with
    {
        Radius = Standards.DefaultRoundedBorderRadius,
        Shadow = Standards.DefaultWithShadow
    };

    public static Borders DefaultForHeaders => _defaultForHeaders ??= Default with
    {
        Style = Standards.DefaultHeaderStyle
    };
    
    public static Borders DefaultForFooters => _defaultForFooters ??= Default with
    {
        Style = Standards.DefaultFooterStyle
    };

    public static Borders DefaultNone => _none ??= Default with
    {
        Style = BorderStyle.None
    };

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