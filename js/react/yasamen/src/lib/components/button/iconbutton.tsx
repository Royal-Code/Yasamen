import React from 'react';
import { Themes, IconButtonClasses, Sizes, getNavigator, Ripple } from '../commons';
import { Icon } from '../icon';
import { type IconRenderer } from '../icon/factory/icon-renderer';

export interface IconButtonProps extends Omit<React.ButtonHTMLAttributes<HTMLButtonElement>, 'children'> {
    /** Nome do ícone (valor de BsIcons ou WellKnownIcons). */
    icon?: string;
    /** Renderer alternativo (IconRenderer) caso queira ícone custom inline. */
    renderer?: IconRenderer;
    /** Classe extra para o ícone. */
    iconClassName?: string;
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
    /** Navegar para URL ao clicar */
    navigateTo?: string;
    /** Rótulo acessível explícito para leitores de tela */
    ariaLabel?: string;
}

// Resolve a classe de tema usando o mapeamento central IconButtonClasses
function resolveThemeClass(theme: Themes, outline: boolean, active: boolean): string {

    return outline
        ? active
            ? IconButtonClasses.Active.Outline[theme]
            : IconButtonClasses.Outline[theme]
        : active
            ? IconButtonClasses.Active[theme] as string
            : IconButtonClasses[theme] as string;
}

const IconButton: React.FC<IconButtonProps> = ({
    icon,
    renderer,
    iconClassName,
    theme = Themes.Primary,
    size = Sizes.Medium,
    outline = false,
    active = false,
    disabled = false,
    className = '',
    onClick,
    navigateTo,
    ariaLabel,
    type = 'button',
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
    const sizeClass = IconButtonClasses.Sizes[size];
    const baseClass = IconButtonClasses.Base;
    const disabledClass = disabled ? IconButtonClasses.Disabled : '';
    const classes = [className, themeClass, sizeClass, baseClass, disabledClass].filter(Boolean).join(' ');

    // Gerar conteúdo do ícone:
    let iconElement: React.ReactNode = null;
    if (renderer) {
        // Renderer recebe (className, restAttr). Para IconButton não precisamos passar attrs extras.
        iconElement = renderer(iconClassName, rest as React.HTMLAttributes<HTMLElement>);
    } else if (icon) {
        iconElement = <Icon name={icon} className={iconClassName} aria-hidden="true" />;
    }

    const handleClick: React.MouseEventHandler<HTMLButtonElement> = (e) => {
        if (disabled) {
            e.preventDefault();
            return;
        }
        if (onClick) {
            onClick(e);
        }
        if (navigateTo) {
            e.preventDefault();
            getNavigator().navigate(navigateTo);
        }
    };

    const computedAriaLabel = ariaLabel || icon || undefined;

    return (
        <button
            type={type}
            disabled={disabled}
            className={classes}
            aria-label={computedAriaLabel}
            onClick={handleClick}
            {...rest}
        >
            {iconElement}
            <Ripple dark={true} />
        </button>
    );
};

export default IconButton;