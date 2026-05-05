# UI Patterns de Navegação

UI Patterns de navegação organizam acesso, orientação e progressão entre áreas, estados ou etapas da experiência.

## Patterns

### Navigation Menu

**ID_UI_PATTERN:** UIP-NAV-NAVIGATION_MENU
**Categoria:** Navegação
**Definição curta:** Navegação estrutural principal que dá acesso aos destinos globais do sistema ou do shell activo.
**Objetivo estrutural:** Acesso estruturado aos módulos e secções do sistema. Âncora de navegação global.
**Não confundir com:** Tabs para vistas irmãs na mesma página, Breadcrumb para contexto hierárquico, menu contextual de ações
**Nível composicional possível:** Root
**Quando usar:** quando o utilizador precisa acessar módulos, áreas ou secções globais do sistema; quando o shell exige navegação persistente entre destinos principais; quando a hierarquia de navegação deve permanecer disponível ao longo da sessão
**Quando evitar:** quando a alternância é apenas entre vistas locais da mesma página; quando a necessidade é contextual a um item específico; quando a navegação existe só dentro de um fluxo sequencial
**Alternativas próximas:** UIP-NAV-TABS, UIP-NAV-BREADCRUMB, UIP-ACTION-CONTEXTUAL_MENU
**Sinais de escolha:** destinos representam módulos ou secções globais; a navegação precisa sobreviver à troca de páginas internas; há relação forte com o shell activo; permissões podem ocultar ou desactivar destinos inteiros
**Zonas usuais:** Shell Sidebar, Shell Header, Global Navigation
**Compatibilidade Primária:** Todos os Shells
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Nenhuma — elemento global
**Estrutura Desktop:** Sidebar vertical (Workspace/Admin) ou barra superior (Portal). Itens hierárquicos com agrupamento por módulo.
**Estrutura Mobile:** Navegação compacta equivalente ao shell. Pode usar bottom navigation para escopo reduzido ou gaveta quando a hierarquia exigir mais profundidade.
**Regra de Transição:** Navegação expandida → navegação compacta equivalente. Hierarquia, destinos principais e clareza de acesso devem ser preservados, mesmo com redistribuição visual.
**Estados próprios:** item activo, item inactivo, item com badge/notificação, item desactivado, menu expandido, menu colapsado
**Reação a estados da página:** No Permission State → item oculto ou desactivado conforme permissão do módulo.
**Grau de Rigidez:** Alto

### Breadcrumb

**ID_UI_PATTERN:** UIP-NAV-BREADCRUMB
**Categoria:** Navegação
**Definição curta:** Trilha hierárquica que mostra onde o utilizador está e como voltar a níveis anteriores.
**Objetivo estrutural:** Orientar o utilizador na hierarquia de navegação actual e permitir retorno a níveis anteriores.
**Não confundir com:** Navigation Menu global, Tabs locais, botão simples de voltar sem contexto hierárquico
**Nível composicional possível:** Leaf
**Quando usar:** quando a página está inserida numa hierarquia de navegação real; quando o utilizador pode precisar regressar a níveis anteriores com contexto; quando o detalhe ou viewer deriva de navegação progressiva por níveis
**Quando evitar:** quando a página é topo de módulo sem hierarquia relevante; quando a navegação local é entre vistas irmãs; quando um simples retorno resolve sem perda de contexto
**Alternativas próximas:** UIP-NAV-NAVIGATION_MENU, botão voltar, UIP-NAV-TABS
**Sinais de escolha:** existe caminho hierárquico identificável; níveis anteriores precisam continuar acessíveis; a localização actual importa para orientação; a página não é apenas uma aba ou estado local
**Zonas usuais:** Header, Detail Header, Content Header
**Compatibilidade Primária:** List+Detail, Detail/Viewer
**Compatibilidade Secundária:** Catalog/Grid, Settings
**Incompatibilidades explícitas:** Dashboard, Landing/Content, Feed/Timeline
**Estrutura Desktop:** Linha horizontal de itens separados por separador. Item actual destacado e não clicável. Itens anteriores clicáveis.
**Estrutura Mobile:** Truncagem dos níveis intermediários. Exibe apenas nível anterior e actual, ou só o anterior como link de retorno.
**Regra de Transição:** Hierarquia completa → versão compacta. Nunca ocultar o nível actual.
**Estados próprios:** nível actual (não navegável), nível anterior (navegável), nível truncado
**Reação a estados da página:** Loading State → itens em skeleton até navegação estar definida.
**Grau de Rigidez:** Alto

### Tabs

**ID_UI_PATTERN:** UIP-NAV-TABS
**Categoria:** Navegação
**Definição curta:** Navegação local entre vistas irmãs da mesma página ou da mesma zona, sem trocar o papel estrutural principal da tela.
**Objetivo estrutural:** Alternar entre vistas ou secções dentro da mesma página sem navegação de rota.
**Não confundir com:** Navigation Menu global, Stepper Indicator sequencial, Accordion de conteúdo colapsável
**Nível composicional possível:** Container
**Quando usar:** quando várias vistas compartilham o mesmo contexto de página; quando o utilizador precisa alternar entre secções irmãs sem perder o contexto principal; quando o conteúdo activo deve trocar sem reestruturar o shell
**Quando evitar:** quando a navegação é global do sistema; quando existe sequência obrigatória entre etapas; quando a quantidade de opções torna a leitura horizontal instável
**Alternativas próximas:** UIP-NAV-NAVIGATION_MENU, UIP-NAV-STEPPER_INDICATOR, selector/dropdown de vistas
**Sinais de escolha:** vistas irmãs partilham o mesmo cabeçalho ou mesmo contexto; o utilizador pode alternar livremente entre secções; apenas uma vista fica activa por vez; a zona de conteúdo abaixo muda, mas a página continua a mesma
**Zonas usuais:** Header local, Subnav de Detail/Viewer, Settings Sections
**Compatibilidade Primária:** Detail/Viewer, Settings
**Compatibilidade Secundária:** Dashboard, List+Detail
**Incompatibilidades explícitas:** Wizard/Stepper, Feed/Timeline
**Estrutura Desktop:** Barra de tabs horizontal no topo da zona. Conteúdo da tab activa abaixo.
**Estrutura Mobile:** Tabs horizontais com scroll lateral se exceder largura. Alternativa: selector dropdown para muitas tabs.
**Regra de Transição:** Barra horizontal preservada. Scroll lateral em Mobile. Nunca colapsar tabs em menu oculto sem alternativa visível.
**Estados próprios:** tab activa, tab inactiva, tab com badge/contagem, tab desactivada, tab com erro
**Reação a estados da página:** Loading State → conteúdo da tab activa em loading. Error State → tab com erro sinalizada.
**Grau de Rigidez:** Médio

### Pagination

**ID_UI_PATTERN:** UIP-NAV-PAGINATION
**Categoria:** Navegação
**Definição curta:** Navegação sequencial entre páginas discretas de uma coleção volumosa.
**Objetivo estrutural:** Navegar entre páginas de um conjunto de resultados volumoso.
**Não confundir com:** Scroll infinito, Stepper Indicator, Tabs de vistas locais
**Nível composicional possível:** Leaf
**Quando usar:** quando a coleção é grande e segmentada em páginas discretas; quando controlo explícito de página, total e avanço faz sentido; quando performance ou previsibilidade favorecem paginação em vez de rolagem contínua
**Quando evitar:** quando a experiência é naturalmente contínua ou cronológica; quando o volume é pequeno o suficiente para uma única lista; quando a navegação por etapas representa fluxo e não resultados
**Alternativas próximas:** scroll infinito, UIP-NAV-STEPPER_INDICATOR, carregamento progressivo
**Sinais de escolha:** há total ou subconjuntos discretos de resultados; o utilizador precisa voltar a páginas específicas; anterior/próxima e página actual são conceitos relevantes; a coleção não é consumida melhor por feed contínuo
**Zonas usuais:** List Footer, Table Footer, Results Footer
**Compatibilidade Primária:** List+Detail, Catalog/Grid
**Compatibilidade Secundária:** Data Table (componente interno)
**Incompatibilidades explícitas:** Feed/Timeline, Conversation
**Estrutura Desktop:** Barra horizontal com botões anterior, próxima, primeira, última e páginas numeradas. Indicador de página actual e total.
**Estrutura Mobile:** Simplificado — botões anterior e próxima com indicador de página actual.
**Regra de Transição:** Paginação completa → paginação simplificada. Páginas numeradas omitidas em Mobile.
**Estados próprios:** página actual, anterior disponível, próxima disponível, primeira página, última página, a carregar
**Reação a estados da página:** Loading State → botões desactivados durante carregamento.
**Grau de Rigidez:** Alto

### Stepper Indicator

**ID_UI_PATTERN:** UIP-NAV-STEPPER_INDICATOR
**Categoria:** Navegação
**Definição curta:** Indicador de progresso e posição dentro de um fluxo sequencial com etapas explícitas.
**Objetivo estrutural:** Indicar progresso e posição num fluxo multi-etapas com sequência obrigatória.
**Não confundir com:** Tabs de alternância livre, Breadcrumb hierárquico, Navigation Menu global
**Nível composicional possível:** Leaf, Container (quando integrado ao cabeçalho do fluxo)
**Quando usar:** quando o utilizador precisa entender em que etapa está e quantas faltam; quando o fluxo tem sequência explícita e avanço controlado; quando a navegação entre passos depende do estado do próprio fluxo
**Quando evitar:** quando a alternância entre secções é livre; quando a navegação é global ou hierárquica; quando a página só precisa exibir progresso genérico sem etapas nomeáveis
**Alternativas próximas:** UIP-NAV-TABS, UIP-NAV-BREADCRUMB, indicador simples de progresso
**Sinais de escolha:** existe ordem explícita entre etapas; a etapa actual precisa ser clara; etapas concluídas e futuras têm valor de orientação; o fluxo depende de progressão e validação
**Zonas usuais:** Wizard Header, Step Header, Flow Navigation
**Compatibilidade Primária:** Wizard/Stepper
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Todos os outros Page Patterns
**Estrutura Desktop:** Barra horizontal com etapas numeradas ou nomeadas. Etapa actual destacada. Etapas concluídas marcadas.
**Estrutura Mobile:** Versão compacta com contagem ou barra simplificada que preserve a etapa actual e a noção de progresso do fluxo.
**Regra de Transição:** Indicador completo → indicador compacto equivalente. Nunca omitir a etapa actual nem a progressão mínima percebida.
**Estados próprios:** etapa actual, etapa concluída, etapa futura, etapa com erro, etapa desactivada
**Reação a estados da página:** Error State → etapa com erro sinalizada. Loading State → etapa em processamento indicada.
**Grau de Rigidez:** Médio