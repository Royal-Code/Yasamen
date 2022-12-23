namespace RoyalCode.Yasamen.Commons;

public enum Shadows
{
    Default,
    
    None,
    ExtraSmall,
    Small,
    Medium,
    Large,
    ExtraLarge
}

public static class ShadowsExtensions
{
    public static string ToCssClass(this Shadows shadow)
    {
        return shadow switch
        {
            Shadows.Default => string.Empty,
            Shadows.None => "shadow-0",
            Shadows.ExtraSmall => "shadow-1",
            Shadows.Small => "shadow-2",
            Shadows.Medium => "shadow-3",
            Shadows.Large => "shadow-4",
            Shadows.ExtraLarge => "shadow-5",
            _ => throw new ArgumentOutOfRangeException(nameof(shadow), shadow, null)
        };
    }
}