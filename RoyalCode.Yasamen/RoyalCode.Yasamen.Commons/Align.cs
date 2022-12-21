
namespace RoyalCode.Yasamen.Commons;

/// <summary>
/// Values for align itens inside a container.
/// </summary>
public enum Align
{
    Default,
    Start,
    Center,
    End,
}

public static class AlignExtensions
{
    public static string ToItemsCssClass(this Align align)
    {
        return align switch
        {
            Align.Default => string.Empty,
            Align.Start => "align-items-start",
            Align.Center => "align-items-center",
            Align.End => "align-items-end",
            _ => throw new NotSupportedException()
        };
    }

    public static string ToSelfCssClass(this Align align)
    {
        return align switch
        {
            Align.Default => string.Empty,
            Align.Start => "align-self-start",
            Align.Center => "align-self-center",
            Align.End => "align-self-end",
            _ => throw new NotSupportedException()
        };
    }

    public static string ToTextCssClass(this Align align)
    {
        return align switch
        {
            Align.Default => string.Empty,
            Align.Start => "text-start",
            Align.Center => "text-center",
            Align.End => "text-end",
            _ => throw new NotSupportedException()
        };
    }
}