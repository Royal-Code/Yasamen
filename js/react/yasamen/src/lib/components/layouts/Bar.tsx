import { attachSlots, createSlot, hasContent, pickSlots } from "../../utils";
import { ThemeClasses } from "../commons";


// Define the three slots.
const Start = createSlot('Start');
const Center = createSlot('Center');
const End = createSlot('End');

export interface BarProps extends React.HTMLAttributes<HTMLDivElement> {
    className?: string;
    children?: React.ReactNode
}

/**
 * Mirrors the Razor Bar:
 * - Base classes: ya-bar flex justify-between items-center w-full
 * - Optional extra classes via additionalClasses or className
 * - Renders Start / Center / End only if provided and non-empty
 */
const BarRoot: React.FC<BarProps & { children?: React.ReactNode }> = ({
  children,
  className,
  ...rest
}) => {
  const slots = pickSlots(children, { Start, Center, End });

  const classes = [
    ThemeClasses.Bar.Base,
    className
  ].filter(Boolean).join(' ');

  return (
    <div className={classes} {...rest}>
      {hasContent(slots.Start) && <div className={ThemeClasses.Bar.Start}>{slots.Start}</div>}
      {hasContent(slots.Center) && <div className={ThemeClasses.Bar.Center}>{slots.Center}</div>}
      {hasContent(slots.End) && <div className={ThemeClasses.Bar.End}>{slots.End}</div>}
    </div>
  );
};

/**
 * Attach slot components so usage becomes: <Bar><Bar.Start>...</Bar.Start></Bar>
 */
const Bar = attachSlots(BarRoot, { Start, Center, End });

export default Bar;
