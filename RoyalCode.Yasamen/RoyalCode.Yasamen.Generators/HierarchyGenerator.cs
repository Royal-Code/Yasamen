
using System.Text;

namespace RoyalCode.Yasamen.Generators;

internal class HierarchyGenerator
{
    private string extends;
    private List<string> implements;

    public string Extends { set => extends = value; }

    public void AddImplements(string typeName)
    {
        implements ??= new();

        if (implements.Contains(typeName))
            return;

        implements.Add(typeName);
    }

    public void Write(StringBuilder sb)
    {
        if (extends is not null || implements is not null)
        {
            sb.Append(" : ");

            if (extends is not null)
            {
                sb.Append(extends);
            }

            if (implements is not null)
            {
                if (extends is not null)
                    sb.Append(", ");
                sb.Append(string.Join(", ", implements));
            }
        }
    }
}
