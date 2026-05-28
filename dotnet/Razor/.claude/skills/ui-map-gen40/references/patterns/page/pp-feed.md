# PP-FEED - Feed

## Definição

**Definição curta**: Página de lista cronológica ou stream contínuo de itens, atualizações ou publicações.

**Objetivo estrutural**: Sustentar consumo recorrente, atualização incremental e navegação por ordem temporal.

**Interação dominante**: Cronológica

**Não confundir com**: PP-CATALOG (coleção filtrável exploratória), PP-CONVERSATION (thread bidirecional).

## Decisão

**Sinais de escolha**:
- ordem temporal dominante
- stream contínuo
- leitura rápida
- atualização incremental
- eventual publicação leve

**Limites**: não usar quando busca estruturada, comparação de coleção ou detalhe persistente são mais importantes que a cronologia.

**Grau de Rigidez**: Médio — stream cronológico e leitura contínua são estáveis; tipo de item, interação e agrupamento variam.

## Composição

**Zonas funcionais obrigatórias**: Filtros; Coleção; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-STRUCT-SCROLLABLE_REGION, UIP-DATA-TIMELINE_ITEM, UIP-ACTION-CONTEXTUAL_MENU, UIP-ACTION-FLOATING_ACTION, UIP-FEEDBACK-EMPTY_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-MEDIA_CONTENT, SHP-COMMUNICATION.

**Compatibilidade Secundária**: SHP-PORTAL.

**Incompatibilidades explícitas**: SHP-DASHBOARD_ANALYTICS como experiência dominante.

## Estrutura e Transição

**Estrutura Desktop**: stream central com filtros, ações e atualização progressiva.

**Estrutura Mobile**: scroll contínuo de foco único com ações compactas.

**Regra de transição**: preservar a ordem temporal e a continuidade de consumo.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir scroll progressivo, filtros e restauração de posição.

**Adaptação Mobile nativo**: pode ativar UIP-INTERACTION-PULL_REFRESH, UIP-SYSTEM-OFFLINE_SYNC e ações por gesto com fallback.

**Adaptação Desktop nativo**: pode ativar teclado e notificações quando o feed representa atividade operacional.
