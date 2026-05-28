# UIP-SURFACE-CHART - Chart Surface

## Definição

**Categoria**: Superfície Especializada

**Definição curta**: Superfície analítica para visualização gráfica, séries, eixos, legenda, comparação e drill-down.

**Objetivo estrutural**: Representar dados quantitativos, temporais, categóricos, hierárquicos ou relacionais por uma visualização gráfica com leitura e exploração próprias.

**Não confundir com**: UIP-CONTENT-METRIC_CARD (KPI isolado), UIP-DATA-DATA_TABLE (comparação tabular), PP-DASHBOARD (página completa).

**Nível composicional possível**: Container, Leaf

## Decisão

**Quando usar**: quando padrões, tendências, distribuição, comparação, correlação ou composição são melhor entendidos visualmente; quando a análise precisa de eixo, legenda, séries, filtros, tooltip, zoom ou drill-down.

**Quando evitar**: quando um número isolado resolve; quando a comparação exige precisão tabular; quando o volume ou a qualidade dos dados tornaria o gráfico enganoso; quando a plataforma não permite leitura gráfica adequada.

**Alternativas próximas**: UIP-CONTENT-METRIC_CARD (KPI isolado), UIP-DATA-DATA_TABLE (comparação tabular), UIP-DATA-TIMELINE_ITEM (cronologia de eventos).

**Sinais de escolha**:
- séries temporais, comparação entre categorias, distribuição
- ranking ou relação entre variáveis
- necessidade de drill-down
- legenda ou tooltip são parte da leitura

**Grau de Rigidez**: Médio — visualização gráfica com eixos e legenda é estável; tipo de gráfico, séries e drill-down variam.

## Composição

**Zonas usuais**: Superfície.

**Variantes reconhecidas**: linha; barras; área; pizza ou donut quando justificável; dispersão; heatmap; funnel; gauge; sparkline; grafo ou rede; treemap.

**UIPs frequentemente combinados**: UIP-INPUT-FILTER_PANEL, UIP-INPUT-DATE_PICKER, UIP-CONTENT-METRIC_CARD, UIP-OVERLAY-TOOLTIP, UIP-FEEDBACK-LOADING_STATE.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DASHBOARD.

**Compatibilidade Secundária**: PP-DETAIL, PP-LIST-DETAIL, PP-BOARD, PP-CALENDAR, PP-MAP.

**Incompatibilidades explícitas**: PP-FORM, PP-WIZARD, PP-CONVERSATION quando a visualização não participa da decisão principal.

## Estrutura e Transição

**Estrutura Desktop**: superfície com gráfico, eixo ou escala, legenda, contexto temporal ou categórico, tooltip, seleção e ações de drill-down ou exportação quando aplicável.

**Estrutura Mobile**: gráfico simplificado ou dividido em leituras progressivas. Legenda, filtros e drill-down podem virar controles externos ou detalhe.

**Regra de Transição**: preservar a pergunta analítica, a relação entre série, eixo e legenda e o acesso ao dado principal. Elementos secundários podem ser resumidos ou movidos para detalhe.

## Estados

**Estados próprios**: carregando, com dados, sem dados, seleção ativa, série destacada, zoom ativo, drill-down ativo, dados parciais, erro, atualização em tempo real.

**Reação a estados da página**: `loading` → skeleton ou placeholder de gráfico. `empty` → sem dados para o período ou filtro. `error` → falha de consulta ou processamento.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir responsividade, tooltip ou foco, legenda, filtros, drill-down, exportação e fallback tabular.

**Adaptação Mobile nativo**: reduzir densidade, priorizar uma pergunta analítica por gráfico e mover detalhe para tela ou painel progressivo.

**Adaptação Desktop nativo**: pode oferecer zoom, seleção múltipla, atalhos, exportação e múltiplas janelas para análise avançada.
