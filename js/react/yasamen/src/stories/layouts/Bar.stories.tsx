import type { Meta, StoryObj } from '@storybook/react';
import './BarStories.css';
import Bar from '../../lib/components/layouts/Bar';

/*
  Stories para Bar (compound component com slots Start / Center / End).
  Objetivos:
  - Demonstrar composição de slots.
  - Mostrar ausência de slots intermediários.
  - Evidenciar política "último vence" (override).
  - Variantes com classes extras.
  - Visualização opcional dos contornos dos slots.
*/

const meta = {
  title: 'Components/Layout/Bar',
  component: Bar,
  parameters: {
    layout: 'centered',
    docs: {
      description: {
        component: 'Bar expõe três slots: Start, Center e End. Internamente utiliza utilidades createSlot + pickSlots. Se múltiplos slots iguais forem fornecidos, o último prevalece. Slots vazios não são renderizados. Pode receber classes adicionais via className.'
      }
    }
  },
  tags: ['autodocs', 'stable'],
  argTypes: {
    className: { control: 'text', description: 'Classes CSS adicionais aplicadas ao wrapper raiz' },
    children: { control: false, description: 'Composição de slots <Bar.Start/> etc.' }
  },
  args: {
    className: ''
  }
} satisfies Meta<typeof Bar>;

export default meta;
type Story = StoryObj<typeof meta>;

// Playground completo
export const Playground: Story = {
  render: (args) => (
    <div className="ya-bar-frame">
      <div className="ya-bar-demo-block">
        <span className="ya-bar-demo-label">Completo</span>
        <Bar {...args} className={args.className + ' ya-bar-slot-outline'}>
          <Bar.Start><span className="text-xs">Left content</span></Bar.Start>
          <Bar.Center><strong className="text-sm">Center title</strong></Bar.Center>
          <Bar.End><button className="text-xs underline">Action</button></Bar.End>
        </Bar>
      </div>
    </div>
  )
};

// Sem Center
export const WithoutCenter: Story = {
  render: (args) => (
    <div className="ya-bar-frame">
      <div className="ya-bar-demo-block">
        <span className="ya-bar-demo-label">Sem Center</span>
        <Bar {...args} className={args.className + ' ya-bar-slot-outline'}>
          <Bar.Start><span className="text-xs">Only Start</span></Bar.Start>
          <Bar.End><span className="text-xs">Only End</span></Bar.End>
        </Bar>
      </div>
    </div>
  )
};

// Apenas Start
export const OnlyStart: Story = {
  render: (args) => (
    <div className="ya-bar-frame">
      <div className="ya-bar-demo-block">
        <span className="ya-bar-demo-label">Apenas Start</span>
        <Bar {...args} className={args.className + ' ya-bar-slot-outline'}>
          <Bar.Start><span className="text-xs">Single slot</span></Bar.Start>
        </Bar>
      </div>
    </div>
  )
};

// Override (último vence)
export const OverridePolicy: Story = {
  render: (args) => (
    <div className="ya-bar-frame">
      <div className="ya-bar-demo-block">
        <span className="ya-bar-demo-label">Override (último vence)</span>
        <Bar {...args} className={args.className + ' ya-bar-slot-outline'}>
          <Bar.Start><span className="text-xs">First start</span></Bar.Start>
          <Bar.Start><span className="text-xs">Second start overrides</span></Bar.Start>
          <Bar.End><span className="text-xs">First end</span></Bar.End>
          <Bar.End><span className="text-xs">Final end overrides</span></Bar.End>
        </Bar>
      </div>
    </div>
  )
};

// Com classes adicionais
export const WithExtraClasses: Story = {
  args: { className: 'p-2 border rounded-md bg-primary-50' },
  render: (args) => (
    <div className="ya-bar-frame">
      <div className="ya-bar-demo-block">
        <span className="ya-bar-demo-label">Com classes extras</span>
        <Bar {...args} className={args.className + ' ya-bar-slot-outline'}>
          <Bar.Start><span className="text-xs">Extra classes</span></Bar.Start>
          <Bar.Center><span className="text-xs">Center info</span></Bar.Center>
          <Bar.End><span className="text-xs">Done</span></Bar.End>
        </Bar>
      </div>
    </div>
  )
};

// Mix de exemplos em bloco único
export const MixedExamples: Story = {
  render: (args) => (
    <div className="ya-bar-frame">
      <div className="ya-bar-demo-block">
        <span className="ya-bar-demo-label">Múltiplos exemplos</span>
        <div className="space-y-3">
          <Bar {...args} className={args.className + ' ya-bar-slot-outline'}>
            <Bar.Start><span className="text-xs">Left</span></Bar.Start>
            <Bar.Center><span className="text-xs">Center</span></Bar.Center>
            <Bar.End><span className="text-xs">Right</span></Bar.End>
          </Bar>
          <Bar {...args} className={args.className + ' ya-bar-slot-outline'}>
            <Bar.Start><span className="text-xs">Only Start second example</span></Bar.Start>
          </Bar>
          <Bar {...args} className={args.className + ' ya-bar-slot-outline'}>
            <Bar.End><span className="text-xs">Only End third example</span></Bar.End>
          </Bar>
        </div>
      </div>
    </div>
  )
};
