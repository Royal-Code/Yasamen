
namespace RoyalCode.Razor.Commons.Styles;

[Flags]
public enum BorderRound
{
    None = 0,
    Top = 1,
    End = 2,
    Bottom = 4,
    Start = 8,
    Circle = 16,
    Pill = 32,
    Ellipse = 64,

    Default = 15,

    TopStart = Top | Start,
    TopEnd = Top | End,
    BottomStart = Bottom | Start,
    BottomEnd = Bottom | End
}
