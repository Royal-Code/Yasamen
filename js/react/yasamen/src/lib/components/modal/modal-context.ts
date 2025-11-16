import React, { createContext, useContext } from "react";
import type { ModalState as FullState, ModalAction } from "./types";

interface ModalDispatch {
    dispatch: React.Dispatch<ModalAction>;
    state: FullState;
}

export const ModalContext = createContext<ModalDispatch | null>(null);

export function useModalSystem() {
    const ctx = useContext(ModalContext);
    if (!ctx) 
        throw new Error("useModalSystem must be inside ModalProvider");
    return ctx;
}