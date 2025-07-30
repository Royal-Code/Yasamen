namespace RoyalCode.Razor.Commons.Styles;

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
    Twelve
}

public static class ShadowsExtensions
{
    public static string ToCssClass(this Shadows shadow)
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
            _ => throw new ArgumentOutOfRangeException(nameof(shadow), shadow, null)
        };
    }
}