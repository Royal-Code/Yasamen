using System.Reflection;

namespace RoyalCode.Yasamen.Commons.Extensions;

/// <summary>
/// <para>
///     Represents a property and its list of attributes of a given type.
/// </para>
/// </summary>
/// <typeparam name="TAttribute">Attribute Type.</typeparam>
public record PropertyAttributeList<TAttribute>(
    PropertyInfo Property,
    List<TAttribute> Attributes,
    TAttribute FirstAttribute)
    where TAttribute : Attribute;