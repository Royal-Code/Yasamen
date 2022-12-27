namespace RoyalCode.Yasamen.Forms;

public class ModelContext
{

}

public class ModelContext<TModel> : ModelContext
{
    public ModelContext(TModel model)
    {
        Model = model;
    }

    public ModelContext() { }

    public TModel? Model { get; }
}

public class ValidationContext<TModel>
{
    public void Clear()
    {
        
    }

    public void Validate(TModel model)
    {
        
    }
}

public interface IValidator<TModel>
{

}