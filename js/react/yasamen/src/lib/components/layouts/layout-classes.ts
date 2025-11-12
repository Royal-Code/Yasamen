import { Sizes } from "../commons";
import { LayoutSizes } from "./layout-sizes";
import type { NumberValueMap } from '../../utils';

export const LayoutClasses = {
    Base: {
        Container: 'ya-container',
        Col: 'ya-col'
    },
    Grid: {
        Base: 'grid xs:grid-cols-1 gap-8 items-start',
        Container: {
            [LayoutSizes.Auto]: 'grid-cols-4 md:grid-cols-8 lg:grid-cols-12 2xl:grid-cols-16',
            [LayoutSizes.Desktop]: 'grid-cols-4 md:grid-cols-8 lg:grid-cols-12 2xl:grid-cols-16',
            [LayoutSizes.Laptop]: 'sm:grid-cols-4 md:grid-cols-8 lg:grid-cols-12',
            [LayoutSizes.Tablet]: 'sm:grid-cols-4 md:grid-cols-8',
            [LayoutSizes.Phone]: 'sm:grid-cols-4'
        },
        Cols: {
            [LayoutSizes.Auto]: {
                1: 'sm:col-span-1', 
                2: 'sm:col-span-2', 
                3: 'sm:col-span-3', 
                4: 'sm:col-span-4', 
                5: 'sm:col-span-5',
                6: 'sm:col-span-6',
                7: 'sm:col-span-7',
                8: 'sm:col-span-8',
                9: 'sm:col-span-9',
                10: 'sm:col-span-10',
                11: 'sm:col-span-11',
                12: 'sm:col-span-12',
                13: 'sm:col-span-13',
                14: 'sm:col-span-14',
                15: 'sm:col-span-15',
                16: 'sm:col-span-16'
            },
            [LayoutSizes.Tablet]: { 
                1: 'md:col-span-1',
                2: 'md:col-span-2',
                3: 'md:col-span-3',
                4: 'md:col-span-4',
                5: 'md:col-span-5',
                6: 'md:col-span-6',
                7: 'md:col-span-7',
                8: 'md:col-span-8'
            },
            [LayoutSizes.Laptop]: { 
                1: 'lg:col-span-1',
                2: 'lg:col-span-2',
                3: 'lg:col-span-3',
                4: 'lg:col-span-4',
                5: 'lg:col-span-5',
                6: 'lg:col-span-6',
                7: 'lg:col-span-7',
                8: 'lg:col-span-8',
                9: 'lg:col-span-9',
                10: 'lg:col-span-10',
                11: 'lg:col-span-11',
                12: 'lg:col-span-12'
            },
            [LayoutSizes.Desktop]: { 
                1: '2xl:col-span-1',
                2: '2xl:col-span-2',
                3: '2xl:col-span-3',
                4: '2xl:col-span-4',
                5: '2xl:col-span-5',
                6: '2xl:col-span-6',
                7: '2xl:col-span-7',
                8: '2xl:col-span-8',
                9: '2xl:col-span-9',
                10: '2xl:col-span-10',
                11: '2xl:col-span-11',
                12: '2xl:col-span-12',
                13: '2xl:col-span-13',
                14: '2xl:col-span-14',
                15: '2xl:col-span-15',
                16: '2xl:col-span-16'
            }
        } as NumberValueMap
    },
    Flex: {
        Container: 'flex flex-wrap grow justify-start',
        Col: 'flex-initial px-4',
        Cols: {
            [LayoutSizes.Auto]: { 
                1: 'w-1/4 md:w-1/8 lg:w-1/12 2xl:w-1/16',
                2: 'w-2/4 md:w-2/8 lg:w-2/12 2xl:w-2/16',
                3: 'w-3/4 md:w-3/8 lg:w-3/12 2xl:w-3/16',
                4: 'w-full md:w-4/8 lg:w-4/12 2xl:w-4/16',
                5: 'w-full md:w-5/8 lg:w-5/12 2xl:w-5/16',
                6: 'w-full md:w-6/8 lg:w-6/12 2xl:w-6/16',
                7: 'w-full md:w-7/8 lg:w-7/12 2xl:w-7/16',
                8: 'w-full lg:w-8/12 2xl:w-8/16',
                9: 'w-full lg:w-9/12 2xl:w-9/16',
                10: 'w-full lg:w-10/12 2xl:w-10/16',
                11: 'w-full lg:w-11/12 2xl:w-11/16',
                12: 'w-full 2xl:w-12/16',
                13: 'w-full 2xl:w-13/16',
                14: 'w-full 2xl:w-14/16',
                15: 'w-full 2xl:w-15/16',
                16: 'w-full'
            },
            [LayoutSizes.Phone]: { 
                1: 'w-1/4',
                2: 'w-2/4',
                3: 'w-3/4',
                4: 'w-full' 
            },
            [LayoutSizes.Tablet]: { 
                1: 'w-1/4 md:w-1/8',
                2: 'w-2/4 md:w-2/8',
                3: 'w-3/4 md:w-3/8',
                4: 'w-full md:w-4/8',
                5: 'w-full md:w-5/8',
                6: 'w-full md:w-6/8',
                7: 'w-full md:w-7/8',
                8: 'w-full'
            },
            [LayoutSizes.Laptop]: { 
                1: 'w-1/4 md:w-1/8 lg:w-1/12',
                2: 'w-2/4 md:w-2/8 lg:w-2/12',
                3: 'w-3/4 md:w-3/8 lg:w-3/12',
                4: 'w-full md:w-4/8 lg:w-4/12',
                5: 'w-full md:w-5/8 lg:w-5/12',
                6: 'w-full md:w-6/8 lg:w-6/12',
                7: 'w-full md:w-7/8 lg:w-7/12',
                8: 'w-full lg:w-8/12',
                9: 'w-full lg:w-9/12',
                10: 'w-full lg:w-10/12',
                11: 'w-full lg:w-11/12',
                12: 'w-full'
            },
            [LayoutSizes.Desktop]: { 
                1: 'w-1/4 md:w-1/8 lg:w-1/12 2xl:w-1/16',
                2: 'w-2/4 md:w-2/8 lg:w-2/12 2xl:w-2/16',
                3: 'w-3/4 md:w-3/8 lg:w-3/12 2xl:w-3/16',
                4: 'w-full md:w-4/8 lg:w-4/12 2xl:w-4/16',
                5: 'w-full md:w-5/8 lg:w-5/12 2xl:w-5/16',
                6: 'w-full md:w-6/8 lg:w-6/12 2xl:w-6/16',
                7: 'w-full md:w-7/8 lg:w-7/12 2xl:w-7/16',
                8: 'w-full lg:w-8/12 2xl:w-8/16',
                9: 'w-full lg:w-9/12 2xl:w-9/16',
                10: 'w-full lg:w-10/12 2xl:w-10/16',
                11: 'w-full lg:w-11/12 2xl:w-11/16',
                12: 'w-full 2xl:w-12/16',
                13: 'w-full 2xl:w-13/16',
                14: 'w-full 2xl:w-14/16',
                15: 'w-full 2xl:w-15/16',
                16: 'w-full'
            }
        } as NumberValueMap
    },
    Height: {
        [Sizes.Smallest]: 'h-7',
        [Sizes.Smaller]: 'h-8',
        [Sizes.Small]: 'h-9',
        [Sizes.Medium]: 'h-10',
        [Sizes.Large]: 'h-11',
        [Sizes.Larger]: 'h-12',
        [Sizes.Largest]: 'h-13',
    }
}