using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Commons.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class SelectModelField<TModel> : SelectModelFieldBase<TModel, TModel>
    where TModel : class
{
    private Func<TModel, object> key = null!;

    [Parameter]
    public Func<TModel, object>? Key { get; set; }

    protected override TModel GetKeyFromModel(TModel model) => model;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        key = Key ?? key ?? CreateKey() ?? throw new InvalidOperationException(
            $"Could not get the Key of the model '{typeof(TModel).Name}'.");
    }

    private Func<TModel, object>? CreateKey() => KeyAndDescriptionFunctionDelegates.GetKeyFunction<TModel>();

    protected override string? FormatValue(TModel? value) => value is null ? null : key(value)?.ToString();

    protected override bool TryParseValue(
        string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out TModel result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        value = value?.Trim('\'');

        if (value is null || value == DefaultOptionValue)
        {
            result = GetDefaultValue(); 
            errorMessage = null;
            return true;
        }

        var matched = OptionsValues.Where(model => FormatValue(model) == value).ToList();
        if (matched.Count == 1)
        {
            result = matched.First();
            errorMessage = null;
            return true;
        }
        else if (matched.Count > 1)
        {
            result = default;
            errorMessage = $"Multiples models matched for {FieldName} for value {value}.";
            return false;
        }

        result = default;
        errorMessage = $"The model for key '{value}' was not found";
        return false;
    }
}

public sealed class SelectKeyField<TModel, TValue> : SelectModelFieldBase<TModel, TValue>
    where TModel : class
{
    private Func<TModel, TValue> key = null!;
    
    [Parameter]
    public Func<TModel, TValue>? Key { get; set; }

    protected override TValue GetKeyFromModel(TModel model) => key(model);

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        key = Key ?? key ?? CreateKey() ?? throw new InvalidOperationException(
            $"Could not get the Key of the model '{typeof(TModel).Name}' with the type '{typeof(TValue).Name}'.");
    }

    private Func<TModel, TValue>? CreateKey()
    {
        return KeyAndDescriptionFunctionDelegates.GetKeyFunction<TModel, TValue>();
    }
}
