import React, { useReducer, useEffect, useRef } from "react";
import { SectionContent } from "../outlet";
import { ModalClasses } from "./modal-classes";
import { useModalSystem } from "./modal-context";

export interface ModalProps {
    id: string;
    closeable?: boolean;
    center?: boolean;
    children: React.ReactNode;
    onOpenClose?: (isOpen: boolean) => void;
    handler?: ModalHandler;
}

export interface ModalHandler {
    open: () => void;
    close: () => void;
}

interface ModalState {
    phase: 'closed' | 'opening_start' | 'opening' | 'open' | 'closing_start' | 'closing';
    closeable: boolean;
    center: boolean;
}

type ModalAction =
    | { type: 'OPEN' }
    | { type: 'OPEN_PROMOTE' }
    | { type: 'OPEN_DONE' }
    | { type: 'CLOSE' }
    | { type: 'CLOSE_PROMOTE' }
    | { type: 'CLOSE_DONE' };

export interface ModalItem {
    id: string;
    dispatch: React.Dispatch<ModalAction>;
}

const reducer = (state: ModalState, action: ModalAction): ModalState => {
    switch (action.type) {
        case 'OPEN':
            return state.phase === 'closed' ? { ...state, phase: 'opening_start' } : state;
        case 'OPEN_PROMOTE':
            return state.phase === 'opening_start' ? { ...state, phase: 'opening' } : state;
        case 'OPEN_DONE':
            return state.phase === 'opening' ? { ...state, phase: 'open' } : state;
        case 'CLOSE':
            return state.phase === 'open' ? { ...state, phase: 'closing_start' } : state;
        case 'CLOSE_PROMOTE':
            return state.phase === 'closing_start' ? { ...state, phase: 'closing' } : state;
        case 'CLOSE_DONE':
            return state.phase === 'closing' ? { ...state, phase: 'closed' } : state;
        default:
            return state;
    }
};

const Modal: React.FC<ModalProps> = ({
    id,
    closeable = true,
    center = false,
    children,
    onOpenClose,
    handler
}) => {
    const sectionId = `modal-content-${id}`;
    const { dispatch: systemDispatch } = useModalSystem();
    const [state, dispatch] = useReducer(reducer, {
        phase: 'closed',
        closeable,
        center
    });
    const lastPhaseRef = useRef(state.phase);
    const modalRef = useRef<HTMLDivElement | null>(null);

    // Registro no sistema global
    useEffect(() => {
        systemDispatch({ type: "REGISTER", item: { id: sectionId, dispatch } });
        return () => {
            systemDispatch({ type: "UNREGISTER", item: { id: sectionId, dispatch } });
        };
    }, [sectionId, systemDispatch]);

    // Promotion frame from opening_start -> opening (allows initial layout commit without transition)
    useEffect(() => {
        if (state.phase === 'opening_start') {
            const raf = requestAnimationFrame(() => {
                dispatch({ type: 'OPEN_PROMOTE' });
            });
            return () => cancelAnimationFrame(raf);
        } else if (state.phase === 'closing_start') {
            const raf = requestAnimationFrame(() => {
                dispatch({ type: 'CLOSE_PROMOTE' });
            });
            return () => cancelAnimationFrame(raf);
        }
    }, [state.phase]);

    // Avança fases somente após término da animação/transição (fallback timeout)
    useEffect(() => {
        // somente durante transições reais
        if (state.phase !== 'opening' && state.phase !== 'closing')
             return;

        const el = modalRef.current;
        if (!el) 
            return;

        const handleEnd = () => {
            if (state.phase === 'opening') 
                dispatch({ type: 'OPEN_DONE' });
            else if (state.phase === 'closing') 
                dispatch({ type: 'CLOSE_DONE' });
        };

        el.addEventListener('transitionend', handleEnd);
        const timeoutId = setTimeout(handleEnd, ModalClasses.TimeOut);

        return () => {
            el.removeEventListener('transitionend', handleEnd);
            clearTimeout(timeoutId);
        };
    }, [state.phase]);
    
    // Dispara callback onOpenClose e eventos globais somente em estados finais
    useEffect(() => {
        const prev = lastPhaseRef.current;
        const curr = state.phase;
        if (prev !== curr) {
            if (curr === 'open') {
                if (onOpenClose)
                     onOpenClose(true);
                systemDispatch({ type: 'MODAL_OPENED', id: sectionId });
            }
            if (curr === 'closed') {
                if (onOpenClose) 
                    onOpenClose(false);
                systemDispatch({ type: 'MODAL_CLOSED', id: sectionId });
            }
            lastPhaseRef.current = curr;
        }
    }, [state.phase, onOpenClose, systemDispatch, sectionId]);

    // Handler externo
    useEffect(() => {
        if (!handler)
             return;

        handler.open = () => systemDispatch({ type: 'OPEN', id: sectionId });
        handler.close = () => systemDispatch({ type: 'CLOSE', id: sectionId });
        
    }, [handler, systemDispatch, sectionId]);

    const classes = [
        ModalClasses.Modal.Base,
        state.phase === 'closed' ? ModalClasses.Modal.Closed :
        state.phase === 'opening_start' ? ModalClasses.Modal.OpeningStart :
        state.phase === 'opening' ? ModalClasses.Modal.Opening :
        state.phase === 'open' ? ModalClasses.Modal.Open :
        state.phase === 'closing_start' ? ModalClasses.Modal.ClosingStart :
        state.phase === 'closing' ? ModalClasses.Modal.Closing :
        null,
        center ? 'ya-modal-center' : null
    ].filter(Boolean).join(' ');

    return (
        <SectionContent id={sectionId}>
            <div
                ref={modalRef}
                className={classes}
                role="dialog"
                aria-modal="true"
            >
                {children}
            </div>
        </SectionContent>
    );
};

export default Modal;