namespace RoyalCode.Razor.Styles;

public enum OutlineWidth
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

public enum OutlineStyle
{
    Default,
    Solid,
    Dashed,
    Dotted,
    Double,
    None,
    Hidden
}

public enum OutlineOffset
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

public static class OutlineExtensions
{
    public static string ToCssClass(this OutlineWidth width)
    {
        return width switch
        {
            OutlineWidth.Default => string.Empty,
            OutlineWidth.One => "outline-1",
            OutlineWidth.Two => "outline-2",
            OutlineWidth.Three => "outline-3",
            OutlineWidth.Four => "outline-4",
            OutlineWidth.Five => "outline-5",
            OutlineWidth.Six => "outline-6",
            OutlineWidth.Seven => "outline-7",
            OutlineWidth.Eight => "outline-8",
            OutlineWidth.Nine => "outline-9",
            _ => throw new ArgumentOutOfRangeException(nameof(width), width, null)
        };
    }

    public static string ToCssClass(this OutlineStyle style)
    {
        return style switch
        {
            OutlineStyle.Default => string.Empty,
            OutlineStyle.Solid => "outline-solid",
            OutlineStyle.Dashed => "outline-dashed",
            OutlineStyle.Dotted => "outline-dotted",
            OutlineStyle.Double => "outline-double",
            OutlineStyle.None => "outline-none",
            OutlineStyle.Hidden => "outline-hidden",
            _ => throw new ArgumentOutOfRangeException(nameof(style), style, null)
        };
    }

    public static string ToCssClass(this OutlineOffset offset)
    {
        return offset switch
        {
            OutlineOffset.Default => string.Empty,
            OutlineOffset.One => "outline-offset-1",
            OutlineOffset.Two => "outline-offset-2",
            OutlineOffset.Three => "outline-offset-3",
            OutlineOffset.Four => "outline-offset-4",
            OutlineOffset.Five => "outline-offset-5",
            OutlineOffset.Six => "outline-offset-6",
            OutlineOffset.Seven => "outline-offset-7",
            OutlineOffset.Eight => "outline-offset-8",
            OutlineOffset.Nine => "outline-offset-9",
            _ => throw new ArgumentOutOfRangeException(nameof(offset), offset, null)
        };
    }
}
