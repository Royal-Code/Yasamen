import { useReducer } from "react";
import { ModalContext } from "./modal-context";
import { modalReducer } from "./reducer";
import type { ModalState } from "./types";

const initialModalState: ModalState = {
    order: [],
    items: {},
};

export const ModalProvider: React.FC<React.PropsWithChildren> = ({ children }) => {
    const [state, dispatch] = useReducer(modalReducer, initialModalState);
    return (
        <ModalContext.Provider value={{ state, dispatch }}>
            {children}
        </ModalContext.Provider>
    );
};