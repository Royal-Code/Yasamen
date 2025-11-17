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
    /** Ordem dos modais na pilha de abertos */
    order: string[];
    /** Modais registrados */
    items: Record<string, ModalDescriptor>;
    /** sequência: abrir após fechar topo */
    pendingNext?: string;
}

export type ModalAction =
    | { type: "REGISTER"; id: string; content: React.ReactNode; closeable: boolean, center: boolean }
    | { type: "UNREGISTER"; id: string }
    | { type: "UPDATE_CONTENT"; id: string; content: React.ReactNode }
    | { type: "UPDATE_META"; id: string; closeable?: boolean, center?: boolean }
    | { type: "OPEN"; id: string }                // abre direto ou agenda se topo existe
    | { type: "CLOSE"; id: string }               // fecha topo
    | { type: "PHASE"; id: string; phase: ModalDescriptor["phase"] } // atualização de fase
    | { type: "TRANSITION_DONE"; id: string };    // final de opening/closing