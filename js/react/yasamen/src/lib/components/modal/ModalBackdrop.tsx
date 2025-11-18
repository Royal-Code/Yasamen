import React from 'react';
import { useModalSystem } from './modal-context';
import { ModalClasses } from './modal-classes';

export type ModalBackdropProps = React.HTMLAttributes<HTMLDivElement> & {
    inertClick?: boolean;
};

export const ModalBackdrop: React.FC<ModalBackdropProps> = ({
    className,
    ...rest
}) => {

    const { state, dispatch } = useModalSystem();
    const ref = React.useRef<HTMLDivElement | null>(null);

    const classes = [
        ModalClasses.Backdrop.Base,
        state.backdropPhase === 'opening' ? ModalClasses.Backdrop.Opening : undefined,
        state.backdropPhase === 'open' ? ModalClasses.Backdrop.Open : undefined,
        state.backdropPhase === 'closing' ? ModalClasses.Backdrop.Closing : undefined,
        className
    ].filter(Boolean).join(' ');

    // Ao entrar em 'opening' ou 'closing', aguarda fim da transição (transitionend / animationend) para disparar evento.
    React.useEffect(() => {
        const el = ref.current;
        if (!el) return;

        let timeoutId: number | undefined;
        const handleEnd = () => {
            if (state.backdropPhase === 'opening') {
                dispatch({ type: 'BACKDROP_OPENED' });
            } else if (state.backdropPhase === 'closing') {
                dispatch({ type: 'BACKDROP_CLOSED' });
            }
        };

        if (state.backdropPhase === 'opening' || state.backdropPhase === 'closing') {
            el.addEventListener('transitionend', handleEnd);
            el.addEventListener('animationend', handleEnd);
            // Fallback caso evento não dispare (tempo baseado no CSS ~250ms)
            timeoutId = window.setTimeout(handleEnd, 300);
        }

        return () => {
            if (el) {
                el.removeEventListener('transitionend', handleEnd);
                el.removeEventListener('animationend', handleEnd);
            }
            if (timeoutId) window.clearTimeout(timeoutId);
        };
    }, [state.backdropPhase, dispatch]);

    return (
        <div
            ref={ref}
            className={classes}
            onClick={() => { dispatch({ type: 'BACKDROP_ACTION' }); }}
            {...rest}
        />
    );
};

export default ModalBackdrop;