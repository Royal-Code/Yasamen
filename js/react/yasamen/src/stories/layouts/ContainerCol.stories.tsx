import type { Meta, StoryObj } from '@storybook/react';
import './ContainerColStories.css';
import { Container, Col, LayoutTypes, LayoutSizes } from '../../lib/components/layouts';
import type { TabletSpanValue, LaptopSpanValue, DesktopSpanValue, SpanValue } from '../../lib/components/layouts/Cols';
import { Sizes } from '../../lib/components/commons';

/* (Movido) Stories para Container + Col */

const allLayoutTypes = Object.values(LayoutTypes);
const allLayoutSizes = Object.values(LayoutSizes);
const allHeights = Object.values(Sizes) as Sizes[];

interface ColDef {
  key?: string;
  span?: SpanValue;
  spanTablet?: TabletSpanValue;
  spanLaptop?: LaptopSpanValue;
  spanDesktop?: DesktopSpanValue;
  height?: Sizes;
  label?: string;
  className?: string;
}

const makeCol = (def: ColDef) => (
  <Col
    key={def.key || def.label || Math.random().toString(36).slice(2)}
    span={def.span ?? 4}
    spanTablet={def.spanTablet}
    spanLaptop={def.spanLaptop}
    spanDesktop={def.spanDesktop}
    height={def.height}
    className={"ya-containercol-demo-item p-2 rounded-sm font-semibold text-light-100 bg-primary-500 shadow-sm " + (def.className || '')}
  >
    {def.label || `span ${def.span}`}
  </Col>
);

const playgroundCols = [
  makeCol({ span: 4, label: 'Col A' }),
  makeCol({ span: 4, label: 'Col B' }),
  makeCol({ span: 4, label: 'Col C' }),
  makeCol({ span: 4, label: 'Col D' }),
];

const playgroundCols2 = [
  makeCol({ span: 4, spanTablet: 3, label: 'Col A' }),
  makeCol({ span: 4, spanTablet: 3, label: 'Col B' }),
  makeCol({ span: 8, spanTablet: 6, label: 'Col C' }),
];

const responsiveGridCols = [
  makeCol({ span: 4, spanTablet: 4, spanLaptop: 6, spanDesktop: 8, label: 'A (multi-breakpoint)' }),
  makeCol({ span: 4, spanTablet: 4, spanLaptop: 3, spanDesktop: 4, label: 'B (multi-breakpoint)' }),
  makeCol({ span: 4, spanTablet: 4, spanLaptop: 3, spanDesktop: 2, label: 'C (shrinks desktop)' }),
  makeCol({ span: 4, spanTablet: 0, spanLaptop: 0, spanDesktop: 0, label: 'D (base only)' }),
];

const heightCols = [
  makeCol({ span: 4, height: Sizes.Small, label: 'Small' }),
  makeCol({ span: 4, height: Sizes.Medium, label: 'Medium' }),
  makeCol({ span: 4, height: Sizes.Large, label: 'Large' }),
  makeCol({ span: 4, height: Sizes.Largest, label: 'Largest' }),
];

const edgeColsBase = [
  makeCol({ span: 0, label: 'span=0 -> fallback 4' }),
  makeCol({ span: 14, label: 'base 14 (Phone clamp 4)' }),
  makeCol({ span: 12, label: 'base 12 (Tablet clamp 8)' }),
  makeCol({ span: 15, label: 'base 15 (Laptop clamp 12)' }),
  makeCol({ span: 16, label: 'base 16 (Dentro limite Desktop)' }),
];

const flexBaseCols = [
  makeCol({ span: 6, spanTablet: 4, spanLaptop: 6, spanDesktop: 8, label: 'Flex A' }),
  makeCol({ span: 6, spanTablet: 4, spanLaptop: 3, spanDesktop: 4, label: 'Flex B' }),
  makeCol({ span: 4, spanTablet: 8, spanLaptop: 6, spanDesktop: 6, label: 'Flex C' }),
  makeCol({ span: 8, spanTablet: 8, spanLaptop: 12, spanDesktop: 16, label: 'Flex D (max desktop)' }),
];

const meta = {
  title: 'Components/Layout/ContainerCol',
  component: Container,
  parameters: {
    layout: 'centered',
    docs: {
      description: {
        component: 'Container provê contexto de layout e Col consome para gerar classes responsivas. Grid gera classes para todos breakpoints; Flex calcula um único span conforme size atual (Phone/Tablet/Laptop/Desktop). span=0 fallback em 4; clamps max variam por breakpoint.'
      }
    }
  },
  tags: ['autodocs', 'stable'],
  argTypes: {
    type: { control: 'select', options: allLayoutTypes },
    size: { control: 'select', options: allLayoutSizes },
    height: { control: 'select', options: allHeights },
    className: { control: 'text' },
    children: { control: false }
  },
  args: {
    type: LayoutTypes.Grid,
    size: LayoutSizes.Auto,
    height: Sizes.Medium,
  }
} satisfies Meta<typeof Container>;

export default meta;
type Story = StoryObj<typeof meta>;

export const Playground: Story = {
  render: a => (
    <div className="ya-layout-frame">
      <div className="ya-layout-demo-container">
        <Container {...a}>{playgroundCols}</Container>
      </div>
    </div>
  )
};

export const Playground2: Story = {
  render: a => (
    <div className="ya-layout-frame">
      <div className="ya-layout-demo-container">
        <Container {...a}>{playgroundCols2}</Container>
      </div>
    </div>
  )
};

export const GridResponsiveBreakpoints: Story = {
  args: { type: LayoutTypes.Grid, size: LayoutSizes.Auto },
  render: a => (
    <div className="ya-layout-frame">
      <div className="ya-layout-demo-container">
        <Container {...a}>{responsiveGridCols}</Container>
      </div>
      <p className="ya-layout-caption text-sm mt-2">Classes específicas de cada breakpoint via media queries.</p>
    </div>
  )
};

export const HeightsShowcase: Story = {
  args: { type: LayoutTypes.Grid, size: LayoutSizes.Auto, height: Sizes.Medium },
  render: a => (
    <div className="ya-layout-frame">
      <div className="ya-layout-demo-container">
        <Container {...a}>{heightCols}</Container>
      </div>
      <p className="ya-layout-caption text-sm mt-2">Altura herdada = {a.height}. Cols podem sobrescrever.</p>
    </div>
  )
};

export const EdgeCases: Story = {
  render: a => (
    <div className="ya-layout-frame ya-layout-edge-grid">
      <div className="ya-layout-demo-container">
        <h4 className="ya-layout-demo-label mb-1">Grid</h4>
        <Container {...a} type={LayoutTypes.Grid} size={LayoutSizes.Auto}>{edgeColsBase}</Container>
      </div>
      <div className="ya-layout-demo-container">
        <h4 className="ya-layout-demo-label mb-1">Flex Phone</h4>
        <Container {...a} type={LayoutTypes.Flex} size={LayoutSizes.Phone}>{edgeColsBase}</Container>
      </div>
      <div className="ya-layout-demo-container">
        <h4 className="ya-layout-demo-label mb-1">Flex Tablet</h4>
        <Container {...a} type={LayoutTypes.Flex} size={LayoutSizes.Tablet}>{edgeColsBase}</Container>
      </div>
      <div className="ya-layout-demo-container">
        <h4 className="ya-layout-demo-label mb-1">Flex Laptop</h4>
        <Container {...a} type={LayoutTypes.Flex} size={LayoutSizes.Laptop}>{edgeColsBase}</Container>
      </div>
      <div className="ya-layout-demo-container">
        <h4 className="ya-layout-demo-label mb-1">Flex Desktop</h4>
        <Container {...a} type={LayoutTypes.Flex} size={LayoutSizes.Desktop}>{edgeColsBase}</Container>
      </div>
      <p className="ya-layout-caption text-sm mt-2">Clamp visível nos Containers Flex; fallback span=0 - 4.</p>
    </div>
  )
};

export const FlexSizeVariants: Story = {
  args: { type: LayoutTypes.Flex },
  render: a => (
    <div className="ya-layout-frame ya-layout-flex-variants">
      {allLayoutSizes.map(sz => (
        <div key={sz} className="ya-layout-demo-container mb-4">
          <span className="ya-layout-demo-label">Flex size: {sz}</span>
          <Container {...a} size={sz}>{flexBaseCols}</Container>
        </div>
      ))}
      <p className="ya-layout-caption text-sm mt-2">Modo Flex considera apenas span do breakpoint atual.</p>
    </div>
  )
};

export const GridSpanMatrix: Story = {
  args: { type: LayoutTypes.Grid, size: LayoutSizes.Auto },
  render: a => {
    const configs: ColDef[][] = [
      [ { span: 4, label: '4' }, { span: 4, label: '4' }, { span: 4, label: '4' }, { span: 4, label: '4' } ],
      [ { span: 6, label: '6' }, { span: 6, label: '6' }, { span: 4, label: '4' } ],
      [ { span: 8, label: '8' }, { span: 4, label: '4' }, { span: 4, label: '4' } ],
      [ { span: 10, label: '10' }, { span: 6, label: '6' } ],
      [ { span: 12, label: '12' }, { span: 4, label: '4' } ],
      [ { span: 16, label: '16' } ],
    ];
    return (
      <div className="ya-layout-frame ya-layout-span-matrix">
        {configs.map((cfg, i) => (
          <div key={i} className="ya-layout-demo-container mb-3">
            <span className="ya-layout-demo-label">Linha {i + 1}</span>
            <Container {...a}>{cfg.map(c => makeCol(c))}</Container>
          </div>
        ))}
        <p className="ya-layout-caption text-sm mt-2">Somatório até 16 por linha.</p>
      </div>
    );
  }
};

export const MinimalFlex: Story = {
  args: { type: LayoutTypes.Flex, size: LayoutSizes.Laptop, height: Sizes.Large },
  render: a => (
    <div className="ya-layout-frame">
      <div className="ya-layout-demo-container">
        <Container {...a}>
          <Col span={4}>A</Col>
          <Col span={4}>B</Col>
          <Col span={4}>C</Col>
          <Col span={4}>D</Col>
        </Container>
      </div>
      <p className="ya-layout-caption text-sm mt-2">Todos herdando height={a.height}.</p>
    </div>
  )
};
