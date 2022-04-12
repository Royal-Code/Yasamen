using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RoyalCode.Yasamen.Commons.Extensions;

/// <summary>
/// Extensions methods for <c>System.Reflection</c> namespace.
/// </summary>
public static class ReflectionExtensions
{
    public static bool TryGetAttribute<TAttribute>(this MemberInfo member, out TAttribute attribute)
        where TAttribute : Attribute
    {
        var attr = member?.GetCustomAttribute(typeof(TAttribute));

        if (attr is null)
        {
            attribute = null;
            return false;
        }

        attribute = (TAttribute)attr;
        return true;
    }

    public static string GetDefaultDisplayName(this MemberInfo member)
        => member.TryGetAttribute<DisplayNameAttribute>(out var displayName)
            ? displayName.DisplayName
            : member.TryGetAttribute<DisplayAttribute>(out var display)
                ? display.Name ?? member.Name
                : member.Name;

    public static string GetTypeName(this Type type)
    {
        var generics = type.GetGenericArguments();
        if (generics.Length == 0)
            return type.Name;

        return $"{type.Name.Replace($"`{generics.Length}", string.Empty)}<{string.Join(", ", generics.Select(t => t.Name))}>";
    }
}