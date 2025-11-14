import { attachSlots, createSlot, hasContent, pickSlots } from "../../../utils";
import { Heights, Paddings, Sides, Widths } from "../../commons";
import type { Spacing } from "../../commons/spacing";
import { AppLayoutClasses } from "./app-layout-classes";

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
        AppLayoutClasses.Base,
        className
    ].filter(Boolean).join(' ');

    const hasLeftMenu = hasContent(slots.LeftMenu);
    const hasRightMenu = hasContent(slots.RightMenu);

    const headerClasses = [AppLayoutClasses.Header, Heights[topSize]].join(' ');
    const pageClasses = [AppLayoutClasses.Page, Paddings[Sides.Top][topSize]].join(' ');
    const contentClasses = [(hasLeftMenu && Paddings[Sides.Left][leftMenuSize]), (hasRightMenu && Paddings[Sides.Right][rightMenuSize]), AppLayoutClasses.Content].join(' ');
    const mainClasses = [AppLayoutClasses.Main].join(' ');
    const footerClasses = [AppLayoutClasses.Footer, Heights[footerSize]].join(' ');
    const leftMenuClasses = [AppLayoutClasses.LeftMenu, Widths[leftMenuSize], Paddings[Sides.Top][topSize]].join(' ');
    const rightMenuClasses = [AppLayoutClasses.RightMenu, Widths[rightMenuSize], Paddings[Sides.Top][topSize]].join(' ');

    return (
        <>
            {hasContent(slots.PreContent) && slots.PreContent}
            <div {...rest} className={containerClasses}>
                <header className={headerClasses}>
                    {hasContent(slots.Top) && slots.Top}
                </header>
                <div className={pageClasses}>
                    {hasLeftMenu && <aside className={leftMenuClasses}>{slots.LeftMenu}</aside>}
                    <div className={contentClasses}>
                        <main className={mainClasses}>
                            {hasContent(slots.MainContent) && slots.MainContent}
                        </main>
                        <footer className={footerClasses}>
                            {hasContent(slots.Footer) && slots.Footer}
                        </footer>
                    </div>
                    {hasRightMenu && <aside className={rightMenuClasses}>{slots.RightMenu}</aside>}
                </div>
            </div>
            {hasContent(slots.PostContent) && slots.PostContent}
        </>
    );
};

const AppLayout = attachSlots(AppLayoutRoot, { Top, Footer, LeftMenu, RightMenu, PreContent, MainContent, PostContent });

export default AppLayout;