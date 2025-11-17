import React from "react";
import { useModal } from "./use-modal";
import { useModalSystem } from "./modal-context";

export interface ModalProps {
    id: string;
    closeable?: boolean;
    center?: boolean;
    children: React.ReactNode;
    onOpenClose: (isOpen: boolean) => void;
    handler? : ModalHandler;
}

export interface ModalHandler {
    open: () => void;
    close: () => void;
}

const Modal : React.FC<ModalProps> = ({
    id,
    closeable = true,
    center = true,
    children,
    onOpenClose = null,
    handler = null
}) => {
    // Este componente é apenas um invólucro para fornecer propriedades ao sistema de modal.
    // A lógica real de abertura/fechamento é gerenciada pelo sistema de modal global.

    const {open, close} = useModal(id, {
        content: children,
        closeable,
        center
    });

    // Monitora mudanças de abertura/fechamento
    const { state } = useModalSystem();
    const isOpen = state.items[id]?.wantOpen ?? false;
    React.useEffect(() => {
        if (onOpenClose) {
            onOpenClose(isOpen);
        }
    }, [isOpen, onOpenClose]);

    // Fornece o manipulador de abertura/fechamento, se solicitado
    React.useEffect(() => {
        if (handler) {
            handler.open = open;
            handler.close = close;
        }
    }, [handler, open, close]);

    return null; // Não renderiza nada diretamente
}

export default Modal;