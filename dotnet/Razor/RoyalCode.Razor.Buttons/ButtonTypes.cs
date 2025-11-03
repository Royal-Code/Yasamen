
namespace RoyalCode.Razor;

/// <summary>
/// Button types, referring to the 'button' tag.
/// </summary>
public enum ButtonTypes
{
    /// <summary>
    /// A Button of button type.
    /// </summary>
    Button,

    /// <summary>
    /// Button to clear data, for example from search fields.
    /// </summary>
    Reset,

    /// <summary>
    /// Button to submit forms.
    /// </summary>
    Submit
}

/// <summary>
/// Extensions for ButtonType enum.
/// </summary>
public static class ButtonTypeExtensions
{
    /// <summary>
    /// Get the HTML attribute value for the button type.
    /// </summary>
    /// <param name="type">The button type.</param>
    /// <returns>The HTML attribute value.</returns>
    public static string ToHtmlAttr(this ButtonTypes type)
    {
        return type switch
        {
            ButtonTypes.Button => "button",
            ButtonTypes.Reset => "reset",
            ButtonTypes.Submit => "submit",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}