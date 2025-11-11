import type { IconRenderer } from "./icon-renderer";

export type IconFactory = (name: string) => IconRenderer | null;
