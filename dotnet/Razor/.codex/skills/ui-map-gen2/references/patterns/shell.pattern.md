# Shell Patterns

## Shell Patterns canônicos

### Workspace/Admin

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

### Portal

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

### Communication

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

### Media/Content

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

### Dashboard/Analytics

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

### Studio/Workbench

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

### Transactional/Commerce

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

### Kiosk/Embedded

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