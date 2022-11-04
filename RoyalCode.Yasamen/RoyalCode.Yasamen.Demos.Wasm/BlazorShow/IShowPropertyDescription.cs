using System.Reflection;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IShowPropertyDescription
{
    PropertyInfo Property { get; }

    string? Name { get; }

    string? Description { get; }

    bool IsHidden { get; }

    bool HasEnumValues { get; }

    Type? EnumType { get; }

    bool IsHtmlAttributes { get; }

    bool IsHtmlClasses { get; }
}
