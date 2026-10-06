import React, { useReducer, useEffect, useRef } from "react";
import { SectionContent } from "../outlet";
import { OffcanvasClasses } from "./offcanvas-classes";
import { useOffcanvasSystem, OffcanvasHandlerContext, type OffcanvasHandler } from "./offcanvas-context";

export interface OffcanvasProps extends React.HTMLAttributes<HTMLElement> {
    id: string;
    position?: 'left' | 'right';
    backdrop?: boolean;
    closeOnBackdropClick?: boolean;
    closeable?: boolean;
    isOpen?: boolean;
    children: React.ReactNode;
    onOpenClose?: (isOpen: boolean) => void;
    handler?: OffcanvasHandler;
    className?: string;
}

export { type OffcanvasHandler } from "./offcanvas-context";

interface OffcanvasState {
    phase: 'closed' | 'opening_start' | 'opening' | 'open' | 'closing_start' | 'closing';
    closeable: boolean;
    position: 'left' | 'right';
}

export type OffcanvasAction =
    | { type: 'OPEN' }
    | { type: 'OPEN_PROMOTE' }
    | { type: 'OPEN_DONE' }
    | { type: 'CLOSE' }
    | { type: 'CLOSE_PROMOTE' }
    | { type: 'CLOSE_DONE' }
    | { type: 'TRANSITION_END' };

const reducer = (state: OffcanvasState, action: OffcanvasAction): OffcanvasState => {
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
        case 'TRANSITION_END':
            if (state.phase === 'opening') {
                return { ...state, phase: 'open' };
            } else if (state.phase === 'closing') {
                return { ...state, phase: 'closed' };
            }
            return state;
        default:
            return state;
    }
};

export const Offcanvas: React.FC<OffcanvasProps> = ({
    id,
    position = 'right',
    backdrop = true,
    closeOnBackdropClick = true,
    closeable = true,
    isOpen: controlledIsOpen,
    children,
    onOpenClose,
    handler,
    className = '',
    ...rest
}) => {
    const sectionId = id || 'offcanvas';
    const system = useOffcanvasSystem();
    const systemDispatch = system?.dispatch;

    const [state, dispatch] = useReducer(reducer, {
        phase: 'closed',
        closeable,
        position
    });

    const offcanvasRef = useRef<HTMLDivElement | null>(null);
    const lastPhaseRef = useRef(state.phase);

    // Registro no sistema global
    useEffect(() => {
        if (!systemDispatch) return;
        const item = {
            id: sectionId,
            dispatch,
            closeable,
            backdrop,
            closeOnBackdropClick
        };
        systemDispatch({ type: 'REGISTER', item });
        return () => {
            systemDispatch({ type: 'UNREGISTER', item });
        };
    }, [systemDispatch, sectionId, closeable, backdrop, closeOnBackdropClick]);

    // Animação: promoção de fases
    useEffect(() => {
        if (state.phase === 'opening_start') {
            const raf = requestAnimationFrame(() => {
                dispatch({ type: 'OPEN_PROMOTE' });
            });
            return () => cancelAnimationFrame(raf);
        }
        if (state.phase === 'closing_start') {
            const raf = requestAnimationFrame(() => {
                dispatch({ type: 'CLOSE_PROMOTE' });
            });
            return () => cancelAnimationFrame(raf);
        }
    }, [state.phase]);

    // Timeout de fallback para transições CSS
    useEffect(() => {
        if (state.phase === 'opening') {
            const timer = setTimeout(() => {
                dispatch({ type: 'OPEN_DONE' });
            }, OffcanvasClasses.TimeOut);
            return () => clearTimeout(timer);
        }
        if (state.phase === 'closing') {
            const timer = setTimeout(() => {
                dispatch({ type: 'CLOSE_DONE' });
            }, OffcanvasClasses.TimeOut);
            return () => clearTimeout(timer);
        }
    }, [state.phase]);

    // Notificação de evento onOpenClose
    useEffect(() => {
        if (lastPhaseRef.current !== state.phase) {
            lastPhaseRef.current = state.phase;
            if (state.phase === 'open') {
                onOpenClose?.(true);
                systemDispatch?.({ type: 'OFFCANVAS_OPENED', id: sectionId });
            } else if (state.phase === 'closed') {
                onOpenClose?.(false);
                systemDispatch?.({ type: 'OFFCANVAS_CLOSED', id: sectionId });
            }
        }
    }, [state.phase, onOpenClose, systemDispatch, sectionId]);

    // Suporte ao handler externo
    useEffect(() => {
        if (!handler) return;
        handler.open = () => {
            if (systemDispatch) {
                systemDispatch({ type: 'OPEN', id: sectionId });
            } else {
                dispatch({ type: 'OPEN' });
            }
        };
        handler.close = () => {
            if (systemDispatch) {
                systemDispatch({ type: 'CLOSE', id: sectionId });
            } else {
                dispatch({ type: 'CLOSE' });
            }
        };
    }, [handler, systemDispatch, sectionId]);

    // Suporte a controle declarativo isOpen
    useEffect(() => {
        if (controlledIsOpen === undefined) return;
        const isCurrentlyOpen = state.phase === 'open' || state.phase === 'opening';
        if (controlledIsOpen && !isCurrentlyOpen) {
            if (handler?.open) {
                handler.open();
            } else if (systemDispatch) {
                systemDispatch({ type: 'OPEN', id: sectionId });
            } else {
                dispatch({ type: 'OPEN' });
            }
        } else if (!controlledIsOpen && isCurrentlyOpen) {
            if (handler?.close) {
                handler.close();
            } else if (systemDispatch) {
                systemDispatch({ type: 'CLOSE', id: sectionId });
            } else {
                dispatch({ type: 'CLOSE' });
            }
        }
    }, [controlledIsOpen, handler, systemDispatch, sectionId, state.phase]);

    const activeHandler: OffcanvasHandler = {
        open: () => {
            if (handler?.open) handler.open();
            else if (systemDispatch) systemDispatch({ type: 'OPEN', id: sectionId });
            else dispatch({ type: 'OPEN' });
        },
        close: () => {
            if (handler?.close) handler.close();
            else if (systemDispatch) systemDispatch({ type: 'CLOSE', id: sectionId });
            else dispatch({ type: 'CLOSE' });
        }
    };

    const positionClass = position === 'left' ? OffcanvasClasses.Offcanvas.Start : OffcanvasClasses.Offcanvas.End;
    const phaseClass =
        state.phase === 'closed' ? OffcanvasClasses.Offcanvas.Closed :
        state.phase === 'opening_start' ? OffcanvasClasses.Offcanvas.OpeningStart :
        state.phase === 'opening' ? OffcanvasClasses.Offcanvas.Opening :
        state.phase === 'open' ? OffcanvasClasses.Offcanvas.Open :
        state.phase === 'closing_start' ? OffcanvasClasses.Offcanvas.ClosingStart :
        state.phase === 'closing' ? OffcanvasClasses.Offcanvas.Closing : undefined;

    const classes = [
        OffcanvasClasses.Offcanvas.Base,
        positionClass,
        phaseClass,
        className
    ].filter(Boolean).join(' ');

    const content = (
        <OffcanvasHandlerContext.Provider value={activeHandler}>
            <aside
                ref={offcanvasRef}
                className={classes}
                role="dialog"
                aria-modal={backdrop ? "true" : undefined}
                onTransitionEnd={(e) => {
                    if (e.target !== e.currentTarget) return;
                    if (state.phase === 'opening' || state.phase === 'closing') {
                        dispatch({ type: 'TRANSITION_END' });
                    }
                }}
                {...rest}
            >
                {children}
            </aside>
        </OffcanvasHandlerContext.Provider>
    );

    return <SectionContent id={sectionId}>{content}</SectionContent>;
};

export default Offcanvas;