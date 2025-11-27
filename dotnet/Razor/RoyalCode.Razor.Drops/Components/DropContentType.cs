namespace RoyalCode.Razor.Components;

/// <summary>
/// <para>
///     The type of content contained in a drop.
/// </para>
/// <para>
///     It can be 'ul' and 'li' elements when the type is List,
///     or 'div' elements when the type is NotDefined.
/// </para>
/// </summary>
public enum DropContentType
{
    /// <summary>
    /// Used for lists.
    /// </summary>
    List,

    /// <summary>
    /// Used for divs.
    /// </summary>
    NotDefined
}
