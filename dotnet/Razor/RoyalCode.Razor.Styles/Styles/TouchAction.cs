namespace RoyalCode.Razor.Styles;

public enum TouchAction
{
    Default,
    Auto,
    None,
    PanX,
    PanY,
    PanLeft,
    PanRight,
    PanUp,
    PanDown,
    PinchZoom,
    Manipulation
}

public static class TouchActionExtensions
{
    public static string ToCssClass(this TouchAction touchAction)
    {
        return touchAction switch
        {
            TouchAction.Default => string.Empty,
            TouchAction.Auto => "touch-auto",
            TouchAction.None => "touch-none",
            TouchAction.PanX => "touch-pan-x",
            TouchAction.PanY => "touch-pan-y",
            TouchAction.PanLeft => "touch-pan-left",
            TouchAction.PanRight => "touch-pan-right",
            TouchAction.PanUp => "touch-pan-up",
            TouchAction.PanDown => "touch-pan-down",
            TouchAction.PinchZoom => "touch-pinch-zoom",
            TouchAction.Manipulation => "touch-manipulation",
            _ => throw new ArgumentOutOfRangeException(nameof(touchAction), touchAction, null)
        };
    }
}