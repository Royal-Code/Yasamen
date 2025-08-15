namespace RoyalCode.Razor.Commons.Extensions;

/// <summary>
/// Utility extension methods to work with the <c>AdditionalAttributes</c> dictionary
/// used in Blazor components (parameter with <c>CaptureUnmatchedValues=true</c>),
/// allowing extraction and interpretation of additional HTML attributes.
/// </summary>
public static class AdditionalAttributesExtensions
{
    /// <summary>
    /// Extracts the value for a given key from the additional attributes dictionary.
    /// <br />
    /// Removes the entry from the dictionary after extraction so it is not rendered again by Blazor.
    /// </summary>
    /// <param name="additionalAttributes">Additional attributes dictionary (<c>AdditionalAttributes</c>).</param>
    /// <param name="key">Name of the attribute to extract.</param>
    /// <param name="defaultValue">Default value returned when the key does not exist or the value is null.</param>
    /// <returns>The value converted to <see cref="string"/> if it exists; otherwise <paramref name="defaultValue"/>.</returns>
    public static string Extract(this IDictionary<string, object>? additionalAttributes, 
        string key, string defaultValue = "")
    {
        if (additionalAttributes is null
            || !additionalAttributes.TryGetValue(key, out var value)
            || value is null)
        {
            return defaultValue;
        }

        // Remove the key from the dictionary to prevent it from being processed again
        additionalAttributes.Remove(key);

        return value is string s ? s : value.ToString() ?? defaultValue;
    }

    /// <summary>
    /// Extracts the <c>class</c> attribute from the additional attributes.
    /// </summary>
    /// <param name="additionalAttributes">Additional attributes dictionary.</param>
    /// <returns>The value of the <c>class</c> attribute or <see cref="string.Empty"/>.</returns>
    public static string ExtractClass(this IDictionary<string, object>? additionalAttributes)
        => Extract(additionalAttributes, "class", string.Empty);

    /// <summary>
    /// Checks whether a key is present in the additional attributes dictionary.
    /// </summary>
    /// <param name="additionalAttributes">Additional attributes dictionary.</param>
    /// <param name="key">Key to check.</param>
    /// <returns><c>true</c> if the key exists; otherwise, <c>false</c>.</returns>
    public static bool Has(this IDictionary<string, object>? additionalAttributes, string key)
    {
        return additionalAttributes is not null
               && additionalAttributes.ContainsKey(key);
    }

    /// <summary>
    /// Indicates whether a boolean-like attribute is present and considered true.
    /// <br />
    /// Useful for HTML attributes such as <c>disabled</c>, <c>checked</c>, <c>required</c>, etc.
    /// <br />
    /// The presence of the attribute with a <c>null</c> value counts as true.
    /// <br />
    /// If the value is explicitly a boolean, its value is returned.
    /// </summary>
    /// <param name="additionalAttributes">Additional attributes dictionary.</param>
    /// <param name="key">Name of the boolean attribute.</param>
    /// <returns><c>true</c> if the attribute exists and is considered true; otherwise, <c>false</c>.</returns>
    public static bool Is(this IDictionary<string, object>? additionalAttributes, string key)
    {
        if (additionalAttributes is null || !additionalAttributes.TryGetValue(key, out var value))
        {
            return false;
        }

        // when value is null, we consider it as true
        // this is useful for boolean attributes like "disabled", "checked", etc.
        // where the presence of the attribute itself is enough to indicate its truthiness.
        // when present, we check if it's a boolean and return its value.
        return value is null ? true : value is bool b && b;
    }
}
