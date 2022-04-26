namespace RoyalCode.Yasamen.Commons;

public enum Shadows
{
    Default,
    
    None,
    Small,
    Medium,
    Large
}

public static class ShadowsExtensions
{
    public static string GetCssClass(this Shadows shadow)
    {
        return shadow switch
        {
            Shadows.Default => string.Empty,
            Shadows.None => "shadow-none",
            Shadows.Small => "shadow-sm",
            Shadows.Medium => "shadow",
            Shadows.Large => "shadow-lg",
            _ => throw new ArgumentOutOfRangeException(nameof(shadow), shadow, null)
        };
    }
}