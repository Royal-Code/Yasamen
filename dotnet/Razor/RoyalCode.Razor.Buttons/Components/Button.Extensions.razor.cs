using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

/// <summary>
/// Extension methods for button-related functionality.
/// </summary>
public static class ButtonExtensions
{
    /// <summary>
    /// <para>
    ///     Returns the tailwindcss classes to set the button size.
    /// </para>
    /// <para>
    ///     Fonts and padding are adjusted according to the selected size.
    /// </para>
    /// </summary>
    /// <param name="size">The size to convert.</param>
    /// <returns>
    ///     The tailwindcss classes for the button size.
    /// </returns>
    public static string ToButtonSize(this Sizes size)
    {
        if (size == Sizes.Default)
            size = Sizes.Medium;

        return size switch
        {
            Sizes.Smallest => "ya-btn-2xs",
            Sizes.Smaller => "ya-btn-xs",
            Sizes.Small => "ya-btn-sm",
            Sizes.Medium => "ya-btn-md",
            Sizes.Large => "ya-btn-lg",
            Sizes.Larger => "ya-btn-xl",
            Sizes.Largest => "ya-btn-2xl",
            _ => string.Empty,
        };
    }

    /// <summary>
    /// Returns the CSS class string for a button based on the specified theme and style.
    /// Adds rounded borders and focus ring similar ao Bootstrap usando Tailwind.
    /// </summary>
    /// <remarks>
    ///     If the theme is set to Default, the Secondary theme is used instead.
    ///     Uses the custom design tokens defined in yasamen.css (@theme colors).
    /// </remarks>
    /// <param name="theme">The theme to apply to the button. Determines the color scheme of the button.</param>
    /// <param name="active">true to use the active button style; otherwise, false.</param>
    /// <param name="outline">true to use the outline button style; otherwise, false to use the filled style.</param>
    /// <returns>
    ///     A string containing the CSS classes for the button that correspond to the specified theme and style.
    ///     Returns an empty string if the theme is not recognized.
    /// </returns>
    public static string ToButtonTheme(this Themes theme, bool active, bool outline)
    {
        if (theme == Themes.Default)
            theme = Themes.Secondary;

        // Outline variants
        if (outline)
        {
            if (active)
            {
                return theme switch
                {
                    Themes.Primary => "ya-btn-primary-outline-active",
                    Themes.Secondary => "ya-btn-secondary-outline-active",
                    Themes.Tertiary => "ya-btn-tertiary-outline-active",
                    Themes.Info => "ya-btn-info-outline-active",
                    Themes.Highlight => "ya-btn-highlight-outline-active",
                    Themes.Success => "ya-btn-success-outline-active",
                    Themes.Warning => "ya-btn-warning-outline-active",
                    Themes.Alert => "ya-btn-alert-outline-active",
                    Themes.Danger => "ya-btn-danger-outline-active",
                    Themes.Light => "ya-btn-light-outline-active",
                    Themes.Dark => "ya-btn-dark-outline-active",
                    _ => string.Empty,
                };
            }

            return theme switch
            {
                Themes.Primary => "ya-btn-primary-outline",
                Themes.Secondary => "ya-btn-secondary-outline",
                Themes.Tertiary => "ya-btn-tertiary-outline",
                Themes.Info => "ya-btn-info-outline",
                Themes.Highlight => "ya-btn-highlight-outline",
                Themes.Success => "ya-btn-success-outline",
                Themes.Warning => "ya-btn-warning-outline",
                Themes.Alert => "ya-btn-alert-outline",
                Themes.Danger => "ya-btn-danger-outline",
                Themes.Light => "ya-btn-light-outline",
                Themes.Dark => "ya-btn-dark-outline",
                _ => string.Empty,
            };
        }

        // Filled variants
        if (active)
        {
            return theme switch
            {
                Themes.Primary => "ya-btn-primary-active",
                Themes.Secondary => "ya-btn-secondary-active",
                Themes.Tertiary => "ya-btn-tertiary-active",
                Themes.Info => "ya-btn-info-active",
                Themes.Highlight => "ya-btn-highlight-active",
                Themes.Success => "ya-btn-success-active",
                Themes.Warning => "ya-btn-warning-active",
                Themes.Alert => "ya-btn-alert-active",
                Themes.Danger => "ya-btn-danger-active",
                Themes.Light => "ya-btn-light-active",
                Themes.Dark => "ya-btn-dark-active",
                _ => string.Empty,
            };
        }

        return theme switch
        {
            Themes.Primary => "ya-btn-primary",
            Themes.Secondary => "ya-btn-secondary",
            Themes.Tertiary => "ya-btn-tertiary",
            Themes.Info => "ya-btn-info",
            Themes.Highlight => "ya-btn-highlight",
            Themes.Success => "ya-btn-success",
            Themes.Warning => "ya-btn-warning",
            Themes.Alert => "ya-btn-alert",
            Themes.Danger => "ya-btn-danger",
            Themes.Light => "ya-btn-light",
            Themes.Dark => "ya-btn-dark",
            _ => string.Empty,
        };
    }

    /// <summary>
    /// <para>
    ///     Returns the tailwindcss classes to set the icon button size.
    /// </para>
    /// <para>
    ///     Fonts and padding are adjusted according to the selected size.
    /// </para>
    /// </summary>
    /// <param name="size">The size to convert.</param>
    /// <returns>
    ///     The tailwindcss classes for the button size.
    /// </returns>
    public static string ToIconButtonSize(this Sizes size)
    {
        if (size == Sizes.Default)
            size = Sizes.Medium;

        return size switch
        {
            Sizes.Smallest => "ya-i-btn-2xs",
            Sizes.Smaller => "ya-i-btn-xs",
            Sizes.Small => "ya-i-btn-sm",
            Sizes.Medium => "ya-i-btn-md",
            Sizes.Large => "ya-i-btn-lg",
            Sizes.Larger => "ya-i-btn-xl",
            Sizes.Largest => "ya-i-btn-2xl",
            _ => string.Empty,
        };
    }

    /// <summary>
    /// Returns the CSS class string for a icon button based on the specified theme and style.
    /// </summary>
    /// <remarks>
    ///     If the theme is set to Default, the Secondary theme is used вместо этого.
    ///     Uses the custom design tokens defined in yasamen.css (@theme colors).
    /// </remarks>
    /// <param name="theme">The theme to apply to the icon button. Determines the color scheme of the icon button.</param>
    /// <param name="active">true to use the active button style; otherwise, false.</param>
    /// <param name="outline">true to use the outline button style; otherwise, false to use the filled style.</param>
    /// <returns>
    ///     A string containing the CSS classes for the button that correspond to the specified theme and style.
    ///     Returns an empty string if the theme is not recognized.
    /// </returns>
    public static string ToIconButtonTheme(this Themes theme, bool active, bool outline)
    {
        if (theme == Themes.Default)
            theme = Themes.Secondary;

        if (outline)
        {
            if (active)
            {
                return theme switch
                {
                    Themes.Primary => "ya-i-btn-primary-outline-active",
                    Themes.Secondary => "ya-i-btn-secondary-outline-active",
                    Themes.Tertiary => "ya-i-btn-tertiary-outline-active",
                    Themes.Info => "ya-i-btn-info-outline-active",
                    Themes.Highlight => "ya-i-btn-highlight-outline-active",
                    Themes.Success => "ya-i-btn-success-outline-active",
                    Themes.Warning => "ya-i-btn-warning-outline-active",
                    Themes.Alert => "ya-i-btn-alert-outline-active",
                    Themes.Danger => "ya-i-btn-danger-outline-active",
                    Themes.Light => "ya-i-btn-light-outline-active",
                    Themes.Dark => "ya-i-btn-dark-outline-active",
                    _ => string.Empty,
                };
            }

            return theme switch
            {
                Themes.Primary => "ya-i-btn-primary-outline",
                Themes.Secondary => "ya-i-btn-secondary-outline",
                Themes.Tertiary => "ya-i-btn-tertiary-outline",
                Themes.Info => "ya-i-btn-info-outline",
                Themes.Highlight => "ya-i-btn-highlight-outline",
                Themes.Success => "ya-i-btn-success-outline",
                Themes.Warning => "ya-i-btn-warning-outline",
                Themes.Alert => "ya-i-btn-alert-outline",
                Themes.Danger => "ya-i-btn-danger-outline",
                Themes.Light => "ya-i-btn-light-outline",
                Themes.Dark => "ya-i-btn-dark-outline",
                _ => string.Empty,
            };
        }

        if (active)
        {
            return theme switch
            {
                Themes.Primary => "ya-i-btn-primary-active",
                Themes.Secondary => "ya-i-btn-secondary-active",
                Themes.Tertiary => "ya-i-btn-tertiary-active",
                Themes.Info => "ya-i-btn-info-active",
                Themes.Highlight => "ya-i-btn-highlight-active",
                Themes.Success => "ya-i-btn-success-active",
                Themes.Warning => "ya-i-btn-warning-active",
                Themes.Alert => "ya-i-btn-alert-active",
                Themes.Danger => "ya-i-btn-danger-active",
                Themes.Light => "ya-i-btn-light-active",
                Themes.Dark => "ya-i-btn-dark-active",
                _ => string.Empty,
            };
        }

        return theme switch
        {
            Themes.Primary => "ya-i-btn-primary",
            Themes.Secondary => "ya-i-btn-secondary",
            Themes.Tertiary => "ya-i-btn-tertiary",
            Themes.Info => "ya-i-btn-info",
            Themes.Highlight => "ya-i-btn-highlight",
            Themes.Success => "ya-i-btn-success",
            Themes.Warning => "ya-i-btn-warning",
            Themes.Alert => "ya-i-btn-alert",
            Themes.Danger => "ya-i-btn-danger",
            Themes.Light => "ya-i-btn-light",
            Themes.Dark => "ya-i-btn-dark",
            _ => string.Empty,
        };
    }
}