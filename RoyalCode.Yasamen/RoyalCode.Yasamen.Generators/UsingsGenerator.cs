using Microsoft.CodeAnalysis;
using System.Text;

namespace RoyalCode.DomainEvents.SourceGenerator;

internal class UsingsGenerator
{
    private readonly List<string> usings = new();

    public void AddUsing(string @namespace)
    {
        if (!usings.Contains(@namespace))
            usings.Add(@namespace);
    }

    public void AddUsing(INamedTypeSymbol symbol)
    {
        AddUsing(symbol.ContainingNamespace.ToDisplayString());
    }

    public void Write(StringBuilder sb)
    {
        foreach (var @using in usings)
        {
            sb.AppendLine($"using {@using};");
        }
    }
}

