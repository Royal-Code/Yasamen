import React, { useCallback } from "react";
import { useModalSystem } from "./modal-context";

export function useModal(id: string, options: { closeable?: boolean; content: React.ReactNode }) {
    const { dispatch } = useModalSystem();

    // registra apenas uma vez
    React.useEffect(() => {
        dispatch({ type: "REGISTER", id, content: options.content, closeable: options.closeable ?? true });
        return () => dispatch({ type: "UNREGISTER", id });
        // somente id e dispatch para não re-registrar em mudanças de conteúdo
    }, [id, dispatch]);

    // atualiza conteúdo quando mudar
    React.useEffect(() => {
        dispatch({ type: "UPDATE_CONTENT", id, content: options.content });
    }, [id, options.content, dispatch]);

    // atualiza meta (closeable) quando mudar
    React.useEffect(() => {
        if (typeof options.closeable !== 'undefined') {
            dispatch({ type: "UPDATE_META", id, closeable: options.closeable });
        }
    }, [id, options.closeable, dispatch]);

    const open = useCallback(() => dispatch({ type: "OPEN", id }), [id, dispatch]);
    const close = useCallback(() => dispatch({ type: "CLOSE", id }), [id, dispatch]);

    return { open, close };
}