# PP-DETAIL - Detail

## Definição

**Definição curta**: Página de visualização estruturada de uma entidade, conteúdo ou artefato específico.

**Objetivo estrutural**: Sustentar leitura, inspeção e ação localizada sobre um objeto singular.

**Interação dominante**: Informativa

**Não confundir com**: PP-LIST-DETAIL (coleção com detalhe sincronizado), PP-LANDING (entrada institucional).

## Decisão

**Sinais de escolha**:
- uma entidade dominante
- leitura de atributos, mídia ou conteúdo
- ações localizadas
- contexto singular
- foco numa entidade ou artefato específico para leitura, inspeção ou operação contextual

**Limites**: não usar quando a página depende de coleção ativa, descoberta contínua ou conversa persistente.

**Grau de Rigidez**: Médio — visualização estruturada de entidade é estável; seções, abas e ações contextuais variam por tipo de entidade.

## Composição

**Zonas funcionais obrigatórias**: Cabeçalho; Detalhe; Ações; Painel Auxiliar.

**UI Patterns tipicamente obrigatórios**: UIP-CONTENT-CONTENT_HEADER, UIP-CONTENT-DETAIL_BLOCK, UIP-CONTENT-RICH_TEXT_BLOCK ou UIP-CONTENT-MEDIA_VIEWER, UIP-ACTION-ACTION_BAR, UIP-NAV-BREADCRUMB, UIP-FEEDBACK-LOADING_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-PORTAL, SHP-MEDIA_CONTENT, SHP-TRANSACTIONAL_COMMERCE.

**Compatibilidade Secundária**: SHP-STUDIO_WORKBENCH, SHP-DASHBOARD_ANALYTICS.

**Incompatibilidades explícitas**: Nenhuma.

## Estrutura e Transição

**Estrutura Desktop**: cabeçalho e corpo de detalhe com seções estruturadas.

**Estrutura Mobile**: leitura em coluna única com ações compactadas.

**Regra de transição**: preservar o agrupamento da informação e a visibilidade da ação principal.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir breadcrumb, ações, seções, mídia e responsividade de conteúdo.

**Adaptação Mobile nativo**: usar stack para retorno; ações secundárias podem ir para menu ou sheet.

**Adaptação Desktop nativo**: pode integrar com inspectors, painéis persistentes e foco por teclado.
