
namespace RoyalCode.Yasamen.Commons.Chaining;

/// <summary>
/// Basic interface for a component that will render the component fragment.
/// </summary>
public interface IComponentChainRender
{
    /// <summary>
    /// Stop to render the component fragment.
    /// </summary>
    void Release();
}
