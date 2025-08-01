namespace RoyalCode.Razor.Styles;

public enum ScrollSnapType
{
    Default,
    None,
    X,
    Y,
    Both,
    Mandatory,
    Proximity
}

public enum ScrollSnapStop
{
    Default,
    Normal,
    Always
}

public enum ScrollSnapAlign
{
    Default,
    Start,
    End,
    Center,
    None
}

public static class ScrollSnapExtensions
{
    public static string ToCssClass(this ScrollSnapType scrollSnapType)
    {
        return scrollSnapType switch
        {
            ScrollSnapType.Default => string.Empty,
            ScrollSnapType.None => "snap-none",
            ScrollSnapType.X => "snap-x",
            ScrollSnapType.Y => "snap-y",
            ScrollSnapType.Both => "snap-both",
            ScrollSnapType.Mandatory => "snap-mandatory",
            ScrollSnapType.Proximity => "snap-proximity",
            _ => throw new ArgumentOutOfRangeException(nameof(scrollSnapType), scrollSnapType, null)
        };
    }

    public static string ToCssClass(this ScrollSnapStop scrollSnapStop)
    {
        return scrollSnapStop switch
        {
            ScrollSnapStop.Default => string.Empty,
            ScrollSnapStop.Normal => "snap-normal",
            ScrollSnapStop.Always => "snap-always",
            _ => throw new ArgumentOutOfRangeException(nameof(scrollSnapStop), scrollSnapStop, null)
        };
    }

    public static string ToCssClass(this ScrollSnapAlign scrollSnapAlign)
    {
        return scrollSnapAlign switch
        {
            ScrollSnapAlign.Default => string.Empty,
            ScrollSnapAlign.Start => "snap-start",
            ScrollSnapAlign.End => "snap-end",
            ScrollSnapAlign.Center => "snap-center",
            ScrollSnapAlign.None => "snap-align-none",
            _ => throw new ArgumentOutOfRangeException(nameof(scrollSnapAlign), scrollSnapAlign, null)
        };
    }
}