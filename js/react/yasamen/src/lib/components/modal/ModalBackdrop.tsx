import React, { useEffect, useReducer, useRef } from 'react';
import { useModalSystem } from './modal-context';
import { ModalClasses } from './modal-classes';

export type ModalBackdropProps = React.HTMLAttributes<HTMLDivElement> & {
    inertClick?: boolean;
};

interface BackdropState {
    phase: 'closed' | 'opening_start' | 'opening' | 'open' | 'closing';
}

export type BackdropAction =
    | { type: 'OPEN' }
    | { type: 'OPEN_PROMOTE' }
    | { type: 'OPEN_DONE' }
    | { type: 'CLOSE' }
    | { type: 'CLOSE_DONE' };


const reducer = (state: BackdropState, action: BackdropAction): BackdropState => {
    switch (action.type) {
        case 'OPEN':
            return state.phase === 'closed' ? { ...state, phase: 'opening_start' } : state;
        case 'OPEN_PROMOTE':
            return state.phase === 'opening_start' ? { ...state, phase: 'opening' } : state;
        case 'OPEN_DONE':
            return state.phase === 'opening' ? { ...state, phase: 'open' } : state;
        case 'CLOSE':
            return state.phase === 'open' ? { ...state, phase: 'closing' } : state;
        case 'CLOSE_DONE':
            return state.phase === 'closing' ? { ...state, phase: 'closed' } : state;
        default:
            return state;
    }
};

export const ModalBackdrop: React.FC<ModalBackdropProps> = ({
    className,
    ...rest
}) => {

    const { dispatch: systemDispatch } = useModalSystem();
    const [state, dispatch] = useReducer(reducer, {
        phase: 'closed'
    });
    const lastPhaseRef = useRef(state.phase);
    const ref = React.useRef<HTMLDivElement | null>(null);

    const classes = [
        ModalClasses.Backdrop.Base,
        state.phase === 'opening_start' ? ModalClasses.Backdrop.OpeningStart : undefined,
        state.phase === 'opening' ? ModalClasses.Backdrop.Opening : undefined,
        state.phase === 'open' ? ModalClasses.Backdrop.Open : undefined,
        state.phase === 'closing' ? ModalClasses.Backdrop.Closing : undefined,
        className
    ].filter(Boolean).join(' ');

    // Registro no sistema global
    useEffect(() => {
        systemDispatch({ type: "SET_BACKDROP_DISPATCH", dispatch });
        return () => {
            systemDispatch({ type: "SET_BACKDROP_DISPATCH", dispatch: undefined });
        };
    }, [systemDispatch]);

    // Promotion frame opening_start -> opening
    useEffect(() => {
        if (state.phase === 'opening_start') {
            const raf = requestAnimationFrame(() => {
                dispatch({ type: 'OPEN_PROMOTE' });
            });
            return () => cancelAnimationFrame(raf);
        }
    }, [state.phase]);

    // Ao entrar em 'opening' ou 'closing', aguarda fim da transição (transitionend / animationend) para disparar evento.
    useEffect(() => {
        // fases que não precisam aguardar transição
        if (state.phase !== 'opening' && state.phase !== 'closing')
             return;

        const el = ref.current;
        if (!el) 
            return;

        const handleEnd = () => {
            if (state.phase === 'opening') {
                dispatch({ type: 'OPEN_DONE' });
            } else if (state.phase === 'closing') {
                dispatch({ type: 'CLOSE_DONE' });
            }
        };

        el.addEventListener('transitionend', handleEnd);
        const timeoutId = setTimeout(handleEnd, ModalClasses.TimeOut);

        return () => {
            el.removeEventListener('transitionend', handleEnd);
            clearTimeout(timeoutId);
        };
    }, [state.phase]);

    useEffect(() => {
        const prev = lastPhaseRef.current;
        const curr = state.phase;
        if (prev !== curr) {
            if (curr === 'open') {
                systemDispatch({ type: 'BACKDROP_OPENED' });
            }
            if (curr === 'closed') {
                systemDispatch({ type: 'BACKDROP_CLOSED' });
            }
            lastPhaseRef.current = curr;
        }
    }, [state.phase, systemDispatch]);

    return (
        <div
            ref={ref}
            className={classes}
            onClick={() => { systemDispatch({ type: 'BACKDROP_ACTION' }); }}
            {...rest}
        />
    );
};

export default ModalBackdrop;