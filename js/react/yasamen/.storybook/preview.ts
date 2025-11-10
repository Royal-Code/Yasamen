import type { Preview } from '@storybook/react';

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
};

export default preview;