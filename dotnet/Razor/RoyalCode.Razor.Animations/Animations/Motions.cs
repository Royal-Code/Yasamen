namespace RoyalCode.Razor.Animations;

/// <summary>
/// Motions Animations
/// </summary>
public static class Motions
{
    /// <summary>
    /// Rotation Animation
    /// </summary>
    /// <param name="clockwise">Indicates whether the rotation is clockwise (default) or counterclockwise.</param>
    /// <returns>An AnimationFragment representing the rotation animation.</returns>
    public static AnimationFragment Rotation(bool clockwise = true)
    {
        return content => builder =>
        {
            builder.OpenComponent<RotationMotion>(0);
            builder.AddAttribute(1, nameof(RotationMotion.CounterClockwise), !clockwise);
            builder.AddAttribute(2, nameof(RotationMotion.ChildContent), content);
            builder.CloseComponent();
        };
    }
}
