import type { Meta, StoryObj } from '@storybook/react';

import { Button } from '../../lib/components/button';
import './ButtonStories.css';
import { Themes, Sizes, Positions } from '../../lib/components/commons/';
import { BsIcons } from '../../lib/components/bsicons/bsIcons';

/*
  Centralized component stories pattern:
  - Each component story lives under stories/components/<Component>.stories.tsx
  - Re-export enums or option maps from the design system for argTypes controls.
  - Provide a "Playground" default story plus focused variant stories.
*/

const allThemes = Object.values(Themes);
const allSizes = Object.values(Sizes) as Sizes[];

const meta = {
  title: 'Components/Button',
  component: Button,
  parameters: {
    layout: 'centered',
    docs: {
      description: {
        component: 'Botão base do design system. Suporta tema, tamanho, ícone opcional (antes ou depois), variantes outline/active/disabled/block. Props adicionais: type (button|submit|reset) e navigateTo (navegação interna via react-router). Em Storybook navegação só funciona dentro de um MemoryRouter.'
      }
    }
  },
  tags: ['autodocs', 'stable'],
  argTypes: {
    label: { control: 'text', description: 'Texto exibido no botão' },
    theme: { control: 'select', options: allThemes, description: 'Tema visual (classe base + variantes)' },
    size: { control: 'select', options: allSizes, description: 'Escala de tamanho (padding/font)' },
    outline: { control: 'boolean', description: 'Aplica estilo outline em vez de sólido' },
    active: { control: 'boolean', description: 'Força estado ativo (aria-pressed visual)' },
    block: { control: 'boolean', description: 'Largura total do contêiner pai' },
    disabled: { control: 'boolean', description: 'Desabilita interação e aplica estilo de disabled' },
    icon: { control: 'select', options: ['', BsIcons.Plus, BsIcons.Dash, BsIcons.Gear, BsIcons.CheckCircle, BsIcons.XCircle, BsIcons.Eye], description: 'Nome do ícone (string de BsIcons) ou vazio para nenhum' },
    iconPosition: { control: 'radio', options: [Positions.Start, Positions.End], description: 'Posição do ícone em relação ao texto' },
    type: { control: 'select', options: ['button','submit','reset'], description: 'Atributo type do <button>' },
    navigateTo: { control: 'text', description: 'Path para navegar via useNavigate (deixe vazio em Storybook se não envolver MemoryRouter)' },
    onClick: { action: 'clicked', description: 'Handler de clique (Storybook action)' }
  },
  args: {
    label: 'Button',
    theme: Themes.Primary,
    size: Sizes.Medium,
    outline: false,
    active: false,
    block: false,
    disabled: false,
    icon: '',
    iconPosition: Positions.Start,
    type: 'button',
    navigateTo: ''
  }
} satisfies Meta<typeof Button>;

export default meta;

type Story = StoryObj<typeof meta>;

export const Playground: Story = {};

// Theme variants
export const Primary: Story = { args: { theme: Themes.Primary } };
export const Secondary: Story = { args: { theme: Themes.Secondary } };
export const Tertiary: Story = { args: { theme: Themes.Tertiary } };
export const Info: Story = { args: { theme: Themes.Info } };
export const Highlight: Story = { args: { theme: Themes.Highlight } };
export const Success: Story = { args: { theme: Themes.Success } };
export const Warning: Story = { args: { theme: Themes.Warning } };
export const Alert: Story = { args: { theme: Themes.Alert } };
export const Danger: Story = { args: { theme: Themes.Danger } };
export const Light: Story = { args: { theme: Themes.Light } };
export const Dark: Story = { args: { theme: Themes.Dark } };

// Outline variants
export const OutlinePrimary: Story = { args: { theme: Themes.Primary, outline: true } };
export const OutlineSecondary: Story = { args: { theme: Themes.Secondary, outline: true } };
export const OutlineDanger: Story = { args: { theme: Themes.Danger, outline: true } };

// Active State
export const ActivePrimary: Story = { args: { theme: Themes.Primary, active: true } };
export const ActiveOutlinePrimary: Story = { args: { theme: Themes.Primary, outline: true, active: true } };

// Disabled and Block
export const Disabled: Story = { args: { disabled: true } };
export const Block: Story = { args: { block: true, label: 'Full Width Button' } };

// Icon variants
export const WithStartIcon: Story = { args: { icon: BsIcons.Plus, iconPosition: Positions.Start, label: 'Add Item' } };
export const WithEndIcon: Story = { args: { icon: BsIcons.Dash, iconPosition: Positions.End, label: 'Remove' } };
export const WithGearIcon: Story = { args: { icon: BsIcons.Gear, iconPosition: Positions.Start, label: 'Settings' } };
export const WithEyeIcon: Story = { args: { icon: BsIcons.Eye, iconPosition: Positions.End, label: 'Show' } };
export const WithoutIcon: Story = { args: { icon: '', label: 'No Icon', theme: Themes.Secondary } };

// Showcase multiple icons side-by-side
export const IconShowcase: Story = {
  render: (args) => (
    <div className="ya-story-grid">
      <div className="ya-story-box">
        <Button {...args} icon={BsIcons.Plus} iconPosition={Positions.Start} label="Add" />
        <Button {...args} icon={BsIcons.Dash} iconPosition={Positions.End} label="Remove" />
        <Button {...args} icon={BsIcons.Gear} iconPosition={Positions.Start} label="Settings" />
        <Button {...args} icon={BsIcons.CheckCircle} iconPosition={Positions.Start} label="Confirm" />
        <Button {...args} icon={BsIcons.XCircle} iconPosition={Positions.End} label="Close" />
        <Button {...args} icon={BsIcons.Eye} iconPosition={Positions.End} label="View" />
      </div>
    </div>
  ),
  args: { theme: Themes.Primary, size: Sizes.Medium }
};

// Block showcase: side-by-side comparison inside constrained containers.
export const BlockShowcase: Story = {
  render: (args) => (
    <div className="ya-story-grid">
      <div className="ya-story-box">
        <span className="ya-story-box-label">Normal (inline width)</span>
        <Button {...args} block={false} label="Inline button" />
        <Button {...args} block={false} outline label="Inline outline" />
      </div>
      <div className="ya-story-box">
        <span className="ya-story-box-label">Block (fills wrapper)</span>
        <Button {...args} block label="Block button" />
        <Button {...args} block outline label="Block outline" />
      </div>
      <div className="ya-story-box ya-story-box--wide">
        <span className="ya-story-box-label">Wide container (responsive)</span>
        <Button {...args} block label="Block wide" />
      </div>
    </div>
  ),
  args: { theme: Themes.Primary, size: Sizes.Medium }
};

// Size scale showcase
export const SizesShowcase: Story = {
  render: (args) => (
    <div className="ya-story-sizes-flex">
      {allSizes.map(sz => (
        <Button key={sz} {...args} size={sz} label={`Size: ${sz}`} />
      ))}
    </div>
  ),
  args: { outline: false }
};

// Navegação interna (usa MemoryRouter). Exemplo demonstrativo; submit/reset não relevantes.
export const NavigateExample: Story = {
  render: (args) => (
    <div className="ya-story-nav-example">
      <p className="ya-story-nav-example__hint">Clique para navegar para /dashboard (exemplo). Em ambiente real configure rotas.</p>
      <Button {...args} label="Go to Dashboard" navigateTo="/dashboard" />
    </div>
  ),
  args: { theme: Themes.Primary, size: Sizes.Medium }
};

/*
  Adding a new component story:
  1. Create stories/components/<NewComponent>.stories.tsx
  2. Import the component and its tokens (enums, option objects).
  3. Define meta with consistent title prefix 'Components/'
  4. Provide a Playground story plus semantic variant stories.
  5. Prefer small focused stories over many knobs for docs clarity.
*/
