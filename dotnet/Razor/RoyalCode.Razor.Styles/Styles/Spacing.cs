namespace RoyalCode.Razor.Styles;

public enum SpacingSize
{
    None,
    One,      // 1
    Two,      // 2
    SmallerX2, // 4
    Smaller,  // 8
    Small,    // 12
    Medium,   // 16
    Large,    // 24
    Larger,   // 32
    LargerX2, // 48
    LargerX3, // 64
    LargerX4, // 80
    LargerX5, // 96
    LargerX6, // 128
    LargerX7, // 196
    LargerX8, // 256
    Largest,  // 512
    Initial
}

public enum SpacingFraction
{
    None,
    One,      // 1/12
    Two,      // 2/12
    Three,    // 3/12
    Four,     // 4/12
    Five,     // 5/12
    Six,      // 6/12
    Seven,    // 7/12
    Eight,    // 8/12
    Nine,     // 9/12
    Ten,      // 10/12
    Eleven,   // 11/12
    Full,     // 12/12
}

[Flags]
public enum SpacingSide
{
    None,
    Top = 1,
    Right = 2,
    Bottom = 4,
    Left = 8,
    Horizontal = Left | Right,
    Vertical = Top | Bottom,
    All = Horizontal | Vertical
}

public static class SpacingMap
{
    public static string GetPaddingCssClass(SpacingSide side, SpacingSize size)
    {
        if (side == SpacingSide.None)
            return string.Empty;

        return side switch
        {
            SpacingSide.Top => size switch
            {
                SpacingSize.None => "pt-0",
                SpacingSize.One => "pt-1",
                SpacingSize.Two => "pt-2",
                SpacingSize.SmallerX2 => "pt-3",
                SpacingSize.Smaller => "pt-4",
                SpacingSize.Small => "pt-5",
                SpacingSize.Medium => "pt-6",
                SpacingSize.Large => "pt-7",
                SpacingSize.Larger => "pt-8",
                SpacingSize.LargerX2 => "pt-9",
                SpacingSize.LargerX3 => "pt-10",
                SpacingSize.LargerX4 => "pt-11",
                SpacingSize.LargerX5 => "pt-12",
                SpacingSize.LargerX6 => "pt-13",
                SpacingSize.LargerX7 => "pt-14",
                SpacingSize.LargerX8 => "pt-15",
                SpacingSize.Largest => "pt-16",
                SpacingSize.Initial => "pt-initial",
            },
            SpacingSide.Right => size switch
            {
                SpacingSize.None => "pr-0",
                SpacingSize.One => "pr-1",
                SpacingSize.Two => "pr-2",
                SpacingSize.SmallerX2 => "pr-3",
                SpacingSize.Smaller => "pr-4",
                SpacingSize.Small => "pr-5",
                SpacingSize.Medium => "pr-6",
                SpacingSize.Large => "pr-7",
                SpacingSize.Larger => "pr-8",
                SpacingSize.LargerX2 => "pr-9",
                SpacingSize.LargerX3 => "pr-10",
                SpacingSize.LargerX4 => "pr-11",
                SpacingSize.LargerX5 => "pr-12",
                SpacingSize.LargerX6 => "pr-13",
                SpacingSize.LargerX7 => "pr-14",
                SpacingSize.LargerX8 => "pr-15",
                SpacingSize.Largest => "pr-16",
                SpacingSize.Initial => "pr-initial",
            },
            SpacingSide.Bottom => size switch
            {
                SpacingSize.None => "pb-0",
                SpacingSize.One => "pb-1",
                SpacingSize.Two => "pb-2",
                SpacingSize.SmallerX2 => "pb-3",
                SpacingSize.Smaller => "pb-4",
                SpacingSize.Small => "pb-5",
                SpacingSize.Medium => "pb-6",
                SpacingSize.Large => "pb-7",
                SpacingSize.Larger => "pb-8",
                SpacingSize.LargerX2 => "pb-9",
                SpacingSize.LargerX3 => "pb-10",
                SpacingSize.LargerX4 => "pb-11",
                SpacingSize.LargerX5 => "pb-12",
                SpacingSize.LargerX6 => "pb-13",
                SpacingSize.LargerX7 => "pb-14",
                SpacingSize.LargerX8 => "pb-15",
                SpacingSize.Largest => "pb-16",
                SpacingSize.Initial => "pb-initial",
            },
            SpacingSide.Left => size switch
            {
                SpacingSize.None => "pl-0",
                SpacingSize.One => "pl-1",
                SpacingSize.Two => "pl-2",
                SpacingSize.SmallerX2 => "pl-3",
                SpacingSize.Smaller => "pl-4",
                SpacingSize.Small => "pl-5",
                SpacingSize.Medium => "pl-6",
                SpacingSize.Large => "pl-7",
                SpacingSize.Larger => "pl-8",
                SpacingSize.LargerX2 => "pl-9",
                SpacingSize.LargerX3 => "pl-10",
                SpacingSize.LargerX4 => "pl-11",
                SpacingSize.LargerX5 => "pl-12",
                SpacingSize.LargerX6 => "pl-13",
                SpacingSize.LargerX7 => "pl-14",
                SpacingSize.LargerX8 => "pl-15",
                SpacingSize.Largest => "pl-16",
                SpacingSize.Initial => "pl-initial",
            },
            SpacingSide.Horizontal => size switch
            {
                SpacingSize.None => "px-0",
                SpacingSize.One => "px-1",
                SpacingSize.Two => "px-2",
                SpacingSize.SmallerX2 => "px-3",
                SpacingSize.Smaller => "px-4",
                SpacingSize.Small => "px-5",
                SpacingSize.Medium => "px-6",
                SpacingSize.Large => "px-7",
                SpacingSize.Larger => "px-8",
                SpacingSize.LargerX2 => "px-9",
                SpacingSize.LargerX3 => "px-10",
                SpacingSize.LargerX4 => "px-11",
                SpacingSize.LargerX5 => "px-12",
                SpacingSize.LargerX6 => "px-13",
                SpacingSize.LargerX7 => "px-14",
                SpacingSize.LargerX8 => "px-15",
                SpacingSize.Largest => "px-16",
                SpacingSize.Initial => "px-initial",
            },
            SpacingSide.Vertical => size switch
            {
                SpacingSize.None => "py-0",
                SpacingSize.One => "py-1",
                SpacingSize.Two => "py-2",
                SpacingSize.SmallerX2 => "py-3",
                SpacingSize.Smaller => "py-4",
                SpacingSize.Small => "py-5",
                SpacingSize.Medium => "py-6",
                SpacingSize.Large => "py-7",
                SpacingSize.Larger => "py-8",
                SpacingSize.LargerX2 => "py-9",
                SpacingSize.LargerX3 => "py-10",
                SpacingSize.LargerX4 => "py-11",
                SpacingSize.LargerX5 => "py-12",
                SpacingSize.LargerX6 => "py-13",
                SpacingSize.LargerX7 => "py-14",
                SpacingSize.LargerX8 => "py-15",
                SpacingSize.Largest => "py-16",
                SpacingSize.Initial => "py-initial",
            },
            SpacingSide.All => size switch
            {
                SpacingSize.None => "p-0",
                SpacingSize.One => "p-1",
                SpacingSize.Two => "p-2",
                SpacingSize.SmallerX2 => "p-3",
                SpacingSize.Smaller => "p-4",
                SpacingSize.Small => "p-5",
                SpacingSize.Medium => "p-6",
                SpacingSize.Large => "p-7",
                SpacingSize.Larger => "p-8",
                SpacingSize.LargerX2 => "p-9",
                SpacingSize.LargerX3 => "p-10",
                SpacingSize.LargerX4 => "p-11",
                SpacingSize.LargerX5 => "p-12",
                SpacingSize.LargerX6 => "p-13",
                SpacingSize.LargerX7 => "p-14",
                SpacingSize.LargerX8 => "p-15",
                SpacingSize.Largest => "p-16",
                SpacingSize.Initial => "p-initial",
            },
        };
    }

    public static string GetMarginCssClass(SpacingSide side, SpacingSize size)
    {
        if (side == SpacingSide.None)
            return string.Empty;

        return side switch
        {
            SpacingSide.Top => size switch
            {
                SpacingSize.None => "mt-0",
                SpacingSize.One => "mt-1",
                SpacingSize.Two => "mt-2",
                SpacingSize.SmallerX2 => "mt-3",
                SpacingSize.Smaller => "mt-4",
                SpacingSize.Small => "mt-5",
                SpacingSize.Medium => "mt-6",
                SpacingSize.Large => "mt-7",
                SpacingSize.Larger => "mt-8",
                SpacingSize.LargerX2 => "mt-9",
                SpacingSize.LargerX3 => "mt-10",
                SpacingSize.LargerX4 => "mt-11",
                SpacingSize.LargerX5 => "mt-12",
                SpacingSize.LargerX6 => "mt-13",
                SpacingSize.LargerX7 => "mt-14",
                SpacingSize.LargerX8 => "mt-15",
                SpacingSize.Largest => "mt-16",
                SpacingSize.Initial => "mt-initial",
            },
            SpacingSide.Right => size switch
            {
                SpacingSize.None => "mr-0",
                SpacingSize.One => "mr-1",
                SpacingSize.Two => "mr-2",
                SpacingSize.SmallerX2 => "mr-3",
                SpacingSize.Smaller => "mr-4",
                SpacingSize.Small => "mr-5",
                SpacingSize.Medium => "mr-6",
                SpacingSize.Large => "mr-7",
                SpacingSize.Larger => "mr-8",
                SpacingSize.LargerX2 => "mr-9",
                SpacingSize.LargerX3 => "mr-10",
                SpacingSize.LargerX4 => "mr-11",
                SpacingSize.LargerX5 => "mr-12",
                SpacingSize.LargerX6 => "mr-13",
                SpacingSize.LargerX7 => "mr-14",
                SpacingSize.LargerX8 => "mr-15",
                SpacingSize.Largest => "mr-16",
                SpacingSize.Initial => "mr-initial",
            },
            SpacingSide.Bottom => size switch
            {
                SpacingSize.None => "mb-0",
                SpacingSize.One => "mb-1",
                SpacingSize.Two => "mb-2",
                SpacingSize.SmallerX2 => "mb-3",
                SpacingSize.Smaller => "mb-4",
                SpacingSize.Small => "mb-5",
                SpacingSize.Medium => "mb-6",
                SpacingSize.Large => "mb-7",
                SpacingSize.Larger => "mb-8",
                SpacingSize.LargerX2 => "mb-9",
                SpacingSize.LargerX3 => "mb-10",
                SpacingSize.LargerX4 => "mb-11",
                SpacingSize.LargerX5 => "mb-12",
                SpacingSize.LargerX6 => "mb-13",
                SpacingSize.LargerX7 => "mb-14",
                SpacingSize.LargerX8 => "mb-15",
                SpacingSize.Largest => "mb-16",
                SpacingSize.Initial => "mb-initial",
            },
            SpacingSide.Left => size switch
            {
                SpacingSize.None => "ml-0",
                SpacingSize.One => "ml-1",
                SpacingSize.Two => "ml-2",
                SpacingSize.SmallerX2 => "ml-3",
                SpacingSize.Smaller => "ml-4",
                SpacingSize.Small => "ml-5",
                SpacingSize.Medium => "ml-6",
                SpacingSize.Large => "ml-7",
                SpacingSize.Larger => "ml-8",
                SpacingSize.LargerX2 => "ml-9",
                SpacingSize.LargerX3 => "ml-10",
                SpacingSize.LargerX4 => "ml-11",
                SpacingSize.LargerX5 => "ml-12",
                SpacingSize.LargerX6 => "ml-13",
                SpacingSize.LargerX7 => "ml-14",
                SpacingSize.LargerX8 => "ml-15",
                SpacingSize.Largest => "ml-16",
                SpacingSize.Initial => "ml-initial",
            },
            SpacingSide.Horizontal => size switch
            {
                SpacingSize.None => "mx-0",
                SpacingSize.One => "mx-1",
                SpacingSize.Two => "mx-2",
                SpacingSize.SmallerX2 => "mx-3",
                SpacingSize.Smaller => "mx-4",
                SpacingSize.Small => "mx-5",
                SpacingSize.Medium => "mx-6",
                SpacingSize.Large => "mx-7",
                SpacingSize.Larger => "mx-8",
                SpacingSize.LargerX2 => "mx-9",
                SpacingSize.LargerX3 => "mx-10",
                SpacingSize.LargerX4 => "mx-11",
                SpacingSize.LargerX5 => "mx-12",
                SpacingSize.LargerX6 => "mx-13",
                SpacingSize.LargerX7 => "mx-14",
                SpacingSize.LargerX8 => "mx-15",
                SpacingSize.Largest => "mx-16",
                SpacingSize.Initial => "mx-initial",
            },
            SpacingSide.Vertical => size switch
            {
                SpacingSize.None => "my-0",
                SpacingSize.One => "my-1",
                SpacingSize.Two => "my-2",
                SpacingSize.SmallerX2 => "my-3",
                SpacingSize.Smaller => "my-4",
                SpacingSize.Small => "my-5",
                SpacingSize.Medium => "my-6",
                SpacingSize.Large => "my-7",
                SpacingSize.Larger => "my-8",
                SpacingSize.LargerX2 => "my-9",
                SpacingSize.LargerX3 => "my-10",
                SpacingSize.LargerX4 => "my-11",
                SpacingSize.LargerX5 => "my-12",
                SpacingSize.LargerX6 => "my-13",
                SpacingSize.LargerX7 => "my-14",
                SpacingSize.LargerX8 => "my-15",
                SpacingSize.Largest => "my-16",
                SpacingSize.Initial => "my-initial",
            },
            SpacingSide.All => size switch
            {
                SpacingSize.None => "m-0",
                SpacingSize.One => "m-1",
                SpacingSize.Two => "m-2",
                SpacingSize.SmallerX2 => "m-3",
                SpacingSize.Smaller => "m-4",
                SpacingSize.Small => "m-5",
                SpacingSize.Medium => "m-6",
                SpacingSize.Large => "m-7",
                SpacingSize.Larger => "m-8",
                SpacingSize.LargerX2 => "m-9",
                SpacingSize.LargerX3 => "m-10",
                SpacingSize.LargerX4 => "m-11",
                SpacingSize.LargerX5 => "m-12",
                SpacingSize.LargerX6 => "m-13",
                SpacingSize.LargerX7 => "m-14",
                SpacingSize.LargerX8 => "m-15",
                SpacingSize.Largest => "m-16",
                SpacingSize.Initial => "m-initial",
            },
            _ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
        };
    }

    public static string ToWidthCssClass(this SpacingSize size)
    {
        return size switch
        {
            SpacingSize.None => "w-0",
            SpacingSize.One => "w-1",
            SpacingSize.Two => "w-2",
            SpacingSize.SmallerX2 => "w-3",
            SpacingSize.Smaller => "w-4",
            SpacingSize.Small => "w-5",
            SpacingSize.Medium => "w-6",
            SpacingSize.Large => "w-7",
            SpacingSize.Larger => "w-8",
            SpacingSize.LargerX2 => "w-9",
            SpacingSize.LargerX3 => "w-10",
            SpacingSize.LargerX4 => "w-11",
            SpacingSize.LargerX5 => "w-12",
            SpacingSize.LargerX6 => "w-13",
            SpacingSize.LargerX7 => "w-14",
            SpacingSize.LargerX8 => "w-15",
            SpacingSize.Largest => "w-16",
            SpacingSize.Initial => "w-initial",
        };
    }

    public static string ToMaxWidthCssClass(this SpacingSize size)
    {
        return size switch
        {
            SpacingSize.None => "max-w-0",
            SpacingSize.One => "max-w-1",
            SpacingSize.Two => "max-w-2",
            SpacingSize.SmallerX2 => "max-w-3",
            SpacingSize.Smaller => "max-w-4",
            SpacingSize.Small => "max-w-5",
            SpacingSize.Medium => "max-w-6",
            SpacingSize.Large => "max-w-7",
            SpacingSize.Larger => "max-w-8",
            SpacingSize.LargerX2 => "max-w-9",
            SpacingSize.LargerX3 => "max-w-10",
            SpacingSize.LargerX4 => "max-w-11",
            SpacingSize.LargerX5 => "max-w-12",
            SpacingSize.LargerX6 => "max-w-13",
            SpacingSize.LargerX7 => "max-w-14",
            SpacingSize.LargerX8 => "max-w-15",
            SpacingSize.Largest => "max-w-16",
            SpacingSize.Initial => "max-w-initial",
        };
    }

    public static string ToMinWidthCssClass(this SpacingSize size)
    {
        return size switch
        {
            SpacingSize.None => "min-w-0",
            SpacingSize.One => "min-w-1",
            SpacingSize.Two => "min-w-2",
            SpacingSize.SmallerX2 => "min-w-3",
            SpacingSize.Smaller => "min-w-4",
            SpacingSize.Small => "min-w-5",
            SpacingSize.Medium => "min-w-6",
            SpacingSize.Large => "min-w-7",
            SpacingSize.Larger => "min-w-8",
            SpacingSize.LargerX2 => "min-w-9",
            SpacingSize.LargerX3 => "min-w-10",
            SpacingSize.LargerX4 => "min-w-11",
            SpacingSize.LargerX5 => "min-w-12",
            SpacingSize.LargerX6 => "min-w-13",
            SpacingSize.LargerX7 => "min-w-14",
            SpacingSize.LargerX8 => "min-w-15",
            SpacingSize.Largest => "min-w-16",
            SpacingSize.Initial => "min-w-initial",
        };
    }

    public static string ToHeightCssClass(this SpacingSize size)
    {
        return size switch
        {
            SpacingSize.None => "h-0",
            SpacingSize.One => "h-1",
            SpacingSize.Two => "h-2",
            SpacingSize.SmallerX2 => "h-3",
            SpacingSize.Smaller => "h-4",
            SpacingSize.Small => "h-5",
            SpacingSize.Medium => "h-6",
            SpacingSize.Large => "h-7",
            SpacingSize.Larger => "h-8",
            SpacingSize.LargerX2 => "h-9",
            SpacingSize.LargerX3 => "h-10",
            SpacingSize.LargerX4 => "h-11",
            SpacingSize.LargerX5 => "h-12",
            SpacingSize.LargerX6 => "h-13",
            SpacingSize.LargerX7 => "h-14",
            SpacingSize.LargerX8 => "h-15",
            SpacingSize.Largest => "h-16",
            SpacingSize.Initial => "h-initial"
        };
    }

    public static string ToMaxHeightCssClass(this SpacingSize size)
    {
        return size switch
        {
            SpacingSize.None => "max-h-0",
            SpacingSize.One => "max-h-1",
            SpacingSize.Two => "max-h-2",
            SpacingSize.SmallerX2 => "max-h-3",
            SpacingSize.Smaller => "max-h-4",
            SpacingSize.Small => "max-h-5",
            SpacingSize.Medium => "max-h-6",
            SpacingSize.Large => "max-h-7",
            SpacingSize.Larger => "max-h-8",
            SpacingSize.LargerX2 => "max-h-9",
            SpacingSize.LargerX3 => "max-h-10",
            SpacingSize.LargerX4 => "max-h-11",
            SpacingSize.LargerX5 => "max-h-12",
            SpacingSize.LargerX6 => "max-h-13",
            SpacingSize.LargerX7 => "max-h-14",
            SpacingSize.LargerX8 => "max-h-15",
            SpacingSize.Largest => "max-h-16",
            SpacingSize.Initial => "max-h-initial"
        };
    }

    public static string ToMinHeightCssClass(this SpacingSize size)
    {
        return size switch
        {
            SpacingSize.None => "min-h-0",
            SpacingSize.One => "min-h-1",
            SpacingSize.Two => "min-h-2",
            SpacingSize.SmallerX2 => "min-h-3",
            SpacingSize.Smaller => "min-h-4",
            SpacingSize.Small => "min-h-5",
            SpacingSize.Medium => "min-h-6",
            SpacingSize.Large => "min-h-7",
            SpacingSize.Larger => "min-h-8",
            SpacingSize.LargerX2 => "min-h-9",
            SpacingSize.LargerX3 => "min-h-10",
            SpacingSize.LargerX4 => "min-h-11",
            SpacingSize.LargerX5 => "min-h-12",
            SpacingSize.LargerX6 => "min-h-13",
            SpacingSize.LargerX7 => "min-h-14",
            SpacingSize.LargerX8 => "min-h-15",
            SpacingSize.Largest => "min-h-16",
            SpacingSize.Initial => "min-h-initial"
        };
    }

    public static string ToWidthCssClass(this SpacingFraction fraction)
    {
        return fraction switch
        {
            SpacingFraction.None => string.Empty,
            SpacingFraction.One => "w-1/12",
            SpacingFraction.Two => "w-2/12",
            SpacingFraction.Three => "w-3/12",
            SpacingFraction.Four => "w-4/12",
            SpacingFraction.Five => "w-5/12",
            SpacingFraction.Six => "w-6/12",
            SpacingFraction.Seven => "w-7/12",
            SpacingFraction.Eight => "w-8/12",
            SpacingFraction.Nine => "w-9/12",
            SpacingFraction.Ten => "w-10/12",
            SpacingFraction.Eleven => "w-11/12",
            SpacingFraction.Full => "w-full",
        };
    }

    public static string ToMinWidthCssClass(this SpacingFraction fraction)
    {
        return fraction switch
        {
            SpacingFraction.None => string.Empty,
            SpacingFraction.One => "min-w-1/12",
            SpacingFraction.Two => "min-w-2/12",
            SpacingFraction.Three => "min-w-3/12",
            SpacingFraction.Four => "min-w-4/12",
            SpacingFraction.Five => "min-w-5/12",
            SpacingFraction.Six => "min-w-6/12",
            SpacingFraction.Seven => "min-w-7/12",
            SpacingFraction.Eight => "min-w-8/12",
            SpacingFraction.Nine => "min-w-9/12",
            SpacingFraction.Ten => "min-w-10/12",
            SpacingFraction.Eleven => "min-w-11/12",
            SpacingFraction.Full => "min-w-full",
        };
    }

    public static string ToMaxWidthCssClass(this SpacingFraction fraction)
    {
        return fraction switch
        {
            SpacingFraction.None => string.Empty,
            SpacingFraction.One => "max-w-1/12",
            SpacingFraction.Two => "max-w-2/12",
            SpacingFraction.Three => "max-w-3/12",
            SpacingFraction.Four => "max-w-4/12",
            SpacingFraction.Five => "max-w-5/12",
            SpacingFraction.Six => "max-w-6/12",
            SpacingFraction.Seven => "max-w-7/12",
            SpacingFraction.Eight => "max-w-8/12",
            SpacingFraction.Nine => "max-w-9/12",
            SpacingFraction.Ten => "max-w-10/12",
            SpacingFraction.Eleven => "max-w-11/12",
            SpacingFraction.Full => "max-w-full",
        };
    }

    public static string ToHeightCssClass(this SpacingFraction fraction)
    {
        return fraction switch
        {
            SpacingFraction.None => string.Empty,
            SpacingFraction.One => "h-1/12",
            SpacingFraction.Two => "h-2/12",
            SpacingFraction.Three => "h-3/12",
            SpacingFraction.Four => "h-4/12",
            SpacingFraction.Five => "h-5/12",
            SpacingFraction.Six => "h-6/12",
            SpacingFraction.Seven => "h-7/12",
            SpacingFraction.Eight => "h-8/12",
            SpacingFraction.Nine => "h-9/12",
            SpacingFraction.Ten => "h-10/12",
            SpacingFraction.Eleven => "h-11/12",
            SpacingFraction.Full => "h-full",
        };
    }

    public static string ToMinHeightCssClass(this SpacingFraction fraction)
    {
        return fraction switch
        {
            SpacingFraction.None => string.Empty,
            SpacingFraction.One => "min-h-1/12",
            SpacingFraction.Two => "min-h-2/12",
            SpacingFraction.Three => "min-h-3/12",
            SpacingFraction.Four => "min-h-4/12",
            SpacingFraction.Five => "min-h-5/12",
            SpacingFraction.Six => "min-h-6/12",
            SpacingFraction.Seven => "min-h-7/12",
            SpacingFraction.Eight => "min-h-8/12",
            SpacingFraction.Nine => "min-h-9/12",
            SpacingFraction.Ten => "min-h-10/12",
            SpacingFraction.Eleven => "min-h-11/12",
            SpacingFraction.Full => "min-h-full",
        };
    }

    public static string ToMaxHeightCssClass(this SpacingFraction fraction)
    {
        return fraction switch
        {
            SpacingFraction.None => string.Empty,
            SpacingFraction.One => "max-h-1/12",
            SpacingFraction.Two => "max-h-2/12",
            SpacingFraction.Three => "max-h-3/12",
            SpacingFraction.Four => "max-h-4/12",
            SpacingFraction.Five => "max-h-5/12",
            SpacingFraction.Six => "max-h-6/12",
            SpacingFraction.Seven => "max-h-7/12",
            SpacingFraction.Eight => "max-h-8/12",
            SpacingFraction.Nine => "max-h-9/12",
            SpacingFraction.Ten => "max-h-10/12",
            SpacingFraction.Eleven => "max-h-11/12",
            SpacingFraction.Full => "max-h-full",
        };
    }
}