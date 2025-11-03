export const Sizes = {
    Smallest: 'smallest',
    Smaller: 'smaller',
    Small: 'small',
    Medium: 'medium',
    Large: 'large',
    Larger: 'larger',
    Largest: 'largest',
}

export type Sizes = typeof Sizes[keyof typeof Sizes];