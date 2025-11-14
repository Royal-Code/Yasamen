import type { Sides } from "./sides";

/**
 * Spacing options for components. Includes none, initial, and numeric spacings from one to sixteen.
 */
export type Spacing = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 | 16 | 'initial' | 'none';

export const Spacing = {
    None: 'none' as Spacing,
    Initial: 'initial' as Spacing,
    One: 1 as Spacing,
    Two: 2 as Spacing,
    Three: 3 as Spacing,
    Four: 4 as Spacing,
    Five: 5 as Spacing,
    Six: 6 as Spacing,
    Seven: 7 as Spacing,
    Eight: 8 as Spacing,
    Nine: 9 as Spacing,
    Ten: 10 as Spacing,
    Eleven: 11 as Spacing,
    Twelve: 12 as Spacing,
    Thirteen: 13 as Spacing,
    Fourteen: 14 as Spacing,
    Fifteen: 15 as Spacing,
    Sixteen: 16 as Spacing,
};

// Usar mapped types (Record) evita erro de index signature com union literal.
export type SpacingValuePair = Record<Spacing, string>;

export type SpacingSideMap = Record<Sides, SpacingValuePair>;