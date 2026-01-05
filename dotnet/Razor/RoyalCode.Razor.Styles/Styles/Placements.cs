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
