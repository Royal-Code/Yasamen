namespace RoyalCode.Yasamen.Commons;

public enum Sizes
{
    Default,
    
    Smallest,
    Small,
    Medium,
    Large,
    Largest,
}

public static class SizesExtensions
{
    public static string ToAbbrCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "xs",
            Sizes.Small => "sm",
            Sizes.Medium => "md",
            Sizes.Large => "lg",
            Sizes.Largest => "xl",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }
}