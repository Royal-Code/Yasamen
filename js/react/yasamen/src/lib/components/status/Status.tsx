import { hasContent } from "../../utils";

export interface StatusProps extends React.HTMLAttributes<HTMLDivElement> {
    code: number;
    message: string;
    className?: string;
    children?: React.ReactNode;
}

const Status: React.FC<StatusProps> = ({
    code,
    message,
    className = '',
    children,
    ...rest
}) => {
    
    const classes = ['ya-status', className].filter(Boolean).join(' ');

    return (
        <div {...rest} className={classes}>
            <h1 className="ya-status-code">{code}</h1>
            <p className="ya-status-message">{message}</p>
            {hasContent(children) && <div className="ya-status-content">{children}</div>}
        </div>
    );
}

export default Status;