
namespace RoyalCode.Yasamen.Components;

/// <summary>
/// Determines the behavior of the dropdown when the user clicks on it.
/// </summary>
public enum DropCloseBehavior
{
    /// <summary>
    /// When open, after clicking in any place, the dropdown will close.
    /// </summary>
    CloseOnClick,
    
    /// <summary>
    /// When open, after clicking in any place outside the dropdown content, the dropdown will close.
    /// </summary>
    CloseOnClickOutside,

    /// <summary>
    /// After open, the dropdown do not close automatically.
    /// </summary>
    CloseManually,
}
