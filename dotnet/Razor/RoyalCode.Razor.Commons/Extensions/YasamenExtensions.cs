using RoyalCode.Razor.Styles;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace RoyalCode.Razor.Commons.Extensions;

/// <summary>
/// General purpose extensions for Yasamen.
/// </summary>
public static partial class YasamenExtensions
{
    private static readonly string IdChars = "abcdefghijklmnopqrstuvwxyz";
    
    [GeneratedRegex(@"[^a-zA-Z0-9\-\\_]")]
    private static partial Regex SafeHtmlRegex();

    /// <summary>
    /// Generates an ID with 10 random lowercase letters.
    /// </summary>
    /// <returns></returns>
    public static string GenerateId()
    {
        var result = new string(
            Enumerable.Repeat(IdChars, 10)
                .Select(s => s[RandomNumberGenerator.GetInt32(s.Length)])
                .ToArray());

        return result;
    }

    /// <summary>
    /// Transforms a string into a valid ID for HTML elements.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ToHtmlId(this string? s)
    {
        if (s.IsMissing())
            return $"_{GenerateId()}";

        var encoded = HtmlEncoder.Default.Encode(s.Replace(" ", "-")).Replace(".", "--");

        // Remove invalid characters for ID in HTML,
        // anything that is not a letter, number, hyphen, underscore, or period
        encoded = SafeHtmlRegex().Replace(encoded, "");

        // Ensure the ID does not start with a number
        if (char.IsDigit(encoded[0]))
        {
            encoded = "_" + encoded;
        }

        return encoded;
    }

    /// <summary>
    /// Gets the default display name of a member.
    /// First attempts to obtain the value of the <see cref="DisplayNameAttribute"/>,
    /// then tries to obtain the value of the <see cref="DescriptionAttribute"/>,
    /// then tries to obtain the value of the <see cref="DisplayAttribute"/>
    /// and finally returns the name of the member.
    /// </summary>
    /// <param name="member"></param>
    /// <returns></returns>
    public static string GetDefaultDisplayName(this MemberInfo member)
    {
        if (member.TryGetAttribute<DisplayNameAttribute>(out var displayName))
        {
            return displayName.DisplayName;
        }
        if (member.TryGetAttribute<DescriptionAttribute>(out var description))
        {
            return description.Description;
        }
        if (member.TryGetAttribute<DisplayAttribute>(out var display) && display.Name.IsPresent())
        {
            return display.Name;
        }

        return member.Name.SplitPascalCase();
    }

    /// <summary>
    /// Attempts to obtain an attribute from a member.
    /// </summary>
    /// <typeparam name="TAttribute">The attribute type</typeparam>
    /// <param name="member">The member</param>
    /// <param name="attribute">The Attribute obtained</param>
    /// <returns>True if the attribute was obtained, false otherwise.</returns>
    public static bool TryGetAttribute<TAttribute>(this MemberInfo? member, [NotNullWhen(true)] out TAttribute? attribute)
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

    /// <summary>
    /// Function that splits a name in PascalCase format/standard into separate words.
    /// </summary>
    /// <example>
    /// <code>
    ///     var name = "SplitPascalCase";
    ///     var result = name.SplitPascalCase(); // "Split Pascal Case"
    ///     Console.WriteLine(result);
    ///     // Output: Split Pascal Case
    ///     
    ///     name = RTFDocument;
    ///     result = name.SplitPascalCase(); // "RTF Document"
    ///     Console.WriteLine(result);
    ///     // Output: RTF Document
    /// </code>
    /// </example>
    /// <param name="name">Any name in PascalCase format</param>
    /// <returns>The name separated by spaces</returns>
    public static string SplitPascalCase(this string? name)
    {
        if (name.IsMissing())
            return string.Empty;

        var sb = new StringBuilder();
        var last = 0;
        for (var i = 1; i < name.Length; i++)
        {
            if (char.IsUpper(name[i]))
            {
                if (i > last)
                {
                    sb.Append(name[last..i]);
                    sb.Append(' ');
                }
                last = i;
            }
        }
        sb.Append(name[last..]);
        return sb.ToString();
    }
}
