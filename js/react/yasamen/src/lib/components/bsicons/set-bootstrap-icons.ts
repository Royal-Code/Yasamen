import { setIconFactory } from "../icon/factory/icon-registry";
import { configureWellKnownIcons } from "../icon/well-known-icons";
import { bsIconFactory } from "./bs-icon-factory";
import { BsIcons } from "./bs-icons";
import { useEffect, useRef } from 'react';

/**
 *  Sets up the Bootstrap icons as the default icon set.
 *  This function maps well-known icon names to their corresponding Bootstrap icons.
 *  It should be called once during the application initialization.
 */
export function setBootstrapIcons() {
    setIconFactory(bsIconFactory);

    configureWellKnownIcons({
        NoIcon: BsIcons.Ban,
        Add: BsIcons.PlusCircle,
        Remove: BsIcons.DashCircle,
        Edit: BsIcons.PencilSquare,
        Save: BsIcons.Save,
        Cancel: BsIcons.XCircle,
        Close: BsIcons.XCircle,
        Search: BsIcons.Search,
        Filter: BsIcons.Funnel,
        Sort: BsIcons.Filter,
        SortAsc: BsIcons.SortAlphaDown,
        SortDesc: BsIcons.SortAlphaUp,
        Working: BsIcons.Gear,
        Progress: BsIcons.GearWideConnected,
        Minus: BsIcons.Dash,
        Plus: BsIcons.Plus,
        Success: BsIcons.CheckCircle,
        Error: BsIcons.XCircle,
        Warning: BsIcons.ExclamationTriangle,
        Info: BsIcons.InfoCircle,
        UserProfile: BsIcons.Person,
        UserSettings: BsIcons.PersonGear,
        UserLogout: BsIcons.BoxArrowRight,
        UserLogin: BsIcons.BoxArrowInRight,
        ShowPassword: BsIcons.Eye,
        HidePassword: BsIcons.EyeSlash,
        Menu: BsIcons.List,
        MenuOpen: BsIcons.List,
        MenuClose: BsIcons.X,
        MenuCollapse: BsIcons.ChevronCompactUp,
        MenuExpand: BsIcons.ChevronCompactDown,
        MenuCollapseAll: BsIcons.ArrowsAngleContract,
        MenuExpandAll: BsIcons.ArrowsAngleExpand
    });
}

// Hook para inicializar bootstrap icons em ambiente React
export function useSetupBootstrapIcons() {
    useEffect(() => {
        setBootstrapIcons();
    }, []);
}

// Componente provider opcional
export function BootstrapIconsProvider({
    href = 'https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.css',
    id = 'bootstrap-icons-stylesheet'
}: { href?: string; id?: string }) {
    // Synchronous one-time initialization before children render.
    const initialized = useRef(false);
    if (!initialized.current) {
        setBootstrapIcons();
        initialized.current = true;
    }

    useEffect(() => {
        if (typeof document === 'undefined') 
            return; // SSR safety

        const existing = document.getElementById(id) as HTMLLinkElement | null;
        
        if (!existing) {
            const link = document.createElement('link');
            link.id = id;
            link.rel = 'stylesheet';
            link.href = href;
            document.head.appendChild(link);
        } else if (existing.href !== href) {
            existing.href = href; // allow override
        }
    }, [href, id]);
    return null;
}