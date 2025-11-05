namespace RoyalCode.Razor.Styles;

/// <summary>
/// Sides enum for specifying sides of a box or element.
/// </summary>
public enum Sides
{
    /// <summary>No sides selected.</summary>
    None = 0,
    /// <summary>Top side selected.</summary>
    Top = 1,
    /// <summary>End side selected.</summary>
    End = 2,
    /// <summary>Bottom side selected.</summary>
    Bottom = 4,
    /// <summary>Start side selected.</summary>
    Start = 8,
    /// <summary>Default sides selected.</summary>
    Default = 16,

    /// <summary>All sides selected.</summary>
    All = Top | End | Bottom | Start,

    /// <summary>Top and Start sides selected.</summary>
    NotAtTop = End | Bottom | Start,
    /// <summary>End and Bottom sides selected.</summary>
    NotAtEnd = Top | Bottom | Start,
    /// <summary>Bottom and Start sides selected.</summary>
    NotAtBottom = Top | End | Start,
    /// <summary>Top and End sides selected.</summary>
    NotAtStart = Top | End | Bottom,

    /// <summary>Top and End sides selected.</summary>
    TopEnd = Top | End,
    /// <summary>Top and Bottom sides selected.</summary>
    TopBottom = Top | Bottom,
    /// <summary>Top and Start sides selected.</summary>
    TopStart = Top | Start,
    /// <summary>End and Bottom sides selected.</summary>
    EndBottom = End | Bottom,
    /// <summary>End and Start sides selected.</summary>
    EndStart = End | Start,
    /// <summary>Bottom and Start sides selected.</summary>
    BottomStart = Bottom | Start,
}
