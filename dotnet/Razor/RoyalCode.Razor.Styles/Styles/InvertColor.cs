namespace RoyalCode.Razor.Styles;

public enum InvertColor
{
    Default,
    Ten,
    Twenty,
    TwentyFive,
    Fifty,
    SeventyFive,
    Eighty,
    Ninety,
    None,
    Full
}

public static class InvertColorExtensions
{
    public static string ToCssClass(this InvertColor invertColor)
    {
        return invertColor switch
        {
            InvertColor.Default => string.Empty,
            InvertColor.Ten => "invert-10",
            InvertColor.Twenty => "invert-20",
            InvertColor.TwentyFive => "invert-25",
            InvertColor.Fifty => "invert-50",
            InvertColor.SeventyFive => "invert-75",
            InvertColor.Eighty => "invert-80",
            InvertColor.Ninety => "invert-90",
            InvertColor.None => "invert-0",
            InvertColor.Full => "invert",
            _ => throw new ArgumentOutOfRangeException(nameof(invertColor), invertColor, null)
        };
    }

    public static string ToBackdropCssClass(this InvertColor invertColor)
    {
                return invertColor switch
        {
            InvertColor.Default => string.Empty,
            InvertColor.Ten => "backdrop-invert-10",
            InvertColor.Twenty => "backdrop-invert-20",
            InvertColor.TwentyFive => "backdrop-invert-25",
            InvertColor.Fifty => "backdrop-invert-50",
            InvertColor.SeventyFive => "backdrop-invert-75",
            InvertColor.Eighty => "backdrop-invert-80",
            InvertColor.Ninety => "backdrop-invert-90",
            InvertColor.None => "backdrop-invert-0",
            InvertColor.Full => "backdrop-invert",
            _ => throw new ArgumentOutOfRangeException(nameof(invertColor), invertColor, null)
        };
    }
}
