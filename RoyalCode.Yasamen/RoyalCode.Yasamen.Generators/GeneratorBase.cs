using Microsoft.CodeAnalysis;
using System.Text;

namespace RoyalCode.Yasamen.Generators;

internal abstract class GeneratorBase
{
    private UsingsGenerator usingsGenerator;
    private GenericsGenerator genericsGenerator;
    private HierarchyGenerator hierarchyGenerator;
    private List<Action<StringBuilder>> bodyGenerators;

    protected GeneratorBase(SourceProductionContext context, string @namespace, string className)
    {
        Context = context;
        Namespace = @namespace;
        ClassName = className;
    }

    public UsingsGenerator UsingsGenerator => usingsGenerator ??= new(Namespace);

    public SourceProductionContext Context { get; }

    public GenericsGenerator GenericsGenerator => genericsGenerator ??= new();

    public HierarchyGenerator HierarchyGenerator => hierarchyGenerator ??= new();

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
        sb.Append($"    public partial class {ClassName}");
        genericsGenerator?.Write(sb);
        hierarchyGenerator?.Write(sb);
        sb.AppendLine();
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
        OnGenerating(builder);
        Write(builder);
        OnGenerated(builder);
        var source = builder.ToString();

        // write the source
        Context.AddSource($"{ClassName}{ExtensionFileName}.g.cs", source);
    }
    
    protected virtual void OnGenerating(StringBuilder builder) { }
    
    protected virtual void OnGenerated(StringBuilder builder) { }
}

