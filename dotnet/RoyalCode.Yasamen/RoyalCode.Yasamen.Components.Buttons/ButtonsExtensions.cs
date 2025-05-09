
using RoyalCode.Yasamen.Commons;

namespace RoyalCode.Yasamen.Components;

internal static class ButtonsExtensions
{
    public static string ToButtonCssClass(this Sizes size)
    {
        return size switch
        {
            Sizes.Default => string.Empty,
            Sizes.Smallest => "btn-xs",
            Sizes.Small => "btn-sm",
            Sizes.Medium => string.Empty,
            Sizes.Large => "btn-lg",
            Sizes.Largest => "btn-xl",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null),
        };
    }
}
