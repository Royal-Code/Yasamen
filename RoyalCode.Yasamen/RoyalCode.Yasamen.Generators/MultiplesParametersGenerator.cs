
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoyalCode.DomainEvents.SourceGenerator;

namespace RoyalCode.Yasamen.Generators;

internal class MultiplesParametersGenerator : GeneratorBase
{
    private const string spaces = "        ";
    
    private readonly Compilation compilation;

    public MultiplesParametersGenerator(
        Compilation compilation, 
        SourceProductionContext context,
        string className,
        string classNamespace)
        : base(context, classNamespace, className)
    {
        this.compilation = compilation;

        UsingsGenerator.AddUsing("Microsoft.AspNetCore.Components");
        ExtensionFileName = "_MultiplesParameters";
    }

    internal void AddProperty(PropertyDeclarationSyntax propertyDeclarationSyntax)
    {
        // obtém o nome da propriedade
        var propertyName = propertyDeclarationSyntax.Identifier.Text;

        // obtém o tipo da propriedade (propertyDeclarationSyntax)
        var propertyType = compilation.GetSemanticModel(propertyDeclarationSyntax.SyntaxTree)
            .GetTypeInfo(propertyDeclarationSyntax.Type).Type;

        // obtém as propriedades públicas com get e set do tipo (propertyType)
        var innerProperties = propertyType.GetMembers()
            .OfType<IPropertySymbol>()
            .Where(p => p.DeclaredAccessibility == Accessibility.Public && p.SetMethod != null && p.GetMethod != null);
        
        foreach(var innerProp in innerProperties)
        {
            AddBodyGenerator(sb =>
            {
                sb.AppendLine();

                // gera nova propriedade lendo e escrevendo na propriedade de origem
                sb.Append(spaces).AppendLine("[Parameter]");
                sb.Append(spaces).AppendLine($"public {innerProp.Type} {innerProp.Name}");
                sb.Append(spaces).AppendLine(@"{");
                sb.Append(spaces).AppendLine($"    get => {propertyName}.{innerProp.Name};");
                sb.Append(spaces).AppendLine($"    set => {propertyName}.{innerProp.Name} = value;");
                sb.Append(spaces).AppendLine(@"}");
                
            });
        }
    }
}
