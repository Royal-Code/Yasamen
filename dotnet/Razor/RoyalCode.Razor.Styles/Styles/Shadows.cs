namespace RoyalCode.Razor.Styles;

public enum Shadows
{
    Default,
    
    None,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Eleven,
    Twelve,

    Smallest,
    Smaller,
    Small,
    Medium,
    Large,
    Larger,
    Largest
}

public static class ShadowsExtensions
{
    public static string ToBoxCssClass(this Shadows shadow)
    {
        return shadow switch
        {
            Shadows.Default => string.Empty,
            Shadows.None => "shadow-0",
            Shadows.One => "shadow-1",
            Shadows.Two => "shadow-2",
            Shadows.Three => "shadow-3",
            Shadows.Four => "shadow-4",
            Shadows.Five => "shadow-5",
            Shadows.Six => "shadow-6",
            Shadows.Seven => "shadow-7",
            Shadows.Eight => "shadow-8",
            Shadows.Nine => "shadow-9",
            Shadows.Ten => "shadow-10",
            Shadows.Eleven => "shadow-11",
            Shadows.Twelve => "shadow-12",
            Shadows.Smallest => "shadow-2xs",
            Shadows.Smaller => "shadow-xs",
            Shadows.Small => "shadow-sm",
            Shadows.Medium => "shadow-md",
            Shadows.Large => "shadow-lg",
            Shadows.Larger => "shadow-xl",
            Shadows.Largest => "shadow-2xl",
            _ => throw new ArgumentOutOfRangeException(nameof(shadow), shadow, null)
        };
    }

    public static string ToTextCssClass(this Shadows shadow)
    {
        return shadow switch
        {
            Shadows.Default => string.Empty,
            Shadows.None => "text-shadow-0",
            Shadows.One => "text-shadow-1",
            Shadows.Two => "text-shadow-2",
            Shadows.Three => "text-shadow-3",
            Shadows.Four => "text-shadow-4",
            Shadows.Five => "text-shadow-5",
            Shadows.Six => "text-shadow-6",
            Shadows.Seven => "text-shadow-7",
            Shadows.Eight => "text-shadow-8",
            Shadows.Nine => "text-shadow-9",
            Shadows.Ten => "text-shadow-10",
            Shadows.Eleven => "text-shadow-11",
            Shadows.Twelve => "text-shadow-12",
            Shadows.Smallest => "text-shadow-2xs",
            Shadows.Smaller => "text-shadow-xs",
            Shadows.Small => "text-shadow-sm",
            Shadows.Medium => "text-shadow-md",
            Shadows.Large => "text-shadow-lg",
            Shadows.Larger => "text-shadow-xl",
            Shadows.Largest => "text-shadow-2xl",
            _ => throw new ArgumentOutOfRangeException(nameof(shadow), shadow, null)
        };
    }

    public static string ToDropCssClass(this Shadows shadow)
    {
        return shadow switch
        {
            Shadows.Default => string.Empty,
            Shadows.None => "drop-shadow-none",
            Shadows.One => "drop-shadow-[0_1px_1px_rgba(0,0,0,0.25)]",
            Shadows.Two => "drop-shadow-[0_2px_2px_rgba(0,0,0,0.25)]",
            Shadows.Three => "drop-shadow-[0_3px_3px_rgba(0,0,0,0.25)]",
            Shadows.Four => "drop-shadow-[0_4px_4px_rgba(0,0,0,0.25)]",
            Shadows.Five => "drop-shadow-[0_5px_5px_rgba(0,0,0,0.25)]",
            Shadows.Six => "drop-shadow-[0_6px_6px_rgba(0,0,0,0.25)]",
            Shadows.Seven => "drop-shadow-[0_7px_7px_rgba(0,0,0,0.25)]",
            Shadows.Eight => "drop-shadow-[0_8px_8px_rgba(0,0,0,0.25)]",
            Shadows.Nine => "drop-shadow-[0_9px_9px_rgba(0,0,0,0.25)]",
            Shadows.Ten => "drop-shadow-[0_10px_10px_rgba(0,0,0,0.25)]",
            Shadows.Eleven => "drop-shadow-[0_11px_11px_rgba(0,0,0,0.25)]",
            Shadows.Twelve => "drop-shadow-[0_12px_12px_rgba(0,0,0,0.25)]",
            Shadows.Smallest => "drop-shadow-[0_0.5px_0.5px_rgba(0,0,0,0.05)]",
            Shadows.Smaller => "drop-shadow-xs",
            Shadows.Small => "drop-shadow-sm",
            Shadows.Medium => "drop-shadow-md",
            Shadows.Large => "drop-shadow-lg",
            Shadows.Larger => "drop-shadow-xl",
            Shadows.Largest => "drop-shadow-2xl",
            _ => throw new ArgumentOutOfRangeException(nameof(shadow), shadow, null)
        };
    }
}