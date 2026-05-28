# UIP-DATA-DATA_TABLE - Data Table

## Definição

**Categoria**: Dados & Listagem

**Definição curta**: Representação tabular de coleções com comparação por linha e coluna, normalmente com ações e seleção.

**Objetivo estrutural**: Apresentar coleções de entidades em formato tabular, com ações por linha e seleção múltipla.

**Não confundir com**: UIP-DATA-CARD_GRID (grade exploratória), UIP-DATA-LIST_ITEM (listagem linear simples), UIP-DATA-TREE_VIEW (hierarquia expansível), planilha de edição massiva livre (fora do catálogo).

**Nível composicional possível**: Root, Container

## Decisão

**Quando usar**: quando o usuário precisa comparar múltiplos atributos por linha; quando há seleção em lote, ordenação, filtros e ações operacionais; quando a densidade informacional importa mais que apelo exploratório.

**Quando evitar**: quando a apresentação depende de imagem, identidade visual ou descoberta exploratória; quando a coleção tem poucos atributos e leitura linear simples; quando a relação pai/filho e expansão de nós é central; quando a interação principal é cronológica, conversacional ou editorial.

**Alternativas próximas**: UIP-DATA-CARD_GRID (grade exploratória), UIP-DATA-LIST_ITEM (listagem linear), UIP-DATA-TREE_VIEW (hierarquia expansível), UIP-DATA-KANBAN_COLUMN (board por estado).

**Sinais de escolha**:
- comparação por colunas é relevante
- existem ações por linha ou seleção múltipla
- ordenação e paginação fazem sentido
- a coleção tem estrutura previsível por atributo
- entidade tem 5+ atributos comparáveis entre itens
- densidade informacional é prioridade sobre apelo visual

**Grau de Rigidez**: Médio — zonas header, body e pagination são estáveis; colunas visíveis, expansão e edição inline variam por densidade e plataforma.

## Composição

**Zonas usuais**: Coleção.

**Variantes reconhecidas**: tabela simples; tabela com expansão de linha; tabela com células editáveis inline; tabela virtualizada; tabela com agrupamento.

**UI Patterns tipicamente contidos**: UIP-NAV-PAGINATION, UIP-ACTION-ACTION_BAR, UIP-INTERACTION-SELECTION, UIP-ACTION-CONTEXTUAL_MENU, UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-LOADING_STATE.

**UIPs frequentemente combinados**: UIP-INPUT-FILTER_PANEL, UIP-INPUT-SEARCH_BAR.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL.

**Compatibilidade Secundária**: PP-DASHBOARD.

**Incompatibilidades explícitas**: PP-FEED, PP-CATALOG, PP-CONVERSATION.

## Estrutura e Transição

**Estrutura Desktop**: tabela com cabeçalho fixo, linhas de dados, coluna de ações, checkbox de seleção e ordenação por coluna. Action Bar acima, Pagination abaixo.

**Estrutura Mobile**: representação tabular compacta ou híbrida. Pode reduzir densidade, colapsar colunas secundárias, usar detalhe expandido e redistribuir ações para overflow contextual.

**Regra de Transição**: tabela completa → tabela compacta ou híbrida. Informação crítica e ações essenciais nunca são omitidas; podem ser reorganizadas em formato touch-friendly.

## Estados

**Estados próprios**: vazio, carregando, com resultados, linha selecionada, múltiplas linhas selecionadas, filtro ativo, ordenação ativa, erro.

**Reação a estados da página**: `loading` → skeleton de linhas. `empty` → Empty State dentro da tabela. `error` → mensagem com retry. `no-permission` → tabela oculta ou ações restritas desativadas.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir colunas críticas, overflow, paginação, seleção e comportamento responsivo.

**Adaptação Mobile nativo**: usar lista, card ou drill-down quando a tabela compacta não preservar leitura e ação essenciais.

**Adaptação Desktop nativo**: pode ativar keyboard flow, seleção múltipla, colunas fixas e operações em lote.
