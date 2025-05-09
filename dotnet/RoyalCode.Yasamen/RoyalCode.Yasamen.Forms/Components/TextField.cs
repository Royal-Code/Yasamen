using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class TextField : InputFieldBase<string>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override bool TryParseValue(string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out string result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        result = value ?? string.Empty;
        errorMessage = null;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override string? FormatValue(string? value) => value;
}
