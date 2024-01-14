using System.Text;

namespace RoyalCode.Yasamen.Commons.Internal;

internal readonly struct ClassesCollection
{
    private readonly StringBuilder builder;

    public ClassesCollection()
    {
        builder = new StringBuilder();
    }
    
    public void Add(string? cssClass)
    {
        if (cssClass is null)
            return;

        if (builder.Length > 0)
            builder.Append(' ');

        builder.Append(cssClass);
    }

    public bool IsEmpty => builder.Length == 0;

    public override string ToString() => builder.ToString();
}