using RoyalCode.Yasamen.Forms.Validation;

namespace RoyalCode.Yasamen.Forms;

public interface IValidationContext
{
    
}

public sealed class ValidationContext<TModel> : IValidationContext
{
    public bool HasErros { get; private set; }

    internal IValidatorProvider Provider { get; set; } = null!;

    internal EditorMessages EditorMessages { get; set; } = null!;

    public void Clear()
    {
        HasErros = false;
        EditorMessages?.Clear();
    }

    public void Validate(TModel model)
    {
        Clear();

        var validator = Provider?.GetValidator<TModel>();
        if (validator is not null)
        {
            var result = validator.Validate(model);
            HasErros = !result.Success;
            EditorMessages?.Add(model, result.Messages);
        }
    }
}
