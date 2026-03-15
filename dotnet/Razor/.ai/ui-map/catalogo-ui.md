# Catalogo Global de UI Patterns

> Heuristica Visual (Frontend)
> Destinado prioritariamente a orquestracao por IA, podendo ser auditado por humanos.

[INSTRUÇÃO]
Todos os UI Patterns deste catálogo possuem agora um **ID_UI_PATTERN canônico global obrigatório**.

Formato oficial:

```
UIP-<GRUPO>-<NOME_CANONICO>
```

Onde:
- `<GRUPO>` corresponde ao grupo estrutural do padrão (STRUCT, NAV, DATA, INPUT, FEEDBACK, ACTION, CONTENT)
- `<NOME_CANONICO>` corresponde ao Nome do padrão em formato normalizado (MAIÚSCULO, underscore)

Exemplos:
- Layout Zone → UIP-STRUCT-LAYOUT_ZONE
- Data Table → UIP-DATA-DATA_TABLE
- Action Bar → UIP-ACTION-ACTION_BAR
- Empty State → UIP-FEEDBACK-EMPTY_STATE

[INSTRUÇÃO]
O campo **ID_UI_PATTERN** passa a ser considerado campo obrigatório implícito de todos os padrões abaixo.
Para efeitos de rastreabilidade em D008, no mapping de biblioteca e em C3/C4, a IA deve sempre referenciar o padrão pelo seu ID_UI_PATTERN.

Nenhum ID pode ser redefinido por projecto.
A alteração de um ID_UI_PATTERN exige versionamento deste catálogo.

---

# Como Ler Este Catálogo

Cada UI Pattern declara os seguintes campos obrigatórios:

- **ID_UI_PATTERN** — identificador canônico global (conforme regra acima)
- **Nome** — identificador canónico do padrão
- **Categoria** — grupo funcional ao qual pertence
- **Objetivo estrutural** — o que este padrão resolve estruturalmente
- **Nível composicional possível** — Root / Container / Leaf, contextual
- **Compatibilidade Primária** — Page Patterns onde este padrão é tipicamente obrigatório
- **Compatibilidade Secundária** — Page Patterns onde pode aparecer condicionalmente
- **Incompatibilidades explícitas** — Page Patterns onde este padrão não deve ser usado
- **Estrutura Desktop** — organização espacial em Desktop
- **Estrutura Mobile** — organização em Mobile
- **Regra de Transição** — o que muda e o que não muda entre Desktop e Mobile
- **Estados próprios** — estados do padrão do ponto de vista do utilizador
- **Reação a estados da página** — como este padrão reage aos estados definidos no D007
- **Grau de Rigidez** — Alto (estrutura fixa), Médio (variações declaradas), Baixo (adaptável por contexto)

---

# Grupo 1 — Estruturais

Organizam o espaço da página. Não têm conteúdo próprio — contêm outros UI Patterns.

---

## Layout Zone

**ID_UI_PATTERN:** UIP-STRUCT-LAYOUT_ZONE
**Categoria:** Estrutural
**Objetivo estrutural:** Delimitar uma área funcional da página com responsabilidade distinta. Âncora que agrupa os UI Patterns de uma zona.
**Nível composicional possível:** Root, Container
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Nenhuma
**Estrutura Desktop:** Área rectangular com dimensões definidas pela zona funcional. Pode ser fixa ou flexível conforme conteúdo.
**Estrutura Mobile:** Ocupa largura total. Empilhamento vertical entre zonas.
**Regra de Transição:** Layout lateral → empilhamento vertical. Zonas simultâneas → zonas sequenciais navegáveis quando necessário.
**Estados próprios:** activa, colapsada, oculta (por permissão ou contexto)
**Reação a estados da página:** Empty State → exibe conteúdo de zona vazia. Loading State → exibe Loading State interno. Error State → exibe Error State interno. No Permission State → zona oculta ou bloqueada.
**Grau de Rigidez:** Baixo

---

## Split Panel

**ID_UI_PATTERN:** UIP-STRUCT-SPLIT_PANEL
**Categoria:** Estrutural
**Objetivo estrutural:** Dividir a área principal em dois painéis com responsabilidades distintas e simultâneas.
**Nível composicional possível:** Root, Container
**Compatibilidade Primária:** List+Detail, Conversation
**Compatibilidade Secundária:** Settings, Detail/Viewer
**Incompatibilidades explícitas:** Form, Wizard/Stepper, Landing/Content
**Estrutura Desktop:** Dois painéis lado a lado. Primário à esquerda (listagem/navegação), secundário à direita (detalhe/conteúdo). Divisor ajustável opcional.
**Estrutura Mobile:** Painéis alternam — apenas um visível de cada vez. Navegação entre painéis por acção do utilizador.
**Regra de Transição:** Simultaneidade → sequência. Painel secundário vazio → exibe estado "nenhum item seleccionado".
**Estados próprios:** painel primário em foco, painel secundário em foco, painel secundário colapsado, painel secundário vazio
**Reação a estados da página:** Loading State → cada painel exibe Loading State independente. Empty State → painel secundário exibe Empty State. Error State → painel afectado exibe Error State localizado.
**Grau de Rigidez:** Médio

---

## Scrollable Region

**ID_UI_PATTERN:** UIP-STRUCT-SCROLLABLE_REGION
**Categoria:** Estrutural
**Objetivo estrutural:** Delimitar uma área com scroll independente do restante da página.
**Nível composicional possível:** Container
**Compatibilidade Primária:** Feed/Timeline, Conversation
**Compatibilidade Secundária:** List+Detail, Catalog/Grid, Detail/Viewer
**Incompatibilidades explícitas:** Form simples, Landing/Content
**Estrutura Desktop:** Área com altura definida e scroll vertical interno. Largura determinada pela zona pai.
**Estrutura Mobile:** Scroll nativo da região. Altura pode expandir para viewport completa em contextos de foco único.
**Regra de Transição:** Comportamento de scroll preservado. Altura pode expandir para viewport em Mobile.
**Estados próprios:** conteúdo disponível, a carregar mais conteúdo, fim do conteúdo, erro ao carregar mais
**Reação a estados da página:** Loading State → indicador no topo ou fundo da região. Empty State → conteúdo de zona vazia centrado.
**Grau de Rigidez:** Baixo

---

## Stack Container

**ID_UI_PATTERN:** UIP-STRUCT-STACK_CONTAINER
**Categoria:** Estrutural
**Objetivo estrutural:** Organizar UI Patterns em sequência vertical com espaçamento consistente.
**Nível composicional possível:** Container
**Compatibilidade Primária:** Form, Settings, Wizard/Stepper
**Compatibilidade Secundária:** Detail/Viewer, Dashboard
**Incompatibilidades explícitas:** Nenhuma explícita
**Estrutura Desktop:** Coluna vertical. Espaçamento uniforme entre elementos filhos. Largura determinada pela zona pai.
**Estrutura Mobile:** Comportamento preservado. Espaçamento pode ser reduzido.
**Regra de Transição:** Estrutura mantida. Ajuste de espaçamento e padding lateral.
**Estados próprios:** normal, com erro em filho (herda visibilidade de erro do filho)
**Reação a estados da página:** Loading State → substitui conteúdo por Loading State. Empty State → exibe zona vazia se todos os filhos estiverem vazios.
**Grau de Rigidez:** Baixo

---

## Grid Container

**ID_UI_PATTERN:** UIP-STRUCT-GRID_CONTAINER
**Categoria:** Estrutural
**Objetivo estrutural:** Organizar UI Patterns em grelha de múltiplas colunas.
**Nível composicional possível:** Container
**Compatibilidade Primária:** Catalog/Grid, Dashboard
**Compatibilidade Secundária:** Feed/Timeline, Landing/Content
**Incompatibilidades explícitas:** Form, Wizard/Stepper, Conversation
**Estrutura Desktop:** Grelha de N colunas (declarado por contexto). Espaçamento uniforme. Itens de largura igual ou proporcional.
**Estrutura Mobile:** Redução de colunas — tipicamente para 1 ou 2. Empilhamento progressivo conforme breakpoint.
**Regra de Transição:** N colunas Desktop → M colunas Mobile (M < N). Nunca alterar ordem dos itens.
**Estados próprios:** normal, a carregar (skeleton), vazio, filtro activo
**Reação a estados da página:** Loading State → skeleton da grelha completa. Empty State → exibe Empty State centrado. Error State → exibe Error State.
**Grau de Rigidez:** Médio

---

# Grupo 2 — Navegação

---

## Navigation Menu

**ID_UI_PATTERN:** UIP-NAV-NAVIGATION_MENU
**Categoria:** Navegação
**Objetivo estrutural:** Acesso estruturado aos módulos e secções do sistema. Âncora de navegação global.
**Nível composicional possível:** Root
**Compatibilidade Primária:** Todos os Shells
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Nenhuma — elemento global
**Estrutura Desktop:** Sidebar vertical (Workspace/Admin) ou barra superior (Portal). Itens hierárquicos com agrupamento por módulo.
**Estrutura Mobile:** Bottom navigation bar (até 5 itens principais) ou menu gaveta (hamburger). Itens secundários via gaveta.
**Regra de Transição:** Sidebar/barra → bottom bar ou gaveta. Hierarquia de itens preservada.
**Estados próprios:** item activo, item inactivo, item com badge/notificação, item desactivado, menu expandido, menu colapsado
**Reação a estados da página:** No Permission State → item oculto ou desactivado conforme permissão do módulo.
**Grau de Rigidez:** Alto

---

## Breadcrumb

**ID_UI_PATTERN:** UIP-NAV-BREADCRUMB
**Categoria:** Navegação
**Objetivo estrutural:** Orientar o utilizador na hierarquia de navegação actual e permitir retorno a níveis anteriores.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** List+Detail, Detail/Viewer
**Compatibilidade Secundária:** Catalog/Grid, Settings
**Incompatibilidades explícitas:** Dashboard, Landing/Content, Feed/Timeline
**Estrutura Desktop:** Linha horizontal de itens separados por separador. Item actual destacado e não clicável. Itens anteriores clicáveis.
**Estrutura Mobile:** Truncagem dos níveis intermediários. Exibe apenas nível anterior e actual, ou só o anterior como link de retorno.
**Regra de Transição:** Hierarquia completa → versão compacta. Nunca ocultar o nível actual.
**Estados próprios:** nível actual (não navegável), nível anterior (navegável), nível truncado
**Reação a estados da página:** Loading State → itens em skeleton até navegação estar definida.
**Grau de Rigidez:** Alto

---

## Tabs

**ID_UI_PATTERN:** UIP-NAV-TABS
**Categoria:** Navegação
**Objetivo estrutural:** Alternar entre vistas ou secções dentro da mesma página sem navegação de rota.
**Nível composicional possível:** Container
**Compatibilidade Primária:** Detail/Viewer, Settings
**Compatibilidade Secundária:** Dashboard, List+Detail
**Incompatibilidades explícitas:** Wizard/Stepper, Feed/Timeline
**Estrutura Desktop:** Barra de tabs horizontal no topo da zona. Conteúdo da tab activa abaixo.
**Estrutura Mobile:** Tabs horizontais com scroll lateral se exceder largura. Alternativa: selector dropdown para muitas tabs.
**Regra de Transição:** Barra horizontal preservada. Scroll lateral em Mobile. Nunca colapsar tabs em menu oculto sem alternativa visível.
**Estados próprios:** tab activa, tab inactiva, tab com badge/contagem, tab desactivada, tab com erro
**Reação a estados da página:** Loading State → conteúdo da tab activa em loading. Error State → tab com erro sinalizada.
**Grau de Rigidez:** Médio

---

## Pagination

**ID_UI_PATTERN:** UIP-NAV-PAGINATION
**Categoria:** Navegação
**Objetivo estrutural:** Navegar entre páginas de um conjunto de resultados volumoso.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** List+Detail, Catalog/Grid
**Compatibilidade Secundária:** Data Table (componente interno)
**Incompatibilidades explícitas:** Feed/Timeline, Conversation
**Estrutura Desktop:** Barra horizontal com botões anterior, próxima, primeira, última e páginas numeradas. Indicador de página actual e total.
**Estrutura Mobile:** Simplificado — botões anterior e próxima com indicador de página actual.
**Regra de Transição:** Paginação completa → paginação simplificada. Páginas numeradas omitidas em Mobile.
**Estados próprios:** página actual, anterior disponível, próxima disponível, primeira página, última página, a carregar
**Reação a estados da página:** Loading State → botões desactivados durante carregamento.
**Grau de Rigidez:** Alto

---

## Stepper Indicator

**ID_UI_PATTERN:** UIP-NAV-STEPPER_INDICATOR
**Categoria:** Navegação
**Objetivo estrutural:** Indicar progresso e posição num fluxo multi-etapas com sequência obrigatória.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Wizard/Stepper
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Todos os outros Page Patterns
**Estrutura Desktop:** Barra horizontal com etapas numeradas ou nomeadas. Etapa actual destacada. Etapas concluídas marcadas.
**Estrutura Mobile:** Versão compacta — etapa actual e total (ex: "Passo 2 de 5").
**Regra de Transição:** Indicador completo → indicador compacto com contagem. Nunca omitir etapa actual.
**Estados próprios:** etapa actual, etapa concluída, etapa futura, etapa com erro, etapa desactivada
**Reação a estados da página:** Error State → etapa com erro sinalizada. Loading State → etapa em processamento indicada.
**Grau de Rigidez:** Alto

---

# Grupo 3 — Dados & Listagem

---

## Data Table

**ID_UI_PATTERN:** UIP-DATA-DATA_TABLE
**Categoria:** Dados & Listagem
**Objetivo estrutural:** Apresentar colecções de entidades em formato tabular com acções por linha e selecção múltipla.
**Nível composicional possível:** Root, Container (contém Action Bar, Pagination)
**Compatibilidade Primária:** List+Detail
**Compatibilidade Secundária:** Dashboard
**Incompatibilidades explícitas:** Feed/Timeline, Catalog/Grid, Conversation
**Estrutura Desktop:** Tabela com cabeçalho fixo, linhas de dados, coluna de acções, checkbox de selecção, ordenação por coluna clicável. Action Bar acima. Pagination abaixo.
**Estrutura Mobile:** Colapso de colunas — apenas colunas prioritárias. Linha expansível para atributos secundários. Acções por linha em menu gaveta.
**Regra de Transição:** Tabela completa → tabela compacta com colunas prioritárias. Nunca omitir acções — reorganizar para menu gaveta.
**Estados próprios:** vazio, a carregar, com resultados, linha seleccionada, múltiplas linhas seleccionadas, filtro activo, ordenação activa, erro
**Reação a estados da página:** Empty State → exibe Empty State dentro da tabela. Loading State → skeleton de linhas. Error State → mensagem com retry. No Permission State → tabela oculta ou sem acções restritas.
**Grau de Rigidez:** Médio
**Variantes reconhecidas:**
- Data Table com expansão de linha — linha expansível com detalhe inline
- Data Table editável — células editáveis inline sem Form separado

---

## List Item

**ID_UI_PATTERN:** UIP-DATA-LIST_ITEM
**Categoria:** Dados & Listagem
**Objetivo estrutural:** Representar um item individual dentro de uma lista simples.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Navigation Menu, resultados de Search Bar
**Compatibilidade Secundária:** Todos os Page Patterns como unidade em listas simples
**Incompatibilidades explícitas:** Não substitui Data Table em colecções com múltiplos atributos
**Estrutura Desktop:** Linha horizontal com ícone/avatar opcional, título, subtítulo opcional, metadado secundário, acção contextual.
**Estrutura Mobile:** Estrutura preservada. Metadados secundários podem ser omitidos. Área de toque ampliada.
**Regra de Transição:** Layout preservado. Redução de informação secundária. Área de toque nunca inferior a 44px.
**Estados próprios:** normal, hover, seleccionado, desactivado, com badge/notificação
**Reação a estados da página:** Loading State → skeleton do item.
**Grau de Rigidez:** Baixo

---

## Card Grid

**ID_UI_PATTERN:** UIP-DATA-CARD_GRID
**Categoria:** Dados & Listagem
**Objetivo estrutural:** Apresentar colecções de itens em formato visual exploratório com ênfase em imagem ou identidade visual.
**Nível composicional possível:** Root, Container
**Compatibilidade Primária:** Catalog/Grid
**Compatibilidade Secundária:** Dashboard, Feed/Timeline
**Incompatibilidades explícitas:** List+Detail operacional com acções complexas
**Estrutura Desktop:** Grelha de cards com 3 a 5 colunas. Card com imagem/ícone, título, subtítulo, metadado, acção primária.
**Estrutura Mobile:** 1 a 2 colunas. Card compacto com informação essencial.
**Regra de Transição:** Redução de colunas. Card pode simplificar conteúdo secundário. Nunca ocultar acção primária.
**Estados próprios:** a carregar (skeleton), sem resultados, com resultados, filtro activo, card hover, card seleccionado
**Reação a estados da página:** Empty State → exibe Empty State na área da grelha. Loading State → skeleton de cards. Error State → mensagem com retry.
**Grau de Rigidez:** Médio

---

## Timeline Item

**ID_UI_PATTERN:** UIP-DATA-TIMELINE_ITEM
**Categoria:** Dados & Listagem
**Objetivo estrutural:** Representar um evento ou entrada num feed cronológico ou histórico de actividade.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Feed/Timeline
**Compatibilidade Secundária:** Dashboard, Detail/Viewer
**Incompatibilidades explícitas:** List+Detail operacional, Catalog/Grid
**Estrutura Desktop:** Linha com indicador de tempo, avatar/ícone, conteúdo principal, acções inline.
**Estrutura Mobile:** Estrutura preservada. Acções por gesto longo ou menu contextual.
**Regra de Transição:** Layout preservado com ajuste de espaçamento. Acções inline → menu contextual.
**Estados próprios:** normal, não lido/novo, expandido, colapsado, com acção em progresso, erro
**Reação a estados da página:** Loading State → skeleton do item.
**Grau de Rigidez:** Baixo

---

## Kanban Column

**ID_UI_PATTERN:** UIP-DATA-KANBAN_COLUMN
**Categoria:** Dados & Listagem
**Objetivo estrutural:** Agrupar e apresentar itens por categoria/estado em formato de coluna arrastável.
**Nível composicional possível:** Container
**Compatibilidade Primária:** List+Detail (variante Kanban/Board)
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Dashboard, Feed/Timeline, Catalog/Grid
**Estrutura Desktop:** Colunas horizontais com scroll vertical interno. Cabeçalho com nome e contagem. Itens arrastáveis entre colunas.
**Estrutura Mobile:** Uma coluna visível de cada vez com navegação horizontal. Drag-and-drop substituído por acção de menu.
**Regra de Transição:** Múltiplas colunas simultâneas → coluna única com navegação. Arrastar → acção de menu.
**Estados próprios:** normal, em destaque (item a ser solto), vazia, com limite atingido
**Reação a estados da página:** Loading State → skeleton das colunas. Empty State → coluna vazia com CTA de criação.
**Grau de Rigidez:** Médio

---

# Grupo 4 — Entrada

---

## Form Field Group

**ID_UI_PATTERN:** UIP-INPUT-FORM_FIELD_GROUP
**Categoria:** Entrada
**Objetivo estrutural:** Agrupar campos de entrada relacionados numa secção lógica com validação e feedback.
**Nível composicional possível:** Container, Leaf
**Compatibilidade Primária:** Form, Settings, Wizard/Stepper
**Compatibilidade Secundária:** Detail/Viewer (edição inline de secção)
**Incompatibilidades explícitas:** Não substitui Filter Panel em contexto de filtros
**Estrutura Desktop:** Secção com título opcional, campos em 1 ou 2 colunas, validação inline abaixo de cada campo.
**Estrutura Mobile:** Campos em coluna única. Títulos preservados. Teclado nativo considerado no layout.
**Regra de Transição:** 2 colunas → 1 coluna. Campos em largura completa. Validação inline preservada.
**Estados próprios:** vazio, preenchendo, válido, com erro de validação, desactivado, somente leitura, a submeter
**Reação a estados da página:** Error State (submissão) → campos com erro destacados. Loading State (submissão) → campos desactivados.
**Grau de Rigidez:** Médio

---

## Search Bar

**ID_UI_PATTERN:** UIP-INPUT-SEARCH_BAR
**Categoria:** Entrada
**Objetivo estrutural:** Capturar termos de busca textual e iniciar pesquisa em colecção.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Catalog/Grid, List+Detail
**Compatibilidade Secundária:** Feed/Timeline, Dashboard
**Incompatibilidades explícitas:** Form, Wizard/Stepper
**Estrutura Desktop:** Campo de texto com ícone de busca, botão de limpar, sugestões dropdown opcionais.
**Estrutura Mobile:** Campo expandido para largura total. Sugestões em overlay em contextos complexos.
**Regra de Transição:** Campo preservado. Sugestões → overlay. Botão de cancelar visível em Mobile.
**Estados próprios:** vazio/inactivo, digitando, buscando, com resultados, sem resultados, com sugestões visíveis
**Reação a estados da página:** Loading State (busca) → indicador de progresso no campo.
**Grau de Rigidez:** Médio

---

## Filter Panel

**ID_UI_PATTERN:** UIP-INPUT-FILTER_PANEL
**Categoria:** Entrada
**Objetivo estrutural:** Filtrar colecções por múltiplos atributos estruturados com aplicação explícita ou reactiva.
**Nível composicional possível:** Container
**Compatibilidade Primária:** List+Detail, Catalog/Grid
**Compatibilidade Secundária:** Dashboard
**Incompatibilidades explícitas:** Form, Wizard/Stepper, Conversation
**Estrutura Desktop:** Painel lateral ou área superior com filtros por atributo. Botão de aplicar ou reactivo. Indicador de filtros activos. Opção de limpar todos.
**Estrutura Mobile:** Filtros em drawer/gaveta ou modal. Botão de filtro na página com indicador de activos.
**Regra de Transição:** Painel visível → gaveta ou modal. Indicador de filtros activos sempre visível.
**Estados próprios:** sem filtros activos, com filtros activos, a aplicar filtros, resultados filtrados
**Reação a estados da página:** Loading State → filtros desactivados durante carregamento.
**Grau de Rigidez:** Médio

---

## Date Picker

**ID_UI_PATTERN:** UIP-INPUT-DATE_PICKER
**Categoria:** Entrada
**Objetivo estrutural:** Capturar data ou intervalo de datas de forma estruturada.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Form, Filter Panel
**Compatibilidade Secundária:** Settings
**Incompatibilidades explícitas:** Nenhuma fora de contexto de entrada
**Estrutura Desktop:** Campo de texto com ícone de calendário. Calendário em dropdown. Navegação por mês/ano. Selecção de intervalo opcional.
**Estrutura Mobile:** Calendário em modal ou sheet. Picker nativo como alternativa.
**Regra de Transição:** Dropdown → modal ou sheet. Picker nativo pode substituir calendário custom em Mobile.
**Estados próprios:** vazio, com data seleccionada, com intervalo seleccionado, data inválida, data desactivada, calendário aberto
**Reação a estados da página:** Error State → campo com mensagem de data inválida ou obrigatória.
**Grau de Rigidez:** Médio

---

## Inline Editor

**ID_UI_PATTERN:** UIP-INPUT-INLINE_EDITOR
**Categoria:** Entrada
**Objetivo estrutural:** Permitir edição de um valor directamente no local onde é exibido, sem abrir Form separado.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Detail/Viewer, List+Detail (variante Data Table editável)
**Compatibilidade Secundária:** Settings
**Incompatibilidades explícitas:** Edição de múltiplos campos relacionados — usar Form Field Group
**Estrutura Desktop:** Campo activado por clique/duplo clique. Confirmação por Enter ou blur. Cancelamento por Escape.
**Estrutura Mobile:** Activação por toque. Campo com botões de confirmar/cancelar explícitos.
**Regra de Transição:** Activação implícita → botões explícitos em Mobile.
**Estados próprios:** exibindo valor, em edição, a guardar, guardado, com erro de validação
**Reação a estados da página:** Loading State (guardar) → campo desactivado com indicador.
**Grau de Rigidez:** Baixo

---

# Grupo 5 — Feedback & Estado

---

## Empty State

**ID_UI_PATTERN:** UIP-FEEDBACK-EMPTY_STATE
**Categoria:** Feedback & Estado
**Objetivo estrutural:** Comunicar ausência de dados e orientar o utilizador para o próximo passo.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Não substitui Error State quando o motivo é falha técnica
**Estrutura Desktop:** Área centrada com ícone/ilustração, título, subtítulo opcional, CTA quando aplicável.
**Estrutura Mobile:** Estrutura preservada. Ilustração pode simplificar. CTA em destaque.
**Regra de Transição:** Layout centrado preservado.
**Estados próprios:** sem dados (com CTA quando aplicável), sem resultados para filtro ou busca activa
**Reação a estados da página:** Substitui conteúdo quando dados estão ausentes.
**Grau de Rigidez:** Baixo

---

## Loading State

**ID_UI_PATTERN:** UIP-FEEDBACK-LOADING_STATE
**Categoria:** Feedback & Estado
**Objetivo estrutural:** Indicar que dados ou acção estão em progresso.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Nenhuma
**Estrutura Desktop:** Skeleton da área de conteúdo esperada (preferencial) ou spinner centrado.
**Estrutura Mobile:** Skeleton preservado. Spinner como alternativa em áreas pequenas.
**Regra de Transição:** Skeleton preservado em ambas as plataformas.
**Estados próprios:** carregamento inicial, carregamento parcial (scroll progressivo), carregamento de acção (overlay ou inline)
**Reação a estados da página:** Activo durante qualquer estado de carregamento.
**Grau de Rigidez:** Médio

---

## Error State

**ID_UI_PATTERN:** UIP-FEEDBACK-ERROR_STATE
**Categoria:** Feedback & Estado
**Objetivo estrutural:** Comunicar falha técnica e oferecer caminho claro de recuperação.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Não substitui Empty State quando há ausência de dados sem erro
**Estrutura Desktop:** Área com ícone de erro, título descritivo, subtítulo opcional, acção de retry ou alternativa.
**Estrutura Mobile:** Estrutura preservada. CTA de retry em destaque.
**Regra de Transição:** Layout preservado.
**Estados próprios:** erro de carregamento (com retry), erro de submissão, erro de permissão, erro de não encontrado, erro de rede
**Reação a estados da página:** Substitui conteúdo quando carregamento falha. Inline quando acção falha.
**Grau de Rigidez:** Médio

---

## Toast / Alert

**ID_UI_PATTERN:** UIP-FEEDBACK-TOAST_ALERT
**Categoria:** Feedback & Estado
**Objetivo estrutural:** Notificar o utilizador de resultado de acção ou evento do sistema de forma não bloqueante.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Não substitui Confirmation Dialog para acções que exigem confirmação prévia
**Estrutura Desktop:** Notificação flutuante no canto superior direito ou inferior. Ícone de tipo, mensagem, fechar, acção secundária opcional. Auto-dismiss com timer.
**Estrutura Mobile:** Notificação na parte inferior. Largura total ou quase total.
**Regra de Transição:** Posição superior direita → posição inferior. Largura adapta-se.
**Estados próprios:** sucesso, aviso, erro, informação, a desaparecer
**Reação a estados da página:** Independente do estado da página — aparece após acção ou evento.
**Grau de Rigidez:** Alto

---

## Confirmation Dialog

**ID_UI_PATTERN:** UIP-FEEDBACK-CONFIRMATION_DIALOG
**Categoria:** Feedback & Estado
**Objetivo estrutural:** Solicitar confirmação explícita antes de acção irreversível ou de alto impacto.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Não usar para acções reversíveis sem risco
**Estrutura Desktop:** Modal centrado com título, descrição do impacto, botão de confirmação (destrutivo quando aplicável) e cancelar. Overlay no fundo.
**Estrutura Mobile:** Sheet de baixo para cima ou modal compacto. Botões empilhados — cancelar acima, confirmar abaixo.
**Regra de Transição:** Modal centrado → sheet ou modal compacto. Ordem dos botões invertida em Mobile.
**Estados próprios:** aberto aguardando decisão, a processar após confirmação, fechado
**Reação a estados da página:** Bloqueia interacção com a página. Loading State após confirmação enquanto processa.
**Grau de Rigidez:** Alto

---

# Grupo 6 — Ação

---

## Action Bar

**ID_UI_PATTERN:** UIP-ACTION-ACTION_BAR
**Categoria:** Ação
**Objetivo estrutural:** Expor acções disponíveis sobre item seleccionado, selecção múltipla ou sobre a página.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** List+Detail, Detail/Viewer, Form
**Compatibilidade Secundária:** Dashboard, Settings
**Incompatibilidades explícitas:** Não substitui Contextual Menu para acções por linha
**Estrutura Desktop:** Barra horizontal com botões primários e secundários. Acções destrutivas separadas ou à direita. Acções de selecção múltipla visíveis quando itens seleccionados.
**Estrutura Mobile:** Acções primárias visíveis. Secundárias em overflow (três pontos). Barra pode ser fixa no fundo em detalhe.
**Regra de Transição:** Todas visíveis → primárias visíveis + overflow. Nunca ocultar acção primária.
**Estados próprios:** acções disponíveis, acções desactivadas (sem selecção ou permissão), acção em progresso, acção concluída
**Reação a estados da página:** Loading State → acções desactivadas. No Permission State → acções restritas ocultas ou desactivadas.
**Grau de Rigidez:** Médio

---

## Contextual Menu

**ID_UI_PATTERN:** UIP-ACTION-CONTEXTUAL_MENU
**Categoria:** Ação
**Objetivo estrutural:** Expor acções disponíveis sobre um item específico sem ocupar espaço permanente.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** List+Detail, Catalog/Grid
**Compatibilidade Secundária:** Feed/Timeline
**Incompatibilidades explícitas:** Não substitui Action Bar para acções globais de página
**Estrutura Desktop:** Dropdown por ícone de três pontos ou clique direito. Lista com separadores. Destrutivas no final.
**Estrutura Mobile:** Sheet de baixo para cima. Botão de cancelar explícito.
**Regra de Transição:** Dropdown → sheet. Acções e agrupamentos preservados.
**Estados próprios:** fechado, aberto, item disponível, item desactivado, item destrutivo
**Reação a estados da página:** No Permission State → acções restritas ocultas ou desactivadas.
**Grau de Rigidez:** Médio

---

## Floating Action

**ID_UI_PATTERN:** UIP-ACTION-FLOATING_ACTION
**Categoria:** Ação
**Objetivo estrutural:** Destacar a acção primária mais importante da página de forma sempre acessível.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Feed/Timeline, Catalog/Grid
**Compatibilidade Secundária:** List+Detail, Dashboard
**Incompatibilidades explícitas:** Form, Wizard/Stepper, Settings
**Estrutura Desktop:** Botão circular ou estendido fixo no canto inferior direito. Ícone com rótulo opcional.
**Estrutura Mobile:** Botão circular fixo no canto inferior direito, acima de bottom navigation. Mínimo 56px.
**Regra de Transição:** Posição e comportamento preservados. Rótulo pode ser omitido se ícone for descritivo.
**Estados próprios:** normal, hover/focus, a processar, desactivado
**Reação a estados da página:** Loading State → desactivado. No Permission State → oculto.
**Grau de Rigidez:** Alto

---

# Grupo 7 — Conteúdo

---

## Detail Block

**ID_UI_PATTERN:** UIP-CONTENT-DETAIL_BLOCK
**Categoria:** Conteúdo
**Objetivo estrutural:** Apresentar atributos e metadados de uma entidade específica de forma estruturada.
**Nível composicional possível:** Container, Leaf
**Compatibilidade Primária:** List+Detail, Detail/Viewer
**Compatibilidade Secundária:** Dashboard
**Incompatibilidades explícitas:** Feed/Timeline, Landing/Content
**Estrutura Desktop:** Secções com rótulo e valor lado a lado ou em coluna. Agrupamento lógico. Separadores entre grupos. Edição por secção opcional.
**Estrutura Mobile:** Rótulo e valor em coluna única. Espaçamento aumentado. Edição com botão explícito.
**Regra de Transição:** Duas colunas → coluna única. Agrupamento preservado.
**Estados próprios:** a carregar, com dados, sem dados, em edição, a guardar, erro
**Reação a estados da página:** Loading State → skeleton dos atributos. Error State → mensagem com retry. Not Found State → mensagem de entidade não encontrada.
**Grau de Rigidez:** Médio

---

## Metric Card

**ID_UI_PATTERN:** UIP-CONTENT-METRIC_CARD
**Categoria:** Conteúdo
**Objetivo estrutural:** Apresentar um indicador, KPI ou métrica de forma destacada e de leitura rápida.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Dashboard
**Compatibilidade Secundária:** Detail/Viewer
**Incompatibilidades explícitas:** Form, Wizard/Stepper, Conversation
**Estrutura Desktop:** Card com valor principal grande, rótulo, variação (positiva/negativa), período de referência, sparkline opcional.
**Estrutura Mobile:** Card compacto com valor e rótulo. Variação preservada. Sparkline opcional omitida.
**Regra de Transição:** Card preservado com possível simplificação de elementos secundários.
**Estados próprios:** com dados, a carregar, sem dados, variação positiva, variação negativa, variação neutra, erro
**Reação a estados da página:** Loading State → skeleton do card. Error State → indicador de erro. Empty State → "--" ou sem dados.
**Grau de Rigidez:** Médio

---

## Rich Text Block

**ID_UI_PATTERN:** UIP-CONTENT-RICH_TEXT_BLOCK
**Categoria:** Conteúdo
**Objetivo estrutural:** Apresentar conteúdo editorial ou documental de formato livre com suporte a formatação.
**Nível composicional possível:** Leaf
**Compatibilidade Primária:** Detail/Viewer, Landing/Content
**Compatibilidade Secundária:** Feed/Timeline, Settings
**Incompatibilidades explícitas:** Dashboard
**Estrutura Desktop:** Área com tipografia editorial. Headings, parágrafos, listas, imagens inline, links. Largura máxima de leitura confortável.
**Estrutura Mobile:** Largura total com padding lateral. Tipografia ajustada. Imagens responsivas.
**Regra de Transição:** Largura máxima → largura total com padding. Tipografia preservada em proporção.
**Estados próprios:** a carregar, com conteúdo, sem conteúdo, erro de carregamento
**Reação a estados da página:** Loading State → skeleton de parágrafos. Error State → mensagem com retry.
**Grau de Rigidez:** Baixo

---

## Media Viewer

**ID_UI_PATTERN:** UIP-CONTENT-MEDIA_VIEWER
**Categoria:** Conteúdo
**Objetivo estrutural:** Apresentar e controlar conteúdo multimédia — imagem, vídeo, documento ou ficheiro.
**Nível composicional possível:** Leaf, Container (galeria com múltiplos viewers)
**Compatibilidade Primária:** Detail/Viewer
**Compatibilidade Secundária:** Feed/Timeline, Catalog/Grid
**Incompatibilidades explícitas:** Dashboard, Form
**Estrutura Desktop:** Área de visualização com controlos (play/pause, volume, fullscreen para vídeo; zoom, rodar para imagem). Thumbnails de navegação em galeria opcional.
**Estrutura Mobile:** Visualização em largura total. Controlos gestuais (pinch-to-zoom, swipe). Fullscreen por padrão em vídeo.
**Regra de Transição:** Controlos de barra → gestuais. Thumbnails podem mover para baixo.
**Estados próprios:** a carregar, disponível, pausado, erro de carregamento, formato não suportado, em fullscreen
**Reação a estados da página:** Loading State → skeleton ou placeholder. Error State → ficheiro indisponível.
**Grau de Rigidez:** Médio

---

# Regras de Evolução do Catálogo

[INSTRUÇÃO]

Este catálogo é fixo no contexto de cada projecto.
A adição de novos UI Patterns segue a governança deste catálogo global.

Para adicionar um novo UI Pattern ao catálogo global do método:
1. O padrão deve ter sido formalizado em pelo menos um projecto com validação humana registada.
2. Deve demonstrar reutilização em contextos distintos.
3. Deve ser proposto com todos os campos obrigatórios preenchidos.
4. Deve ser validado formalmente antes de entrada no catálogo global.

Para alterar um UI Pattern existente:
1. Declarar o impacto nos projectos que já o utilizam.
2. Validação humana explícita obrigatória.
3. Versionar o catálogo após alteração.

---
