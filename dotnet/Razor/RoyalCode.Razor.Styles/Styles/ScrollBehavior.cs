namespace RoyalCode.Razor.Styles;

public enum ScrollBehavior
{
    Auto,
    Smooth
}

public static class ScrollBehaviorExtensions
{
    public static string ToCssClass(this ScrollBehavior scrollBehavior)
    {
        return scrollBehavior switch
        {
            ScrollBehavior.Auto => "scroll-auto",
            ScrollBehavior.Smooth => "scroll-smooth",
            _ => throw new ArgumentOutOfRangeException(nameof(scrollBehavior), scrollBehavior, null)
        };
    }
}
