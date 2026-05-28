# UIP-DATA-TREE_VIEW - Tree View

## Definição

**Categoria**: Dados & Listagem

**Definição curta**: Representação hierárquica de itens expansíveis para navegar, selecionar ou operar sobre entidades em árvore.

**Objetivo estrutural**: Apresentar coleções hierárquicas — pastas, categorias, módulos, nós, documentos, permissões ou taxonomias — preservando relação pai/filho, expansão, seleção e ações por nó.

**Não confundir com**: UIP-NAV-NAVIGATION_MENU (destinos globais do shell), UIP-NAV-SECTION_NAV (headings da página atual), UIP-DATA-LIST_ITEM (listagem linear), UIP-DATA-DATA_TABLE (comparação por colunas).

**Nível composicional possível**: Root, Container

## Decisão

**Quando usar**: quando os itens possuem hierarquia real; quando expandir e recolher nós é parte da leitura ou operação; quando o usuário precisa navegar, selecionar, mover, renomear ou comparar relações pai/filho; quando listas planas perderiam contexto estrutural.

**Quando evitar**: quando a hierarquia é rasa e pode ser resolvida por grupos simples; quando a relação principal é comparação por atributos; quando a árvore é apenas navegação global do app; quando a tela pequena não preserva profundidade, foco e ações com clareza.

**Alternativas próximas**: UIP-DATA-LIST_ITEM (listagem linear), UIP-DATA-DATA_TABLE (comparação por colunas), UIP-NAV-NAVIGATION_MENU (navegação global), UIP-NAV-SECTION_NAV (âncoras da página), UIP-STRUCT-COLLAPSIBLE_SECTION (seção expansível).

**Sinais de escolha**:
- existem nós filhos
- expandir e recolher muda a leitura
- nível, indentação, raiz e filhos importam
- seleção de nó altera detalhe, preview ou ações
- o usuário pensa em termos de árvore, pasta, categoria ou estrutura
- dados possuem hierarquia pai/filho com profundidade variável

**Grau de Rigidez**: Médio — hierarquia expansível com nós e folhas é invariante; profundidade, ações por nó e seleção variam.

## Composição

**Zonas usuais**: Navegação, Coleção, Painel Auxiliar.

**Variantes reconhecidas**: árvore simples; árvore com checkbox; árvore com seleção única; árvore com seleção múltipla; árvore com drag/drop; árvore virtualizada; árvore com busca; árvore com lazy loading.

**UI Patterns tipicamente contidos**: UIP-DATA-LIST_ITEM, UIP-INTERACTION-SELECTION, UIP-INTERACTION-DRAG_DROP, UIP-ACTION-CONTEXTUAL_MENU, UIP-INPUT-SEARCH_BAR, UIP-FEEDBACK-EMPTY_STATE.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-DETAIL, PP-CANVAS.

**Compatibilidade Secundária**: PP-SETTINGS, PP-CATALOG, PP-BOARD, PP-FORM.

**Incompatibilidades explícitas**: PP-FEED, PP-CONVERSATION, PP-LANDING (estrutura principal não hierárquica).

## Estrutura e Transição

**Estrutura Desktop**: árvore vertical com indentação, affordance de expandir e recolher, estado de seleção, ícone opcional por tipo de nó e ações contextuais. Pode compor com painel de detalhe ou canvas.

**Estrutura Mobile**: hierarquia profunda vira navegação por stack, drill-down por nível, busca ou árvore simplificada. Expandir inline só é adequado para profundidade curta e alvos de toque claros.

**Regra de Transição**: relação pai/filho e seleção ativa são preservadas. A indentação desktop pode virar níveis navegáveis em mobile; ações por nó podem ir para menu de contexto.

## Estados

**Estados próprios**: nó expandido, nó recolhido, nó selecionado, nó parcialmente selecionado, nó carregando, nó vazio, nó desativado, nó com erro, nó com permissão restrita, árvore filtrada.

**Reação a estados da página**: `loading` → skeleton ou nós carregando. `empty` → ausência de árvore ou nó vazio. `error` → erro localizado no nó ou na árvore. `no-permission` → nós ocultos, bloqueados ou desativados.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir expansão, lazy loading, busca, drag/drop, seleção e integração com painel de detalhe.

**Adaptação Mobile nativo**: preferir stack ou drill-down por nível, busca ou lista filtrada; evitar árvore profunda inline.

**Adaptação Desktop nativo**: pode integrar keyboard flow, drag/drop, menus de contexto, multi-select e painéis acoplados.
