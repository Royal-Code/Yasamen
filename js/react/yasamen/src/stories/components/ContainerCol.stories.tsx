import type { Meta, StoryObj } from '@storybook/react';
import './ContainerColStories.css';
import { Container, Col, LayoutTypes, LayoutSizes } from '../../lib/components/layouts';
import type { TabletSpanValue, LaptopSpanValue, DesktopSpanValue, SpanValue } from '../../lib/components/layouts/Cols';
import { Sizes } from '../../lib/components/commons';

/*
  Stories para Container + Col.
  Objetivos:
  - Demonstrar diferença entre Grid e Flex.
  - Mostrar spans base e overrides por breakpoint (Phone / Tablet / Laptop / Desktop).
  - Evidenciar fallback quando span = 0 (cai em 4) e clamp de valores máximos.
  - Ilustrar altura (height) herdada do Container vs definida no Col.
  - Expor variantes de tamanho (size) no modo Flex e como o span efetivo muda.
*/

const allLayoutTypes = Object.values(LayoutTypes);
const allLayoutSizes = Object.values(LayoutSizes);
const allHeights = Object.values(Sizes) as Sizes[];

// Helper para gerar Cols rapidamente
interface ColDef {
  key?: string;
  span?: SpanValue; // base span (0 permite fallback)
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

// Conjunto padrão de colunas para playground
const playgroundCols = [
  makeCol({ span: 4, label: 'Col A' }),
  makeCol({ span: 4, label: 'Col B' }),
  makeCol({ span: 4, label: 'Col C' }),
  makeCol({ span: 4, label: 'Col D' }),
];

// Conjunto padrão de colunas para playground
const playgroundCols2 = [
  makeCol({ span: 4, spanTablet: 3, label: 'Col A' }),
  makeCol({ span: 4, spanTablet: 3, label: 'Col B' }),
  makeCol({ span: 8, spanTablet: 6, label: 'Col C' }),
];

// Responsive grid set mostrando overrides em cada breakpoint
const responsiveGridCols = [
  makeCol({ span: 4, spanTablet: 4, spanLaptop: 6, spanDesktop: 8, label: 'A (multi-breakpoint)' }),
  makeCol({ span: 4, spanTablet: 4, spanLaptop: 3, spanDesktop: 4, label: 'B (multi-breakpoint)' }),
  makeCol({ span: 4, spanTablet: 4, spanLaptop: 3, spanDesktop: 2, label: 'C (shrinks desktop)' }),
  makeCol({ span: 4, spanTablet: 0, spanLaptop: 0, spanDesktop: 0, label: 'D (base only)' }),
];

// Heights showcase
const heightCols = [
  makeCol({ span: 4, height: Sizes.Small, label: 'Small' }),
  makeCol({ span: 4, height: Sizes.Medium, label: 'Medium' }),
  makeCol({ span: 4, height: Sizes.Large, label: 'Large' }),
  makeCol({ span: 4, height: Sizes.Largest, label: 'Largest' }),
];

// Fallback & clamp:
// - span=0 demonstra fallback para 4.
// - spans maiores que a capacidade de um breakpoint (ex.: 14 em Phone) serão limitados (clamp) em Flex.
// Observação: Tipos restringem valores máximos por breakpoint, portanto demonstramos clamp usando span base > limite.
const edgeColsBase = [
  makeCol({ span: 0, label: 'span=0 -> fallback 4' }),
  makeCol({ span: 14, label: 'base 14 (Phone clamp 4)' }),
  makeCol({ span: 12, label: 'base 12 (Tablet clamp 8)' }),
  makeCol({ span: 15, label: 'base 15 (Laptop clamp 12)' }),
  makeCol({ span: 16, label: 'base 16 (Dentro do limite Desktop)' }),
];

// Para demonstrar Flex, declaramos base com spans + overrides. A story iterará pelos sizes.
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
        component: 'Container provê contexto de layout (type, size, height) e Col consome para gerar classes responsivas. Tipo Grid gera classes para todos breakpoints simultaneamente; Flex calcula um único span conforme o size atual do contexto. Spans são limitados: Phone<=4, Tablet<=8, Laptop<=12, Desktop<=16. Span base 0 cai em 4 por fallback.'
      }
    }
  },
  tags: ['autodocs', 'stable'],
  argTypes: {
    type: { control: 'select', options: allLayoutTypes, description: 'Tipo de layout (grid ou flex)' },
    size: { control: 'select', options: allLayoutSizes, description: 'Breakpoint/largura lógica do Container (influencia Flex)' },
    height: { control: 'select', options: allHeights, description: 'Altura padrão herdada pelos Cols (caso eles não definam)' },
    className: { control: 'text', description: 'Classes CSS adicionais para o Container' },
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

// Playground simples
export const Playground: Story = {
  render: (args) => (
    <div className="ya-layout-frame">
      <div className="ya-layout-demo-container">
        <Container {...args}>
          {playgroundCols}
        </Container>
      </div>
    </div>
  )
};

// Playground 2 
export const Playground2: Story = {
  render: (args) => (
    <div className="ya-layout-frame">
      <div className="ya-layout-demo-container">
        <Container {...args}>
          {playgroundCols2}
        </Container>
      </div>
    </div>
  )
};

// Grid responsivo – mostra múltiplos spans declarados por breakpoint
export const GridResponsiveBreakpoints: Story = {
  args: { type: LayoutTypes.Grid, size: LayoutSizes.Auto },
  render: (args) => (
    <div className="ya-layout-frame">
      <div className="ya-layout-demo-container">
        <Container {...args}>
          {responsiveGridCols}
        </Container>
      </div>
      <p className="ya-layout-caption text-sm mt-2 text-primary-700">Classes específicas de cada breakpoint são aplicadas e ativadas pelo CSS media queries.</p>
    </div>
  )
};

// Showcase de heights – alguns Cols sobrescrevem a altura herdada
export const HeightsShowcase: Story = {
  args: { type: LayoutTypes.Grid, size: LayoutSizes.Auto, height: Sizes.Medium },
  render: (args) => (
    <div className="ya-layout-frame">
      <div className="ya-layout-demo-container">
        <Container {...args}>
          {heightCols}
        </Container>
      </div>
      <p className="ya-layout-caption text-sm mt-2 text-primary-700">Altura herdada = {args.height}. Cols podem definir height próprio sobrescrevendo o contexto.</p>
    </div>
  )
};

// Edge cases de spans: fallback e clamp (mostrado melhor em Flex). Renderiza Grid e Flex lado a lado.
export const EdgeCases: Story = {
  render: (args) => (
    <div className="ya-layout-frame ya-layout-edge-grid">
      <div className="ya-layout-demo-container">
        <h4 className="ya-layout-demo-label mb-1">Grid (todos breakpoints via CSS)</h4>
        <Container {...args} type={LayoutTypes.Grid} size={LayoutSizes.Auto}>
          {edgeColsBase}
        </Container>
      </div>
      <div className="ya-layout-demo-container">
        <h4 className="ya-layout-demo-label mb-1">Flex Phone</h4>
        <Container {...args} type={LayoutTypes.Flex} size={LayoutSizes.Phone}>
          {edgeColsBase}
        </Container>
      </div>
      <div className="ya-layout-demo-container">
        <h4 className="ya-layout-demo-label mb-1">Flex Tablet</h4>
        <Container {...args} type={LayoutTypes.Flex} size={LayoutSizes.Tablet}>
          {edgeColsBase}
        </Container>
      </div>
      <div className="ya-layout-demo-container">
        <h4 className="ya-layout-demo-label mb-1">Flex Laptop</h4>
        <Container {...args} type={LayoutTypes.Flex} size={LayoutSizes.Laptop}>
          {edgeColsBase}
        </Container>
      </div>
      <div className="ya-layout-demo-container">
        <h4 className="ya-layout-demo-label mb-1">Flex Desktop</h4>
        <Container {...args} type={LayoutTypes.Flex} size={LayoutSizes.Desktop}>
          {edgeColsBase}
        </Container>
      </div>
      <p className="ya-layout-caption text-sm mt-2 text-primary-700">Clamp visível nos Containers Flex: spans acima do limite do breakpoint são reduzidos (Phone 4, Tablet 8, Laptop 12). Desktop aceita até 16. Fallback do span=0 cai em 4.</p>
    </div>
  )
};

// Flex – mostra como o mesmo set de Cols muda conforme size do Container
export const FlexSizeVariants: Story = {
  args: { type: LayoutTypes.Flex },
  render: (args) => (
    <div className="ya-layout-frame ya-layout-flex-variants">
      {allLayoutSizes.map(sz => (
        <div key={sz} className="ya-layout-demo-container mb-4">
          <span className="ya-layout-demo-label">Flex size: {sz}</span>
          <Container {...args} size={sz}>
            {flexBaseCols}
          </Container>
        </div>
      ))}
      <p className="ya-layout-caption text-sm mt-2 text-primary-700">No modo Flex, somente o span do breakpoint corrente (ou base) é considerado; após cálculo aplica clamp máximo.</p>
    </div>
  )
};

// Matrix de spans base – compara distribuição com diferentes combinações (grid)
export const GridSpanMatrix: Story = {
  args: { type: LayoutTypes.Grid, size: LayoutSizes.Auto },
  render: (args) => {
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
            <Container {...args}>
              {cfg.map(c => makeCol(c))}
            </Container>
          </div>
        ))}
        <p className="ya-layout-caption text-sm mt-2 text-primary-700">Demonstra diferentes somas de spans (até 16). CSS pode quebrar linha conforme necessário.</p>
      </div>
    );
  }
};

// Story minimalista – Container Flex com base sem overrides (demonstra herança de height)
export const MinimalFlex: Story = {
  args: { type: LayoutTypes.Flex, size: LayoutSizes.Laptop, height: Sizes.Large },
  render: (args) => (
    <div className="ya-layout-frame">
      <div className="ya-layout-demo-container">
        <Container {...args}>
          <Col span={4}>A</Col>
          <Col span={4}>B</Col>
          <Col span={4}>C</Col>
          <Col span={4}>D</Col>
        </Container>
      </div>
      <p className="ya-layout-caption text-sm mt-2 text-primary-700">Todos os Cols herdam height={args.height}. Flex calcula spans conforme size Laptop.</p>
    </div>
  )
};
