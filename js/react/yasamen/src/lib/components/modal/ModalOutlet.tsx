import React, { useEffect } from "react";
import { useModalSystem } from "./modal-context";
import { ModalClasses } from "./modal-classes";
import { SectionOutlet } from "../outlet";
import type { ModalItem } from "./modal";
import { ModalBackdrop } from './ModalBackdrop';

export interface ModalSystemState {
    isOpen: boolean; // outlet visível
    backdropPhase: 'closed' | 'opening' | 'open' | 'closing';
    items: ModalItem[]; // modais registrados (sempre montados)
    openedItemsIds: string[]; // stack de modais abertos (topo = último)
    actionQueue: ModalSystemAction[]; // fila de ações internas e high-level
    processQueue: boolean; // se true, deve processar a fila
}

export type ModalSystemAction =
    | { type: 'REGISTER'; item: ModalItem }
    | { type: 'UNREGISTER'; item: ModalItem }
    | { type: 'OPEN'; id: string } // high-level solicitar abertura
    | { type: 'CLOSE'; id: string } // high-level solicitar fechamento
    | { type: 'BACKDROP_ACTION' }
    | { type: 'OPEN_OUTLET' }
    | { type: 'CLOSE_OUTLET' }
    | { type: 'OPEN_BACKDROP' }
    | { type: 'CLOSE_BACKDROP' }
    | { type: 'OPEN_MODAL'; id: string }
    | { type: 'CLOSE_MODAL'; id: string }
    | { type: 'PROCESS_QUEUE'; processNext?: boolean }
    | { type: 'MODAL_OPENED'; id: string } // evento (futuro trigger por animação)
    | { type: 'MODAL_CLOSED'; id: string } // evento (futuro trigger por animação)
    | { type: 'BACKDROP_OPENED' }
    | { type: 'BACKDROP_CLOSED' }
    | { type: 'OUTLET_SHOWN' }
    | { type: 'OUTLET_HIDDEN' };

export const ModalSystemReducer = (state: ModalSystemState, action: ModalSystemAction): ModalSystemState => {
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
                    actionQueue: [
                        ...state.actionQueue,
                        { type: "CLOSE", id: state.openedItemsIds[state.openedItemsIds.length - 1] },
                        { type: "OPEN", id: action.id }
                    ],
                    processQueue: true,
                };
            }
            else {
                // senão, enfilera abertura do outlet, do backdrop e do modal
                return {
                    ...state,
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

            // se não for o último aberto então só remove da lista de abertos
            if (state.openedItemsIds[state.openedItemsIds.length - 1] !== action.id) {
                return {
                    ...state,
                    openedItemsIds: state.openedItemsIds.filter(id => id !== action.id),
                };
            }
            
            // se houver mais de um aberto, enfileira o fechamento do atual e a reabertura do anterior
            if (state.openedItemsIds.length > 1) {
                return {
                    ...state,
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
        case 'BACKDROP_ACTION': {

            // verifica se há algum aberto
            if (state.openedItemsIds.length === 0)
                return state;

            // se o último aberto for closeable, enfileira o fechamento
            const lastId = state.openedItemsIds[state.openedItemsIds.length - 1];
            const lastItem = state.items.find(i => i.id === lastId);
            if (lastItem) {
                // aqui seria necessário verificar a propriedade closeable do modal
                return {
                    ...state,
                    actionQueue: [
                        ...state.actionQueue,
                        { type: "CLOSE", id: lastId }
                    ],
                    processQueue: true,
                };
            }

            return state;
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
            if (state.backdropPhase !== 'closed')
                 return state;

            return { ...state, backdropPhase: 'opening' };
        }
        case 'CLOSE_BACKDROP': {
            if (state.backdropPhase === 'closed') 
                return state;

            return { ...state, backdropPhase: 'closing' };
        }
        case 'OPEN_MODAL': {
            // adiciona id ao topo se ainda não for o topo
            const top = state.openedItemsIds[state.openedItemsIds.length - 1];

            if (top === action.id) 
                return state; // já é topo

            // dispara dispatch local OPEN
            state.items.find(i => i.id === action.id)?.dispatch({ type: 'OPEN' });

            return { 
                ...state,
                 openedItemsIds: [...state.openedItemsIds, action.id] 
            };
        }
        case 'CLOSE_MODAL': {

            const top = state.openedItemsIds[state.openedItemsIds.length - 1];
            if (!top) 
                return state;

            // se id não for topo, apenas remove da stack
            if (top !== action.id) {
                return {
                    ...state,
                    openedItemsIds: state.openedItemsIds.filter(id => id !== action.id)
                };
            }

            // dispara dispatch local CLOSE
            state.items.find(i => i.id === action.id)?.dispatch({ type: 'CLOSE' });

            // Mantém id até animação terminar (evento futuro MODAL_CLOSED vai tirar)
            return state;
        }
        // Eventos (placeholder para futuro processamento de animação)
        case 'MODAL_OPENED': {
            
            // processar próxima acão da fila, se houver
            if (state.actionQueue.length === 0)
                return state;   
            return {
                ...state,
                processQueue: true,
            }
        }
        case 'MODAL_CLOSED': {
            // remover da stack ao final real da animação
            return {
                ...state,
                openedItemsIds: state.openedItemsIds.filter(id => id !== action.id),
                processQueue: true,
            };
        }
        case 'BACKDROP_OPENED': {
            if (state.backdropPhase === 'opening') {
                return { ...state, backdropPhase: 'open', processQueue: state.actionQueue.length > 0 };
            }
            return state;
        }
        case 'BACKDROP_CLOSED': {
            if (state.backdropPhase === 'closing') {
                return { ...state, backdropPhase: 'closed', processQueue: state.actionQueue.length > 0 };
            }
            return state;
        }
        case 'OUTLET_SHOWN':
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
            }, next as ModalSystemAction);

            return stateAfter;
        }
        default:
            return state;
    }
};

export const ModalOutlet: React.FC<React.HTMLAttributes<HTMLDivElement>> = ({
    ...rest
}) => {
    const { state, dispatch } = useModalSystem();

    const outletClasses = [
        ModalClasses.Outlet.Base,
        state.isOpen ? ModalClasses.Outlet.Open : undefined,
    ]
        .filter(Boolean)
        .join(" ");

    // adiciona aria-hidden booleano quando nenhum modal está aberto (tipagem Booleanish)
    const rest2: React.HTMLAttributes<HTMLDivElement> = { ...rest, 'aria-hidden': state.isOpen ? undefined : true };

    useEffect(() => {
        // após abrir ou fechar o outlet, dispara evento correspondente
        if (state.isOpen) {
            dispatch({ type: 'OUTLET_SHOWN' });
        } else {
            dispatch({ type: 'OUTLET_HIDDEN' });
        }
    }, [state.isOpen, dispatch]);

    return (
        <div className={outletClasses} {...rest2}>
            {Object.values(state.items).map(item => (
                <SectionOutlet id={item.id} key={item.id} />
            ))}
            <ModalBackdrop />
        </div>
    );
};