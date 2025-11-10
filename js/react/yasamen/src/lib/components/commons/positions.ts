
export const Positions = {
    Start: 'start',
    Center: 'center',
    End: 'end',
}

export type Positions = typeof Positions[keyof typeof Positions];