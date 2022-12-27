using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;

namespace RoyalCode.Yasamen.Generators;

[Generator(LanguageNames.CSharp)]
public class MultiplesParametersIncrementalGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var properties = context.SyntaxProvider.CreateSyntaxProvider(HasAttribute, GetPropertyDeclarationSyntax)
            .Where(static p => p is not null)
            .Collect();

        var compilation = context.CompilationProvider.Combine(properties);

        context.RegisterSourceOutput(compilation,
                static (spc, source) => Execute(source.Item1, source.Item2, spc));
    }
    
    private bool HasAttribute(SyntaxNode node, CancellationToken _)
    {
        return node is PropertyDeclarationSyntax property && property.AttributeLists.Count > 0;
    }

    private PropertyDeclarationSyntax GetPropertyDeclarationSyntax(GeneratorSyntaxContext context, CancellationToken _)
    {
        var propertyDeclaration = (PropertyDeclarationSyntax)context.Node;
        if (propertyDeclaration.TryGetAttribute("MultiplesParameters") is not null)
            return propertyDeclaration;
        return null;
    }

    private static void Execute(
        Compilation compilation, 
        ImmutableArray<PropertyDeclarationSyntax> properties,
        SourceProductionContext context)
    {
        if (properties.IsDefaultOrEmpty)
        {
            // nothing to do yet
            return;
        }

        // group the fields by class
        var groups = properties.GroupBy(m => m.Parent);

        foreach (var group in groups)
        {
            var classDeclarationSyntax = (group.Key as ClassDeclarationSyntax)!;
            var classMethods = group.ToList();

            if (!GuardParentIsAPartialClass(context, classDeclarationSyntax, classMethods[0].GetLocation()))
                continue;

            // get the class model
            var classModel = compilation.GetSemanticModel(classDeclarationSyntax.SyntaxTree)
                .GetDeclaredSymbol(classDeclarationSyntax)!;
            // get class name
            var className = classModel.Name;
            // get class namespace
            var classNamespace = classModel.ContainingNamespace.ToDisplayString();

            var generator = new MultiplesParametersGenerator(compilation, context, className, classNamespace);

            for (int i = 0; i < classMethods.Count; i++)
            {
                generator.AddProperty(properties[i]);
            }

            generator.Generate();
        }
    }

    private static bool GuardParentIsAPartialClass(
        SourceProductionContext context,
        ClassDeclarationSyntax classDeclaration,
        Location location)
    {
        if (classDeclaration is null || !classDeclaration.Modifiers.Any(SyntaxKind.PartialKeyword))
        {
            // create diagnostic for class is not a partial class
            var diagnostic = Diagnostic.Create(
                new DiagnosticDescriptor(
                    "YAMP001",
                    "Class is not a partial class",
                    "Class {0} is not a partial class",
                    "MultiplesParametersGenerator",
                    DiagnosticSeverity.Error,
                    true),
                location,
                classDeclaration?.Identifier.Text ?? "Unknown");

            // add diagnostic
            context.ReportDiagnostic(diagnostic);

            return false;
        }

        return true;
    }
}
