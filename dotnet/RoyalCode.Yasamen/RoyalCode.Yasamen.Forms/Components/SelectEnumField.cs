
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class SelectEnumField<TEnum> : SelectFieldBase<TEnum>
{
    private readonly Type targetType;
    private readonly bool nullable;
    private readonly IEnumerable<EnumOptions<TEnum>> options;

    public SelectEnumField()
    {
        var underlyingType = Nullable.GetUnderlyingType(typeof(TEnum));
        targetType = underlyingType ?? typeof(TEnum);
        nullable = underlyingType is not null;
        options = EnumOptions.GetOptions<TEnum>();
    }

    [Parameter]
    public string? EmptyDescription { get; set; }

    [Parameter]
    public Func<TEnum, string>? Description { get; set; }

    protected override int RenderOptions(RenderTreeBuilder builder, int index)
    {
        if (EmptyDescription is not null || nullable)
        {
            builder.OpenElement(index, "option");
            builder.SetKey(string.Empty);
            builder.AddAttribute(1 + index, "value", string.Empty);
            builder.AddContent(2 + index, EmptyDescription ?? string.Empty);
            builder.CloseElement();
        }

        foreach (var option in options)
        {
            builder.OpenElement(index, "option");
            builder.SetKey(option.Value);
            builder.AddAttribute(1 + index, "value", option.Value);
            builder.AddContent(2 + index, Description?.Invoke(option.Enum) ?? option.Description);
            builder.CloseElement();
        }

        return index + 3;
    }

    protected override bool TryParseValue(
        string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out TEnum result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        if ((EmptyDescription is not null || nullable) && string.IsNullOrEmpty(value))
        {
            result = default!;
            errorMessage = null;
            return true;
        }
        
        if(Enum.TryParse(targetType, value, true, out var parsedResult))
        {
            result = (TEnum)parsedResult;
            errorMessage = null;
            return true;
        }

        result = default;
        errorMessage = $"The field '{FieldName}' has a non-valid option.";
        return false;
    }

    protected override string? FormatValue(TEnum? value) => value?.ToString() ?? string.Empty;
}

public record EnumOptions<TEnum>
{
    public TEnum Enum { get; init; }

    public string Value { get; init; }

    public string Description { get; init; }
}

public static class EnumOptions
{
    private static readonly Dictionary<Type, IEnumerable<object>> cache = new();

    public static IEnumerable<EnumOptions<TEnum>> GetOptions<TEnum>()
    {
        if (cache.TryGetValue(typeof(TEnum), out var options))
            return (IEnumerable<EnumOptions<TEnum>>)options;

        var newOptions = CreateOptions<TEnum>().ToList();
        cache.Add(typeof(TEnum), newOptions);
        return newOptions;
    }


    public static IEnumerable<EnumOptions<TEnum>> CreateOptions<TEnum>()
    {
        var targetType = Nullable.GetUnderlyingType(typeof(TEnum)) ?? typeof(TEnum);
        if (!targetType.IsEnum)
        {
            throw new InvalidOperationException($"The type '{targetType}' is not a supported enum type.");
        }

        // for each value of the enum, create the options
        foreach (var value in Enum.GetValues(targetType))
        {
            yield return new EnumOptions<TEnum>
            {
                Enum = (TEnum)value,
                Value = value.ToString()!,
                Description = typeof(TEnum).GetField(value.ToString()!)
                    ?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? value.ToString()!
            };
        }
    }
}