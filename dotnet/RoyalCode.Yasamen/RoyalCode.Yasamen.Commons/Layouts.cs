namespace RoyalCode.Yasamen.Commons;

public enum Layouts
{
    Flex,
    Grid,
    Block,
    Inline,
    InlineFlex,
    InlineGrid,
    InlineBlock,
}

public static class LayoutsExtensions
{
    public static string ToCssClass(this Layouts layout)
    {
        return layout switch
        {
            Layouts.Flex => "flex",
            Layouts.Grid => "grid",
            Layouts.Block => "block",
            Layouts.Inline => "inline",
            Layouts.InlineFlex => "inline-flex",
            Layouts.InlineGrid => "inline-grid",
            Layouts.InlineBlock => "inline-block",
            _ => throw new NotSupportedException()
        };
    }
}