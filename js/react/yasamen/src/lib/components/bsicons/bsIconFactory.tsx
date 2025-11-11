import type { IconFactory } from "../icon/factory/iconFactory";
import type { IconRenderer } from "../icon/factory/iconRenderer";
import { BsIcons, type BsIconsValues } from "./bsIcons";

export const bsIconFactory: IconFactory = (name: string): IconRenderer | null => {
    // verify is name is in BsIcons
    if (!isBsIcon(name)) {
        return null;
    }

    return bsIconRenderer(name);
};

function isBsIcon(value: unknown): value is BsIconsValues {
  return Object.values(BsIcons).includes(value as BsIconsValues);
}

function bsIconRenderer(name: string): IconRenderer {
    return (className: string | undefined, rest) => {
        const classNames = ["bi", `bi-${name}`, className].filter(Boolean).join(" ");
        return <i className={classNames} {...rest} />;
    };
}