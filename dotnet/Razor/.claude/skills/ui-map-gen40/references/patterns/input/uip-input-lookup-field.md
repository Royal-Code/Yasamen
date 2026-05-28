# UIP-INPUT-LOOKUP_FIELD - Lookup Field

## Definição

**Categoria**: Entrada

**Definição curta**: Campo de busca e seleção de entidade, registro ou referência, normalmente com consulta remota e resultado rico.

**Objetivo estrutural**: Capturar uma referência a entidade externa quando o valor selecionado precisa de identidade, display, busca, permissões ou detalhe contextual.

**Não confundir com**: UIP-INPUT-OPTION_PICKER (opções conhecidas), UIP-INPUT-SEARCH_BAR (localizar conteúdo sem persistir seleção), UIP-DATA-LIST_ITEM (resultado visual).

**Nível composicional possível**: Leaf, Container

## Decisão

**Quando usar**: quando o campo representa cliente, usuário, produto, endereço, documento, recurso ou outra entidade pesquisável; quando resultados vêm de API ou coleção grande; quando a seleção precisa mostrar metadados, avatar, status, código ou detalhe.

**Quando evitar**: quando a lista de opções é pequena e local; quando entrada livre é permitida; quando o usuário só precisa buscar conteúdo, não persistir uma referência; quando a relação deve ser criada em formulário próprio.

**Alternativas próximas**: UIP-INPUT-OPTION_PICKER (opções conhecidas), UIP-INPUT-SEARCH_BAR (busca de conteúdo), UIP-DATA-LIST_ITEM (resultado em lista), UIP-OVERLAY-POPOVER (seleção ancorada), UIP-OVERLAY-MODAL (busca em modal).

**Sinais de escolha**:
- busca remota com resultados ricos
- valor com id e display
- seleção única ou múltipla
- possibilidade de criar novo
- permissões e estados por entidade
- o usuário não conhece todas as opções de antemão

**Grau de Rigidez**: Médio — busca e seleção de entidade remota são invariantes; preview, filtros e apresentação variam.

## Composição

**Zonas usuais**: Conteúdo, Filtros, Overlay.

**Variantes reconhecidas**: autocomplete remoto; search-select; entity picker; async lookup; lookup com criação; multi-lookup; lookup em modal.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD, PP-SETTINGS.

**Compatibilidade Secundária**: PP-LIST-DETAIL, PP-CATALOG, PP-BOARD, PP-MAP.

**Incompatibilidades explícitas**: não usar para opções estáticas simples ou escolha binária.

## Estrutura e Transição

**Estrutura Desktop**: campo de busca com resultados em dropdown, popover ou modal, mostrando label e metadados suficientes para desambiguar.

**Estrutura Mobile**: tela, sheet ou modal de busca quando o dropdown não comporta teclado, resultados e seleção com clareza.

**Regra de Transição**: preservar busca, desambiguação, seleção atual e fallback para sem resultados. O resultado selecionado fica legível mesmo após fechar a busca.

## Estados

**Estados próprios**: vazio, digitando, buscando, com resultados, sem resultados, entidade selecionada, múltiplas entidades selecionadas, carregando detalhe, erro de busca, sem permissão, criando novo.

**Reação a estados da página**: `loading` → indicador de busca ou detalhe. `empty` → sem resultados. `error` → falha de consulta. `no-permission` → entidades restritas ocultas ou desativadas.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir debounce, dropdown, popover ou modal, resultado rico, criação rápida e estados async.

**Adaptação Mobile nativo**: preferir tela ou sheet de busca quando teclado e resultados competem por espaço.

**Adaptação Desktop nativo**: suportar keyboard flow, typeahead, enter para seleção e escape para cancelar.
