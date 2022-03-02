
namespace RoyalCode.Yasamen.Commons;

public enum Justify
{
    Default,
    Start,
    Center,
    End,
    Between,
    Around,
    Evenly
}

public static class JustifyExtensions
{
    public static string ToContentCssClass(this Justify align)
    {
        return align switch
        {
            Justify.Default => string.Empty,
            Justify.Start => "justify-content-start",
            Justify.Center => "justify-content-center",
            Justify.End => "justify-content-end",
            Justify.Between => "justify-content-between",
            Justify.Around => "justify-content-around",
            Justify.Evenly => "justify-content-evenly",
            _ => throw new NotSupportedException()
        };
    }
}