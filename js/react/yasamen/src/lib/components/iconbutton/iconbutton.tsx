

import React from 'react';
import { Themes, ThemeClasses } from '../commons/themes';
import { Sizes } from '../commons/sizes';
import Icon from '../icon/icon';
import { type IconRenderer } from '../icon/iconRenderer';

interface IconButtonProps extends Omit<React.ButtonHTMLAttributes<HTMLButtonElement>, 'children'> {
    /** Nome do ícone (valor de BsIcons ou WellKnownIcons). */
    icon?: string;
    /** Renderer alternativo (IconRenderer) caso queira ícone custom inline. */
    renderer?: IconRenderer;
    /** Tema visual. */
    theme?: Themes;
    /** Escala de tamanho. */
    size?: Sizes;
    /** Variante outline. */
    outline?: boolean;
    /** Estado ativo. */
    active?: boolean;
    /** Desabilitado. */
    disabled?: boolean;
    /** Classe extra. */
    className?: string;
    /** onClick explícito (sobrescreve o herdado) */
    onClick?: React.MouseEventHandler<HTMLButtonElement>;
}

// Resolve a classe de tema usando o mapeamento central ThemeClasses.IconButton
function resolveThemeClass(theme: Themes, outline: boolean, active: boolean): string {

    return outline
        ? active
            ? ThemeClasses.IconButton.Active.Outline[theme]
            : ThemeClasses.IconButton.Outline[theme]
        : active
            ? ThemeClasses.IconButton.Active[theme] as string
            : ThemeClasses.IconButton[theme] as string;
}

export const IconButton: React.FC<IconButtonProps> = ({
    icon,
    renderer,
    theme = Themes.Primary,
    size = Sizes.Medium,
    outline = false,
    active = false,
    disabled = false,
    className = '',
    onClick,
    ...rest
}) => {
    // Validação: exigir exatamente UMA fonte de ícone.
    const provided = [!!icon, !!renderer].filter(Boolean).length;
    if (provided === 0) {
        throw new Error('IconButton requer uma das props: icon OU renderer.');
    }
    if (provided > 1) {
        throw new Error('Forneça somente uma das props: icon OU renderer, não ambas.');
    }

    const themeClass = resolveThemeClass(theme, outline, active);
    const sizeClass = ThemeClasses.IconButton.Sizes[size];
    const baseClass = ThemeClasses.IconButton.Base;
    const disabledClass = disabled ? ThemeClasses.IconButton.Disabled : '';
    const classes = [className, themeClass, sizeClass, baseClass, disabledClass].filter(Boolean).join(' ');

    // Gerar conteúdo do ícone:
    let iconElement: React.ReactNode = null;
    if (renderer) {
        // Renderer recebe (className, restAttr). Para IconButton não precisamos passar attrs extras.
        iconElement = renderer(className, rest as React.HTMLAttributes<HTMLElement>);
    } else if (icon) {
        iconElement = <Icon name={icon} aria-hidden="true" />;
    }

    return (
        <button
            type="button"
            disabled={disabled}
            className={classes}
            aria-label={rest['aria-label'] || icon || 'icon button'}
            onClick={onClick}
            {...rest}
        >
            {iconElement}
        </button>
    );
};

export default IconButton;