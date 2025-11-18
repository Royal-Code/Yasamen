import React, { createContext, useContext } from "react";
import type { ModalSystemAction, ModalSystemState } from "./ModalOutlet";

interface ModalSystemDispatch {
    state: ModalSystemState;
    dispatch: React.Dispatch<ModalSystemAction>;
}

export const ModalContext = createContext<ModalSystemDispatch | null>(null);

export function useModalSystem() {
    const ctx = useContext(ModalContext);
    if (!ctx) 
        throw new Error("useModalSystem must be inside ModalProvider");
    return ctx;
}