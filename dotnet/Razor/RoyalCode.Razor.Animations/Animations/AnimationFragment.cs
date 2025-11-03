using Microsoft.AspNetCore.Components;

namespace RoyalCode.Razor.Animations;

/// <summary>
/// Represents an animation fragment that can wrap content with animation effects.
/// </summary>
/// <param name="content">The content to be animated.</param>
/// <returns>A RenderFragment that applies the animation effect to the provided content.</returns>
public delegate RenderFragment AnimationFragment(RenderFragment content);
