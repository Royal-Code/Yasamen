namespace RoyalCode.Razor.Styles;

/// <summary>
/// Utility to create CSS classes for components.
/// </summary>
public static partial class Css
{
    public static PaddingBuilder Padding => PaddingBuilder.None;
}

public readonly struct PaddingBuilder
{
    private readonly SpacingSide side;
    private readonly SpacingSize size;

    public PaddingBuilder(SpacingSide side, SpacingSize size)
    {
        this.side = side;
        this.size = size;
    }

    public static PaddingBuilder None => new(SpacingSide.None, SpacingSize.None);

    public PaddingSideBuilder Side => new PaddingSideBuilder(this);

    public PaddingSizeBuilder Size => new PaddingSizeBuilder(this);

    public PaddingBuilder WithSide(SpacingSide side)
    {
        return new PaddingBuilder(side, size);
    }

    public PaddingBuilder WithSize(SpacingSize size)
    {
        return new PaddingBuilder(side, size);
    }

    public override string ToString()
    {
        if (side == SpacingSide.None)
            return string.Empty;

        return SpacingMap.GetPaddingCssClass(side, size);
    }

    public static implicit operator string(PaddingBuilder builder) => builder.ToString();
}

public readonly struct PaddingSideBuilder
{
    private readonly PaddingBuilder builder;

    public PaddingSideBuilder(PaddingBuilder builder)
    {
        this.builder = builder;
    }

    public PaddingBuilder None() => builder.WithSide(SpacingSide.None);
    public PaddingBuilder Top() => builder.WithSide(SpacingSide.Top);
    public PaddingBuilder Right() => builder.WithSide(SpacingSide.Right);
    public PaddingBuilder Bottom() => builder.WithSide(SpacingSide.Bottom);
    public PaddingBuilder Left() => builder.WithSide(SpacingSide.Left);
    public PaddingBuilder Horizontal() => builder.WithSide(SpacingSide.Horizontal);
    public PaddingBuilder Vertical() => builder.WithSide(SpacingSide.Vertical);
    public PaddingBuilder All() => builder.WithSide(SpacingSide.All);
}

public readonly struct PaddingSizeBuilder
{
    private readonly PaddingBuilder builder;

    public PaddingSizeBuilder(PaddingBuilder builder)
    {
        this.builder = builder;
    }

    public PaddingBuilder None() => builder.WithSize(SpacingSize.None);
    public PaddingBuilder One() => builder.WithSize(SpacingSize.One);
    public PaddingBuilder Two() => builder.WithSize(SpacingSize.Two);
    public PaddingBuilder SmallerX2() => builder.WithSize(SpacingSize.SmallerX2);
    public PaddingBuilder Smaller() => builder.WithSize(SpacingSize.Smaller);
    public PaddingBuilder Small() => builder.WithSize(SpacingSize.Small);
    public PaddingBuilder Medium() => builder.WithSize(SpacingSize.Medium);
    public PaddingBuilder Large() => builder.WithSize(SpacingSize.Large);
    public PaddingBuilder Larger() => builder.WithSize(SpacingSize.Larger);
    public PaddingBuilder LargerX2() => builder.WithSize(SpacingSize.LargerX2);
    public PaddingBuilder LargerX3() => builder.WithSize(SpacingSize.LargerX3);
    public PaddingBuilder LargerX4() => builder.WithSize(SpacingSize.LargerX4);
    public PaddingBuilder LargerX5() => builder.WithSize(SpacingSize.LargerX5);
    public PaddingBuilder Largest() => builder.WithSize(SpacingSize.Largest);
    public PaddingBuilder Initial() => builder.WithSize(SpacingSize.Initial);
}
