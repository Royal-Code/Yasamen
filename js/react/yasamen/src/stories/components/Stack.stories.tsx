import type { Meta, StoryObj } from '@storybook/react';
import { Stack } from '../../lib/components/layouts/Stack';
import { Orientations, Sizes, ContentJustify } from '../../lib/components/commons';
import './StackStories.css';

/*
  Stories for Stack layout component.
  - Exibe orientação (horizontal/vertical), gaps, e justify-items.
  - Cada exemplo aplica borda primary-300 e fundo primary-100 conforme pedido.
  - Elementos filhos usam tema highlight.
  - Vertical ocupa 100% da altura do container; fornecemos wrapper com altura fixa para visualização.
  - Inclui exemplos com overflow (muitos filhos) horizontal e vertical.
*/

const allOrientations = Object.values(Orientations);
const allGaps = Object.values(Sizes) as Sizes[];
const allJustify = Object.values(ContentJustify);

// Helper para gerar filhos padrão
const makeChildren = (count: number) => Array.from({ length: count }, (_, i) => (
  <div key={i} className="ya-stack-demo-item p-2 bg-highlight-500 text-light-100 rounded-sm font-semibold shadow-sm flex items-center justify-center">
    Item {i + 1}
  </div>
));

const meta = {
  title: 'Components/Stack',
  component: Stack,
  parameters: {
    layout: 'centered',
    docs: {
      description: {
        component: 'Stack organiza elementos em linha ou coluna, aplicando gap e justify-items. Vertical ocupa 100% da altura do wrapper; horizontal ocupa 100% da largura. As classes vêm de ThemeClasses.Stack. Use para compor layouts simples.'
      }
    }
  },
  tags: ['autodocs', 'stable'],
  argTypes: {
    orientation: { control: 'select', options: allOrientations, description: 'Orientação dos itens (horizontal ou vertical)' },
    gap: { control: 'select', options: allGaps, description: 'Espaçamento (gap) entre itens' },
  justify: { control: 'select', options: allJustify, description: 'Justificação do conteúdo (flex justify content semantic)' },
    children: { control: false, description: 'Elementos filhos dentro da Stack' },
    className: { control: 'text', description: 'Classes CSS adicionais' }
  },
  args: {
    orientation: Orientations.Horizontal,
    gap: Sizes.Medium,
  justify: ContentJustify.Start,
    children: makeChildren(3)
  }
} satisfies Meta<typeof Stack>;

export default meta;
type Story = StoryObj<typeof meta>;

// Playground base
export const Playground: Story = {
  render: (args) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container">
        <Stack {...args} />
      </div>
    </div>
  )
};

// Orientações
export const Horizontal: Story = {
  args: { orientation: Orientations.Horizontal },
  render: (args) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container">
        <Stack {...args} />
      </div>
    </div>
  )
};

export const Vertical: Story = {
  args: { orientation: Orientations.Vertical },
  render: (args) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container ya-stack-demo-vertical-240">
        <Stack {...args} />
      </div>
    </div>
  )
};

// Showcase de gaps
export const GapShowcase: Story = {
  render: (args) => (
    <div className="ya-stack-frame ya-stack-gap-showcase">
      {allGaps.map(g => (
        <div key={g} className="ya-stack-demo-container">
          <span className="ya-stack-demo-label">gap: {g}</span>
          <Stack {...args} gap={g}>
            {makeChildren(3)}
          </Stack>
        </div>
      ))}
    </div>
  ),
  args: { orientation: Orientations.Horizontal }
};

// Justify variantes (horizontal)
export const JustifyHorizontalVariants: Story = {
  render: (args) => (
    <div className="ya-stack-frame ya-stack-justify-showcase">
      {allJustify.map(j => (
        <div key={j} className="ya-stack-demo-container">
          <span className="ya-stack-demo-label">justify: {j || 'default'}</span>
          <Stack {...args} justify={j as ContentJustify}>
            {makeChildren(3)}
          </Stack>
        </div>
      ))}
    </div>
  ),
  args: { orientation: Orientations.Horizontal }
};

// Justify variantes (vertical)
export const JustifyVerticalVariants: Story = {
  render: (args) => (
    <div className="ya-stack-frame ya-stack-justify-showcase ya-stack-justify-showcase-demo-vertical">
      {allJustify.map(j => (
        <div key={j} className="ya-stack-demo-container ya-stack-demo-vertical-200">
          <span className="ya-stack-demo-label">justify: {j || 'default'}</span>
          <Stack {...args} justify={j as ContentJustify}>
            {makeChildren(3)}
          </Stack>
        </div>
      ))}
    </div>
  ),
  args: { orientation: Orientations.Vertical }
};

// Overflow horizontal (muitos filhos)
export const OverflowHorizontal: Story = {
  render: (args) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container ya-stack-overflow-horizontal">
        <Stack {...args}>
          {makeChildren(20)}
        </Stack>
      </div>
    </div>
  ),
  args: { orientation: Orientations.Horizontal, gap: Sizes.Small }
};

// Overflow vertical (muitos filhos)
export const OverflowVertical: Story = {
  render: (args) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container ya-stack-overflow-vertical">
        <Stack {...args}>
          {makeChildren(25)}
        </Stack>
      </div>
    </div>
  ),
  args: { orientation: Orientations.Vertical, gap: Sizes.Small }
};

// Combinação completa (orientações x gaps) – útil para inspeção visual
export const MatrixOrientationGap: Story = {
  render: (args) => (
    <div className="ya-stack-frame ya-stack-matrix">
      {allOrientations.map(o => allGaps.map(g => (
        <div key={`${o}-${g}`} className={"ya-stack-demo-container" + (o === Orientations.Vertical ? ' ya-stack-demo-vertical-200' : '')}>
          <span className="ya-stack-demo-label">{o} • gap {g}</span>
          <Stack {...args} orientation={o} gap={g}>
            {makeChildren(3)}
          </Stack>
        </div>
      )))}
    </div>
  )
};

// História mínima só vertical com altura total do pai (demonstra expansão)
export const FullHeightVertical: Story = {
  render: (args) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container ya-stack-demo-vertical-300">
        <Stack {...args} />
      </div>
    </div>
  ),
  args: { orientation: Orientations.Vertical }
};
