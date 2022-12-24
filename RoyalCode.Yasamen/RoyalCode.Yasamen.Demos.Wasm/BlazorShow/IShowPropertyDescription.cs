using System.Reflection;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IShowPropertyDescription
{
    PropertyInfo Property { get; }

    string? Name { get; }

    string? Description { get; }

    bool IsHidden { get; }

    bool IsFragment { get; }

    bool IsEvent { get; }

    bool HasEnumValues { get; }

    Type? EnumType { get; }

    bool IsHtmlAttributes { get; }

    bool IsHtmlClasses { get; }

    bool IsCaptureUnmatchedValues { get; }

    bool HasValueSet { get; }

    object? ValueSet { get; }
}

public static class ShowPropertyDescriptionExtensions
{
    public static bool IsEnum(this IShowPropertyDescription property)
        => (property.Property.PropertyType.IsEnum || property.Property.PropertyType == typeof(Enum))
            && property.HasEnumValues 
            && property.EnumType is not null;

    public static bool IsStringType(this IShowPropertyDescription property)
        => property.Property.PropertyType == typeof(string);

    public static bool IsNumberType(this IShowPropertyDescription property)
        => property.Property.PropertyType == typeof(int)
            || property.Property.PropertyType == typeof(long)
            || property.Property.PropertyType == typeof(float)
            || property.Property.PropertyType == typeof(double)
            || property.Property.PropertyType == typeof(decimal);

    public static bool IsBoolType(this IShowPropertyDescription property)
        => property.Property.PropertyType == typeof(bool);
}