import React, { useReducer } from "react";
import { ModalSystemReducer, type ModalSystemState } from "./ModalOutlet";
import { ModalContext } from "./modal-context";

const initialModalState: ModalSystemState = {
    isOpen: false,
    items: [],
    openedItemsIds: [],
    actionQueue: [],
    processQueue: false,
    effectQueue: [],
    backdropDispatch: undefined
};

export const ModalProvider: React.FC<React.PropsWithChildren> = ({ children }) => {
    const [state, dispatch] = useReducer(ModalSystemReducer, initialModalState);

    return (
        <ModalContext.Provider value={{ state, dispatch }}>
            {children}
        </ModalContext.Provider>
    );
};