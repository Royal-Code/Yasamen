namespace RoyalCode.Razor.Icons.Factory;

/// <summary>
/// Icon content factory.
/// Provides a way to obtain an <see cref="IconFragment"/> delegate for a given enum icon kind.
/// </summary>
public interface IIconContentFactory
{
    /// <summary>
    /// Gets the enum type that this factory supports.
    /// </summary>
    Type EnumType { get; }

    /// <summary>
    /// Gets an <see cref="IconFragment"/> delegate for the specified icon kind.
    /// The returned delegate can later be invoked providing optional additional css classes
    /// and html attributes to compose the final <see cref="Microsoft.AspNetCore.Components.RenderFragment"/>.
    /// </summary>
    /// <param name="iconKind">Enum value that identifies the icon to render.</param>
    /// <returns>An <see cref="IconFragment"/> delegate used to create the render fragment for the icon.</returns>
    IconFragment GetFragment(Enum iconKind);
}
