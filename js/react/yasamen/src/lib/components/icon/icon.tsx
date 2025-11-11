import React from 'react';
import { WellKnownIcons } from './wellKnownIcons';
import { getIconRenderer } from './factory/iconRegistry';

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
	return getIconRenderer(name)(className, rest);
};

export default Icon;
