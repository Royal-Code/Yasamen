namespace RoyalCode.Razor.Styles;

public enum ContentClear
{
    Default,
    Left,
    Right,
    Both,
    Start,
    End,
    None
}

public static class ContentClearExtensions
{
    public static string ToCssClass(this ContentClear contentClear)
    {
        return contentClear switch
        {
            ContentClear.Default => string.Empty,
            ContentClear.Left => "clear-left",
            ContentClear.Right => "clear-right",
            ContentClear.Both => "clear-both",
            ContentClear.Start => "clear-start",
            ContentClear.End => "clear-end",
            ContentClear.None => "clear-none",
            _ => throw new ArgumentOutOfRangeException(nameof(contentClear), contentClear, null)
        };
    }
}
