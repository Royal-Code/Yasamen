using Microsoft.CodeAnalysis;
using System.Text;

namespace RoyalCode.Yasamen.Generators;

internal class UsingsGenerator
{
    private readonly string typeNameSpace;
    private readonly List<string> usings = new();
    
    public UsingsGenerator(string typeNameSpace)
    {
        this.typeNameSpace = typeNameSpace;
    }
    
    public void AddUsing(string @namespace)
    {
        if (typeNameSpace == @namespace)
            return;
        
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

