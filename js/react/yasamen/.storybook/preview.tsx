import React from 'react';
import type { Preview } from '@storybook/react';
import { MemoryRouter } from 'react-router-dom';
import { ReactRouterNavigatorProvider } from '../src/lib/utils';

// Global design system styles
import '../src/lib/styles/yasamen.css';

import { BootstrapIconsProvider } from '../src/lib/components/bsicons/setBootstrapIcons';

const preview: Preview = {
  parameters: {
    layout: 'centered',
    controls: {
      matchers: {
        color: /(background|color)$/i,
        date: /Date$/i,
      },
    },
  },
  decorators: [
    (Story) => (
      <MemoryRouter initialEntries={['/']}>
        <BootstrapIconsProvider />
        <ReactRouterNavigatorProvider />
        <Story />
      </MemoryRouter>
    )
  ]
};

export default preview;