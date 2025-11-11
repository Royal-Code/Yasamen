import React from 'react';
import { Themes, ThemeClasses, Sizes, Positions, getNavigator } from '../commons';
import Icon from '../icon/icon';

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
    label: string;
    theme?: Themes;
    size?: Sizes;
    outline?: boolean;
    active?: boolean;
    icon?: string;
    iconPosition?: Positions;
    block?: boolean;
    disabled?: boolean;
    onClick?: React.MouseEventHandler<HTMLButtonElement>;
    navigateTo?: string;
    className?: string;
}

const Button: React.FC<ButtonProps> = ({
    label,
    theme = Themes.Primary,
    size = Sizes.Medium,
    outline = false,
    active = false,
    icon,
    iconPosition = Positions.Start,
    block = false,
    disabled = false,
    onClick,
    navigateTo,
    className = '',
    type = 'button',
    ...rest
}) => {

    // validate position, must be start or end, center is not valid for button icon position
    if (iconPosition === Positions.Center) {
        throw new Error('Invalid iconPosition "center" for Button component. Use "start" or "end".');
    }

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

    return (
        <button
            type={type}
            onClick={handleClick}
            disabled={disabled}
            className={classes}
            {...rest}
        >
            {icon && iconPosition === Positions.Start && <Icon name={icon} className='mr-3' aria-hidden="true"></Icon>}
            {label}
            {icon && iconPosition === Positions.End && <Icon name={icon} className='ml-3' aria-hidden="true"></Icon>}
        </button>
    );
};

export default Button;