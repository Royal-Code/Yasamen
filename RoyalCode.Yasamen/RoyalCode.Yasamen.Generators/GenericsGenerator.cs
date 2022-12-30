
using System.Text;

namespace RoyalCode.Yasamen.Generators;

internal class GenericsGenerator
{
    private List<string> generics;

    public void AddGeneric(string typeName)
    {
        generics ??= new();

        if (generics.Contains(typeName))
            return;

        generics.Add(typeName);
    }

    public void Write(StringBuilder sb)
    {
        if (generics is not null)
        {
            sb.Append("<");
            sb.Append(string.Join(", ", generics));
            sb.Append(">");
        }
    }
}
