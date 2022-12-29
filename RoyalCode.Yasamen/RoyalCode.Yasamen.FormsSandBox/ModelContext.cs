using System.ComponentModel.DataAnnotations;
using RoyalCode.Yasamen.Forms.Validation;

namespace RoyalCode.Yasamen.Forms;

public sealed class ModelContext<TModel> : IModelContext
{
    public ModelContext(TModel model)
    {
        Model = model;
    }

    public ModelContext(TModel model, IModelContext parent) : this(model)
    {
        Parent = parent;
    }

    public ModelContext() { }

    internal bool IsInitialized { get; private set; }
    
    public TModel? Model { get; }

    public IModelContext? Parent { get; }
    
    public ValidationContext<TModel> ValidationContext { get; } = new ValidationContext<TModel>();

    public EditorMessages EditorMessages { get; private set; } = null!;

    public bool Validate()
    {
        if (Model is null)
            return false;
        
        ValidationContext.Validate(Model);
        return !ValidationContext.HasErros;
    }
    
    public void Clear()
    {
        ValidationContext.Clear();
    }

    internal void Initialize(IValidatorProvider validatorProvider, EditorMessages editorMessages)
    {
        EditorMessages = editorMessages;
        ValidationContext.Provider = validatorProvider;
        ValidationContext.EditorMessages = editorMessages;

        IsInitialized = true;
    }

    public object? GetModel() => Model;

    public IValidationContext GetValidationContext() => ValidationContext;

    public EditorMessages GetEditorMessages() => EditorMessages;

    public IModelContext? GetParent() => Parent;
}
