using RoyalCode.Razor.Styles;
using System;
using System.Drawing;

namespace RoyalCode.Razor.Layouts;

/// <summary>
/// Define the layout sizes.
/// </summary>
public enum LayoutSizes
{
    /// <summary>
    /// Default layout size. All devices.
    /// </summary>
    Default,

    /// <summary>
    /// Phone layout size. 4 columns.
    /// </summary>
    Phone,

    /// <summary>
    /// Tablet layout size. 8 columns.
    /// </summary>
    Tablet,

    /// <summary>
    /// Laptop layout size. 12 columns.
    /// </summary>
    Laptop,

    /// <summary>
    /// Desktop layout size. 16 columns.
    /// </summary>
    Desktop
}

/// <summary>
/// Extension methods for <see cref="LayoutSizes"/>.
/// </summary>
public static class LayoutSizesExtensions
{
    /// <summary>
    /// Defines the CSS class for the grid layout based on the <see cref="LayoutSizes"/>.
    /// </summary>
    /// <param name="size">The layout size.</param>
    /// <returns>A set of CSS classes for the grid layout.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the provided <paramref name="size"/> is not a valid <see cref="LayoutSizes"/> value.
    /// </exception>
    public static string ToGridCssClass(this LayoutSizes size)
    {
        return size switch
        {
            LayoutSizes.Default | LayoutSizes.Desktop
                => "grid xs:grid-cols-1 gap-8 items-start grid-cols-4 md:grid-cols-8 lg:grid-cols-12 2xl:grid-cols-16",
            LayoutSizes.Laptop
                => "grid xs:grid-cols-1 gap-8 items-start sm:grid-cols-4 md:grid-cols-8 lg:grid-cols-12",
            LayoutSizes.Tablet
                => "grid xs:grid-cols-1 gap-8 items-start sm:grid-cols-4 md:grid-cols-8",
            LayoutSizes.Phone
                => "grid xs:grid-cols-1 gap-8 items-start sm:grid-cols-4",
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, "Invalid layout size")
        };
    }

    public static string ToFlexColClass(this LayoutSizes size, int span, int tabletSpan, int laptopSpan, int desktopSpan)
    {
        return size switch
        {
            LayoutSizes.Phone => ToFlexPhoneColClass(span),
            LayoutSizes.Tablet => ToFlexTabletColClass(span, tabletSpan),
            LayoutSizes.Laptop => ToFlexLaptopColClass(span, laptopSpan),
            LayoutSizes.Desktop => ToFlexDesktopColClass(span, desktopSpan),
            _ => ToFlexDesktopColClass(span, desktopSpan, false)
        };
    }

    private static string ToFlexPhoneColClass(int span)
    {
        return span switch
        {
            1 => "w-1/4",
            2 => "w-2/4",
            3 => "w-3/4",
            _ => "w-full"
        };
    }

    private static string ToFlexTabletColClass(int span, int tabletSpan)
    {
        span = tabletSpan > 0 ? tabletSpan : span;
        return span switch
        {
            1 => "w-1/4 md:w-1/8",
            2 => "w-2/4 md:w-2/8",
            3 => "w-3/4 md:w-3/8",
            4 => "w-full md:w-4/8",
            5 => "w-full md:w-5/8",
            6 => "w-full md:w-6/8",
            7 => "w-full md:w-7/8",
            _ => "w-full"
        };
    }

    private static string ToFlexLaptopColClass(int span, int laptopSpan)
    {
        span = laptopSpan > 0 ? laptopSpan : span;
        return span switch
        {
            1 => "w-1/4 md:w-1/8 lg:w-1/12",
            2 => "w-2/4 md:w-2/8 lg:w-2/12",
            3 => "w-3/4 md:w-3/8 lg:w-3/12",
            4 => "w-full md:w-4/8 lg:w-4/12",
            5 => "w-full md:w-5/8 lg:w-5/12",
            6 => "w-full md:w-6/8 lg:w-6/12",
            7 => "w-full md:w-7/8 lg:w-7/12",
            8 => "w-full lg:w-8/12",
            9 => "w-full lg:w-9/12",
            10 => "w-full lg:w-10/12",
            11 => "w-full lg:w-11/12",
            _ => "w-full"
        };
    }

    private static string ToFlexDesktopColClass(int span, int desktopSpan, bool desktop = true)
    {
        span = desktop && desktopSpan > 0 ? desktopSpan : span;
        return span switch
        {
            1 => "w-1/4 md:w-1/8 lg:w-1/12 2xl:w-1/16",
            2 => "w-2/4 md:w-2/8 lg:w-2/12 2xl:w-2/16",
            3 => "w-3/4 md:w-3/8 lg:w-3/12 2xl:w-3/16",
            4 => "w-full md:w-4/8 lg:w-4/12 2xl:w-4/16",
            5 => "w-full md:w-5/8 lg:w-5/12 2xl:w-5/16",
            6 => "w-full md:w-6/8 lg:w-6/12 2xl:w-6/16",
            7 => "w-full md:w-7/8 lg:w-7/12 2xl:w-7/16",
            8 => "w-full lg:w-8/12 2xl:w-8/16",
            9 => "w-full lg:w-9/12 2xl:w-9/16",
            10 => "w-full lg:w-10/12 2xl:w-10/16",
            11 => "w-full lg:w-11/12 2xl:w-11/16",
            12 => "w-full 2xl:w-12/16",
            13 => "w-full 2xl:w-13/16",
            14 => "w-full 2xl:w-14/16",
            15 => "w-full 2xl:w-15/16",
            _ => "w-full"
        };
    }

    public static CssClasses AddGridColClass(this CssClasses classes, bool condition, LayoutSizes size, int span, int tabletSpan, int laptopSpan, int desktopSpan)
    {
        return condition ? classes
            .AddClass(span > 0 && span <= 16 ? GridSpanMap.Default[span] : null)
            .AddClass(tabletSpan > 0 && tabletSpan <= 8 ? GridSpanMap.Tablet[tabletSpan] : null)
            .AddClass(laptopSpan > 0 && laptopSpan <= 12 ? GridSpanMap.Laptop[laptopSpan] : null)
            .AddClass(desktopSpan > 0 && desktopSpan <= 16 ? GridSpanMap.Desktop[desktopSpan] : null) : classes;
    }

    public static class GridSpanMap
    {
        public static Dictionary<int, string> Default { get; } = new Dictionary<int, string>
        {
            {1, "sm:col-span-1"},
            {2, "sm:col-span-2"},
            {3, "sm:col-span-3"},
            {4, "sm:col-span-4"},
            {5, "sm:col-span-5"},
            {6, "sm:col-span-6"},
            {7, "sm:col-span-7"},
            {8, "sm:col-span-8"},
            {9, "sm:col-span-9"},
            {10, "sm:col-span-10"},
            {11, "sm:col-span-11"},
            {12, "sm:col-span-12"},
            {13, "sm:col-span-13"},
            {14, "sm:col-span-14"},
            {15, "sm:col-span-15"},
            {16, "sm:col-span-16"}
        };

        public static Dictionary<int, string> Tablet { get; } = new Dictionary<int, string>
        {
            {1, "md:col-span-1"},
            {2, "md:col-span-2"},
            {3, "md:col-span-3"},
            {4, "md:col-span-4"},
            {5, "md:col-span-5"},
            {6, "md:col-span-6"},
            {7, "md:col-span-7"},
            {8, "md:col-span-8"},
        };

        public static Dictionary<int, string> Laptop { get; } = new Dictionary<int, string>
        {
            {1, "lg:col-span-1"},
            {2, "lg:col-span-2"},
            {3, "lg:col-span-3"},
            {4, "lg:col-span-4"},
            {5, "lg:col-span-5"},
            {6, "lg:col-span-6"},
            {7, "lg:col-span-7"},
            {8, "lg:col-span-8"},
            {9, "lg:col-span-9"},
            {10, "lg:col-span-10"},
            {11, "lg:col-span-11"},
            {12, "lg:col-span-12"},
        };

        public static Dictionary<int, string> Desktop { get; } = new Dictionary<int, string>
        {
            {1, "2xl:col-span-1"},
            {2, "2xl:col-span-2"},
            {3, "2xl:col-span-3"},
            {4, "2xl:col-span-4"},
            {5, "2xl:col-span-5"},
            {6, "2xl:col-span-6"},
            {7, "2xl:col-span-7"},
            {8, "2xl:col-span-8"},
            {9, "2xl:col-span-9"},
            {10, "2xl:col-span-10"},
            {11, "2xl:col-span-11"},
            {12, "2xl:col-span-12"},
            {13, "2xl:col-span-13"},
            {14, "2xl:col-span-14"},
            {15, "2xl:col-span-15"},
            {16, "2xl:col-span-16"}
        };
    }
}