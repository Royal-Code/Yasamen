import type { ModalAction, ModalState } from "./types";

export function modalReducer(
    state: ModalState,
    action: ModalAction
): ModalState {
    switch (action.type) {
        
        case "REGISTER": {
            if (state.items[action.id]) return state;

            return {
                ...state,
                items: {
                    ...state.items,
                    [action.id]: {
                        id: action.id,
                        content: action.content,
                        closeable: action.closeable,
                        wantOpen: false,
                        phase: "idle",
                    },
                },
            };
        }

        case "UNREGISTER": {
            if (!state.items[action.id])
                 return state;

            const newItems = { ...state.items };

            delete newItems[action.id];
            
            return {
                ...state,
                items: newItems,
                order: state.order.filter((o) => o !== action.id),
                pendingNext: state.pendingNext === action.id ? undefined : state.pendingNext,
            };
        }

        case "OPEN": {
            const isTop = state.order[state.order.length - 1];
            if (!isTop) {
                return applyOpen(state, action.id);
            }
            if (isTop === action.id) return state;
            // marca topo para fechamento e agenda próximo
            return {
                ...applyRequestClose(state, isTop),
                pendingNext: action.id,
            };
        }

        case "CLOSE": {
            const top = state.order[state.order.length - 1];

            if (top !== action.id) return state;

            return applyRequestClose(state, action.id);
        }

        case "PHASE": {
            const item = state.items[action.id];

            if (!item) return state;

            return {
                ...state,
                items: {
                    ...state.items,
                    [action.id]: { ...item, phase: action.phase },
                },
            };
        }

        case "UPDATE_CONTENT": {
            const item = state.items[action.id];
            if (!item) return state;
            return {
                ...state,
                items: {
                    ...state.items,
                    [action.id]: { ...item, content: action.content }
                }
            };
        }

        case "UPDATE_META": {
            const item = state.items[action.id];
            if (!item) return state;
            return {
                ...state,
                items: {
                    ...state.items,
                    [action.id]: { ...item, closeable: action.closeable ?? item.closeable }
                }
            };
        }

        case "TRANSITION_DONE": {
            const item = state.items[action.id];

            if (!item) 
                return state;

            // final de abertura
            if (item.phase === "opening") {
                return setPhase(state, action.id, "open");
            }

            // final de fechamento
            if (item.phase === "closing") {
                // fechar modal atual
                let nextState: ModalState = {
                    ...state,
                    items: {
                        ...state.items,
                        [action.id]: { ...item, phase: "idle", wantOpen: false }
                    }
                };

                if (state.pendingNext) {
                    // abre o próximo agendado, mantendo o atual (idle) no order
                    nextState = {
                        ...applyOpen(nextState, state.pendingNext),
                        pendingNext: undefined
                    };
                    return nextState;
                }

                // fechamento voluntário (sem próximo agendado)
                // remove o modal fechado do order
                const newOrder = nextState.order.filter(o => o !== action.id);
                nextState = { ...nextState, order: newOrder };

                // tentar reabrir último modal idle prévio
                const reopenId = [...newOrder].reverse().find(id => nextState.items[id]?.phase === 'idle');
                if (reopenId) {
                    nextState = applyOpen(nextState, reopenId);
                    return nextState;
                }
                return nextState; // nenhum para reabrir (backdrop some)
            }

            return state;
        }
        default:
            return state;
    }
}

function applyOpen(state: ModalState, id: string): ModalState {
    const item = state.items[id];

    if (!item) return state;

    return {
        ...state,
        order: state.order.includes(id) ? state.order : [...state.order, id],
        items: {
            ...state.items,
            [id]: { ...item, wantOpen: true, phase: "opening" },
        },
    };
}

function applyRequestClose(state: ModalState, id: string): ModalState {
    const item = state.items[id];

    if (!item) return state;

    return {
        ...state,
        items: {
            ...state.items,
            [id]: { ...item, wantOpen: false, phase: "closing" },
        },
    };
}

function setPhase(
    state: ModalState,
    id: string,
    phase: ModalState["items"][string]["phase"]
): ModalState {
    const item = state.items[id];

    if (!item) return state;

    return {
        ...state,
        items: {
            ...state.items,
            [id]: { ...item, phase },
        },
    };
}
