using Microsoft.CodeAnalysis;
using System.Text;

namespace RoyalCode.DomainEvents.SourceGenerator;

internal abstract class GeneratorBase
{
    private UsingsGenerator usingsGenerator;
    private List<Action<StringBuilder>> bodyGenerators;

    public GeneratorBase(SourceProductionContext context, string @namespace, string className)
    {
        Context = context;
        Namespace = @namespace;
        ClassName = className;
    }

    public UsingsGenerator UsingsGenerator => usingsGenerator ??= new();

    public SourceProductionContext Context { get; }


    public string Namespace { get; }

    public string ClassName { get; }

    protected string ExtensionFileName { get; set; } = string.Empty;

    public void AddBodyGenerator(Action<StringBuilder> generator)
    {
        bodyGenerators ??= new();
        bodyGenerators.Add(generator);
    }

    public void Write(StringBuilder sb)
    {
        if (Namespace is null)
            throw new InvalidOperationException("Namespace is null.");

        if (ClassName is null)
            throw new InvalidOperationException("ClassName is null.");

        if (usingsGenerator is not null)
        {
            usingsGenerator.Write(sb);
            sb.AppendLine();
        }

        sb.AppendLine($"namespace {Namespace}");
        sb.AppendLine("{");
        sb.AppendLine($"    public partial class {ClassName}");
        sb.AppendLine("    {");

        if (bodyGenerators is not null)
        {
            foreach (var generator in bodyGenerators)
            {
                generator(sb);
                sb.AppendLine();
            }
        }

        sb.AppendLine("    }");
        sb.AppendLine("}");
    }

    public virtual void Generate()
    {
        StringBuilder builder = new();
        Write(builder);
        var source = builder.ToString();

        // write the source
        Context.AddSource($"{ClassName}{ExtensionFileName}.g.cs", source);
    }
}

