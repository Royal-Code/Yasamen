import type { Meta, StoryObj } from '@storybook/react';
import { Stack } from '../../lib/components/layouts';
import { Orientations, Sizes, ContentJustify } from '../../lib/components/commons';
import './StackStories.css';

/*
  (Movido) Stories para Stack layout component.
*/

const allOrientations = Object.values(Orientations);
const allGaps = Object.values(Sizes) as Sizes[];
const allJustify = Object.values(ContentJustify);

const makeChildren = (count: number) => Array.from({ length: count }, (_, i) => (
  <div key={i} className="ya-stack-demo-item p-2 bg-highlight-500 text-light-100 rounded-sm font-semibold shadow-sm flex items-center justify-center">
    Item {i + 1}
  </div>
));

const meta = {
  title: 'Components/Layout/Stack',
  component: Stack,
  parameters: {
    layout: 'centered',
    docs: {
      description: {
        component: 'Stack organiza elementos em linha ou coluna, aplicando gap e justify-items. Vertical ocupa 100% da altura do wrapper; horizontal ocupa 100% da largura.'
      }
    }
  },
  tags: ['autodocs', 'stable'],
  argTypes: {
    orientation: { control: 'select', options: allOrientations },
    gap: { control: 'select', options: allGaps },
    justify: { control: 'select', options: allJustify },
    children: { control: false },
    className: { control: 'text' }
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

export const Playground: Story = {
  render: (a) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container">
        <Stack {...a} />
      </div>
    </div>
  )
};

export const Horizontal: Story = {
  args: { orientation: Orientations.Horizontal },
  render: (a) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container">
        <Stack {...a} />
      </div>
    </div>
  )
};

export const Vertical: Story = {
  args: { orientation: Orientations.Vertical },
  render: (a) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container ya-stack-demo-vertical-240">
        <Stack {...a} />
      </div>
    </div>
  )
};

export const GapShowcase: Story = {
  args: { orientation: Orientations.Horizontal },
  render: (a) => (
    <div className="ya-stack-frame ya-stack-gap-showcase">
      {allGaps.map(g => (
        <div key={g} className="ya-stack-demo-container">
          <span className="ya-stack-demo-label">gap: {g}</span>
          <Stack {...a} gap={g}>{makeChildren(3)}</Stack>
        </div>
      ))}
    </div>
  )
};

export const JustifyHorizontalVariants: Story = {
  args: { orientation: Orientations.Horizontal },
  render: (a) => (
    <div className="ya-stack-frame ya-stack-justify-showcase">
      {allJustify.map(j => (
        <div key={j} className="ya-stack-demo-container">
          <span className="ya-stack-demo-label">justify: {j || 'default'}</span>
          <Stack {...a} justify={j as ContentJustify}>{makeChildren(3)}</Stack>
        </div>
      ))}
    </div>
  )
};

export const JustifyVerticalVariants: Story = {
  args: { orientation: Orientations.Vertical },
  render: (a) => (
    <div className="ya-stack-frame ya-stack-justify-showcase ya-stack-justify-showcase-demo-vertical">
      {allJustify.map(j => (
        <div key={j} className="ya-stack-demo-container ya-stack-demo-vertical-200">
          <span className="ya-stack-demo-label">justify: {j || 'default'}</span>
          <Stack {...a} justify={j as ContentJustify}>{makeChildren(3)}</Stack>
        </div>
      ))}
    </div>
  )
};

export const OverflowHorizontal: Story = {
  args: { orientation: Orientations.Horizontal, gap: Sizes.Small },
  render: (a) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container ya-stack-overflow-horizontal">
        <Stack {...a}>{makeChildren(20)}</Stack>
      </div>
    </div>
  )
};

export const OverflowVertical: Story = {
  args: { orientation: Orientations.Vertical, gap: Sizes.Small },
  render: (a) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container ya-stack-overflow-vertical">
        <Stack {...a}>{makeChildren(25)}</Stack>
      </div>
    </div>
  )
};

export const MatrixOrientationGap: Story = {
  render: (a) => (
    <div className="ya-stack-frame ya-stack-matrix">
      {allOrientations.map(o =>
        allGaps.map(g => (
          <div
            key={`${o}-${g}`}
            className={"ya-stack-demo-container" + (o === Orientations.Vertical ? ' ya-stack-demo-vertical-200' : '')}
          >
            <span className="ya-stack-demo-label">{o} • gap {g}</span>
            <Stack {...a} orientation={o} gap={g}>{makeChildren(3)}</Stack>
          </div>
        ))
      )}
    </div>
  )
};

export const FullHeightVertical: Story = {
  args: { orientation: Orientations.Vertical },
  render: (a) => (
    <div className="ya-stack-frame">
      <div className="ya-stack-demo-container ya-stack-demo-vertical-300">
        <Stack {...a} />
      </div>
    </div>
  )
};
