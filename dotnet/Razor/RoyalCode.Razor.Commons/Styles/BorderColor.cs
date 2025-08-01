namespace RoyalCode.Razor.Commons.Styles;

public readonly struct BorderColor
{
    private readonly string className;

    public BorderColor(Themes theme, Gradients gradients)
    {
        className = Map.GetClassName(theme, gradients);
    }

    public static BorderColor Default { get; } = new BorderColor(Themes.Default, Gradients.Default);

    public override string ToString()
    {
        return className;
    }

    public static implicit operator string(BorderColor borderColor) => borderColor.className;

    public static Builder With(Themes theme)
    {
        return new Builder(theme);
    }

    public static Builder Primary()
    {
        return new Builder(Themes.Primary);
    }

    public static Builder Secondary()
    {
        return new Builder(Themes.Secondary);
    }

    public static Builder Tertiary()
    {
        return new Builder(Themes.Tertiary);
    }

    public static Builder Info()
    {
        return new Builder(Themes.Info);
    }

    public static Builder Highlight()
    {
        return new Builder(Themes.Highlight);
    }

    public static Builder Success()
    {
        return new Builder(Themes.Success);
    }

    public static Builder Warning()
    {
        return new Builder(Themes.Warning);
    }

    public static Builder Alert()
    {
        return new Builder(Themes.Alert);
    }

    public static Builder Danger()
    {
        return new Builder(Themes.Danger);
    }

    public static Builder Light()
    {
        return new Builder(Themes.Light);
    }

    public static Builder Dark()
    {
        return new Builder(Themes.Dark);
    }

    public readonly struct Builder
    {
        private readonly Themes theme;
        public Builder(Themes theme)
        {
            this.theme = theme;
        }

        public BorderColor With(Gradients gradients)
        {
            return new BorderColor(theme, gradients);
        }

        public BorderColor White()
        {
            return new BorderColor(theme, Gradients.White);
        }

        public BorderColor Lightest()
        {
            return new BorderColor(theme, Gradients.Lightest);
        }

        public BorderColor Lighter()
        {
            return new BorderColor(theme, Gradients.Lighter);
        }

        public BorderColor Light()
        {
            return new BorderColor(theme, Gradients.Light);
        }

        public BorderColor Normal()
        {
            return new BorderColor(theme, Gradients.Normal);
        }

        public BorderColor Dark()
        {
            return new BorderColor(theme, Gradients.Dark);
        }

        public BorderColor Darker()
        {
            return new BorderColor(theme, Gradients.Darker);
        }

        public BorderColor Darkest()
        {
            return new BorderColor(theme, Gradients.Darkest);
        }

        public BorderColor Black()
        {
            return new BorderColor(theme, Gradients.Black);
        }
    }

    /// <summary>
    /// Maps the theme and gradient to a CSS class name.
    /// </summary>
    private sealed class Map
    {
        public static string GetClassName(Themes theme, Gradients gradients)
        {
            if (theme == Themes.Default)
                return string.Empty;

            return theme switch
            {
                Themes.Primary => gradients switch
                {
                    Gradients.Default => "border-primary",
                    Gradients.White => "border-primary-100",
                    Gradients.Lightest => "border-primary-200",
                    Gradients.Lighter => "border-primary-300",
                    Gradients.Light => "border-primary-400",
                    Gradients.Normal => "border-primary-500",
                    Gradients.Dark => "border-primary-600",
                    Gradients.Darker => "border-primary-700",
                    Gradients.Darkest => "border-primary-800",
                    Gradients.Black => "border-primary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Secondary => gradients switch
                {
                    Gradients.Default => "border-secondary",
                    Gradients.White => "border-secondary-100",
                    Gradients.Lightest => "border-secondary-200",
                    Gradients.Lighter => "border-secondary-300",
                    Gradients.Light => "border-secondary-400",
                    Gradients.Normal => "border-secondary-500",
                    Gradients.Dark => "border-secondary-600",
                    Gradients.Darker => "border-secondary-700",
                    Gradients.Darkest => "border-secondary-800",
                    Gradients.Black => "border-secondary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Tertiary => gradients switch
                {
                    Gradients.Default => "border-tertiary",
                    Gradients.White => "border-tertiary-100",
                    Gradients.Lightest => "border-tertiary-200",
                    Gradients.Lighter => "border-tertiary-300",
                    Gradients.Light => "border-tertiary-400",
                    Gradients.Normal => "border-tertiary-500",
                    Gradients.Dark => "border-tertiary-600",
                    Gradients.Darker => "border-tertiary-700",
                    Gradients.Darkest => "border-tertiary-800",
                    Gradients.Black => "border-tertiary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Info => gradients switch
                {
                    Gradients.Default => "border-info",
                    Gradients.White => "border-info-100",
                    Gradients.Lightest => "border-info-200",
                    Gradients.Lighter => "border-info-300",
                    Gradients.Light => "border-info-400",
                    Gradients.Normal => "border-info-500",
                    Gradients.Dark => "border-info-600",
                    Gradients.Darker => "border-info-700",
                    Gradients.Darkest => "border-info-800",
                    Gradients.Black => "border-info-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Highlight => gradients switch
                {
                    Gradients.Default => "border-highlight",
                    Gradients.White => "border-highlight-100",
                    Gradients.Lightest => "border-highlight-200",
                    Gradients.Lighter => "border-highlight-300",
                    Gradients.Light => "border-highlight-400",
                    Gradients.Normal => "border-highlight-500",
                    Gradients.Dark => "border-highlight-600",
                    Gradients.Darker => "border-highlight-700",
                    Gradients.Darkest => "border-highlight-800",
                    Gradients.Black => "border-highlight-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Success => gradients switch
                {
                    Gradients.Default => "border-success",
                    Gradients.White => "border-success-100",
                    Gradients.Lightest => "border-success-200",
                    Gradients.Lighter => "border-success-300",
                    Gradients.Light => "border-success-400",
                    Gradients.Normal => "border-success-500",
                    Gradients.Dark => "border-success-600",
                    Gradients.Darker => "border-success-700",
                    Gradients.Darkest => "border-success-800",
                    Gradients.Black => "border-success-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Warning => gradients switch
                {
                    Gradients.Default => "border-warning",
                    Gradients.White => "border-warning-100",
                    Gradients.Lightest => "border-warning-200",
                    Gradients.Lighter => "border-warning-300",
                    Gradients.Light => "border-warning-400",
                    Gradients.Normal => "border-warning-500",
                    Gradients.Dark => "border-warning-600",
                    Gradients.Darker => "border-warning-700",
                    Gradients.Darkest => "border-warning-800",
                    Gradients.Black => "border-warning-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Alert => gradients switch
                {
                    Gradients.Default => "border-alert",
                    Gradients.White => "border-alert-100",
                    Gradients.Lightest => "border-alert-200",
                    Gradients.Lighter => "border-alert-300",
                    Gradients.Light => "border-alert-400",
                    Gradients.Normal => "border-alert-500",
                    Gradients.Dark => "border-alert-600",
                    Gradients.Darker => "border-alert-700",
                    Gradients.Darkest => "border-alert-800",
                    Gradients.Black => "border-alert-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Danger => gradients switch
                {
                    Gradients.Default => "border-danger",
                    Gradients.White => "border-danger-100",
                    Gradients.Lightest => "border-danger-200",
                    Gradients.Lighter => "border-danger-300",
                    Gradients.Light => "border-danger-400",
                    Gradients.Normal => "border-danger-500",
                    Gradients.Dark => "border-danger-600",
                    Gradients.Darker => "border-danger-700",
                    Gradients.Darkest => "border-danger-800",
                    Gradients.Black => "border-danger-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Light => gradients switch
                {
                    Gradients.Default => "border-light",
                    Gradients.White => "border-light-100",
                    Gradients.Lightest => "border-light-200",
                    Gradients.Lighter => "border-light-300",
                    Gradients.Light => "border-light-400",
                    Gradients.Normal => "border-light-500",
                    Gradients.Dark => "border-light-600",
                    Gradients.Darker => "border-light-700",
                    Gradients.Darkest => "border-light-800",
                    Gradients.Black => "border-light-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Dark => gradients switch
                {
                    Gradients.Default => "border-dark",
                    Gradients.White => "border-dark-100",
                    Gradients.Lightest => "border-dark-200",
                    Gradients.Lighter => "border-dark-300",
                    Gradients.Light => "border-dark-400",
                    Gradients.Normal => "border-dark-500",
                    Gradients.Dark => "border-dark-600",
                    Gradients.Darker => "border-dark-700",
                    Gradients.Darkest => "border-dark-800",
                    Gradients.Black => "border-dark-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
            };
        }
    }
}
