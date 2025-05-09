using System.Runtime.CompilerServices;

namespace RoyalCode.Yasamen.Generators.Tests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifySourceGenerators.Initialize();
    }
}
