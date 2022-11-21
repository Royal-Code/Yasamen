namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow;

public class ValueSet<TValue> : List<ValueDescription<TValue>>, IValueSet
{
    public object? GetFirst()
    {
        return this.FirstOrDefault();
    }

    public Type GetValueType() => typeof(ValueDescription<TValue>);
}
