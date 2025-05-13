import React from 'react';
import { Themes, ThemeClasses } from '../commons/themes';
import { Sizes } from '../commons/size';

interface ButtonProps {
    label: string;
    theme?: Themes;
    size?: Sizes;
    outline?: boolean;
    onClick: () => void;
    disabled?: boolean;
    className?: string;
}

const Button: React.FC<ButtonProps> = (
{
    label,
    theme = Themes.Primary,
    size = Sizes.Medium,
    outline = false,
    onClick,
    disabled = false,
    className = ''
}) => {

    const themeClass = outline ? ThemeClasses.Button.Outline[theme] : ThemeClasses.Button[theme];
    const sizeClass = ThemeClasses.Button.Sizes[size];
    const baseClass = ThemeClasses.Button.Base;
    const disabledClass = disabled ? ThemeClasses.Button.Disabled : '';
    
    return (
        <button
            onClick={onClick}
            disabled={disabled}
            className={`${className} ${themeClass} ${baseClass} ${sizeClass} ${disabledClass}`}
        >
            {label}
        </button>
    );
};

export default Button;