namespace RoyalCode.Razor.Styles;

public enum Overflow
{
    Default,
    Auto,
    Hidden,
    Clip,
    Visible,
    Scroll,
    AutoX,
    AutoY,
    HiddenX,
    HiddenY,
    ClipX,
    ClipY,
    VisibleX,
    VisibleY,
    ScrollX,
    ScrollY
}

public static class OverflowExtensions
{
    public static string ToCssClass(this Overflow overflow)
    {
        return overflow switch
        {
            Overflow.Default => string.Empty,
            Overflow.Auto => "overflow-auto",
            Overflow.Hidden => "overflow-hidden",
            Overflow.Clip => "overflow-clip",
            Overflow.Visible => "overflow-visible",
            Overflow.Scroll => "overflow-scroll",
            Overflow.AutoX => "overflow-x-auto",
            Overflow.AutoY => "overflow-y-auto",
            Overflow.HiddenX => "overflow-x-hidden",
            Overflow.HiddenY => "overflow-y-hidden",
            Overflow.ClipX => "overflow-x-clip",
            Overflow.ClipY => "overflow-y-clip",
            Overflow.VisibleX => "overflow-x-visible",
            Overflow.VisibleY => "overflow-y-visible",
            Overflow.ScrollX => "overflow-x-scroll",
            Overflow.ScrollY => "overflow-y-scroll",
            _ => throw new ArgumentOutOfRangeException(nameof(overflow), overflow, null)
        };
    }
}
