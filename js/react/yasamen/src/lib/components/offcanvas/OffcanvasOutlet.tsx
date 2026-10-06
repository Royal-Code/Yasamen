import React, { useEffect } from "react";
import { useOffcanvasSystem } from "./offcanvas-context";
import { OffcanvasClasses } from "./offcanvas-classes";
import { SectionOutlet } from "../outlet";
import { OffcanvasBackdrop, type OffcanvasBackdropAction } from "./OffcanvasBackdrop";
import type { OffcanvasAction } from "./Offcanvas";

export interface OffcanvasItem {
    id: string;
    dispatch: React.ActionDispatch<[action: OffcanvasAction]>;
    closeable: boolean;
    backdrop: boolean;
    closeOnBackdropClick?: boolean;
}

export interface OffcanvasSystemState {
    isOpen: boolean;
    backdropDispatch?: React.Dispatch<OffcanvasBackdropAction>;
    items: OffcanvasItem[];
    openedItemsIds: string[];
    actionQueue: OffcanvasSystemAction[];
    processQueue: boolean;
    effectQueue: (() => void)[];
}

export type OffcanvasSystemAction =
    | { type: 'REGISTER'; item: OffcanvasItem }
    | { type: 'UNREGISTER'; item: OffcanvasItem }
    | { type: 'OPEN'; id: string }
    | { type: 'CLOSE'; id: string }
    | { type: 'SET_BACKDROP_DISPATCH'; dispatch?: React.Dispatch<OffcanvasBackdropAction> }
    | { type: 'BACKDROP_ACTION' }
    | { type: 'OPEN_OUTLET' }
    | { type: 'CLOSE_OUTLET' }
    | { type: 'OPEN_BACKDROP' }
    | { type: 'CLOSE_BACKDROP' }
    | { type: 'OPEN_OFFCANVAS'; id: string }
    | { type: 'CLOSE_OFFCANVAS'; id: string }
    | { type: 'PROCESS_QUEUE' }
    | { type: 'EFFECT_PROCESSED' }
    | { type: 'OFFCANVAS_OPENED'; id: string }
    | { type: 'OFFCANVAS_CLOSED'; id: string }
    | { type: 'BACKDROP_OPENED' }
    | { type: 'BACKDROP_CLOSED' }
    | { type: 'OUTLET_SHOWN' }
    | { type: 'OUTLET_HIDDEN' };

export const OffcanvasSystemReducer = (
    state: OffcanvasSystemState,
    action: OffcanvasSystemAction
): OffcanvasSystemState => {
    switch (action.type) {
        case "REGISTER": {
            if (state.items.find(i => i.id === action.item.id)) return state;
            return { ...state, items: [...state.items, action.item] };
        }
        case "UNREGISTER": {
            const nextItems = state.items.filter(i => i.id !== action.item.id);
            const nextOpened = state.openedItemsIds.filter(id => id !== action.item.id);
            return {
                ...state,
                items: nextItems,
                openedItemsIds: nextOpened,
                isOpen: nextOpened.length > 0,
            };
        }
        case "OPEN": {
            const item = state.items.find(i => i.id === action.id);
            if (!item) return state;
            if (state.openedItemsIds.includes(action.id)) return state;

            const isFirst = state.openedItemsIds.length === 0;
            const newOpened = [...state.openedItemsIds, action.id];
            const queue: OffcanvasSystemAction[] = [];

            if (isFirst) {
                queue.push({ type: 'OPEN_OUTLET' });
                if (item.backdrop) {
                    queue.push({ type: 'OPEN_BACKDROP' });
                }
            }
            queue.push({ type: 'OPEN_OFFCANVAS', id: action.id });

            return {
                ...state,
                openedItemsIds: newOpened,
                actionQueue: [...state.actionQueue, ...queue],
                processQueue: true
            };
        }
        case "CLOSE": {
            if (!state.openedItemsIds.includes(action.id)) return state;

            const remaining = state.openedItemsIds.filter(id => id !== action.id);
            const isLast = remaining.length === 0;
            const queue: OffcanvasSystemAction[] = [
                { type: 'CLOSE_OFFCANVAS', id: action.id }
            ];

            if (isLast) {
                queue.push({ type: 'CLOSE_BACKDROP' });
                queue.push({ type: 'CLOSE_OUTLET' });
            }

            return {
                ...state,
                openedItemsIds: remaining,
                actionQueue: [...state.actionQueue, ...queue],
                processQueue: true
            };
        }
        case "BACKDROP_ACTION": {
            if (state.openedItemsIds.length === 0) return state;
            const topId = state.openedItemsIds[state.openedItemsIds.length - 1];
            const topItem = state.items.find(i => i.id === topId);
            if (topItem && topItem.closeable) {
                return OffcanvasSystemReducer(state, { type: 'CLOSE', id: topId });
            }
            return state;
        }
        case "SET_BACKDROP_DISPATCH":
            return { ...state, backdropDispatch: action.dispatch };
        case "OPEN_OUTLET":
            return { ...state, isOpen: true };
        case "CLOSE_OUTLET":
            return { ...state, isOpen: false };
        case "OPEN_BACKDROP":
            return {
                ...state,
                effectQueue: [
                    ...state.effectQueue,
                    () => state.backdropDispatch?.({ type: 'OPEN' })
                ]
            };
        case "CLOSE_BACKDROP":
            return {
                ...state,
                effectQueue: [
                    ...state.effectQueue,
                    () => state.backdropDispatch?.({ type: 'CLOSE' })
                ]
            };
        case "OPEN_OFFCANVAS": {
            const it = state.items.find(i => i.id === action.id);
            if (!it) return state;
            return {
                ...state,
                effectQueue: [
                    ...state.effectQueue,
                    () => it.dispatch({ type: 'OPEN' })
                ]
            };
        }
        case "CLOSE_OFFCANVAS": {
            const it = state.items.find(i => i.id === action.id);
            if (!it) return state;
            return {
                ...state,
                effectQueue: [
                    ...state.effectQueue,
                    () => it.dispatch({ type: 'CLOSE' })
                ]
            };
        }
        case "PROCESS_QUEUE": {
            if (state.actionQueue.length === 0) {
                return { ...state, processQueue: false };
            }
            const [nextAction, ...restQueue] = state.actionQueue;
            const nextState = OffcanvasSystemReducer(state, nextAction);
            return {
                ...nextState,
                actionQueue: restQueue,
                processQueue: restQueue.length > 0
            };
        }
        case "EFFECT_PROCESSED": {
            const [, ...remaining] = state.effectQueue;
            return { ...state, effectQueue: remaining };
        }
        default:
            return state;
    }
};

export interface OffcanvasOutletProps extends React.HTMLAttributes<HTMLDivElement> {
    className?: string;
}

export const OffcanvasOutlet: React.FC<OffcanvasOutletProps> = ({ className, ...rest }) => {
    const system = useOffcanvasSystem();
    if (!system) return null;

    const { state } = system;
    const outletClasses = [
        OffcanvasClasses.Outlet.Base,
        state.isOpen ? OffcanvasClasses.Outlet.Open : undefined,
        className
    ].filter(Boolean).join(' ');

    return (
        <div className={outletClasses} aria-hidden={state.isOpen ? undefined : true} {...rest}>
            {state.items.map(item => (
                <SectionOutlet id={item.id} key={item.id} />
            ))}
            <OffcanvasBackdrop />
            <OffcanvasOutletEffects />
        </div>
    );
};

const OffcanvasOutletEffects: React.FC = () => {
    const system = useOffcanvasSystem();
    const state = system?.state;
    const dispatch = system?.dispatch;

    useEffect(() => {
        if (!state || !dispatch) return;
        if (state.processQueue) {
            dispatch({ type: 'PROCESS_QUEUE' });
        }
    }, [state, dispatch]);

    useEffect(() => {
        if (!state || !dispatch) return;
        if (state.effectQueue.length > 0) {
            state.effectQueue[0]();
            dispatch({ type: 'EFFECT_PROCESSED' });
        }
    }, [state, dispatch]);

    useEffect(() => {
        if (!state || !dispatch) return;
        if (state.openedItemsIds.length === 0) return;

        const onKey = (e: KeyboardEvent) => {
            if (e.key === 'Escape') {
                dispatch({ type: 'BACKDROP_ACTION' });
            }
        };

        window.addEventListener('keydown', onKey);
        return () => window.removeEventListener('keydown', onKey);
    }, [state, dispatch]);

    return null;
};

export default OffcanvasOutlet;
