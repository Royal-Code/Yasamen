
export const ContentJustify = {
    Default: 'default',
    Start: 'start',
    StartSafe: 'start-safe',
    End: 'end',
    EndSafe: 'end-safe',
    Center: 'center',
    CenterSafe: 'center-safe',
    Between: 'between',
    Around: 'around',
    Evenly: 'evenly',
    Stretch: 'stretch',
    Baseline: 'baseline',
    Normal: 'normal'
}

export type ContentJustify = typeof ContentJustify[keyof typeof ContentJustify];

export const ItemsJustify = {
    Default: 'default',
    Start: 'start',
    StartSafe: 'start-safe',
    End: 'end',
    EndSafe: 'end-safe',
    Center: 'center',
    CenterSafe: 'center-safe',
    Stretch: 'stretch',
    Normal: 'normal'
}

export type ItemsJustify = typeof ItemsJustify[keyof typeof ItemsJustify];