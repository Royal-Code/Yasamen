using RoyalCode.Razor.Internal.Forms;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace RoyalCode.Razor.Components;

/// <summary>
/// A text input field component.
/// </summary>
public class TextField : InputFieldBase<string>
{
    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override bool TryParseValue(string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out string result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        result = value ?? string.Empty;
        errorMessage = null;
        return true;
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override string? FormatValue(string? value) => value;
}
