namespace RoyalCode.Yasamen.Forms;

internal sealed class ModelContainerState : IModelContainerState
{
    public bool IsLoading { get; set; }

    public bool UsingContainer { get; set; }
}