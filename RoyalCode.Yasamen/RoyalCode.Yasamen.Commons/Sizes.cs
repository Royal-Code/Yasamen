namespace RoyalCode.Yasamen.Commons;

public enum Sizes
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

public static class SizesExtensions
{
    public static string ToAbbrCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "xxs",
            Sizes.Smaller => "xs",
            Sizes.Small => "sm",
            Sizes.Medium => "md",
            Sizes.Large => "lg",
            Sizes.Larger => "xl",
            Sizes.Largest => "xxl",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }
}