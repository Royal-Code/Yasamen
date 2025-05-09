namespace RoyalCode.Yasamen.Commons;

public sealed class CapturedValue
{
    public static implicit operator string?(CapturedValue? capturedValue) => capturedValue?.ToString();

    public object? Value { get; set; }

    public override string? ToString()
    {
        return Value is string s ? s : Value?.ToString();
    }
}