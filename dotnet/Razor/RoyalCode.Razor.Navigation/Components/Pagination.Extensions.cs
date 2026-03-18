using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

public static class PaginationExtensions
{
    public static string ToPaginationSize(this Sizes size)
    {
        if (size == Sizes.Default)
            size = Sizes.Small;

        return size.ToCssClassName("ya-pagination");
    }
}