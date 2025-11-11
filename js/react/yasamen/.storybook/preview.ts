import React from 'react';
import type { Preview } from '@storybook/react';
import { MemoryRouter } from 'react-router-dom';
import { ReactRouterNavigatorProvider } from '../src/lib/utils';

// Global design system styles
import '../src/lib/styles/yasamen.css';

// Initialize icon system (Bootstrap Icons mapping)
import { BootstrapIconsProvider } from '../src/lib/components/bsicons/set-bootstrap-icons';

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
    (Story) => React.createElement(
      MemoryRouter,
      { initialEntries: ['/'] },
      React.createElement(React.Fragment, null,
        React.createElement(BootstrapIconsProvider),
        React.createElement(ReactRouterNavigatorProvider),
        React.createElement(Story)
      )
    )
  ]
};

export default preview;