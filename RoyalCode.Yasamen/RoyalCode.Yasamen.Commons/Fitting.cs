namespace RoyalCode.Yasamen.Commons;

/// <summary>
/// Fitting of some component, for example a side menu. 
/// The docker can either overlay the top menu or embed it in the page.
/// </summary>
public enum Fitting
{
    /// <summary>
    /// The component will go over the top menu.
    /// </summary>
    Overlaying,

    /// <summary>
    /// The component will incorporate itself into the content by being below the top menu.
    /// </summary>
    Incorporated,
}