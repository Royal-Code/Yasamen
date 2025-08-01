using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Razor.Styles;

/// <summary>
/// Utility to create CSS classes for components.
/// </summary>
public static partial class Css
{
    public static TextBuilder Text => TextBuilder.Default();
}

public readonly struct TextBuilder
{
    private readonly TextAlign align;
    private readonly TextJustify justify;
    private readonly TextColor color;
    private readonly TextDecoration decoration;
    private readonly TextTransform transform;
    private readonly TextOverflow overflow;
    private readonly TextWrap wrap;
    private readonly TextIndent indent;
    private readonly TextWhiteSpace whiteSpace;
    private readonly TextWordBreak wordBreak;
    private readonly TextOverflowWrap overflowWrap;
    private readonly TextHyphens hyphens;

    public TextBuilder(
        TextAlign align,
        TextJustify justify,
        TextColor color,
        TextDecoration decoration,
        TextTransform transform,
        TextOverflow overflow,
        TextWrap wrap,
        TextIndent indent,
        TextWhiteSpace whiteSpace,
        TextWordBreak wordBreak,
        TextOverflowWrap overflowWrap,
        TextHyphens hyphens)
    {
        this.align = align;
        this.justify = justify;
        this.color = color;
        this.decoration = decoration;
        this.transform = transform;
        this.overflow = overflow;
        this.wrap = wrap;
        this.indent = indent;
        this.whiteSpace = whiteSpace;
        this.wordBreak = wordBreak;
        this.overflowWrap = overflowWrap;
        this.hyphens = hyphens;
    }

    public static TextBuilder Default() => new(
        TextAlign.Default,
        TextJustify.Default,
        TextColor.Default,
        TextDecoration.Default,
        TextTransform.Default,
        TextOverflow.Default,
        TextWrap.Default,
        TextIndent.Default,
        TextWhiteSpace.Default,
        TextWordBreak.Default,
        TextOverflowWrap.Default,
        TextHyphens.Default);

    public TextAlignBuilder Align => new(this);

    public TextJustifyBuilder Justify => new(this);

    public TextColorBuilder Color => new(this);

    public TextTransformBuilder Transform => new(this);

    public TextOverflowBuilder Overflow => new(this);

    public TextWrapBuilder Wrap => new(this);

    public TextIndentBuilder Indent => new(this);

    public TextWhiteSpaceBuilder WhiteSpace => new(this);

    public TextWordBreakBuilder WordBreak => new(this);

    public TextOverflowWrapBuilder OverflowWrap => new(this);

    public TextHyphensBuilder Hyphens => new(this);

    public override string ToString() => string.Join(' ', AllCssClasses().Where(s => s != string.Empty));

    private IEnumerable<string> AllCssClasses()
    {
        yield return align.ToCssClass();
        yield return justify.ToCssClass();
        yield return color;
        yield return decoration;
        yield return transform.ToCssClass();
        yield return overflow.ToCssClass();
        yield return wrap.ToCssClass();
        yield return indent.ToCssClass();
        yield return whiteSpace.ToCssClass();
        yield return wordBreak.ToCssClass();
        yield return overflowWrap.ToCssClass();
        yield return hyphens.ToCssClass();
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is TextBuilder builder && this == builder;
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

    public static bool operator ==(TextBuilder left, TextBuilder right)
    {
        return left.align == right.align &&
               left.justify == right.justify &&
               left.color == right.color &&
               left.decoration == right.decoration &&
               left.transform == right.transform &&
               left.overflow == right.overflow &&
               left.wrap == right.wrap &&
               left.indent == right.indent &&
               left.whiteSpace == right.whiteSpace &&
               left.wordBreak == right.wordBreak &&
               left.overflowWrap == right.overflowWrap &&
               left.hyphens == right.hyphens;
    }

    public static bool operator !=(TextBuilder left, TextBuilder right)
    {
        return !(left == right);
    }

    public static implicit operator string(TextBuilder builder) => builder.ToString();

    public TextBuilder WithAlign(TextAlign align)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithJustify(TextJustify justify)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithColor(TextColor color)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithDecoration(TextDecoration decoration)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithTransform(TextTransform transform)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithOverflow(TextOverflow overflow)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithWrap(TextWrap wrap)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithIndent(TextIndent indent)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithWhiteSpace(TextWhiteSpace whiteSpace)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithWordBreak(TextWordBreak wordBreak)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithOverflowWrap(TextOverflowWrap overflowWrap)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public TextBuilder WithHyphens(TextHyphens hyphens)
    {
        return new TextBuilder(align, justify, color, decoration, transform, overflow, wrap, indent, whiteSpace, wordBreak, overflowWrap, hyphens);
    }

    public readonly struct TextAlignBuilder
    {
        private readonly TextBuilder builder;

        public TextAlignBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithAlign(TextAlign.Default);
        }

        public TextBuilder Baseline()
        {
            return builder.WithAlign(TextAlign.Baseline);
        }

        public TextBuilder Top()
        {
            return builder.WithAlign(TextAlign.Top);
        }

        public TextBuilder Middle()
        {
            return builder.WithAlign(TextAlign.Middle);
        }

        public TextBuilder Bottom()
        {
            return builder.WithAlign(TextAlign.Bottom);
        }

        public TextBuilder TextTop()
        {
            return builder.WithAlign(TextAlign.TextTop);
        }

        public TextBuilder TextBottom()
        {
            return builder.WithAlign(TextAlign.TextBottom);
        }

        public TextBuilder Sub()
        {
            return builder.WithAlign(TextAlign.Sub);
        }

        public TextBuilder Super()
        {
            return builder.WithAlign(TextAlign.Super);
        }
    }

    public readonly struct TextJustifyBuilder
    {
        private readonly TextBuilder builder;

        public TextJustifyBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithJustify(TextJustify.Default);
        }

        public TextBuilder Left()
        {
            return builder.WithJustify(TextJustify.Left);
        }

        public TextBuilder Center()
        {
            return builder.WithJustify(TextJustify.Center);
        }

        public TextBuilder Right()
        {
            return builder.WithJustify(TextJustify.Right);
        }

        public TextBuilder Justify()
        {
            return builder.WithJustify(TextJustify.Justify);
        }

        public TextBuilder Start()
        {
            return builder.WithJustify(TextJustify.Start);
        }

        public TextBuilder End()
        {
            return builder.WithJustify(TextJustify.End);
        }
    }

    public readonly struct TextColorBuilder
    {
        private readonly TextBuilder builder;

        public TextColorBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithColor(TextColor.Default);
        }

        public TextBuilder White()
        {
            return builder.WithColor(TextColor.White);
        }

        public TextBuilder Black()
        {
            return builder.WithColor(TextColor.Black);
        }

        public TextBuilder Transparent()
        {
            return builder.WithColor(TextColor.Transparent);
        }

        public TextBuilder Current()
        {
            return builder.WithColor(TextColor.Current);
        }

        public TextBuilder Inherit()
        {
            return builder.WithColor(TextColor.Inherit);
        }

        public TextColorGradientBuilder Primary()
        {
            return new(builder, Themes.Primary);
        }

        public TextColorGradientBuilder Secondary()
        {
            return new(builder, Themes.Secondary);
        }

        public TextColorGradientBuilder Tertiary()
        {
            return new(builder, Themes.Tertiary);
        }

        public TextColorGradientBuilder Info()
        {
            return new(builder, Themes.Info);
        }

        public TextColorGradientBuilder Highlight()
        {
            return new(builder, Themes.Highlight);
        }

        public TextColorGradientBuilder Success()
        {
            return new(builder, Themes.Success);
        }

        public TextColorGradientBuilder Warning()
        {
            return new(builder, Themes.Warning);
        }

        public TextColorGradientBuilder Alert()
        {
            return new(builder, Themes.Alert);
        }

        public TextColorGradientBuilder Danger()
        {
            return new(builder, Themes.Danger);
        }

        public TextColorGradientBuilder Light()
        {
            return new(builder, Themes.Light);
        }

        public TextColorGradientBuilder Dark()
        {
            return new(builder, Themes.Dark);
        }
    }

    public readonly struct TextColorGradientBuilder
    {
        private readonly TextBuilder builder;
        private readonly Themes themes;

        public TextColorGradientBuilder(TextBuilder builder, Themes themes)
        {
            this.builder = builder;
            this.themes = themes;
        }

        public static implicit operator TextBuilder(TextColorGradientBuilder builder)
        {
            return builder.builder.WithColor(new TextColor(builder.themes, Gradients.Default));
        }

        public TextBuilder Default()
        {
            return builder.WithColor(new TextColor(themes, Gradients.Default));
        }

        public TextBuilder White()
        {
            return builder.WithColor(new TextColor(themes, Gradients.White));
        }

        public TextBuilder Lightest()
        {
            return builder.WithColor(new TextColor(themes, Gradients.Lightest));
        }

        public TextBuilder Lighter()
        {
            return builder.WithColor(new TextColor(themes, Gradients.Lighter));
        }

        public TextBuilder Light()
        {
            return builder.WithColor(new TextColor(themes, Gradients.Light));
        }

        public TextBuilder Normal()
        {
            return builder.WithColor(new TextColor(themes, Gradients.Normal));
        }

        public TextBuilder Dark()
        {
            return builder.WithColor(new TextColor(themes, Gradients.Dark));
        }

        public TextBuilder Darker()
        {
            return builder.WithColor(new TextColor(themes, Gradients.Darker));
        }

        public TextBuilder Darkest()
        {
            return builder.WithColor(new TextColor(themes, Gradients.Darkest));
        }

        public TextBuilder Black()
        {
            return builder.WithColor(new TextColor(themes, Gradients.Black));
        }
    }

    public readonly struct TextTransformBuilder
    {
        private readonly TextBuilder builder;

        public TextTransformBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithTransform(TextTransform.Default);
        }

        public TextBuilder None()
        {
            return builder.WithTransform(TextTransform.None);
        }

        public TextBuilder Lowercase()
        {
            return builder.WithTransform(TextTransform.Lowercase);
        }

        public TextBuilder Uppercase()
        {
            return builder.WithTransform(TextTransform.Uppercase);
        }

        public TextBuilder Capitalize()
        {
            return builder.WithTransform(TextTransform.Capitalize);
        }
    }

    public readonly struct TextOverflowBuilder
    {
        private readonly TextBuilder builder;

        public TextOverflowBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithOverflow(TextOverflow.Default);
        }

        public TextBuilder Clip()
        {
            return builder.WithOverflow(TextOverflow.Clip);
        }

        public TextBuilder Ellipsis()
        {
            return builder.WithOverflow(TextOverflow.Ellipsis);
        }

        public TextBuilder Truncate()
        {
            return builder.WithOverflow(TextOverflow.Truncate);
        }
    }

    public readonly struct TextWrapBuilder
    {
        private readonly TextBuilder builder;

        public TextWrapBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithWrap(TextWrap.Default);
        }

        public TextBuilder Wrap()
        {
            return builder.WithWrap(TextWrap.Wrap);
        }

        public TextBuilder NoWrap()
        {
            return builder.WithWrap(TextWrap.NoWrap);
        }

        public TextBuilder Balance()
        {
            return builder.WithWrap(TextWrap.Balance);
        }

        public TextBuilder Pretty()
        {
            return builder.WithWrap(TextWrap.Pretty);
        }
    }

    public readonly struct TextIndentBuilder
    {
        private readonly TextBuilder builder;

        public TextIndentBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithIndent(TextIndent.Default);
        }

        public TextBuilder Smaller()
        {
            return builder.WithIndent(TextIndent.Smaller);
        }

        public TextBuilder Small()
        {
            return builder.WithIndent(TextIndent.Small);
        }

        public TextBuilder Medium()
        {
            return builder.WithIndent(TextIndent.Medium);
        }

        public TextBuilder Large()
        {
            return builder.WithIndent(TextIndent.Large);
        }

        public TextBuilder Larger()
        {
            return builder.WithIndent(TextIndent.Larger);
        }
    }

    public readonly struct TextWhiteSpaceBuilder
    {
        private readonly TextBuilder builder;

        public TextWhiteSpaceBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithWhiteSpace(TextWhiteSpace.Default);
        }

        public TextBuilder Normal()
        {
            return builder.WithWhiteSpace(TextWhiteSpace.Normal);
        }

        public TextBuilder Nowrap()
        {
            return builder.WithWhiteSpace(TextWhiteSpace.Nowrap);
        }

        public TextBuilder Pre()
        {
            return builder.WithWhiteSpace(TextWhiteSpace.Pre);
        }

        public TextBuilder PreLine()
        {
            return builder.WithWhiteSpace(TextWhiteSpace.PreLine);
        }

        public TextBuilder PreWrap()
        {
            return builder.WithWhiteSpace(TextWhiteSpace.PreWrap);
        }

        public TextBuilder BreakSpaces()
        {
            return builder.WithWhiteSpace(TextWhiteSpace.BreakSpaces);
        }
    }

    public readonly struct TextWordBreakBuilder
    {
        private readonly TextBuilder builder;

        public TextWordBreakBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithWordBreak(TextWordBreak.Default);
        }

        public TextBuilder Normal()
        {
            return builder.WithWordBreak(TextWordBreak.Normal);
        }

        public TextBuilder All()
        {
            return builder.WithWordBreak(TextWordBreak.All);
        }

        public TextBuilder Keep()
        {
            return builder.WithWordBreak(TextWordBreak.Keep);
        }
    }

    public readonly struct TextOverflowWrapBuilder
    {
        private readonly TextBuilder builder;

        public TextOverflowWrapBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithOverflowWrap(TextOverflowWrap.Default);
        }

        public TextBuilder Normal()
        {
            return builder.WithOverflowWrap(TextOverflowWrap.Normal);
        }

        public TextBuilder BreakWord()
        {
            return builder.WithOverflowWrap(TextOverflowWrap.BreakWord);
        }

        public TextBuilder Anywhere()
        {
            return builder.WithOverflowWrap(TextOverflowWrap.Anywhere);
        }
    }

    public readonly struct TextHyphensBuilder
    {
        private readonly TextBuilder builder;

        public TextHyphensBuilder(TextBuilder builder)
        {
            this.builder = builder;
        }

        public TextBuilder Default()
        {
            return builder.WithHyphens(TextHyphens.Default);
        }

        public TextBuilder None()
        {
            return builder.WithHyphens(TextHyphens.None);
        }

        public TextBuilder Manual()
        {
            return builder.WithHyphens(TextHyphens.Manual);
        }

        public TextBuilder Auto()
        {
            return builder.WithHyphens(TextHyphens.Auto);
        }
    }
}
