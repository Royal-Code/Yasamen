namespace RoyalCode.Razor.Styles;

public readonly struct BgColor
{
    private readonly string className;

    public BgColor(Themes themes, Gradients gradients)
    {
        className = Map.GetClassName(themes, gradients);
    }

    private BgColor(string className)
    {
        this.className = className;
    }

    public static BgColor Default => new BgColor(Themes.Default, Gradients.Default);

    public static BgColor White => new BgColor(Themes.Light, Gradients.White);

    public static BgColor Black => new BgColor(Themes.Dark, Gradients.Black);

    public static BgColor Transparent => new BgColor("bg-transparent");

    public static BgColor Current => new BgColor("bg-current");

    public static BgColor Inherit => new BgColor("bg-inherit");

    public static Builder Primary => new Builder(Themes.Primary);

    public static Builder Secondary => new Builder(Themes.Secondary);

    public static Builder Tertiary => new Builder(Themes.Tertiary);

    public static Builder Info => new Builder(Themes.Info);

    public static Builder Highlight => new Builder(Themes.Highlight);

    public static Builder Success => new Builder(Themes.Success);

    public static Builder Warning => new Builder(Themes.Warning);

    public static Builder Alert => new Builder(Themes.Alert);

    public static Builder Danger => new Builder(Themes.Danger);

    public static Builder Light => new Builder(Themes.Light);

    public static Builder Dark => new Builder(Themes.Dark);

    public static Builder With(Themes theme) => new Builder(theme);

    public override string ToString() => className;

    public static implicit operator string(BgColor bgColor) => bgColor.className;

    public readonly struct Builder
    {
        private readonly Themes Themes;

        public Builder(Themes themes)
        {
            Themes = themes;
        }

        public static implicit operator BgColor(Builder builder)
        {
            return new BgColor(builder.Themes, Gradients.Default);
        }

        public static implicit operator string(Builder builder)
        {
            return Map.GetClassName(builder.Themes, Gradients.Default);
        }

        public BgColor With(Gradients gradients)
        {
            return new BgColor(Themes, gradients);
        }

        public BgColor Default()
        {
            return new BgColor(Themes, Gradients.Default);
        }

        public BgColor White()
        {
            return new BgColor(Themes, Gradients.White);
        }

        public BgColor Lightest()
        {
            return new BgColor(Themes, Gradients.Lightest);
        }

        public BgColor Lighter()
        {
            return new BgColor(Themes, Gradients.Lighter);
        }

        public BgColor Light()
        {
            return new BgColor(Themes, Gradients.Light);
        }

        public BgColor Normal()
        {
            return new BgColor(Themes, Gradients.Normal);
        }

        public BgColor Dark()
        {
            return new BgColor(Themes, Gradients.Dark);
        }

        public BgColor Darker()
        {
            return new BgColor(Themes, Gradients.Darker);
        }

        public BgColor Darkest()
        {
            return new BgColor(Themes, Gradients.Darkest);
        }

        public BgColor Black()
        {
            return new BgColor(Themes, Gradients.Black);
        }
    }

    /// <summary>
    /// Maps the theme and gradient to a CSS class name.
    /// </summary>
    private static class Map
    {
        public static string GetClassName(Themes themes, Gradients gradients)
        {
            if (themes == Themes.Default)
                return string.Empty;

            return themes switch
            {
                Themes.Primary => gradients switch
                {
                    Gradients.Default => "bg-primary",
                    Gradients.White => "bg-primary-100",
                    Gradients.Lightest => "bg-primary-200",
                    Gradients.Lighter => "bg-primary-300",
                    Gradients.Light => "bg-primary-400",
                    Gradients.Normal => "bg-primary-500",
                    Gradients.Dark => "bg-primary-600",
                    Gradients.Darker => "bg-primary-700",
                    Gradients.Darkest => "bg-primary-800",
                    Gradients.Black => "bg-primary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Secondary => gradients switch
                {
                    Gradients.Default => "bg-secondary",
                    Gradients.White => "bg-secondary-100",
                    Gradients.Lightest => "bg-secondary-200",
                    Gradients.Lighter => "bg-secondary-300",
                    Gradients.Light => "bg-secondary-400",
                    Gradients.Normal => "bg-secondary-500",
                    Gradients.Dark => "bg-secondary-600",
                    Gradients.Darker => "bg-secondary-700",
                    Gradients.Darkest => "bg-secondary-800",
                    Gradients.Black => "bg-secondary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Tertiary => gradients switch
                {
                    Gradients.Default => "bg-tertiary",
                    Gradients.White => "bg-tertiary-100",
                    Gradients.Lightest => "bg-tertiary-200",
                    Gradients.Lighter => "bg-tertiary-300",
                    Gradients.Light => "bg-tertiary-400",
                    Gradients.Normal => "bg-tertiary-500",
                    Gradients.Dark => "bg-tertiary-600",
                    Gradients.Darker => "bg-tertiary-700",
                    Gradients.Darkest => "bg-tertiary-800",
                    Gradients.Black => "bg-tertiary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Info => gradients switch
                {
                    Gradients.Default => "bg-info",
                    Gradients.White => "bg-info-100",
                    Gradients.Lightest => "bg-info-200",
                    Gradients.Lighter => "bg-info-300",
                    Gradients.Light => "bg-info-400",
                    Gradients.Normal => "bg-info-500",
                    Gradients.Dark => "bg-info-600",
                    Gradients.Darker => "bg-info-700",
                    Gradients.Darkest => "bg-info-800",
                    Gradients.Black => "bg-info-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Highlight => gradients switch
                {
                    Gradients.Default => "bg-highlight",
                    Gradients.White => "bg-highlight-100",
                    Gradients.Lightest => "bg-highlight-200",
                    Gradients.Lighter => "bg-highlight-300",
                    Gradients.Light => "bg-highlight-400",
                    Gradients.Normal => "bg-highlight-500",
                    Gradients.Dark => "bg-highlight-600",
                    Gradients.Darker => "bg-highlight-700",
                    Gradients.Darkest => "bg-highlight-800",
                    Gradients.Black => "bg-highlight-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Success => gradients switch
                {
                    Gradients.Default => "bg-success",
                    Gradients.White => "bg-success-100",
                    Gradients.Lightest => "bg-success-200",
                    Gradients.Lighter => "bg-success-300",
                    Gradients.Light => "bg-success-400",
                    Gradients.Normal => "bg-success-500",
                    Gradients.Dark => "bg-success-600",
                    Gradients.Darker => "bg-success-700",
                    Gradients.Darkest => "bg-success-800",
                    Gradients.Black => "bg-success-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Warning => gradients switch
                {
                    Gradients.Default => "bg-warning",
                    Gradients.White => "bg-warning-100",
                    Gradients.Lightest => "bg-warning-200",
                    Gradients.Lighter => "bg-warning-300",
                    Gradients.Light => "bg-warning-400",
                    Gradients.Normal => "bg-warning-500",
                    Gradients.Dark => "bg-warning-600",
                    Gradients.Darker => "bg-warning-700",
                    Gradients.Darkest => "bg-warning-800",
                    Gradients.Black => "bg-warning-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Alert => gradients switch
                {
                    Gradients.Default => "bg-alert",
                    Gradients.White => "bg-alert-100",
                    Gradients.Lightest => "bg-alert-200",
                    Gradients.Lighter => "bg-alert-300",
                    Gradients.Light => "bg-alert-400",
                    Gradients.Normal => "bg-alert-500",
                    Gradients.Dark => "bg-alert-600",
                    Gradients.Darker => "bg-alert-700",
                    Gradients.Darkest => "bg-alert-800",
                    Gradients.Black => "bg-alert-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Danger => gradients switch
                {
                    Gradients.Default => "bg-danger",
                    Gradients.White => "bg-danger-100",
                    Gradients.Lightest => "bg-danger-200",
                    Gradients.Lighter => "bg-danger-300",
                    Gradients.Light => "bg-danger-400",
                    Gradients.Normal => "bg-danger-500",
                    Gradients.Dark => "bg-danger-600",
                    Gradients.Darker => "bg-danger-700",
                    Gradients.Darkest => "bg-danger-800",
                    Gradients.Black => "bg-danger-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Light => gradients switch
                {
                    Gradients.Default => "bg-light",
                    Gradients.White => "bg-light-100",
                    Gradients.Lightest => "bg-light-200",
                    Gradients.Lighter => "bg-light-300",
                    Gradients.Light => "bg-light-400",
                    Gradients.Normal => "bg-light-500",
                    Gradients.Dark => "bg-light-600",
                    Gradients.Darker => "bg-light-700",
                    Gradients.Darkest => "bg-light-800",
                    Gradients.Black => "bg-light-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Dark => gradients switch
                {
                    Gradients.Default => "bg-dark",
                    Gradients.White => "bg-dark-100",
                    Gradients.Lightest => "bg-dark-200",
                    Gradients.Lighter => "bg-dark-300",
                    Gradients.Light => "bg-dark-400",
                    Gradients.Normal => "bg-dark-500",
                    Gradients.Dark => "bg-dark-600",
                    Gradients.Darker => "bg-dark-700",
                    Gradients.Darkest => "bg-dark-800",
                    Gradients.Black => "bg-dark-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
            };
        }
    }
}