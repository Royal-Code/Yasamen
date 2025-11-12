import { Sizes } from "../commons";
import { LayoutSizes } from "./layout-sizes";
import { LayoutTypes  } from "./layout-types";
import { LayoutClasses } from "./layout-classes";
import { LayoutContext } from "./layout-context";

export interface ContainerProps extends React.HTMLAttributes<HTMLDivElement> {
    /** Layout type */
    type?: LayoutTypes;
    /** Layout size */
    size?: LayoutSizes;
    /** Layout height */
    height?: Sizes;
    /** additional CSS class */
    className?: string;
    /** child content */
    children?: React.ReactNode;
}

const Container: React.FC<ContainerProps> = ({
    type = LayoutTypes.Grid,
    size = LayoutSizes.Auto,
    height = Sizes.Medium,
    className = '',
    children,
    ...rest
}) => {

    let classes = '';

    if (type == LayoutTypes.Grid) {
        const baseClasse = LayoutClasses.Base.Container;
        const gridBaseClass = LayoutClasses.Grid.Base;
        const sizeClass = LayoutClasses.Grid.Container[size];

        classes = [className, baseClasse, gridBaseClass, sizeClass].filter(Boolean).join(' ');
    } else {
        const baseClasse = LayoutClasses.Base.Container;
        const flexClasses = LayoutClasses.Flex.Container;

        classes = [className, baseClasse, flexClasses].filter(Boolean).join(' ');
    }

    const contextValue = { type, size, height };

    return (
        <LayoutContext.Provider value={contextValue}>
            <div className={classes} {...rest}>
                {children}
            </div>
        </LayoutContext.Provider>
    );
}

export default Container;