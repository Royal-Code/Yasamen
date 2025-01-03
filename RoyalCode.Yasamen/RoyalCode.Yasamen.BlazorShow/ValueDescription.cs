namespace RoyalCode.YasamenBlazorShow;

public record ValueDescription<TValue>(string Name, TValue Value, string? Description = null) : IValueDescription
{
    public object? GetValue() => Value;
}