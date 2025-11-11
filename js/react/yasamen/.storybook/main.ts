import type { StorybookConfig } from '@storybook/react-vite';

// Storybook 10 config adjustments:
// - Explicit docs addon required for MDX & autodocs (split out in SB9+ lean core)
// - staticDirs added to serve public assets (images, fonts)
// - Keep onboarding addon for now (optional; can remove later to slim bundle)
// - Future: consider enabling tags config & module mocking (`sb.mock`) if needed
const config: StorybookConfig = {
  stories: [
    '../src/**/*.mdx',
    '../src/**/*.stories.@(js|jsx|mjs|ts|tsx)'
  ],
  addons: [
    '@storybook/addon-docs',
    '@storybook/addon-onboarding',
    '@chromatic-com/storybook'
  ],
  staticDirs: ['../public'],
  framework: {
    name: '@storybook/react-vite',
    options: {}
  }
};
export default config;