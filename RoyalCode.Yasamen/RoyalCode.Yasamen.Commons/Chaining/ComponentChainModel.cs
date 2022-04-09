
namespace RoyalCode.Yasamen.Commons.Chaining;

/// <summary>
/// Holds the model for the current component fragment that will be rendered and
/// the component reference that render the fragment.
/// </summary>
/// <typeparam name="TChainModel">The type of the model that will be shared with de component.</typeparam>
/// <param name="Model">The shared model.</param>
/// <param name="Reference">The fragment render reference.</param>
public record ComponentChainModel<TChainModel>(TChainModel Model, ComponentChainReference Reference);