using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor;

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
            Sizes.Smallest => "text-xs px-3 py-1 focus-within:ring-2 rounded-sm",
            Sizes.Smaller => "text-sm px-4 py-2 focus-within:ring-3 rounded-sm",
            Sizes.Small => "text-base px-4 py-2 focus-within:ring-4 rounded-md",
            Sizes.Medium => "text-base px-5 py-3 focus-within:ring-4 rounded-md",
            Sizes.Large => "text-base px-6 py-4 focus-within:ring-4 rounded-md",
            Sizes.Larger => "text-xl px-6 py-4 focus-within:ring-5 rounded-lg",
            Sizes.Largest => "text-2xl px-7 py-4 focus-within:ring-6 rounded-lg",
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

        if (outline)
        {
            if (active)
            {
                return theme switch
                {
                    Themes.Primary => "text-primary-600 bg-primary-200 focus-within:ring-primary-600/50",
                    Themes.Secondary => "text-secondary-600 bg-secondary-200 focus-within:ring-secondary-600/50",
                    Themes.Tertiary => "text-tertiary-600 bg-tertiary-200 focus-within:ring-tertiary-600/50",
                    Themes.Info => "text-info-600 bg-info-200 focus-within:ring-info-600/50",
                    Themes.Highlight => "text-highlight-600 bg-highlight-200 focus-within:ring-highlight-600/50",
                    Themes.Success => "text-success-600 bg-success-200 focus-within:ring-success-600/50",
                    Themes.Warning => "text-warning-600 bg-warning-200 focus-within:ring-warning-600/50",
                    Themes.Alert => "text-alert-600 bg-alert-200 focus-within:ring-alert-600/50",
                    Themes.Danger => "text-danger-600 bg-danger-200 focus-within:ring-danger-600/50",
                    Themes.Light => "text-light-700 bg-light-200 focus-within:ring-light-700/50",
                    Themes.Dark => "text-dark-700 bg-dark-200 focus-within:ring-dark-700/50",
                    _ => string.Empty,
                };
            }

            return theme switch
            {
                Themes.Primary => $"text-primary-600 border-primary-600 bg-white hover:bg-primary-100 active:bg-primary-200 focus-within:bg-primary-100 focus-within:ring-primary-600/50",
                Themes.Secondary => $"text-secondary-600 border-secondary-600 bg-white hover:bg-secondary-100 active:bg-secondary-200 focus-within:bg-secondary-100 focus-within:ring-secondary-600/50",
                Themes.Tertiary => $"text-tertiary-600 border-tertiary-600 bg-white hover:bg-tertiary-100 active:bg-tertiary-200 focus-within:bg-tertiary-100 focus-within:ring-tertiary-600/50",
                Themes.Info => $"text-info-600 border-info-600 bg-white hover:bg-info-100 active:bg-info-200 focus-within:bg-info-100 focus-within:ring-info-600/50",
                Themes.Highlight => $"text-highlight-600 border-highlight-600 bg-white hover:bg-highlight-100 active:bg-highlight-200 focus-within:bg-highlight-100 focus-within:ring-highlight-600/50",
                Themes.Success => $"text-success-600 border-success-600 bg-white hover:bg-success-100 active:bg-success-200 focus-within:bg-success-100 focus-within:ring-success-600/50",
                Themes.Warning => $"text-warning-600 border-warning-600 bg-white hover:bg-warning-100 active:bg-warning-200 focus-within:bg-warning-100 focus-within:ring-warning-600/50",
                Themes.Alert => $"text-alert-600 border-alert-600 bg-white hover:bg-alert-100 active:bg-alert-200 focus-within:bg-alert-100 focus-within:ring-alert-600/50",
                Themes.Danger => $"text-danger-600 border-danger-600 bg-white hover:bg-danger-100 active:bg-danger-200 focus-within:bg-danger-100 focus-within:ring-danger-600/50",
                Themes.Light => $"text-light-700 border-light-700 bg-white hover:bg-light-100 active:bg-light-200 focus-within:bg-light-100 focus-within:ring-light-700/50",
                Themes.Dark => $"text-dark-700 border-dark-700 bg-white hover:bg-dark-100 active:bg-dark-200 focus-within:bg-dark-100 focus-within:ring-dark-700/50",
                _ => string.Empty,
            };
        }

        if (active)
        {
            return theme switch
            {
                Themes.Primary => $"text-white bg-primary-700 border-primary-400 focus-within:ring-primary-300/50",
                Themes.Secondary => $"text-white bg-secondary-700 border-secondary-400 focus-within:ring-secondary-300/50",
                Themes.Tertiary => $"text-white bg-tertiary-700 border-tertiary-400 focus-within:ring-tertiary-300/50",
                Themes.Info => $"text-white bg-info-700 border-info-400 focus-within:ring-info-300/50",
                Themes.Highlight => $"text-white bg-highlight-700 border-highlight-400 focus-within:ring-highlight-300/50",
                Themes.Success => $"text-dark-900 bg-success-700 border-success-400 focus-within:ring-success-300/50",
                Themes.Warning => $"text-dark-900 bg-warning-700 border-warning-400 focus-within:ring-warning-300/50",
                Themes.Alert => $"text-dark-900 bg-alert-700 border-alert-400 focus-within:ring-alert-300/50",
                Themes.Danger => $"text-white bg-danger-700 border-danger-400 focus-within:ring-danger-300/50",
                Themes.Light => $"text-dark-500 bg-light-300 border-light-400 focus-within:ring-light-300/50",
                Themes.Dark => $"text-white bg-dark-700 border-dark-400 focus-within:ring-dark-300/50",
                _ => string.Empty,
            };
        }

        return theme switch
        {
            Themes.Primary => $"bg-primary-400 text-white hover:bg-primary-600 active:bg-primary-700 border-primary-400 focus-within:ring-primary-300/50",
            Themes.Secondary => $"bg-secondary-400 text-white hover:bg-secondary-600 active:bg-secondary-700 border-secondary-400 focus-within:ring-secondary-300/50",
            Themes.Tertiary => $"bg-tertiary-400 text-white hover:bg-tertiary-600 active:bg-tertiary-700 border-tertiary-400 focus-within:ring-tertiary-300/50",
            Themes.Info => $"bg-info-400 text-white hover:bg-info-600 active:bg-info-700 border-info-400 focus-within:ring-info-300/50",
            Themes.Highlight => $"bg-highlight-400 text-white hover:bg-highlight-600 active:bg-highlight-700 border-highlight-400 focus-within:ring-highlight-300/50",
            Themes.Success => $"bg-success-400 text-dark-900 hover:bg-success-600 active:bg-success-700 border-success-400 focus-within:ring-success-300/50",
            Themes.Warning => $"bg-warning-400 text-dark-900 hover:bg-warning-600 active:bg-warning-700 border-warning-400 focus-within:ring-warning-300/50",
            Themes.Alert => $"bg-alert-400 text-dark-900 hover:bg-alert-600 active:bg-alert-700 border-alert-400 focus-within:ring-alert-300/50",
            Themes.Danger => $"bg-danger-400 text-white hover:bg-danger-600 active:bg-danger-700 border-danger-400 focus-within:ring-danger-300/50",
            Themes.Light => $"bg-light-100 text-dark-500 hover:bg-light-200 active:bg-light-300 border-light-400 focus-within:ring-light-300/50",
            Themes.Dark => $"bg-dark-400 text-white hover:bg-dark-600 active:bg-dark-700 border-dark-400 focus-within:ring-dark-300/50",
            _ => string.Empty,
        };
    }
}