using System.ComponentModel.DataAnnotations;
using RoyalCode.Yasamen.Forms.Support;
using RoyalCode.Yasamen.Forms.Validation;

namespace RoyalCode.Yasamen.Forms;

public sealed class ModelContext<TModel> : IModelContext
{
    public ModelContext(TModel model) : this()
    {
        Model = model;
    }
    
    internal ModelContext()
    {
        PropertyChangeSupport = new();
        EditorMessages = new();
    }
    
    // Futuramente poderá ser private e ter um método para criar um Nested.
    internal ModelContext(TModel model, IModelContext parent)
    {
        Model = model;
        Parent = parent;
        EditorMessages = parent.EditorMessages;
        PropertyChangeSupport = new(parent.PropertyChangeSupport);

        InternalConteinerState.UsingContainer = parent.ContainerState.UsingContainer;
    }
    
    internal bool IsInitialized { get; private set; }

    internal ModelContainerState InternalConteinerState { get; } = new();

    public TModel? Model { get; }

    public IModelContext? Parent { get; }

    public IModelContainerState ContainerState => InternalConteinerState;

    public ValidationContext<TModel> ValidationContext { get; } = new ValidationContext<TModel>();

    public EditorMessages EditorMessages { get; private set; }

    public PropertyChangeSupport PropertyChangeSupport { get; private set; }
    
    public bool Validate()
    {
        if (Model is null)
            return false;

        // TODO: pode haver model context aninhados, a validação deverá ser para todos os níveis.

        ValidationContext.Validate(Model);
        return !ValidationContext.HasErros;
    }
    
    public void Clear()
    {
        if (Model is null)
            return;
        
        ValidationContext.Clear(Model);
    }

    internal void Initialize(IValidatorProvider validatorProvider)
    {
        ValidationContext.Provider = validatorProvider;
        ValidationContext.EditorMessages = EditorMessages;

        IsInitialized = true;
    }

    public object? GetModel() => Model;
}
