namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public interface IValueSet
{
    object? GetFirst();

    object? GetValueSetByValue(object value);

    Type GetValueType();
}
