# UIP-OVERLAY-DRAWER - Drawer

## Definição

**Categoria**: Overlay & Superfície Temporária

**Definição curta**: Painel temporário lateral ou contextual para navegação, filtros, detalhe ou conteúdo auxiliar.

**Objetivo estrutural**: Expor uma região auxiliar sem abandonar a página, preservando o contexto principal enquanto o usuário consulta ou ajusta uma parte específica da tarefa.

**Não confundir com**: UIP-NAV-NAVIGATION_MENU (navegação permanente), UIP-STRUCT-SPLIT_PANEL (painéis simultâneos), UIP-OVERLAY-BOTTOM_SHEET (superfície deslizante na base), UIP-OVERLAY-MODAL (superfície bloqueante).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando conteúdo auxiliar precisa entrar temporariamente pela lateral; quando filtros, navegação secundária, detalhe ou edição curta dependem do contexto da página; quando a região não deve ocupar espaço permanente.

**Quando evitar**: quando o conteúdo precisa estar sempre visível; quando a tarefa exige foco bloqueante; quando a tela pequena favorece bottom sheet ou página própria; quando o drawer viraria navegação global confusa.

**Alternativas próximas**: UIP-STRUCT-SPLIT_PANEL (painéis simultâneos), UIP-OVERLAY-BOTTOM_SHEET (superfície deslizante), UIP-OVERLAY-MODAL (superfície bloqueante), UIP-NAV-NAVIGATION_MENU (navegação permanente).

**Sinais de escolha**:
- painel temporário com abrir e fechar como parte do fluxo
- o contexto principal continua relevante
- conteúdo auxiliar com largura ou hierarquia própria
- navegação, filtros ou detalhe não precisam estar sempre visíveis

**Grau de Rigidez**: Médio — painel temporário lateral é estável; lado, tamanho, persistência e conteúdo variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: drawer lateral; drawer de filtros; drawer de detalhe; drawer de navegação; drawer persistente; drawer modal.

**UI Patterns tipicamente contidos**: UIP-INPUT-FILTER_PANEL, UIP-NAV-NAVIGATION_MENU, UIP-CONTENT-DETAIL_BLOCK, UIP-ACTION-ACTION_BAR.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CATALOG, PP-LIST-DETAIL, PP-DETAIL, PP-DASHBOARD.

**Compatibilidade Secundária**: PP-SETTINGS, PP-BOARD, PP-MAP, PP-CALENDAR, PP-FORM.

**Incompatibilidades explícitas**: PP-LANDING, PP-CONVERSATION quando o drawer não contribui para a tarefa principal.

## Estrutura e Transição

**Estrutura Desktop**: painel lateral temporário ou persistente com cabeçalho, conteúdo, ações e fechamento explícito. Pode coexistir com o conteúdo principal visível.

**Estrutura Mobile**: o drawer pode virar bottom sheet, fullscreen panel ou navegação por stack quando a largura lateral não for suficiente.

**Regra de Transição**: preservar a relação com o contexto originador, o fechamento claro e o estado interno. A posição lateral pode virar sheet ou tela progressiva em touch pequeno.

## Estados

**Estados próprios**: fechado, abrindo, aberto, persistente, modal, carregando, com alterações pendentes, fechando, erro interno.

**Reação a estados da página**: `loading` → conteúdo do drawer em skeleton ou progresso local. `error` → erro dentro do drawer quando a falha pertence ao conteúdo auxiliar.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir modal ou persistent drawer, foco, scroll interno, largura e comportamento responsivo.

**Adaptação Mobile nativo**: preferir stack, fullscreen panel ou bottom sheet quando a lateralidade reduzir legibilidade ou controle.

**Adaptação Desktop nativo**: pode coexistir com split panel e floating panel; distinguir temporário de painel persistente.
