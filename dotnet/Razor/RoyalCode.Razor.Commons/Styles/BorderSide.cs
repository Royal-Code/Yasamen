
namespace RoyalCode.Razor.Commons.Styles;

[Flags]
public enum BorderSide
{
    None = 0,
    Top = 1,
    End = 2,
    Bottom = 4,
    Start = 8,
    Default = 16,

    All = Top | End | Bottom | Start,

    NotAtTop = End | Bottom | Start,
    NotAtEnd = Top | Bottom | Start,
    NotAtBottom = Top | End | Start,
    NotAtStart = Top | End | Bottom,

    TopEnd = Top | End,
    TopBottom = Top | Bottom,
    TopStart = Top | Start,
    EndBottom = End | Bottom,
    EndStart = End | Start,
    BottomStart = Bottom | Start,
}
