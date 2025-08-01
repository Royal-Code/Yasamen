namespace RoyalCode.Razor.Styles;

public enum Saturate
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

public static class SaturateExtensions
{
    public static string ToCssClass(this Saturate saturate)
    {
        return saturate switch
        {
            Saturate.Default => string.Empty,
            Saturate.Smallest => "saturate-50",
            Saturate.Smaller => "saturate-75",
            Saturate.Small => "saturate-90",
            Saturate.Medium => "saturate-100",
            Saturate.Large => "saturate-125",
            Saturate.Larger => "saturate-150",
            Saturate.Largest => "saturate-200",
            _ => throw new ArgumentOutOfRangeException(nameof(saturate), saturate, null),
        };
    }

    public static string ToBackdropCssClass(this Saturate saturate)
    {
        return saturate switch
        {
            Saturate.Default => string.Empty,
            Saturate.Smallest => "backdrop-saturate-50",
            Saturate.Smaller => "backdrop-saturate-75",
            Saturate.Small => "backdrop-saturate-90",
            Saturate.Medium => "backdrop-saturate-100",
            Saturate.Large => "backdrop-saturate-125",
            Saturate.Larger => "backdrop-saturate-150",
            Saturate.Largest => "backdrop-saturate-200",
            _ => throw new ArgumentOutOfRangeException(nameof(saturate), saturate, null),
        };
    }
}
