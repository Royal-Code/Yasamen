/** Signature for icon render functions */

export type IconRenderer = (
    className: string | undefined,
    rest: React.HTMLAttributes<HTMLElement>
) => React.ReactElement;


