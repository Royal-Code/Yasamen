
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace RoyalCode.Yasamen.Forms;

/// <summary>
/// A context that holds the model to edit and the fields options.
/// </summary>
/// <typeparam name="TModel">The model type</typeparam>
public class ModelContext<TModel> : ModelContext
{
    public ModelContext(TModel model, string alias)
    {
        Model = model ?? throw new ArgumentNullException(nameof(model));
        Alias = alias;
    }

    public TModel Model { get; }

    internal Task Submit()
    {
        return Task.CompletedTask;
    }
}

public abstract class ModelContext
{
    public string Alias { get; protected set; }
}