namespace RoyalCode.Razor.Styles;

public enum Opacity
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

public static class OpacityExtensions
{
    public static string ToCssClass(this Opacity opacity)
    {
        return opacity switch
        {
            Opacity.Default => string.Empty,
            Opacity.Ten => "opacity-10",
            Opacity.Twenty => "opacity-20",
            Opacity.TwentyFive => "opacity-25",
            Opacity.Fifty => "opacity-50",
            Opacity.SeventyFive => "opacity-75",
            Opacity.Eighty => "opacity-80",
            Opacity.Ninety => "opacity-90",
            Opacity.None => "opacity-100",
            Opacity.Full => "opacity-0",
            _ => throw new ArgumentOutOfRangeException(nameof(opacity), opacity, null)
        };
    }

    public static string ToBackdropCssClass(this Opacity opacity)
    {
        return opacity switch
        {
            Opacity.Default => string.Empty,
            Opacity.Ten => "backdrop-opacity-10",
            Opacity.Twenty => "backdrop-opacity-20",
            Opacity.TwentyFive => "backdrop-opacity-25",
            Opacity.Fifty => "backdrop-opacity-50",
            Opacity.SeventyFive => "backdrop-opacity-75",
            Opacity.Eighty => "backdrop-opacity-80",
            Opacity.Ninety => "backdrop-opacity-90",
            Opacity.None => "backdrop-opacity-100",
            Opacity.Full => "backdrop-opacity-0",
            _ => throw new ArgumentOutOfRangeException(nameof(opacity), opacity, null)
        };
    }
}