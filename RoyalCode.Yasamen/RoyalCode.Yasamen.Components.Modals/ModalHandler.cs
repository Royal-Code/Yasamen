namespace RoyalCode.Yasamen.Components;

public class ModalHandler
{
    public Modal? Modal { get; internal set; }

    public Task OpenAsync()
    {
        if (Modal is null)
            throw new InvalidOperationException("Modal is not set.");

        return Modal.OpenAsync();
    }

    public Task CloseAsync()
    {
        if (Modal is null)
            throw new InvalidOperationException("Modal is not set.");

        return Modal.CloseAsync();
    }
}
