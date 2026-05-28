# SHP-WORKSPACE_ADMIN - Workspace/Admin

## Definição

**Definição curta**: Shell operacional para backoffice, gestão, CRUD e trabalho contínuo em múltiplos módulos.

**Objetivo estrutural**: Sustentar operação recorrente, navegação persistente e alta densidade funcional.

**Interação dominante**: Operacional

**Não confundir com**: SHP-DASHBOARD_ANALYTICS (monitoramento dominante), SHP-PORTAL (conteúdo público), SHP-STUDIO_WORKBENCH (ferramenta de criação).

## Decisão

**Sinais de escolha**:
- múltiplos módulos
- uso interno
- gestão recorrente de entidades
- alternância frequente entre listas, detalhe, formulários e configurações

**Limites**: não é o shell adequado quando a experiência é predominantemente pública, editorial, conversacional ou centrada em canvas.

**Grau de Rigidez**: Alto — navegação persistente, sidebar e área principal são invariantes; módulos e densidade variam por domínio.

## Navegação e Estrutura

**Modelo de navegação global**: sidebar persistente, header operacional e ações globais por módulo.

**Estrutura Desktop**: navegação lateral persistente com área principal de trabalho e utilitários globais.

**Estrutura Mobile**: navegação compacta equivalente com prioridade à tarefa corrente.

**Regra de transição**: reduzir densidade e colapsar navegação sem perder acesso aos módulos principais.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-FORM, PP-WIZARD, PP-DETAIL, PP-SETTINGS, PP-DASHBOARD, PP-BOARD.

**Compatibilidade Secundária**: PP-CATALOG, PP-FEED, PP-CALENDAR, PP-MAP.

**Incompatibilidades explícitas**: PP-LANDING como padrão dominante do shell.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir navegação global em viewport pequeno, fallback para hover ou atalhos e comportamento de tabelas e listas densas.

**Adaptação Mobile nativo**: transformar a navegação lateral persistente em navegação raiz compacta, stack ou tabs conforme escopo; não assumir simultaneidade de lista e detalhe em phone.

**Adaptação Desktop nativo**: pode ativar UIP-INTERACTION-KEYBOARD_FLOW, UIP-ACTION-COMMAND_PALETTE, UIP-SYSTEM-MULTI_WINDOW ou UIP-SYSTEM-TRAY quando houver trabalho contínuo, comandos numerosos ou operação em background.
