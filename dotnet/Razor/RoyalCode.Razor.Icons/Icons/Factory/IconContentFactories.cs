
namespace RoyalCode.Razor.Icons.Factory;

/// <summary>
/// <para>
///     A registry for icon content factories.
/// </para>
/// <para>
///     For each enum type that represents a set of icon kinds,
///     an <see cref="IIconContentFactory"/> can be registered.
/// </para>
/// </summary>
public static class IconContentFactories
{
    private static readonly Dictionary<Type, IIconContentFactory> factories = new();

    /// <summary>
    /// Adds an icon content factory for the specified enum type.
    /// </summary>
    /// <param name="enumType">The enum type representing icon kinds.</param>
    /// <param name="factory">The icon content factory to register.</param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void AddIconContentFactory(Type enumType, IIconContentFactory factory)
    {
        ArgumentNullException.ThrowIfNull(enumType);
        ArgumentNullException.ThrowIfNull(factory);

        if (!enumType.IsEnum)
            throw new InvalidOperationException($"The {nameof(enumType)} must be an Enum, the type {enumType.FullName} is not a enum.");

        factories.Add(enumType, factory);
    }

    /// <summary>
    /// Gets the icon content factory for the specified icon kind type.
    /// </summary>
    /// <param name="kindType">The icon kind type.</param>
    /// <returns>The icon content factory.</returns>
    /// <exception cref="InvalidOperationException">
    ///     When no factory is found for the specified icon kind type.
    /// </exception>
    public static IIconContentFactory Get(Type kindType)
    {
        return factories.TryGetValue(kindType, out var options)
            ? options
            : throw new InvalidOperationException($"None {nameof(IIconContentFactory)} found for icon kind {kindType.FullName}.");
    }
}
