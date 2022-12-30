using Microsoft.AspNetCore.Components.Forms;

namespace RoyalCode.Yasamen.Forms.Support;

/// <summary>
/// <para>
///     Internal interface used by <see cref="ChangeSupport"/>
///     to handle <see cref="IncludeChangeSupport{TProperty,TIncludedProperty}"/>.
/// </para>
/// </summary>
internal interface IIncludeChangeSupport
{
    void Initialize<TValue>(FieldIdentifier identifier, TValue initialValue);

    void Reset();

    void PropertyHasChanged<TValue>(FieldIdentifier field, TValue oldValue, TValue newValue);
}