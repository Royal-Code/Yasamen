# UI Patterns Estruturais

UI Patterns estruturais organizam o espaço da página ou do shell. Não carregam semântica de negócio por si só; servem como base composicional para outros patterns.

## Como ler este catálogo

Cada UI Pattern declara:

- ID_UI_PATTERN
- Categoria
- Definição curta
- Objetivo estrutural
- Não confundir com
- Nível composicional possível
- Compatibilidade Primária
- Compatibilidade Secundária
- Incompatibilidades explícitas
- Estrutura Desktop
- Estrutura Mobile
- Regra de Transição
- Estados próprios
- Reação a estados da página
- Grau de Rigidez

## Patterns

### Layout Zone

**ID_UI_PATTERN:** UIP-STRUCT-LAYOUT_ZONE
**Categoria:** Estrutural
**Definição curta:** Região funcional da interface que agrupa conteúdo com responsabilidade própria dentro de uma página ou shell.
**Objetivo estrutural:** Delimitar uma área funcional da página com responsabilidade distinta. Âncora que agrupa os UI Patterns de uma zona.
**Não confundir com:** Shell de navegação completo, Split Panel, Grid Container usado só para distribuição visual
**Nível composicional possível:** Root, Container
**Quando usar:** quando a página precisa separar responsabilidades funcionais em áreas distintas; quando a mesma página combina listagem, detalhe, filtros, ações ou conteúdo auxiliar; quando a zona precisa agrupar outros UIPs sem virar um padrão semântico próprio
**Quando evitar:** quando a necessidade real é apenas distribuir colunas ou espaçamento visual; quando a estrutura exige dois painéis com simultaneidade explícita; quando a área inteira já é o shell de navegação da experiência
**Alternativas próximas:** UIP-STRUCT-SPLIT_PANEL, UIP-STRUCT-GRID_CONTAINER, Shell/Workspace Container
**Sinais de escolha:** existe uma zona funcional nomeável na página; a zona tem responsabilidade própria e pode reagir a estados localizados; a zona contém outros UIPs, não apenas conteúdo solto; a página precisa explicitar cabeçalho, filtro, lista, detalhe ou ações em áreas separadas
**Zonas usuais:** Header, Filter, List, Detail-Panel, Actions
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Nenhuma
**Estrutura Desktop:** Área rectangular com dimensões definidas pela zona funcional. Pode ser fixa ou flexível conforme conteúdo.
**Estrutura Mobile:** Ocupa largura total. Empilhamento vertical entre zonas.
**Regra de Transição:** Layout lateral → empilhamento vertical. Zonas simultâneas → zonas sequenciais navegáveis quando necessário.
**Estados próprios:** activa, colapsada, oculta (por permissão ou contexto)
**Reação a estados da página:** Empty State → exibe conteúdo de zona vazia. Loading State → exibe Loading State interno. Error State → exibe Error State interno. No Permission State → zona oculta ou bloqueada.
**Grau de Rigidez:** Baixo

### Split Panel

**ID_UI_PATTERN:** UIP-STRUCT-SPLIT_PANEL
**Categoria:** Estrutural
**Definição curta:** Estrutura de dois painéis com responsabilidades simultâneas e complementares.
**Objetivo estrutural:** Dividir a área principal em dois painéis com responsabilidades distintas e simultâneas.
**Não confundir com:** Layout Zone genérica, Grid Container multicoluna, Tabs de alternância local
**Nível composicional possível:** Root, Container
**Quando usar:** quando duas áreas precisam coexistir e interagir ao mesmo tempo; quando a escolha em um painel altera o conteúdo do outro; quando a experiência depende de contexto simultâneo entre lista e detalhe ou áreas equivalentes
**Quando evitar:** quando as áreas podem ser apenas empilhadas sem perda de contexto; quando a navegação é livre entre vistas e não simultânea; quando a tela é essencialmente formulário ou conteúdo linear
**Alternativas próximas:** UIP-STRUCT-LAYOUT_ZONE, UIP-NAV-TABS, fluxo sequencial de detalhe
**Sinais de escolha:** existem duas responsabilidades fortes no mesmo espaço; simultaneidade importa; a navegação de um lado alimenta o conteúdo do outro; o utilizador beneficia de comparação ou contexto paralelo
**Zonas usuais:** List + Detail, Conversation + Context, Master + Secondary Pane
**Compatibilidade Primária:** List+Detail, Conversation
**Compatibilidade Secundária:** Settings, Detail/Viewer
**Incompatibilidades explícitas:** Form, Wizard/Stepper, Landing/Content
**Estrutura Desktop:** Dois painéis lado a lado. Primário à esquerda (listagem/navegação), secundário à direita (detalhe/conteúdo). Divisor ajustável opcional.
**Estrutura Mobile:** Painéis alternam — apenas um visível de cada vez. Navegação entre painéis por acção do utilizador.
**Regra de Transição:** Simultaneidade → sequência. Painel secundário vazio → exibe estado "nenhum item seleccionado".
**Estados próprios:** painel primário em foco, painel secundário em foco, painel secundário colapsado, painel secundário vazio
**Reação a estados da página:** Loading State → cada painel exibe Loading State independente. Empty State → painel secundário exibe Empty State. Error State → painel afectado exibe Error State localizado.
**Grau de Rigidez:** Médio

### Scrollable Region

**ID_UI_PATTERN:** UIP-STRUCT-SCROLLABLE_REGION
**Categoria:** Estrutural
**Definição curta:** Região com scroll próprio, independente do scroll principal da página.
**Objetivo estrutural:** Delimitar uma área com scroll independente do restante da página.
**Não confundir com:** página inteira rolável, Layout Zone sem scroll independente, Feed completo
**Nível composicional possível:** Container
**Quando usar:** quando uma subárea precisa rolar sem deslocar toda a página; quando a experiência exige foco local em lista, feed ou conversa; quando a altura da região é delimitada pelo contexto estrutural
**Quando evitar:** quando o scroll da página inteira resolve naturalmente; quando o conteúdo da área é pequeno e estável; quando múltiplas regiões roláveis degradariam a usabilidade
**Alternativas próximas:** página com scroll único, UIP-STRUCT-LAYOUT_ZONE, UIP-DATA-TIMELINE_ITEM em feed simples
**Sinais de escolha:** a região tem altura definida; o conteúdo pode crescer independentemente do resto da página; o utilizador precisa interagir longamente com a área sem perder o entorno; o scroll local faz parte da tarefa
**Zonas usuais:** Feed List, Conversation Body, Secondary Panel
**Compatibilidade Primária:** Feed/Timeline, Conversation
**Compatibilidade Secundária:** List+Detail, Catalog/Grid, Detail/Viewer
**Incompatibilidades explícitas:** Form simples, Landing/Content
**Estrutura Desktop:** Área com altura definida e scroll vertical interno. Largura determinada pela zona pai.
**Estrutura Mobile:** Scroll nativo da região. Altura pode expandir para viewport completa em contextos de foco único.
**Regra de Transição:** Comportamento de scroll preservado. Altura pode expandir para viewport em Mobile.
**Estados próprios:** conteúdo disponível, a carregar mais conteúdo, fim do conteúdo, erro ao carregar mais
**Reação a estados da página:** Loading State → indicador no topo ou fundo da região. Empty State → conteúdo de zona vazia centrado.
**Grau de Rigidez:** Baixo

### Stack Container

**ID_UI_PATTERN:** UIP-STRUCT-STACK_CONTAINER
**Categoria:** Estrutural
**Definição curta:** Contêiner que organiza elementos em sequência vertical com espaçamento coerente.
**Objetivo estrutural:** Organizar UI Patterns em sequência vertical com espaçamento consistente.
**Não confundir com:** Form Field Group semântico, Layout Zone com responsabilidade própria, Grid Container
**Nível composicional possível:** Container
**Quando usar:** quando o conteúdo deve ser lido ou percorrido verticalmente; quando a zona combina vários blocos sem necessidade de grade; quando a clareza depende de empilhamento simples e previsível
**Quando evitar:** quando o agrupamento precisa de semântica própria de formulário ou detalhe; quando a composição real é de múltiplas colunas; quando a relação entre elementos é simultânea e lateral
**Alternativas próximas:** UIP-STRUCT-GRID_CONTAINER, UIP-INPUT-FORM_FIELD_GROUP, UIP-STRUCT-LAYOUT_ZONE
**Sinais de escolha:** os filhos são consumidos em ordem vertical; o espaçamento uniforme é relevante; a zona não precisa de layout em grade; o contêiner é puramente estrutural
**Zonas usuais:** Form Body, Settings Body, Detail Sections
**Compatibilidade Primária:** Form, Settings, Wizard/Stepper
**Compatibilidade Secundária:** Detail/Viewer, Dashboard
**Incompatibilidades explícitas:** Nenhuma explícita
**Estrutura Desktop:** Coluna vertical. Espaçamento uniforme entre elementos filhos. Largura determinada pela zona pai.
**Estrutura Mobile:** Comportamento preservado. Espaçamento pode ser reduzido.
**Regra de Transição:** Estrutura mantida. Ajuste de espaçamento e padding lateral.
**Estados próprios:** normal, com erro em filho (herda visibilidade de erro do filho)
**Reação a estados da página:** Loading State → substitui conteúdo por Loading State. Empty State → exibe zona vazia se todos os filhos estiverem vazios.
**Grau de Rigidez:** Baixo

### Grid Container

**ID_UI_PATTERN:** UIP-STRUCT-GRID_CONTAINER
**Categoria:** Estrutural
**Definição curta:** Contêiner de organização em grade para distribuir elementos por colunas e linhas.
**Objetivo estrutural:** Organizar UI Patterns em grelha de múltiplas colunas.
**Não confundir com:** Card Grid semântico de coleção, Layout Zone funcional, Data Table
**Nível composicional possível:** Container
**Quando usar:** quando a composição exige distribuição em múltiplas colunas; quando os blocos precisam manter alinhamento visual em grade; quando o layout responde por densidade e distribuição, não por semântica de coleção
**Quando evitar:** quando a intenção é uma coleção visual de cards; quando a leitura é predominantemente linear; quando a zona tem significado funcional próprio além da distribuição
**Alternativas próximas:** UIP-DATA-CARD_GRID, UIP-STRUCT-STACK_CONTAINER, UIP-STRUCT-LAYOUT_ZONE
**Sinais de escolha:** a grade serve à composição dos blocos; colunas variáveis fazem sentido; os elementos compartilham alinhamento visual, não papel semântico comum; a ordem deve ser preservada entre faixas responsivas
**Zonas usuais:** Dashboard Body, Landing Sections, Multi-column Content
**Compatibilidade Primária:** Catalog/Grid, Dashboard
**Compatibilidade Secundária:** Feed/Timeline, Landing/Content
**Incompatibilidades explícitas:** Form, Wizard/Stepper, Conversation
**Estrutura Desktop:** Grelha de N colunas (declarado por contexto). Espaçamento uniforme. Itens de largura igual ou proporcional.
**Estrutura Mobile:** Redução de colunas — tipicamente para 1 ou 2. Empilhamento progressivo conforme breakpoint.
**Regra de Transição:** N colunas Desktop → M colunas Mobile (M < N). Nunca alterar ordem dos itens.
**Estados próprios:** normal, a carregar (skeleton), vazio, filtro activo
**Reação a estados da página:** Loading State → skeleton da grelha completa. Empty State → exibe Empty State centrado. Error State → exibe Error State.
**Grau de Rigidez:** Médio