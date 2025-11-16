import { useReducer } from "react";
import { ModalContext } from "./modal-context";
import { initialModalState, modalReducer } from "./reducer";

export const ModalProvider: React.FC<React.PropsWithChildren> = ({ children }) => {
    const [state, dispatch] = useReducer(modalReducer, initialModalState);
    return (
        <ModalContext.Provider value={{ state, dispatch }}>
            {children}
        </ModalContext.Provider>
    );
};