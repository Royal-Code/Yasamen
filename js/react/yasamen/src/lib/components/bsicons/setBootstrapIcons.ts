import { setIconFactory } from "../icon/factory/iconRegistry";
import { WellKnownIcons } from "../icon/wellKnownIcons";
import { bsIconFactory } from "./bsIconFactory";
import { BsIcons } from "./bsIcons";
import { useEffect } from 'react';

export function setBootstrapIcons() {
    setIconFactory(bsIconFactory);

    WellKnownIcons.Add = BsIcons.PlusCircle;
    WellKnownIcons.Remove = BsIcons.DashCircle;
    WellKnownIcons.Edit = BsIcons.PencilSquare;
    WellKnownIcons.Save = BsIcons.Save;
    WellKnownIcons.Cancel = BsIcons.XCircle;
    WellKnownIcons.Close = BsIcons.XCircle;
    WellKnownIcons.Search = BsIcons.Search;
    WellKnownIcons.Filter = BsIcons.Funnel;
    WellKnownIcons.Sort = BsIcons.Filter;
    WellKnownIcons.SortAsc = BsIcons.SortAlphaDown;
    WellKnownIcons.SortDesc = BsIcons.SortAlphaUp;
    WellKnownIcons.Working = BsIcons.Gear;
    WellKnownIcons.Progress = BsIcons.GearWideConnected;
    WellKnownIcons.Minus = BsIcons.Dash;
    WellKnownIcons.Plus = BsIcons.Plus;
    WellKnownIcons.Success = BsIcons.CheckCircle;
    WellKnownIcons.Error = BsIcons.XCircle;
    WellKnownIcons.Warning = BsIcons.ExclamationTriangle;
    WellKnownIcons.Info = BsIcons.InfoCircle;
    WellKnownIcons.UserProfile = BsIcons.Person;
    WellKnownIcons.UserSettings = BsIcons.PersonGear;
    WellKnownIcons.UserLogout = BsIcons.BoxArrowRight;
    WellKnownIcons.UserLogin = BsIcons.BoxArrowInRight;
    WellKnownIcons.ShowPassword = BsIcons.Eye;
    WellKnownIcons.HidePassword = BsIcons.EyeSlash;
    WellKnownIcons.Menu = BsIcons.List;
    WellKnownIcons.MenuOpen = BsIcons.List;
    WellKnownIcons.MenuClose = BsIcons.X;
    WellKnownIcons.MenuCollapse = BsIcons.ChevronCompactUp;
    WellKnownIcons.MenuExpand = BsIcons.ChevronCompactDown;
    WellKnownIcons.MenuCollapseAll = BsIcons.ArrowsAngleContract;
    WellKnownIcons.MenuExpandAll = BsIcons.ArrowsAngleExpand;
}

// Hook para inicializar bootstrap icons em ambiente React
export function useSetupBootstrapIcons() {
    useEffect(() => {
        setBootstrapIcons();
    }, []);
}

// Componente provider opcional
export function BootstrapIconsProvider() {
    useSetupBootstrapIcons();
    return null;
}