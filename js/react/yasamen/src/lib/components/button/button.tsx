import React from 'react';
import { Themes, ThemeClasses } from '../commons/themes';
import { Sizes } from '../commons/sizes';

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
    label: string;
    theme?: Themes;
    size?: Sizes;
    outline?: boolean;
    active?: boolean;
    block?: boolean;
    disabled?: boolean;
    onClick?: React.MouseEventHandler<HTMLButtonElement>;
    className?: string;
}

const Button: React.FC<ButtonProps> = ({
    label,
    theme = Themes.Primary,
    size = Sizes.Medium,
    outline = false,
    active = false,
    block = false,
    onClick,
    disabled = false,
    className = '',
    ...rest
}) => {

    const themeClass = outline
        ? active
            ? ThemeClasses.Button.Active.Outline[theme]
            : ThemeClasses.Button.Outline[theme]
        : active
            ? ThemeClasses.Button.Active[theme]
            : ThemeClasses.Button[theme];
    const sizeClass = ThemeClasses.Button.Sizes[size];
    const baseClass = ThemeClasses.Button.Base;
    const disabledClass = disabled ? ThemeClasses.Button.Disabled : '';
    const blockClass = block ? ThemeClasses.Button.Block : '';

    const classes = [className, themeClass, sizeClass, baseClass, disabledClass, blockClass].filter(Boolean).join(' ');

    return (
        <button
            type="button"
            onClick={onClick}
            disabled={disabled}
            className={classes}
            {...rest}
        >
            {label}
        </button>
    );
};

export default Button;