import React, { useEffect, useReducer } from "react";
import { ModalSystemReducer, type ModalSystemState } from "./ModalOutlet";
import { ModalContext } from "./modal-context";

const initialModalState: ModalSystemState = {
    isOpen: false,
    backdropPhase: 'closed',
    items: [],
    openedItemsIds: [],
    actionQueue: [],
    processQueue: false,
};

export const ModalProvider: React.FC<React.PropsWithChildren> = ({ children }) => {
    const [state, dispatch] = useReducer(ModalSystemReducer, initialModalState);

    // Processa uma ação da fila por render até esvaziar
    useEffect(() => {
        if (state.processQueue) {
            dispatch({ type: 'PROCESS_QUEUE' });
        }
    }, [state.processQueue]);

    // Listener para tecla ESC fechando modal topo (equivalente a BACKDROP_ACTION)
    useEffect(() => {
        if (state.openedItemsIds.length === 0)
             return;

        const onKey = (e: KeyboardEvent) => {
            if (e.key === 'Escape') {
                dispatch({ type: 'BACKDROP_ACTION' });
            }
        };

        window.addEventListener('keydown', onKey);

        return () => window.removeEventListener('keydown', onKey);
        
    }, [state.openedItemsIds.length]);

    return (
        <ModalContext.Provider value={{ state, dispatch }}>
            {children}
        </ModalContext.Provider>
    );
};