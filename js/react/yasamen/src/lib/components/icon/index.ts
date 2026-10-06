import Icon from "./icon";
import { WellKnownIcons } from "./well-known-icons";
import { setIconFactory, getIconRenderer, tryGetIconRenderer } from "./factory/icon-registry";
import { NoIconRenderer } from "./factory/NoIconRenderer";
import type { IconRenderer } from "./factory/icon-renderer";
import type { IconFactory } from "./factory/icon-factory";

export type { IconProps } from "./icon";
export type { IconRenderer, IconFactory };

export {
    Icon,
    WellKnownIcons,
    setIconFactory,
    getIconRenderer,
    tryGetIconRenderer,
    NoIconRenderer,
};