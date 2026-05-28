# Patterns — Lista

Scan rápido de candidatos por grupo. Abrir o arquivo detalhado só para candidatos reais. Em SHP e PP, a interação dominante vem após `·`.

## SHELL — Shell Patterns

- **SHP-WORKSPACE_ADMIN**: [Workspace/Admin](shell/shp-workspace-admin.md) — backoffice, gestão, CRUD e trabalho contínuo em múltiplos módulos · Operacional
- **SHP-PORTAL**: [Portal](shell/shp-portal.md) — conteúdo público, institucional e jornadas lineares ou hierárquicas · Informativa
- **SHP-COMMUNICATION**: [Communication](shell/shp-communication.md) — conversa, inbox, threads e comunicação em tempo real · Comunicacional
- **SHP-MEDIA_CONTENT**: [Media/Content](shell/shp-media-content.md) — descoberta, consumo e navegação de conteúdo ou mídia · Exploratória
- **SHP-DASHBOARD_ANALYTICS**: [Dashboard/Analytics](shell/shp-dashboard-analytics.md) — monitoramento e leitura analítica de métricas · Analítica
- **SHP-STUDIO_WORKBENCH**: [Studio/Workbench](shell/shp-studio-workbench.md) — ferramenta de criação, edição e manipulação técnica · Composicional
- **SHP-TRANSACTIONAL_COMMERCE**: [Transactional/Commerce](shell/shp-transactional-commerce.md) — descoberta orientada à conversão, transação e pedidos · Transacional
- **SHP-KIOSK_EMBEDDED**: [Kiosk/Embedded](shell/shp-kiosk-embedded.md) — dispositivo dedicado, full-screen e fluxo restrito · Guiada
- **SHP-FOCUSED**: [Focused](shell/shp-focused.md) — shell mínimo para tela autônoma de tarefa única, sem navegação global · Focal

## PAGE — Page Patterns

- **PP-LIST-DETAIL**: [List Detail](page/pp-list-detail.md) — coleção e detalhe sincronizados, simultâneos ou alternáveis · Operacional
- **PP-CATALOG**: [Catalog](page/pp-catalog.md) — coleção filtrável orientada à descoberta e comparação · Exploratória
- **PP-FORM**: [Form](page/pp-form.md) — captura ou atualização de dados em uma etapa principal · Transacional simples
- **PP-WIZARD**: [Wizard](page/pp-wizard.md) — fluxo guiado em múltiplas etapas com validação por fase · Transacional multi-etapa
- **PP-DASHBOARD**: [Dashboard](page/pp-dashboard.md) — síntese analítica de indicadores, estados e tendências · Analítica
- **PP-DETAIL**: [Detail](page/pp-detail.md) — visualização estruturada de uma entidade ou artefato · Informativa
- **PP-LANDING**: [Landing](page/pp-landing.md) — entrada, campanha ou narrativa institucional linear · Informativa
- **PP-CONVERSATION**: [Conversation](page/pp-conversation.md) — thread conversacional com composição e leitura contínua · Comunicacional
- **PP-FEED**: [Feed](page/pp-feed.md) — stream cronológico contínuo de itens ou publicações · Cronológica
- **PP-SETTINGS**: [Settings](page/pp-settings.md) — configuração e preferências por seções estáveis · Configuracional
- **PP-BOARD**: [Board](page/pp-board.md) — organização visual por colunas, estados ou lanes · Operacional visual
- **PP-CALENDAR**: [Calendar](page/pp-calendar.md) — agenda e distribuição de itens por tempo · Temporal
- **PP-MAP**: [Map](page/pp-map.md) — navegação e operação sobre espaço geográfico · Espacial
- **PP-CANVAS**: [Canvas](page/pp-canvas.md) — superfície de criação, composição ou edição técnica · Composicional
- **PP-AUTH**: [Authentication](page/pp-auth.md) — autenticação e gestão de acesso: login, cadastro, recuperação · Transacional simples

## UI-STRUCT — Estruturais

- **UIP-STRUCT-LAYOUT_ZONE**: [Layout Zone](struct/uip-struct-layout-zone.md) — região funcional que agrupa conteúdo com responsabilidade própria.
- **UIP-STRUCT-SPLIT_PANEL**: [Split Panel](struct/uip-struct-split-panel.md) — dois painéis com responsabilidades simultâneas e complementares.
- **UIP-STRUCT-DOCKED_PANEL_SET**: [Docked Panel Set](struct/uip-struct-docked-panel-set.md) — painéis acoplados ao redor de uma área principal.
- **UIP-STRUCT-SCROLLABLE_REGION**: [Scrollable Region](struct/uip-struct-scrollable-region.md) — região com scroll próprio, independente do scroll da página.
- **UIP-STRUCT-STACK_CONTAINER**: [Stack Container](struct/uip-struct-stack-container.md) — sequência vertical de elementos com espaçamento coerente.
- **UIP-STRUCT-GRID_CONTAINER**: [Grid Container](struct/uip-struct-grid-container.md) — distribuição de elementos por colunas e linhas.
- **UIP-STRUCT-COLLAPSIBLE_SECTION**: [Collapsible Section](struct/uip-struct-collapsible-section.md) — seção expansível ou recolhível para densidade e disclosure.

## UI-NAV — Navegação

- **UIP-NAV-NAVIGATION_MENU**: [Navigation Menu](nav/uip-nav-navigation-menu.md) — navegação principal para destinos globais do sistema ou shell.
- **UIP-NAV-BREADCRUMB**: [Breadcrumb](nav/uip-nav-breadcrumb.md) — trilha hierárquica de localização e retorno a níveis anteriores.
- **UIP-NAV-SECTION_NAV**: [Section Nav](nav/uip-nav-section-nav.md) — navegação local por seções ou âncoras da mesma página.
- **UIP-NAV-TABS**: [Tabs](nav/uip-nav-tabs.md) — alternância local entre vistas irmãs da mesma página ou zona.
- **UIP-NAV-PAGINATION**: [Pagination](nav/uip-nav-pagination.md) — navegação sequencial entre páginas discretas de uma coleção.
- **UIP-NAV-STEPPER_INDICATOR**: [Stepper Indicator](nav/uip-nav-stepper-indicator.md) — indicador de progresso e posição em fluxo sequencial.
- **UIP-NAV-NAV_STACK**: [Navigation Stack](nav/uip-nav-nav-stack.md) — navegação hierárquica por push/pop de vistas com retorno.
- **UIP-NAV-TAB_BAR**: [Tab Bar](nav/uip-nav-tab-bar.md) — barra fixa na base com destinos raiz do app, cada um com stack própria.

## UI-DATA — Dados e Listagem

- **UIP-DATA-DATA_TABLE**: [Data Table](data/uip-data-data-table.md) — tabular com comparação por linha e coluna, ações e seleção.
- **UIP-DATA-LIST_ITEM**: [List Item](data/uip-data-list-item.md) — unidade simples de listagem para leitura linear e ação localizada.
- **UIP-DATA-CARD_GRID**: [Card Grid](data/uip-data-card-grid.md) — grade de itens visuais para exploração e descoberta.
- **UIP-DATA-TREE_VIEW**: [Tree View](data/uip-data-tree-view.md) — representação hierárquica de itens expansíveis.
- **UIP-DATA-TIMELINE_ITEM**: [Timeline Item](data/uip-data-timeline-item.md) — entrada cronológica de evento, atividade ou histórico.
- **UIP-DATA-KANBAN_COLUMN**: [Kanban Column](data/uip-data-kanban-column.md) — coluna de board que agrupa itens por estado ou etapa.

## UI-INPUT — Entrada

- **UIP-INPUT-FORM_FIELD_GROUP**: [Form Field Group](input/uip-input-form-field-group.md) — agrupamento lógico de campos com validação coerente.
- **UIP-INPUT-INPUT_FIELD**: [Input Field](input/uip-input-input-field.md) — campo atômico para captura de um valor único.
- **UIP-INPUT-CHOICE_GROUP**: [Choice Group](input/uip-input-choice-group.md) — escolhas visíveis para seleção única, múltipla ou binária.
- **UIP-INPUT-OPTION_PICKER**: [Option Picker](input/uip-input-option-picker.md) — seleção a partir de opções conhecidas, colapsadas ou pesquisáveis.
- **UIP-INPUT-LOOKUP_FIELD**: [Lookup Field](input/uip-input-lookup-field.md) — busca e seleção de entidade, registro ou referência.
- **UIP-INPUT-FILE_UPLOAD**: [File Upload](input/uip-input-file-upload.md) — entrada de arquivo ou mídia com validação e progresso.
- **UIP-INPUT-REPEATING_GROUP**: [Repeating Group](input/uip-input-repeating-group.md) — grupo repetível de campos para capturar listas de subitens.
- **UIP-INPUT-VALIDATION_SUMMARY**: [Validation Summary](input/uip-input-validation-summary.md) — resumo de erros e pendências de validação.
- **UIP-INPUT-SEARCH_BAR**: [Search Bar](input/uip-input-search-bar.md) — entrada textual de busca para localizar itens numa coleção.
- **UIP-INPUT-FILTER_PANEL**: [Filter Panel](input/uip-input-filter-panel.md) — filtros estruturados para refinar coleções por atributos ou facetas.
- **UIP-INPUT-DATE_PICKER**: [Date Picker](input/uip-input-date-picker.md) — seleção estruturada de data única ou intervalo.
- **UIP-INPUT-INLINE_EDITOR**: [Inline Editor](input/uip-input-inline-editor.md) — edição localizada no próprio ponto de leitura.

## UI-ACTION — Ação

- **UIP-ACTION-ACTION_BAR**: [Action Bar](action/uip-action-action-bar.md) — barra de ações visíveis sobre página, seleção ou entidade.
- **UIP-ACTION-CONTEXTUAL_MENU**: [Contextual Menu](action/uip-action-contextual-menu.md) — menu de ações locais associado a um item, sob demanda.
- **UIP-ACTION-FLOATING_ACTION**: [Floating Action](action/uip-action-floating-action.md) — ação primária destacada e persistente sobre o conteúdo.
- **UIP-ACTION-COMMAND_PALETTE**: [Command Palette](action/uip-action-command-palette.md) — overlay de busca e execução rápida de comandos por teclado.

## UI-FEEDBACK — Feedback e Estado

- **UIP-FEEDBACK-EMPTY_STATE**: [Empty State](feedback/uip-feedback-empty-state.md) — estado de ausência de dados com orientação de próximo passo.
- **UIP-FEEDBACK-LOADING_STATE**: [Loading State](feedback/uip-feedback-loading-state.md) — estado de progresso enquanto conteúdo ou ação carrega.
- **UIP-FEEDBACK-ERROR_STATE**: [Error State](feedback/uip-feedback-error-state.md) — feedback de falha técnica com caminho claro de retorno.
- **UIP-FEEDBACK-TOAST_ALERT**: [Toast / Alert](feedback/uip-feedback-toast-alert.md) — feedback não bloqueante sobre resultado de ação ou evento.
- **UIP-FEEDBACK-CONFIRMATION_DIALOG**: [Confirmation Dialog](feedback/uip-feedback-confirmation-dialog.md) — confirmação modal de ação arriscada ou irreversível.

## UI-CONTENT — Conteúdo

- **UIP-CONTENT-CONTENT_HEADER**: [Content Header](content/uip-content-content-header.md) — cabeçalho semântico de entidade, seção ou conteúdo.
- **UIP-CONTENT-DETAIL_BLOCK**: [Detail Block](content/uip-content-detail-block.md) — leitura estruturada de atributos, propriedades e metadados.
- **UIP-CONTENT-METRIC_CARD**: [Metric Card](content/uip-content-metric-card.md) — card de síntese para indicador ou KPI de leitura imediata.
- **UIP-CONTENT-RICH_TEXT_BLOCK**: [Rich Text Block](content/uip-content-rich-text-block.md) — bloco de conteúdo editorial livre com formatação.
- **UIP-CONTENT-CALLOUT_BLOCK**: [Callout Block](content/uip-content-callout-block.md) — bloco persistente de orientação, aviso ou contexto.
- **UIP-CONTENT-MEDIA_VIEWER**: [Media Viewer](content/uip-content-media-viewer.md) — visualização de mídia ou arquivo com controles adequados.
- **UIP-CONTENT-MEDIA_COLLECTION**: [Media Collection](content/uip-content-media-collection.md) — coleção de mídias ou anexos de uma entidade.
- **UIP-CONTENT-COMPARISON_BLOCK**: [Comparison Block](content/uip-content-comparison-block.md) — comparação entre versões, estados, opções ou valores.
- **UIP-CONTENT-COMMENT_THREAD**: [Comment Thread](content/uip-content-comment-thread.md) — thread de comentários vinculada a uma entidade.

## UI-SURFACE — Superfícies Especializadas

- **UIP-SURFACE-CALENDAR**: [Calendar Surface](surface/uip-surface-calendar.md) — superfície temporal para agenda, slots, eventos e disponibilidade.
- **UIP-SURFACE-MAP**: [Map Surface](surface/uip-surface-map.md) — superfície espacial para viewport, marcadores, camadas e rotas.
- **UIP-SURFACE-CANVAS**: [Canvas Surface](surface/uip-surface-canvas.md) — superfície editável para objetos, layers, pan/zoom e manipulação.
- **UIP-SURFACE-CHART**: [Chart Surface](surface/uip-surface-chart.md) — superfície analítica para visualização gráfica e drill-down.
- **UIP-SURFACE-DOCUMENT_VIEWER**: [Document Viewer Surface](surface/uip-surface-document-viewer.md) — superfície de documento paginado com navegação e anotação.
- **UIP-SURFACE-CAMERA_CAPTURE**: [Camera Capture Surface](surface/uip-surface-camera-capture.md) — captura por câmera com preview, permissão e confirmação.
- **UIP-SURFACE-SCANNER**: [Scanner Surface](surface/uip-surface-scanner.md) — leitura estruturada de código, documento ou imagem.

## UI-OVERLAY — Overlays e Superfícies Temporárias

- **UIP-OVERLAY-MODAL**: [Modal](overlay/uip-overlay-modal.md) — superfície bloqueante para tarefa, decisão ou conteúdo temporário.
- **UIP-OVERLAY-DRAWER**: [Drawer](overlay/uip-overlay-drawer.md) — painel temporário lateral para navegação, filtros ou conteúdo auxiliar.
- **UIP-OVERLAY-POPOVER**: [Popover](overlay/uip-overlay-popover.md) — superfície contextual leve ancorada a um elemento de origem.
- **UIP-OVERLAY-TOOLTIP**: [Tooltip](overlay/uip-overlay-tooltip.md) — ajuda contextual curta acionada por foco ou hover.
- **UIP-OVERLAY-BOTTOM_SHEET**: [Bottom Sheet](overlay/uip-overlay-bottom-sheet.md) — superfície deslizante a partir da base, com alturas progressivas.
- **UIP-OVERLAY-FLOATING_PANEL**: [Floating Panel](overlay/uip-overlay-floating-panel.md) — painel destacável e reposicionável para ferramentas ou inspectors.

## UI-INTERACTION — Interação e Manipulação

- **UIP-INTERACTION-SELECTION**: [Selection](interaction/uip-interaction-selection.md) — seleção simples, múltipla ou por intervalo em coleções ou superfícies.
- **UIP-INTERACTION-DRAG_DROP**: [Drag and Drop](interaction/uip-interaction-drag-drop.md) — manipulação direta por arraste dentro da mesma tela.
- **UIP-INTERACTION-PAN_ZOOM**: [Pan Zoom](interaction/uip-interaction-pan-zoom.md) — navegação espacial por arrasto, zoom e foco em superfície grande.
- **UIP-INTERACTION-UNDO_REDO**: [Undo Redo](interaction/uip-interaction-undo-redo.md) — reversão e reaplicação de ações em fluxos editáveis.
- **UIP-INTERACTION-SWIPE_ACTION**: [Swipe Action](interaction/uip-interaction-swipe-action.md) — ações reveladas por gesto horizontal sobre itens de lista.
- **UIP-INTERACTION-PULL_REFRESH**: [Pull to Refresh](interaction/uip-interaction-pull-refresh.md) — gesto de puxar no topo de uma lista para atualizar.
- **UIP-INTERACTION-KEYBOARD_FLOW**: [Keyboard Flow](interaction/uip-interaction-keyboard-flow.md) — navegação e operação completa via teclado.
- **UIP-INTERACTION-CROSS_WINDOW_DND**: [Cross Window Drag and Drop](interaction/uip-interaction-cross-window-dnd.md) — arrastar e soltar entre janelas, apps ou arquivos.

## UI-SYSTEM — Sistema e Host

- **UIP-SYSTEM-PERMISSION_FLOW**: [Permission Flow](system/uip-system-permission-flow.md) — pedido de permissão do SO com pré-contexto e tratamento de recusa.
- **UIP-SYSTEM-OFFLINE_SYNC**: [Offline Sync](system/uip-system-offline-sync.md) — indicação de conectividade, sincronização pendente e conflitos.
- **UIP-SYSTEM-APP_LIFECYCLE**: [App Lifecycle](system/uip-system-app-lifecycle.md) — gestão de cold start, background, foreground e preservação de contexto.
- **UIP-SYSTEM-MULTI_WINDOW**: [Multi Window](system/uip-system-multi-window.md) — gestão de múltiplas janelas independentes.
- **UIP-SYSTEM-TRAY**: [System Tray](system/uip-system-tray.md) — presença persistente no system tray ou menu bar do SO.
- **UIP-SYSTEM-DOCK_INTEGRATION**: [Dock Integration](system/uip-system-dock-integration.md) — integração com dock ou taskbar para progresso e badges.
- **UIP-SYSTEM-AUTH_SESSION**: [Auth Session](system/uip-system-auth-session.md) — sessão expirada, lock, reautenticação e retorno seguro.
- **UIP-SYSTEM-BACKGROUND_PROGRESS**: [Background Progress](system/uip-system-background-progress.md) — comunicação de operação longa em background.
- **UIP-SYSTEM-NOTIFICATION_CENTER**: [Notification Center](system/uip-system-notification-center.md) — agregação e ação sobre notificações do sistema ou produto.
