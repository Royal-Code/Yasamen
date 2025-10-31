using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Icons.Factory;

namespace RoyalCode.Razor.Icons;

/// <summary>
/// Well known icon fragments used across the application.
/// When an icon library (e.g. BootstrapIcons.Include) is initialized each property
/// receives its corresponding <see cref="IconFragment"/>; until then a fallback fragment is shown.
/// </summary>
public static class WellKnownIcons
{
    private static readonly IconFragment NoIconFragment = (string? classes, Dictionary<string, object>? attrs) => builder => builder.AddContent(0, "Icon not informed");

    /// <summary>
    /// Icon for add / create action.
    /// </summary>
    public static IconFragment Add { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for remove / delete action.
    /// </summary>
    public static IconFragment Remove { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for edit action.
    /// </summary>
    public static IconFragment Edit { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for save / persist action.
    /// </summary>
    public static IconFragment Save { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for cancel action.
    /// </summary>
    public static IconFragment Cancel { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for close action.
    /// </summary>
    public static IconFragment Close { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for search.
    /// </summary>
    public static IconFragment Search { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for filtering.
    /// </summary>
    public static IconFragment Filter { get; set; } = NoIconFragment;
    /// <summary>
    /// Generic icon for sorting (unspecified direction).
    /// </summary>
    public static IconFragment Sort { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for ascending sort.
    /// </summary>
    public static IconFragment SortAsc { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for descending sort.
    /// </summary>
    public static IconFragment SortDesc { get; set; } = NoIconFragment;

    /// <summary>
    /// Icon for decrease / subtract / collapse.
    /// </summary>
    public static IconFragment Minus { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for increase / add / expand.
    /// </summary>
    public static IconFragment Plus { get; set; } = NoIconFragment;

    /// <summary>
    /// Icon indicating work in progress / processing.
    /// </summary>
    public static IconFragment Working { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon indicating progress / running operation.
    /// </summary>
    public static IconFragment Progress { get; set; } = NoIconFragment;

    /// <summary>
    /// Icon for success state.
    /// </summary>
    public static IconFragment Success { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for error state.
    /// </summary>
    public static IconFragment Error { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for warning state.
    /// </summary>
    public static IconFragment Warning { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for informational state.
    /// </summary>
    public static IconFragment Info { get; set; } = NoIconFragment;

    /// <summary>
    /// Icon for user profile.
    /// </summary>
    public static IconFragment UserProfile { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for user settings.
    /// </summary>
    public static IconFragment UserSettings { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for user logout / sign out.
    /// </summary>
    public static IconFragment UserLogout { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for user login / sign in.
    /// </summary>
    public static IconFragment UserLogin { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon to show password.
    /// </summary>
    public static IconFragment ShowPassord { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon to hide password.
    /// </summary>
    public static IconFragment HidePassord { get; set; } = NoIconFragment;

    /// <summary>
    /// Icon for menu (hamburger or list).
    /// </summary>
    public static IconFragment Menu { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for opened menu (if distinct).
    /// </summary>
    public static IconFragment MenuOpen { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for closing menu.
    /// </summary>
    public static IconFragment MenuClose { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for collapsing a menu item.
    /// </summary>
    public static IconFragment MenuCollapse { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for expanding a menu item.
    /// </summary>
    public static IconFragment MenuExpand { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for collapsing all menu items.
    /// </summary>
    public static IconFragment MenuCollapseAll { get; set; } = NoIconFragment;
    /// <summary>
    /// Icon for expanding all menu items.
    /// </summary>
    public static IconFragment MenuExpandAll { get; set; } = NoIconFragment;
}
