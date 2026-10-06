import React, { useEffect, useReducer, useRef } from 'react';
import { useOffcanvasSystem } from './offcanvas-context';
import { OffcanvasClasses } from './offcanvas-classes';

export type OffcanvasBackdropProps = React.HTMLAttributes<HTMLDivElement> & {
    onClick?: () => void;
};

interface BackdropState {
    phase: 'closed' | 'opening_start' | 'opening' | 'open' | 'closing';
}

export type OffcanvasBackdropAction =
    | { type: 'OPEN' }
    | { type: 'OPEN_PROMOTE' }
    | { type: 'OPEN_DONE' }
    | { type: 'CLOSE' }
    | { type: 'CLOSE_DONE' }
    | { type: 'TRANSITION_END' };

const reducer = (state: BackdropState, action: OffcanvasBackdropAction): BackdropState => {
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

export const OffcanvasBackdrop: React.FC<OffcanvasBackdropProps> = ({
    className,
    onClick,
    ...rest
}) => {
    const system = useOffcanvasSystem();
    const systemDispatch = system?.dispatch;
    const [state, dispatch] = useReducer(reducer, { phase: 'closed' });
    const lastPhaseRef = useRef(state.phase);

    useEffect(() => {
        if (systemDispatch) {
            systemDispatch({ type: 'SET_BACKDROP_DISPATCH', dispatch });
        }
        return () => {
            if (systemDispatch) {
                systemDispatch({ type: 'SET_BACKDROP_DISPATCH', dispatch: undefined });
            }
        };
    }, [systemDispatch]);

    useEffect(() => {
        if (state.phase === 'opening_start') {
            const raf = requestAnimationFrame(() => {
                dispatch({ type: 'OPEN_PROMOTE' });
            });
            return () => cancelAnimationFrame(raf);
        }
    }, [state.phase]);

    // Fallback timeout
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

    useEffect(() => {
        if (lastPhaseRef.current !== state.phase) {
            lastPhaseRef.current = state.phase;
            if (systemDispatch) {
                if (state.phase === 'open') {
                    systemDispatch({ type: 'BACKDROP_OPENED' });
                } else if (state.phase === 'closed') {
                    systemDispatch({ type: 'BACKDROP_CLOSED' });
                }
            }
        }
    }, [state.phase, systemDispatch]);

    const handleClick: React.MouseEventHandler<HTMLDivElement> = () => {
        if (onClick) {
            onClick();
        } else if (systemDispatch) {
            systemDispatch({ type: 'BACKDROP_ACTION' });
        }
    };

    const classes = [
        OffcanvasClasses.Backdrop.Base,
        state.phase === 'opening_start' ? OffcanvasClasses.Backdrop.OpeningStart : undefined,
        state.phase === 'opening' ? OffcanvasClasses.Backdrop.Opening : undefined,
        state.phase === 'open' ? OffcanvasClasses.Backdrop.Open : undefined,
        state.phase === 'closing' ? OffcanvasClasses.Backdrop.Closing : undefined,
        state.phase === 'closed' ? OffcanvasClasses.Backdrop.Closed : undefined,
        className
    ].filter(Boolean).join(' ');

    return (
        <div
            className={classes}
            onClick={handleClick}
            onTransitionEnd={() => dispatch({ type: 'TRANSITION_END' })}
            {...rest}
        />
    );
};

export default OffcanvasBackdrop;
