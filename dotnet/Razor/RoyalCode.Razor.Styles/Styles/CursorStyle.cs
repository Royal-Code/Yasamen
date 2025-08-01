namespace RoyalCode.Razor.Styles;

public enum CursorStyle
{
    Auto,
    Default,
    Pointer,
    Wait,
    Text,
    Move,
    Help,
    NotAllowed,
    None,
    ContextMenu,
    Progress,
    Cell,
    Crosshair,
    VerticalText,
    Alias,
    Copy,
    NoDrop,
    Grab,
    Grabbing,
    AllScroll,
    ColResize,
    RowResize,
    NorthResize,
    EastResize,
    SouthResize,
    WestResize,
    NorthEastResize,
    NorthWestResize,
    SouthEastResize,
    SouthWestResize,
    EastWestResize,
    NorthSouthResize,
    NorthEastSouthWestResize,
    NorthWestSouthEastResize,
    ZoomIn,
    ZoomOut
}

public static class CursorStyleExtensions
{
    public static string ToCssClass(this CursorStyle cursor)
    {
        return cursor switch
        {
            CursorStyle.Auto => "cursor-auto",
            CursorStyle.Default => "cursor-default",
            CursorStyle.Pointer => "cursor-pointer",
            CursorStyle.Wait => "cursor-wait",
            CursorStyle.Text => "cursor-text",
            CursorStyle.Move => "cursor-move",
            CursorStyle.Help => "cursor-help",
            CursorStyle.NotAllowed => "cursor-not-allowed",
            CursorStyle.None => "cursor-none",
            CursorStyle.ContextMenu => "cursor-context-menu",
            CursorStyle.Progress => "cursor-progress",
            CursorStyle.Cell => "cursor-cell",
            CursorStyle.Crosshair => "cursor-crosshair",
            CursorStyle.VerticalText => "cursor-vertical-text",
            CursorStyle.Alias => "cursor-alias",
            CursorStyle.Copy => "cursor-copy",
            CursorStyle.NoDrop => "cursor-no-drop",
            CursorStyle.Grab => "cursor-grab",
            CursorStyle.Grabbing => "cursor-grabbing",
            CursorStyle.AllScroll => "cursor-all-scroll",
            CursorStyle.ColResize => "cursor-col-resize",
            CursorStyle.RowResize => "cursor-row-resize",
            CursorStyle.NorthResize => "cursor-n-resize",
            CursorStyle.EastResize => "cursor-e-resize",
            CursorStyle.SouthResize => "cursor-s-resize",
            CursorStyle.WestResize => "cursor-w-resize",
            CursorStyle.NorthEastResize => "cursor-ne-resize",
            CursorStyle.NorthWestResize => "cursor-nw-resize",
            CursorStyle.SouthEastResize => "cursor-se-resize",
            CursorStyle.SouthWestResize => "cursor-sw-resize",
            CursorStyle.EastWestResize => "cursor-ew-resize",
            CursorStyle.NorthSouthResize => "cursor-ns-resize",
            CursorStyle.NorthEastSouthWestResize => "cursor-nesw-resize",
            CursorStyle.NorthWestSouthEastResize => "cursor-nwse-resize",
            CursorStyle.ZoomIn => "cursor-zoom-in",
            CursorStyle.ZoomOut => "cursor-zoom-out",
            _ => throw new ArgumentOutOfRangeException(nameof(cursor), cursor, null)
        };
    }
}
