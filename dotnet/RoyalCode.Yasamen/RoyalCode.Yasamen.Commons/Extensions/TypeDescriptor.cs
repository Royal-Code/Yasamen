using System.Reflection;

namespace RoyalCode.Yasamen.Commons.Extensions;

/// <summary>
/// Represents a property that can describe a data model.
/// </summary>
public class TypeDescriptor
{
    /// <summary>
    /// The property that describe the model.
    /// </summary>
    public required PropertyInfo Property { get; init; }

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