namespace RoyalCode.Razor.Styles;

public enum LayoutPosition
{
    Default,
    Static,
    Relative,
    Absolute,
    Fixed,
    Sticky
}

public static class LayoutPositionExtensions
{
    public static string ToCssClass(this LayoutPosition layoutPosition)
    {
        return layoutPosition switch
        {
            LayoutPosition.Default => string.Empty,
            LayoutPosition.Static => "static",
            LayoutPosition.Relative => "relative",
            LayoutPosition.Absolute => "absolute",
            LayoutPosition.Fixed => "fixed",
            LayoutPosition.Sticky => "sticky",
            _ => throw new ArgumentOutOfRangeException(nameof(layoutPosition), layoutPosition, null)
        };
    }
}