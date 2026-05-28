# PP-DASHBOARD - Dashboard

## Definição

**Definição curta**: Página de síntese analítica para leitura rápida de indicadores, estados e tendências.

**Objetivo estrutural**: Sustentar observação, correlação leve e drill-down controlado sobre métricas.

**Interação dominante**: Analítica

**Não confundir com**: PP-DETAIL (entidade singular), PP-LIST-DETAIL (coleção operacional com detalhe).

## Decisão

**Sinais de escolha**:
- KPIs dominantes
- leitura frequente
- filtros temporais
- comparações
- visão resumida precedendo exploração

**Limites**: não usar quando a página é centrada em criação, edição profunda ou captura transacional extensa.

**Grau de Rigidez**: Médio — síntese de indicadores e leitura analítica são estáveis; quantidade, tipo e disposição de métricas variam por domínio.

## Composição

**Zonas funcionais obrigatórias**: Filtros; Conteúdo; Detalhe.

**UI Patterns tipicamente obrigatórios**: UIP-CONTENT-METRIC_CARD, UIP-SURFACE-CHART, UIP-STRUCT-GRID_CONTAINER, UIP-INPUT-FILTER_PANEL, UIP-CONTENT-DETAIL_BLOCK, UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-LOADING_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-DASHBOARD_ANALYTICS.

**Compatibilidade Secundária**: SHP-WORKSPACE_ADMIN, SHP-KIOSK_EMBEDDED.

**Incompatibilidades explícitas**: SHP-COMMUNICATION como experiência dominante.

## Estrutura e Transição

**Estrutura Desktop**: grade de métricas, filtros e blocos de análise com leitura comparativa.

**Estrutura Mobile**: cartões empilhados, filtros compactos e drill-down progressivo.

**Regra de transição**: reduzir simultaneidade visual sem perder a leitura hierárquica das métricas.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: definir grid, filtros e drill-down por viewport.

**Adaptação Mobile nativo**: reduzir para síntese, lista de KPIs e navegação progressiva para detalhe.

**Adaptação Desktop nativo**: pode compor dashboards densos com múltiplos painéis, atalhos e drill-down avançado.
