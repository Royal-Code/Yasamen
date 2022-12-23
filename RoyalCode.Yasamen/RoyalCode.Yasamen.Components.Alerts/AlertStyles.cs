
namespace RoyalCode.Yasamen.Components;

/// <summary>
/// The styles of the alerts.
/// </summary>
public enum AlertStyles
{
    Primary,
    Secondary,
    Success,
    Danger,
    Warning,
    Info,
    Light,
    Dark,
}

/// <summary>
/// <para>
///     Extensions methods for <see cref="AlertStyles"/>.
/// </para>
/// </summary>
public static class AlertStylesExtensions
{
    /// <summary>
    /// Get the css class name for the related style.
    /// </summary>
    /// <param name="style">The style.</param>
    /// <returns>The css class name.</returns>
    /// <exception cref="NotSupportedException">
    ///     The style is not supported.
    /// </exception>
    public static string ToCssClass(this AlertStyles style)
    {
        return style switch
        {
            AlertStyles.Primary => "alert-primary",
            AlertStyles.Secondary => "alert-secondary",
            AlertStyles.Success => "alert-success",
            AlertStyles.Danger => "alert-danger",
            AlertStyles.Warning => "alert-warning",
            AlertStyles.Info => "alert-info",
            AlertStyles.Light => "alert-light",
            AlertStyles.Dark => "alert-dark",
            _ => throw new NotSupportedException($"Alert style '{style}' is not supported.")
        };
    }
}