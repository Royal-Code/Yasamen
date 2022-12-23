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
        switch (size)
        {
            case Sizes.Default:
                return string.Empty;
            case Sizes.Smallest:
                return "xs";
            case Sizes.Small:
                return "sm";
            case Sizes.Medium:
                return "md";
            case Sizes.Large:
                return "lg";
            case Sizes.Largest:
                return "xl";
            default:
                throw new ArgumentOutOfRangeException(nameof(size), size, null);
        }
    }
}