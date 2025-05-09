
namespace RoyalCode.Yasamen.Components;

/// <summary>
/// The styles of the buttons, defining the appearance/theme of the button.
/// </summary>
public enum ButtonStyles
{
    None,
    Primary,
    Secondary,
    Success,
    Info,
    Warning,
    Danger,
    Light,
    Dark,
    Link,
}

/// <summary>
/// Extensions methods for <see cref="ButtonStyles"/>.
/// </summary>
public static class ButtonStylesExtensions
{
    /// <summary>
    /// Obtém a classe css do estilo do botão.
    /// </summary>
    /// <param name="styles"></param>
    /// <returns></returns>
    public static string ToCssClass(this ButtonStyles styles, bool outline = false)
    {
        return outline
            ? (styles switch
            {
                ButtonStyles.None => string.Empty,
                ButtonStyles.Primary => "btn-outline-primary",
                ButtonStyles.Secondary => "btn-outline-secondary",
                ButtonStyles.Success => "btn-outline-success",
                ButtonStyles.Info => "btn-outline-info",
                ButtonStyles.Warning => "btn-outline-warning",
                ButtonStyles.Danger => "btn-outline-danger",
                ButtonStyles.Light => "btn-outline-light",
                ButtonStyles.Dark => "btn-outline-dark",
                ButtonStyles.Link => "btn-outline-link",
                _ => throw new NotSupportedException("Button Styles Not Supported"),
            })
            : (styles switch
            {
                ButtonStyles.None => string.Empty,
                ButtonStyles.Primary => "btn-primary",
                ButtonStyles.Secondary => "btn-secondary",
                ButtonStyles.Success => "btn-success",
                ButtonStyles.Info => "btn-info",
                ButtonStyles.Warning => "btn-warning",
                ButtonStyles.Danger => "btn-danger",
                ButtonStyles.Light => "btn-light",
                ButtonStyles.Dark => "btn-dark",
                ButtonStyles.Link => "btn-link",
                _ => throw new NotSupportedException("Button Styles Not Supported"),
            });
    }

    //public static ThemeStyles ToTheme(this ButtonStyles style)
    //{
    //    return style switch
    //    {
    //        ButtonStyles.None => ThemeStyles.None,
    //        ButtonStyles.Primary => ThemeStyles.Primary,
    //        ButtonStyles.Secondary => ThemeStyles.Secondary,
    //        ButtonStyles.Success => ThemeStyles.Success,
    //        ButtonStyles.Info => ThemeStyles.Info,
    //        ButtonStyles.Warning => ThemeStyles.Warning,
    //        ButtonStyles.Danger => ThemeStyles.Danger,
    //        ButtonStyles.Light => ThemeStyles.Secondary,
    //        ButtonStyles.Dark => ThemeStyles.None,
    //        ButtonStyles.Link => ThemeStyles.Secondary,
    //        _ => throw new NotSupportedException("Button Styles Not Supported"),
    //    };
    //}
}