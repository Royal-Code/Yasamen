using RoyalCode.Razor.Commons.Styles;
using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Razor.Commons;

public static partial class Css
{
    public static FontBuilder Font => FontBuilder.Default;
}

public readonly struct FontBuilder
{
    private readonly FontFamily font;
    private readonly FontSize size;
    private readonly FontSmoothing smoothing;
    private readonly FontStyle style;
    private readonly FontWeight weight;
    private readonly FontStretch stretch;
    private readonly FontVariant variant;
    private readonly LetterSpacing spacing;
    private readonly LineClamp clamp;
    private readonly LineHeight lineHeight;

    public FontBuilder(
        FontFamily font,
        FontSize size,
        FontSmoothing smoothing,
        FontStyle style,
        FontWeight weight,
        FontStretch stretch,
        FontVariant variant,
        LetterSpacing spacing,
        LineClamp clamp,
        LineHeight lineHeight)
    {
        this.font = font;
        this.size = size;
        this.smoothing = smoothing;
        this.style = style;
        this.weight = weight;
        this.stretch = stretch;
        this.variant = variant;
        this.spacing = spacing;
        this.clamp = clamp;
        this.lineHeight = lineHeight;
    }

    public static FontBuilder Default { get; } = new(
        FontFamily.Default,
        FontSize.Default,
        FontSmoothing.Default,
        FontStyle.Default,
        FontWeight.Default,
        FontStretch.Default,
        FontVariant.Default,
        LetterSpacing.Default,
        LineClamp.Default,
        LineHeight.Default);

    public FontFamilyBuilder Font => new(this);

    public FontSizeBuilder Size => new(this);

    public FontSmoothingBuilder Smoothing => new(this);

    public FontStyleBuilder Style => new(this);

    public FontWeightBuilder Weight => new(this);

    public FontStretchBuilder Stretch => new(this);

    public FontVariantBuilder Variant => new(this);

    public LetterSpacingBuilder Spacing => new(this);

    public LineClampBuilder Clamp => new(this);

    public LineHeightBuilder Line => new(this);

    public override string ToString()
    {
        return string.Join(' ', AllCssClasses().Where(s => s != string.Empty));
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is FontBuilder font && this == font;
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

    public static bool operator ==(FontBuilder left, FontBuilder right)
    {
        return left.font == right.font &&
               left.size == right.size &&
               left.smoothing == right.smoothing &&
               left.style == right.style &&
               left.weight == right.weight &&
               left.stretch == right.stretch &&
               left.variant == right.variant &&
               left.spacing == right.spacing &&
               left.clamp == right.clamp &&
               left.lineHeight == right.lineHeight;
    }

    public static bool operator !=(FontBuilder left, FontBuilder right)
    {
        return !(left == right);
    }

    public static implicit operator string(FontBuilder builder) => builder.ToString();

    public static implicit operator CssClasses(FontBuilder builder) => new CssClasses(builder.ToString());

    private IEnumerable<string> AllCssClasses()
    {
        yield return font.ToCssClass();
        yield return size.ToCssClass();
        yield return smoothing.ToCssClass();
        yield return style.ToCssClass();
        yield return weight.ToCssClass();
        yield return stretch.ToCssClass();
        yield return variant.ToCssClass();
        yield return spacing.ToCssClass();
        yield return clamp.ToCssClass();
        yield return lineHeight.ToCssClass();
    }

    public FontBuilder WithFont(FontFamily font)
    {
        return new FontBuilder(font, size, smoothing, style, weight, stretch, variant, spacing, clamp, lineHeight);
    }

    public FontBuilder WithSize(FontSize size)
    {
        return new FontBuilder(font, size, smoothing, style, weight, stretch, variant, spacing, clamp, lineHeight);
    }

    public FontBuilder WithSmoothing(FontSmoothing smoothing)
    {
        return new FontBuilder(font, size, smoothing, style, weight, stretch, variant, spacing, clamp, lineHeight);
    }

    public FontBuilder WithStyle(FontStyle style)
    {
        return new FontBuilder(font, size, smoothing, style, weight, stretch, variant, spacing, clamp, lineHeight);
    }

    public FontBuilder WithWeight(FontWeight weight)
    {
        return new FontBuilder(font, size, smoothing, style, weight, stretch, variant, spacing, clamp, lineHeight);
    }

    public FontBuilder WithStretch(FontStretch stretch)
    {
        return new FontBuilder(font, size, smoothing, style, weight, stretch, variant, spacing, clamp, lineHeight);
    }

    public FontBuilder WithVariant(FontVariant variant)
    {
        return new FontBuilder(font, size, smoothing, style, weight, stretch, variant, spacing, clamp, lineHeight);
    }

    public FontBuilder WithSpacing(LetterSpacing spacing)
    {
        return new FontBuilder(font, size, smoothing, style, weight, stretch, variant, spacing, clamp, lineHeight);
    }

    public FontBuilder WithClamp(LineClamp clamp)
    {
        return new FontBuilder(font, size, smoothing, style, weight, stretch, variant, spacing, clamp, lineHeight);
    }

    public FontBuilder WithLineHeight(LineHeight lineHeight)
    {
        return new FontBuilder(font, size, smoothing, style, weight, stretch, variant, spacing, clamp, lineHeight);
    }


    public readonly struct FontFamilyBuilder
    {
        private readonly FontBuilder fontBuilder;

        public FontFamilyBuilder(FontBuilder fontBuilder)
        {
            this.fontBuilder = fontBuilder;
        }

        public FontBuilder WithFont(FontFamily font)
        {
            return fontBuilder.WithFont(font);
        }

        public FontBuilder Default()
        {
            return fontBuilder.WithFont(FontFamily.Default);
        }

        public FontBuilder Sans()
        {
            return fontBuilder.WithFont(FontFamily.Sans);
        }

        public FontBuilder Serif()
        {
            return fontBuilder.WithFont(FontFamily.Serif);
        }

        public FontBuilder Mono()
        {
            return fontBuilder.WithFont(FontFamily.Mono);
        }
    }

    public readonly struct FontSizeBuilder
    {
        private readonly FontBuilder fontBuilder;

        public FontSizeBuilder(FontBuilder fontBuilder)
        {
            this.fontBuilder = fontBuilder;
        }

        public FontBuilder WithSize(FontSize size)
        {
            return fontBuilder.WithSize(size);
        }

        public FontBuilder Default()
        {
            return fontBuilder.WithSize(FontSize.Default);
        }

        public FontBuilder SmallerX4()
        {
            return fontBuilder.WithSize(FontSize.SmallerX4);
        }

        public FontBuilder SmallerX3()
        {
            return fontBuilder.WithSize(FontSize.SmallerX3);
        }

        public FontBuilder SmallerX2()
        {
            return fontBuilder.WithSize(FontSize.SmallerX2);
        }

        public FontBuilder Smaller()
        {
            return fontBuilder.WithSize(FontSize.Smaller);
        }

        public FontBuilder Small()
        {
            return fontBuilder.WithSize(FontSize.Small);
        }

        public FontBuilder Medium()
        {
            return fontBuilder.WithSize(FontSize.Medium);
        }

        public FontBuilder Large()
        {
            return fontBuilder.WithSize(FontSize.Large);
        }

        public FontBuilder Larger()
        {
            return fontBuilder.WithSize(FontSize.Larger);
        }

        public FontBuilder LargerX2()
        {
            return fontBuilder.WithSize(FontSize.LargerX2);
        }

        public FontBuilder LargerX3()
        {
            return fontBuilder.WithSize(FontSize.LargerX3);
        }

        public FontBuilder LargerX4()
        {
            return fontBuilder.WithSize(FontSize.LargerX4);
        }

        public FontBuilder LargerX5()
        {
            return fontBuilder.WithSize(FontSize.LargerX5);
        }

        public FontBuilder LargerX6()
        {
            return fontBuilder.WithSize(FontSize.LargerX6);
        }

        public FontBuilder LargerX7()
        {
            return fontBuilder.WithSize(FontSize.LargerX7);
        }

        public FontBuilder LargerX8()
        {
            return fontBuilder.WithSize(FontSize.LargerX8);
        }

        public FontBuilder LargerX9()
        {
            return fontBuilder.WithSize(FontSize.LargerX9);
        }
    }

    public readonly struct FontSmoothingBuilder
    {
        private readonly FontBuilder fontBuilder;

        public FontSmoothingBuilder(FontBuilder fontBuilder)
        {
            this.fontBuilder = fontBuilder;
        }

        public FontBuilder WithSmoothing(FontSmoothing smoothing)
        {
            return fontBuilder.WithSmoothing(smoothing);
        }

        public FontBuilder Default()
        {
            return fontBuilder.WithSmoothing(FontSmoothing.Default);
        }

        public FontBuilder Antialiased()
        {
            return fontBuilder.WithSmoothing(FontSmoothing.Antialiased);
        }

        public FontBuilder SubpixelAntialiased()
        {
            return fontBuilder.WithSmoothing(FontSmoothing.SubpixelAntialiased);
        }
    }

    public readonly struct FontStyleBuilder
    {
        private readonly FontBuilder fontBuilder;

        public FontStyleBuilder(FontBuilder fontBuilder)
        {
            this.fontBuilder = fontBuilder;
        }

        public FontBuilder WithStyle(FontStyle style)
        {
            return fontBuilder.WithStyle(style);
        }

        public FontBuilder Default()
        {
            return fontBuilder.WithStyle(FontStyle.Default);
        }

        public FontBuilder Normal()
        {
            return fontBuilder.WithStyle(FontStyle.Normal);
        }

        public FontBuilder Italic()
        {
            return fontBuilder.WithStyle(FontStyle.Italic);
        }
    }

    public readonly struct FontWeightBuilder
    {
        private readonly FontBuilder fontBuilder;

        public FontWeightBuilder(FontBuilder fontBuilder)
        {
            this.fontBuilder = fontBuilder;
        }

        public FontBuilder WithWeight(FontWeight weight)
        {
            return fontBuilder.WithWeight(weight);
        }

        public FontBuilder Default()
        {
            return fontBuilder.WithWeight(FontWeight.Default);
        }

        public FontBuilder Thin()
        {
            return fontBuilder.WithWeight(FontWeight.Thin);
        }

        public FontBuilder ExtraLight()
        {
            return fontBuilder.WithWeight(FontWeight.ExtraLight);
        }

        public FontBuilder Light()
        {
            return fontBuilder.WithWeight(FontWeight.Light);
        }

        public FontBuilder Normal()
        {
            return fontBuilder.WithWeight(FontWeight.Normal);
        }

        public FontBuilder Medium()
        {
            return fontBuilder.WithWeight(FontWeight.Medium);
        }

        public FontBuilder SemiBold()
        {
            return fontBuilder.WithWeight(FontWeight.SemiBold);
        }

        public FontBuilder Bold()
        {
            return fontBuilder.WithWeight(FontWeight.Bold);
        }

        public FontBuilder ExtraBold()
        {
            return fontBuilder.WithWeight(FontWeight.ExtraBold);
        }

        public FontBuilder Black()
        {
            return fontBuilder.WithWeight(FontWeight.Black);
        }
    }

    public readonly struct FontStretchBuilder
    {
        private readonly FontBuilder fontBuilder;

        public FontStretchBuilder(FontBuilder fontBuilder)
        {
            this.fontBuilder = fontBuilder;
        }

        public FontBuilder WithStretch(FontStretch stretch)
        {
            return fontBuilder.WithStretch(stretch);
        }

        public FontBuilder Default()
        {
            return fontBuilder.WithStretch(FontStretch.Default);
        }

        public FontBuilder UltraCondensed()
        {
            return fontBuilder.WithStretch(FontStretch.UltraCondensed);
        }

        public FontBuilder ExtraCondensed()
        {
            return fontBuilder.WithStretch(FontStretch.ExtraCondensed);
        }

        public FontBuilder Condensed()
        {
            return fontBuilder.WithStretch(FontStretch.Condensed);
        }

        public FontBuilder SemiCondensed()
        {
            return fontBuilder.WithStretch(FontStretch.SemiCondensed);
        }

        public FontBuilder Normal()
        {
            return fontBuilder.WithStretch(FontStretch.Normal);
        }

        public FontBuilder SemiExpanded()
        {
            return fontBuilder.WithStretch(FontStretch.SemiExpanded);
        }

        public FontBuilder Expanded()
        {
            return fontBuilder.WithStretch(FontStretch.Expanded);
        }

        public FontBuilder ExtraExpanded()
        {
            return fontBuilder.WithStretch(FontStretch.ExtraExpanded);
        }

        public FontBuilder UltraExpanded()
        {
            return fontBuilder.WithStretch(FontStretch.UltraExpanded);
        }
    }

    public readonly struct FontVariantBuilder
    {
        private readonly FontBuilder fontBuilder;

        public FontVariantBuilder(FontBuilder fontBuilder)
        {
            this.fontBuilder = fontBuilder;
        }

        public FontBuilder WithVariant(FontVariant variant)
        {
            return fontBuilder.WithVariant(variant);
        }

        public FontBuilder Default()
        {
            return fontBuilder.WithVariant(FontVariant.Default);
        }

        public FontBuilder Normal()
        {
            return fontBuilder.WithVariant(FontVariant.Normal);
        }

        public FontBuilder Ordinal()
        {
            return fontBuilder.WithVariant(FontVariant.Ordinal);
        }

        public FontBuilder SlashedZero()
        {
            return fontBuilder.WithVariant(FontVariant.SlashedZero);
        }

        public FontBuilder Liniear()
        {
            return fontBuilder.WithVariant(FontVariant.Liniear);
        }

        public FontBuilder OldStyle()
        {
            return fontBuilder.WithVariant(FontVariant.OldStyle);
        }

        public FontBuilder Proportional()
        {
            return fontBuilder.WithVariant(FontVariant.Proportional);
        }

        public FontBuilder Tabular()
        {
            return fontBuilder.WithVariant(FontVariant.Tabular);
        }

        public FontBuilder DiagonalFractions()
        {
            return fontBuilder.WithVariant(FontVariant.DiagonalFractions);
        }

        public FontBuilder StackedFractions()
        {
            return fontBuilder.WithVariant(FontVariant.StackedFractions);
        }
    }

    public readonly struct LetterSpacingBuilder
    {
        private readonly FontBuilder fontBuilder;

        public LetterSpacingBuilder(FontBuilder fontBuilder)
        {
            this.fontBuilder = fontBuilder;
        }

        public FontBuilder WithSpacing(LetterSpacing spacing)
        {
            return fontBuilder.WithSpacing(spacing);
        }

        public FontBuilder Default()
        {
            return fontBuilder.WithSpacing(LetterSpacing.Default);
        }

        public FontBuilder Tighter()
        {
            return fontBuilder.WithSpacing(LetterSpacing.Tighter);
        }

        public FontBuilder Tight()
        {
            return fontBuilder.WithSpacing(LetterSpacing.Tight);
        }

        public FontBuilder Normal()
        {
            return fontBuilder.WithSpacing(LetterSpacing.Normal);
        }

        public FontBuilder Wide()
        {
            return fontBuilder.WithSpacing(LetterSpacing.Wide);
        }

        public FontBuilder Wider()
        {
            return fontBuilder.WithSpacing(LetterSpacing.Wider);
        }

        public FontBuilder Widest()
        {
            return fontBuilder.WithSpacing(LetterSpacing.Widest);
        }
    }

    public readonly struct LineClampBuilder
    {
        private readonly FontBuilder fontBuilder;

        public LineClampBuilder(FontBuilder fontBuilder)
        {
            this.fontBuilder = fontBuilder;
        }

        public FontBuilder WithClamp(LineClamp clamp)
        {
            return fontBuilder.WithClamp(clamp);
        }

        public FontBuilder Default()
        {
            return fontBuilder.WithClamp(LineClamp.Default);
        }

        public FontBuilder None()
        {
            return fontBuilder.WithClamp(LineClamp.None);
        }

        public FontBuilder Clamp1()
        {
            return fontBuilder.WithClamp(LineClamp.Clamp1);
        }

        public FontBuilder Clamp2()
        {
            return fontBuilder.WithClamp(LineClamp.Clamp2);
        }

        public FontBuilder Clamp3()
        {
            return fontBuilder.WithClamp(LineClamp.Clamp3);
        }

        public FontBuilder Clamp4()
        {
            return fontBuilder.WithClamp(LineClamp.Clamp4);
        }

        public FontBuilder Clamp5()
        {
            return fontBuilder.WithClamp(LineClamp.Clamp5);
        }

        public FontBuilder Clamp6()
        {
            return fontBuilder.WithClamp(LineClamp.Clamp6);
        }

        public FontBuilder Clamp7()
        {
            return fontBuilder.WithClamp(LineClamp.Clamp7);
        }

        public FontBuilder Clamp8()
        {
            return fontBuilder.WithClamp(LineClamp.Clamp8);
        }

        public FontBuilder Clamp9()
        {
            return fontBuilder.WithClamp(LineClamp.Clamp9);
        }

        public FontBuilder Clamp10()
        {
            return fontBuilder.WithClamp(LineClamp.Clamp10);
        }
    }

    public readonly struct LineHeightBuilder
    {
        private readonly FontBuilder fontBuilder;
        public LineHeightBuilder(FontBuilder fontBuilder)
        {
            this.fontBuilder = fontBuilder;
        }
        public FontBuilder WithLineHeight(LineHeight lineHeight)
        {
            return fontBuilder.WithLineHeight(lineHeight);
        }
        public FontBuilder Default()
        {
            return fontBuilder.WithLineHeight(LineHeight.Default);
        }
        public FontBuilder None()
        {
            return fontBuilder.WithLineHeight(LineHeight.None);
        }

        public FontBuilder Leading1()
        {
            return fontBuilder.WithLineHeight(LineHeight.Leading1);
        }

        public FontBuilder Leading2()
        {
            return fontBuilder.WithLineHeight(LineHeight.Leading2);
        }

        public FontBuilder Leading3()
        {
            return fontBuilder.WithLineHeight(LineHeight.Leading3);
        }

        public FontBuilder Leading4()
        {
            return fontBuilder.WithLineHeight(LineHeight.Leading4);
        }

        public FontBuilder Leading5()
        {
            return fontBuilder.WithLineHeight(LineHeight.Leading5);
        }

        public FontBuilder Leading6()
        {
            return fontBuilder.WithLineHeight(LineHeight.Leading6);
        }

        public FontBuilder Leading7()
        {
            return fontBuilder.WithLineHeight(LineHeight.Leading7);
        }

        public FontBuilder Leading8()
        {
            return fontBuilder.WithLineHeight(LineHeight.Leading8);
        }

        public FontBuilder Leading9()
        {
            return fontBuilder.WithLineHeight(LineHeight.Leading9);
        }

        public FontBuilder Leading10()
        {
            return fontBuilder.WithLineHeight(LineHeight.Leading10);
        }
    }
}