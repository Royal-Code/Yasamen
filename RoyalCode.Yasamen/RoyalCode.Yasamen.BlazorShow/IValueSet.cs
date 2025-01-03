namespace RoyalCode.YasamenBlazorShow;

public interface IValueSet
{
    object? GetFirst();

    object? GetValueSetByValue(object value);

    Type GetValueType();
}
