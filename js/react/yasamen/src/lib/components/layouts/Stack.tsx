
import { ContentJustify, Orientations, Sizes, StackClasses, Justifies } from "../commons";

export interface StackProps extends React.HTMLAttributes<HTMLDivElement> {
    /** Orientation of the stack */
    orientation?: Orientations;
    /** Gap of the stack */
    gap?: Sizes;
    /** Justify content of the stack */
    justify?: ContentJustify;
    /** additional CSS class */
    className?: string;
    /** child content */
    children?: React.ReactNode;
}

const Stack: React.FC<StackProps> = ({
    orientation = Orientations.Vertical,
    gap = Sizes.Medium,
    justify = ContentJustify.Start,
    className = '',
    children,
    ...rest
}) => {
    const orientationClass = StackClasses.Orientation[orientation];
    const gapClass = StackClasses.Gap[gap];
    const justifyClass = Justifies.Content[justify];
    const baseClass = StackClasses.Base;
    
    const classes = [className, orientationClass, gapClass, justifyClass, baseClass].filter(Boolean).join(' ');

    return (
        <div className={classes} {...rest}>
            {children}
        </div>
    );
};

export default Stack;