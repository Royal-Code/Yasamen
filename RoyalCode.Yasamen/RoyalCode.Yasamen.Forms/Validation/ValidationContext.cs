using RoyalCode.Yasamen.Forms.Messages;

namespace RoyalCode.Yasamen.Forms.Validation;

public interface IValidationContext
{
    bool HasErros { get; }
}

public sealed class ValidationContext<TModel> : IValidationContext
{
    public bool HasErros { get; private set; }

    internal IValidatorProvider Provider { get; set; } = null!;

    internal EditorMessages EditorMessages { get; set; } = null!;

    public void Clear(TModel model)
    {
        HasErros = false;

        if (model is null)
            return;
        
        EditorMessages?.Clear(model);
    }

    public void Validate(TModel model)
    {
        Clear(model);

        if (model is null)
            return;

        var validator = Provider?.GetValidator<TModel>();
        if (validator is not null)
        {
            var result = validator.Validate(model);
            HasErros = result.TryGetError(out var errors);
            if (HasErros)
                EditorMessages?.Add(model, errors!);
        }
    }
}
