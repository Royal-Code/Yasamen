namespace RoyalCode.Razor.Styles;

public readonly struct OutlineColor
{
    private readonly string className;

    public OutlineColor(Themes theme, Gradients gradients)
    {
        className = Map.GetClassName(theme, gradients);
    }

    private OutlineColor(string className)
    {
        this.className = className;
    }

    public static OutlineColor Default => new OutlineColor(Themes.Default, Gradients.Default);
    public static OutlineColor White => new OutlineColor(Themes.Light, Gradients.White);
    public static OutlineColor Black => new OutlineColor(Themes.Dark, Gradients.Black);
    public static OutlineColor Transparent => new OutlineColor("outline-transparent");
    public static OutlineColor Current => new OutlineColor("outline-current");
    public static OutlineColor Inherit => new OutlineColor("outline-inherit");

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
    public static implicit operator string(OutlineColor outlineColor) => outlineColor.className;

    public readonly struct Builder
    {
        private readonly Themes theme;

        public Builder(Themes theme) { this.theme = theme; }

        public static implicit operator OutlineColor(Builder builder) => new OutlineColor(builder.theme, Gradients.Default);
        public static implicit operator string(Builder builder) => Map.GetClassName(builder.theme, Gradients.Default);
        
        public OutlineColor With(Gradients gradients) => new OutlineColor(theme, gradients);
        
        public OutlineColor Default() => new OutlineColor(theme, Gradients.Default);
        
        public OutlineColor White() => new OutlineColor(theme, Gradients.White);
        public OutlineColor Lightest() => new OutlineColor(theme, Gradients.Lightest);
        public OutlineColor Lighter() => new OutlineColor(theme, Gradients.Lighter);
        public OutlineColor Light() => new OutlineColor(theme, Gradients.Light);
        public OutlineColor Normal() => new OutlineColor(theme, Gradients.Normal);
        public OutlineColor Dark() => new OutlineColor(theme, Gradients.Dark);
        public OutlineColor Darker() => new OutlineColor(theme, Gradients.Darker);
        public OutlineColor Darkest() => new OutlineColor(theme, Gradients.Darkest);
        public OutlineColor Black() => new OutlineColor(theme, Gradients.Black);
    }

    private static class Map
    {
        public static string GetClassName(Themes theme, Gradients gradients)
        {
            if (theme == Themes.Default)
                return string.Empty;

            return theme switch
            {
                Themes.Primary => gradients switch
                {
                    Gradients.Default => "outline-primary",
                    Gradients.White => "outline-primary-100",
                    Gradients.Lightest => "outline-primary-200",
                    Gradients.Lighter => "outline-primary-300",
                    Gradients.Light => "outline-primary-400",
                    Gradients.Normal => "outline-primary-500",
                    Gradients.Dark => "outline-primary-600",
                    Gradients.Darker => "outline-primary-700",
                    Gradients.Darkest => "outline-primary-800",
                    Gradients.Black => "outline-primary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Secondary => gradients switch
                {
                    Gradients.Default => "outline-secondary",
                    Gradients.White => "outline-secondary-100",
                    Gradients.Lightest => "outline-secondary-200",
                    Gradients.Lighter => "outline-secondary-300",
                    Gradients.Light => "outline-secondary-400",
                    Gradients.Normal => "outline-secondary-500",
                    Gradients.Dark => "outline-secondary-600",
                    Gradients.Darker => "outline-secondary-700",
                    Gradients.Darkest => "outline-secondary-800",
                    Gradients.Black => "outline-secondary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Tertiary => gradients switch
                {
                    Gradients.Default => "outline-tertiary",
                    Gradients.White => "outline-tertiary-100",
                    Gradients.Lightest => "outline-tertiary-200",
                    Gradients.Lighter => "outline-tertiary-300",
                    Gradients.Light => "outline-tertiary-400",
                    Gradients.Normal => "outline-tertiary-500",
                    Gradients.Dark => "outline-tertiary-600",
                    Gradients.Darker => "outline-tertiary-700",
                    Gradients.Darkest => "outline-tertiary-800",
                    Gradients.Black => "outline-tertiary-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Info => gradients switch
                {
                    Gradients.Default => "outline-info",
                    Gradients.White => "outline-info-100",
                    Gradients.Lightest => "outline-info-200",
                    Gradients.Lighter => "outline-info-300",
                    Gradients.Light => "outline-info-400",
                    Gradients.Normal => "outline-info-500",
                    Gradients.Dark => "outline-info-600",
                    Gradients.Darker => "outline-info-700",
                    Gradients.Darkest => "outline-info-800",
                    Gradients.Black => "outline-info-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Highlight => gradients switch
                {
                    Gradients.Default => "outline-highlight",
                    Gradients.White => "outline-highlight-100",
                    Gradients.Lightest => "outline-highlight-200",
                    Gradients.Lighter => "outline-highlight-300",
                    Gradients.Light => "outline-highlight-400",
                    Gradients.Normal => "outline-highlight-500",
                    Gradients.Dark => "outline-highlight-600",
                    Gradients.Darker => "outline-highlight-700",
                    Gradients.Darkest => "outline-highlight-800",
                    Gradients.Black => "outline-highlight-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Success => gradients switch
                {
                    Gradients.Default => "outline-success",
                    Gradients.White => "outline-success-100",
                    Gradients.Lightest => "outline-success-200",
                    Gradients.Lighter => "outline-success-300",
                    Gradients.Light => "outline-success-400",
                    Gradients.Normal => "outline-success-500",
                    Gradients.Dark => "outline-success-600",
                    Gradients.Darker => "outline-success-700",
                    Gradients.Darkest => "outline-success-800",
                    Gradients.Black => "outline-success-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Warning => gradients switch
                {
                    Gradients.Default => "outline-warning",
                    Gradients.White => "outline-warning-100",
                    Gradients.Lightest => "outline-warning-200",
                    Gradients.Lighter => "outline-warning-300",
                    Gradients.Light => "outline-warning-400",
                    Gradients.Normal => "outline-warning-500",
                    Gradients.Dark => "outline-warning-600",
                    Gradients.Darker => "outline-warning-700",
                    Gradients.Darkest => "outline-warning-800",
                    Gradients.Black => "outline-warning-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Alert => gradients switch
                {
                    Gradients.Default => "outline-alert",
                    Gradients.White => "outline-alert-100",
                    Gradients.Lightest => "outline-alert-200",
                    Gradients.Lighter => "outline-alert-300",
                    Gradients.Light => "outline-alert-400",
                    Gradients.Normal => "outline-alert-500",
                    Gradients.Dark => "outline-alert-600",
                    Gradients.Darker => "outline-alert-700",
                    Gradients.Darkest => "outline-alert-800",
                    Gradients.Black => "outline-alert-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Danger => gradients switch
                {
                    Gradients.Default => "outline-danger",
                    Gradients.White => "outline-danger-100",
                    Gradients.Lightest => "outline-danger-200",
                    Gradients.Lighter => "outline-danger-300",
                    Gradients.Light => "outline-danger-400",
                    Gradients.Normal => "outline-danger-500",
                    Gradients.Dark => "outline-danger-600",
                    Gradients.Darker => "outline-danger-700",
                    Gradients.Darkest => "outline-danger-800",
                    Gradients.Black => "outline-danger-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Light => gradients switch
                {
                    Gradients.Default => "outline-light",
                    Gradients.White => "outline-light-100",
                    Gradients.Lightest => "outline-light-200",
                    Gradients.Lighter => "outline-light-300",
                    Gradients.Light => "outline-light-400",
                    Gradients.Normal => "outline-light-500",
                    Gradients.Dark => "outline-light-600",
                    Gradients.Darker => "outline-light-700",
                    Gradients.Darkest => "outline-light-800",
                    Gradients.Black => "outline-light-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                Themes.Dark => gradients switch
                {
                    Gradients.Default => "outline-dark",
                    Gradients.White => "outline-dark-100",
                    Gradients.Lightest => "outline-dark-200",
                    Gradients.Lighter => "outline-dark-300",
                    Gradients.Light => "outline-dark-400",
                    Gradients.Normal => "outline-dark-500",
                    Gradients.Dark => "outline-dark-600",
                    Gradients.Darker => "outline-dark-700",
                    Gradients.Darkest => "outline-dark-800",
                    Gradients.Black => "outline-dark-900",
                    _ => throw new ArgumentOutOfRangeException(nameof(gradients), gradients, null)
                },
                _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
            };
        }
    }
}
