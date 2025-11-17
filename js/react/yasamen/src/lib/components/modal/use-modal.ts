import React, { useCallback } from "react";
import { useModalSystem } from "./modal-context";

interface UseModalOptions {
    closeable?: boolean;
    center?: boolean;
    content: React.ReactNode;
}

export function useModal(id: string, options: UseModalOptions) {
    
    const { dispatch } = useModalSystem();

    // registra apenas uma vez
    React.useEffect(() => {
        dispatch({ 
            type: "REGISTER",
            id, 
            content: options.content, 
            closeable: options.closeable ?? true,
            center: options.center ?? false
        });
        return () => dispatch({ 
            type: "UNREGISTER",
            id 
        });
    }, [id, dispatch, options]);

    // atualiza conteúdo quando mudar
    React.useEffect(() => {
        dispatch({ 
            type: "UPDATE_CONTENT", 
            id,
            content: options.content
        });
    }, [id, dispatch, options.content]);

    // atualiza meta (closeable) quando mudar
    React.useEffect(() => {
        dispatch({ 
            type: "UPDATE_META",
            id,
            closeable: options.closeable,
            center: options.center
        });
    }, [id, dispatch, options.closeable, options.center]);

    const open = useCallback(() => dispatch({ type: "OPEN", id }), [id, dispatch]);
    const close = useCallback(() => dispatch({ type: "CLOSE", id }), [id, dispatch]);

    return { open, close };
}