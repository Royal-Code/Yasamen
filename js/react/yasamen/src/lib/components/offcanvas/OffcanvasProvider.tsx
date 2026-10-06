import React, { useReducer, useMemo } from "react";
import { OffcanvasSystemReducer, type OffcanvasSystemState } from "./OffcanvasOutlet";
import { OffcanvasContext } from "./offcanvas-context";

const initialOffcanvasState: OffcanvasSystemState = {
    isOpen: false,
    items: [],
    openedItemsIds: [],
    actionQueue: [],
    processQueue: false,
    effectQueue: [],
    backdropDispatch: undefined
};

export const OffcanvasProvider: React.FC<React.PropsWithChildren> = ({ children }) => {
    const [state, dispatch] = useReducer(OffcanvasSystemReducer, initialOffcanvasState);
    const value = useMemo(() => ({ state, dispatch }), [state, dispatch]);

    return (
        <OffcanvasContext.Provider value={value}>
            {children}
        </OffcanvasContext.Provider>
    );
};

export default OffcanvasProvider;
