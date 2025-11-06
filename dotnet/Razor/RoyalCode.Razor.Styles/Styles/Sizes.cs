namespace RoyalCode.Razor.Styles;

/// <summary>
/// Sizes enum for specifying sizes.
/// </summary>
public enum Sizes
{
    /// <summary>Default, It will not usually have an associated class or Medium size.</summary>
    Default,
    /// <summary>Smallest size.</summary>
    Smallest,
    /// <summary>Smaller size.</summary>
    Smaller,
    /// <summary>Small size.</summary>
    Small,
    /// <summary>Medium size.</summary>
    Medium,
    /// <summary>Large size.</summary>
    Large,
    /// <summary>Larger size.</summary>
    Larger,
    /// <summary>Largest size.</summary>
    Largest,
}

public static class SizesExtensions
{
    /// <summary>
    /// Converts the Sizes enum to its corresponding content CSS class.
    /// </summary>
    public static string ToContentCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "size-50",
            Sizes.Smaller => "size-75",
            Sizes.Small => "size-90",
            Sizes.Medium => "size-100",
            Sizes.Large => "size-125",
            Sizes.Larger => "size-150",
            Sizes.Largest => "size-200",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }
}