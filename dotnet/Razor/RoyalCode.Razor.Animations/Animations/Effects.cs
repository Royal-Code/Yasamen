namespace RoyalCode.Razor.Animations;

/// <summary>
/// Animations Effects
/// </summary>
public static class Effects
{
    /// <summary>
    /// Creates a Rotate Effect
    /// </summary>
    /// <param name="degrees">The degrees to rotate</param>
    /// <returns>An Animation Fragment</returns>
    public static AnimationFragment Rotate(double degrees)
    {
        return content => builder =>
        {
            builder.OpenComponent<RotateEffect>(0);
            builder.AddAttribute(1, nameof(RotateEffect.Degrees), degrees);
            builder.AddAttribute(2, nameof(RotateEffect.ChildContent), content);
            builder.CloseComponent();
        };
    }
}
