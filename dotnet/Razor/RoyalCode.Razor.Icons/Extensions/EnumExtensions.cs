using System.ComponentModel;
using System.Reflection;

namespace System;

/// <summary>
/// Enum extensions methods.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Gets the description of an enumerated value, 
    /// through the attribute System.ComponentModel.DescriptionAttribute
    /// </summary>
    /// <param name="value">An Enum.</param>
    /// <returns>Returns the "Description" if it has one, otherwise value.toString().</returns>
    public static string GetDescription(this Enum value)
    {
        var name = value.ToString();
        return value.GetType()
            .GetField(name)
            ?.GetCustomAttribute(typeof(DescriptionAttribute)) is DescriptionAttribute attr
                ? attr.Description
                : name;
    }
}
