using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Razor.Styles;

/// <summary>
/// Extensions for CSS classes.
/// </summary>
public static partial class Css
{
    /// <summary>
    /// Checks that the value is present; it must not be null or blank.
    /// </summary>
    /// <param name="s">The string to check.</param>
    /// <returns><c>true</c> if the string is not null or whitespace; otherwise, <c>false</c>.</returns>
    public static bool IsPresent([NotNullWhen(true)] this string? s) => !string.IsNullOrWhiteSpace(s);

    /// <summary>
    /// Checks if the value is missing, null, or blank.
    /// </summary>
    /// <param name="s">The string to check.</param>
    /// <returns><c>true</c> if the string is null or whitespace; otherwise, <c>false</c>.</returns>
    public static bool IsMissing([NotNullWhen(false)] this string? s) => string.IsNullOrWhiteSpace(s);

    /// <summary>
    /// Adds a class to the class string if the value other is present.
    /// </summary>
    /// <param name="classes"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static CssClasses AddClass(this string classes, string? other)
    {
        return new CssClasses(classes).AddClass(other);
    }

    /// <summary>
    /// Adds a class if the condition is met and the other value is present.
    /// </summary>
    /// <param name="classes"></param>
    /// <param name="condition"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static CssClasses AddClass(this string classes, bool condition, string? other)
    {
        return new CssClasses(classes).AddClass(condition, other);
    }

    /// <summary>
    /// Adds one of the two classes, depending on the condition.
    /// </summary>
    /// <param name="classes"></param>
    /// <param name="condition"></param>
    /// <param name="otherWhenTrue"></param>
    /// <param name="otherWhenFalse"></param>
    /// <returns></returns>
    public static CssClasses AddClass(this string classes, bool condition, string? otherWhenTrue, string? otherWhenFalse)
    {
        return new CssClasses(classes).AddClass(condition, otherWhenTrue, otherWhenFalse);
    }

    /// <summary>
    /// Adds a class if the value is not null, using a function to get the value.
    /// </summary>
    /// <typeparam name="T">O Valor</typeparam>
    /// <param name="classes"></param>
    /// <param name="value"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public static CssClasses AddClass<T>(this string classes, T? value, Func<T, string?> func)
    {
        var cssClasses = new CssClasses(classes);
        return value is not null ? cssClasses.AddClass(func(value)) : cssClasses;
    }

    /// <summary>
    /// Adds a class if the value is not null, using a function to get the value.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="classes"></param>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public static CssClasses AddClass<T1, T2>(this string classes, T1? value1, T2? value2, Func<T1, T2, string?> func)
    {
        var cssClasses = new CssClasses(classes);
        return value1 is not null && value2 is not null ? cssClasses.AddClass(func(value1, value2)) : cssClasses;
    }
}