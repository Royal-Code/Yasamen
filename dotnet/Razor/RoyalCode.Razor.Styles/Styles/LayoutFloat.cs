namespace RoyalCode.Razor.Styles;

public enum LayoutFloat
{
    Default,
    Left,
    Right,
    Start,
    End,
    None
}

public static class LayoutFloatExtensions
{
    public static string ToCssClass(this LayoutFloat layoutFloat)
    {
        return layoutFloat switch
        {
            LayoutFloat.Default => string.Empty,
            LayoutFloat.Left => "float-left",
            LayoutFloat.Right => "float-right",
            LayoutFloat.Start => "float-start",
            LayoutFloat.End => "float-end",
            LayoutFloat.None => "float-none",
            _ => throw new ArgumentOutOfRangeException(nameof(layoutFloat), layoutFloat, null)
        };
    }
}
