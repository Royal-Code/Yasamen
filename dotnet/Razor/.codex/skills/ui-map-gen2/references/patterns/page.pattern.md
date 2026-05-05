# Page Patterns

## Page Patterns canônicos

### PP-LIST-DETAIL

**ID_PAGE_PATTERN:** PP-LIST-DETAIL
**Definição curta:** Página operacional com coleção e detalhe sincronizados, simultâneos ou alternáveis.
**Objetivo estrutural:** Permitir selecionar itens numa coleção e operar sobre o detalhe com contexto persistente.
**Interação dominante:** Operacional
**Não confundir com:** PP-CATALOG, PP-DETAIL
**Sinais de escolha:** existe coleção principal; a seleção altera um detalhe; o utilizador alterna entre operar na lista e consultar ou editar o item
**Zonas funcionais obrigatórias:** navegação ou filtros; coleção; detalhe ou preview; ações contextuais
**UI Patterns tipicamente obrigatórios:** UIP-STRUCT-LAYOUT_ZONE, UIP-STRUCT-SPLIT_PANEL, UIP-DATA-DATA_TABLE ou UIP-DATA-LIST_ITEM, UIP-CONTENT-DETAIL_BLOCK, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-EMPTY_STATE
**Compatibilidade Primária:** SHP-WORKSPACE_ADMIN, SHP-COMMUNICATION
**Compatibilidade Secundária:** SHP-DASHBOARD_ANALYTICS, SHP-TRANSACTIONAL_COMMERCE
**Incompatibilidades explícitas:** SHP-PORTAL como shell dominante
**Limites:** não usar quando a descoberta visual é o foco principal, quando não existe detalhe relevante ou quando a página é essencialmente formulário
**Estrutura Desktop:** lista e detalhe coexistem em painéis simultâneos ou em master-detail forte
**Estrutura Mobile:** lista e detalhe tornam-se vistas alternáveis
**Regra de transição:** simultaneidade em Desktop evolui para sequência navegável em Mobile
**Grau de Rigidez:** Alto

### PP-CATALOG

**ID_PAGE_PATTERN:** PP-CATALOG
**Definição curta:** Página exploratória de coleção filtrável, comparável e orientada à descoberta.
**Objetivo estrutural:** Sustentar procura, refino e comparação leve de muitos itens.
**Interação dominante:** Exploratória
**Não confundir com:** PP-LIST-DETAIL, PP-FEED
**Sinais de escolha:** coleção ampla; busca ou filtro relevantes; comparação leve entre itens; descoberta e refino mais importantes do que detalhe simultâneo
**Zonas funcionais obrigatórias:** busca; filtros; coleção; paginação ou scroll; ações de item
**UI Patterns tipicamente obrigatórios:** UIP-INPUT-SEARCH_BAR, UIP-INPUT-FILTER_PANEL, UIP-DATA-CARD_GRID ou UIP-DATA-LIST_ITEM, UIP-NAV-PAGINATION ou UIP-STRUCT-SCROLLABLE_REGION, UIP-ACTION-CONTEXTUAL_MENU, UIP-FEEDBACK-EMPTY_STATE
**Compatibilidade Primária:** SHP-MEDIA_CONTENT, SHP-PORTAL, SHP-TRANSACTIONAL_COMMERCE
**Compatibilidade Secundária:** SHP-WORKSPACE_ADMIN
**Incompatibilidades explícitas:** SHP-COMMUNICATION como shell dominante
**Limites:** não usar quando a tarefa principal depende de detalhe persistente, conversa ou monitoramento analítico
**Estrutura Desktop:** cabeçalho de busca e filtros com grade ou lista de itens
**Estrutura Mobile:** busca e filtros compactos com coleção em scroll contínuo ou paginação simplificada
**Regra de transição:** preservar descoberta, ordem e refinamento com compressão das zonas auxiliares
**Grau de Rigidez:** Médio

### PP-FORM

**ID_PAGE_PATTERN:** PP-FORM
**Definição curta:** Página de captura, atualização ou confirmação de dados em uma única etapa principal.
**Objetivo estrutural:** Sustentar entrada de dados com contexto claro, validação e submissão controlada.
**Interação dominante:** Transacional simples
**Não confundir com:** PP-WIZARD, PP-DETAIL
**Sinais de escolha:** uma única etapa dominante; campos agrupados; validação direta; submissão única; baixa necessidade de progressão entre etapas
**Zonas funcionais obrigatórias:** contexto da página; grupos de campos; ações primárias; feedback de validação
**UI Patterns tipicamente obrigatórios:** UIP-INPUT-FORM_FIELD_GROUP, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-TOAST_ALERT, UIP-FEEDBACK-CONFIRMATION_DIALOG
**Compatibilidade Primária:** SHP-WORKSPACE_ADMIN, SHP-TRANSACTIONAL_COMMERCE, SHP-KIOSK_EMBEDDED
**Compatibilidade Secundária:** SHP-PORTAL, SHP-STUDIO_WORKBENCH
**Incompatibilidades explícitas:** SHP-DASHBOARD_ANALYTICS como padrão dominante
**Limites:** não usar quando a tarefa exige múltiplas etapas explícitas, navegação por estados temporais ou exploração de coleção
**Estrutura Desktop:** formulário em coluna única ou dupla, com ações claramente separadas
**Estrutura Mobile:** coluna única com ações acessíveis e validação contextual
**Regra de transição:** reduzir colunas e preservar hierarquia dos campos e da ação primária
**Grau de Rigidez:** Médio

### PP-WIZARD

**ID_PAGE_PATTERN:** PP-WIZARD
**Definição curta:** Página de fluxo guiado em múltiplas etapas, com progressão declarada e validação por fase.
**Objetivo estrutural:** Sustentar tarefas transacionais complexas divididas em etapas explícitas.
**Interação dominante:** Transacional multi-etapa
**Não confundir com:** PP-FORM, PP-SETTINGS
**Sinais de escolha:** sequência obrigatória; dependência entre etapas; progressão monitorada; necessidade de reduzir carga cognitiva por fase
**Zonas funcionais obrigatórias:** indicador de etapas; corpo da etapa; ações de progressão; resumo ou confirmação
**UI Patterns tipicamente obrigatórios:** UIP-NAV-STEPPER_INDICATOR, UIP-INPUT-FORM_FIELD_GROUP, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-LOADING_STATE
**Compatibilidade Primária:** SHP-WORKSPACE_ADMIN, SHP-TRANSACTIONAL_COMMERCE, SHP-KIOSK_EMBEDDED
**Compatibilidade Secundária:** SHP-PORTAL
**Incompatibilidades explícitas:** SHP-COMMUNICATION, SHP-DASHBOARD_ANALYTICS como experiência dominante
**Limites:** não usar quando a tarefa cabe confortavelmente numa única página ou quando a ordem das ações é flexível
**Estrutura Desktop:** stepper visível com corpo da etapa e ações de navegação
**Estrutura Mobile:** progressão vertical ou compacta, com foco numa etapa por vez
**Regra de transição:** preservar ordem, progresso e critérios de validação em qualquer faixa
**Grau de Rigidez:** Alto

### PP-DASHBOARD

**ID_PAGE_PATTERN:** PP-DASHBOARD
**Definição curta:** Página de síntese analítica para leitura rápida de indicadores, estados e tendências.
**Objetivo estrutural:** Sustentar observação, correlação leve e drill-down controlado sobre métricas.
**Interação dominante:** Analítica
**Não confundir com:** PP-DETAIL, PP-LIST-DETAIL
**Sinais de escolha:** KPIs dominantes; leitura frequente; filtros temporais; comparações; visão resumida precedendo exploração
**Zonas funcionais obrigatórias:** resumo de KPIs; filtros; área analítica principal; indicadores secundários ou detalhes
**UI Patterns tipicamente obrigatórios:** UIP-CONTENT-METRIC_CARD, UIP-STRUCT-GRID_CONTAINER, UIP-INPUT-FILTER_PANEL, UIP-CONTENT-DETAIL_BLOCK, UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-LOADING_STATE
**Compatibilidade Primária:** SHP-DASHBOARD_ANALYTICS
**Compatibilidade Secundária:** SHP-WORKSPACE_ADMIN, SHP-KIOSK_EMBEDDED
**Incompatibilidades explícitas:** SHP-COMMUNICATION como experiência dominante
**Limites:** não usar quando a página é centrada em criação, edição profunda ou captura transacional extensa
**Estrutura Desktop:** grelha de métricas, filtros e blocos de análise com leitura comparativa
**Estrutura Mobile:** cartões empilhados, filtros compactos e drill-down progressivo
**Regra de transição:** reduzir simultaneidade visual sem perder leitura hierárquica das métricas
**Grau de Rigidez:** Médio

### PP-DETAIL

**ID_PAGE_PATTERN:** PP-DETAIL
**Definição curta:** Página de visualização estruturada de uma entidade, conteúdo ou artefacto específico.
**Objetivo estrutural:** Sustentar leitura, inspeção e ação localizada sobre um objeto singular.
**Interação dominante:** Informativa
**Não confundir com:** PP-LIST-DETAIL, PP-LANDING
**Sinais de escolha:** uma entidade dominante; leitura de atributos, media ou conteúdo; ações localizadas; contexto singular
**Zonas funcionais obrigatórias:** cabeçalho contextual; corpo de detalhe; ações da entidade; conteúdo complementar
**UI Patterns tipicamente obrigatórios:** UIP-CONTENT-DETAIL_BLOCK, UIP-CONTENT-RICH_TEXT_BLOCK ou UIP-CONTENT-MEDIA_VIEWER, UIP-ACTION-ACTION_BAR, UIP-NAV-BREADCRUMB, UIP-FEEDBACK-LOADING_STATE
**Compatibilidade Primária:** SHP-WORKSPACE_ADMIN, SHP-PORTAL, SHP-MEDIA_CONTENT, SHP-TRANSACTIONAL_COMMERCE
**Compatibilidade Secundária:** SHP-STUDIO_WORKBENCH, SHP-DASHBOARD_ANALYTICS
**Incompatibilidades explícitas:** nenhuma estrutural explícita
**Limites:** não usar quando a página depende de coleção ativa, descoberta contínua ou conversa persistente
**Estrutura Desktop:** cabeçalho e corpo de detalhe com secções estruturadas
**Estrutura Mobile:** leitura em coluna única com ações compactadas
**Regra de transição:** preservar agrupamento da informação e visibilidade da ação principal
**Grau de Rigidez:** Médio

### PP-LANDING

**ID_PAGE_PATTERN:** PP-LANDING
**Definição curta:** Página de entrada, campanha, boas-vindas ou narrativa institucional com progressão linear.
**Objetivo estrutural:** Ancorar proposta de valor, orientação inicial ou conversão simples.
**Interação dominante:** Informativa
**Não confundir com:** PP-DETAIL, PP-CATALOG
**Sinais de escolha:** hero principal; narrativa linear; CTAs claros; secções editoriais; intenção de apresentação ou entrada
**Zonas funcionais obrigatórias:** hero; blocos de conteúdo; prova ou destaque; CTA principal
**UI Patterns tipicamente obrigatórios:** UIP-CONTENT-RICH_TEXT_BLOCK, UIP-STRUCT-GRID_CONTAINER, UIP-CONTENT-MEDIA_VIEWER, UIP-ACTION-ACTION_BAR
**Compatibilidade Primária:** SHP-PORTAL
**Compatibilidade Secundária:** SHP-MEDIA_CONTENT, SHP-TRANSACTIONAL_COMMERCE
**Incompatibilidades explícitas:** SHP-WORKSPACE_ADMIN, SHP-STUDIO_WORKBENCH como experiência dominante
**Limites:** não usar para operações densas, configuração complexa ou exploração de coleções grandes
**Estrutura Desktop:** fluxo por secções com hierarquia visual clara e CTA destacado
**Estrutura Mobile:** narrativa vertical contínua com CTA acessível
**Regra de transição:** preservar sequência narrativa, destaque do CTA e leitura confortável
**Grau de Rigidez:** Médio

### PP-CONVERSATION

**ID_PAGE_PATTERN:** PP-CONVERSATION
**Definição curta:** Página de thread conversacional com composição, leitura e atualização contínua.
**Objetivo estrutural:** Sustentar troca de mensagens, leitura de contexto e continuidade de conversa.
**Interação dominante:** Comunicacional
**Não confundir com:** PP-FEED, PP-LIST-DETAIL
**Sinais de escolha:** thread dominante; composição de mensagem; histórico conversacional; contexto de participantes; atualização em tempo real
**Zonas funcionais obrigatórias:** lista ou thread ativa; área de mensagens; compositor; contexto da conversa
**UI Patterns tipicamente obrigatórios:** UIP-STRUCT-SCROLLABLE_REGION, UIP-DATA-TIMELINE_ITEM, UIP-ACTION-ACTION_BAR, UIP-DATA-LIST_ITEM, UIP-FEEDBACK-EMPTY_STATE
**Compatibilidade Primária:** SHP-COMMUNICATION
**Compatibilidade Secundária:** SHP-WORKSPACE_ADMIN
**Incompatibilidades explícitas:** SHP-PORTAL como shell dominante
**Limites:** não usar quando a cronologia é unilateral, sem resposta, ou quando a conversa é apenas um detalhe secundário
**Estrutura Desktop:** thread e contexto coexistem, com scroll independente quando necessário
**Estrutura Mobile:** alternância entre lista de conversas e thread ativa ou foco direto em thread
**Regra de transição:** preservar continuidade conversacional, composição e leitura do histórico
**Grau de Rigidez:** Alto

### PP-FEED

**ID_PAGE_PATTERN:** PP-FEED
**Definição curta:** Página de lista cronológica ou stream contínuo de itens, atualizações ou publicações.
**Objetivo estrutural:** Sustentar consumo recorrente, atualização incremental e navegação por ordem temporal.
**Interação dominante:** Cronológica
**Não confundir com:** PP-CATALOG, PP-CONVERSATION
**Sinais de escolha:** ordem temporal dominante; stream contínuo; leitura rápida; atualização incremental; eventual publicação leve
**Zonas funcionais obrigatórias:** stream principal; filtros ou ordenação; ações de item; estado de atualização
**UI Patterns tipicamente obrigatórios:** UIP-STRUCT-SCROLLABLE_REGION, UIP-DATA-TIMELINE_ITEM, UIP-ACTION-CONTEXTUAL_MENU, UIP-ACTION-FLOATING_ACTION, UIP-FEEDBACK-EMPTY_STATE
**Compatibilidade Primária:** SHP-MEDIA_CONTENT, SHP-COMMUNICATION
**Compatibilidade Secundária:** SHP-PORTAL
**Incompatibilidades explícitas:** SHP-DASHBOARD_ANALYTICS como experiência dominante
**Limites:** não usar quando busca estruturada, comparação de coleção ou detalhe persistente são mais importantes do que a cronologia
**Estrutura Desktop:** stream central com filtros, ações e atualização progressiva
**Estrutura Mobile:** scroll contínuo de foco único com ações compactas
**Regra de transição:** preservar ordem temporal e continuidade de consumo
**Grau de Rigidez:** Médio

### PP-SETTINGS

**ID_PAGE_PATTERN:** PP-SETTINGS
**Definição curta:** Página de configuração, preferências e parâmetros agrupados por secções estáveis.
**Objetivo estrutural:** Sustentar leitura, edição e guarda controlada de preferências e políticas.
**Interação dominante:** Configuracional
**Não confundir com:** PP-FORM, PP-WIZARD
**Sinais de escolha:** parâmetros persistentes; secções estáveis; preferência ou política; alterações não necessariamente lineares
**Zonas funcionais obrigatórias:** navegação local ou agrupamento de secções; corpo de configuração; ações de guardar e restaurar; feedback de estado
**UI Patterns tipicamente obrigatórios:** UIP-NAV-TABS ou UIP-NAV-BREADCRUMB, UIP-STRUCT-STACK_CONTAINER, UIP-INPUT-FORM_FIELD_GROUP, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-TOAST_ALERT
**Compatibilidade Primária:** SHP-WORKSPACE_ADMIN
**Compatibilidade Secundária:** SHP-PORTAL, SHP-STUDIO_WORKBENCH
**Incompatibilidades explícitas:** SHP-COMMUNICATION como experiência dominante
**Limites:** não usar quando a tarefa é transação curta, onboarding guiado ou gestão intensiva de coleção
**Estrutura Desktop:** secções agrupadas com navegação local e ações persistentes
**Estrutura Mobile:** secções empilhadas ou tabs compactas com ações no final ou fixas
**Regra de transição:** preservar agrupamento lógico e segurança da ação de guardar
**Grau de Rigidez:** Médio

### PP-BOARD

**ID_PAGE_PATTERN:** PP-BOARD
**Definição curta:** Página de organização visual por colunas, estados, etapas ou lanes.
**Objetivo estrutural:** Sustentar acompanhamento e manipulação de itens por estado, estágio ou agrupamento operacional.
**Interação dominante:** Operacional visual
**Não confundir com:** PP-LIST-DETAIL, PP-CALENDAR
**Sinais de escolha:** colunas ou lanes; arrastar ou mover entre estados; visão do fluxo de trabalho; status como eixo principal
**Zonas funcionais obrigatórias:** toolbar; filtros; colunas ou lanes; cartões ou itens; ações contextuais
**UI Patterns tipicamente obrigatórios:** UIP-DATA-KANBAN_COLUMN, UIP-INPUT-SEARCH_BAR, UIP-INPUT-FILTER_PANEL, UIP-ACTION-ACTION_BAR, UIP-ACTION-CONTEXTUAL_MENU, UIP-FEEDBACK-EMPTY_STATE
**Compatibilidade Primária:** SHP-WORKSPACE_ADMIN, SHP-STUDIO_WORKBENCH
**Compatibilidade Secundária:** SHP-TRANSACTIONAL_COMMERCE
**Incompatibilidades explícitas:** SHP-PORTAL como experiência dominante
**Limites:** não usar quando o eixo principal é temporal, geográfico ou de leitura linear, e não estado operacional
**Estrutura Desktop:** colunas simultâneas com itens movíveis ou comparáveis lado a lado
**Estrutura Mobile:** foco em uma coluna por vez, com navegação horizontal ou agrupamento sequencial
**Regra de transição:** reduzir simultaneidade sem perder leitura do fluxo por estados
**Grau de Rigidez:** Alto

### PP-CALENDAR

**ID_PAGE_PATTERN:** PP-CALENDAR
**Definição curta:** Página orientada a agenda, calendário ou distribuição de itens por tempo.
**Objetivo estrutural:** Sustentar leitura e operação sobre eventos, reservas, compromissos ou disponibilidade ao longo do tempo.
**Interação dominante:** Temporal
**Não confundir com:** PP-BOARD, PP-FEED
**Sinais de escolha:** tempo como eixo principal; visualização por dia, semana ou mês; conflitos de agenda; disponibilidade; eventos posicionados temporalmente
**Zonas funcionais obrigatórias:** controle temporal; superfície de agenda ou calendário; detalhe do item temporal; ações de criação ou edição
**UI Patterns tipicamente obrigatórios:** UIP-INPUT-DATE_PICKER, UIP-ACTION-ACTION_BAR, UIP-CONTENT-DETAIL_BLOCK, UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-LOADING_STATE
**Compatibilidade Primária:** SHP-WORKSPACE_ADMIN, SHP-TRANSACTIONAL_COMMERCE
**Compatibilidade Secundária:** SHP-PORTAL, SHP-KIOSK_EMBEDDED, SHP-DASHBOARD_ANALYTICS
**Incompatibilidades explícitas:** SHP-COMMUNICATION como experiência dominante
**Limites:** exige eixo temporal como estrutura principal; quando a grelha temporal for especializada, a superfície de calendário ainda precisa de UI Pattern próprio formalizado
**Estrutura Desktop:** agenda, semana ou mês com detalhe acessório e controles temporais visíveis
**Estrutura Mobile:** agenda simplificada, foco por dia ou lista temporal com drill-down
**Regra de transição:** preservar semântica temporal e acesso às ações principais mesmo com simplificação da grelha
**Grau de Rigidez:** Médio

### PP-MAP

**ID_PAGE_PATTERN:** PP-MAP
**Definição curta:** Página orientada a navegação, análise ou operação sobre espaço geográfico.
**Objetivo estrutural:** Sustentar leitura, filtro e ação sobre entidades cuja posição espacial é estruturalmente relevante.
**Interação dominante:** Espacial
**Não confundir com:** PP-CATALOG, PP-DASHBOARD
**Sinais de escolha:** localização é decisiva; camadas, áreas, rotas ou pontos; relação entre proximidade e decisão; exploração espacial dominante
**Zonas funcionais obrigatórias:** superfície cartográfica; busca ou filtros; legenda ou camadas; detalhe contextual; ações
**UI Patterns tipicamente obrigatórios:** UIP-INPUT-SEARCH_BAR, UIP-INPUT-FILTER_PANEL, UIP-CONTENT-DETAIL_BLOCK, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-EMPTY_STATE
**Compatibilidade Primária:** SHP-MEDIA_CONTENT, SHP-DASHBOARD_ANALYTICS
**Compatibilidade Secundária:** SHP-WORKSPACE_ADMIN, SHP-KIOSK_EMBEDDED
**Incompatibilidades explícitas:** SHP-COMMUNICATION como experiência dominante
**Limites:** exige eixo espacial como estrutura principal; a superfície cartográfica ainda depende de UI Pattern especializado fora do catálogo atual
**Estrutura Desktop:** mapa dominante com overlays, filtros e painel contextual
**Estrutura Mobile:** mapa de foco único com painéis sobrepostos ou alternáveis
**Regra de transição:** preservar contexto espacial, controles essenciais e leitura do detalhe selecionado
**Grau de Rigidez:** Médio

### PP-CANVAS

**ID_PAGE_PATTERN:** PP-CANVAS
**Definição curta:** Página centrada em superfície de criação, composição, desenho ou edição técnica.
**Objetivo estrutural:** Sustentar manipulação direta de artefactos com ferramentas, inspector e contexto especializado.
**Interação dominante:** Composicional
**Não confundir com:** PP-DETAIL, PP-FORM, PP-BOARD
**Sinais de escolha:** superfície editável central; manipulação direta; painéis de propriedades; toolbar persistente; objetos, layers ou assets como matéria de trabalho
**Zonas funcionais obrigatórias:** toolbar; superfície principal; inspector; painel auxiliar; ações de guardar ou publicar
**UI Patterns tipicamente obrigatórios:** UIP-STRUCT-LAYOUT_ZONE, UIP-NAV-TABS, UIP-ACTION-ACTION_BAR, UIP-ACTION-CONTEXTUAL_MENU, UIP-FEEDBACK-CONFIRMATION_DIALOG, UIP-FEEDBACK-EMPTY_STATE
**Compatibilidade Primária:** SHP-STUDIO_WORKBENCH
**Compatibilidade Secundária:** nenhuma
**Incompatibilidades explícitas:** SHP-PORTAL, SHP-COMMUNICATION, SHP-KIOSK_EMBEDDED como experiência dominante
**Limites:** exige superfície especializada de edição como núcleo da página; o canvas em si ainda requer UI Pattern próprio fora do catálogo atual
**Estrutura Desktop:** superfície dominante com painéis laterais simultâneos e ferramentas persistentes
**Estrutura Mobile:** revisão, anotação ou ajustes pontuais; edição completa pode ser restringida
**Regra de transição:** preservar a primazia da superfície principal, mesmo quando a edição integral não couber em Mobile
**Grau de Rigidez:** Alto