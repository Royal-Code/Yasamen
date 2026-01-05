namespace RoyalCode.Razor.Styles;

/// <summary>
/// Defines the available placement options for UI elements.
/// </summary>
/// <remarks>
/// Use these values to position overlays, tooltips, popovers, or other UI elements
/// relative to a reference element or container.
/// </remarks>
public enum Placements
{
    /// <summary>
    /// Place the element at the top position.
    /// </summary>
    Top,

    /// <summary>
    /// Place the element at the bottom position.
    /// </summary>
    Bottom,

    /// <summary>
    /// Place the element centered within the available space.
    /// </summary>
    Center,

    /// <summary>
    /// Place the element at the left position.
    /// </summary>
    Left,

    /// <summary>
    /// Place the element at the right position.
    /// </summary>
    Right,

    /// <summary>
    /// Place the element at the top position aligned to the start (e.g., left in LTR).
    /// </summary>
    TopStart,

    /// <summary>
    /// Place the element at the top position aligned to the end (e.g., right in LTR).
    /// </summary>
    TopEnd,

    /// <summary>
    /// Place the element at the bottom position aligned to the start (e.g., left in LTR).
    /// </summary>
    BottomStart,

    /// <summary>
    /// Place the element at the bottom position aligned to the end (e.g., right in LTR).
    /// </summary>
    BottomEnd,

    /// <summary>
    /// Place the element at the left position aligned to the start (e.g., top).
    /// </summary>
    LeftStart,

    /// <summary>
    /// Place the element at the left position aligned to the end (e.g., bottom).
    /// </summary>
    LeftEnd,

    /// <summary>
    /// Place the element at the right position aligned to the start (e.g., top).
    /// </summary>
    RightStart,

    /// <summary>
    /// Place the element at the right position aligned to the end (e.g., bottom).
    /// </summary>
    RightEnd,
}

/// <summary>
/// Extension methods for the <see cref="Placements"/> enum.
/// </summary>
public static class PlacementsExtensions
{
    /// <summary>
    /// Converts the placement enum value to its corresponding CSS class name.
    /// </summary>
    /// <param name="placement">The placement enum value.</param>
    /// <returns>The corresponding CSS class name.</returns>
    public static string ToCssClass(this Placements placement, string prefix = "placement") => placement switch
    {
        Placements.Top => $"{prefix}-top",
        Placements.Bottom => $"{prefix}-bottom",
        Placements.Center => $"{prefix}-center",
        Placements.Left => $"{prefix}-left",
        Placements.Right => $"{prefix}-right",
        Placements.TopStart => $"{prefix}-top-start",
        Placements.TopEnd => $"{prefix}-top-end",
        Placements.BottomStart => $"{prefix}-bottom-start",
        Placements.BottomEnd => $"{prefix}-bottom-end",
        Placements.LeftStart => $"{prefix}-left-start",
        Placements.LeftEnd => $"{prefix}-left-end",
        Placements.RightStart => $"{prefix}-right-start",
        Placements.RightEnd => $"{prefix}-right-end",
        _ => string.Empty,
    };

    /// <summary>
    /// Check if the placement is a bottom placement.
    /// </summary>
    /// <param name="placement"></param>
    /// <returns></returns>
    public static bool IsBottom(this Placements placement)
    {
        return placement == Placements.Bottom || placement == Placements.BottomStart || placement == Placements.BottomEnd;
    }
}