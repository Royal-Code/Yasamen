using System.Text.Json;

namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Components.Contexts;

public class ScenePropertyValue
{
    private readonly Action changeStateCallback;

    public ScenePropertyValue(IShowPropertyDescription propertyDescription, Action changeStateCallback)
    {
        this.changeStateCallback = changeStateCallback;
        PropertyDescription = propertyDescription;

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

    public Dictionary<string, string>? ValueAttributes => PropertyDescription.IsHtmlAttributes ? (Dictionary<string, string>) Value! : null;

    public IEnumerable<KeyValuePair<string, object>> GetMultipleAttributes()
        => ValueAttributes?.Select(p => new KeyValuePair<string, object>(p.Key, p.Value)) ?? Enumerable.Empty<KeyValuePair<string, object>>();

    public Dictionary<string, object> GetAttributesDictionary()
        => ValueAttributes?.ToDictionary(p => p.Key, p => (object)p.Value) ?? new Dictionary<string, object>();

    public string GetClasses()
        => string.Join(" ", ValueClasses ?? Enumerable.Empty<string>());

    public void StateHasChanged() => changeStateCallback();

    private void InitValue()
    {
        if (PropertyDescription.IsHtmlAttributes)
        {
            Value = new Dictionary<string, string>();
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

    internal PropertySerialization Serialize()
    {
        return new PropertySerialization
        {
            PropertyName = PropertyDescription.Property.Name,
            SerializedValue = SerializeValue()
        };
    }

    private string SerializeValue()
    {
        if (PropertyDescription.IsHtmlAttributes)
        {
            return JsonSerializer.Serialize(ValueAttributes);
        }

        if (PropertyDescription.IsHtmlClasses)
        {
            return JsonSerializer.Serialize(ValueClasses);
        }

        if (PropertyDescription.IsEnum())
        {
            return Value?.ToString() ?? string.Empty;
        }

        if (PropertyDescription.IsStringType())
        {
            return Value?.ToString() ?? string.Empty;
        }

        if (PropertyDescription.IsNumberType())
        {
            return Value?.ToString() ?? string.Empty;
        }

        if (PropertyDescription.IsBoolType())
        {
            return Value?.ToString() ?? string.Empty;
        }

        return string.Empty;
    }

    internal void DeserializeValue(PropertySerialization valueSerialization)
    {
        if (PropertyDescription.IsHtmlAttributes)
        {
            Value = JsonSerializer.Deserialize<Dictionary<string, string>>(valueSerialization.SerializedValue);
            return;
        }

        if (PropertyDescription.IsHtmlClasses)
        {
            Value = JsonSerializer.Deserialize<List<string>>(valueSerialization.SerializedValue);
            return;
        }

        if (PropertyDescription.IsEnum())
        {
            Value = Enum.Parse(PropertyDescription.EnumType!, valueSerialization.SerializedValue);
            return;
        }

        if (PropertyDescription.IsStringType())
        {
            Value = valueSerialization.SerializedValue;
            return;
        }

        if (PropertyDescription.IsNumberType())
        {
            Value = Convert.ChangeType(valueSerialization.SerializedValue, PropertyDescription.Property.PropertyType);
            return;
        }

        if (PropertyDescription.IsBoolType())
        {
            Value = Convert.ChangeType(valueSerialization.SerializedValue, PropertyDescription.Property.PropertyType);
            return;
        }
    }

    internal class PropertySerialization
    {
        public string PropertyName { get; set; }

        public string? SerializedValue { get; set; }
    }
}