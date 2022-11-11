namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components.Contexts;

public class ScenePropertyValue
{
    private readonly IScene scene;

    public ScenePropertyValue(IShowPropertyDescription p, IScene scene)
    {
        this.scene = scene;
        PropertyDescription = p;

        InitValue();
    }

    public IShowPropertyDescription PropertyDescription { get; }

    public object? Value { get; set; }

    public TValue? TryGetValue<TValue>()
        => Value is TValue v ? v : default;

    public string ValueString => Value?.ToString() ?? string.Empty;

    public int ValueInt => Value is int i ? i : 0;

    public long ValueLong => Value is long l ? l : 0;

    public float ValueFloat => Value is float f ? f : 0;

    public double ValueDouble => Value is double d ? d : 0;

    public decimal ValueDecimal => Value is decimal m ? m : 0;
    
    public bool ValueBool => Value is bool b && b;
    
    public List<string>? ValueClasses => PropertyDescription.IsHtmlClasses ? (List<string>)Value! : null;

    private void InitValue()
    {
        if (PropertyDescription.IsHtmlAttributes)
        {
            Value = new Dictionary<string, object>();
            return;
        }

        if (PropertyDescription.IsHtmlClasses)
        {
            Value = new List<string>();
            return;
        }

        if (PropertyDescription.IsEnum())
        {
            if (PropertyDescription.EnumType is not null)
            {
                var values = Enum.GetValues(PropertyDescription.EnumType);
                Value = values.GetValue(0);
            }
            else
            {
                Value = PropertyDescription.EnumType?.GetEnumValues().GetValue(0);
            }

            return;
        }

        if (PropertyDescription.IsStringType())
        {
            Value = PropertyDescription.Name;
            return;
        }

        if (PropertyDescription.IsNumberType())
        {
            Value = 0;
            return;
        }

        if (PropertyDescription.IsBoolType())
        {
            Value = false;
            return;
        }
    }
}