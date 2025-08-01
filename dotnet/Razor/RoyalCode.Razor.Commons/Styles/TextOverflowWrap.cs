namespace RoyalCode.Razor.Commons.Styles;

public enum TextOverflowWrap
{
    Default,
    BreakWord,
    Anywhere,
    Normal
}

public static class OverflowWrapExtensions
{
    public static string ToCssClass(this TextOverflowWrap overflowWrap)
    {
        return overflowWrap switch
        {
            TextOverflowWrap.Default => string.Empty,
            TextOverflowWrap.BreakWord => "wrap-break-word",
            TextOverflowWrap.Anywhere => "wrap-anywhere",
            TextOverflowWrap.Normal => "wrap-normal",
            _ => throw new ArgumentOutOfRangeException(nameof(overflowWrap), overflowWrap, null)
        };
    }
}
