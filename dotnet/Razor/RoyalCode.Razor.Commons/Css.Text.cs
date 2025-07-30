using RoyalCode.Razor.Commons.Styles;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RoyalCode.Yasamen.Commons;

public static partial class Css
{
}

#region Text

public readonly struct TextClasses
{
    public override string ToString()
    {
        return string.Join(' ', AllCssClasses().Where(s => s != string.Empty));
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is TextClasses text && this == text;
    }

    public override int GetHashCode()
    {
        return 0;// HashCode.Combine(positions, theme, width, style, round, radius, shadow);
    }

    public static bool operator ==(TextClasses left, TextClasses right)
    {
        return left == right;
    }

    public static bool operator !=(TextClasses left, TextClasses right)
    {
        return !(left == right);
    }

    public static implicit operator string(TextClasses builder) => builder.ToString();

    private IEnumerable<string> AllCssClasses()
    {
        yield return string.Empty;
    }
}

public readonly struct TextBuilder
{
    private readonly Fonts font;
    private readonly TextAlign align;

    public TextBuilder(Fonts font, TextAlign align)
    {
        this.font = font;
        this.align = align;
    }

    public TextClasses Build() => new();

    public override string ToString() => Build();

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is TextBuilder builder && this == builder;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(font, align);
    }

    public static bool operator ==(TextBuilder left, TextBuilder right)
    {
        return left.font == right.font &&
               left.align == right.align;
    }

    public static bool operator !=(TextBuilder left, TextBuilder right)
    {
        return !(left == right);
    }

    public static implicit operator string(TextBuilder builder) => builder.ToString();

    public static implicit operator TextClasses(TextBuilder builder) => builder.Build();
}

#endregion