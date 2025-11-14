import { attachSlots, createSlot, hasContent, pickSlots } from "../../../utils";
import { Heights, Paddings, Sides } from "../../commons";
import type { Spacing } from "../../commons/spacing";

export interface AppLayoutProps extends React.HTMLAttributes<HTMLDivElement> {
    /** Tamanho do espaço superior */
    topSize?: Spacing;
    /** Tamanho do espaço do rodapé */
    footerSize?: Spacing;
    /** Tamanho do menu lateral esquerdo */
    leftMenuSize?: Spacing;
    /** Tamanho do menu lateral direito */
    rightMenuSize?: Spacing;

    /** Conteúdo principal do layout */
    children: React.ReactNode;
    /** Classe CSS extra para o contêiner raiz */
    className?: string;
}

// define slots internos
const Top = createSlot('Top');
const Footer = createSlot('Footer');
const LeftMenu = createSlot('LeftMenu');
const RightMenu = createSlot('RightMenu');
const PreContent = createSlot('Pre');
const PostContent = createSlot('Post');
const MainContent = createSlot('Main');

const AppLayoutRoot : React.FC<AppLayoutProps> = ({
    topSize = 9,
    footerSize = 9,
    leftMenuSize = 9,
    rightMenuSize = 9,
    children,
    className,
    ...rest
}) => {
    
    const slots = pickSlots(children, { Top, Footer, LeftMenu, RightMenu, PreContent, MainContent, PostContent });

    // construir classes CSS com base nos tamanhos fornecidos
    const containerClasses = [
        'ya-app-layout',
        className
    ].filter(Boolean).join(' ');

    const headerClasses = ['ya-app-layout-header', Heights[topSize]].join(' ');
    const pageClasses = ['ya-app-layout-page', Paddings[Sides.Top][topSize]].join(' ');
    const contentClasses = ['ya-app-content'].join(' ');
    const mainClasses = ['ya-app-main'].join(' ');
    const footerClasses = ['ya-app-layout-footer', Heights[footerSize]].join(' ');
    const leftMenuClasses = ['ya-app-layout-left-menu', Paddings[Sides.Left][leftMenuSize]].join(' ');
    const rightMenuClasses = ['ya-app-layout-right-menu', Paddings[Sides.Right][rightMenuSize]].join(' ');

    return (
        <div {...rest} className={containerClasses}>
            <header className={headerClasses}>
                {hasContent(slots.Top) && slots.Top}
            </header>
            <div className={pageClasses}>
                {hasContent(slots.LeftMenu) && <aside className={leftMenuClasses}>{slots.LeftMenu}</aside>}
                <div className={contentClasses}>
                    <main className={mainClasses}>
                        {hasContent(slots.MainContent) && slots.MainContent}
                    </main>
                    <footer className={footerClasses}>
                        {hasContent(slots.Footer) && slots.Footer}
                    </footer>
                </div>
                {hasContent(slots.RightMenu) && <aside className={rightMenuClasses}>{slots.RightMenu}</aside>}
            </div>
        </div>
    );
};

const AppLayout = attachSlots(AppLayoutRoot, { Top, Footer, LeftMenu, RightMenu, PreContent, MainContent, PostContent });

export default AppLayout;