import React from "react";
import type { OutletProps } from "./outlet-props";
import { useSectionSystem } from "./section-context";

const SectionOutlet: React.FC<OutletProps> = ({ id }) => {
    const { state } = useSectionSystem();
    if (!id) 
        return null; // Sem id definido, não há como resolver
    const stack = state[id];
    const top = stack && stack.length > 0 ? stack[stack.length - 1].node : null;
    return <>{top}</>;
};

export default SectionOutlet;