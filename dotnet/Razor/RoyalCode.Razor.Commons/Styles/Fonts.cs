namespace RoyalCode.Razor.Commons.Styles;

public enum Fonts
{
    Default,
    Sans,
    Serif,
    Mono,
}

public enum FontSizes
{
    Default,
    SmallerX4,
    SmallerX3,
    SmallerX2,
    Smaller,
    Small,
    Medium,
    Large,
    Larger,
    LargerX2,
    LargerX3,
    LargerX4,
    LargerX5,
    LargerX6,
    LargerX7,
    LargerX8,
    LargerX9
}

public enum FontSmoothing
{
    Default,
    Antialiased,
    SubpixelAntialiased
}

public enum FontStyle
{
    Default,
    Normal,
    Italic
}

public enum FontWeight
{
    Default,
    Thin,
    ExtraLight,
    Light,
    Normal,
    Medium,
    SemiBold,
    Bold,
    ExtraBold,
    Black
}

public static class FontsExtensions
{
    public static string ToCssClass(this Fonts font)
    {
        return font switch
        {
            Fonts.Default => string.Empty,
            Fonts.Sans => "font-sans",
            Fonts.Serif => "font-serif",
            Fonts.Mono => "font-mono",
            _ => throw new ArgumentOutOfRangeException(nameof(font), font, null)
        };
    }

    public static string ToCssClass(this FontSizes size)
    {
        return size switch
        {
            FontSizes.Default => string.Empty,
            FontSizes.SmallerX4 => "text-4xs",
            FontSizes.SmallerX3 => "text-3xs",
            FontSizes.SmallerX2 => "text-2xs",
            FontSizes.Smaller => "text-xs",
            FontSizes.Small => "text-sm",
            FontSizes.Medium => "text-base",
            FontSizes.Large => "text-lg",
            FontSizes.Larger => "text-xl",
            FontSizes.LargerX2 => "text-2xl",
            FontSizes.LargerX3 => "text-3xl",
            FontSizes.LargerX4 => "text-4xl",
            FontSizes.LargerX5 => "text-5xl",
            FontSizes.LargerX6 => "text-6xl",
            FontSizes.LargerX7 => "text-7xl",
            FontSizes.LargerX8 => "text-8xl",
            FontSizes.LargerX9 => "text-9xl",
        };
    }

    public static string ToCssClass(this FontSmoothing smoothing)
    {
        return smoothing switch
        {
            FontSmoothing.Default => string.Empty,
            FontSmoothing.Antialiased => "antialiased",
            FontSmoothing.SubpixelAntialiased => "subpixel-antialiased",
            _ => throw new ArgumentOutOfRangeException(nameof(smoothing), smoothing, null)
        };
    }

    public static string ToCssClass(this FontStyle style)
    {
        return style switch
        {
            FontStyle.Default => string.Empty,
            FontStyle.Normal => "not-italic",
            FontStyle.Italic => "italic",
            _ => throw new ArgumentOutOfRangeException(nameof(style), style, null)
        };
    }

    public static string ToCssClass(this FontWeight weight)
    {
        return weight switch
        {
            FontWeight.Default => string.Empty,
            FontWeight.Thin => "font-thin",
            FontWeight.ExtraLight => "font-extralight",
            FontWeight.Light => "font-light",
            FontWeight.Normal => "font-normal",
            FontWeight.Medium => "font-medium",
            FontWeight.SemiBold => "font-semibold",
            FontWeight.Bold => "font-bold",
            FontWeight.ExtraBold => "font-extrabold",
            FontWeight.Black => "font-black",
            _ => throw new ArgumentOutOfRangeException(nameof(weight), weight, null)
        };
    }
}