import React, { createContext, useContext } from "react";

interface SectionStackItem {
    instanceId: symbol;
    node: React.ReactNode;
}

export interface SectionState {
    [id: string]: SectionStackItem[];
}

interface SectionContextValue {
    state: SectionState;
    mount: (id: string, node: React.ReactNode) => symbol;
    update: (instance: symbol, id: string, node: React.ReactNode) => void;
    unmount: (instance: symbol, id: string) => void;
}

const SectionContext = createContext<SectionContextValue | null>(null);

export const SectionProvider: React.FC<React.PropsWithChildren> = ({ children }) => {
    const [state, setState] = React.useState<SectionState>({});

    const mount = React.useCallback((id: string, node: React.ReactNode) => {
        const instance = Symbol(id);
        setState(prev => {
            const stack = prev[id] 
                ? [...prev[id], { instanceId: instance, node }] 
                : [{ instanceId: instance, node }];
            return { ...prev, [id]: stack };
        });
        return instance;
    }, []);

    const update = React.useCallback((instance: symbol, id: string, node: React.ReactNode) => {
        setState(prev => {
            const stack = prev[id];
            if (!stack) 
                return prev;

            const idx = stack.findIndex(s => s.instanceId === instance);
            if (idx === -1)
                 return prev;
                
            const newStack = [...stack];
            newStack[idx] = { ...newStack[idx], node };
            return { ...prev, [id]: newStack };
        });
    }, []);

    const unmount = React.useCallback((instance: symbol, id: string) => {
        setState(prev => {
            const stack = prev[id];
            if (!stack) 
                return prev;

            const newStack = stack.filter(s => s.instanceId !== instance);
            const next = { ...prev } as SectionState;
            if (newStack.length === 0) {
                delete next[id];
            } else {
                next[id] = newStack;
            }
            return next;
        });
    }, []);

    const value: SectionContextValue = React.useMemo(() => ({ state, mount, update, unmount }), [state, mount, update, unmount]);

    return <SectionContext.Provider value={value}>{children}</SectionContext.Provider>;
};

export function useSectionSystem() {
    const ctx = useContext(SectionContext);
    if (!ctx) 
        throw new Error("useSectionSystem must be used inside SectionProvider");
    return ctx;
}
