using Microsoft.AspNetCore.Components;
using RoyalCode.Yasamen.Commons.Extensions;
using RoyalCode.Yasamen.Forms.Support;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class SelectKeyField<TModel, TValue> : SelectModelFieldBase<TModel, TValue>
    where TModel : class
{
    private Func<TModel, TValue> key = null!;
    private ChangeSupport? modelChangeSupport;
    private TModel? lastSelectedModel;

    [Parameter]
    public Func<TModel, TValue>? Key { get; set; }

    [Parameter]
    public string? ModelSupport { get; set; }

    protected override TValue GetKeyFromModel(TModel model) => key(model);

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        key = Key ?? key ?? CreateKey() ?? throw new InvalidOperationException(
            $"Could not get the Key of the model '{typeof(TModel).Name}' with the type '{typeof(TValue).Name}'.");

        if (modelChangeSupport is not null)
        {
            // get the current model
            var currentModel = GetSelectedModel(Value);
            if (currentModel != lastSelectedModel)
            {
                lastSelectedModel = currentModel;
                modelChangeSupport.HasCurrentValue(lastSelectedModel);
            }
        }
        else if (ModelSupport is not null)
        {
            lastSelectedModel = GetSelectedModel(Value);

            modelChangeSupport = ModelContext.PropertyChangeSupport.GetChangeSupport(ModelSupport);
            modelChangeSupport.Initialize(FieldIdentifier, lastSelectedModel);
        }
    }

    private Func<TModel, TValue>? CreateKey()
    {
        return KeyAndDescriptionFunctionDelegates.GetKeyFunction<TModel, TValue>();
    }

    private TModel? GetSelectedModel(TValue? value)
    {
        if (Key is null)
            return null;

        return OptionsValues.FirstOrDefault(model => Equals(Key(model), value));
    }

    protected override void OnAfterValueChanged(TValue? newValue)
    {
        if (ModelSupport is null || modelChangeSupport is null)
            return;

        // get the current model
        var currentModel = GetSelectedModel(newValue);

        // fire model has changed
        ModelContext.PropertyChangeSupport.PropertyHasChanged(FieldIdentifier, lastSelectedModel, currentModel);

        // update the value of last model.
        lastSelectedModel = currentModel;
    }
}
