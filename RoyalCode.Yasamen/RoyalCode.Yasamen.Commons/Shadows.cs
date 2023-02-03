namespace RoyalCode.Yasamen.Commons;

public enum Shadows
{
    Default,
    
    None,
    Smallest,
    Small,
    Medium,
    Large,
    Largest
}

public static class ShadowsExtensions
{
    public static string ToCssClass(this Shadows shadow)
    {
        return shadow switch
        {
            Shadows.Default => string.Empty,
            Shadows.None => "shadow-0",
            Shadows.Smallest => "shadow-1",
            Shadows.Small => "shadow-2",
            Shadows.Medium => "shadow-3",
            Shadows.Large => "shadow-4",
            Shadows.Largest => "shadow-5",
            _ => throw new ArgumentOutOfRangeException(nameof(shadow), shadow, null)
        };
    }
}