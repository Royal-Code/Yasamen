using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Razor.Commons.Styles;

public readonly struct TextDecoration
{
    private readonly string className;

    public TextDecoration(DecorationBuilder builder)
    {
        className = builder.ToString();
    }

    public static TextDecoration Default { get; } = new TextDecoration(DecorationBuilder.Default());

    public static DecorationBuilder Builder { get;} = DecorationBuilder.Default();

    public static implicit operator string(TextDecoration decoration) => decoration.className;

    public override string ToString() => className;

    public readonly struct DecorationBuilder
    {
        private readonly TextDecorationLine line;
        private readonly TextDecorationStyle style;
        private readonly TextDecorationThickness thickness;
        private readonly TextUnderlineOffset underlineOffset;
        private readonly Themes color;
        private readonly Gradients gradient;

        public DecorationBuilder(
            TextDecorationLine line,
            TextDecorationStyle style,
            TextDecorationThickness thickness,
            TextUnderlineOffset underlineOffset,
            Themes color,
            Gradients gradient)
        {
            this.line = line;
            this.style = style;
            this.thickness = thickness;
            this.underlineOffset = underlineOffset;
            this.color = color;
            this.gradient = gradient;
        }

        public static DecorationBuilder Default()
        {
            return new DecorationBuilder(
                TextDecorationLine.Default,
                TextDecorationStyle.Default,
                TextDecorationThickness.Default,
                TextUnderlineOffset.Default,
                Themes.Default,
                Gradients.Default);
        }

        public TextDecorationLineBuilder Line => new TextDecorationLineBuilder(this);

        public TextDecorationStyleBuilder Style => new TextDecorationStyleBuilder(this);

        public TextDecorationThicknessBuilder Thickness => new TextDecorationThicknessBuilder(this);

        public TextUnderlineOffsetBuilder UnderlineOffset => new TextUnderlineOffsetBuilder(this);

        public TextDecorationColorBuilder Color => new TextDecorationColorBuilder(this);

        public DecorationBuilder With(TextDecorationLine line)
        {
            return new DecorationBuilder(
                line,
                style,
                thickness,
                underlineOffset,
                color,
                gradient);
        }

        public DecorationBuilder With(TextDecorationStyle style)
        {
            return new DecorationBuilder(
                line,
                style,
                thickness,
                underlineOffset,
                color,
                gradient);
        }

        public DecorationBuilder With(TextDecorationThickness thickness)
        {
            return new DecorationBuilder(
                line,
                style,
                thickness,
                underlineOffset,
                color,
                gradient);
        }

        public DecorationBuilder With(TextUnderlineOffset underlineOffset)
        {
            return new DecorationBuilder(
                line,
                style,
                thickness,
                underlineOffset,
                color,
                gradient);
        }

        public DecorationBuilder With(Themes theme, Gradients gradients)
        {
            return new DecorationBuilder(
                line,
                style,
                thickness,
                underlineOffset,
                theme,
                gradients);
        }

        public static implicit operator string(DecorationBuilder builder) => builder.ToString();

        public static implicit operator TextDecoration(DecorationBuilder builder) => new(builder);

        public override string ToString()
        {
            return string.Join(" ", AllCssClasses().Where(c => !string.IsNullOrEmpty(c)));
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is DecorationBuilder other &&
                   line == other.line &&
                   style == other.style &&
                   thickness == other.thickness &&
                   underlineOffset == other.underlineOffset &&
                   color == other.color &&
                   gradient == other.gradient;
        }

        public static bool operator ==(DecorationBuilder left, DecorationBuilder right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DecorationBuilder left, DecorationBuilder right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(line, style, thickness, underlineOffset, color, gradient);
        }

        private IEnumerable<string> AllCssClasses()
        {
            yield return line.ToCssClass();
            yield return style.ToCssClass();
            yield return thickness.ToCssClass();
            yield return underlineOffset.ToCssClass();
            yield return color.ToDecorationColorCssClass(gradient);
        }
    }

    public readonly struct TextDecorationLineBuilder
    {
        private readonly DecorationBuilder builder;

        public TextDecorationLineBuilder(DecorationBuilder builder)
        {
            this.builder = builder;
        }
        
        public DecorationBuilder With(TextDecorationLine line)
        {
            return builder.With(line);
        }

        public DecorationBuilder Default()
        {
            return builder.With(TextDecorationLine.Default);
        }

        public DecorationBuilder None()
        {
            return builder.With(TextDecorationLine.None);
        }

        public DecorationBuilder Underline()
        {
            return builder.With(TextDecorationLine.Underline);
        }

        public DecorationBuilder Overline()
        {
            return builder.With(TextDecorationLine.Overline);
        }

        public DecorationBuilder LineThrough()
        {
            return builder.With(TextDecorationLine.LineThrough);
        }
    }

    public readonly struct TextDecorationStyleBuilder
    {
        private readonly DecorationBuilder builder;

        public TextDecorationStyleBuilder(DecorationBuilder builder)
        {
            this.builder = builder;
        }

        public DecorationBuilder With(TextDecorationStyle style)
        {
            return builder.With(style);
        }

        public DecorationBuilder Default()
        {
            return builder.With(TextDecorationStyle.Default);
        }

        public DecorationBuilder Solid()
        {
            return builder.With(TextDecorationStyle.Solid);
        }

        public DecorationBuilder Double()
        {
            return builder.With(TextDecorationStyle.Double);
        }

        public DecorationBuilder Dotted()
        {
            return builder.With(TextDecorationStyle.Dotted);
        }

        public DecorationBuilder Dashed()
        {
            return builder.With(TextDecorationStyle.Dashed);
        }

        public DecorationBuilder Wavy()
        {
            return builder.With(TextDecorationStyle.Wavy);
        }
    }

    public readonly struct TextDecorationThicknessBuilder
    {
        private readonly DecorationBuilder builder;

        public TextDecorationThicknessBuilder(DecorationBuilder builder)
        {
            this.builder = builder;
        }

        public DecorationBuilder With(TextDecorationThickness thickness)
        {
            return builder.With(thickness);
        }

        public DecorationBuilder Default()
        {
            return builder.With(TextDecorationThickness.Default);
        }

        public DecorationBuilder Auto()
        {
            return builder.With(TextDecorationThickness.Auto);
        }

        public DecorationBuilder FromFont()
        {
            return builder.With(TextDecorationThickness.FromFont);
        }

        public DecorationBuilder Hairline()
        {
            return builder.With(TextDecorationThickness.Hairline);
        }

        public DecorationBuilder Thin()
        {
            return builder.With(TextDecorationThickness.Thin);
        }

        public DecorationBuilder Thick()
        {
            return builder.With(TextDecorationThickness.Thick);
        }
    }

    public readonly struct TextUnderlineOffsetBuilder
    {
        private readonly DecorationBuilder builder;

        public TextUnderlineOffsetBuilder(DecorationBuilder builder)
        {
            this.builder = builder;
        }

        public DecorationBuilder With(TextUnderlineOffset underlineOffset)
        {
            return builder.With(underlineOffset);
        }

        public DecorationBuilder Default()
        {
            return builder.With(TextUnderlineOffset.Default);
        }

        public DecorationBuilder Auto()
        {
            return builder.With(TextUnderlineOffset.Auto);
        }

        public DecorationBuilder Negative()
        {
            return builder.With(TextUnderlineOffset.Negative);
        }

        public DecorationBuilder Smaller()
        {
            return builder.With(TextUnderlineOffset.Smaller);
        }

        public DecorationBuilder Small()
        {
            return builder.With(TextUnderlineOffset.Small);
        }

        public DecorationBuilder Medium()
        {
            return builder.With(TextUnderlineOffset.Medium);
        }

        public DecorationBuilder Large()
        {
            return builder.With(TextUnderlineOffset.Large);
        }

        public DecorationBuilder Larger()
        {
            return builder.With(TextUnderlineOffset.Larger);
        }
    }

    public readonly struct TextDecorationColorBuilder
    {
        private readonly DecorationBuilder builder;

        public TextDecorationColorBuilder(DecorationBuilder builder)
        {
            this.builder = builder;
        }

        public TextDecorationGradientBuilder With(Themes theme)
        {
            return new TextDecorationGradientBuilder(builder, theme);
        }

        public TextDecorationGradientBuilder Default()
        {
            return With(Themes.Default);
        }

        public TextDecorationGradientBuilder Primary()
        {
            return With(Themes.Primary);
        }

        public TextDecorationGradientBuilder Secondary()
        {
            return With(Themes.Secondary);
        }

        public TextDecorationGradientBuilder Tertiary()
        {
            return With(Themes.Tertiary);
        }

        public TextDecorationGradientBuilder Info()
        {
            return With(Themes.Info);
        }

        public TextDecorationGradientBuilder Highlight()
        {
            return With(Themes.Highlight);
        }

        public TextDecorationGradientBuilder Success()
        {
            return With(Themes.Success);
        }

        public TextDecorationGradientBuilder Warning()
        {
            return With(Themes.Warning);
        }

        public TextDecorationGradientBuilder Alert()
        {
            return With(Themes.Alert);
        }

        public TextDecorationGradientBuilder Danger()
        {
            return With(Themes.Danger);
        }

        public TextDecorationGradientBuilder Light()
        {
            return With(Themes.Light);
        }

        public TextDecorationGradientBuilder Dark()
        {
            return With(Themes.Dark);
        }
    }

    public readonly struct TextDecorationGradientBuilder
    {
        private readonly DecorationBuilder builder;
        private readonly Themes theme;

        public TextDecorationGradientBuilder(DecorationBuilder builder, Themes theme)
        {
            this.builder = builder;
            this.theme = theme;
        }

        public DecorationBuilder With(Gradients gradient)
        {
            return builder.With(theme, gradient);
        }

        public DecorationBuilder Default()
        {
            return builder.With(theme, Gradients.Default);
        }

        public DecorationBuilder White()
        {
            return builder.With(theme, Gradients.White);
        }

        public DecorationBuilder Lightest()
        {
            return builder.With(theme, Gradients.Lightest);
        }

        public DecorationBuilder Lighter()
        {
            return builder.With(theme, Gradients.Lighter);
        }

        public DecorationBuilder Light()
        {
            return builder.With(theme, Gradients.Light);
        }

        public DecorationBuilder Normal()
        {
            return builder.With(theme, Gradients.Normal);
        }

        public DecorationBuilder Dark()
        {
            return builder.With(theme, Gradients.Dark);
        }

        public DecorationBuilder Darker()
        {
            return builder.With(theme, Gradients.Darker);
        }

        public DecorationBuilder Darkest()
        {
            return builder.With(theme, Gradients.Darkest);
        }

        public DecorationBuilder Black()
        {
            return builder.With(theme, Gradients.Black);
        }
    }
}

public enum TextDecorationLine
{
    Default,
    None,
    Underline,
    Overline,
    LineThrough
}

public enum TextDecorationStyle
{
    Default,
    Solid,
    Double,
    Dotted,
    Dashed,
    Wavy
}

public enum TextDecorationThickness
{
    Default,
    Auto,
    FromFont,
    Hairline,
    Thin,
    Thick,
}

public enum TextUnderlineOffset
{
    Default,
    Auto,
    Negative,
    Smaller,
    Small,
    Medium,
    Large,
    Larger,
}

public static class TextDecorationExtensions
{
    public static string ToCssClass(this TextDecorationLine line)
    {
        return line switch 
        {
            TextDecorationLine.Default => string.Empty,
            TextDecorationLine.None => "no-underline",
            TextDecorationLine.Underline => "underline",
            TextDecorationLine.Overline => "overline",
            TextDecorationLine.LineThrough => "line-through",
            _ => throw new ArgumentOutOfRangeException(nameof(line), line, null)
        };
    }

    public static string ToCssClass(this TextDecorationStyle style)
    {
        return style switch
        {
            TextDecorationStyle.Default => string.Empty,
            TextDecorationStyle.Solid => "decoration-solid",
            TextDecorationStyle.Double => "decoration-double",
            TextDecorationStyle.Dotted => "decoration-dotted",
            TextDecorationStyle.Dashed => "decoration-dashed",
            TextDecorationStyle.Wavy => "decoration-wavy",
            _ => throw new ArgumentOutOfRangeException(nameof(style), style, null)
        };
    }

    public static string ToCssClass(this TextDecorationThickness thickness)
    {
        return thickness switch
        {
            TextDecorationThickness.Default => string.Empty,
            TextDecorationThickness.Auto => "decoration-auto",
            TextDecorationThickness.FromFont => "decoration-from-font",
            TextDecorationThickness.Hairline => "decoration-1",
            TextDecorationThickness.Thin => "decoration-2",
            TextDecorationThickness.Thick => "decoration-4",
            _ => throw new ArgumentOutOfRangeException(nameof(thickness), thickness, null)
        };
    }

    public static string ToCssClass(this TextUnderlineOffset underlineOffset)
    {
        return underlineOffset switch
        {
            TextUnderlineOffset.Default => string.Empty,
            TextUnderlineOffset.Auto => "underline-offset-auto",
            TextUnderlineOffset.Negative => "-underline-offset-1",
            TextUnderlineOffset.Smaller => "underline-offset-1",
            TextUnderlineOffset.Small => "underline-offset-2",
            TextUnderlineOffset.Medium => "underline-offset-4",
            TextUnderlineOffset.Large => "underline-offset-8",
            TextUnderlineOffset.Larger => "underline-offset-12",
            _ => throw new ArgumentOutOfRangeException(nameof(underlineOffset), underlineOffset, null)
        };
    }

    public static string ToDecorationColorCssClass(this Themes theme, Gradients gradient)
    {
        if (theme == Themes.Default)
            return string.Empty;

        return theme switch
        {
            Themes.Primary => gradient switch
            {
                Gradients.Default => "decoration-primary",
                Gradients.White => "decoration-primary-100",
                Gradients.Lightest => "decoration-primary-200",
                Gradients.Lighter => "decoration-primary-300",
                Gradients.Light => "decoration-primary-400",
                Gradients.Normal => "decoration-primary-500",
                Gradients.Dark => "decoration-primary-600",
                Gradients.Darker => "decoration-primary-700",
                Gradients.Darkest => "decoration-primary-800",
                Gradients.Black => "decoration-primary-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            Themes.Secondary => gradient switch
            {
                Gradients.Default => "decoration-secondary",
                Gradients.White => "decoration-secondary-100",
                Gradients.Lightest => "decoration-secondary-200",
                Gradients.Lighter => "decoration-secondary-300",
                Gradients.Light => "decoration-secondary-400",
                Gradients.Normal => "decoration-secondary-500",
                Gradients.Dark => "decoration-secondary-600",
                Gradients.Darker => "decoration-secondary-700",
                Gradients.Darkest => "decoration-secondary-800",
                Gradients.Black => "decoration-secondary-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            Themes.Tertiary => gradient switch
            {
                Gradients.Default => "decoration-tertiary",
                Gradients.White => "decoration-tertiary-100",
                Gradients.Lightest => "decoration-tertiary-200",
                Gradients.Lighter => "decoration-tertiary-300",
                Gradients.Light => "decoration-tertiary-400",
                Gradients.Normal => "decoration-tertiary-500",
                Gradients.Dark => "decoration-tertiary-600",
                Gradients.Darker => "decoration-tertiary-700",
                Gradients.Darkest => "decoration-tertiary-800",
                Gradients.Black => "decoration-tertiary-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            Themes.Info => gradient switch
            {
                Gradients.Default => "decoration-info",
                Gradients.White => "decoration-info-100",
                Gradients.Lightest => "decoration-info-200",
                Gradients.Lighter => "decoration-info-300",
                Gradients.Light => "decoration-info-400",
                Gradients.Normal => "decoration-info-500",
                Gradients.Dark => "decoration-info-600",
                Gradients.Darker => "decoration-info-700",
                Gradients.Darkest => "decoration-info-800",
                Gradients.Black => "decoration-info-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            Themes.Highlight => gradient switch
            {
                Gradients.Default => "decoration-highlight",
                Gradients.White => "decoration-highlight-100",
                Gradients.Lightest => "decoration-highlight-200",
                Gradients.Lighter => "decoration-highlight-300",
                Gradients.Light => "decoration-highlight-400",
                Gradients.Normal => "decoration-highlight-500",
                Gradients.Dark => "decoration-highlight-600",
                Gradients.Darker => "decoration-highlight-700",
                Gradients.Darkest => "decoration-highlight-800",
                Gradients.Black => "decoration-highlight-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            Themes.Success => gradient switch
            {
                Gradients.Default => "decoration-success",
                Gradients.White => "decoration-success-100",
                Gradients.Lightest => "decoration-success-200",
                Gradients.Lighter => "decoration-success-300",
                Gradients.Light => "decoration-success-400",
                Gradients.Normal => "decoration-success-500",
                Gradients.Dark => "decoration-success-600",
                Gradients.Darker => "decoration-success-700",
                Gradients.Darkest => "decoration-success-800",
                Gradients.Black => "decoration-success-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            Themes.Warning => gradient switch
            {
                Gradients.Default => "decoration-warning",
                Gradients.White => "decoration-warning-100",
                Gradients.Lightest => "decoration-warning-200",
                Gradients.Lighter => "decoration-warning-300",
                Gradients.Light => "decoration-warning-400",
                Gradients.Normal => "decoration-warning-500",
                Gradients.Dark => "decoration-warning-600",
                Gradients.Darker => "decoration-warning-700",
                Gradients.Darkest => "decoration-warning-800",
                Gradients.Black => "decoration-warning-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            Themes.Alert => gradient switch
            {
                Gradients.Default => "decoration-alert",
                Gradients.White => "decoration-alert-100",
                Gradients.Lightest => "decoration-alert-200",
                Gradients.Lighter => "decoration-alert-300",
                Gradients.Light => "decoration-alert-400",
                Gradients.Normal => "decoration-alert-500",
                Gradients.Dark => "decoration-alert-600",
                Gradients.Darker => "decoration-alert-700",
                Gradients.Darkest => "decoration-alert-800",
                Gradients.Black => "decoration-alert-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            Themes.Danger => gradient switch
            {
                Gradients.Default => "decoration-danger",
                Gradients.White => "decoration-danger-100",
                Gradients.Lightest => "decoration-danger-200",
                Gradients.Lighter => "decoration-danger-300",
                Gradients.Light => "decoration-danger-400",
                Gradients.Normal => "decoration-danger-500",
                Gradients.Dark => "decoration-danger-600",
                Gradients.Darker => "decoration-danger-700",
                Gradients.Darkest => "decoration-danger-800",
                Gradients.Black => "decoration-danger-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            Themes.Light => gradient switch
            {
                Gradients.Default => "decoration-light",
                Gradients.White => "decoration-light-100",
                Gradients.Lightest => "decoration-light-200",
                Gradients.Lighter => "decoration-light-300",
                Gradients.Light => "decoration-light-400",
                Gradients.Normal => "decoration-light-500",
                Gradients.Dark => "decoration-light-600",
                Gradients.Darker => "decoration-light-700",
                Gradients.Darkest => "decoration-light-800",
                Gradients.Black => "decoration-light-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            Themes.Dark => gradient switch
            {
                Gradients.Default => "decoration-dark",
                Gradients.White => "decoration-dark-100",
                Gradients.Lightest => "decoration-dark-200",
                Gradients.Lighter => "decoration-dark-300",
                Gradients.Light => "decoration-dark-400",
                Gradients.Normal => "decoration-dark-500",
                Gradients.Dark => "decoration-dark-600",
                Gradients.Darker => "decoration-dark-700",
                Gradients.Darkest => "decoration-dark-800",
                Gradients.Black => "decoration-dark-900",
                _ => throw new ArgumentOutOfRangeException(nameof(gradient), gradient, null)
            },
            _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
        };
    }
}