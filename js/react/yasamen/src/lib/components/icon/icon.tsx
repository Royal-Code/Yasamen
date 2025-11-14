import React from 'react';
import { WellKnownIcons } from './well-known-icons';
import { tryGetIconRenderer } from './factory/icon-registry';

interface IconProps extends React.HTMLAttributes<HTMLElement> {
	/** Icon name (well known or custom). */
	name?: string;
	/** Extra class names applied to underlying element */
	className?: string;
}

/** Generic Icon component */
const Icon: React.FC<IconProps> = ({
     name = WellKnownIcons.NoIcon, 
     className, 
     ...rest 
}) => {
	// Usa tryGet para evitar exceptions e renderizar fallback (NoIconRenderer)
	return tryGetIconRenderer(name)(className, rest);
};

export default Icon;
