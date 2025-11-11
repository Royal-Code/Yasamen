import type { IconRenderer } from "./iconRenderer";

export type IconFactory = (name: string) => IconRenderer | null;
