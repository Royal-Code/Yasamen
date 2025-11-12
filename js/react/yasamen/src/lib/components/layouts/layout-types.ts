
export const LayoutTypes = {
    Grid: 'grid',
    Flex: 'flex',
}

export type LayoutTypes = typeof LayoutTypes[keyof typeof LayoutTypes];