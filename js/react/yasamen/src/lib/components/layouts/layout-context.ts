import { createContext, useContext } from 'react';
import { LayoutTypes } from './layout-types';
import { LayoutSizes } from './layout-sizes';
import { Sizes } from '../commons';

export interface ContainerContextValue {
  type: LayoutTypes;
  size: LayoutSizes;
  height?: Sizes | null;
}

export const LayoutContext = createContext<ContainerContextValue>({
  type: LayoutTypes.Grid,
  size: LayoutSizes.Auto,
  height: Sizes.Medium,
});

export const useLayoutContext = () => useContext(LayoutContext);