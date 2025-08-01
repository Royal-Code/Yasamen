namespace RoyalCode.Razor.Styles;

public enum Brightness
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

public static class BrightnessExtensions
{
    public static string ToCssClass(this Brightness brightness)
    {
        return brightness switch
        {
            Brightness.Default => string.Empty,
            Brightness.Smallest => "brightness-50",
            Brightness.Smaller => "brightness-75",
            Brightness.Small => "brightness-90",
            Brightness.Medium => "brightness-100",
            Brightness.Large => "brightness-125",
            Brightness.Larger => "brightness-150",
            Brightness.Largest => "brightness-200",
            _ => throw new ArgumentOutOfRangeException(nameof(brightness), brightness, null),
        };
    }

    public static string ToBackdropCssClass(this Brightness brightness)
    {
        return brightness switch
        {
            Brightness.Default => string.Empty,
            Brightness.Smallest => "backdrop-brightness-50",
            Brightness.Smaller => "backdrop-brightness-75",
            Brightness.Small => "backdrop-brightness-90",
            Brightness.Medium => "backdrop-brightness-100",
            Brightness.Large => "backdrop-brightness-125",
            Brightness.Larger => "backdrop-brightness-150",
            Brightness.Largest => "backdrop-brightness-200",
            _ => throw new ArgumentOutOfRangeException(nameof(brightness), brightness, null),
        };
    }
}
