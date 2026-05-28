# PP-CATALOG - Catalog

## Definição

**Definição curta**: Página exploratória de coleção filtrável, comparável e orientada à descoberta.

**Objetivo estrutural**: Sustentar procura, refino e comparação leve de muitos itens.

**Interação dominante**: Exploratória

**Não confundir com**: PP-LIST-DETAIL (coleção operacional com detalhe), PP-FEED (stream cronológico).

## Decisão

**Sinais de escolha**:
- coleção ampla
- busca ou filtro relevantes
- comparação leve entre itens
- descoberta e refino mais importantes que detalhe simultâneo
- filtros e facetas refinam a descoberta

**Limites**: não usar quando a tarefa principal depende de detalhe persistente, conversa ou monitoramento analítico.

**Grau de Rigidez**: Médio — filtros e coleção explorável são estáveis; grid, cards, comparação e layout variam por domínio e conteúdo.

## Composição

**Zonas funcionais obrigatórias**: Filtros; Coleção; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-INPUT-SEARCH_BAR, UIP-INPUT-FILTER_PANEL, UIP-DATA-CARD_GRID ou UIP-DATA-LIST_ITEM, UIP-NAV-PAGINATION ou UIP-STRUCT-SCROLLABLE_REGION, UIP-ACTION-CONTEXTUAL_MENU, UIP-FEEDBACK-EMPTY_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-MEDIA_CONTENT, SHP-PORTAL, SHP-TRANSACTIONAL_COMMERCE.

**Compatibilidade Secundária**: SHP-WORKSPACE_ADMIN.

**Incompatibilidades explícitas**: SHP-COMMUNICATION como shell dominante.

## Estrutura e Transição

**Estrutura Desktop**: cabeçalho de busca e filtros com grade ou lista de itens.

**Estrutura Mobile**: busca e filtros compactos com coleção em scroll contínuo ou paginação simplificada.

**Regra de transição**: preservar descoberta, ordem e refinamento com compressão das zonas auxiliares.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir entre paginação, scroll progressivo, filtros persistentes ou filtros em overlay.

**Adaptação Mobile nativo**: filtros tendem a virar sheet, modal ou tela dedicada; a coleção preserva a ação primária do item.

**Adaptação Desktop nativo**: pode ativar atalhos, busca global e organização por biblioteca.
