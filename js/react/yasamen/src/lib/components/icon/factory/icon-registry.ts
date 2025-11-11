import { type IconRenderer } from "./icon-renderer";
import { NoIconRenderer } from "./NoIconRenderer";
import { type IconFactory } from "./icon-factory";

class CurrentIconFactory {
    Factory: IconFactory;

    constructor() {
        this.Factory = () => NoIconRenderer;
    }
}

const currentIconFactory = new CurrentIconFactory();

export function setIconFactory(factory: IconFactory) {
    currentIconFactory.Factory = factory;
}

export function getIconRenderer(name: string): IconRenderer {
    const renderer = currentIconFactory.Factory(name);
    if (!renderer) {
        throw new Error(`Icon with name "${name}" is not registered.`);
    }
    return renderer;
}

export function tryGetIconRenderer(name: string): IconRenderer {
    let renderer = currentIconFactory.Factory(name);
    if (!renderer) {
        renderer = NoIconRenderer;
    }
    return renderer;
}