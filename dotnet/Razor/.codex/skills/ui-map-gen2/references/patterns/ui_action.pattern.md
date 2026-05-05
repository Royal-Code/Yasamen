# UI Patterns de Ação

UI Patterns de ação expõem operações globais, contextuais ou prioritárias sobre páginas, seleções e itens.

## Patterns

### Action Bar

**ID_UI_PATTERN:** UIP-ACTION-ACTION_BAR
**Categoria:** Ação
**Definição curta:** Barra de ações visíveis para operações principais sobre a página, seleção ou entidade em foco.
**Objetivo estrutural:** Expor acções disponíveis sobre item seleccionado, selecção múltipla ou sobre a página.
**Não confundir com:** Contextual Menu por item, Floating Action de destaque único, Navigation Menu
**Nível composicional possível:** Leaf
**Quando usar:** quando a página ou seleção exige ações principais visíveis; quando existe conjunto pequeno e recorrente de operações relevantes; quando as ações precisam ficar próximas da área de trabalho
**Quando evitar:** quando as ações pertencem a um item específico e não ao contexto global; quando existe apenas uma ação primária dominante; quando a densidade de ações tornaria a barra ilegível
**Alternativas próximas:** UIP-ACTION-CONTEXTUAL_MENU, UIP-ACTION-FLOATING_ACTION, botões inline
**Sinais de escolha:** ações são frequentes e devem ficar explícitas; o contexto de página ou seleção altera a disponibilidade das ações; existe ação primária e secundárias relacionadas; o utilizador não deve abrir menu para toda ação importante
**Zonas usuais:** Header Actions, Table Toolbar, Detail Actions
**Compatibilidade Primária:** List+Detail, Detail/Viewer, Form
**Compatibilidade Secundária:** Dashboard, Settings
**Incompatibilidades explícitas:** Não substitui Contextual Menu para acções por linha
**Estrutura Desktop:** Barra horizontal com botões primários e secundários. Acções destrutivas separadas ou à direita. Acções de selecção múltipla visíveis quando itens seleccionados.
**Estrutura Mobile:** Acções primárias visíveis. Secundárias em overflow (três pontos). Barra pode ser fixa no fundo em detalhe.
**Regra de Transição:** Todas visíveis → primárias visíveis + overflow. Nunca ocultar acção primária.
**Estados próprios:** acções disponíveis, acções desactivadas (sem selecção ou permissão), acção em progresso, acção concluída
**Reação a estados da página:** Loading State → acções desactivadas. No Permission State → acções restritas ocultas ou desactivadas.
**Grau de Rigidez:** Médio

### Contextual Menu

**ID_UI_PATTERN:** UIP-ACTION-CONTEXTUAL_MENU
**Categoria:** Ação
**Definição curta:** Menu de ações locais associado a um item ou contexto específico, activado sob demanda.
**Objetivo estrutural:** Expor acções disponíveis sobre um item específico sem ocupar espaço permanente.
**Não confundir com:** Action Bar global, Navigation Menu, diálogo de confirmação
**Nível composicional possível:** Leaf
**Quando usar:** quando as ações pertencem a um item específico; quando a interface precisa economizar espaço permanente; quando ações secundárias ou avançadas não precisam ficar sempre visíveis
**Quando evitar:** quando as ações são globais da página ou da seleção; quando a ação principal precisa ser imediatamente visível; quando o utilizador precisa confirmar antes mesmo de escolher a ação
**Alternativas próximas:** UIP-ACTION-ACTION_BAR, botões inline, UIP-FEEDBACK-CONFIRMATION_DIALOG
**Sinais de escolha:** há ações locais por item; o espaço visual é restrito; parte das ações pode ficar oculta até demanda; a lista de ações precisa ser contextual
**Zonas usuais:** Row Actions, Card Actions, Item Overflow
**Compatibilidade Primária:** List+Detail, Catalog/Grid
**Compatibilidade Secundária:** Feed/Timeline
**Incompatibilidades explícitas:** Não substitui Action Bar para acções globais de página
**Estrutura Desktop:** Dropdown por ícone de três pontos ou clique direito. Lista com separadores. Destrutivas no final.
**Estrutura Mobile:** Variante touch-friendly como sheet, popover adaptado ou menu contextual nativo. Cancelamento explícito ou implícito depende do padrão da plataforma e do risco das ações.
**Regra de Transição:** Menu compacto de desktop → variante touch-friendly equivalente. Ações, agrupamentos e distinção de destrutividade devem ser preservados.
**Estados próprios:** fechado, aberto, item disponível, item desactivado, item destrutivo
**Reação a estados da página:** No Permission State → acções restritas ocultas ou desactivadas.
**Grau de Rigidez:** Médio

### Floating Action

**ID_UI_PATTERN:** UIP-ACTION-FLOATING_ACTION
**Categoria:** Ação
**Definição curta:** Ação primária destacada e persistente, acessível acima do conteúdo da página.
**Objetivo estrutural:** Destacar a acção primária mais importante da página de forma sempre acessível.
**Não confundir com:** Action Bar com múltiplas ações, botão inline contextual, Navigation control
**Nível composicional possível:** Leaf
**Quando usar:** quando existe uma única ação primária dominante; quando a ação deve permanecer acessível durante rolagem; quando a página é orientada a criação ou execução recorrente de uma ação
**Quando evitar:** quando há muitas ações equivalentes; quando a página já possui barra de ações suficiente; quando o overlay flutuante conflita com leitura, navegação ou acessibilidade
**Alternativas próximas:** UIP-ACTION-ACTION_BAR, botão primário em header, ação inline fixa
**Sinais de escolha:** há uma ação claramente dominante; a rolagem não deve esconder a ação principal; a tarefa principal é recorrente e rápida; o contexto tolera overlay persistente
**Zonas usuais:** Global Overlay, Feed Action, Catalog Primary Action
**Compatibilidade Primária:** Feed/Timeline, Catalog/Grid
**Compatibilidade Secundária:** List+Detail, Dashboard
**Incompatibilidades explícitas:** Form, Wizard/Stepper, Settings
**Estrutura Desktop:** Botão circular ou estendido fixo no canto inferior direito. Ícone com rótulo opcional.
**Estrutura Mobile:** Botão circular fixo no canto inferior direito, acima de bottom navigation. Mínimo 56px.
**Regra de Transição:** Posição e comportamento preservados. Rótulo pode ser omitido se ícone for descritivo.
**Estados próprios:** normal, hover/focus, a processar, desactivado
**Reação a estados da página:** Loading State → desactivado. No Permission State → oculto.
**Grau de Rigidez:** Alto