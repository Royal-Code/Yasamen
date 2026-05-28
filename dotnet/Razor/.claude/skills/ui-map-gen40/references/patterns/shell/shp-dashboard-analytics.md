# SHP-DASHBOARD_ANALYTICS - Dashboard/Analytics

## Definição

**Definição curta**: Shell orientado a monitoramento, leitura analítica e observação de métricas.

**Objetivo estrutural**: Sustentar leitura de KPIs, tendências, estados operacionais e resposta rápida a desvios.

**Interação dominante**: Analítica

**Não confundir com**: SHP-WORKSPACE_ADMIN (operação multi-módulo), SHP-PORTAL (conteúdo informativo), SHP-STUDIO_WORKBENCH (ferramenta de criação).

## Decisão

**Sinais de escolha**:
- métricas dominantes
- leitura frequente de KPIs
- filtros temporais
- alertas
- necessidade de correlação visual de indicadores

**Limites**: não usar como shell principal quando a tarefa primária é executar operações transacionais extensas.

**Grau de Rigidez**: Alto — grade de métricas, filtros globais e leitura analítica são invariantes; disposição de painéis e drill-downs variam.

## Navegação e Estrutura

**Modelo de navegação global**: navegação curta por áreas analíticas, filtros globais, painéis e drill-downs controlados.

**Estrutura Desktop**: áreas analíticas com grade de métricas, filtros globais e painéis comparativos.

**Estrutura Mobile**: visão resumida por blocos, drill-down progressivo e filtros compactos.

**Regra de transição**: reduzir densidade simultânea sem perder a leitura hierárquica dos indicadores.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DASHBOARD, PP-DETAIL, PP-MAP.

**Compatibilidade Secundária**: PP-LIST-DETAIL, PP-CALENDAR.

**Incompatibilidades explícitas**: PP-LANDING como padrão dominante; PP-WIZARD como experiência principal.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir comportamento de grid, filtros e drill-down por viewport.

**Adaptação Mobile nativo**: usar síntese, lista de indicadores e drill-down; não assumir comparação simultânea de muitos painéis em phone.

**Adaptação Desktop nativo**: pode ativar UIP-INTERACTION-KEYBOARD_FLOW, multi-window ou background progress quando monitoramento e investigação ocorrerem em janelas separadas.
