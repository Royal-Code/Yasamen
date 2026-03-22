using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Internal.Buttons;

/// <summary>
/// Cascading defaults applied by <see cref="RoyalCode.Razor.Components.ButtonGroup"/> to supported child buttons.
/// </summary>
internal sealed class ButtonGroupContext
{
    public Themes Style { get; init; }

    public Sizes Size { get; init; }

    public bool Disabled { get; init; }
}
