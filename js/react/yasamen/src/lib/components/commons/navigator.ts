
export interface Navigator {
    navigate(to: string): void;
}

class NavigatorRegistry {
    private navigator: Navigator = {
        navigate: (to: string) => {
            window.location.href = to;
        }
    }

    setNavigator(navigator: Navigator) {
        this.navigator = navigator;
    }

    getNavigator(): Navigator {
        return this.navigator;
    }
}

const navigatorRegistry = new NavigatorRegistry();

export function setNavigator(navigator: Navigator) {
    navigatorRegistry.setNavigator(navigator);
}

export function getNavigator(): Navigator {
    return navigatorRegistry.getNavigator();
}