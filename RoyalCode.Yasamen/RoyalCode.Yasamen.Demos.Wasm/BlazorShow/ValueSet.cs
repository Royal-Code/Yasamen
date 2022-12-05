namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public class ValueSet<TValue> : List<ValueDescription<TValue>>, IValueSet
{
    public object? GetFirst()
    {
        return this.FirstOrDefault();
    }

    public object? GetValueSetByValue(object value)
    {
        return this.FirstOrDefault(p => p.Value.Equals(value));
    }

    public Type GetValueType() => typeof(ValueDescription<TValue>);
}
