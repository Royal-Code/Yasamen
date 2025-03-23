
namespace RoyalCode.Yasamen.Commons;

[Flags]
public enum BorderPositions
{
    None = 0,
    Top = 1,
    End = 2,
    Bottom = 4,
    Start = 8,

    Default = Top | End | Bottom | Start,

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
