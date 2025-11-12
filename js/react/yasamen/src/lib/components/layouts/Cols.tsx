import { Sizes } from "../commons";
import { LayoutSizes } from "./layout-sizes";
import { LayoutTypes  } from "./layout-types";
import { LayoutClasses } from "./layout-classes";
import { useLayoutContext } from "./layout-context";

export type PhoneSpanValue = 0 | 1 | 2 | 3 | 4;
export type TabletSpanValue = PhoneSpanValue | 5 | 6 | 7 | 8;
export type LaptopSpanValue = TabletSpanValue | 9 | 10 | 11 | 12;
export type DesktopSpanValue = LaptopSpanValue | 13 | 14 | 15 | 16;
export type SpanValue = DesktopSpanValue;

export interface ColProps extends React.HTMLAttributes<HTMLDivElement> {
    /** Span default. Number of columns the component will occupy. Default 4. */
    span?: SpanValue;
    /** Span for tablet devices.  Optional, number of columns the component will occupy on small screens. Default 0. */
    spanTablet?: TabletSpanValue;
    /** Span for laptop devices.  Optional, number of columns the component will occupy on medium screens. Default 0. */
    spanLaptop?: LaptopSpanValue;
    /** Span for desktop devices.  Optional, number of columns the component will occupy on large screens. Default 0. */
    spanDesktop?: DesktopSpanValue;
    /** Component height. When not initialized, uses context height or Medium as default. */
    height?: Sizes;
    /** additional CSS class */
    className?: string;
    /** child content */
    children?: React.ReactNode;
}

const Col: React.FC<React.PropsWithChildren<ColProps>> = ({
    span = 4,
    spanTablet = 0,
    spanLaptop = 0,
    spanDesktop = 0,
    height = Sizes.Medium,
    className = '',
    children,
    ...rest
}) => {

    const { type, size, height: contextHeight } = useLayoutContext();

    const effectiveHeight = height ?? contextHeight ?? Sizes.Medium;
    const heightClass = LayoutClasses.Height[effectiveHeight];

    const autoSpan = span > 0 
        ? span <= 16 
            ? span 
            : 16
        : 4;

    let classes = '';

    if (type === LayoutTypes.Grid) {
        const baseClass = LayoutClasses.Base.Col;
        const spanClass = autoSpan > 0 && autoSpan <= 16 ? LayoutClasses.Grid.Cols[LayoutSizes.Auto][autoSpan] : '';
        const spanTabletClass = spanTablet > 0 && spanTablet <= 8 ? LayoutClasses.Grid.Cols[LayoutSizes.Tablet][spanTablet] : '';
        const spanLaptopClass = spanLaptop > 0 && spanLaptop <= 12 ? LayoutClasses.Grid.Cols[LayoutSizes.Laptop][spanLaptop] : '';
        const spanDesktopClass = spanDesktop > 0 && spanDesktop <= 16 ? LayoutClasses.Grid.Cols[LayoutSizes.Desktop][spanDesktop] : '';
        
        classes = [className, baseClass, spanClass, spanTabletClass, spanLaptopClass, spanDesktopClass, heightClass].filter(Boolean).join(' ');

    } else if (type === LayoutTypes.Flex) {
        const baseClass = LayoutClasses.Base.Col;
        const flexClass = LayoutClasses.Flex.Col;
        const map = LayoutClasses.Flex.Cols[size];
        let flexSpan = autoSpan;
        if (size == LayoutSizes.Phone) {
            flexSpan = autoSpan;
            if (flexSpan > 4) 
                flexSpan = 4;
        } else if (size == LayoutSizes.Tablet) {
            flexSpan = spanTablet > 0 ? spanTablet : autoSpan;
            if (flexSpan > 8)
                flexSpan = 8;
        } else if (size == LayoutSizes.Laptop) {
            flexSpan = spanLaptop > 0 ? spanLaptop : autoSpan;
            if (flexSpan > 12)
                flexSpan = 12;
        } else if (size == LayoutSizes.Desktop) {
            flexSpan = spanDesktop > 0 ? spanDesktop : autoSpan;
        }
        
        const spanClass = map[flexSpan] || '';

        classes = [className, baseClass, flexClass, spanClass, heightClass].filter(Boolean).join(' ');
    }

    return (
        <div className={classes} {...rest}>
            {children}
        </div>
    );
}

export default Col;