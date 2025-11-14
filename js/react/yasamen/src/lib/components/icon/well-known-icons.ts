/* Well-known icon registry pattern without Proxy.
     External code accesses dynamic values through getter properties (e.g. WellKnownIcons.Add).
     configureWellKnownIcons() updates the internal _registry mapping; reads reflect new values.
*/

export const WellKnownIconKeys = [
    'NoIcon',
    'Add',
    'Remove',
    'Edit',
    'Save',
    'Cancel',
    'Close',
    'Search',
    'Filter',
    'Sort',
    'SortAsc',
    'SortDesc',
    'Minus',
    'Plus',
    'Working',
    'Progress',
    'Success',
    'Error',
    'Warning',
    'Info',
    'UserProfile',
    'UserSettings',
    'UserLogout',
    'UserLogin',
    'ShowPassword',
    'HidePassword',
    'Menu',
    'MenuOpen',
    'MenuClose',
    'MenuCollapse',
    'MenuExpand',
    'MenuCollapseAll',
    'MenuExpandAll'
] as const;

export type WellKnownIconKey = typeof WellKnownIconKeys[number];

// Internal mutable registry. Defaults map each key to a base string (existing original values).
const _registry: Record<WellKnownIconKey, string> = {
    NoIcon: 'no_icon',
    Add: 'add',
    Remove: 'remove',
    Edit: 'edit',
    Save: 'save',
    Cancel: 'cancel',
    Close: 'close',
    Search: 'search',
    Filter: 'filter',
    Sort: 'sort',
    SortAsc: 'sort_asc',
    SortDesc: 'sort_desc',
    Minus: 'minus',
    Plus: 'plus',
    Working: 'working',
    Progress: 'progress',
    Success: 'success',
    Error: 'error',
    Warning: 'warning',
    Info: 'info',
    UserProfile: 'user_profile',
    UserSettings: 'user_settings',
    UserLogout: 'user_logout',
    UserLogin: 'user_login',
    ShowPassword: 'show_password',
    HidePassword: 'hide_password',
    Menu: 'menu',
    MenuOpen: 'menu_open',
    MenuClose: 'menu_close',
    MenuCollapse: 'menu_collapse',
    MenuExpand: 'menu_expand',
    MenuCollapseAll: 'menu_collapse_all',
    MenuExpandAll: 'menu_expand_all'
};

// Public read-only facade with getters bound to _registry values.
export const WellKnownIcons = {} as Record<WellKnownIconKey, string>;
WellKnownIconKeys.forEach(k => {
    Object.defineProperty(WellKnownIcons, k, {
        get: () => _registry[k],
        set: () => { throw new Error(`Cannot assign to WellKnownIcons.${k}; use configureWellKnownIcons().`); },
        enumerable: true,
        configurable: false
    });
});
Object.freeze(WellKnownIcons);

// Configure mapping (e.g., in setBootstrapIcons)
export function configureWellKnownIcons(map: Partial<Record<WellKnownIconKey, string>>) {
    for (const [k, v] of Object.entries(map)) {
        if (!WellKnownIconKeys.includes(k as WellKnownIconKey)) {
            throw new Error(`Unknown well-known icon key: ${k}`);
        }
        if (typeof v === 'string' && v.trim().length > 0) {
            _registry[k as WellKnownIconKey] = v;
        }
    }
}

// Direct access helpers
export function getWellKnownIcon(key: WellKnownIconKey): string {
    return _registry[key];
}

// Hook (non-reactive snapshot; if dynamic updates needed add state/emit later)
export function useWellKnownIcons(): Record<WellKnownIconKey, string> {
    return _registry; // Consumers should treat as read-only
}
