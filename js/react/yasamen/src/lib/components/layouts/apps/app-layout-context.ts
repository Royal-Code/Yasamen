import { createContext, useContext } from "react";
import type { Spacing } from "../../commons";

export interface AppLayoutContextValue {
    /** Tamanho do espaço superior */
    topSize?: Spacing;
    /** Tamanho do espaço do rodapé */
    footerSize?: Spacing;
    /** Tamanho do menu lateral esquerdo */
    leftMenuSize?: Spacing;
    /** Tamanho do menu lateral direito */
    rightMenuSize?: Spacing;
}

export const AppLayoutContext = createContext<AppLayoutContextValue>({
    topSize: 9,
    footerSize: 9,
    leftMenuSize: 9,
    rightMenuSize: 9,
});

export const useAppLayoutContext = () => useContext(AppLayoutContext);