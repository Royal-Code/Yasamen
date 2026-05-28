# UIP-DATA-CARD_GRID - Card Grid

## Definição

**Categoria**: Dados & Listagem

**Definição curta**: Grade de itens visuais para exploração, descoberta e comparação leve entre cards.

**Objetivo estrutural**: Apresentar coleções de itens em formato visual exploratório, com ênfase em imagem ou identidade visual.

**Não confundir com**: UIP-DATA-DATA_TABLE (tabela operacional), UIP-DATA-TREE_VIEW (hierarquia expansível), UIP-DATA-LIST_ITEM (listagem linear), UIP-STRUCT-GRID_CONTAINER (grade apenas estrutural).

**Nível composicional possível**: Root, Container

## Decisão

**Quando usar**: quando a descoberta visual ou a identidade do item ajuda a decisão; quando imagem, ícone ou resumo visual têm peso real; quando a coleção se beneficia de exploração em grade e leitura mais livre.

**Quando evitar**: quando a operação exige comparação densa por atributo; quando há muitas ações complexas por item; quando o contexto é puramente cronológico ou conversacional.

**Alternativas próximas**: UIP-DATA-DATA_TABLE (tabela operacional), UIP-DATA-LIST_ITEM (listagem linear), UIP-DATA-TREE_VIEW (hierarquia expansível), UIP-STRUCT-GRID_CONTAINER (grade estrutural).

**Sinais de escolha**:
- cada item tem representação visual própria
- a coleção é exploratória ou catálogo
- poucos dados estruturados bastam por item
- a navegação parte do reconhecimento visual
- identidade visual forte por item (imagem, cor, ícone)
- poucos atributos por item (2-4) com leitura de reconhecimento
- exploração e descoberta são mais relevantes que comparação tabular

**Grau de Rigidez**: Médio — grade de itens visuais exploráveis é estável; tamanho, conteúdo e interação dos cards variam.

## Composição

**Zonas usuais**: Coleção.

**Variantes reconhecidas**: card com mídia dominante; card compacto informativo; card de ação; card selecionável; grade de densidade variável.

**UI Patterns tipicamente contidos**: UIP-NAV-PAGINATION, UIP-INTERACTION-SELECTION, UIP-ACTION-CONTEXTUAL_MENU, UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-LOADING_STATE.

**UIPs frequentemente combinados**: UIP-INPUT-FILTER_PANEL, UIP-INPUT-SEARCH_BAR, UIP-ACTION-FLOATING_ACTION.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CATALOG.

**Compatibilidade Secundária**: PP-DASHBOARD, PP-FEED.

**Incompatibilidades explícitas**: PP-LIST-DETAIL operacional com ações complexas.

## Estrutura e Transição

**Estrutura Desktop**: grade de cards com 3 a 5 colunas. Card com imagem ou ícone, título, subtítulo, metadado e ação primária.

**Estrutura Mobile**: 1 a 2 colunas. Card compacto com informação essencial.

**Regra de Transição**: redução de colunas. O card pode simplificar conteúdo secundário. Nunca ocultar a ação primária.

## Estados

**Estados próprios**: carregando, sem resultados, com resultados, filtro ativo, card em hover, card selecionado.

**Reação a estados da página**: `loading` → skeleton de cards. `empty` → Empty State na área da grade. `error` → mensagem com retry. `no-permission` → grade oculta ou ações restritas desativadas.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: definir redução de colunas e comportamento de filtros e paginação.

**Adaptação Mobile nativo**: limitar colunas, preservar a ação primária e considerar lista quando os cards ficarem densos.

**Adaptação Desktop nativo**: para bibliotecas ou catálogo visual; pode ativar seleção múltipla e ações de lote.
