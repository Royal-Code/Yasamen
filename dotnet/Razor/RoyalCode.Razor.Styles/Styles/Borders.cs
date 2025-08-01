namespace RoyalCode.Razor.Styles;

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
    Default = 128,

    All = Top | End | Bottom | Start,

    TopStart = Top | Start,
    TopEnd = Top | End,
    BottomStart = Bottom | Start,
    BottomEnd = Bottom | End
}

[Flags]
public enum BorderSide
{
    None = 0,
    Top = 1,
    End = 2,
    Bottom = 4,
    Start = 8,
    Default = 16,

    All = Top | End | Bottom | Start,

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

public enum BorderWidth
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

public static class BordersExtensions
{
    public static string ToCssClass(this BorderSide style)
    {
        return style switch
        {
            BorderSide.Default => string.Empty,
            BorderSide.None => "border-0",
            BorderSide.All => "border",
            BorderSide.Top => "border-top",
            BorderSide.End => "border-end",
            BorderSide.Bottom => "border-bottom",
            BorderSide.Start => "border-start",
            BorderSide.NotAtTop => "border border-top-0",
            BorderSide.NotAtEnd => "border border-end-0",
            BorderSide.NotAtBottom => "border border-bottom-0",
            BorderSide.NotAtStart => "border border-start-0",
            BorderSide.TopEnd => "border-top border-end",
            BorderSide.TopBottom => "border-top border-bottom",
            BorderSide.TopStart => "border-top border-start",
            BorderSide.EndBottom => "border-end border-bottom",
            BorderSide.EndStart => "border-end border-start",
            BorderSide.BottomStart => "border-bottom border-start",
            _ => string.Empty
        };
    }

    public static string ToCssClass(this BorderWidth width)
    {
        return width switch
        {
            BorderWidth.Default => string.Empty,
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

    public static string ToCssClass(this BorderStyles style)
    {
        return style switch
        {
            BorderStyles.Default => string.Empty,
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

    public static string ToCssClass(this BorderRound round)
    {
        return round switch
        {
            BorderRound.Default => string.Empty,
            BorderRound.None => "round-0",
            BorderRound.All => "round",
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

    public static string ToCssClass(this BorderRadius radius)
    {
        return radius switch
        {
            BorderRadius.Default => string.Empty,
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
