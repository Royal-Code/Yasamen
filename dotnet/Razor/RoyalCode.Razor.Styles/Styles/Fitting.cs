namespace RoyalCode.Razor.Styles;

/// <summary>
/// Fitting of some component, for example a side menu. 
/// The docker can either overlay the top menu or embed it in the page.
/// </summary>
public enum Fitting
{
    /// <summary>
    /// The component will go over the top menu.
    /// </summary>
    Overlaying,

    /// <summary>
    /// The component will incorporate itself into the content by being below the top menu.
    /// </summary>
    Incorporated,

    /// <summary>
    /// The component will be floating in the page, below the top menu and above the footer.
    /// </summary>
    Float,
}

public static class FittingExtensions
{
    public static string ToFitTopSpacing(this SpacingSize size)
    {
        return size switch
        {
            SpacingSize.None => "fit-top-0",
            SpacingSize.One => "fit-top-1",
            SpacingSize.Two => "fit-top-2",
            SpacingSize.SmallerX2 => "fit-top-3",
            SpacingSize.Smaller => "fit-top-4",
            SpacingSize.Small => "fit-top-5",
            SpacingSize.Medium => "fit-top-6",
            SpacingSize.Large => "fit-top-7",
            SpacingSize.Larger => "fit-top-8",
            SpacingSize.LargerX2 => "fit-top-9",
            SpacingSize.LargerX3 => "fit-top-10",
            SpacingSize.LargerX4 => "fit-top-11",
            SpacingSize.LargerX5 => "fit-top-12",
            SpacingSize.LargerX6 => "fit-top-13",
            SpacingSize.LargerX7 => "fit-top-14",
            SpacingSize.LargerX8 => "fit-top-15",
            SpacingSize.Largest => "fit-top-16",
            SpacingSize.Initial => "fit-top-initial",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }

    public static string ToFitBottomSpacing(this SpacingSize size)
    {
        return size switch
        {
            SpacingSize.None => "fit-bottom-0",
            SpacingSize.One => "fit-bottom-1",
            SpacingSize.Two => "fit-bottom-2",
            SpacingSize.SmallerX2 => "fit-bottom-3",
            SpacingSize.Smaller => "fit-bottom-4",
            SpacingSize.Small => "fit-bottom-5",
            SpacingSize.Medium => "fit-bottom-6",
            SpacingSize.Large => "fit-bottom-7",
            SpacingSize.Larger => "fit-bottom-8",
            SpacingSize.LargerX2 => "fit-bottom-9",
            SpacingSize.LargerX3 => "fit-bottom-10",
            SpacingSize.LargerX4 => "fit-bottom-11",
            SpacingSize.LargerX5 => "fit-bottom-12",
            SpacingSize.LargerX6 => "fit-bottom-13",
            SpacingSize.LargerX7 => "fit-bottom-14",
            SpacingSize.LargerX8 => "fit-bottom-15",
            SpacingSize.Largest => "fit-bottom-16",
            SpacingSize.Initial => "fit-bottom-initial",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }

    public static string ToFitLeftSpacing(this SpacingSize size)
    {
        return size switch
        {
            SpacingSize.None => "fit-left-0",
            SpacingSize.One => "fit-left-1",
            SpacingSize.Two => "fit-left-2",
            SpacingSize.SmallerX2 => "fit-left-3",
            SpacingSize.Smaller => "fit-left-4",
            SpacingSize.Small => "fit-left-5",
            SpacingSize.Medium => "fit-left-6",
            SpacingSize.Large => "fit-left-7",
            SpacingSize.Larger => "fit-left-8",
            SpacingSize.LargerX2 => "fit-left-9",
            SpacingSize.LargerX3 => "fit-left-10",
            SpacingSize.LargerX4 => "fit-left-11",
            SpacingSize.LargerX5 => "fit-left-12",
            SpacingSize.LargerX6 => "fit-left-13",
            SpacingSize.LargerX7 => "fit-left-14",
            SpacingSize.LargerX8 => "fit-left-15",
            SpacingSize.Largest => "fit-left-16",
            SpacingSize.Initial => "fit-left-initial",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }

    public static string ToFitRightSpacing(this SpacingSize size)
    {
        return size switch
        {
            SpacingSize.None => "fit-right-0",
            SpacingSize.One => "fit-right-1",
            SpacingSize.Two => "fit-right-2",
            SpacingSize.SmallerX2 => "fit-right-3",
            SpacingSize.Smaller => "fit-right-4",
            SpacingSize.Small => "fit-right-5",
            SpacingSize.Medium => "fit-right-6",
            SpacingSize.Large => "fit-right-7",
            SpacingSize.Larger => "fit-right-8",
            SpacingSize.LargerX2 => "fit-right-9",
            SpacingSize.LargerX3 => "fit-right-10",
            SpacingSize.LargerX4 => "fit-right-11",
            SpacingSize.LargerX5 => "fit-right-12",
            SpacingSize.LargerX6 => "fit-right-13",
            SpacingSize.LargerX7 => "fit-right-14",
            SpacingSize.LargerX8 => "fit-right-15",
            SpacingSize.Largest => "fit-right-16",
            SpacingSize.Initial => "fit-right-initial",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }
}