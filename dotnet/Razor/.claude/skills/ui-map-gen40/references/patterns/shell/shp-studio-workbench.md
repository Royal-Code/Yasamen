# SHP-STUDIO_WORKBENCH - Studio/Workbench

## Definição

**Definição curta**: Shell de ferramenta para criação, edição, composição e manipulação técnica de artefatos.

**Objetivo estrutural**: Sustentar trabalho focado em superfície principal de edição com painéis de apoio, inspeção e ferramentas.

**Interação dominante**: Composicional

**Não confundir com**: SHP-WORKSPACE_ADMIN (operação multi-módulo), SHP-DASHBOARD_ANALYTICS (monitoramento), SHP-MEDIA_CONTENT (consumo de conteúdo).

## Decisão

**Sinais de escolha**:
- canvas ou editor como centro da tarefa
- painéis de propriedades
- ferramentas persistentes
- layers, assets ou inspector
- operações de criação contínua

**Limites**: não é o shell certo para CRUD clássico, consumo editorial ou jornadas públicas simples.

**Grau de Rigidez**: Alto — superfície principal, painéis laterais e toolbar são invariantes; número e tipo de painéis variam por ferramenta.

## Navegação e Estrutura

**Modelo de navegação global**: superfície principal de trabalho com painéis laterais, toolbar, inspector e utilitários contextuais.

**Estrutura Desktop**: superfície central dominante com painéis laterais simultâneos e toolbar persistente.

**Estrutura Mobile**: versão reduzida, focada em revisão, ajustes pontuais ou tarefas secundárias.

**Regra de transição**: preservar o foco na superfície principal, mesmo quando a edição completa precisar ser reduzida ou sequenciada.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CANVAS, PP-BOARD, PP-DETAIL.

**Compatibilidade Secundária**: PP-FORM, PP-SETTINGS.

**Incompatibilidades explícitas**: PP-LANDING, PP-FEED como experiência dominante.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir suporte a teclado, drag/drop, pan/zoom, persistência de painéis e fallback para touch.

**Adaptação Mobile nativo**: reduzir o escopo de edição; modelar stack, sheets e tarefas secundárias em vez de preservar todos os painéis simultâneos.

**Adaptação Desktop nativo**: pode ativar UIP-SYSTEM-MULTI_WINDOW, UIP-OVERLAY-FLOATING_PANEL, UIP-INTERACTION-KEYBOARD_FLOW, UIP-INTERACTION-CROSS_WINDOW_DND e UIP-ACTION-COMMAND_PALETTE.
