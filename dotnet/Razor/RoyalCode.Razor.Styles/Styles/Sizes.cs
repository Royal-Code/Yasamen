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
    /// Converts the Sizes enum to its corresponding content CSS class to apply width/height.
    /// </summary>
    public static string ToContentCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "size-25",
            Sizes.Smaller => "size-50",
            Sizes.Small => "size-75",
            Sizes.Medium => "size-100",
            Sizes.Large => "size-125",
            Sizes.Larger => "size-150",
            Sizes.Largest => "size-200",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }

    /// <summary>
    /// Converts the Sizes enum to its corresponding content CSS class to apply minimum width/height.
    /// </summary>
    public static string ToMinContentCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "min-size-25",
            Sizes.Smaller => "min-size-50",
            Sizes.Small => "min-size-75",
            Sizes.Medium => "min-size-100",
            Sizes.Large => "min-size-125",
            Sizes.Larger => "min-size-150",
            Sizes.Largest => "min-size-200",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }

    /// <summary>
    /// Converts the Sizes enum to its corresponding content CSS class to apply maximum width/height.
    /// </summary>
    public static string ToMaxContentCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "max-size-25",
            Sizes.Smaller => "max-size-50",
            Sizes.Small => "max-size-75",
            Sizes.Medium => "max-size-100",
            Sizes.Large => "max-size-125",
            Sizes.Larger => "max-size-150",
            Sizes.Largest => "max-size-200",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }

    /// <summary>
    /// Converts the Sizes enum to its corresponding content CSS class to apply width.
    /// </summary>
    public static string ToContentWidthCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "w-25",
            Sizes.Smaller => "w-50",
            Sizes.Small => "w-75",
            Sizes.Medium => "w-100",
            Sizes.Large => "w-125",
            Sizes.Larger => "w-150",
            Sizes.Largest => "w-200",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }

    /// <summary>
    /// Converts the Sizes enum to its corresponding content CSS class to apply minimum width.
    /// </summary>
    public static string ToContentMinWidthCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "min-w-25",
            Sizes.Smaller => "min-w-50",
            Sizes.Small => "min-w-75",
            Sizes.Medium => "min-w-100",
            Sizes.Large => "min-w-125",
            Sizes.Larger => "min-w-150",
            Sizes.Largest => "min-w-200",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }

    /// <summary>
    /// Converts the Sizes enum to its corresponding content CSS class to apply maximum width.
    /// </summary>
    public static string ToContentMaxWidthCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "max-w-25",
            Sizes.Smaller => "max-w-50",
            Sizes.Small => "max-w-75",
            Sizes.Medium => "max-w-100",
            Sizes.Large => "max-w-125",
            Sizes.Larger => "max-w-150",
            Sizes.Largest => "max-w-200",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }

    /// <summary>
    /// Converts the Sizes enum to its corresponding content CSS class to apply height.
    /// </summary>
    public static string ToContentHeightCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "h-25",
            Sizes.Smaller => "h-50",
            Sizes.Small => "h-75",
            Sizes.Medium => "h-100",
            Sizes.Large => "h-125",
            Sizes.Larger => "h-150",
            Sizes.Largest => "h-200",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }

    /// <summary>
    /// Converts the Sizes enum to its corresponding content CSS class to apply minimum height.
    /// </summary>
    public static string ToContentMinHeightCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "min-h-25",
            Sizes.Smaller => "min-h-50",
            Sizes.Small => "min-h-75",
            Sizes.Medium => "min-h-100",
            Sizes.Large => "min-h-125",
            Sizes.Larger => "min-h-150",
            Sizes.Largest => "min-h-200",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }

    /// <summary>
    /// Converts the Sizes enum to its corresponding content CSS class to apply maximum height.
    /// </summary>
    public static string ToContentMaxHeightCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "max-h-25",
            Sizes.Smaller => "max-h-50",
            Sizes.Small => "max-h-75",
            Sizes.Medium => "max-h-100",
            Sizes.Large => "max-h-125",
            Sizes.Larger => "max-h-150",
            Sizes.Largest => "max-h-200",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }
}