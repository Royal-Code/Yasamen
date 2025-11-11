import type { Meta, StoryObj } from '@storybook/react';
// Removed deprecated '@storybook/test' import for SB9. Use action args instead.

import { Header } from './Header';

const meta = {
  title: 'Example/Header',
  component: Header,
  // This component will have an automatically generated Autodocs entry: https://storybook.js.org/docs/writing-docs/autodocs
  tags: ['autodocs'],
  parameters: {
    // More on how to position stories at: https://storybook.js.org/docs/configure/story-layout
    layout: 'fullscreen',
  },
  argTypes: {
    onLogin: { action: 'login' },
    onLogout: { action: 'logout' },
    onCreateAccount: { action: 'createAccount' },
  },
  args: {},
} satisfies Meta<typeof Header>;

export default meta;
type Story = StoryObj<typeof meta>;

export const LoggedIn: Story = {
  args: {
    user: {
      name: 'Jane Doe',
    },
  },
};

export const LoggedOut: Story = {};
