namespace RoyalCode.Yasamen.Commons;

public interface ICssBuilder
{
    /// <summary>
    /// Make element visible.
    /// </summary>
    /// <returns>The builder for fluent construct CSS classes.</returns>
    ICssBuilder Visible();

    /// <summary>
    /// Make element invisible.
    /// </summary>
    /// <returns></returns>
    ICssBuilder Invisible();

    /// <summary>
    /// Make element opaque.
    /// </summary>
    /// <param name="opacity">From 0 to 5.</param>
    /// <returns>The builder for fluent construct CSS classes.</returns>
    ICssBuilder Opacity(int opacity);

    /// <summary>
    /// Apply a gap between elements.
    /// </summary>
    /// <param name="gap">From 0 to 5.</param>
    /// <returns>The builder for fluent construct CSS classes.</returns>
    ICssBuilder Gap(int gap);

    /// <summary>
    /// Apply a vertical gap between elements.
    /// </summary>
    /// <param name="gap"></param>
    /// <returns>The builder for fluent construct CSS classes.</returns>
    ICssBuilder GapVertical(int gap);

    /// <summary>
    /// Apply a horizontal gap between elements.
    /// </summary>
    /// <param name="gap">From 0 to 5.</param>
    /// <returns>The builder for fluent construct CSS classes.</returns>
    ICssBuilder GapHorizontal(int gap);

    /// <summary>
    /// Apply shadow to the element.
    /// </summary>
    /// <param name="shadow">From 0 to 5.</param>
    /// <returns>The builder for fluent construct CSS classes.</returns>
    ICssBuilder Shadow(int shadow);

    /// <summary>
    /// Select the width and height of the element.
    /// </summary>
    ICssSizeBuilder Sizes { get; }

    /// <summary>
    /// Select the alignment of the element.
    /// </summary>
    ICssAlignBuilder Align { get; }

    /// <summary>
    /// Select the float direction of the element.
    /// </summary>
    ICssFloatBuilder Float { get; }

    /// <summary>
    /// Select the display of the element.
    /// </summary>
    ICssDisplayBuilder Display { get; }

    /// <summary>
    /// Select the element position.
    /// </summary>
    ICssPositionBuilder Position { get; }

    /// <summary>
    /// Select the margins of the element.
    /// </summary>
    ICssMarginBuilder Margin { get; }

    /// <summary>
    /// Select the paddings of the element.
    /// </summary>
    ICssPaddingBuilder Padding { get; }

    /// <summary>
    /// Select the background of the element.
    /// </summary>
    ICssBackgroundBuilder Background { get; }

    /// <summary>
    /// Select the text CSS properties of the element.
    /// </summary>
    ICssTextBuilder Text { get; }
}

public interface ICssTextBuilder : ICssBuilder
{
    ICssTextAlignBuilder TextAlign { get; }

    ICssTextDecorationBuilder Decoration { get; }

    ICssTextTransformBuilder Transform { get; }

    ICssTextSpaceBuilder WhiteSpace { get; }

    ICssTextColorBuilder Color { get; }

    ICssTextBuilder Truncate();

    ICssTextBuilder Break();
}

public interface ICssTextColorBuilder
{
    ICssTextBuilder Default();

    ICssTextBuilder Main();

    ICssTextBuilder Muted();

    ICssTextBuilder Primary();

    ICssTextBuilder Secondary();

    ICssTextBuilder Success();

    ICssTextBuilder Info();

    ICssTextBuilder Warning();

    ICssTextBuilder Danger();

    ICssTextBuilder Light();

    ICssTextBuilder Dark();

    ICssTextBuilder Body();

    ICssTextBuilder Black();

    ICssTextBuilder White();

    ICssTextBuilder Black50();

    ICssTextBuilder White50();

    ICssTextBuilder Reset();
}

public interface ICssTextSpaceBuilder
{
    ICssTextBuilder Normal();

    ICssTextBuilder NoWrap();

    ICssTextBuilder Pre();

    ICssTextBuilder PreLine();

    ICssTextBuilder PreWrap();
}

public interface ICssTextTransformBuilder
{
    ICssTextBuilder Lowercase();

    ICssTextBuilder Uppercase();

    ICssTextBuilder Capitalize();
}

public interface ICssTextDecorationBuilder
{
    ICssTextBuilder None();

    ICssTextBuilder Underline();

    ICssTextBuilder LineThrough();

    ICssTextBuilder Overline();

    ICssTextBuilder UnderlineLineThrough();

    ICssTextBuilder OverlineLineThrough();

    ICssTextBuilder UnderlineOverline();

    ICssTextBuilder LineThroughOverline();

    ICssTextBuilder OverlineUnderlineLineThrough();
}

public interface ICssTextAlignBuilder
{
    ICssTextBuilder Left();

    ICssTextBuilder Right();

    ICssTextBuilder Center();
}

public interface ICssBackgroundBuilder : ICssBuilder
{
    ICssBackgroundBuilder Main();

    ICssBackgroundBuilder Primary();

    ICssBackgroundBuilder Secondary();

    ICssBackgroundBuilder Success();

    ICssBackgroundBuilder Danger();

    ICssBackgroundBuilder Warning();

    ICssBackgroundBuilder Info();

    ICssBackgroundBuilder Light();

    ICssBackgroundBuilder Dark();

    ICssBackgroundBuilder Black();

    ICssBackgroundBuilder White();

    ICssBackgroundBuilder Transparent();

    ICssBackgroundBuilder Body();
}

public interface ICssPaddingBuilder : ICssBuilder
{
    ICssPaddingBuilder All(int padding);

    ICssPaddingBuilder Vertical(int padding);

    ICssPaddingBuilder Horizontal(int padding);

    ICssPaddingBuilder Top(int padding);

    ICssPaddingBuilder Bottom(int padding);

    ICssPaddingBuilder Start(int padding);

    ICssPaddingBuilder End(int padding);
}

public interface ICssMarginBuilder : ICssBuilder
{
    ICssMarginBuilder All(int margin);

    ICssMarginBuilder Vertical(int margin);

    ICssMarginBuilder Horizontal(int margin);

    ICssMarginBuilder Top(int margin);

    ICssMarginBuilder Bottom(int margin);

    ICssMarginBuilder Start(int margin);

    ICssMarginBuilder End(int margin);

    ICssMarginAutoBuilder Auto { get; }
}

public interface ICssMarginAutoBuilder : ICssBuilder
{
    ICssMarginAutoBuilder All();

    ICssMarginAutoBuilder Vertical();

    ICssMarginAutoBuilder Horizontal();

    ICssMarginAutoBuilder Top();

    ICssMarginAutoBuilder Bottom();

    ICssMarginAutoBuilder Start();

    ICssMarginAutoBuilder End();
}

public interface ICssPositionBuilder : ICssBuilder
{
    ICssPositionBuilder Static();

    ICssPositionBuilder Relative();

    ICssPositionBuilder Absolute();

    ICssPositionBuilder Fixed();

    ICssPositionBuilder Sticky();
}

public interface ICssDisplayBuilder : ICssBuilder
{
    ICssDisplayBuilder Inline();

    ICssDisplayBuilder InlineBlock();

    ICssDisplayBuilder Block();

    ICssDisplayBuilder Grid();

    ICssDisplayBuilder Table();

    ICssDisplayBuilder TableRow();

    ICssDisplayBuilder TableCell();

    ICssDisplayBuilder Flex();

    ICssDisplayBuilder InlineFlex();

    ICssDisplayBuilder None();
}

public interface ICssFloatBuilder : ICssBuilder
{
    ICssFloatBuilder Start();

    ICssFloatBuilder End();

    ICssFloatBuilder None();
}

public interface ICssSizeBuilder : ICssBuilder
{
    ICssSizeBuilder Width25();

    ICssSizeBuilder Width50();

    ICssSizeBuilder Width75();

    ICssSizeBuilder Width100();

    ICssSizeBuilder WidthAuto();

    ICssSizeBuilder Height25();

    ICssSizeBuilder Height50();

    ICssSizeBuilder Height75();

    ICssSizeBuilder Height100();

    ICssSizeBuilder HeightAuto();
}

public interface ICssAlignBuilder : ICssBuilder
{
    ICssVerticalAlignBuilder Vertical { get; }
}

public interface ICssVerticalAlignBuilder : ICssAlignBuilder
{
    ICssVerticalAlignBuilder Baseline();

    ICssVerticalAlignBuilder Top();

    ICssVerticalAlignBuilder Middle();

    ICssVerticalAlignBuilder Bottom();

    ICssVerticalAlignBuilder TextTop();

    ICssVerticalAlignBuilder TextBottom();
}

