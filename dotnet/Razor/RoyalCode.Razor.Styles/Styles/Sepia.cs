namespace RoyalCode.Razor.Styles;

public enum Sepia
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

public static class SepiaExtensions
{
    public static string ToCssClass(this Sepia sepia)
    {
        return sepia switch
        {
            Sepia.Default => string.Empty,
            Sepia.Ten => "sepia-10",
            Sepia.Twenty => "sepia-20",
            Sepia.TwentyFive => "sepia-25",
            Sepia.Fifty => "sepia-50",
            Sepia.SeventyFive => "sepia-75",
            Sepia.Eighty => "sepia-80",
            Sepia.Ninety => "sepia-90",
            Sepia.None => "sepia-0",
            Sepia.Full => "sepia",
            _ => throw new ArgumentOutOfRangeException(nameof(sepia), sepia, null)
        };
    }

    public static string ToBackdropCssClass(this Sepia sepia)
    {
        return sepia switch
        {
            Sepia.Default => string.Empty,
            Sepia.Ten => "backdrop-sepia-10",
            Sepia.Twenty => "backdrop-sepia-20",
            Sepia.TwentyFive => "backdrop-sepia-25",
            Sepia.Fifty => "backdrop-sepia-50",
            Sepia.SeventyFive => "backdrop-sepia-75",
            Sepia.Eighty => "backdrop-sepia-80",
            Sepia.Ninety => "backdrop-sepia-90",
            Sepia.None => "backdrop-sepia-0",
            Sepia.Full => "backdrop-sepia",
            _ => throw new ArgumentOutOfRangeException(nameof(sepia), sepia, null)
        };
    }
}
