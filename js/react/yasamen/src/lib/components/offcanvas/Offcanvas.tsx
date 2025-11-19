import { createContext, useContext } from "react";

export interface OffcanvasProps {
    id: string;
    position?: 'left' | 'right';
    backdrop?: boolean;
    closeOnBackdropClick?: boolean;
    children: React.ReactNode;
    onOpenClose?: (isOpen: boolean) => void;
    handler?: OffcanvasHandler;
}

export interface OffcanvasHandler {
    open: () => void;
    close: () => void;
}

export const OffcanvasHandlerContext = createContext<OffcanvasHandler>({
    open: () => { },
    close: () => { }
});
export const useOffcanvasHandler = () => useContext(OffcanvasHandlerContext);