namespace RoyalCode.Razor.Commons;

/// <summary>
/// State management for visibility.
/// </summary>
public class VisibleState
{
    private readonly Func<Task> stateHasChangedAsync;

    /// <summary>
    /// Creates a new instance of <see cref="VisibleState"/>.
    /// </summary>
    /// <param name="stateHasChangedAsync"></param>
    public VisibleState(Func<Task> stateHasChangedAsync)
    {
        this.stateHasChangedAsync = stateHasChangedAsync;
    }

    /// <summary>
    /// Determines whether the component is visible.
    /// </summary>
    public bool IsVisible { get; private set; }

    /// <summary>
    /// Shows the component.
    /// </summary>
    /// <returns></returns>
    public async Task ShowAsync()
    {
        if (!IsVisible)
        {
            IsVisible = true;
            await stateHasChangedAsync();
        }
    }

    /// <summary>
    /// Hides the component.
    /// </summary>
    /// <returns></returns>
    public async Task HideAsync()
    {
        if (IsVisible)
        {
            IsVisible = false;
            await stateHasChangedAsync();
        }
    }
}
