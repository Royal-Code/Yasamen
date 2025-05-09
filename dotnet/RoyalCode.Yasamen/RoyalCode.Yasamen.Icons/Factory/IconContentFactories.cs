
namespace RoyalCode.Yasamen.Icons.Factory;

public static class IconContentFactories
{
    private static readonly Dictionary<Type, IIconContentFactory> factories = new();

    public static void AddIconContentFactory(Type enumType, IIconContentFactory factory)
    {
        ArgumentNullException.ThrowIfNull(enumType);
        ArgumentNullException.ThrowIfNull(factory);

        if (!enumType.IsEnum)
            throw new InvalidOperationException($"The {nameof(enumType)} must be an Enum, the type {enumType.FullName} is not a enum.");

        factories.Add(enumType, factory);
    }

    public static IIconContentFactory Get(Type kindType)
    {
        return factories.TryGetValue(kindType, out var options)
            ? options
            : throw new InvalidOperationException($"None {nameof(IIconContentFactory)} found for icon kind {kindType.FullName}.");
    }
}
