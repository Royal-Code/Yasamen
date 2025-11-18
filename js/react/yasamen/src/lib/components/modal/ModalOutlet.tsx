import React, { useEffect } from "react";
import { useModalSystem } from "./modal-context";
import { ModalClasses } from "./modal-classes";
import { SectionOutlet } from "../outlet";
import type { ModalItem } from "./Modal";
import { ModalBackdrop, type BackdropAction } from './ModalBackdrop';

export interface ModalSystemState {
    isOpen: boolean; // outlet visível
    backdropDispatch?: React.Dispatch<BackdropAction>; // dispatch do backdrop
    items: ModalItem[]; // modais registrados (sempre montados)
    openedItemsIds: string[]; // stack de modais abertos (topo = último)
    actionQueue: ModalSystemAction[]; // fila de ações internas e high-level
    processQueue: boolean; // se true, deve processar a fila
    effectQueue: EffectCommand[]; // fila de comandos de efeito a serem processados
}

export type ModalSystemAction =
    | { type: 'REGISTER'; item: ModalItem }
    | { type: 'UNREGISTER'; item: ModalItem }
    | { type: 'OPEN'; id: string } // high-level solicitar abertura
    | { type: 'CLOSE'; id: string } // high-level solicitar fechamento
    | { type: 'SET_BACKDROP_DISPATCH'; dispatch?: React.Dispatch<BackdropAction>}
    | { type: 'BACKDROP_ACTION' }
    | { type: 'OPEN_OUTLET' }
    | { type: 'CLOSE_OUTLET' }
    | { type: 'OPEN_BACKDROP' }
    | { type: 'CLOSE_BACKDROP' }
    | { type: 'OPEN_MODAL'; id: string }
    | { type: 'CLOSE_MODAL'; id: string }
    | { type: 'PROCESS_QUEUE'; processNext?: boolean }
    | { type: 'EFFECT_PROCESSED' }
    | { type: 'MODAL_OPENED'; id: string } // evento (futuro trigger por animação)
    | { type: 'MODAL_CLOSED'; id: string } // evento (futuro trigger por animação)
    | { type: 'BACKDROP_OPENED' }
    | { type: 'BACKDROP_CLOSED' }
    | { type: 'OUTLET_SHOWN' }
    | { type: 'OUTLET_HIDDEN' };

export interface EffectCommand {
    execute: () => void;
}

export const ModalSystemReducer = (state: ModalSystemState, action: ModalSystemAction): ModalSystemState => {
    if (import.meta.env.MODE !== 'production') {
        console.log('[ModalSystemReducer]', action.type, action);
    }
    switch (action.type) {
        case "REGISTER": {

            if (state.items.find(i => i.id === action.item.id))
                return state;

            return {
                ...state,
                items: [...state.items, action.item],
            };
        }
        case "UNREGISTER": {

            // se o item é o atual (ultimo do openedItemsIds), fecha antes de remover
            if (state.openedItemsIds.length > 0 &&
                state.openedItemsIds[state.openedItemsIds.length - 1] === action.item.id) {
                    return {
                        ...state,
                        actionQueue: [
                            ...state.actionQueue, 
                            { type: "CLOSE", id: action.item.id },
                            action
                        ],
                        processQueue: true,
                    };
                }

            return {
                ...state,
                items: state.items.filter(i => i.id !== action.item.id),
                openedItemsIds: state.openedItemsIds.filter(id => id !== action.item.id),
            };
        }
        case 'OPEN': {

            // se já está aberto, não faz nada
            if (state.openedItemsIds.length > 0 &&
                state.openedItemsIds[state.openedItemsIds.length - 1] === action.id) {
                    return state;
                }

            // se já tem algum aberto, enfileira a ação de fechar o atual e abrir o novo
            if (state.openedItemsIds.length > 0) {
                return {
                    ...state,
                    openedItemsIds: [...state.openedItemsIds, action.id],
                    actionQueue: [
                        ...state.actionQueue,
                        { type: "CLOSE_MODAL", id: state.openedItemsIds[state.openedItemsIds.length - 1] },
                        { type: "OPEN_MODAL", id: action.id }
                    ],
                    processQueue: true,
                };
            }
            else {
                // senão, enfilera abertura do outlet, do backdrop e do modal
                return {
                    ...state,
                    openedItemsIds: [action.id],
                    actionQueue: [
                        ...state.actionQueue,
                        { type: "OPEN_OUTLET" },
                        { type: "OPEN_BACKDROP" },
                        { type: "OPEN_MODAL", id: action.id }
                    ],
                    processQueue: true,
                };
            }
        }
        case 'CLOSE': {

            if (state.openedItemsIds.length === 0)
                return state;

            const lastId = state.openedItemsIds[state.openedItemsIds.length - 1];

            if (lastId !== action.id)
                return {
                    ...state,
                    openedItemsIds: state.openedItemsIds.filter(id => id !== action.id),
                    processQueue: true,
                };
            
            // se houver mais de um aberto, enfileira o fechamento do atual e a reabertura do anterior
            if (state.openedItemsIds.length > 1) {
                return {
                    ...state,
                    openedItemsIds: state.openedItemsIds.filter(id => id !== action.id),
                    actionQueue: [
                        ...state.actionQueue,
                        { type: "CLOSE_MODAL", id: action.id },
                        { type: "OPEN_MODAL", id: state.openedItemsIds[state.openedItemsIds.length - 2] }
                    ],
                    processQueue: true,
                };
            }
            else {
                // senão, enfilera o fechamento do modal, do backdrop e do outlet
                return {
                    ...state,
                    openedItemsIds: state.openedItemsIds.filter(id => id !== action.id),
                    actionQueue: [
                        ...state.actionQueue,
                        { type: "CLOSE_MODAL", id: action.id },
                        { type: "CLOSE_BACKDROP" },
                        { type: "CLOSE_OUTLET" }
                    ],
                    processQueue: true,
                };
            }
        }
        case 'SET_BACKDROP_DISPATCH': {
            return {
                ...state,
                backdropDispatch: action.dispatch,
            };
        }
        case 'BACKDROP_ACTION': {

            // verifica se há algum aberto
            if (state.openedItemsIds.length === 0)
                return state;

            const lastId = state.openedItemsIds[state.openedItemsIds.length - 1];
            const lastItem = state.items.find(i => i.id === lastId);
            if (!lastItem || !lastItem.closeable)
                return state;

            // se o último aberto for closeable, enfileira o fechamento
            return ModalSystemReducer(state, { type: 'CLOSE', id: lastId });
        }
        // Internas de efeito imediato (sem animação ainda)
        case 'OPEN_OUTLET': {
            if (state.isOpen) 
                return state;

            return { ...state, isOpen: true };
        }
        case 'CLOSE_OUTLET': {
            if (!state.isOpen)
                 return state;

            return { ...state, isOpen: false };
        }
        case 'OPEN_BACKDROP': {
            if (state.backdropDispatch)
            {
                const dispatch = state.backdropDispatch;
                const command = {
                    execute: () => {
                        dispatch({ type: 'OPEN' });
                    }
                };

                return {
                    ...state,
                    effectQueue: [...state.effectQueue, command ]
                };
            }
            return state;
        }
        case 'CLOSE_BACKDROP': {
            if (state.backdropDispatch) {
                const dispatch = state.backdropDispatch;
                const command = {
                    execute: () => {
                        dispatch({ type: 'CLOSE' });
                    }
                };

                return {
                    ...state,
                    effectQueue: [...state.effectQueue, command ]
                };
            }
            return state;
        }
        case 'OPEN_MODAL': {

            const item = state.items.find(i => i.id === action.id);
            if (!item) 
                return state;

            const command = {
                execute: () => {
                    item.dispatch({ type: 'OPEN' });
                }
            };

            return { 
                ...state,
                effectQueue: [...state.effectQueue, command ],
                processQueue: false
            };
        }
        case 'CLOSE_MODAL': {

            const item = state.items.find(i => i.id === action.id);
            if (!item) 
                return state;

            const command = {
                execute: () => {
                    item.dispatch({ type: 'CLOSE' });
                }
            };

            return {
                ...state,
                effectQueue: [...state.effectQueue, command ],
                processQueue: false
            }
        }
        case 'MODAL_OPENED': {
            if (state.actionQueue.length === 0)
                return state;   
            return {
                ...state,
                processQueue: true,
            }
        }
        case 'MODAL_CLOSED': {
            return {
                ...state,
                processQueue: true,
            };
        }
        case 'BACKDROP_OPENED': {
            return {
                ...state,
                processQueue: state.actionQueue.length > 0
            };
        }
        case 'BACKDROP_CLOSED': {
            return {
                ...state,
                processQueue: state.actionQueue.length > 0
            };
        }
        case 'OUTLET_SHOWN': {
            // processar próxima acão da fila, se houver
            if (state.actionQueue.length === 0)
                return state;
            return {
                ...state,
                processQueue: true,
            };
        }
        case 'OUTLET_HIDDEN': {
            // processar próxima acão da fila, se houver
            if (state.actionQueue.length === 0)
                return state;
            return {
                ...state,
                processQueue: true,
            };
        }
        case 'PROCESS_QUEUE': {
            
            if (state.actionQueue.length === 0) {
                if (state.processQueue)
                    return { ...state, processQueue: false };
                return state;
            }

            const [next, ...rest] = state.actionQueue;

            // aplica primeira ação imediatamente chamando reducer recursivamente
            const stateAfter = ModalSystemReducer({
                ...state, 
                actionQueue: rest,
                processQueue: action.processNext ?? false
            }, next);

            return stateAfter;
        }
        case 'EFFECT_PROCESSED': {
            if (state.effectQueue.length === 0)
                return state;

            const [, ...rest] = state.effectQueue;
            return {
                ...state,
                effectQueue: rest
            };
        }
        default:
            return state;
    }
};

export const ModalOutlet: React.FC<React.HTMLAttributes<HTMLDivElement>> = ({
    ...rest
}) => {
    const { state, } = useModalSystem();

    const outletClasses = [
        ModalClasses.Outlet.Base,
        state.isOpen ? ModalClasses.Outlet.Open : undefined,
    ]
        .filter(Boolean)
        .join(" ");

    // adiciona aria-hidden booleano quando nenhum modal está aberto (tipagem Booleanish)
    const rest2: React.HTMLAttributes<HTMLDivElement> = { ...rest, 'aria-hidden': state.isOpen ? undefined : true };

    return (
        <div className={outletClasses} {...rest2}>
            {Object.values(state.items).map(item => (
                <SectionOutlet id={item.id} key={item.id} />
            ))}
            <ModalBackdrop />
            <ModalOutletEffects />
        </div>
    );
};

const ModalOutletEffects: React.FC = () => {

    const { state, dispatch } = useModalSystem();

    useEffect(() => {
        // Dispara evento após o próximo frame (DOM já atualizado e classes aplicadas)
        const raf = requestAnimationFrame(() => {
            dispatch({ type: state.isOpen ? 'OUTLET_SHOWN' : 'OUTLET_HIDDEN' });
        });
        return () => cancelAnimationFrame(raf);
    }, [state.isOpen, dispatch]);

    // Processa uma ação da fila por render até esvaziar
    useEffect(() => {
        if (state.processQueue === true) {
            dispatch({ type: 'PROCESS_QUEUE' });
        }
    }, [state.processQueue, dispatch]);

    // Processa commandos de efeito (animações) um por render até esvaziar
    useEffect(() => {
        if (state.effectQueue.length > 0) {
            state.effectQueue[0].execute();
            dispatch({ type: 'EFFECT_PROCESSED' });
        }
    }, [state.effectQueue, dispatch]);

    // Listener para tecla ESC fechando modal topo (equivalente a BACKDROP_ACTION)
    useEffect(() => {
        if (state.openedItemsIds.length === 0)
             return;

        const onKey = (e: KeyboardEvent) => {
            if (e.key === 'Escape') {
                dispatch({ type: 'BACKDROP_ACTION' });
            }
        };

        window.addEventListener('keydown', onKey);

        return () => window.removeEventListener('keydown', onKey);
        
    }, [state.openedItemsIds.length, dispatch]);

    return null;
}