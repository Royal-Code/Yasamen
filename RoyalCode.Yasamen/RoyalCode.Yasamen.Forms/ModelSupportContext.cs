namespace RoyalCode.Yasamen.Forms;

public class ModelSupportContext<TModel> : IModelLoadingState
    where TModel : class, new()
{
    private readonly ModelSupport<TModel> finder;
    private TModel? internalModel;

    public ModelSupportContext(ModelSupport<TModel> finder)
    {
        this.finder = finder;
    }

    public TModel Model => (IsLoading ? internalModel : finder.Model) ?? internalModel!;

    public bool IsLoading { get; internal set; }

    public bool NotFound { get; internal set; }

    public Exception? Exception { get; internal set; }

    public bool HasError { get; internal set; }

    internal void StartingLoad(TModel model)
    {
        internalModel = model;
        IsLoading = true;
        Exception = null;
        NotFound = false;
        HasError = false;
    }

    internal TModel ResultNotFound()
    {
        IsLoading = false;
        NotFound = true;

        return new TModel();
    }

    internal void ResultFound()
    {
        IsLoading = false;
    }

    internal TModel ResultError(Exception ex)
    {
        IsLoading = false;
        Exception = ex;
        HasError = true;

        return new TModel();
    }
}