namespace RoyalCode.Yasamen.Commons.Extensions;

/// <summary>
/// <para>
///     Defines the properties and fields that serve to describe a data model.
/// </para>
/// <para>
///     Used in components that describe a model (object/class), for example, 
///     the comboboxes (select in Html).
/// </para>
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class DescriptorAttribute : Attribute
{
    /// <summary>
    /// Used for sorting the description.
    /// </summary>
    public int Order { get; init; }

    /// <summary>
    /// Value for <see cref="string.Format(string, object?)"/>.
    /// </summary>
    /// <example>
    ///     "[{0}]"
    /// </example>
    public string? StringFormat { get; init; }

    /// <summary>
    /// <para>
    ///     String used for separation between property values of the model description.
    /// </para>
    /// <para>
    ///     This value is used between the current property and the previous property.
    /// </para>
    /// <para>
    ///     When not informed, the default value will be used, which is " - ".
    /// </para>
    /// </summary>
    public string? Separetor { get; init; }
}