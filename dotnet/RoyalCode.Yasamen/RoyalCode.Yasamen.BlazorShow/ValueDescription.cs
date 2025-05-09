namespace RoyalCode.Yasamen.BlazorShow;

public record ValueDescription<TValue>(string Name, TValue Value, string? Description = null) : IValueDescription
{
    public object? GetValue() => Value;
}