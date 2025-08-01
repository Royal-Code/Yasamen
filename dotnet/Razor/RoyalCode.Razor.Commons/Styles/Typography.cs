namespace RoyalCode.Razor.Commons.Styles;

public enum FontFamily
{
    Default,
    Sans,
    Serif,
    Mono,
}

public enum FontSize
{
    Default,
    SmallerX4,
    SmallerX3,
    SmallerX2,
    Smaller,
    Small,
    Medium,
    Large,
    Larger,
    LargerX2,
    LargerX3,
    LargerX4,
    LargerX5,
    LargerX6,
    LargerX7,
    LargerX8,
    LargerX9
}

public enum FontSmoothing
{
    Default,
    Antialiased,
    SubpixelAntialiased
}

public enum FontStyle
{
    Default,
    Normal,
    Italic
}

public enum FontWeight
{
    Default,
    Thin,
    ExtraLight,
    Light,
    Normal,
    Medium,
    SemiBold,
    Bold,
    ExtraBold,
    Black
}

public enum FontStretch
{
    Default,
    UltraCondensed,
    ExtraCondensed,
    Condensed,
    SemiCondensed,
    Normal,
    SemiExpanded,
    Expanded,
    ExtraExpanded,
    UltraExpanded
}

public enum FontVariant
{
    Default,
    Normal,
    Ordinal,
    SlashedZero,
    Liniear,
    OldStyle,
    Proportional,
    Tabular,
    DiagonalFractions,
    StackedFractions
}

public enum LetterSpacing
{
    Default,
    Tighter,
    Tight,
    Normal,
    Wide,
    Wider,
    Widest
}

public enum LineClamp
{
    Default,
    None,
    Clamp1,
    Clamp2,
    Clamp3,
    Clamp4,
    Clamp5,
    Clamp6,
    Clamp7,
    Clamp8,
    Clamp9,
    Clamp10
}

public enum LineHeight
{
    Default,
    None,
    Leading1,
    Leading2,
    Leading3,
    Leading4,
    Leading5,
    Leading6,
    Leading7,
    Leading8,
    Leading9,
    Leading10
}

public enum ListStylePosition
{
    Default,
    Inside,
    Outside
}

public enum ListStyleType
{
    Default,
    None,
    Decimal,
    Disc,
    Circle,
    Square,
    DecimalLeadingZero,
    LowerAlpha,
    UpperAlpha,
    LowerRoman,
    UpperRoman
}

public enum TextTransform
{
    Default,
    None,
    Capitalize,
    Uppercase,
    Lowercase
}

public enum TextOverflow
{
    Default,
    Clip,
    Ellipsis,
    Truncate
}

public enum TextWrap
{
    Default,
    Wrap,
    NoWrap,
    Balance,
    Pretty,
}

public enum TextIndent
{
    Default,
    Smaller,
    Small,
    Medium,
    Large,
    Larger,
}

public enum TextWhiteSpace
{
    Default,
    Normal,
    Nowrap,
    Pre,
    PreLine,
    PreWrap,
    BreakSpaces
}

public enum TextWordBreak
{
    Default,
    Normal,
    All,
    Keep
}

public enum TextHyphens
{
    Default,
    None,
    Manual,
    Auto
}

public static class TypographyExtensions
{
    public static string ToCssClass(this FontFamily font)
    {
        return font switch
        {
            FontFamily.Default => string.Empty,
            FontFamily.Sans => "font-sans",
            FontFamily.Serif => "font-serif",
            FontFamily.Mono => "font-mono",
            _ => throw new ArgumentOutOfRangeException(nameof(font), font, null)
        };
    }

    public static string ToCssClass(this FontSize size)
    {
        return size switch
        {
            FontSize.Default => string.Empty,
            FontSize.SmallerX4 => "text-4xs",
            FontSize.SmallerX3 => "text-3xs",
            FontSize.SmallerX2 => "text-2xs",
            FontSize.Smaller => "text-xs",
            FontSize.Small => "text-sm",
            FontSize.Medium => "text-base",
            FontSize.Large => "text-lg",
            FontSize.Larger => "text-xl",
            FontSize.LargerX2 => "text-2xl",
            FontSize.LargerX3 => "text-3xl",
            FontSize.LargerX4 => "text-4xl",
            FontSize.LargerX5 => "text-5xl",
            FontSize.LargerX6 => "text-6xl",
            FontSize.LargerX7 => "text-7xl",
            FontSize.LargerX8 => "text-8xl",
            FontSize.LargerX9 => "text-9xl",
        };
    }

    public static string ToCssClass(this FontSmoothing smoothing)
    {
        return smoothing switch
        {
            FontSmoothing.Default => string.Empty,
            FontSmoothing.Antialiased => "antialiased",
            FontSmoothing.SubpixelAntialiased => "subpixel-antialiased",
            _ => throw new ArgumentOutOfRangeException(nameof(smoothing), smoothing, null)
        };
    }

    public static string ToCssClass(this FontStyle style)
    {
        return style switch
        {
            FontStyle.Default => string.Empty,
            FontStyle.Normal => "not-italic",
            FontStyle.Italic => "italic",
            _ => throw new ArgumentOutOfRangeException(nameof(style), style, null)
        };
    }

    public static string ToCssClass(this FontWeight weight)
    {
        return weight switch
        {
            FontWeight.Default => string.Empty,
            FontWeight.Thin => "font-thin",
            FontWeight.ExtraLight => "font-extralight",
            FontWeight.Light => "font-light",
            FontWeight.Normal => "font-normal",
            FontWeight.Medium => "font-medium",
            FontWeight.SemiBold => "font-semibold",
            FontWeight.Bold => "font-bold",
            FontWeight.ExtraBold => "font-extrabold",
            FontWeight.Black => "font-black",
            _ => throw new ArgumentOutOfRangeException(nameof(weight), weight, null)
        };
    }

    public static string ToCssClass(this FontStretch stretch)
    {
        return stretch switch
        {
            FontStretch.Default => string.Empty,
            FontStretch.UltraCondensed => "font-stretch-ultra-condensed",
            FontStretch.ExtraCondensed => "font-stretch-extra-condensed",
            FontStretch.Condensed => "font-stretch-condensed",
            FontStretch.SemiCondensed => "font-stretch-semi-condensed",
            FontStretch.Normal => "font-stretch-normal",
            FontStretch.SemiExpanded => "font-stretch-semi-expanded",
            FontStretch.Expanded => "font-stretch-expanded",
            FontStretch.ExtraExpanded => "font-stretch-extra-expanded",
            FontStretch.UltraExpanded => "font-stretch-ultra-expanded",
            _ => throw new ArgumentOutOfRangeException(nameof(stretch), stretch, null)
        };
    }

    public static string ToCssClass(this FontVariant variant)
    {
        return variant switch
        {
            FontVariant.Default => string.Empty,
            FontVariant.Normal => "normal-nums",
            FontVariant.Ordinal => "ordinal",
            FontVariant.SlashedZero => "slashed-zero",
            FontVariant.Liniear => "lining-nums",
            FontVariant.OldStyle => "oldstyle-nums",
            FontVariant.Proportional => "proportional-nums",
            FontVariant.Tabular => "tabular-nums",
            FontVariant.DiagonalFractions => "diagonal-fractions",
            FontVariant.StackedFractions => "stacked-fractions",
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null)
        };
    }

    public static string ToCssClass(this LetterSpacing spacing)
    {
        return spacing switch
        {
            LetterSpacing.Default => string.Empty,
            LetterSpacing.Tighter => "tracking-tighter",
            LetterSpacing.Tight => "tracking-tight",
            LetterSpacing.Normal => "tracking-normal",
            LetterSpacing.Wide => "tracking-wide",
            LetterSpacing.Wider => "tracking-wider",
            LetterSpacing.Widest => "tracking-widest",
            _ => throw new ArgumentOutOfRangeException(nameof(spacing), spacing, null)
        };
    }

    public static string ToCssClass(this LineClamp clamp)
    {
        return clamp switch
        {
            LineClamp.Default => string.Empty,
            LineClamp.None => "line-clamp-none",
            LineClamp.Clamp1 => "line-clamp-1",
            LineClamp.Clamp2 => "line-clamp-2",
            LineClamp.Clamp3 => "line-clamp-3",
            LineClamp.Clamp4 => "line-clamp-4",
            LineClamp.Clamp5 => "line-clamp-5",
            LineClamp.Clamp6 => "line-clamp-6",
            LineClamp.Clamp7 => "line-clamp-7",
            LineClamp.Clamp8 => "line-clamp-8",
            LineClamp.Clamp9 => "line-clamp-9",
            LineClamp.Clamp10 => "line-clamp-10",
            _ => throw new ArgumentOutOfRangeException(nameof(clamp), clamp, null)
        };
    }

    public static string ToCssClass(this LineHeight height)
    {
        return height switch
        {
            LineHeight.Default => string.Empty,
            LineHeight.None => "leading-none",
            LineHeight.Leading1 => "leading-1",
            LineHeight.Leading2 => "leading-2",
            LineHeight.Leading3 => "leading-3",
            LineHeight.Leading4 => "leading-4",
            LineHeight.Leading5 => "leading-5",
            LineHeight.Leading6 => "leading-6",
            LineHeight.Leading7 => "leading-7",
            LineHeight.Leading8 => "leading-8",
            LineHeight.Leading9 => "leading-9",
            LineHeight.Leading10 => "leading-10",
            _ => throw new ArgumentOutOfRangeException(nameof(height), height, null)
        };
    }

    public static string ToCssClass(this ListStylePosition position)
    {
        return position switch
        {
            ListStylePosition.Default => string.Empty,
            ListStylePosition.Inside => "list-inside",
            ListStylePosition.Outside => "list-outside",
            _ => throw new ArgumentOutOfRangeException(nameof(position), position, null)
        };
    }

    public static string ToCssClass(this ListStyleType type)
    {
        return type switch
        {
            ListStyleType.Default => string.Empty,
            ListStyleType.None => "list-none",
            ListStyleType.Decimal => "list-decimal",
            ListStyleType.Disc => "list-disc",
            ListStyleType.Circle => "list-[circle]",
            ListStyleType.Square => "list-[square]",
            ListStyleType.DecimalLeadingZero => "list-[decimal-leading-zero]",
            ListStyleType.LowerAlpha => "list-[lower-alpha]",
            ListStyleType.UpperAlpha => "list-[upper-alpha]",
            ListStyleType.LowerRoman => "list-[lower-roman]",
            ListStyleType.UpperRoman => "list-[upper-roman]",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    public static string ToCssClass(this TextTransform transform)
    {
        return transform switch
        {
            TextTransform.Default => string.Empty,
            TextTransform.None => "normal-case",
            TextTransform.Capitalize => "capitalize",
            TextTransform.Uppercase => "uppercase",
            TextTransform.Lowercase => "lowercase",
            _ => throw new ArgumentOutOfRangeException(nameof(transform), transform, null)
        };
    }

    public static string ToCssClass(this TextOverflow overflow)
    {
        return overflow switch
        {
            TextOverflow.Default => string.Empty,
            TextOverflow.Clip => "text-clip",
            TextOverflow.Ellipsis => "text-ellipsis",
            TextOverflow.Truncate => "truncate",
            _ => throw new ArgumentOutOfRangeException(nameof(overflow), overflow, null)
        };
    }

    public static string ToCssClass(this TextWrap wrap)
    {
        return wrap switch
        {
            TextWrap.Default => string.Empty,
            TextWrap.Wrap => "text-wrap",
            TextWrap.NoWrap => "text-nowrap",
            TextWrap.Balance => "text-balance",
            TextWrap.Pretty => "text-pretty",
            _ => throw new ArgumentOutOfRangeException(nameof(wrap), wrap, null)
        };
    }

    public static string ToCssClass(this TextIndent indent, bool positive = true)
    {
        if (positive)
            return indent switch
            {
                TextIndent.Default => string.Empty,
                TextIndent.Smaller => "indent-2",
                TextIndent.Small => "indent-4",
                TextIndent.Medium => "indent-8",
                TextIndent.Large => "indent-12",
                TextIndent.Larger => "indent-16",
                _ => throw new ArgumentOutOfRangeException(nameof(indent), indent, null)
            };

        return indent switch
        {
            TextIndent.Default => string.Empty,
            TextIndent.Smaller => "-indent-2",
            TextIndent.Small => "-indent-4",
            TextIndent.Medium => "-indent-8",
            TextIndent.Large => "-indent-12",
            TextIndent.Larger => "-indent-16",
            _ => throw new ArgumentOutOfRangeException(nameof(indent), indent, null)
        };
    }

    public static string ToCssClass(this TextWhiteSpace whiteSpace)
    {
        return whiteSpace switch
        {
            TextWhiteSpace.Default => string.Empty,
            TextWhiteSpace.Normal => "whitespace-normal",
            TextWhiteSpace.Nowrap => "whitespace-nowrap",
            TextWhiteSpace.Pre => "whitespace-pre",
            TextWhiteSpace.PreLine => "whitespace-pre-line",
            TextWhiteSpace.PreWrap => "whitespace-pre-wrap",
            TextWhiteSpace.BreakSpaces => "whitespace-break-spaces",
            _ => throw new ArgumentOutOfRangeException(nameof(whiteSpace), whiteSpace, null)
        };
    }

    public static string ToCssClass(this TextWordBreak wordBreak)
    {
        return wordBreak switch
        {
            TextWordBreak.Default => string.Empty,
            TextWordBreak.Normal => "break-normal",
            TextWordBreak.All => "break-all",
            TextWordBreak.Keep => "break-keep",
            _ => throw new ArgumentOutOfRangeException(nameof(wordBreak), wordBreak, null)
        };
    }

    public static string ToCssClass(this TextHyphens hyphens)
    {
        return hyphens switch
        {
            TextHyphens.Default => string.Empty,
            TextHyphens.None => "hyphens-none",
            TextHyphens.Manual => "hyphens-manual",
            TextHyphens.Auto => "hyphens-auto",
            _ => throw new ArgumentOutOfRangeException(nameof(hyphens), hyphens, null)
        };
    }
}