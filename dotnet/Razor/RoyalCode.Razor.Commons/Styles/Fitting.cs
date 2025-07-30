namespace RoyalCode.Razor.Commons.Styles;

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

    /// <summary>
    /// The component will be floating in the page, below the top menu and above the footer.
    /// </summary>
    Float,
}