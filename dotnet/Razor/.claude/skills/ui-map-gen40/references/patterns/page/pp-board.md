# PP-BOARD - Board

## Definição

**Definição curta**: Página de organização visual por colunas, estados, etapas ou lanes.

**Objetivo estrutural**: Sustentar acompanhamento e manipulação de itens por estado, estágio ou agrupamento operacional.

**Interação dominante**: Operacional visual

**Não confundir com**: PP-LIST-DETAIL (coleção com detalhe sincronizado), PP-CALENDAR (eixo temporal).

## Decisão

**Sinais de escolha**:
- colunas ou lanes
- arrastar ou mover itens entre estados
- visão do fluxo de trabalho
- status como eixo principal
- organização visual por colunas é central

**Limites**: não usar quando o eixo principal é temporal, geográfico ou de leitura linear, e não estado operacional.

**Grau de Rigidez**: Alto — colunas e lanes e a transição visual de itens entre estados são invariantes; quantidade de colunas, tipo de card e ações variam por domínio.

## Composição

**Zonas funcionais obrigatórias**: Filtros; Coleção; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-DATA-KANBAN_COLUMN, UIP-INPUT-SEARCH_BAR, UIP-INPUT-FILTER_PANEL, UIP-ACTION-ACTION_BAR, UIP-ACTION-CONTEXTUAL_MENU, UIP-FEEDBACK-EMPTY_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-STUDIO_WORKBENCH.

**Compatibilidade Secundária**: SHP-TRANSACTIONAL_COMMERCE.

**Incompatibilidades explícitas**: SHP-PORTAL como experiência dominante.

## Estrutura e Transição

**Estrutura Desktop**: colunas simultâneas com itens movíveis ou comparáveis lado a lado.

**Estrutura Mobile**: foco em uma coluna por vez, com navegação horizontal ou agrupamento sequencial.

**Regra de transição**: reduzir simultaneidade sem perder a leitura do fluxo por estados.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir scroll horizontal, drag/drop, filtros e fallback touch.

**Adaptação Mobile nativo**: uma coluna por vez; mover item por menu ou ação explícita quando o drag for frágil.

**Adaptação Desktop nativo**: pode ativar keyboard flow, drag/drop e multi-window quando itens transitam entre contextos.
