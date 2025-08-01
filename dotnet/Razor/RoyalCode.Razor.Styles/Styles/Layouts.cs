namespace RoyalCode.Razor.Styles;

public enum Layouts
{
    Inline,
    Block,
    InlineBlock,
    FlowRoot,
    Flex,
    InlineFlex,
    Grid,
    InlineGrid,
    Hidden
}

public static class LayoutsExtensions
{
    public static string ToCssClass(this Layouts layout)
    {
        return layout switch
        {
            Layouts.Inline => "inline",
            Layouts.Block => "block",
            Layouts.InlineBlock => "inline-block",
            Layouts.FlowRoot => "flow-root",
            Layouts.Flex => "flex",
            Layouts.InlineFlex => "inline-flex",
            Layouts.Grid => "grid",
            Layouts.InlineGrid => "inline-grid",
            Layouts.Hidden => "hidden",
            _ => throw new NotSupportedException()
        };
    }
}