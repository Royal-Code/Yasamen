# PP-MAP - Map

## Definição

**Definição curta**: Página orientada a navegação, análise ou operação sobre espaço geográfico.

**Objetivo estrutural**: Sustentar leitura, filtro e ação sobre entidades cuja posição espacial é estruturalmente relevante.

**Interação dominante**: Espacial

**Não confundir com**: PP-CATALOG (coleção filtrável), PP-DASHBOARD (síntese analítica).

## Decisão

**Sinais de escolha**:
- a localização é decisiva
- camadas, áreas, rotas ou pontos
- relação entre proximidade e decisão
- exploração espacial dominante

**Limites**: exige eixo espacial como estrutura principal; não usar quando a localização é apenas atributo textual.

**Grau de Rigidez**: Médio — viewport cartográfico e marcadores são estáveis; camadas, interação e painéis laterais variam por domínio.

## Composição

**Zonas funcionais obrigatórias**: Superfície; Filtros; Detalhe; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-SURFACE-MAP, UIP-INPUT-SEARCH_BAR, UIP-INPUT-FILTER_PANEL, UIP-CONTENT-DETAIL_BLOCK, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-EMPTY_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-MEDIA_CONTENT, SHP-DASHBOARD_ANALYTICS.

**Compatibilidade Secundária**: SHP-WORKSPACE_ADMIN, SHP-KIOSK_EMBEDDED.

**Incompatibilidades explícitas**: SHP-COMMUNICATION como experiência dominante.

## Estrutura e Transição

**Estrutura Desktop**: mapa dominante com overlays, filtros e painel contextual.

**Estrutura Mobile**: mapa de foco único com painéis sobrepostos ou alternáveis.

**Regra de transição**: preservar contexto espacial, controles essenciais e leitura do detalhe selecionado.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir overlay, filtros, busca, detalhe e fallback para viewport pequeno.

**Adaptação Mobile nativo**: considerar permissão de localização, lifecycle, mapa offline ou cache e painéis sobrepostos.

**Adaptação Desktop nativo**: pode ativar múltiplas janelas, atalhos e integração com arquivos ou dados externos.
