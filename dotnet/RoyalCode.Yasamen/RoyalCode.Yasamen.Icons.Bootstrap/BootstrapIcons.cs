using RoyalCode.Yasamen.Commons.Options;
using RoyalCode.Yasamen.Icons.Factory;

namespace RoyalCode.Yasamen.Icons.Bootstrap;

/// <summary>
/// Bootstrap icon configuration utility.
/// </summary>
public static class BootstrapIcons
{
    /// <summary>
    /// It includes the Bootstrap options and factory and icons.
    /// </summary>
    /// <param name="includeCommonsIcons">If it is true, it includes the common icons.</param>
    public static void Include(bool includeCommonsIcons = true)
    {
        IconContentFactories.AddIconContentFactory(typeof(BsIconNames), new BootstrapIconContentFactory());

        if (includeCommonsIcons)
        {
            CommonsOptions.Configure<Icon>()
                .Set(WellKnownIcons.Add, BsIconNames.PlusCircle)
                .Set(WellKnownIcons.Remove, BsIconNames.DashCircle)
                .Set(WellKnownIcons.Edit, BsIconNames.PencilSquare)
                .Set(WellKnownIcons.Save, BsIconNames.Save)
                .Set(WellKnownIcons.Cancel, BsIconNames.XCircle)
                .Set(WellKnownIcons.Close, BsIconNames.XCircle)
                .Set(WellKnownIcons.Search, BsIconNames.Search)
                .Set(WellKnownIcons.Filter, BsIconNames.Funnel)
                .Set(WellKnownIcons.Sort, BsIconNames.Filter)
                .Set(WellKnownIcons.SortAsc, BsIconNames.SortAlphaDown)
                .Set(WellKnownIcons.SortDesc, BsIconNames.SortAlphaUp)

                .Set(WellKnownIcons.Working, BsIconNames.Gear)
                .Set(WellKnownIcons.Progress, BsIconNames.GearWideConnected)

                .Set(WellKnownIcons.Minus, BsIconNames.Dash)
                .Set(WellKnownIcons.Plus, BsIconNames.Plus)

                .Set(WellKnownIcons.Success, BsIconNames.CheckCircle)
                .Set(WellKnownIcons.Error, BsIconNames.XCircle)
                .Set(WellKnownIcons.Warning, BsIconNames.ExclamationCircle)
                .Set(WellKnownIcons.Info, BsIconNames.InfoCircle)

                .Set(WellKnownIcons.UserProfile, BsIconNames.Person)
                .Set(WellKnownIcons.UserSettings, BsIconNames.Gear)
                .Set(WellKnownIcons.UserLogout, BsIconNames.BoxArrowRight)
                .Set(WellKnownIcons.UserLogin, BsIconNames.BoxArrowInRight)
                .Set(WellKnownIcons.ShowPassord, BsIconNames.Eye)
                .Set(WellKnownIcons.HidePassord, BsIconNames.EyeSlash)

                .Set(WellKnownIcons.Menu, BsIconNames.List)
                .Set(WellKnownIcons.MenuOpen, BsIconNames.List)
                .Set(WellKnownIcons.MenuClose, BsIconNames.X)
                .Set(WellKnownIcons.MenuCollapse, BsIconNames.ChevronCompactUp)
                .Set(WellKnownIcons.MenuExpand, BsIconNames.ChevronCompactDown)
                .Set(WellKnownIcons.MenuCollapseAll, BsIconNames.ChevronCompactUp)
                .Set(WellKnownIcons.MenuExpandAll, BsIconNames.ChevronCompactDown);
        }
    }
}
