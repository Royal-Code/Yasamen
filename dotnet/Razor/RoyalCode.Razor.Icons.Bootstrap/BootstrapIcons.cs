using RoyalCode.Razor.Icons.Factory;

namespace RoyalCode.Razor.Icons.Bootstrap;

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
        var factory = new BootstrapIconContentFactory();
        IconContentFactories.AddIconContentFactory(typeof(BsIconNames), factory);

        if (includeCommonsIcons)
        {
            WellKnownIcons.Add = factory.GetFragment(BsIconNames.PlusCircle);
            WellKnownIcons.Remove = factory.GetFragment(BsIconNames.DashCircle);
            WellKnownIcons.Edit = factory.GetFragment(BsIconNames.PencilSquare);
            WellKnownIcons.Save = factory.GetFragment(BsIconNames.Save);
            WellKnownIcons.Cancel = factory.GetFragment(BsIconNames.XCircle);
            WellKnownIcons.Close = factory.GetFragment(BsIconNames.XCircle);
            WellKnownIcons.Search = factory.GetFragment(BsIconNames.Search);
            WellKnownIcons.Filter = factory.GetFragment(BsIconNames.Funnel);
            WellKnownIcons.Sort = factory.GetFragment(BsIconNames.Filter);
            WellKnownIcons.SortAsc = factory.GetFragment(BsIconNames.SortAlphaDown);
            WellKnownIcons.SortDesc = factory.GetFragment(BsIconNames.SortAlphaUp);

            WellKnownIcons.Working = factory.GetFragment(BsIconNames.Gear);
            WellKnownIcons.Progress = factory.GetFragment(BsIconNames.GearWideConnected);

            WellKnownIcons.Minus = factory.GetFragment(BsIconNames.Dash);
            WellKnownIcons.Plus = factory.GetFragment(BsIconNames.Plus);

            WellKnownIcons.Success = factory.GetFragment(BsIconNames.CheckCircle);
            WellKnownIcons.Error = factory.GetFragment(BsIconNames.XCircle);
            WellKnownIcons.Warning = factory.GetFragment(BsIconNames.ExclamationCircle);
            WellKnownIcons.Info = factory.GetFragment(BsIconNames.InfoCircle);

            WellKnownIcons.UserProfile = factory.GetFragment(BsIconNames.Person);
            WellKnownIcons.UserSettings = factory.GetFragment(BsIconNames.Gear);
            WellKnownIcons.UserLogout = factory.GetFragment(BsIconNames.BoxArrowRight);
            WellKnownIcons.UserLogin = factory.GetFragment(BsIconNames.BoxArrowInRight);
            WellKnownIcons.ShowPassord = factory.GetFragment(BsIconNames.Eye);
            WellKnownIcons.HidePassord = factory.GetFragment(BsIconNames.EyeSlash);

            WellKnownIcons.Menu = factory.GetFragment(BsIconNames.List);
            WellKnownIcons.MenuOpen = factory.GetFragment(BsIconNames.List);
            WellKnownIcons.MenuClose = factory.GetFragment(BsIconNames.X);
            WellKnownIcons.MenuCollapse = factory.GetFragment(BsIconNames.ChevronCompactUp);
            WellKnownIcons.MenuExpand = factory.GetFragment(BsIconNames.ChevronCompactDown);
            WellKnownIcons.MenuCollapseAll = factory.GetFragment(BsIconNames.ChevronCompactUp);
            WellKnownIcons.MenuExpandAll = factory.GetFragment(BsIconNames.ChevronCompactDown);
        }
    }
}
