import { Orientations } from "./orientation";
import { Sizes } from "./sizes";
import { ContentJustify, ItemsJustify } from "./justify";

export const Themes = {
    Primary: 'primary',
    Secondary: 'secondary',
    Tertiary: 'tertiary',
    Info: 'info',
    Highlight: 'highlight',
    Success: 'success',
    Warning: 'warning',
    Alert: 'alert',
    Danger: 'danger',
    Light: 'light',
    Dark: 'dark',
};

export type Themes = typeof Themes[keyof typeof Themes];

// Background color classes keyed by theme
export const BgColors = {
    [Themes.Primary]: 'bg-primary-500',
    [Themes.Secondary]: 'bg-secondary-500',
    [Themes.Tertiary]: 'bg-tertiary-500',
    [Themes.Info]: 'bg-info-500',
    [Themes.Highlight]: 'bg-highlight-500',
    [Themes.Success]: 'bg-success-500',
    [Themes.Warning]: 'bg-warning-500',
    [Themes.Alert]: 'bg-alert-500',
    [Themes.Danger]: 'bg-danger-500',
    [Themes.Light]: 'bg-light-500',
    [Themes.Dark]: 'bg-dark-500',
} as const;

// Text color classes keyed by theme
export const TextColors = {
    [Themes.Primary]: 'text-primary-500',
    [Themes.Secondary]: 'text-secondary-500',
    [Themes.Tertiary]: 'text-tertiary-500',
    [Themes.Info]: 'text-info-500',
    [Themes.Highlight]: 'text-highlight-500',
    [Themes.Success]: 'text-success-500',
    [Themes.Warning]: 'text-warning-500',
    [Themes.Alert]: 'text-alert-500',
    [Themes.Danger]: 'text-danger-500',
    [Themes.Light]: 'text-light-500',
    [Themes.Dark]: 'text-dark-500',
} as const;

// Justify utility classes
export const Justifies = {
    Content: {
        [ContentJustify.Default]: '',
        [ContentJustify.Start]: 'justify-start',
        [ContentJustify.StartSafe]: 'justify-start-safe',
        [ContentJustify.End]: 'justify-end',
        [ContentJustify.EndSafe]: 'justify-end-safe',
        [ContentJustify.Center]: 'justify-center',
        [ContentJustify.CenterSafe]: 'justify-center-safe',
        [ContentJustify.Between]: 'justify-between',
        [ContentJustify.Around]: 'justify-around',
        [ContentJustify.Evenly]: 'justify-evenly',
        [ContentJustify.Stretch]: 'justify-stretch',
        [ContentJustify.Baseline]: 'justify-baseline',
        [ContentJustify.Normal]: 'justify-normal',
    },
    Items: {
        [ItemsJustify.Default]: '',
        [ItemsJustify.Start]: 'justify-items-start',
        [ItemsJustify.StartSafe]: 'justify-items-start-safe',
        [ItemsJustify.End]: 'justify-items-end',
        [ItemsJustify.EndSafe]: 'justify-items-end-safe',
        [ItemsJustify.Center]: 'justify-items-center',
        [ItemsJustify.CenterSafe]: 'justify-items-center-safe',
        [ItemsJustify.Stretch]: 'justify-items-stretch',
        [ItemsJustify.Normal]: 'justify-items-normal',
    }
} as const;

// Button related classes
export const ButtonClasses = {
    Base: 'ya-btn',
    Disabled: 'ya-btn-disabled',
    Block: 'ya-btn-block',
    Close: 'ya-btn-close',
    Sizes: {
        [Sizes.Smallest]: 'ya-btn-2xs',
        [Sizes.Smaller]: 'ya-btn-xs',
        [Sizes.Small]: 'ya-btn-sm',
        [Sizes.Medium]: 'ya-btn-md',
        [Sizes.Large]: 'ya-btn-lg',
        [Sizes.Larger]: 'ya-btn-xl',
        [Sizes.Largest]: 'ya-btn-2xl',
    },
    Active: {
        Outline: {
            [Themes.Primary]: 'ya-btn-primary-outline-active',
            [Themes.Secondary]: 'ya-btn-secondary-outline-active',
            [Themes.Tertiary]: 'ya-btn-tertiary-outline-active',
            [Themes.Info]: 'ya-btn-info-outline-active',
            [Themes.Highlight]: 'ya-btn-highlight-outline-active',
            [Themes.Success]: 'ya-btn-success-outline-active',
            [Themes.Warning]: 'ya-btn-warning-outline-active',
            [Themes.Alert]: 'ya-btn-alert-outline-active',
            [Themes.Danger]: 'ya-btn-danger-outline-active',
            [Themes.Light]: 'ya-btn-light-outline-active',
            [Themes.Dark]: 'ya-btn-dark-outline-active',
        },
        [Themes.Primary]: 'ya-btn-primary-active',
        [Themes.Secondary]: 'ya-btn-secondary-active',
        [Themes.Tertiary]: 'ya-btn-tertiary-active',
        [Themes.Info]: 'ya-btn-info-active',
        [Themes.Highlight]: 'ya-btn-highlight-active',
        [Themes.Success]: 'ya-btn-success-active',
        [Themes.Warning]: 'ya-btn-warning-active',
        [Themes.Alert]: 'ya-btn-alert-active',
        [Themes.Danger]: 'ya-btn-danger-active',
        [Themes.Light]: 'ya-btn-light-active',
        [Themes.Dark]: 'ya-btn-dark-active',
    },
    Outline: {
        [Themes.Primary]: 'ya-btn-primary-outline',
        [Themes.Secondary]: 'ya-btn-secondary-outline',
        [Themes.Tertiary]: 'ya-btn-tertiary-outline',
        [Themes.Info]: 'ya-btn-info-outline',
        [Themes.Highlight]: 'ya-btn-highlight-outline',
        [Themes.Success]: 'ya-btn-success-outline',
        [Themes.Warning]: 'ya-btn-warning-outline',
        [Themes.Alert]: 'ya-btn-alert-outline',
        [Themes.Danger]: 'ya-btn-danger-outline',
        [Themes.Light]: 'ya-btn-light-outline',
        [Themes.Dark]: 'ya-btn-dark-outline',
    },
    [Themes.Primary]: 'ya-btn-primary',
    [Themes.Secondary]: 'ya-btn-secondary',
    [Themes.Tertiary]: 'ya-btn-tertiary',
    [Themes.Info]: 'ya-btn-info',
    [Themes.Highlight]: 'ya-btn-highlight',
    [Themes.Success]: 'ya-btn-success',
    [Themes.Warning]: 'ya-btn-warning',
    [Themes.Alert]: 'ya-btn-alert',
    [Themes.Danger]: 'ya-btn-danger',
    [Themes.Light]: 'ya-btn-light',
    [Themes.Dark]: 'ya-btn-dark',
} as const;

// IconButton related classes
export const IconButtonClasses = {
    Base: 'ya-i-btn',
    Disabled: 'ya-btn-disabled',
    Sizes: {
        [Sizes.Smallest]: 'ya-i-btn-2xs',
        [Sizes.Smaller]: 'ya-i-btn-xs',
        [Sizes.Small]: 'ya-i-btn-sm',
        [Sizes.Medium]: 'ya-i-btn-md',
        [Sizes.Large]: 'ya-i-btn-lg',
        [Sizes.Larger]: 'ya-i-btn-xl',
        [Sizes.Largest]: 'ya-i-btn-2xl',
    },
    Active: {
        Outline: {
            [Themes.Primary]: 'ya-i-btn-primary-outline-active',
            [Themes.Secondary]: 'ya-i-btn-secondary-outline-active',
            [Themes.Tertiary]: 'ya-i-btn-tertiary-outline-active',
            [Themes.Info]: 'ya-i-btn-info-outline-active',
            [Themes.Highlight]: 'ya-i-btn-highlight-outline-active',
            [Themes.Success]: 'ya-i-btn-success-outline-active',
            [Themes.Warning]: 'ya-i-btn-warning-outline-active',
            [Themes.Alert]: 'ya-i-btn-alert-outline-active',
            [Themes.Danger]: 'ya-i-btn-danger-outline-active',
            [Themes.Light]: 'ya-i-btn-light-outline-active',
            [Themes.Dark]: 'ya-i-btn-dark-outline-active',
        },
        [Themes.Primary]: 'ya-i-btn-primary-active',
        [Themes.Secondary]: 'ya-i-btn-secondary-active',
        [Themes.Tertiary]: 'ya-i-btn-tertiary-active',
        [Themes.Info]: 'ya-i-btn-info-active',
        [Themes.Highlight]: 'ya-i-btn-highlight-active',
        [Themes.Success]: 'ya-i-btn-success-active',
        [Themes.Warning]: 'ya-i-btn-warning-active',
        [Themes.Alert]: 'ya-i-btn-alert-active',
        [Themes.Danger]: 'ya-i-btn-danger-active',
        [Themes.Light]: 'ya-i-btn-light-active',
        [Themes.Dark]: 'ya-i-btn-dark-active',
    },
    Outline: {
        [Themes.Primary]: 'ya-i-btn-primary-outline',
        [Themes.Secondary]: 'ya-i-btn-secondary-outline',
        [Themes.Tertiary]: 'ya-i-btn-tertiary-outline',
        [Themes.Info]: 'ya-i-btn-info-outline',
        [Themes.Highlight]: 'ya-i-btn-highlight-outline',
        [Themes.Success]: 'ya-i-btn-success-outline',
        [Themes.Warning]: 'ya-i-btn-warning-outline',
        [Themes.Alert]: 'ya-i-btn-alert-outline',
        [Themes.Danger]: 'ya-i-btn-danger-outline',
        [Themes.Light]: 'ya-i-btn-light-outline',
        [Themes.Dark]: 'ya-i-btn-dark-outline',
    },
    [Themes.Primary]: 'ya-i-btn-primary',
    [Themes.Secondary]: 'ya-i-btn-secondary',
    [Themes.Tertiary]: 'ya-i-btn-tertiary',
    [Themes.Info]: 'ya-i-btn-info',
    [Themes.Highlight]: 'ya-i-btn-highlight',
    [Themes.Success]: 'ya-i-btn-success',
    [Themes.Warning]: 'ya-i-btn-warning',
    [Themes.Alert]: 'ya-i-btn-alert',
    [Themes.Danger]: 'ya-i-btn-danger',
    [Themes.Light]: 'ya-i-btn-light',
    [Themes.Dark]: 'ya-i-btn-dark',
} as const;

// Ripple related classes
export const RippleClasses = {
    Base: 'ya-ripple',
    Animation: 'ya-ripple-animation',
    Light: 'bg-white/50',
    Dark: 'bg-black/30',
} as const;

// Stack related classes
export const StackClasses = {
    Base: 'ya-stack',
    Orientation: {
        [Orientations.Vertical]: 'ya-stack-vertical',
        [Orientations.Horizontal]: 'ya-stack-horizontal',
    },
    Gap: {
        [Sizes.Smallest]: 'ya-stack-gap-2xs',
        [Sizes.Smaller]: 'ya-stack-gap-xs',
        [Sizes.Small]: 'ya-stack-gap-sm',
        [Sizes.Medium]: 'ya-stack-gap-md',
        [Sizes.Large]: 'ya-stack-gap-lg',
        [Sizes.Larger]: 'ya-stack-gap-xl',
        [Sizes.Largest]: 'ya-stack-gap-2xl',
    }
} as const;

// Bar related classes
export const BarClasses = {
    Base: 'ya-bar',
    Start: 'ya-bar-start',
    Center: 'ya-bar-center',
    End: 'ya-bar-end',
} as const;

export const StatusClasses = {
    Base: 'ya-status',
    Code: 'ya-status-code',
    Message: 'ya-status-message',
    Content: 'ya-status-content',
} as const;

// Types for external usage if needed
export type BgColorsMap = typeof BgColors;
export type TextColorsMap = typeof TextColors;
export type JustifiesMap = typeof Justifies;
export type ButtonClassesMap = typeof ButtonClasses;
export type IconButtonClassesMap = typeof IconButtonClasses;
export type RippleClassesMap = typeof RippleClasses;
export type StackClassesMap = typeof StackClasses;
export type BarClassesMap = typeof BarClasses;
export type StatusClassesMap = typeof StatusClasses;

