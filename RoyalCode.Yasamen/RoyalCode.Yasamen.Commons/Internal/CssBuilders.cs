
namespace RoyalCode.Yasamen.Commons.Internal;


internal class CssBuilderBase : ICssBuilder
{
    protected readonly CssCollection classes;

    public CssBuilderBase(CssCollection classes)
    {
        this.classes = classes;
    }

    public ICssSizeBuilder Sizes => new CssSizeBuilder(classes);

    public ICssAlignBuilder Align => new CssAlignBuilder(classes);

    public ICssFloatBuilder Float => new CssFloatBuilder(classes);

    public ICssDisplayBuilder Display => new CssDisplayBuilder(classes);

    public ICssPositionBuilder Position => new CssPositionBuilder(classes);

    public ICssMarginBuilder Margin => new CssMarginBuilder(classes);

    public ICssPaddingBuilder Padding => new CssPaddingBuilder(classes);

    public ICssBackgroundBuilder Background => new CssBackgroundBuilder(classes);

    public ICssTextBuilder Text => new CssTextBuilder(classes);

    public ICssBuilder Gap(int gap)
    {
        // validate range 0-5
        if (gap < 0 || gap > 5)
            throw new ArgumentOutOfRangeException(nameof(gap), gap, "The gap must be between 0 and 5.");

        classes.TryAdd("gap");
        classes.Add($"g-{gap}");
        return this;
    }

    public ICssBuilder GapHorizontal(int gap)
    {
        // validate range 0-5
        if (gap < 0 || gap > 5)
            throw new ArgumentOutOfRangeException(nameof(gap), gap, "The gap must be between 0 and 5.");

        classes.TryAdd("gap");
        classes.Add($"gx-{gap}");
        return this;
    }

    public ICssBuilder GapVertical(int gap)
    {
        // validate range 0-5
        if (gap < 0 || gap > 5)
            throw new ArgumentOutOfRangeException(nameof(gap), gap, "The gap must be between 0 and 5.");

        classes.TryAdd("gap");
        classes.Add($"gy-{gap}");
        return this;
    }

    public ICssBuilder Invisible()
    {
        classes.Add("invisible");
        return this;
    }

    public ICssBuilder Opacity(int opacity)
    {
        // validate range 0-5
        if (opacity < 0 || opacity > 5)
            throw new ArgumentOutOfRangeException(nameof(opacity), opacity, "The opacity must be between 0 and 5.");

        classes.Add($"opacity-{opacity}");
        return this;
    }

    public ICssBuilder Shadow(int shadow)
    {
        // validate range 0-5
        if (shadow < 0 || shadow > 5)
            throw new ArgumentOutOfRangeException(nameof(shadow), shadow, "The shadow must be between 0 and 5.");

        classes.Add($"shadow-{shadow}");
        return this;
    }

    public ICssBuilder Visible()
    {
        classes.Add("visible");
        return this;
    }
}

internal class CssCollection
{
    private readonly List<string> classes = [];

    public void Add(string cssClass) => classes.Add(cssClass);

    public void TryAdd(string cssClass)
    {
        if (!classes.Contains(cssClass))
            classes.Add(cssClass);
    }

    public override string ToString()
    {
        return string.Join(" ", classes);
    }
}

internal class CssBuilder : CssBuilderBase
{
    public CssBuilder() : base(new()) { }
}

internal class CssSizeBuilder : CssBuilderBase, ICssSizeBuilder
{
    public CssSizeBuilder(CssCollection classes) : base(classes) { }

    public ICssSizeBuilder Width25()
    {
        classes.Add("w-25");
        return this;
    }

    public ICssSizeBuilder Width50()
    {
        classes.Add("w-50");
        return this;
    }

    public ICssSizeBuilder Width75()
    {
        classes.Add("w-75");
        return this;
    }

    public ICssSizeBuilder Width100()
    {
        classes.Add("w-100");
        return this;
    }

    public ICssSizeBuilder WidthAuto()
    {
        classes.Add("w-auto");
        return this;
    }

    public ICssSizeBuilder Height25()
    {
        classes.Add("h-25");
        return this;
    }

    public ICssSizeBuilder Height50()
    {
        classes.Add("h-50");
        return this;
    }

    public ICssSizeBuilder Height75()
    {
        classes.Add("h-75");
        return this;
    }

    public ICssSizeBuilder Height100()
    {
        classes.Add("h-100");
        return this;
    }

    public ICssSizeBuilder HeightAuto()
    {
        classes.Add("h-auto");
        return this;
    }
}

internal class CssAlignBuilder : CssBuilderBase, ICssAlignBuilder
{
    public CssAlignBuilder(CssCollection classes) : base(classes) { }

    public ICssVerticalAlignBuilder Vertical => new CssVerticalAlignBuilder(classes);
}

internal class CssVerticalAlignBuilder : CssAlignBuilder, ICssVerticalAlignBuilder
{
    public CssVerticalAlignBuilder(CssCollection classes) : base(classes) { }

    public ICssVerticalAlignBuilder Baseline()
    {
        classes.Add("align-baseline");
        return this;
    }

    public ICssVerticalAlignBuilder Bottom()
    {
        classes.Add("align-bottom");
        return this;
    }

    public ICssVerticalAlignBuilder Middle()
    {
        classes.Add("align-middle");
        return this;
    }

    public ICssVerticalAlignBuilder TextBottom()
    {
        classes.Add("align-text-bottom");
        return this;
    }

    public ICssVerticalAlignBuilder TextTop()
    {
        classes.Add("align-text-top");
        return this;
    }

    public ICssVerticalAlignBuilder Top()
    {
        classes.Add("align-top");
        return this;
    }
}

internal class CssFloatBuilder : CssBuilderBase, ICssFloatBuilder
{
    public CssFloatBuilder(CssCollection classes) : base(classes) { }

    public ICssFloatBuilder Start()
    {
        classes.Add("float-start");
        return this;
    }

    public ICssFloatBuilder End()
    {
        classes.Add("float-end");
        return this;
    }

    public ICssFloatBuilder None()
    {
        classes.Add("float-none");
        return this;
    }
}

internal class CssDisplayBuilder : CssBuilderBase, ICssDisplayBuilder
{
    public CssDisplayBuilder(CssCollection classes) : base(classes) { }

    public ICssDisplayBuilder Block()
    {
        classes.Add("d-block");
        return this;
    }

    public ICssDisplayBuilder Inline()
    {
        classes.Add("d-inline");
        return this;
    }

    public ICssDisplayBuilder InlineBlock()
    {
        classes.Add("d-inline-block");
        return this;
    }

    public ICssDisplayBuilder Flex()
    {
        classes.Add("d-flex");
        return this;
    }

    public ICssDisplayBuilder InlineFlex()
    {
        classes.Add("d-inline-flex");
        return this;
    }

    public ICssDisplayBuilder None()
    {
        classes.Add("d-none");
        return this;
    }

    public ICssDisplayBuilder Table()
    {
        classes.Add("d-table");
        return this;
    }

    public ICssDisplayBuilder TableRow()
    {
        classes.Add("d-table-row");
        return this;
    }

    public ICssDisplayBuilder TableCell()
    {
        classes.Add("d-table-cell");
        return this;
    }

    public ICssDisplayBuilder Grid()
    {
        classes.Add("d-grid");
        return this;
    }
}

internal class CssPositionBuilder : CssBuilderBase, ICssPositionBuilder
{
    public CssPositionBuilder(CssCollection classes) : base(classes) { }

    public ICssPositionBuilder Static()
    {
        classes.Add("position-static");
        return this;
    }

    public ICssPositionBuilder Relative()
    {
        classes.Add("position-relative");
        return this;
    }

    public ICssPositionBuilder Absolute()
    {
        classes.Add("position-absolute");
        return this;
    }

    public ICssPositionBuilder Fixed()
    {
        classes.Add("position-fixed");
        return this;
    }

    public ICssPositionBuilder Sticky()
    {
        classes.Add("position-sticky");
        return this;
    }
}

internal class CssMarginBuilder : CssBuilderBase, ICssMarginBuilder
{
    public CssMarginBuilder(CssCollection classes) : base(classes) { }

    public ICssMarginAutoBuilder Auto => new CssMarginAutoBuilder(classes);

    public ICssMarginBuilder All(int margin)
    {
        if (margin < 0 || margin > 5)
            throw new ArgumentOutOfRangeException(nameof(margin), "Margin must be between 0 and 5");

        classes.Add($"m-{margin}");
        return this;
    }

    public ICssMarginBuilder Bottom(int margin)
    {
        if (margin < 0 || margin > 5)
            throw new ArgumentOutOfRangeException(nameof(margin), "Margin must be between 0 and 5");

        classes.Add($"mb-{margin}");
        return this;
    }

    public ICssMarginBuilder End(int margin)
    {
        if (margin < 0 || margin > 5)
            throw new ArgumentOutOfRangeException(nameof(margin), "Margin must be between 0 and 5");

        classes.Add($"me-{margin}");
        return this;
    }

    public ICssMarginBuilder Horizontal(int margin)
    {
        if (margin < 0 || margin > 5)
            throw new ArgumentOutOfRangeException(nameof(margin), "Margin must be between 0 and 5");

        classes.Add($"mx-{margin}");
        return this;
    }

    public ICssMarginBuilder Start(int margin)
    {
        if (margin < 0 || margin > 5)
            throw new ArgumentOutOfRangeException(nameof(margin), "Margin must be between 0 and 5");

        classes.Add($"ms-{margin}");
        return this;
    }

    public ICssMarginBuilder Top(int margin)
    {
        if (margin < 0 || margin > 5)
            throw new ArgumentOutOfRangeException(nameof(margin), "Margin must be between 0 and 5");

        classes.Add($"mt-{margin}");
        return this;
    }

    public ICssMarginBuilder Vertical(int margin)
    {
        if (margin < 0 || margin > 5)
            throw new ArgumentOutOfRangeException(nameof(margin), "Margin must be between 0 and 5");

        classes.Add($"my-{margin}");
        return this;
    }
}

internal class CssMarginAutoBuilder : CssBuilderBase, ICssMarginAutoBuilder
{
    public CssMarginAutoBuilder(CssCollection classes) : base(classes) { }

    public ICssMarginAutoBuilder All()
    {
        classes.Add("m-auto");
        return this;
    }

    public ICssMarginAutoBuilder Bottom()
    {
        classes.Add("mb-auto");
        return this;
    }

    public ICssMarginAutoBuilder End()
    {
        classes.Add("me-auto");
        return this;
    }

    public ICssMarginAutoBuilder Horizontal()
    {
        classes.Add("mx-auto");
        return this;
    }

    public ICssMarginAutoBuilder Start()
    {
        classes.Add("ms-auto");
        return this;
    }

    public ICssMarginAutoBuilder Top()
    {
        classes.Add("mt-auto");
        return this;
    }

    public ICssMarginAutoBuilder Vertical()
    {
        classes.Add("my-auto");
        return this;
    }
}

internal class CssPaddingBuilder : CssBuilderBase, ICssPaddingBuilder
{
    public CssPaddingBuilder(CssCollection classes) : base(classes) { }

    public ICssPaddingBuilder All(int padding)
    {
        if (padding < 0 || padding > 5)
            throw new ArgumentOutOfRangeException(nameof(padding), "Padding must be between 0 and 5");

        classes.Add($"p-{padding}");
        return this;
    }

    public ICssPaddingBuilder Bottom(int padding)
    {
        if (padding < 0 || padding > 5)
            throw new ArgumentOutOfRangeException(nameof(padding), "Padding must be between 0 and 5");

        classes.Add($"pb-{padding}");
        return this;
    }

    public ICssPaddingBuilder End(int padding)
    {
        if (padding < 0 || padding > 5)
            throw new ArgumentOutOfRangeException(nameof(padding), "Padding must be between 0 and 5");

        classes.Add($"pe-{padding}");
        return this;
    }

    public ICssPaddingBuilder Horizontal(int padding)
    {
        if (padding < 0 || padding > 5)
            throw new ArgumentOutOfRangeException(nameof(padding), "Padding must be between 0 and 5");

        classes.Add($"px-{padding}");
        return this;
    }

    public ICssPaddingBuilder Start(int padding)
    {
        if (padding < 0 || padding > 5)
            throw new ArgumentOutOfRangeException(nameof(padding), "Padding must be between 0 and 5");

        classes.Add($"ps-{padding}");
        return this;
    }

    public ICssPaddingBuilder Top(int padding)
    {
        if (padding < 0 || padding > 5)
            throw new ArgumentOutOfRangeException(nameof(padding), "Padding must be between 0 and 5");

        classes.Add($"pt-{padding}");
        return this;
    }

    public ICssPaddingBuilder Vertical(int padding)
    {
        if (padding < 0 || padding > 5)
            throw new ArgumentOutOfRangeException(nameof(padding), "Padding must be between 0 and 5");

        classes.Add($"py-{padding}");
        return this;
    }
}

internal class CssBackgroundBuilder : CssBuilderBase, ICssBackgroundBuilder
{
    public CssBackgroundBuilder(CssCollection classes) : base(classes) { }

    public ICssBackgroundBuilder Black()
    {
        classes.Add("bg-black");
        return this;
    }

    public ICssBackgroundBuilder Body()
    {
        classes.Add("bg-body");
        return this;
    }

    public ICssBackgroundBuilder Danger()
    {
        classes.Add("bg-danger");
        return this;
    }

    public ICssBackgroundBuilder Dark()
    {
        classes.Add("bg-dark");
        return this;
    }

    public ICssBackgroundBuilder Info()
    {
        classes.Add("bg-info");
        return this;
    }

    public ICssBackgroundBuilder Light()
    {
        classes.Add("bg-light");
        return this;
    }

    public ICssBackgroundBuilder Main()
    {
        classes.Add("bg-main");
        return this;
    }

    public ICssBackgroundBuilder Primary()
    {
        classes.Add("bg-primary");
        return this;
    }

    public ICssBackgroundBuilder Secondary()
    {
        classes.Add("bg-secondary");
        return this;
    }

    public ICssBackgroundBuilder Success()
    {
        classes.Add("bg-success");
        return this;
    }

    public ICssBackgroundBuilder Transparent()
    {
        classes.Add("bg-transparent");
        return this;
    }

    public ICssBackgroundBuilder Warning()
    {
        classes.Add("bg-warning");
        return this;
    }

    public ICssBackgroundBuilder White()
    {
        classes.Add("bg-white");
        return this;
    }
}

internal class CssTextBuilder : CssBuilderBase, ICssTextBuilder
{
    public CssTextBuilder(CssCollection classes) : base(classes) { }

    public ICssTextAlignBuilder TextAlign => new CssTextAlignBuilder(classes);

    public ICssTextDecorationBuilder Decoration => new CssTextDecorationBuilder(classes);

    public ICssTextTransformBuilder Transform => new CssTextTransformBuilder(classes);

    public ICssTextSpaceBuilder WhiteSpace => new CssTextSpaceBuilder(classes);

    public ICssTextColorBuilder Color => new CssTextColorBuilder(classes);

    public ICssTextBuilder Break()
    {
        classes.Add("text-break");
        return this;
    }

    public ICssTextBuilder Truncate()
    {
        classes.Add("text-truncate");
        return this;
    }
}

internal class CssTextColorBuilder : ICssTextColorBuilder
{
    private readonly CssCollection classes;

    public CssTextColorBuilder(CssCollection classes)
    {
        this.classes = classes;
    }

    public ICssTextBuilder Black()
    {
        classes.Add("text-black");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Black50()
    {
        classes.Add("text-black-50");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Body()
    {
        classes.Add("text-body");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Danger()
    {
        classes.Add("text-danger");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Dark()
    {
        classes.Add("text-dark");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Default()
    {
        classes.Add("text-default");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Info()
    {
        classes.Add("text-info");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Light()
    {
        classes.Add("text-light");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Main()
    {
        classes.Add("text-main");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Muted()
    {
        classes.Add("text-muted");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Primary()
    {
        classes.Add("text-primary");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Reset()
    {
        classes.Add("text-reset");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Secondary()
    {
        classes.Add("text-secondary");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Success()
    {
        classes.Add("text-success");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Warning()
    {
        classes.Add("text-warning");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder White()
    {
        classes.Add("text-white");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder White50()
    {
        classes.Add("text-white-50");
        return new CssTextBuilder(classes);
    }
}

internal class CssTextSpaceBuilder : ICssTextSpaceBuilder
{
    private readonly CssCollection classes;

    public CssTextSpaceBuilder(CssCollection classes)
    {
        this.classes = classes;
    }

    public ICssTextBuilder BreakAll()
    {
        classes.Add("text-break-all");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder BreakWord()
    {
        classes.Add("text-break-word");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder NoWrap()
    {
        classes.Add("text-nowrap");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Normal()
    {
        classes.Add("text-normal");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Pre()
    {
        classes.Add("text-pre");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder PreLine()
    {
        classes.Add("text-pre-line");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder PreWrap()
    {
        classes.Add("text-pre-wrap");
        return new CssTextBuilder(classes);
    }
}

internal class CssTextTransformBuilder : ICssTextTransformBuilder
{
    private readonly CssCollection classes;

    public CssTextTransformBuilder(CssCollection classes)
    {
        this.classes = classes;
    }

    public ICssTextBuilder Capitalize()
    {
        classes.Add("text-transform-capitalize");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Lowercase()
    {
        classes.Add("text-transform-lowercase");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder None()
    {
        classes.Add("text-transform-none");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Uppercase()
    {
        classes.Add("text-transform-uppercase");
        return new CssTextBuilder(classes);
    }
}

internal class CssTextDecorationBuilder : ICssTextDecorationBuilder
{
    private readonly CssCollection classes;

    public CssTextDecorationBuilder(CssCollection classes)
    {
        this.classes = classes;
    }

    public ICssTextBuilder LineThrough()
    {
        classes.Add("text-decoration-line-through");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder LineThroughOverline()
    {
        classes.Add("text-decoration-line-through-overline");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder None()
    {
        classes.Add("text-decoration-none");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Overline()
    {
        classes.Add("text-decoration-overline");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder OverlineLineThrough()
    {
        throw new NotImplementedException();
    }

    public ICssTextBuilder OverlineUnderlineLineThrough()
    {
        throw new NotImplementedException();
    }

    public ICssTextBuilder Underline()
    {
        classes.Add("text-decoration-underline");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder UnderlineLineThrough()
    {
        throw new NotImplementedException();
    }

    public ICssTextBuilder UnderlineOverline()
    {
        throw new NotImplementedException();
    }
}

internal class CssTextAlignBuilder : ICssTextAlignBuilder
{
    private readonly CssCollection classes;

    public CssTextAlignBuilder(CssCollection classes)
    {
        this.classes = classes;
    }

    public ICssTextBuilder Center()
    {
        classes.Add("text-center");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder End()
    {
        classes.Add("text-end");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Justify()
    {
        classes.Add("text-justify");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Left()
    {
        classes.Add("text-left");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Right()
    {
        classes.Add("text-right");
        return new CssTextBuilder(classes);
    }

    public ICssTextBuilder Start()
    {
        classes.Add("text-start");
        return new CssTextBuilder(classes);
    }
}