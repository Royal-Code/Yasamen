import React from 'react';
import type { Preview } from '@storybook/react';
import { MemoryRouter } from 'react-router-dom';

// Global design system styles
import '../src/lib/styles/yasamen.css';

// Initialize icon system (Bootstrap Icons mapping)
import { setBootstrapIcons } from '../src/lib/components/bsicons/setBootstrapIcons';
setBootstrapIcons();

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
        <Story />
      </MemoryRouter>
    )
  ]
};

export default preview;