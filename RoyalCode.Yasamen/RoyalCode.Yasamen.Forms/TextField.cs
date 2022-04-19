using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Yasamen.Forms;

public class TextField : InputFieldBase<string>
{
    protected override bool TryParseValueFromString(
        string? value, 
        [MaybeNullWhen(false)] out string result, 
        [NotNullWhen(false)] out string? validationErrorMessage)
    {
        result = value ?? string.Empty;
        validationErrorMessage = null;
        return true;
    }
}