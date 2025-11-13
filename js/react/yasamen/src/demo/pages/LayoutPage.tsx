import React from 'react';
import Container from '../../lib/components/layouts/Container';
import Col from '../../lib/components/layouts/Cols';
import { LayoutTypes } from '../../lib/components/layouts/layout-types';
import { Sizes } from '../../lib/components/commons';

// Nota: LayoutSizes está em outro arquivo; import corrigido abaixo.
import { LayoutSizes as SizesMap } from '../../lib/components/layouts/layout-sizes';

// Pequeno util para visualização de coluna
function Box({ children }: { children: React.ReactNode }) {
  return (
    <div className="p-2 text-center text-xs rounded bg-secondary-500 text-white">
      {children}
    </div>
  );
}

const LayoutPage: React.FC = () => {
  return (
    <div className="layout-page">
      <h2 className="mb-2">Container & Cols</h2>
      <p className="mb-4 text-sm opacity-80 max-w-prose">
        Demonstração dos componentes de layout <code>Container</code> e <code>Col</code> em modo Grid e Flex.\n
        As colunas podem ter <code>span</code> automático (omitido) ou definido por dispositivo: <code>spanTablet</code>, <code>spanLaptop</code>, <code>spanDesktop</code>.\n
        O Grid utiliza limites de colunas por breakpoint (4 / 8 / 12 / 16) enquanto o Flex recalcula dinamicamente conforme o <code>size</code> do Container.
      </p>

      <h3 className="mb-2">Grid Básico (auto span)</h3>
      <p className="mb-3 text-xs opacity-70">Colunas sem especificar <code>span</code> (usa default interno). Cada box mostra a ordem.</p>
      <Container className="mb-6">
        <Col><Box>1 auto</Box></Col>
        <Col><Box>2 auto</Box></Col>
        <Col><Box>3 auto</Box></Col>
        <Col><Box>4 auto</Box></Col>
      </Container>

      <h3 className="mb-2">Grid Básico (auto span) multiplas linhas</h3>
      <p className="mb-3 text-xs opacity-70">Colunas sem especificar <code>span</code> (usa default interno). Cada box mostra a ordem.</p>
      <Container className="mb-6">
        <Col><Box>1 auto</Box></Col>
        <Col><Box>2 auto</Box></Col>
        <Col><Box>3 auto</Box></Col>
        <Col><Box>4 auto</Box></Col>
        <Col><Box>5 auto</Box></Col>
        <Col><Box>6 auto</Box></Col>
        <Col><Box>7 auto</Box></Col>
        <Col><Box>8 auto</Box></Col>
        <Col><Box>9 auto</Box></Col>
        <Col><Box>10 auto</Box></Col>
      </Container>

      <h3 className="mb-2">Flex Básico (auto span)</h3>
      <p className="mb-3 text-xs opacity-70">Colunas sem especificar <code>span</code> (usa default interno). Cada box mostra a ordem.</p>
      <Container type={LayoutTypes.Flex} className="mb-6">
        <Col><Box>1 auto</Box></Col>
        <Col><Box>2 auto</Box></Col>
        <Col><Box>3 auto</Box></Col>
        <Col><Box>4 auto</Box></Col>
      </Container>

      <h3 className="mb-2">Flex Básico (auto span) multiplas linhas</h3>
      <p className="mb-3 text-xs opacity-70">Colunas sem especificar <code>span</code> (usa default interno). Cada box mostra a ordem.</p>
      <Container type={LayoutTypes.Flex} className="mb-6">
        <Col><Box>1 auto</Box></Col>
        <Col><Box>2 auto</Box></Col>
        <Col><Box>3 auto</Box></Col>
        <Col><Box>4 auto</Box></Col>
        <Col><Box>5 auto</Box></Col>
        <Col><Box>6 auto</Box></Col>
        <Col><Box>7 auto</Box></Col>
        <Col><Box>8 auto</Box></Col>
        <Col><Box>9 auto</Box></Col>
        <Col><Box>10 auto</Box></Col>
      </Container>

      <h3 className="mb-2">Grid com spans explícitos</h3>
      <p className="mb-3 text-xs opacity-70">Exemplo definindo diferentes larguras (somando até 16).</p>
      <Container type={LayoutTypes.Grid} size={SizesMap.Auto} className="mb-6">
        <Col span={2}><Box>span 2</Box></Col>
        <Col span={4}><Box>span 4</Box></Col>
        <Col span={6}><Box>span 6</Box></Col>
        <Col span={4}><Box>span 4</Box></Col>
      </Container>

      <h3 className="mb-2">Grid Responsivo por Dispositivo</h3>
      <p className="mb-3 text-xs opacity-70">Cada coluna usa props específicas para Tablet/Laptop/Desktop.</p>
      <Container type={LayoutTypes.Grid} size={SizesMap.Auto} className="mb-6">
        <Col span={4} spanTablet={4} spanLaptop={6} spanDesktop={8}><Box>4 / 4 / 6 / 8</Box></Col>
        <Col span={4} spanTablet={4} spanLaptop={3} spanDesktop={4}><Box>4 / 4 / 3 / 4</Box></Col>
        <Col span={4} spanTablet={8} spanLaptop={3} spanDesktop={4}><Box>4 / 8 / 3 / 4</Box></Col>
      </Container>

      <h3 className="mb-2">Flex Básico</h3>
      <p className="mb-3 text-xs opacity-70">Exemplo de Container flex manipulando spans conforme breakpoint atual.</p>
      <Container type={LayoutTypes.Flex} size={SizesMap.Auto} className="mb-6">
        <Col span={2} spanTablet={2} spanLaptop={2} spanDesktop={2}><Box>2</Box></Col>
        <Col span={4} spanTablet={4} spanLaptop={4} spanDesktop={4}><Box>4</Box></Col>
        <Col span={6} spanTablet={8} spanLaptop={6} spanDesktop={6}><Box>6/8/6/6</Box></Col>
        <Col span={4} spanTablet={4} spanLaptop={4} spanDesktop={4}><Box>4</Box></Col>
      </Container>

      <h3 className="mb-2">Flex com Auto + Overrides</h3>
      <p className="mb-3 text-xs opacity-70">Algumas colunas usam apenas <code>span</code>, outras definem overrides para laptop / desktop.</p>
      <Container type={LayoutTypes.Flex} size={SizesMap.Auto} className="mb-6">
        <Col><Box>auto</Box></Col>
        <Col span={3}><Box>span 3</Box></Col>
        <Col span={5} spanLaptop={6} spanDesktop={8}><Box>5 / 6 / 8</Box></Col>
        <Col span={4} spanDesktop={6}><Box>4 / 6</Box></Col>
        <Col span={0} spanTablet={2} spanLaptop={3} spanDesktop={4}><Box>auto /2 /3 /4</Box></Col>
      </Container>

      <h3 className="mb-2">Diferentes Alturas</h3>
      <p className="mb-3 text-xs opacity-70">Alturas aplicadas via prop <code>height</code>.</p>
      <Container type={LayoutTypes.Grid} size={SizesMap.Auto} className="mb-6" height={Sizes.Large}>
        <Col span={4} height={Sizes.Small}><Box>h small</Box></Col>
        <Col span={4} height={Sizes.Medium}><Box>h medium</Box></Col>
        <Col span={4} height={Sizes.Large}><Box>h large</Box></Col>
        <Col span={4}><Box>h inherit (container)</Box></Col>
      </Container>
    </div>
  );
};

export default LayoutPage;
