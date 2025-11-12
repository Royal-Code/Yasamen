import React, { useEffect, useRef } from 'react';
import { ThemeClasses } from './themes';

export interface RippleProps {
    dark?: boolean;
    className?: string;
}

export const Ripple: React.FC<RippleProps> = ({ dark = false, className }) => {
    const spanRef = useRef<HTMLSpanElement | null>(null);

    useEffect(() => {
        ripple(spanRef.current);
    }, []);

    const classes = [
        ThemeClasses.Ripple.Base,
        dark ? ThemeClasses.Ripple.Dark : ThemeClasses.Ripple.Light,
        className
    ].filter(Boolean).join(' ');

    return <span ref={spanRef} className={classes} />;
};

function ripple(el: HTMLSpanElement | null) {
    if (!el) return false;

    const parent = el.parentElement;
    if (!parent) return false;

    parent.addEventListener('click', evt => {
        if (evt.target === el) return;

        const rect = parent.getBoundingClientRect();
        let x = (evt as MouseEvent).clientX - rect.left;
        let y = (evt as MouseEvent).clientY - rect.top;

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

        el.classList.remove(ThemeClasses.Ripple.Animation);
        void el.offsetWidth; // reflow

        el.style.left = x + 'px';
        el.style.top = y + 'px';
        el.style.width = size + 'px';
        el.style.height = size + 'px';
        el.classList.add(ThemeClasses.Ripple.Animation);
    });

    el.addEventListener('animationend', () => {
        el.classList.remove(ThemeClasses.Ripple.Animation);
        el.style.left = '';
        el.style.top = '';
        el.style.width = '';
        el.style.height = '';
    });

    return true;
}