import React, { useEffect, useRef } from 'react';
import { RippleClasses } from './themes';

export interface RippleProps {
    dark?: boolean;
    className?: string;
}

export const Ripple: React.FC<RippleProps> = ({ dark = false, className }) => {
    const spanRef = useRef<HTMLSpanElement | null>(null);

    useEffect(() => {
        const el = spanRef.current;
        if (!el) return;

        const parent = el.parentElement;
        if (!parent) return;

        const clickHandler = (evt: MouseEvent) => {
            if (evt.target === el) return;

            const rect = parent.getBoundingClientRect();
            let x = evt.clientX - rect.left;
            let y = evt.clientY - rect.top;

            const deltaX = Math.max(x, parent.offsetWidth - x);
            const deltaY = Math.max(y, parent.offsetHeight - y);
            const size = Math.sqrt(deltaX ** 2 + deltaY ** 2) * 1.25;

            const currentStyle = getComputedStyle(parent);
            const display = currentStyle.getPropertyValue('display');

            if (display && display.includes('flex')) {
                const adjustX = currentStyle.justifyContent === 'center' ? (size / 2) : 0;
                const adjustY = currentStyle.alignItems === 'center' ? (size / 2) : 0;
                x = x - adjustX;
                y = y - adjustY;
            } else {
                x = x - size / 2;
                y = y - size / 2;
            }

            el.classList.remove(RippleClasses.Animation);
            void el.offsetWidth; // reflow

            el.style.left = x + 'px';
            el.style.top = y + 'px';
            el.style.width = size + 'px';
            el.style.height = size + 'px';
            el.classList.add(RippleClasses.Animation);
        };

        const animationEndHandler = () => {
            el.classList.remove(RippleClasses.Animation);
            el.style.left = '';
            el.style.top = '';
            el.style.width = '';
            el.style.height = '';
        };

        parent.addEventListener('click', clickHandler);
        el.addEventListener('animationend', animationEndHandler);

        return () => {
            parent.removeEventListener('click', clickHandler);
            el.removeEventListener('animationend', animationEndHandler);
        };
    }, []);

    const classes = [
        RippleClasses.Base,
        dark ? RippleClasses.Dark : RippleClasses.Light,
        className
    ].filter(Boolean).join(' ');

    return <span ref={spanRef} className={classes} />;
};