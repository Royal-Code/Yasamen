using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;

namespace RoyalCode.Yasamen.Generators;

public static class ExtensionMethods
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static AttributeSyntax TryGetAttribute(this MemberDeclarationSyntax node, string attributeSimpleName)
    {
        var attributesLists = node.AttributeLists;
        foreach (var attributeList in attributesLists)
        {
            foreach (AttributeSyntax attribute in attributeList.Attributes)
            {
                if (CheckName(attribute, attributeSimpleName))
                    return attribute;
            }
        }
        return null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool CheckName(AttributeSyntax attribute, string attributeSimpleName)
    {
        var name = attribute.Name;
        if (name is SimpleNameSyntax simpleName)
        {
            return simpleName.Identifier.Text.FastStartWith(attributeSimpleName);
        }
        else if (name is QualifiedNameSyntax qualifiedName)
        {
            return qualifiedName.Right.Identifier.Text.FastEndWith($"{attributeSimpleName}Attribute");
        }
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool FastStartWith(this string text, string value)
    {
        if (text.Length < value.Length)
            return false;
        for (int i = 0; i < value.Length; i++)
        {
            if (text[i] != value[i])
                return false;
        }
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool FastEndWith(this string text, string value)
    {
        if (text.Length < value.Length)
            return false;
        for (int i = 0; i < value.Length; i++)
        {
            if (text[text.Length - i - 1] != value[value.Length - i - 1])
                return false;
        }
        return true;
    }
}
