# Catálogo Global de Shell Patterns, Page Patterns e UI Patterns

> Heurística Visual (Frontend)
> Destinado prioritariamente à orquestração por IA, podendo ser auditado por humanos.

[INSTRUÇÃO] Não é um documento de algoritmo; é o repositório formal dos padrões oficiais do método para frontend.
Nenhum Shell Pattern, Page Pattern ou UI Pattern pode ser criado ou alterado sem validação humana explícita e registo formal.

---

## Sistema de Identificação Canônico Global

[INSTRUÇÃO]
Todos os padrões deste catálogo possuem agora um identificador canônico global obrigatório.

Formato oficial:

```
SHP-<NOME_CANONICO>
PP-<NOME_CANONICO>
UIP-<GRUPO>-<NOME_CANONICO>
```

Onde:
- `SHP` corresponde a Shell Pattern
- `PP` corresponde a Page Pattern
- `UIP` corresponde a UI Pattern
- `<GRUPO>` corresponde ao grupo estrutural do UI Pattern (STRUCT, NAV, DATA, INPUT, FEEDBACK, ACTION, CONTENT)
- `<NOME_CANONICO>` corresponde ao nome do padrão em formato normalizado, em maiúsculas e underscore quando necessário

Exemplos:
- Workspace/Admin -> SHP-WORKSPACE_ADMIN
- PP-BOARD -> PP-BOARD
- Layout Zone -> UIP-STRUCT-LAYOUT_ZONE
- Data Table -> UIP-DATA-DATA_TABLE

[INSTRUÇÃO]
Os campos **ID_SHELL_PATTERN**, **ID_PAGE_PATTERN** e **ID_UI_PATTERN** passam a ser considerados campos obrigatórios implícitos de todos os padrões deste catálogo.

Nenhum ID pode ser redefinido por projeto.
A alteração de qualquer identificador canônico exige versionamento deste catálogo.

---

## Catálogo oficial de Shell Patterns

[INSTRUÇÃO]
Shell Pattern é o padrão estrutural global da experiência.
Define navegação dominante, persistência de contexto, densidade operacional, fronteiras entre módulos e forma principal de trabalho do utilizador.

[INSTRUÇÃO]
Este catálogo cobre prioritariamente aplicações orientadas a páginas, fluxos e áreas funcionais persistentes.
Não cobre integralmente jogos, CAD/3D, interfaces imersivas, HMIs industriais ou superfícies altamente especializadas sem formalização própria.

### Como ler Shell Patterns

Cada Shell Pattern declara os seguintes campos mínimos obrigatórios:

- **ID_SHELL_PATTERN** - identificador canônico global no formato `SHP-<NOME_CANONICO>`
- **Definição curta** - frase curta que ancora a semântica do shell
- **Objetivo estrutural** - o que este shell resolve no enquadramento global
- **Interação dominante** - tipo principal de uso esperado
- **Não confundir com** - shells próximos mas estruturalmente distintos
- **Sinais de escolha** - indícios objetivos para seleção do shell
- **Modelo de navegação global** - organização dominante de navegação e acesso
- **Compatibilidade Primária** - Page Patterns tipicamente adequados a este shell
- **Compatibilidade Secundária** - Page Patterns possíveis mas não dominantes
- **Incompatibilidades explícitas** - padrões ou cenários que não devem definir este shell
- **Limites** - fronteiras de validade do shell
- **Estrutura Desktop** - organização dominante em Desktop
- **Estrutura Mobile** - organização dominante em Mobile
- **Regra de transição** - o que muda e o que deve permanecer entre Desktop e Mobile
- **Grau de Rigidez** - Alto, Médio ou Baixo

### Limites do catálogo de Shell Patterns

- descreve famílias estruturais canônicas, não shells instanciados por projeto
- não substitui módulos, páginas, fluxos ou UI Patterns
- um dashboard local dentro de um backoffice não converte automaticamente o shell em `Dashboard/Analytics`
- shells híbridos são permitidos, mas exigem shell principal explícito e justificativa rastreável

### Shell Patterns canônicos

#### Workspace/Admin

**ID_SHELL_PATTERN:** SHP-WORKSPACE_ADMIN
**Definição curta:** Shell operacional para backoffice, gestão, CRUD e trabalho contínuo em múltiplos módulos.
**Objetivo estrutural:** Sustentar operação recorrente, navegação persistente e alta densidade funcional.
**Interação dominante:** Operacional
**Não confundir com:** Dashboard/Analytics dominante, Portal, Studio/Workbench
**Sinais de escolha:** múltiplos módulos; uso interno; gestão recorrente de entidades; alternância frequente entre listas, detalhe, formulários e configurações
**Modelo de navegação global:** sidebar persistente, header operacional e ações globais por módulo
**Compatibilidade Primária:** PP-LIST-DETAIL, PP-FORM, PP-WIZARD, PP-DETAIL, PP-SETTINGS, PP-DASHBOARD, PP-BOARD
**Compatibilidade Secundária:** PP-CATALOG, PP-FEED, PP-CALENDAR, PP-MAP
**Incompatibilidades explícitas:** PP-LANDING como padrão dominante do shell
**Limites:** não é o shell principal adequado quando a experiência é predominantemente pública, editorial, conversacional ou centrada em canvas
**Estrutura Desktop:** navegação lateral persistente com área principal de trabalho e utilitários globais
**Estrutura Mobile:** navegação compacta equivalente com prioridade à tarefa corrente
**Regra de transição:** reduzir densidade e colapsar navegação sem perder acesso aos módulos principais
**Grau de Rigidez:** Alto

---

#### Portal

**ID_SHELL_PATTERN:** SHP-PORTAL
**Definição curta:** Shell para conteúdo público, institucional, descoberta leve e jornadas lineares ou hierárquicas.
**Objetivo estrutural:** Sustentar navegação pública, clareza de entrada e progressão simples entre secções.
**Interação dominante:** Informativa
**Não confundir com:** Media/Content, Workspace/Admin, Transactional/Commerce
**Sinais de escolha:** conteúdo público; navegação linear ou hierárquica; baixa densidade operacional; foco em descoberta, leitura, onboarding ou autoatendimento leve
**Modelo de navegação global:** header superior, navegação simples, rodapé informativo e CTAs claros
**Compatibilidade Primária:** PP-LANDING, PP-DETAIL, PP-CATALOG, PP-FEED
**Compatibilidade Secundária:** PP-FORM, PP-WIZARD, PP-CALENDAR
**Incompatibilidades explícitas:** PP-LIST-DETAIL como padrão dominante multi-módulo
**Limites:** não deve ser o shell principal de sistemas internos densos, operações complexas ou monitoramento contínuo
**Estrutura Desktop:** header superior com navegação horizontal e corpo linear por secções
**Estrutura Mobile:** header compacto, menu recolhível e fluxo vertical dominante
**Regra de transição:** preservar clareza de navegação e CTAs com simplificação progressiva da hierarquia
**Grau de Rigidez:** Médio

---

#### Communication

**ID_SHELL_PATTERN:** SHP-COMMUNICATION
**Definição curta:** Shell orientado a conversa, inbox, threads e comunicação em tempo real.
**Objetivo estrutural:** Sustentar troca contínua de mensagens, contexto conversacional e atualização frequente.
**Interação dominante:** Comunicacional
**Não confundir com:** Feed social, Workspace/Admin genérico, Portal
**Sinais de escolha:** thread como centro da tarefa; presença de inbox; atualização em tempo real; histórico de mensagens; necessidade de contexto conversacional persistente
**Modelo de navegação global:** inbox, lista de threads, áreas de conversa e contexto lateral complementar
**Compatibilidade Primária:** PP-CONVERSATION, PP-LIST-DETAIL, PP-FEED
**Compatibilidade Secundária:** PP-DETAIL, PP-SETTINGS
**Incompatibilidades explícitas:** PP-LANDING como padrão dominante do shell
**Limites:** não é adequado quando a conversa é apenas um recurso auxiliar e não a estrutura principal da experiência
**Estrutura Desktop:** lista de conversas e thread ativa com contexto complementar simultâneo
**Estrutura Mobile:** alternância entre inbox e thread ativa, priorizando foco único
**Regra de transição:** simultaneidade em Desktop evolui para sequência navegável em Mobile
**Grau de Rigidez:** Alto

---

#### Media/Content

**ID_SHELL_PATTERN:** SHP-MEDIA_CONTENT
**Definição curta:** Shell para descoberta, consumo e navegação de conteúdo, catálogo ou mídia.
**Objetivo estrutural:** Sustentar exploração, comparação leve, consumo recorrente e continuidade de descoberta.
**Interação dominante:** Exploratória
**Não confundir com:** Portal institucional, Dashboard/Analytics, Transactional/Commerce
**Sinais de escolha:** catálogo, feed, coleções, descoberta, recomendação, consumo de mídia ou conteúdo como atividade principal
**Modelo de navegação global:** navegação superior ou lateral leve, busca proeminente e acesso rápido a coleções e recomendações
**Compatibilidade Primária:** PP-CATALOG, PP-FEED, PP-DETAIL, PP-LANDING
**Compatibilidade Secundária:** PP-MAP, PP-CALENDAR
**Incompatibilidades explícitas:** PP-LIST-DETAIL operacional como padrão dominante
**Limites:** não é o shell adequado para operações densas, workflows transacionais complexos ou edição técnica de artefactos
**Estrutura Desktop:** navegação leve com áreas de descoberta, destaques e conteúdo principal
**Estrutura Mobile:** foco em scroll, descoberta contínua e navegação compacta
**Regra de transição:** preservar descoberta e continuidade de consumo com simplificação da navegação periférica
**Grau de Rigidez:** Médio

---

#### Dashboard/Analytics

**ID_SHELL_PATTERN:** SHP-DASHBOARD_ANALYTICS
**Definição curta:** Shell orientado a monitoramento, leitura analítica e observação de métricas.
**Objetivo estrutural:** Sustentar leitura de KPIs, tendências, estados operacionais e resposta rápida a desvios.
**Interação dominante:** Analítica
**Não confundir com:** Workspace/Admin com dashboard inicial, Portal informativo, Studio/Workbench
**Sinais de escolha:** métricas dominantes; leitura frequente de KPIs; filtros temporais; alertas; necessidade de correlação visual de indicadores
**Modelo de navegação global:** navegação curta por áreas analíticas, filtros globais, painéis e drill-downs controlados
**Compatibilidade Primária:** PP-DASHBOARD, PP-DETAIL, PP-MAP
**Compatibilidade Secundária:** PP-LIST-DETAIL, PP-CALENDAR
**Incompatibilidades explícitas:** PP-LANDING como padrão dominante; PP-WIZARD como experiência principal
**Limites:** não deve ser tratado como shell principal quando a tarefa primária é executar operações transacionais extensas
**Estrutura Desktop:** áreas analíticas com grade de métricas, filtros globais e painéis comparativos
**Estrutura Mobile:** visão resumida por blocos, drill-down progressivo e filtros compactos
**Regra de transição:** reduzir densidade simultânea sem perder leitura hierárquica dos indicadores
**Grau de Rigidez:** Alto

---

#### Studio/Workbench

**ID_SHELL_PATTERN:** SHP-STUDIO_WORKBENCH
**Definição curta:** Shell de ferramenta para criação, edição, composição e manipulação técnica de artefactos.
**Objetivo estrutural:** Sustentar trabalho focado em superfície principal de edição com painéis de apoio, inspeção e ferramentas.
**Interação dominante:** Composicional
**Não confundir com:** Workspace/Admin, Dashboard/Analytics, Media/Content
**Sinais de escolha:** canvas ou editor como centro da tarefa; painéis de propriedades; ferramentas persistentes; layers, assets ou inspector; operações de criação contínua
**Modelo de navegação global:** superfície principal de trabalho com painéis laterais, toolbar, inspector e utilitários contextuais
**Compatibilidade Primária:** PP-CANVAS, PP-BOARD, PP-DETAIL
**Compatibilidade Secundária:** PP-FORM, PP-SETTINGS
**Incompatibilidades explícitas:** PP-LANDING, PP-FEED como experiência dominante
**Limites:** não é o shell certo para CRUD clássico, consumo editorial ou jornadas públicas simples
**Estrutura Desktop:** superfície central dominante com painéis laterais simultâneos e toolbar persistente
**Estrutura Mobile:** versão reduzida, focada em revisão, ajustes pontuais ou tarefas secundárias
**Regra de transição:** preservar o foco na superfície principal, mesmo quando a edição completa precisar ser reduzida ou sequenciada
**Grau de Rigidez:** Alto

---

#### Transactional/Commerce

**ID_SHELL_PATTERN:** SHP-TRANSACTIONAL_COMMERCE
**Definição curta:** Shell para descoberta orientada à conversão, transação e acompanhamento de pedidos ou reservas.
**Objetivo estrutural:** Sustentar percurso de escolha, comparação, decisão, checkout e acompanhamento transacional.
**Interação dominante:** Transacional
**Não confundir com:** Portal genérico, Media/Content, Workspace/Admin
**Sinais de escolha:** catálogo com intenção de compra ou reserva; carrinho; checkout; pagamento; histórico de pedidos; conversão como objetivo principal
**Modelo de navegação global:** navegação orientada a descoberta, carrinho, conta e estado transacional
**Compatibilidade Primária:** PP-CATALOG, PP-DETAIL, PP-FORM, PP-WIZARD
**Compatibilidade Secundária:** PP-LANDING, PP-CALENDAR
**Incompatibilidades explícitas:** PP-DASHBOARD como experiência dominante de entrada
**Limites:** não é o shell adequado para gestão interna extensa ou para editores técnicos centrados em canvas
**Estrutura Desktop:** navegação clara para descoberta, conta e transação, com CTAs persistentes de conversão
**Estrutura Mobile:** fluxo simplificado, CTA prioritário e transições curtas entre descoberta e checkout
**Regra de transição:** reduzir fricção e preservar continuidade do estado transacional em todas as faixas
**Grau de Rigidez:** Alto

---

#### Kiosk/Embedded

**ID_SHELL_PATTERN:** SHP-KIOSK_EMBEDDED
**Definição curta:** Shell para dispositivos dedicados, atendimento assistido, contexto embarcado ou uso full-screen com fluxo restrito.
**Objetivo estrutural:** Sustentar tarefas rápidas, foco extremo, baixo desvio e integração com contexto físico ou hardware.
**Interação dominante:** Guiada
**Não confundir com:** Portal, Workspace/Admin, Studio/Workbench
**Sinais de escolha:** dispositivo dedicado; touchscreen; fluxo curto; contexto físico; sessões efémeras; navegação muito restrita; integração com periféricos
**Modelo de navegação global:** navegação mínima, full-screen, ações grandes e progressão guiada
**Compatibilidade Primária:** PP-FORM, PP-WIZARD, PP-DETAIL
**Compatibilidade Secundária:** PP-CALENDAR, PP-DASHBOARD, PP-MAP
**Incompatibilidades explícitas:** PP-LIST-DETAIL multi-módulo; PP-CANVAS como experiência principal
**Limites:** não deve ser usado como shell principal para sistemas com exploração livre, multitarefa rica ou navegação profunda
**Estrutura Desktop:** quando existe, tende a fullscreen, com poucos destinos e alta legibilidade
**Estrutura Mobile:** comportamento equivalente, priorizando toque, foco e baixo desvio
**Regra de transição:** preservar foco absoluto na tarefa e minimizar caminhos alternativos
**Grau de Rigidez:** Alto

---

## Catálogo oficial de Page Patterns

[INSTRUÇÃO]
Page Pattern é o padrão estrutural dominante de uma página concreta.
Define tipo de interação, zonas funcionais obrigatórias, distribuição macro da página e família principal de UI Patterns esperada.

[INSTRUÇÃO]
Page Pattern não define componente técnico final, preset visual, biblioteca, shell do sistema ou detalhe de implementação.

### Como ler Page Patterns

Cada Page Pattern declara os seguintes campos mínimos obrigatórios:

- **ID_PAGE_PATTERN** - identificador canônico global no formato `PP-<NOME_CANONICO>`
- **Definição curta** - frase curta que ancora a semântica da página
- **Objetivo estrutural** - o que este pattern resolve ao nível da página
- **Interação dominante** - tipo principal de trabalho esperado
- **Não confundir com** - Page Patterns próximos mas não equivalentes
- **Sinais de escolha** - indícios objetivos para selecionar o pattern
- **Zonas funcionais obrigatórias** - áreas sem as quais a página perde identidade estrutural
- **UI Patterns tipicamente obrigatórios** - padrões de UI que costumam ser necessários
- **Compatibilidade Primária** - Shell Patterns onde este page pattern é tipicamente adequado
- **Compatibilidade Secundária** - Shell Patterns onde pode aparecer condicionalmente
- **Incompatibilidades explícitas** - shells ou cenários onde não deve ser dominante
- **Limites** - fronteiras de validade do pattern
- **Estrutura Desktop** - organização dominante em Desktop
- **Estrutura Mobile** - organização dominante em Mobile
- **Regra de transição** - o que muda e o que deve permanecer entre Desktop e Mobile
- **Grau de Rigidez** - Alto, Médio ou Baixo

### Limites do catálogo de Page Patterns

- descreve a estrutura dominante da página, não todas as variações locais
- cada página concreta deve declarar um único Page Pattern dominante
- modais, drawers, overlays, sheets e diálogos não são Page Patterns
- alguns patterns especializados podem depender de superfícies de UI ainda não formalizadas neste catálogo de UI Patterns; nesses casos o limite deve ser declarado explicitamente

### Page Patterns canônicos

#### PP-LIST-DETAIL

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

---

#### PP-CATALOG

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

---

#### PP-FORM

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

---

#### PP-WIZARD

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

---

#### PP-DASHBOARD

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

---

#### PP-DETAIL

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

---

#### PP-LANDING

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

---

#### PP-CONVERSATION

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

---

#### PP-FEED

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

---

#### PP-SETTINGS

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

---

#### PP-BOARD

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

---

#### PP-CALENDAR

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

---

#### PP-MAP

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

---

#### PP-CANVAS

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

---

## Como Ler o Catálogo de UI Patterns

Cada UI Pattern declara os seguintes campos obrigatórios:

- **ID_UI_PATTERN** — identificador canônico global (conforme regra acima)
- **Nome** — identificador canónico do padrão
- **Categoria** — grupo funcional ao qual pertence
- **Definição curta** — frase curta que ancora a semântica do padrão
- **Objetivo estrutural** — o que este padrão resolve estruturalmente
- **Não confundir com** — padrões próximos ou estruturas que não são equivalentes a este padrão
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

Campos opcionais de apoio à decisão podem ser adicionados quando trouxerem clareza real:

- **Quando usar**
- **Quando evitar**
- **Alternativas próximas**
- **Sinais de escolha**
- **Zonas usuais**
- **Variantes reconhecidas**
- **Comportamento por faixa responsiva**

[NOTA DE INTERPRETAÇÃO]
Os campos:

- **Estrutura Desktop**
- **Estrutura Mobile**
- **Regra de Transição**

devem ser lidos como descrição de invariantes estruturais e variantes aceitáveis do padrão.

Eles **não** definem uma implementação técnica única, nem devem ser usados para deduzir sozinho o componente real de uma library.

Quando um padrão exigir precisão adicional para heurística visual, pode ser usado o campo opcional **Comportamento por faixa responsiva**, descrevendo faixas conceituais como `Large Desktop`, `Desktop`, `Tablet` e `Mobile` sem amarrar breakpoints concretos.

---

# Grupo 1 — Estruturais

Organizam o espaço da página. Não têm conteúdo próprio — contêm outros UI Patterns.

---

## Layout Zone

**ID_UI_PATTERN:** UIP-STRUCT-LAYOUT_ZONE
**Categoria:** Estrutural
**Definição curta:** Região funcional da interface que agrupa conteúdo com responsabilidade própria dentro de uma página ou shell.
**Objetivo estrutural:** Delimitar uma área funcional da página com responsabilidade distinta. Âncora que agrupa os UI Patterns de uma zona.
**Não confundir com:** Shell de navegação completo, Split Panel, Grid Container usado só para distribuição visual
**Nível composicional possível:** Root, Container
**Quando usar:**
- quando a página precisa separar responsabilidades funcionais em áreas distintas
- quando a mesma página combina listagem, detalhe, filtros, ações ou conteúdo auxiliar
- quando a zona precisa agrupar outros UIPs sem virar um padrão semântico próprio
**Quando evitar:**
- quando a necessidade real é apenas distribuir colunas ou espaçamento visual
- quando a estrutura exige dois painéis com simultaneidade explícita
- quando a área inteira já é o shell de navegação da experiência
**Alternativas próximas:** UIP-STRUCT-SPLIT_PANEL, UIP-STRUCT-GRID_CONTAINER, Shell/Workspace Container
**Sinais de escolha:**
- existe uma zona funcional nomeável na página
- a zona tem responsabilidade própria e pode reagir a estados localizados
- a zona contém outros UIPs, não apenas conteúdo solto
- a página precisa explicitar cabeçalho, filtro, lista, detalhe ou ações em áreas separadas
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

---

## Split Panel

**ID_UI_PATTERN:** UIP-STRUCT-SPLIT_PANEL
**Categoria:** Estrutural
**Definição curta:** Estrutura de dois painéis com responsabilidades simultâneas e complementares.
**Objetivo estrutural:** Dividir a área principal em dois painéis com responsabilidades distintas e simultâneas.
**Não confundir com:** Layout Zone genérica, Grid Container multicoluna, Tabs de alternância local
**Nível composicional possível:** Root, Container
**Quando usar:**
- quando duas áreas precisam coexistir e interagir ao mesmo tempo
- quando a escolha em um painel altera o conteúdo do outro
- quando a experiência depende de contexto simultâneo entre lista e detalhe ou áreas equivalentes
**Quando evitar:**
- quando as áreas podem ser apenas empilhadas sem perda de contexto
- quando a navegação é livre entre vistas e não simultânea
- quando a tela é essencialmente formulário ou conteúdo linear
**Alternativas próximas:** UIP-STRUCT-LAYOUT_ZONE, UIP-NAV-TABS, fluxo sequencial de detalhe
**Sinais de escolha:**
- existem duas responsabilidades fortes no mesmo espaço
- simultaneidade importa
- a navegação de um lado alimenta o conteúdo do outro
- o utilizador beneficia de comparação ou contexto paralelo
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

---

## Scrollable Region

**ID_UI_PATTERN:** UIP-STRUCT-SCROLLABLE_REGION
**Categoria:** Estrutural
**Definição curta:** Região com scroll próprio, independente do scroll principal da página.
**Objetivo estrutural:** Delimitar uma área com scroll independente do restante da página.
**Não confundir com:** página inteira rolável, Layout Zone sem scroll independente, Feed completo
**Nível composicional possível:** Container
**Quando usar:**
- quando uma subárea precisa rolar sem deslocar toda a página
- quando a experiência exige foco local em lista, feed ou conversa
- quando a altura da região é delimitada pelo contexto estrutural
**Quando evitar:**
- quando o scroll da página inteira resolve naturalmente
- quando o conteúdo da área é pequeno e estável
- quando múltiplas regiões roláveis degradariam a usabilidade
**Alternativas próximas:** página com scroll único, UIP-STRUCT-LAYOUT_ZONE, UIP-DATA-TIMELINE_ITEM em feed simples
**Sinais de escolha:**
- a região tem altura definida
- o conteúdo pode crescer independentemente do resto da página
- o utilizador precisa interagir longamente com a área sem perder o entorno
- o scroll local faz parte da tarefa
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

---

## Stack Container

**ID_UI_PATTERN:** UIP-STRUCT-STACK_CONTAINER
**Categoria:** Estrutural
**Definição curta:** Contêiner que organiza elementos em sequência vertical com espaçamento coerente.
**Objetivo estrutural:** Organizar UI Patterns em sequência vertical com espaçamento consistente.
**Não confundir com:** Form Field Group semântico, Layout Zone com responsabilidade própria, Grid Container
**Nível composicional possível:** Container
**Quando usar:**
- quando o conteúdo deve ser lido ou percorrido verticalmente
- quando a zona combina vários blocos sem necessidade de grade
- quando a clareza depende de empilhamento simples e previsível
**Quando evitar:**
- quando o agrupamento precisa de semântica própria de formulário ou detalhe
- quando a composição real é de múltiplas colunas
- quando a relação entre elementos é simultânea e lateral
**Alternativas próximas:** UIP-STRUCT-GRID_CONTAINER, UIP-INPUT-FORM_FIELD_GROUP, UIP-STRUCT-LAYOUT_ZONE
**Sinais de escolha:**
- os filhos são consumidos em ordem vertical
- o espaçamento uniforme é relevante
- a zona não precisa de layout em grade
- o contêiner é puramente estrutural
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

---

## Grid Container

**ID_UI_PATTERN:** UIP-STRUCT-GRID_CONTAINER
**Categoria:** Estrutural
**Definição curta:** Contêiner de organização em grade para distribuir elementos por colunas e linhas.
**Objetivo estrutural:** Organizar UI Patterns em grelha de múltiplas colunas.
**Não confundir com:** Card Grid semântico de coleção, Layout Zone funcional, Data Table
**Nível composicional possível:** Container
**Quando usar:**
- quando a composição exige distribuição em múltiplas colunas
- quando os blocos precisam manter alinhamento visual em grade
- quando o layout responde por densidade e distribuição, não por semântica de coleção
**Quando evitar:**
- quando a intenção é uma coleção visual de cards
- quando a leitura é predominantemente linear
- quando a zona tem significado funcional próprio além da distribuição
**Alternativas próximas:** UIP-DATA-CARD_GRID, UIP-STRUCT-STACK_CONTAINER, UIP-STRUCT-LAYOUT_ZONE
**Sinais de escolha:**
- a grade serve à composição dos blocos
- colunas variáveis fazem sentido
- os elementos compartilham alinhamento visual, não papel semântico comum
- a ordem deve ser preservada entre faixas responsivas
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

---

# Grupo 2 — Navegação

---

## Navigation Menu

**ID_UI_PATTERN:** UIP-NAV-NAVIGATION_MENU
**Categoria:** Navegação
**Definição curta:** Navegação estrutural principal que dá acesso aos destinos globais do sistema ou do shell activo.
**Objetivo estrutural:** Acesso estruturado aos módulos e secções do sistema. Âncora de navegação global.
**Não confundir com:** Tabs para vistas irmãs na mesma página, Breadcrumb para contexto hierárquico, menu contextual de ações
**Nível composicional possível:** Root
**Quando usar:**
- quando o utilizador precisa acessar módulos, áreas ou secções globais do sistema
- quando o shell exige navegação persistente entre destinos principais
- quando a hierarquia de navegação deve permanecer disponível ao longo da sessão
**Quando evitar:**
- quando a alternância é apenas entre vistas locais da mesma página
- quando a necessidade é contextual a um item específico
- quando a navegação existe só dentro de um fluxo sequencial
**Alternativas próximas:** UIP-NAV-TABS, UIP-NAV-BREADCRUMB, UIP-ACTION-CONTEXTUAL_MENU
**Sinais de escolha:**
- destinos representam módulos ou secções globais
- a navegação precisa sobreviver à troca de páginas internas
- há relação forte com o shell activo
- permissões podem ocultar ou desactivar destinos inteiros
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

---

## Breadcrumb

**ID_UI_PATTERN:** UIP-NAV-BREADCRUMB
**Categoria:** Navegação
**Definição curta:** Trilha hierárquica que mostra onde o utilizador está e como voltar a níveis anteriores.
**Objetivo estrutural:** Orientar o utilizador na hierarquia de navegação actual e permitir retorno a níveis anteriores.
**Não confundir com:** Navigation Menu global, Tabs locais, botão simples de voltar sem contexto hierárquico
**Nível composicional possível:** Leaf
**Quando usar:**
- quando a página está inserida numa hierarquia de navegação real
- quando o utilizador pode precisar regressar a níveis anteriores com contexto
- quando o detalhe ou viewer deriva de navegação progressiva por níveis
**Quando evitar:**
- quando a página é topo de módulo sem hierarquia relevante
- quando a navegação local é entre vistas irmãs
- quando um simples retorno resolve sem perda de contexto
**Alternativas próximas:** UIP-NAV-NAVIGATION_MENU, botão voltar, UIP-NAV-TABS
**Sinais de escolha:**
- existe caminho hierárquico identificável
- níveis anteriores precisam continuar acessíveis
- a localização actual importa para orientação
- a página não é apenas uma aba ou estado local
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

---

## Tabs

**ID_UI_PATTERN:** UIP-NAV-TABS
**Categoria:** Navegação
**Definição curta:** Navegação local entre vistas irmãs da mesma página ou da mesma zona, sem trocar o papel estrutural principal da tela.
**Objetivo estrutural:** Alternar entre vistas ou secções dentro da mesma página sem navegação de rota.
**Não confundir com:** Navigation Menu global, Stepper Indicator sequencial, Accordion de conteúdo colapsável
**Nível composicional possível:** Container
**Quando usar:**
- quando várias vistas compartilham o mesmo contexto de página
- quando o utilizador precisa alternar entre secções irmãs sem perder o contexto principal
- quando o conteúdo activo deve trocar sem reestruturar o shell
**Quando evitar:**
- quando a navegação é global do sistema
- quando existe sequência obrigatória entre etapas
- quando a quantidade de opções torna a leitura horizontal instável
**Alternativas próximas:** UIP-NAV-NAVIGATION_MENU, UIP-NAV-STEPPER_INDICATOR, selector/dropdown de vistas
**Sinais de escolha:**
- vistas irmãs partilham o mesmo cabeçalho ou mesmo contexto
- o utilizador pode alternar livremente entre secções
- apenas uma vista fica activa por vez
- a zona de conteúdo abaixo muda, mas a página continua a mesma
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

---

## Pagination

**ID_UI_PATTERN:** UIP-NAV-PAGINATION
**Categoria:** Navegação
**Definição curta:** Navegação sequencial entre páginas discretas de uma coleção volumosa.
**Objetivo estrutural:** Navegar entre páginas de um conjunto de resultados volumoso.
**Não confundir com:** Scroll infinito, Stepper Indicator, Tabs de vistas locais
**Nível composicional possível:** Leaf
**Quando usar:**
- quando a coleção é grande e segmentada em páginas discretas
- quando controlo explícito de página, total e avanço faz sentido
- quando performance ou previsibilidade favorecem paginação em vez de rolagem contínua
**Quando evitar:**
- quando a experiência é naturalmente contínua ou cronológica
- quando o volume é pequeno o suficiente para uma única lista
- quando a navegação por etapas representa fluxo e não resultados
**Alternativas próximas:** scroll infinito, UIP-NAV-STEPPER_INDICATOR, carregamento progressivo
**Sinais de escolha:**
- há total ou subconjuntos discretos de resultados
- o utilizador precisa voltar a páginas específicas
- anterior/próxima e página actual são conceitos relevantes
- a coleção não é consumida melhor por feed contínuo
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

---

## Stepper Indicator

**ID_UI_PATTERN:** UIP-NAV-STEPPER_INDICATOR
**Categoria:** Navegação
**Definição curta:** Indicador de progresso e posição dentro de um fluxo sequencial com etapas explícitas.
**Objetivo estrutural:** Indicar progresso e posição num fluxo multi-etapas com sequência obrigatória.
**Não confundir com:** Tabs de alternância livre, Breadcrumb hierárquico, Navigation Menu global
**Nível composicional possível:** Leaf, Container (quando integrado ao cabeçalho do fluxo)
**Quando usar:**
- quando o utilizador precisa entender em que etapa está e quantas faltam
- quando o fluxo tem sequência explícita e avanço controlado
- quando a navegação entre passos depende do estado do próprio fluxo
**Quando evitar:**
- quando a alternância entre secções é livre
- quando a navegação é global ou hierárquica
- quando a página só precisa exibir progresso genérico sem etapas nomeáveis
**Alternativas próximas:** UIP-NAV-TABS, UIP-NAV-BREADCRUMB, indicador simples de progresso
**Sinais de escolha:**
- existe ordem explícita entre etapas
- a etapa actual precisa ser clara
- etapas concluídas e futuras têm valor de orientação
- o fluxo depende de progressão e validação
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

---

# Grupo 3 — Dados & Listagem

---

## Data Table

**ID_UI_PATTERN:** UIP-DATA-DATA_TABLE
**Categoria:** Dados & Listagem
**Definição curta:** Representação tabular de colecções com comparação por linha e coluna, normalmente com ações e seleção.
**Objetivo estrutural:** Apresentar colecções de entidades em formato tabular com acções por linha e selecção múltipla.
**Não confundir com:** Card Grid exploratório, List Item simples, planilha livre de edição massiva
**Nível composicional possível:** Root, Container (contém Action Bar, Pagination)
**Quando usar:**
- quando o utilizador precisa comparar múltiplos atributos por linha
- quando há seleção em lote, ordenação, filtros e ações operacionais
- quando a densidade informacional é mais importante que apelo exploratório
**Quando evitar:**
- quando a apresentação depende de imagem, identidade visual ou descoberta exploratória
- quando a coleção tem poucos atributos e leitura linear simples
- quando a interação principal é cronológica, conversacional ou editorial
**Alternativas próximas:** UIP-DATA-CARD_GRID, UIP-DATA-LIST_ITEM, variante Kanban/Board
**Sinais de escolha:**
- comparação por colunas é relevante
- existem ações por linha ou seleção múltipla
- ordenação e paginação fazem sentido
- a coleção tem estrutura previsível por atributo
**Zonas usuais:** List, Table-Area, Results
**Compatibilidade Primária:** List+Detail
**Compatibilidade Secundária:** Dashboard
**Incompatibilidades explícitas:** Feed/Timeline, Catalog/Grid, Conversation
**Estrutura Desktop:** Tabela com cabeçalho fixo, linhas de dados, coluna de acções, checkbox de selecção, ordenação por coluna clicável. Action Bar acima. Pagination abaixo.
**Estrutura Mobile:** Representação tabular compacta ou híbrida. Pode reduzir densidade, colapsar colunas secundárias, usar detalhe expandido e redistribuir ações para overflow contextual.
**Regra de Transição:** Tabela completa → tabela compacta ou híbrida. Informação crítica e ações essenciais nunca podem ser omitidas; podem ser reorganizadas para formatos touch-friendly.
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
**Definição curta:** Unidade simples de listagem para leitura linear e ação localizada sobre um item.
**Objetivo estrutural:** Representar um item individual dentro de uma lista simples.
**Não confundir com:** Data Table com comparação por colunas, Card Grid exploratório, Timeline Item cronológico
**Nível composicional possível:** Leaf
**Quando usar:**
- quando a leitura principal é item a item, em sequência linear
- quando a coleção é simples ou de baixa densidade informacional
- quando o foco está em título, subtítulo e poucos metadados
**Quando evitar:**
- quando comparação por múltiplos atributos é central
- quando imagem e apelo visual são dominantes
- quando a ordem temporal e o contexto de evento são o centro da experiência
**Alternativas próximas:** UIP-DATA-DATA_TABLE, UIP-DATA-CARD_GRID, UIP-DATA-TIMELINE_ITEM
**Sinais de escolha:**
- cada item cabe em uma linha ou bloco simples
- poucos atributos precisam ficar visíveis ao mesmo tempo
- ações por item são leves e localizadas
- a lista pode ser percorrida rapidamente em sequência
**Zonas usuais:** List, Search Results, Navigation List
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
**Definição curta:** Grade de itens visuais para exploração, descoberta e comparação leve entre cards.
**Objetivo estrutural:** Apresentar colecções de itens em formato visual exploratório com ênfase em imagem ou identidade visual.
**Não confundir com:** Data Table operacional, List Item linear, Grid Container apenas estrutural
**Nível composicional possível:** Root, Container
**Quando usar:**
- quando a descoberta visual ou identidade do item ajuda a decisão
- quando imagem, ícone ou resumo visual têm peso real
- quando a coleção beneficia de exploração em grade e leitura mais livre
**Quando evitar:**
- quando a operação exige comparação densa por atributo
- quando há muitas ações complexas por item
- quando o contexto é puramente cronológico ou conversacional
**Alternativas próximas:** UIP-DATA-DATA_TABLE, UIP-DATA-LIST_ITEM, UIP-STRUCT-GRID_CONTAINER
**Sinais de escolha:**
- cada item tem representação visual própria
- a coleção é exploratória ou catálogo
- poucos dados estruturados bastam por item
- a navegação parte do reconhecimento visual
**Zonas usuais:** Catalog Area, Grid Results, Dashboard Collections
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
**Definição curta:** Entrada cronológica de evento, actividade ou histórico em uma linha temporal.
**Objetivo estrutural:** Representar um evento ou entrada num feed cronológico ou histórico de actividade.
**Não confundir com:** List Item genérico, card de catálogo, mensagem conversacional
**Nível composicional possível:** Leaf
**Quando usar:**
- quando tempo, sequência e histórico importam
- quando cada item representa um evento ou actualização
- quando o utilizador precisa percorrer atividade em ordem temporal
**Quando evitar:**
- quando a coleção é operacional e comparativa
- quando a experiência é de catálogo ou grid
- quando a interação principal é diálogo bidirecional
**Alternativas próximas:** UIP-DATA-LIST_ITEM, UIP-DATA-CARD_GRID, item de conversation
**Sinais de escolha:**
- a ordem temporal é central
- cada item representa evento ou atividade
- timestamp e contexto do evento são relevantes
- o histórico pode crescer continuamente
**Zonas usuais:** Feed List, Activity History, Audit Trail
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
**Definição curta:** Coluna de board que agrupa itens por estado, etapa ou categoria operacional.
**Objetivo estrutural:** Agrupar e apresentar itens por categoria/estado em formato de coluna arrastável.
**Não confundir com:** Data Table por status, Grid Container estrutural, Split Panel de duas áreas
**Nível composicional possível:** Container
**Quando usar:**
- quando o fluxo é melhor entendido por estados ou colunas
- quando mover itens entre categorias faz parte da tarefa
- quando a visão de board agrega mais valor que lista linear
**Quando evitar:**
- quando comparação tabular é mais importante
- quando a coleção não tem estados ou agrupamentos claros
- quando o mobile não consegue sustentar a interação de board sem perda excessiva
**Alternativas próximas:** UIP-DATA-DATA_TABLE, board simplificado por listas, UIP-STRUCT-GRID_CONTAINER
**Sinais de escolha:**
- os itens pertencem a colunas semânticas
- mudança de estado é recorrente
- a visão horizontal por coluna ajuda a operação
- drag-and-drop ou equivalente faz sentido
**Zonas usuais:** Board Area, Workflow Board, Stage Columns
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
**Definição curta:** Agrupamento lógico de campos relacionados, com validação e feedback coerentes dentro da mesma secção.
**Objetivo estrutural:** Agrupar campos de entrada relacionados numa secção lógica com validação e feedback.
**Não confundir com:** Filter Panel para refinamento de colecções, Detail Block para leitura, formulário inteiro de múltiplas secções
**Nível composicional possível:** Container, Leaf
**Quando usar:**
- quando vários campos pertencem à mesma secção lógica de captura
- quando a validação e o feedback precisam ficar associados ao grupo
- quando a tela exige organização clara por blocos de formulário
**Quando evitar:**
- quando a intenção é filtrar resultados e não persistir dados
- quando a zona é apenas leitura estruturada
- quando um único campo isolado resolve a interação
**Alternativas próximas:** UIP-INPUT-FILTER_PANEL, UIP-CONTENT-DETAIL_BLOCK, campo isolado
**Sinais de escolha:**
- campos compartilham um mesmo objetivo de edição
- existe título ou agrupamento de secção
- validação do grupo é relevante
- a captura acontece por bloco, não só por campo isolado
**Zonas usuais:** Form Body, Settings Section, Step Body
**Compatibilidade Primária:** Form, Settings, Wizard/Stepper
**Compatibilidade Secundária:** Detail/Viewer (edição inline de secção)
**Incompatibilidades explícitas:** Não substitui Filter Panel em contexto de filtros
**Estrutura Desktop:** Secção com título opcional, campos em 1 ou 2 colunas, validação inline abaixo de cada campo.
**Estrutura Mobile:** Campos em coluna única. Títulos preservados. Teclado nativo considerado no layout.
**Regra de Transição:** 2 colunas → 1 coluna. Campos em largura completa. Validação inline preservada.
**Estados próprios:** vazio, preenchendo, válido, com erro de validação, desactivado, somente leitura, a submeter
**Reação a estados da página:** Error State (submissão) → campos com erro destacados. Loading State (submissão) → campos desactivados.
**Grau de Rigidez:** Médio
**Variantes reconhecidas:**
- Secção de formulário simples
- Grupo de campos repetíveis ou compostos

---

## Search Bar

**ID_UI_PATTERN:** UIP-INPUT-SEARCH_BAR
**Categoria:** Entrada
**Definição curta:** Entrada textual de busca para localizar itens, entidades ou conteúdo numa coleção.
**Objetivo estrutural:** Capturar termos de busca textual e iniciar pesquisa em colecção.
**Não confundir com:** Filter Panel estruturado, campo de formulário genérico, command palette global
**Nível composicional possível:** Leaf
**Quando usar:**
- quando a principal forma de localizar conteúdo é por termo textual
- quando o utilizador precisa refinar rapidamente grandes colecções
- quando sugestões, histórico ou autocomplete agregam valor à descoberta
**Quando evitar:**
- quando o refinamento depende de múltiplos atributos estruturados
- quando a interação principal é captura de dado persistente
- quando a busca não tem papel relevante na página
**Alternativas próximas:** UIP-INPUT-FILTER_PANEL, campo de formulário, command/search global
**Sinais de escolha:**
- há volume de itens que justifica busca textual
- o utilizador tende a conhecer nomes, termos ou códigos
- a busca pode disparar resultados ou sugestões
- a zona precisa suportar limpar e reexecutar busca
**Zonas usuais:** Header, List Toolbar, Catalog Header
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
**Definição curta:** Área de filtros estruturados para refinar coleções por atributos, estados ou facetas.
**Objetivo estrutural:** Filtrar colecções por múltiplos atributos estruturados com aplicação explícita ou reactiva.
**Não confundir com:** Search Bar textual, Form Field Group de captura, menu de ordenação simples
**Nível composicional possível:** Container
**Quando usar:**
- quando a coleção precisa ser refinada por múltiplos atributos
- quando facetas, intervalos, estados e filtros compostos fazem parte da navegação
- quando os filtros precisam permanecer visíveis ou acessíveis como bloco coerente
**Quando evitar:**
- quando um único termo textual resolve a busca
- quando a tela é formulário de captura e não refinamento de resultados
- quando os filtros são tão simples que cabem em controle único isolado
**Alternativas próximas:** UIP-INPUT-SEARCH_BAR, controlo de ordenação, UIP-INPUT-FORM_FIELD_GROUP
**Sinais de escolha:**
- existem vários atributos filtráveis
- filtros activos precisam ser visíveis e reversíveis
- o utilizador combina critérios
- o refinamento altera uma coleção já exibida
**Zonas usuais:** Filter, Sidebar, Results Toolbar
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
**Definição curta:** Controle estruturado para seleção de data única ou intervalo de datas.
**Objetivo estrutural:** Capturar data ou intervalo de datas de forma estruturada.
**Não confundir com:** campo textual livre, filtro genérico sem calendário, seletor de período exclusivamente analítico
**Nível composicional possível:** Leaf
**Quando usar:**
- quando a data ou intervalo é parte explícita da entrada ou do filtro
- quando calendário, validação de datas e restrições de período agregam valor
- quando o utilizador não deve digitar datas complexas livremente
**Quando evitar:**
- quando um texto livre basta e não há regra temporal relevante
- quando o período é pré-definido por atalhos fixos sem escolha granular
- quando a data é apenas exibida e não editada
**Alternativas próximas:** campo de texto com máscara, seletor de período predefinido, filtro simples
**Sinais de escolha:**
- a data é parte estrutural da ação ou filtro
- intervalo de datas pode ser necessário
- restrições como datas inválidas ou desactivadas importam
- o utilizador precisa apoio visual de calendário
**Zonas usuais:** Form Body, Filter Panel, Settings
**Compatibilidade Primária:** Form, Filter Panel
**Compatibilidade Secundária:** Settings
**Incompatibilidades explícitas:** Nenhuma fora de contexto de entrada
**Estrutura Desktop:** Campo de texto com ícone de calendário. Calendário em dropdown. Navegação por mês/ano. Selecção de intervalo opcional.
**Estrutura Mobile:** Pode usar modal, sheet ou picker nativo, conforme plataforma, granularidade da selecção e complexidade da interação.
**Regra de Transição:** Dropdown → variante mobile equivalente. Picker nativo pode substituir calendário custom quando melhorar consistência e usabilidade.
**Estados próprios:** vazio, com data seleccionada, com intervalo seleccionado, data inválida, data desactivada, calendário aberto
**Reação a estados da página:** Error State → campo com mensagem de data inválida ou obrigatória.
**Grau de Rigidez:** Médio

---

## Inline Editor

**ID_UI_PATTERN:** UIP-INPUT-INLINE_EDITOR
**Categoria:** Entrada
**Definição curta:** Edição localizada no próprio ponto de leitura, sem abrir formulário separado.
**Objetivo estrutural:** Permitir edição de um valor directamente no local onde é exibido, sem abrir Form separado.
**Não confundir com:** Form Field Group completo, edição em tabela massiva, Detail Block apenas de leitura
**Nível composicional possível:** Leaf
**Quando usar:**
- quando a edição é simples e localizada
- quando a leitura e a edição precisam coexistir no mesmo ponto
- quando abrir formulário separado seria fricção desnecessária
**Quando evitar:**
- quando múltiplos campos dependem um do outro
- quando a validação é complexa
- quando a edição precisa de contexto amplo ou confirmação extensa
**Alternativas próximas:** UIP-INPUT-FORM_FIELD_GROUP, edição em modal, Data Table editável
**Sinais de escolha:**
- o valor pode ser alterado isoladamente
- a edição pode acontecer em contexto de leitura
- o utilizador beneficia de mudança rápida
- a confirmação pode ser local e simples
**Zonas usuais:** Detail Block, Table Cell, Settings Value
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
**Definição curta:** Estado de ausência de dados ou resultados, com orientação sobre o próximo passo possível.
**Objetivo estrutural:** Comunicar ausência de dados e orientar o utilizador para o próximo passo.
**Não confundir com:** Error State por falha técnica, Toast/Alert por evento transitório, placeholder de loading
**Nível composicional possível:** Leaf
**Quando usar:**
- quando não há dados iniciais ou a busca/filtro não retornou resultados
- quando a zona ou página precisa explicar a ausência de conteúdo
- quando um CTA pode orientar criação, ajuste de filtros ou novo caminho
**Quando evitar:**
- quando a ausência decorre de erro técnico
- quando o feedback é transitório após uma ação
- quando o conteúdo ainda está a carregar
**Alternativas próximas:** UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-LOADING_STATE, UIP-FEEDBACK-TOAST_ALERT
**Sinais de escolha:**
- não há conteúdo para exibir
- a situação não é erro técnico
- existe orientação possível ao utilizador
- a zona pode ser substituída por mensagem e CTA
**Zonas usuais:** Content-Body, List, Table-Area, Detail-Panel
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
**Definição curta:** Estado visual de progresso enquanto conteúdo ou ação ainda está em carregamento ou processamento.
**Objetivo estrutural:** Indicar que dados ou acção estão em progresso.
**Não confundir com:** Empty State sem dados, Error State por falha, toast de ação concluída
**Nível composicional possível:** Leaf
**Quando usar:**
- quando conteúdo ou ação ainda não está pronto
- quando a página ou zona precisa preservar continuidade durante espera
- quando o utilizador deve perceber progresso ou indisponibilidade temporária
**Quando evitar:**
- quando já há falha técnica estabelecida
- quando não existe mais conteúdo esperado
- quando o feedback é apenas posterior a uma ação concluída
**Alternativas próximas:** UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-ERROR_STATE, indicador inline simples
**Sinais de escolha:**
- a operação está em curso
- o conteúdo será exibido depois
- a zona precisa sinalizar espera
- a interface deve evitar sensação de quebra
**Zonas usuais:** Content-Body, Table-Area, Form Submit, Panel Body
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
**Definição curta:** Feedback de falha técnica ou de recuperação necessária, com mensagem compreensível e caminho claro de retorno.
**Objetivo estrutural:** Comunicar falha técnica e oferecer caminho claro de recuperação.
**Não confundir com:** Empty State por ausência de dados, Toast / Alert pós-ação, No Permission State estrutural
**Nível composicional possível:** Leaf
**Quando usar:**
- quando o conteúdo ou a ação falhou por erro técnico, de rede, de permissão operacional ou de recurso não encontrado
- quando a página ou a zona precisa oferecer retry, alternativa ou orientação de recuperação
- quando a falha precisa substituir ou interromper a leitura normal do conteúdo
**Quando evitar:**
- quando não há erro e apenas não existem dados
- quando o feedback pode ser não bloqueante após uma ação concluída
- quando a situação pede confirmação antes de agir, não recuperação após falha
**Alternativas próximas:** UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-TOAST_ALERT, No Permission State
**Sinais de escolha:**
- carregamento ou submissão falhou
- há caminho de retry ou ação corretiva
- a falha precisa ser explicada no próprio contexto da zona ou página
- o conteúdo esperado não pode ser exibido normalmente
**Zonas usuais:** Content-Body, Detail-Panel, Form Body, Table-Area
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
**Definição curta:** Feedback não bloqueante sobre resultado de ação ou evento do sistema, em forma flutuante temporária ou alerta contextual persistente.
**Objetivo estrutural:** Notificar o utilizador de resultado de acção ou evento do sistema de forma não bloqueante, seja por toast flutuante temporário ou alerta inline/contextual.
**Não confundir com:** Error State que substitui conteúdo, Confirmation Dialog que exige decisão prévia, Empty State sem evento disparador
**Nível composicional possível:** Leaf
**Quando usar:**
- quando o sistema precisa confirmar, avisar ou sinalizar algo sem bloquear a tarefa em curso
- quando o feedback está ligado a uma ação concluída ou a um evento contextual
- quando a mensagem deve ficar global ou local sem substituir a estrutura principal
**Quando evitar:**
- quando a falha exige substituição do conteúdo ou recuperação explícita no corpo da página
- quando a interação exige decisão prévia do utilizador
- quando a mensagem precisa permanecer como conteúdo primário da zona
**Alternativas próximas:** UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-CONFIRMATION_DIALOG, mensagem inline de formulário
**Sinais de escolha:**
- a tarefa principal pode continuar
- o feedback é complementar e não estrutural
- a mensagem pode ser efêmera ou contextual
- não há necessidade de bloquear a interface
**Zonas usuais:** Global Overlay, Header contextual, Inline Feedback, Form Feedback
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Não substitui Confirmation Dialog para acções que exigem confirmação prévia
**Estrutura Desktop:** Pode ser notificação flutuante temporária ou alerta inline/contextual. Ícone de tipo, mensagem, fechar e acção secundária opcional quando fizer sentido.
**Estrutura Mobile:** Variante não bloqueante equivalente ao contexto. Pode aparecer como toast compacto, faixa contextual ou alerta inline touch-friendly.
**Regra de Transição:** A semântica do feedback deve ser preservada. Posição, largura e modo de apresentação podem variar conforme contexto global, local e plataforma.
**Estados próprios:** sucesso, aviso, erro, informação, persistente, a desaparecer
**Reação a estados da página:** Independente do estado da página — aparece após acção ou evento.
**Grau de Rigidez:** Médio
**Variantes reconhecidas:**
- Toast flutuante temporário
- Alert inline/contextual persistente

---

## Confirmation Dialog

**ID_UI_PATTERN:** UIP-FEEDBACK-CONFIRMATION_DIALOG
**Categoria:** Feedback & Estado
**Definição curta:** Confirmação modal de ação arriscada, irreversível ou operacionalmente sensível.
**Objetivo estrutural:** Solicitar confirmação explícita antes de acção irreversível ou de alto impacto.
**Não confundir com:** Toast / Alert informativo, Error State de falha, Action Bar de execução direta
**Nível composicional possível:** Leaf
**Quando usar:**
- quando a ação tem impacto irreversível ou risco elevado
- quando a decisão precisa ser explícita antes de executar
- quando o utilizador deve entender claramente o impacto antes de prosseguir
**Quando evitar:**
- quando a ação é reversível ou de baixo risco
- quando o feedback deve acontecer depois da ação e não antes
- quando a confirmação seria fricção desnecessária
**Alternativas próximas:** UIP-FEEDBACK-TOAST_ALERT, inline confirmation leve, dupla ação reversível
**Sinais de escolha:**
- existe risco real ou irreversibilidade
- a interface precisa bloquear até a decisão
- há distinção clara entre confirmar e cancelar
- o impacto precisa ser lido antes da execução
**Zonas usuais:** Global Overlay, Destructive Action Confirmation
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Não usar para acções reversíveis sem risco
**Estrutura Desktop:** Modal centrado com título, descrição do impacto, botão de confirmação (destrutivo quando aplicável) e cancelar. Overlay no fundo.
**Estrutura Mobile:** Sheet ou modal compacto, com clareza equivalente para impacto, confirmação e cancelamento. Botões podem ser empilhados ou distribuídos conforme guideline da plataforma.
**Regra de Transição:** Modal centrado → variante compacta touch-friendly. A inteligibilidade da decisão e a distinção da ação destrutiva devem ser preservadas.
**Estados próprios:** aberto aguardando decisão, a processar após confirmação, fechado
**Reação a estados da página:** Bloqueia interacção com a página. Loading State após confirmação enquanto processa.
**Grau de Rigidez:** Alto

---

# Grupo 6 — Ação

---

## Action Bar

**ID_UI_PATTERN:** UIP-ACTION-ACTION_BAR
**Categoria:** Ação
**Definição curta:** Barra de ações visíveis para operações principais sobre a página, seleção ou entidade em foco.
**Objetivo estrutural:** Expor acções disponíveis sobre item seleccionado, selecção múltipla ou sobre a página.
**Não confundir com:** Contextual Menu por item, Floating Action de destaque único, Navigation Menu
**Nível composicional possível:** Leaf
**Quando usar:**
- quando a página ou seleção exige ações principais visíveis
- quando existe conjunto pequeno e recorrente de operações relevantes
- quando as ações precisam ficar próximas da área de trabalho
**Quando evitar:**
- quando as ações pertencem a um item específico e não ao contexto global
- quando existe apenas uma ação primária dominante
- quando a densidade de ações tornaria a barra ilegível
**Alternativas próximas:** UIP-ACTION-CONTEXTUAL_MENU, UIP-ACTION-FLOATING_ACTION, botões inline
**Sinais de escolha:**
- ações são frequentes e devem ficar explícitas
- o contexto de página ou seleção altera a disponibilidade das ações
- existe ação primária e secundárias relacionadas
- o utilizador não deve abrir menu para toda ação importante
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

---

## Contextual Menu

**ID_UI_PATTERN:** UIP-ACTION-CONTEXTUAL_MENU
**Categoria:** Ação
**Definição curta:** Menu de ações locais associado a um item ou contexto específico, activado sob demanda.
**Objetivo estrutural:** Expor acções disponíveis sobre um item específico sem ocupar espaço permanente.
**Não confundir com:** Action Bar global, Navigation Menu, diálogo de confirmação
**Nível composicional possível:** Leaf
**Quando usar:**
- quando as ações pertencem a um item específico
- quando a interface precisa economizar espaço permanente
- quando ações secundárias ou avançadas não precisam ficar sempre visíveis
**Quando evitar:**
- quando as ações são globais da página ou da seleção
- quando a ação principal precisa ser imediatamente visível
- quando o utilizador precisa confirmar antes mesmo de escolher a ação
**Alternativas próximas:** UIP-ACTION-ACTION_BAR, botões inline, UIP-FEEDBACK-CONFIRMATION_DIALOG
**Sinais de escolha:**
- há ações locais por item
- o espaço visual é restrito
- parte das ações pode ficar oculta até demanda
- a lista de ações precisa ser contextual
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

---

## Floating Action

**ID_UI_PATTERN:** UIP-ACTION-FLOATING_ACTION
**Categoria:** Ação
**Definição curta:** Ação primária destacada e persistente, acessível acima do conteúdo da página.
**Objetivo estrutural:** Destacar a acção primária mais importante da página de forma sempre acessível.
**Não confundir com:** Action Bar com múltiplas ações, botão inline contextual, Navigation control
**Nível composicional possível:** Leaf
**Quando usar:**
- quando existe uma única ação primária dominante
- quando a ação deve permanecer acessível durante rolagem
- quando a página é orientada a criação ou execução recorrente de uma ação
**Quando evitar:**
- quando há muitas ações equivalentes
- quando a página já possui barra de ações suficiente
- quando o overlay flutuante conflita com leitura, navegação ou acessibilidade
**Alternativas próximas:** UIP-ACTION-ACTION_BAR, botão primário em header, ação inline fixa
**Sinais de escolha:**
- há uma ação claramente dominante
- a rolagem não deve esconder a ação principal
- a tarefa principal é recorrente e rápida
- o contexto tolera overlay persistente
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

---

# Grupo 7 — Conteúdo

---

## Detail Block

**ID_UI_PATTERN:** UIP-CONTENT-DETAIL_BLOCK
**Categoria:** Conteúdo
**Definição curta:** Bloco de leitura estruturada de atributos, propriedades e metadados de uma entidade ou contexto específico.
**Objetivo estrutural:** Apresentar atributos e metadados de uma entidade específica de forma estruturada.
**Não confundir com:** Rich Text Block editorial, Metric Card sintético, Form Field Group para captura de dados
**Nível composicional possível:** Container, Leaf
**Quando usar:**
- quando a prioridade é leitura estruturada de atributos e metadados
- quando a entidade precisa ser apresentada em grupos lógicos de informação
- quando a zona deve suportar leitura e eventual edição localizada por secção
**Quando evitar:**
- quando o conteúdo é editorial, narrativo ou documental livre
- quando a prioridade é destacar poucos indicadores sintéticos
- quando a interação principal é captura de dados em vez de leitura
**Alternativas próximas:** UIP-CONTENT-RICH_TEXT_BLOCK, UIP-CONTENT-METRIC_CARD, UIP-INPUT-FORM_FIELD_GROUP
**Sinais de escolha:**
- existem rótulos e valores estruturados
- os atributos podem ser agrupados por secções
- a leitura depende de pares nome/valor ou metadado/valor
- o utilizador precisa consultar detalhes de uma entidade específica
**Zonas usuais:** Detail-Panel, Content-Body, Summary Section
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
**Definição curta:** Card de síntese para exibir um indicador ou KPI de leitura imediata.
**Objetivo estrutural:** Apresentar um indicador, KPI ou métrica de forma destacada e de leitura rápida.
**Não confundir com:** Detail Block de atributos, Rich Text Block editorial, card genérico de catálogo
**Nível composicional possível:** Leaf
**Quando usar:**
- quando a informação principal pode ser resumida em um indicador
- quando a tela precisa de leitura rápida de status ou performance
- quando o valor e sua variação importam mais que a narrativa detalhada
**Quando evitar:**
- quando a zona precisa mostrar múltiplos atributos estruturados
- quando o conteúdo depende de explicação longa ou editorial
- quando a métrica não é prioritária o bastante para destaque
**Alternativas próximas:** UIP-CONTENT-DETAIL_BLOCK, chart summary, card informativo genérico
**Sinais de escolha:**
- existe um valor principal dominante
- comparação rápida importa
- variação, período ou tendência agregam contexto
- a leitura deve ser quase imediata
**Zonas usuais:** KPI-Row, Dashboard Header, Summary Strip
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
**Definição curta:** Bloco de conteúdo livre e editorial, com formatação textual e elementos embutidos.
**Objetivo estrutural:** Apresentar conteúdo editorial ou documental de formato livre com suporte a formatação.
**Não confundir com:** Detail Block estruturado, Form Field Group de captura, Metric Card sintético
**Nível composicional possível:** Leaf
**Quando usar:**
- quando o conteúdo é narrativo, editorial, explicativo ou documental
- quando headings, listas, links e imagens fazem parte natural da leitura
- quando a estrutura principal é textual e não de pares atributo/valor
**Quando evitar:**
- quando a zona depende de leitura estruturada de campos
- quando a tarefa principal é editar ou preencher dados
- quando o valor central é um KPI ou síntese analítica
**Alternativas próximas:** UIP-CONTENT-DETAIL_BLOCK, UIP-CONTENT-METRIC_CARD, viewer documental específico
**Sinais de escolha:**
- a leitura é livre e contínua
- headings e parágrafos são elementos naturais do conteúdo
- o utilizador precisa consumir explicação, política, descrição ou documentação
- a semântica editorial é mais importante que grade de dados
**Zonas usuais:** Content-Body, Article Body, Policy/Help Section
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
**Definição curta:** Área de visualização de mídia ou ficheiro com controles adequados ao tipo de conteúdo exibido.
**Objetivo estrutural:** Apresentar e controlar conteúdo multimédia — imagem, vídeo, documento ou ficheiro.
**Não confundir com:** Rich Text Block editorial, Card Grid de coleção, componente puramente decorativo de mídia
**Nível composicional possível:** Leaf, Container (galeria com múltiplos viewers)
**Quando usar:**
- quando a mídia ou ficheiro é conteúdo principal da zona
- quando o utilizador precisa visualizar, navegar ou controlar o conteúdo exibido
- quando o tipo de mídia exige comportamento específico de visualização
**Quando evitar:**
- quando a mídia é apenas apoio visual secundário de um card ou texto
- quando a zona precisa apenas de miniatura decorativa
- quando o conteúdo é melhor representado como texto estruturado ou editorial
**Alternativas próximas:** UIP-CONTENT-RICH_TEXT_BLOCK, miniatura de Card Grid, viewer documental específico
**Sinais de escolha:**
- o conteúdo principal é imagem, vídeo, documento ou ficheiro
- existem controles ou gestos relevantes de visualização
- o utilizador pode precisar ampliar, reproduzir ou navegar entre mídias
- a mídia ocupa papel funcional na tarefa
**Zonas usuais:** Detail-Panel, Content-Body, Gallery Area
**Compatibilidade Primária:** Detail/Viewer
**Compatibilidade Secundária:** Feed/Timeline, Catalog/Grid
**Incompatibilidades explícitas:** Dashboard, Form
**Estrutura Desktop:** Área de visualização com controles adequados ao tipo de mídia. Pode incluir navegação secundária, thumbnails ou ações auxiliares quando fizer sentido.
**Estrutura Mobile:** Visualização em largura total ou foco único. Gestos e controles simplificados podem assumir o papel principal conforme o tipo de mídia.
**Regra de Transição:** A experiência de visualização deve preservar acesso ao conteúdo e aos controles essenciais. Layout, gestos e posição de navegação auxiliar podem variar conforme mídia e plataforma.
**Estados próprios:** a carregar, disponível, pausado, erro de carregamento, formato não suportado, em fullscreen
**Reação a estados da página:** Loading State → skeleton ou placeholder. Error State → ficheiro indisponível.
**Grau de Rigidez:** Médio
**Variantes reconhecidas:**
- Image Viewer
- Video Viewer
- Document/File Viewer

---

# Regras de Evolução do Catálogo

[INSTRUÇÃO]

Este catálogo é fixo no contexto de cada projecto.

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

Fim do Documento - Catálogo Global de Shell Patterns, Page Patterns e UI Patterns v1.3
