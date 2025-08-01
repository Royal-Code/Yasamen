namespace RoyalCode.Razor.Styles;

public enum BgClip
{
    Default,
    Border,
    Padding,
    Content,
    Text
}

public static class BackgroundExtensions
{
    public static string ToCssClass(this BgClip clip)
    {
        return clip switch
        {
            BgClip.Default => string.Empty,
            BgClip.Border => "bg-clip-border",
            BgClip.Padding => "bg-clip-padding",
            BgClip.Content => "bg-clip-content",
            BgClip.Text => "bg-clip-text",
            _ => throw new ArgumentOutOfRangeException(nameof(clip), clip, null)
        };
    }
}
