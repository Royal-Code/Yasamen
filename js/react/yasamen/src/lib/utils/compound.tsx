import React from "react";

/**
 * Creates a plain slot component. It only renders its children.
 * Example: const Start = createSlot('Start');
 */
export function createSlot(name: string) {
  const Slot: React.FC<{ children?: React.ReactNode }> = ({ children }) => <>{children}</>;
  Slot.displayName = `Slot:${name}`;
  return Slot;
}

/** 
 * Attaches slot components so usage becomes: <RootComponent><RootComponent.SlotName>...</RootComponent.SlotName></RootComponent>
 */
export function attachSlots<P, S extends Record<string, SlotComponent>>(
  Root: React.ComponentType<P>,
  slots: S
) {
  return Object.assign(Root, slots) as React.ComponentType<P> & S;
}


type SlotComponent = React.ComponentType<{ children?: React.ReactNode }>;

/**
 * Extracts slot children from all passed children.
 * We compare by direct reference (child.type === slotComponent).
 * Last occurrence wins. Simple and predictable.
 */
export function pickSlots<T extends Record<string, SlotComponent>>(
  children: React.ReactNode,
  slotMap: T
): { [K in keyof T]?: React.ReactNode } {

  const found = {} as { [K in keyof T]?: React.ReactNode };

  React.Children.forEach(children, child => {
    if (!React.isValidElement(child))
       return;
      
    for (const [slotName, slotComp] of Object.entries(slotMap) as [keyof T, SlotComponent][]) {
      if (child.type === slotComp) {
        const element = child as React.ReactElement<{ children?: React.ReactNode }>;
        found[slotName] = element.props.children;
      }
    }
  });

  return found;
}

/**
 * Checks if a React node has content (not null/undefined/false/empty string).
*/
export function hasContent(node: React.ReactNode): boolean {
  if (node === null || node === undefined || node === false) return false;
  if (typeof node === 'string') return node.trim().length > 0;
  if (Array.isArray(node)) return node.some(n => hasContent(n));
  return true;
}
