
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

    public override Type ModelType => typeof(TModel);
    
    public override object ModelInstance => Model!;
}

public abstract class ModelContext
{
    public string Alias { get; protected internal set; }
    
    public abstract Type ModelType { get; }
    
    public abstract object ModelInstance { get; }
}