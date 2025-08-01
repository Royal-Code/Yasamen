namespace RoyalCode.Razor.Styles;

public enum Contrast
{
    Default,
    Smallest,
    Smaller,
    Small,
    Medium,
    Large,
    Larger,
    Largest,
}

public static class ContrastExtensions
{
    public static string ToCssClass(this Contrast contrast)
    {
        return contrast switch
        {
            Contrast.Default => string.Empty,
            Contrast.Smallest => "contrast-50",
            Contrast.Smaller => "contrast-75",
            Contrast.Small => "contrast-90",
            Contrast.Medium => "contrast-100",
            Contrast.Large => "contrast-125",
            Contrast.Larger => "contrast-150",
            Contrast.Largest => "contrast-200",
            _ => throw new ArgumentOutOfRangeException(nameof(contrast), contrast, null),
        };
    }

    public static string ToBackdropCssClass(this Contrast contrast)
    {
        return contrast switch
        {
            Contrast.Default => string.Empty,
            Contrast.Smallest => "backdrop-contrast-50",
            Contrast.Smaller => "backdrop-contrast-75",
            Contrast.Small => "backdrop-contrast-90",
            Contrast.Medium => "backdrop-contrast-100",
            Contrast.Large => "backdrop-contrast-125",
            Contrast.Larger => "backdrop-contrast-150",
            Contrast.Largest => "backdrop-contrast-200",
            _ => throw new ArgumentOutOfRangeException(nameof(contrast), contrast, null),
        };
    }
}
