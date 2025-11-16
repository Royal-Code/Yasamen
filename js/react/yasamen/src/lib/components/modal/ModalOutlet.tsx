import React from "react";
import { useModalSystem } from "./modal-context";
import { ModalClasses } from "./modal-classes";

export const ModalOutlet: React.FC<React.HTMLAttributes<HTMLDivElement>> = ({
    ...rest
}) => {
    const { state, dispatch } = useModalSystem();
    const anyOpen = state.order.length > 0;

    const backdropClasses = [
        ModalClasses.Backdrop.Base,
        anyOpen ? ModalClasses.Backdrop.Shown : ModalClasses.Backdrop.Hidden,
    ].join(" ");

    const outletClasses = [
        ModalClasses.Outlet.Base,
        anyOpen ? ModalClasses.Outlet.Show : undefined,
    ]
        .filter(Boolean)
        .join(" ");

    // adiciona aria-hidden booleano quando nenhum modal está aberto (tipagem Booleanish)
    const rest2: React.HTMLAttributes<HTMLDivElement> = anyOpen ? rest : { ...rest, 'aria-hidden': true };

    return (
        <div className={outletClasses} {...rest2}>
            {Object.values(state.items).map((item) => (
                <ModalWindow
                    key={item.id}
                    item={item}
                    onTransitionEnd={() =>
                        dispatch({ type: "TRANSITION_DONE", id: item.id })
                    }
                />
            ))}
            <div className={backdropClasses} onClick={() => {
                const top = state.order[state.order.length - 1];
                if (!top) return;
                const descriptor = state.items[top];
                if (descriptor.closeable)
                    dispatch({ type: "CLOSE", id: top });
            }}
            />
        </div>
    );
};

interface ModalWindowProps {
    item: {
        id: string;
        content: React.ReactNode;
        phase: "idle" | "opening" | "open" | "closing";
    };
    onTransitionEnd: () => void;
}

const ModalWindow: React.FC<ModalWindowProps> = ({ item, onTransitionEnd }) => {
    const { dispatch } = useModalSystem();

    const classes = [
        ModalClasses.Window.Base,
        item.phase === 'idle' && ModalClasses.Window.Idle,
        (item.phase === "open" || item.phase === "closing") &&
            ModalClasses.Window.Show,
        item.phase === "opening" && ModalClasses.Window.Opening,
        item.phase === "closing" && ModalClasses.Window.Closing,
    ]
        .filter(Boolean)
        .join(" ");

    // Fallback apenas se a animação NÃO disparar (tempo > duração). Evita pular a animação na abertura.
    React.useEffect(() => {
        if (item.phase === 'opening') {
            const timeout = setTimeout(() => {
                // Se ainda em opening após 300ms, força finalizar.
                const current = item.phase;
                if (current === 'opening') {
                    dispatch({ type: 'TRANSITION_DONE', id: item.id });
                }
            }, 300); // > 250ms para dar tempo da animação
            return () => clearTimeout(timeout);
        }
        if (item.phase === 'closing') {
            const timeout = setTimeout(() => {
                const current = item.phase;
                if (current === 'closing') {
                    dispatch({ type: 'TRANSITION_DONE', id: item.id });
                }
            }, 300);
            return () => clearTimeout(timeout);
        }
    }, [item.phase, item.id, dispatch]);

    return (
        <div
            id={item.id}
            className={classes}
            tabIndex={-1}
            aria-modal="true"
            role="dialog"
            onAnimationEnd={onTransitionEnd}
        >
            {item.content}
        </div>
    );
};
