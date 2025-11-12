
export const Orientations = {
    Horizontal: 'horizontal',
    Vertical: 'vertical',
}

export type Orientations = typeof Orientations[keyof typeof Orientations];