
namespace RoyalCode.Yasamen.Commons.Chaining;

/// <summary>
/// Class that holds the reference for the component that will render the component fragment.
/// </summary>
public class ComponentChainReference : IDisposable
{
    private readonly IComponentChainRender render;

    internal ComponentChainReference(IComponentChainRender render)
    {
        this.render = render;
    }

    /// <summary>
    /// If set, will be called after the component fragment was rendered.
    /// </summary>
    public Action? OnAfterRender { get; set; }

    internal void FragmentWasRendered()
    {
        OnAfterRender?.Invoke();
    }

    /// <summary>
    /// When the time to render the fragment of the component is over, 
    /// dispose should be called so that the fragment is no longer rendered.
    /// </summary>
    public void Dispose()
    {
        render.Release();
    }
}
