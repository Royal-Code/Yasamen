namespace RoyalCode.Yasamen.BlazorShow;

public interface IValueSet
{
    object? GetFirst();

    object? GetValueSetByValue(object value);

    Type GetValueType();
}
