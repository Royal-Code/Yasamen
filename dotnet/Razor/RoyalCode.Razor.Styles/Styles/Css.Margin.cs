namespace RoyalCode.Razor.Styles;

/// <summary>
/// Utility to create CSS classes for components.
/// </summary>
public static partial class Css
{
    public static MarginBuilder Margin => MarginBuilder.Default;
}

public readonly struct MarginBuilder
{
    private readonly SpacingSide side;
    private readonly SpacingSize size;
    public MarginBuilder(SpacingSide side, SpacingSize size)
    {
        this.side = side;
        this.size = size;
    }

    public static MarginBuilder Default => new(SpacingSide.None, SpacingSize.None);

    public MarginSideBuilder Side => new MarginSideBuilder(this);

    public MarginSizeBuilder Size => new MarginSizeBuilder(this);

    public MarginBuilder WithSide(SpacingSide side)
    {
        return new MarginBuilder(side, size);
    }
    public MarginBuilder WithSize(SpacingSize size)
    {
        return new MarginBuilder(side, size);
    }
    public override string ToString()
    {
        if (side == SpacingSide.None)
            return string.Empty;

        return SpacingMap.GetMarginCssClass(side, size);
    }
}

public readonly struct MarginSideBuilder
{
    private readonly MarginBuilder builder;
    public MarginSideBuilder(MarginBuilder builder)
    {
        this.builder = builder;
    }
    public MarginBuilder None() => builder.WithSide(SpacingSide.None);
    public MarginBuilder Top() => builder.WithSide(SpacingSide.Top);
    public MarginBuilder Right() => builder.WithSide(SpacingSide.Right);
    public MarginBuilder Bottom() => builder.WithSide(SpacingSide.Bottom);
    public MarginBuilder Left() => builder.WithSide(SpacingSide.Left);
    public MarginBuilder Horizontal() => builder.WithSide(SpacingSide.Horizontal);
    public MarginBuilder Vertical() => builder.WithSide(SpacingSide.Vertical);
    public MarginBuilder All() => builder.WithSide(SpacingSide.All);
}

public readonly struct MarginSizeBuilder
{
    private readonly MarginBuilder builder;
    public MarginSizeBuilder(MarginBuilder builder)
    {
        this.builder = builder;
    }
    public MarginBuilder None() => builder.WithSize(SpacingSize.None);
    public MarginBuilder One() => builder.WithSize(SpacingSize.One);
    public MarginBuilder Two() => builder.WithSize(SpacingSize.Two);
    public MarginBuilder SmallerX2() => builder.WithSize(SpacingSize.SmallerX2);
    public MarginBuilder Smaller() => builder.WithSize(SpacingSize.Smaller);
    public MarginBuilder Small() => builder.WithSize(SpacingSize.Small);
    public MarginBuilder Medium() => builder.WithSize(SpacingSize.Medium);
    public MarginBuilder Large() => builder.WithSize(SpacingSize.Large);
    public MarginBuilder Larger() => builder.WithSize(SpacingSize.Larger);
    public MarginBuilder LargerX2() => builder.WithSize(SpacingSize.LargerX2);
    public MarginBuilder LargerX3() => builder.WithSize(SpacingSize.LargerX3);
    public MarginBuilder LargerX4() => builder.WithSize(SpacingSize.LargerX4);
    public MarginBuilder LargerX5() => builder.WithSize(SpacingSize.LargerX5);
    public MarginBuilder Largest() => builder.WithSize(SpacingSize.Largest);
    public MarginBuilder Initial() => builder.WithSize(SpacingSize.Initial);
}
