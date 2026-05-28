# PP-CALENDAR - Calendar

## Definição

**Definição curta**: Página orientada a agenda, calendário ou distribuição de itens por tempo.

**Objetivo estrutural**: Sustentar leitura e operação sobre eventos, reservas, compromissos ou disponibilidade ao longo do tempo.

**Interação dominante**: Temporal

**Não confundir com**: PP-BOARD (organização por estados), PP-FEED (stream cronológico contínuo).

## Decisão

**Sinais de escolha**:
- tempo como eixo principal
- visualização por dia, semana ou mês
- conflitos de agenda
- disponibilidade
- eventos posicionados temporalmente

**Limites**: exige eixo temporal como estrutura principal; não usar quando o tempo é apenas metadado secundário.

**Grau de Rigidez**: Médio — visualização temporal e navegação por período são estáveis; tipo de evento, vistas e criação variam.

## Composição

**Zonas funcionais obrigatórias**: Superfície; Detalhe; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-SURFACE-CALENDAR, UIP-INPUT-DATE_PICKER, UIP-ACTION-ACTION_BAR, UIP-CONTENT-DETAIL_BLOCK, UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-LOADING_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-TRANSACTIONAL_COMMERCE.

**Compatibilidade Secundária**: SHP-PORTAL, SHP-KIOSK_EMBEDDED, SHP-DASHBOARD_ANALYTICS.

**Incompatibilidades explícitas**: SHP-COMMUNICATION como experiência dominante.

## Estrutura e Transição

**Estrutura Desktop**: agenda, semana ou mês com detalhe acessório e controles temporais visíveis.

**Estrutura Mobile**: agenda simplificada, foco por dia ou lista temporal com drill-down.

**Regra de transição**: preservar a semântica temporal e o acesso às ações principais mesmo com simplificação da grade.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir a visão temporal principal por viewport e fallback para lista.

**Adaptação Mobile nativo**: priorizar dia ou lista e drill-down; usar picker nativo quando fizer sentido.

**Adaptação Desktop nativo**: pode ativar drag/drop, keyboard flow e múltiplas janelas para agenda avançada.
