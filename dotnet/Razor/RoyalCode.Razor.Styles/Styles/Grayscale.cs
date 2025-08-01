namespace RoyalCode.Razor.Styles;

public enum Grayscale
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

public static class GrayscaleExtensions
{
    public static string ToCssClass(this Grayscale grayscale)
    {
        return grayscale switch
        {
            Grayscale.Default => string.Empty,
            Grayscale.Ten => "grayscale-10",
            Grayscale.Twenty => "grayscale-20",
            Grayscale.TwentyFive => "grayscale-25",
            Grayscale.Fifty => "grayscale-50",
            Grayscale.SeventyFive => "grayscale-75",
            Grayscale.Eighty => "grayscale-80",
            Grayscale.Ninety => "grayscale-90",
            Grayscale.None => "grayscale-0",
            Grayscale.Full => "grayscale",
            _ => throw new ArgumentOutOfRangeException(nameof(grayscale), grayscale, null)
        };
    }

    public static string ToBackdropCssClass(this Grayscale grayscale)
    {
        return grayscale switch
        {
            Grayscale.Default => string.Empty,
            Grayscale.Ten => "backdrop-grayscale-10",
            Grayscale.Twenty => "backdrop-grayscale-20",
            Grayscale.TwentyFive => "backdrop-grayscale-25",
            Grayscale.Fifty => "backdrop-grayscale-50",
            Grayscale.SeventyFive => "backdrop-grayscale-75",
            Grayscale.Eighty => "backdrop-grayscale-80",
            Grayscale.Ninety => "backdrop-grayscale-90",
            Grayscale.None => "backdrop-grayscale-0",
            Grayscale.Full => "backdrop-grayscale",
            _ => throw new ArgumentOutOfRangeException(nameof(grayscale), grayscale, null)
        };
    }
}
