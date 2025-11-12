
import { ContentJustify, Orientations, Sizes, ThemeClasses } from "../commons";

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

export const Stack: React.FC<StackProps> = ({
    orientation = Orientations.Vertical,
    gap = Sizes.Medium,
    justify = ContentJustify.Start,
    className = '',
    children,
    ...rest
}) => {
    const orientationClass = ThemeClasses.Stack.Orientation[orientation];
    const gapClass = ThemeClasses.Stack.Gap[gap];
    const justifyClass = ThemeClasses.Justify.Content[justify];
    const baseClass = ThemeClasses.Stack.Base;
    
    const classes = [className, orientationClass, gapClass, justifyClass, baseClass].filter(Boolean).join(' ');

    return (
        <div className={classes} {...rest}>
            {children}
        </div>
    );
};