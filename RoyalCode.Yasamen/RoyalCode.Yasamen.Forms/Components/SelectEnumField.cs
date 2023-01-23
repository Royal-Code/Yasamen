
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.ComponentModel;
using System.Reflection;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class SelectEnumField<TEnum> : SelectFieldBase<TEnum>
    where TEnum : Enum
{
    [Parameter]
    public string? EmptyDescription { get; set; }

    protected override int RenderOptions(RenderTreeBuilder builder, int index)
    {
        var options = EnumOptions.GetOptions<TEnum>();

        if (EmptyDescription is not null)
        {
            builder.OpenElement(index, "option");
            builder.SetKey(string.Empty);
            builder.AddAttribute(1 + index, "value", "");
            builder.AddContent(2 + index, EmptyDescription);
            builder.CloseElement();
        }

        foreach (var option in options)
        {
            builder.OpenElement(index, "option");
            builder.SetKey(option.Value);
            builder.AddAttribute(1 + index, "value", option.Value);
            builder.AddContent(2 + index, option.Description);
            builder.CloseElement();
        }

        return index + 3;
    }
    
    
}

public struct EnumOptions
{
    private static readonly Dictionary<Type, List<EnumOptions>> cache = new();
    
    public string Value { get; init; }

    public string Description { get; init; }

    public static IEnumerable<EnumOptions> GetOptions<TEnum>()
        where TEnum : Enum
    {
        if (cache.TryGetValue(typeof(TEnum), out var options))
            return options;

        options = CreateOptions<TEnum>().ToList();
        cache.Add(typeof(TEnum), options);
        return options;
    }


    public static IEnumerable<EnumOptions> CreateOptions<TEnum>()
        where TEnum : Enum
    {
        // get all fields of the enum
        var fields = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static);
        // for each field, get the value as string and the description
        foreach (var field in fields)
        {
            yield return new EnumOptions
            {
                Value = field.Name,
                Description = field.GetCustomAttribute<DescriptionAttribute>()?.Description ?? field.Name
            };
        }
    }
}