import Status from './Status';

export interface Status404Props extends React.HTMLAttributes<HTMLDivElement> {
    className?: string;
    children?: React.ReactNode;
}

const Status404: React.FC<Status404Props> = ({
    className = '',
    children,
    ...rest
}) => (
  <Status code={404} message="Página não encontrada." className={className} {...rest}>
    {children}
  </Status>
);

export default Status404;