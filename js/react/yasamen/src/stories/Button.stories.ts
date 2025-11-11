import type { Meta, StoryObj } from '@storybook/react';

import Button from '../lib/components/button/button';
import { Themes } from '../lib/components/commons/themes';
import { Sizes } from '../lib/components/commons/sizes';
import { Positions } from '../lib/components/commons/positions';
import { BsIcons } from '../lib/components/bsicons/bsIcons';

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
    icon: { control: 'select', options: ['', ...Object.values(BsIcons)], description: 'Nome de ícone (vazio para nenhum)' },
    iconPosition: { control: 'radio', options: [Positions.Start, Positions.End], description: 'Posição do ícone' },
    onClick: { action: 'clicked' }
  },
  args: {},
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
    icon: '',
    iconPosition: Positions.Start,
  },
};

export const Secondary: Story = {
  args: {
    label: 'Button',
    theme: Themes.Secondary,
    icon: BsIcons.Dash,
    iconPosition: Positions.End,
  },
};

export const Large: Story = {
  args: {
    size: Sizes.Large,
    label: 'Button',
    icon: BsIcons.Gear,
    iconPosition: Positions.Start,
  },
};

export const Small: Story = {
  args: {
    size: Sizes.Small,
    label: 'Button',
    icon: BsIcons.CheckCircle,
    iconPosition: Positions.End,
  },
};

export const IconOnly: Story = {
  args: {
    label: 'Add',
    theme: Themes.Primary,
    icon: BsIcons.PlusCircle,
    iconPosition: Positions.Start,
  },
};

export const WithoutIcon: Story = {
  args: {
    label: 'No Icon',
    theme: Themes.Secondary,
    icon: '',
  },
};
