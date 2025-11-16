export interface ModalDescriptor {
    id: string;
    content: React.ReactNode;
    closeable: boolean;
    // intenção
    wantOpen: boolean;
    // fases
    phase: "idle" | "opening" | "open" | "closing";
}

export interface ModalState {
    order: string[];          // pilha
    items: Record<string, ModalDescriptor>;
    pendingNext?: string;     // sequência: abrir após fechar topo
}

export type ModalAction =
    | { type: "REGISTER"; id: string; content: React.ReactNode; closeable: boolean }
    | { type: "UNREGISTER"; id: string }
    | { type: "UPDATE_CONTENT"; id: string; content: React.ReactNode }
    | { type: "UPDATE_META"; id: string; closeable?: boolean }
    | { type: "OPEN"; id: string }                // abre direto ou agenda se topo existe
    | { type: "CLOSE"; id: string }               // fecha topo
    | { type: "PHASE"; id: string; phase: ModalDescriptor["phase"] } // atualização de fase
    | { type: "TRANSITION_DONE"; id: string };    // final de opening/closing