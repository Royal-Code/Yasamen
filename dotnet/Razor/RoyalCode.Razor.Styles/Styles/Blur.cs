namespace RoyalCode.Razor.Styles;

public enum Blur
{
    Default,
    None,
    Smaller,
    Small,
    Medium,
    Large,
    Larger,
    LargerX2,
    LargerX3,
}

public static class BlurExtensions
{
    public static string ToCssClass(this Blur blur)
    {
        return blur switch
        {
            Blur.Default => string.Empty,
            Blur.None => "blur-none",
            Blur.Smaller => "blur-xs",
            Blur.Small => "blur-sm",
            Blur.Medium => "blur-md",
            Blur.Large => "blur-lg",
            Blur.Larger => "blur-xl",
            Blur.LargerX2 => "blur-2xl",
            Blur.LargerX3 => "blur-3xl",
            _ => throw new ArgumentOutOfRangeException(nameof(blur), blur, null),
        };
    }

    public static string ToBackdropCssClass(this Blur blur)
    {
        return blur switch
        {
            Blur.Default => string.Empty,
            Blur.None => "backdrop-blur-none",
            Blur.Smaller => "backdrop-blur-xs",
            Blur.Small => "backdrop-blur-sm",
            Blur.Medium => "backdrop-blur-md",
            Blur.Large => "backdrop-blur-lg",
            Blur.Larger => "backdrop-blur-xl",
            Blur.LargerX2 => "backdrop-blur-2xl",
            Blur.LargerX3 => "backdrop-blur-3xl",
            _ => throw new ArgumentOutOfRangeException(nameof(blur), blur, null),
        };
    }
}
