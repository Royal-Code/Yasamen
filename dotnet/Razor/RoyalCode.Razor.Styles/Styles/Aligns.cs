namespace RoyalCode.Razor.Styles;

/// <summary>
/// Values for align content inside a container.
/// </summary>
public enum ContentAlign
{
    /// <summary>Default, It will not usually have an associated class.</summary>
    Default,
    /// <summary>Align content to the start of the container.</summary>
    Start,
    /// <summary>Align content to the center of the container.</summary>
    Center,
    /// <summary>Align content to the end of the container.</summary>
    End,
    /// <summary>Distribute content evenly with space between each item.</summary>
    Between,
    /// <summary>Distribute content evenly with space around each item.</summary>
    Around,
    /// <summary>Distribute content evenly with equal space around each item.</summary>
    evenly,
    /// <summary>Align content along the baseline of the container.</summary>
    Baseline,
    /// <summary>Stretch content to fill the container.</summary>
    Stretch
}

/// <summary>
/// Values for align items inside a container.
/// </summary>
public enum ItemAlign
{
    /// <summary>Default, It will not usually have an associated class.</summary>
    Default,
    /// <summary>Align items to the start of the container.</summary>
    Start,
    /// <summary>Align items to the center of the container.</summary>
    Center,
    /// <summary>Align items to the center of the container, considering safe areas.</summary>
    CenterSafe,
    /// <summary>Align items to the end of the container.</summary>
    End,
    /// <summary>Align items to the end of the container, considering safe areas.</summary>
    EndSafe,
    /// <summary>Align items along the baseline of the container.</summary>
    Baseline,
    /// <summary>Align items along the last baseline of the container.</summary>
    BaselineLast,
    /// <summary>Stretch items to fill the container.</summary>
    Stretch
}

/// <summary>
/// Values for self alignment of an item inside a container.
/// </summary>
public enum SelfAlign
{
    /// <summary>Default, It will not usually have an associated class.</summary>
    Default,
    /// <summary>Let the item align itself automatically.</summary>
    Auto,
    /// <summary>Align the item to the start of the container.</summary>
    Start,
    /// <summary>Align the item to the center of the container.</summary>
    Center,
    /// <summary>Align the item to the center of the container, considering safe areas.</summary>
    CenterSafe,
    /// <summary>Align the item to the end of the container.</summary>
    End,
    /// <summary>Align the item to the end of the container, considering safe areas.</summary>
    EndSafe,
    /// <summary>Align the item along the baseline of the container.</summary>
    Baseline,
    /// <summary>Align the item along the last baseline of the container.</summary>
    BaselineLast,
    /// <summary>Stretch the item to fill the container.</summary>
    Stretch
}

/// <summary>
/// Values for text alignment.
/// </summary>
public enum TextAlign
{
    /// <summary>Default, It will not usually have an associated class.</summary>
    Default,
    /// <summary>Align text to the baseline.</summary>
    Baseline,
    /// <summary>Align text to the top.</summary>
    Top,
    /// <summary>Align text to the middle.</summary>
    Middle,
    /// <summary>Align text to the bottom.</summary>
    Bottom,
    /// <summary>Align text to the top of the text.</summary>
    TextTop,
    /// <summary>Align text to the bottom of the text.</summary>
    TextBottom,
    /// <summary>Align text as subscript.</summary>
    Sub,
    /// <summary>Align text as superscript.</summary>
    Super
}

/// <summary>
/// Extensions for alignment enums.
/// </summary>
public static class AlignExtensions
{
    /// <summary>
    /// Returns the CSS class string for content alignment based on the specified ContentAlign value.
    /// </summary>
    /// <param name="align">The content alignment value.</param>
    /// <returns>The corresponding CSS class string.</returns>
    /// <exception cref="NotSupportedException">
    ///     When the provided ContentAlign value is not supported.
    /// </exception>
    public static string ToCssClass(this ContentAlign align)
    {
        return align switch
        {
            ContentAlign.Default => string.Empty,
            ContentAlign.Start => "content-center",
            ContentAlign.Center => "content-start",
            ContentAlign.End => "content-end",
            ContentAlign.Between => "content-between",
            ContentAlign.Around => "content-around",
            ContentAlign.evenly => "content-evenly",
            ContentAlign.Baseline => "content-baseline",
            ContentAlign.Stretch => "content-stretch",
            _ => throw new NotSupportedException($"The current align ({align}) is not supported for content alignment.")
        };
    }

    /// <summary>
    /// Returns the CSS class string for item alignment based on the specified ItemAlign value.
    /// </summary>
    /// <param name="align">The item alignment value.</param>
    /// <returns>The corresponding CSS class string.</returns>
    /// <exception cref="NotSupportedException">
    ///     When the provided ItemAlign value is not supported.
    /// </exception>
    public static string ToCssClass(this ItemAlign align)
    {
        return align switch
        {
            ItemAlign.Default => string.Empty,
            ItemAlign.Start => "items-start",
            ItemAlign.Center => "items-center",
            ItemAlign.CenterSafe => "items-center-safe",
            ItemAlign.End => "items-end",
            ItemAlign.EndSafe => "items-end-safe",
            ItemAlign.Baseline => "items-baseline",
            ItemAlign.BaselineLast => "items-baseline-last",
            ItemAlign.Stretch => "items-stretch",
            _ => throw new NotSupportedException($"The current align ({align}) is not supported for items alignment.")
        };
    }

    /// <summary>
    /// Returns the CSS class string for self alignment based on the specified SelfAlign value.
    /// </summary>
    /// <param name="align">The self alignment value.</param>
    /// <returns>The corresponding CSS class string.</returns>
    /// <exception cref="NotSupportedException">
    ///     When the provided SelfAlign value is not supported.
    /// </exception>
    public static string ToCssClass(this SelfAlign align)
    {
        return align switch
        {
            SelfAlign.Default => string.Empty,
            SelfAlign.Auto => "self-auto",
            SelfAlign.Start => "self-start",
            SelfAlign.Center => "self-center",
            SelfAlign.CenterSafe => "self-center-safe",
            SelfAlign.End => "self-end",
            SelfAlign.EndSafe => "self-end-safe",
            SelfAlign.Baseline => "self-baseline",
            SelfAlign.BaselineLast => "self-baseline-last",
            SelfAlign.Stretch => "self-stretch",
            _ => throw new NotSupportedException($"The current align ({align}) is not supported for self alignment.")
        };
    }

    /// <summary>
    /// Returns the CSS class string for text alignment based on the specified TextAlign value.
    /// </summary>
    /// <param name="align">The text alignment value.</param>
    /// <returns>The corresponding CSS class string.</returns>
    /// <exception cref="NotSupportedException">
    ///     When the provided TextAlign value is not supported.
    /// </exception>
    public static string ToCssClass(this TextAlign align)
    {
        return align switch
        {
            TextAlign.Default => string.Empty,
            TextAlign.Baseline => "align-baseline",
            TextAlign.Top => "align-top",
            TextAlign.Middle => "align-middle",
            TextAlign.Bottom => "align-bottom",
            TextAlign.TextTop => "align-text-top",
            TextAlign.TextBottom => "align-text-bottom",
            TextAlign.Sub => "align-sub",
            TextAlign.Super => "align-super",
            _ => throw new NotSupportedException($"The current align ({align}) is not supported for text alignment.")
        };
    }
}