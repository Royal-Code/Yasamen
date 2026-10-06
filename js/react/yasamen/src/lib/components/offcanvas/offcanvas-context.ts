import React, { createContext, useContext } from "react";
import type { OffcanvasSystemAction, OffcanvasSystemState } from "./OffcanvasOutlet";

export interface OffcanvasHandler {
    open: () => void;
    close: () => void;
}

export const OffcanvasHandlerContext = createContext<OffcanvasHandler>({
    open: () => { },
    close: () => { }
});

export const useOffcanvasHandler = () => useContext(OffcanvasHandlerContext);

export interface OffcanvasSystemDispatch {
    state: OffcanvasSystemState;
    dispatch: React.Dispatch<OffcanvasSystemAction>;
}

export const OffcanvasContext = createContext<OffcanvasSystemDispatch | null>(null);

export function useOffcanvasSystem() {
    return useContext(OffcanvasContext);
}
