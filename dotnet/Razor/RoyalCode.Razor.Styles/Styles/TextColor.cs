namespace RoyalCode.Razor.Styles;

public readonly struct TextColor
{
    private readonly string className;

    public TextColor(Themes theme, Gradients gradients)
    {
        className = Map.GetClassName(theme, gradients);
    }

    public override string ToString()
    {
        return className;
    }

    public static implicit operator string(TextColor textColor) => textColor.className;

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

    public static TextColor Default { get; } = new TextColor(Themes.Default, Gradients.Default);

    public readonly struct Builder
    {
        private readonly Themes theme;
        
        internal Builder(Themes theme)
        {
            this.theme = theme;
        }
        
        public static implicit operator TextColor(Builder builder)
        {
            return new TextColor(builder.theme, Gradients.Default);
        }

        public static implicit operator string(Builder builder)
        {
            return new TextColor(builder.theme, Gradients.Default).className;
        }

        public TextColor With(Gradients gradients)
        {
            return new TextColor(theme, gradients);
        }
        
        public static TextColor Default()
        {
            return new TextColor(Themes.Default, Gradients.Default);
        }

        public static TextColor Normal()
        {
            return new TextColor(Themes.Primary, Gradients.Normal);
        }

        public static TextColor White()
        {
            return new TextColor(Themes.Primary, Gradients.White);
        }

        public static TextColor Lightest()
        {
            return new TextColor(Themes.Primary, Gradients.Lightest);
        }

        public static TextColor Lighter()
        {
            return new TextColor(Themes.Primary, Gradients.Lighter);
        }

        public static TextColor Light()
        {
            return new TextColor(Themes.Primary, Gradients.Light);
        }

        public static TextColor Dark()
        {
            return new TextColor(Themes.Primary, Gradients.Dark);
        }

        public static TextColor Darker()
        {
            return new TextColor(Themes.Primary, Gradients.Darker);
        }

        public static TextColor Darkest()
        {
            return new TextColor(Themes.Primary, Gradients.Darkest);
        }

        public static TextColor Black()
        {
            return new TextColor(Themes.Primary, Gradients.Black);
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
                    Gradients.Default => "text-primary",
                    Gradients.White => "text-primary-100",
                    Gradients.Lightest => "text-primary-200",
                    Gradients.Lighter => "text-primary-300",
                    Gradients.Light => "text-primary-400",
                    Gradients.Normal => "text-primary-500",
                    Gradients.Dark => "text-primary-600",
                    Gradients.Darker => "text-primary-700",
                    Gradients.Darkest => "text-primary-800",
                    Gradients.Black => "text-primary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Secondary => gradients switch
                {
                    Gradients.Default => "text-secondary",
                    Gradients.White => "text-secondary-100",
                    Gradients.Lightest => "text-secondary-200",
                    Gradients.Lighter => "text-secondary-300",
                    Gradients.Light => "text-secondary-400",
                    Gradients.Normal => "text-secondary-500",
                    Gradients.Dark => "text-secondary-600",
                    Gradients.Darker => "text-secondary-700",
                    Gradients.Darkest => "text-secondary-800",
                    Gradients.Black => "text-secondary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Tertiary => gradients switch
                {
                    Gradients.Default => "text-tertiary",
                    Gradients.White => "text-tertiary-100",
                    Gradients.Lightest => "text-tertiary-200",
                    Gradients.Lighter => "text-tertiary-300",
                    Gradients.Light => "text-tertiary-400",
                    Gradients.Normal => "text-tertiary-500",
                    Gradients.Dark => "text-tertiary-600",
                    Gradients.Darker => "text-tertiary-700",
                    Gradients.Darkest => "text-tertiary-800",
                    Gradients.Black => "text-tertiary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Info => gradients switch
                {
                    Gradients.Default => "text-info",
                    Gradients.White => "text-info-100",
                    Gradients.Lightest => "text-info-200",
                    Gradients.Lighter => "text-info-300",
                    Gradients.Light => "text-info-400",
                    Gradients.Normal => "text-info-500",
                    Gradients.Dark => "text-info-600",
                    Gradients.Darker => "text-info-700",
                    Gradients.Darkest => "text-info-800",
                    Gradients.Black => "text-info-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Highlight => gradients switch
                {
                    Gradients.Default => "text-highlight",
                    Gradients.White => "text-highlight-100",
                    Gradients.Lightest => "text-highlight-200",
                    Gradients.Lighter => "text-highlight-300",
                    Gradients.Light => "text-highlight-400",
                    Gradients.Normal => "text-highlight-500",
                    Gradients.Dark => "text-highlight-600",
                    Gradients.Darker => "text-highlight-700",
                    Gradients.Darkest => "text-highlight-800",
                    Gradients.Black => "text-highlight-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Success => gradients switch
                {
                    Gradients.Default => "text-success",
                    Gradients.White => "text-success-100",
                    Gradients.Lightest => "text-success-200",
                    Gradients.Lighter => "text-success-300",
                    Gradients.Light => "text-success-400",
                    Gradients.Normal => "text-success-500",
                    Gradients.Dark => "text-success-600",
                    Gradients.Darker => "text-success-700",
                    Gradients.Darkest => "text-success-800",
                    Gradients.Black => "text-success-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Warning => gradients switch
                {
                    Gradients.Default => "text-warning",
                    Gradients.White => "text-warning-100",
                    Gradients.Lightest => "text-warning-200",
                    Gradients.Lighter => "text-warning-300",
                    Gradients.Light => "text-warning-400",
                    Gradients.Normal => "text-warning-500",
                    Gradients.Dark => "text-warning-600",
                    Gradients.Darker => "text-warning-700",
                    Gradients.Darkest => "text-warning-800",
                    Gradients.Black => "text-warning-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Alert => gradients switch
                {
                    Gradients.Default => "text-alert",
                    Gradients.White => "text-alert-100",
                    Gradients.Lightest => "text-alert-200",
                    Gradients.Lighter => "text-alert-300",
                    Gradients.Light => "text-alert-400",
                    Gradients.Normal => "text-alert-500",
                    Gradients.Dark => "text-alert-600",
                    Gradients.Darker => "text-alert-700",
                    Gradients.Darkest => "text-alert-800",
                    Gradients.Black => "text-alert-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Danger => gradients switch
                {
                    Gradients.Default => "text-danger",
                    Gradients.White => "text-danger-100",
                    Gradients.Lightest => "text-danger-200",
                    Gradients.Lighter => "text-danger-300",
                    Gradients.Light => "text-danger-400",
                    Gradients.Normal => "text-danger-500",
                    Gradients.Dark => "text-danger-600",
                    Gradients.Darker => "text-danger-700",
                    Gradients.Darkest => "text-danger-800",
                    Gradients.Black => "text-danger-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Light => gradients switch
                {
                    Gradients.Default => "text-light",
                    Gradients.White => "text-light-100",
                    Gradients.Lightest => "text-light-200",
                    Gradients.Lighter => "text-light-300",
                    Gradients.Light => "text-light-400",
                    Gradients.Normal => "text-light-500",
                    Gradients.Dark => "text-light-600",
                    Gradients.Darker => "text-light-700",
                    Gradients.Darkest => "text-light-800",
                    Gradients.Black => "text-light-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Dark => gradients switch
                {
                    Gradients.Default => "text-dark",
                    Gradients.White => "text-dark-100",
                    Gradients.Lightest => "text-dark-200",
                    Gradients.Lighter => "text-dark-300",
                    Gradients.Light => "text-dark-400",
                    Gradients.Normal => "text-dark-500",
                    Gradients.Dark => "text-dark-600",
                    Gradients.Darker => "text-dark-700",
                    Gradients.Darkest => "text-dark-800",
                    Gradients.Black => "text-dark-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
            };
        }
    }
}
