using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Generators.Tests;

[UsesVerify]
public class MultiplesParametersTests
{
    [Fact]
    public async Task SingleMultiplesParametersProperty()
    {
        await MultiplesParametersTestHelper.Verify(CodeForTest.CodeSingle);       
    }

    [Fact]
    public async Task WithInterfaceMultiplesParametersProperty()
    {
        await MultiplesParametersTestHelper.Verify(CodeForTest.CodeInterface);
    }
}

public static class MultiplesParametersTestHelper
{
    public static Task Verify(string source)
    {
        // Parse the provided string into a C# syntax tree
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);

        // Create a Roslyn compilation for the syntax tree.
        CSharpCompilation compilation = CSharpCompilation.Create(
            assemblyName: "Tests",
            syntaxTrees: new[] { syntaxTree });

        // Create an instance of our MultiplesParametersIncrementalGenerator incremental source generator
        var generator = new MultiplesParametersIncrementalGenerator();

        // The GeneratorDriver is used to run our generator against a compilation
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        // Run the source generator!
        driver = driver.RunGenerators(compilation);

        // Use verify to snapshot test the source generator output!
        return Verifier.Verify(driver);
    }
}

file class CodeForTest
{
    public const string CodeSingle =
"""
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Generators.Tests;

public partial class TextComponent
{
    [MultiplesParameters]
    public TestParametersType Parameters { get; set; } = new();
}


public class TestParametersType
{

    public int Cols { get; set; }

    public int? XsCols { get; set; }

    public int? SmCols { get; set; }

    public int? MdCols { get; set; }

    public int? LgCols { get; set; }

    public int? XlCols { get; set; }
}

""";


    public const string CodeInterface =
"""
using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Generators.Tests;

[MultiplesParameters]
public interface IHasColumns
{
    int Cols { get; set; }
}

public partial class TextComponent
{
    [MultiplesParameters]
    public TestParametersType Parameters { get; set; } = new();
}

public class TestParametersType : IHasColumns
{

    public int Cols { get; set; }
}

""";
}

public partial class MyTextComponent
{
    [MultiplesParameters]
    public MyTestParametersType Parameters { get; set; } = new();
    
}

public class MyTestParametersType
{

    public int Cols { get; set; }

    public int? XsCols { get; set; }

    public int? SmCols { get; set; }

    public int? MdCols { get; set; }

    public int? LgCols { get; set; }

    public int? XlCols { get; set; }
}