export const LayoutSizes = {
    /** Default layout size. All devices. Up to 16 cols */
    Auto: 'auto',
    /** Small devices. e.g., phones. 4 cols. */
    Phone: 'phone',
    /** Medium devices. e.g., tablets. 8 cols. */
    Tablet: 'tablet',
    /** Large devices. e.g., laptops. 12 cols. */
    Laptop: 'laptop',
    /** Extra large devices. e.g., desktops. 16 cols. */
    Desktop: 'desktop'
}

export type LayoutSizes = typeof LayoutSizes[keyof typeof LayoutSizes];