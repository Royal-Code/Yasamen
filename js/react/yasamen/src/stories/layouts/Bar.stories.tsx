import type { Meta, StoryObj } from '@storybook/react';
import './BarStories.css';
import Bar from '../../lib/components/layouts/Bar';

/*
  Padrão de Slots (Compound Component)

  O componente Bar segue um padrão de composição via slots nomeados (<Bar.Start />, <Bar.Center />, <Bar.End />),
  inspirado na versão Razor (Bar.razor) onde os slots eram Start / Middle / End. Na migração para React,
  "Middle" foi renomeado para "Center" para ficar consistente com convenções de layout e utilidades Tailwind.

  Características principais:
  - Os slots são estáticos e definidos por utilidades createSlot + attachSlots.
  - Apenas o último slot de cada tipo fornecido é renderizado (política "último vence").
  - Slots vazios (sem children, null, undefined, string vazia) não são emitidos no DOM.
  - A ordem visual é Start | Center | End dentro de um wrapper com classes base (ya-bar ...).
  - É possível combinar apenas alguns slots: ex. Start + End, ou somente Center.
  - A prop className adiciona classes ao contêiner raiz; cada slot recebe sua própria classe semântica (ya-bar-start, ya-bar-center, ya-bar-end).

  Diferenças frente ao Razor:
  - Naming: Middle -> Center.
  - API React usa composição JSX em vez de parâmetros / RenderFragments.
  - Override: No Razor seria necessário lógica adicional; aqui pickSlots simplesmente mantém o último encontrado.

  Exemplo de Uso Básico:
    <Bar className="p-2 bg-light-100">
      <Bar.Start><Logo /></Bar.Start>
      <Bar.Center><Title /></Bar.Center>
      <Bar.End><UserMenu /></Bar.End>
    </Bar>

  Override (último vence):
    <Bar>
      <Bar.Start>Primeiro</Bar.Start>
      <Bar.Start>Segundo (renderizado)</Bar.Start>
    </Bar>

  Somente um slot:
    <Bar><Bar.End>Ações</Bar.End></Bar>

  A documentação abaixo demonstra cenários de composição, ausência e override.
*/

const meta = {
  title: 'Components/Layout/Bar',
  component: Bar,
  parameters: {
    layout: 'centered',
    docs: {
      description: {
        component: 'Padrão de slots: <Bar.Start />, <Bar.Center /> e <Bar.End />. Similar ao Bar.razor (Start/Middle/End) porém usando Center. Política de override: último slot de mesmo tipo substitui anteriores. Slots sem conteúdo não são renderizados. Use para cabeçalhos, barras de ferramentas ou regiões horizontais com alinhamentos semânticos.'
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
