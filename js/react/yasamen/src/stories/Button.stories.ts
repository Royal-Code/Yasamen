import type { Meta, StoryObj } from '@storybook/react';
import { fn } from '@storybook/test';

import Button from '../lib/components/button/button';
import { Themes } from '../lib/components/commons/themes';
import { Sizes } from '../lib/components/commons/sizes';

// More on how to set up stories at: https://storybook.js.org/docs/writing-stories#default-export
const meta = {
  title: 'Example/Button',
  component: Button,
  parameters: {
    // Optional parameter to center the component in the Canvas. More info: https://storybook.js.org/docs/configure/story-layout
    layout: 'centered',
  },
  // This component will have an automatically generated Autodocs entry: https://storybook.js.org/docs/writing-docs/autodocs
  tags: ['autodocs'],
  // More on argTypes: https://storybook.js.org/docs/api/argtypes
  argTypes: {
    theme: { control: 'select', options: Object.values(Themes) },
    size: { control: 'select', options: Object.values(Sizes) },
  },
  // Use `fn` to spy on the onClick arg, which will appear in the actions panel once invoked: https://storybook.js.org/docs/essentials/actions#action-args
  args: { onClick: fn() },
} satisfies Meta<typeof Button>;

export default meta;
type Story = StoryObj<typeof meta>;

// More on writing stories with args: https://storybook.js.org/docs/writing-stories/args
export const Primary: Story = {
  args: {
    label: 'Button',
    theme: Themes.Primary,
    size: Sizes.Medium,
    outline: false,
  },
};

export const Secondary: Story = {
  args: {
    label: 'Button',
    theme: Themes.Secondary,
  },
};

export const Large: Story = {
  args: {
    size: Sizes.Large,
    label: 'Button',
  },
};

export const Small: Story = {
  args: {
    size: Sizes.Small,
    label: 'Button',
  },
};
