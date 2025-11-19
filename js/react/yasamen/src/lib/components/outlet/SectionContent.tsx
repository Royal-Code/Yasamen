import React from "react";
import type { OutletProps } from "./outlet-props";
import { useSectionSystem } from "./section-context";

interface SectionContentProps extends OutletProps {
    children: React.ReactNode;
}

const SectionContent: React.FC<SectionContentProps> = ({ id, children }) => {
    const { mount, update, unmount } = useSectionSystem();
    const instanceRef = React.useRef<symbol | null>(null);

    // Mount / Unmount lifecycle
    React.useEffect(() => {
        if (!id) 
            return; // Sem id não registra
        const inst = mount(id, children);
        instanceRef.current = inst;
        return () => {
            unmount(inst, id);
        };
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [id]);

    // Atualiza o conteúdo quando muda
    React.useEffect(() => {
        const inst = instanceRef.current;
        if (!inst || !id) 
            return;
        update(inst, id, children);
    }, [children, id, update]);

    // Não renderiza nada localmente; conteúdo é exibido pelo SectionOutlet
    return null;
};

export default SectionContent;