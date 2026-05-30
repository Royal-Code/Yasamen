# Patterns Orientations — yasamen-razor

## Preferências gerais

- Preferir patterns com nota ≥ 8 em `patterns.table.md` — cobertura nativa, sem adaptação.
- Para patterns com nota < 6 mas semanticamente necessários, usar sempre o blueprint correspondente.
- Shells não-admin nunca usam `AppLayout` — ver `rules/shell-selection.rules.md`.
- Superfícies visuais especializadas (mapa, gráfico, canvas, calendário) requerem biblioteca JS externa — a lib só cobre controles periféricos e overlay.
- Para qualquer overlay de detalhe, preferir `UIP-OVERLAY-DRAWER` sobre `UIP-OVERLAY-MODAL` quando o conteúdo é contextual sem bloqueio total.

---

## Orientação por tipo de tela

### Admin / Workspace operacional

- Preferir: `SHP-WORKSPACE_ADMIN`
- Combinar com: `UIP-DATA-DATA_TABLE`, `PP-FORM`, `PP-DETAIL`, `PP-LIST-DETAIL`
- Evitar: `SHP-PORTAL`, `SHP-MEDIA_CONTENT` (shells sem sidebar de admin)
- Abrir depois: `samples/app-layout.sample.md`, `samples/app-side-bar.sample.md`, `patterns-blueprints/uip-data-data-table.blueprint.md`
- Motivo: `AppLayout + AppSideBar` cobrem nativamente; painel operacional é o caso canônico da lib.

### CRUD simples (formulário + detalhe + listagem)

- Preferir: `PP-FORM`, `PP-DETAIL`
- Combinar com: `UIP-DATA-LIST_ITEM`, `UIP-CONTENT-CONTENT_HEADER`, `UIP-FEEDBACK-CONFIRMATION_DIALOG`, `UIP-FEEDBACK-TOAST_ALERT`
- Evitar como padrão: `PP-LIST-DETAIL` (split panel — apenas quando detalhe deve permanecer visível lado a lado)
- Abrir depois: `patterns-blueprints/pp-list-detail.blueprint.md`
- Motivo: `PP-FORM` e `PP-DETAIL` têm nota 8 com cobertura total nativa; split panel exige blueprint.

### Listagem tabular (dados operacionais)

- Preferir: `UIP-DATA-DATA_TABLE`
- Combinar com: `UIP-INPUT-SEARCH_BAR`, `UIP-INPUT-FILTER_PANEL`, `UIP-NAV-PAGINATION`, `UIP-ACTION-CONTEXTUAL_MENU`
- Evitar como padrão: `UIP-DATA-CARD_GRID` quando a densidade de dados é alta e a leitura é comparativa
- Abrir depois: `patterns-blueprints/uip-data-data-table.blueprint.md`, `patterns-blueprints/uip-input-filter-panel.blueprint.md`
- Motivo: HTML `<table>` + Tailwind coordenado por blueprint; sem componente nativo de DataTable.

### Dashboard / Analytics

- Preferir: `PP-DASHBOARD` com `SHP-DASHBOARD_ANALYTICS` para shell
- Combinar com: `UIP-CONTENT-METRIC_CARD`, `UIP-INPUT-FILTER_PANEL`, `UIP-OVERLAY-DRAWER`
- Evitar: `UIP-SURFACE-CHART` como padrão direto sem lib externa (GAP crítico)
- Abrir depois: `patterns-blueprints/pp-dashboard.blueprint.md`, `patterns-blueprints/shp-dashboard-analytics.blueprint.md`
- Motivo: KPIs e filtros são cobertos nativamente; gráficos requerem Chart.js, Radzen ou similar.

### Formulário guiado por etapas (Wizard / Onboarding)

- Preferir: `PP-WIZARD`
- Combinar com: `UIP-INPUT-FORM_FIELD_GROUP`, `UIP-FEEDBACK-ERROR_STATE`, `UIP-FEEDBACK-CONFIRMATION_DIALOG`
- Evitar como padrão: `UIP-NAV-STEPPER_INDICATOR` isolado sem o wizard completo
- Abrir depois: `patterns-blueprints/pp-wizard.blueprint.md`
- Motivo: stepper CSS manual com validação por etapa — cobertura nota 6, blueprint orienta toda a coordenação.

### Board / Kanban

- Preferir: `PP-BOARD` ou `UIP-DATA-KANBAN_COLUMN`
- Combinar com: `UIP-OVERLAY-MODAL` para formulário de card, `UIP-ACTION-CONTEXTUAL_MENU` para movimentação
- Evitar como padrão: `UIP-INTERACTION-DRAG_DROP` (requer lib externa; alternativa via DropItem é suficiente para casos simples)
- Abrir depois: `patterns-blueprints/pp-board.blueprint.md`, `patterns-blueprints/uip-data-kanban-column.blueprint.md`
- Motivo: coordenação multi-coluna sem DnD nativo; blueprint cobre o padrão completo.

### Conversa / Mensagens

- Preferir: `PP-CONVERSATION` com `SHP-COMMUNICATION` para shell multi-painel
- Combinar com: `UIP-SYSTEM-NOTIFICATION_CENTER`, `UIP-DATA-LIST_ITEM`
- Evitar como padrão: `UIP-INTERACTION-SWIPE_ACTION` (mobile nativo)
- Abrir depois: `patterns-blueprints/pp-conversation.blueprint.md`, `patterns-blueprints/shp-communication.blueprint.md`
- Motivo: layout split inbox+thread sem AppLayout; tempo real requer SignalR externo.

### Portal público / Institucional

- Preferir: `SHP-PORTAL`
- Combinar com: `UIP-DATA-CARD_GRID`, `UIP-CONTENT-CALLOUT_BLOCK`, `UIP-NAV-PAGINATION`
- Evitar: `SHP-WORKSPACE_ADMIN` (sidebar de admin incompatível com portal público)
- Abrir depois: `patterns-blueprints/shp-portal.blueprint.md`, `rules/shell-selection.rules.md`
- Motivo: shell sem AppLayout; hero e seções de features via HTML livre + Container+Slot.

### Catálogo / Mídia / Streaming

- Preferir: `SHP-MEDIA_CONTENT`
- Combinar com: `UIP-DATA-CARD_GRID`, `UIP-INPUT-SEARCH_BAR`, `UIP-NAV-PAGINATION`, `UIP-CONTENT-RICH_TEXT_BLOCK`
- Evitar como padrão: `SHP-PORTAL` (sem categoria ativa por NavLink)
- Abrir depois: `patterns-blueprints/shp-media-content.blueprint.md`
- Motivo: shell com header leve + categorias + OffCanvas mobile; player via `<video>` HTML nativo.

### Kiosk / Self-service / Embedded

- Preferir: `SHP-KIOSK_EMBEDDED`
- Combinar com: `PP-WIZARD`, `PP-FORM`, `UIP-FEEDBACK-CONFIRMATION_DIALOG`
- Evitar: `SHP-WORKSPACE_ADMIN`, `SHP-PORTAL`
- Abrir depois: `patterns-blueprints/shp-kiosk-embedded.blueprint.md`, `rules/bootstrap.rules.md`
- Motivo: full-screen sem AppLayout; timeout de sessão e botões oversized para toque.

### Editor / Studio / Workbench

- Preferir: `SHP-STUDIO_WORKBENCH`
- Combinar com: `UIP-STRUCT-DOCKED_PANEL_SET`, `UIP-DATA-TREE_VIEW`
- Evitar: `UIP-SURFACE-CANVAS` diretamente sem lib externa (GAP crítico)
- Abrir depois: `patterns-blueprints/shp-studio-workbench.blueprint.md`, `patterns-blueprints/uip-struct-docked-panel-set.blueprint.md`
- Motivo: multi-painel CSS customizado + tema escuro; canvas requer Fabric.js, Konva, tldraw etc.

### Mapa com marcadores / Geolocalização

- Preferir: `PP-MAP` com overlay de controles Yasamen
- Combinar com: `UIP-OVERLAY-DRAWER`, `UIP-OVERLAY-MODAL`
- Evitar como padrão: `UIP-SURFACE-MAP` sem lib externa (GAP crítico — cobertura 0 na superfície)
- Abrir depois: `patterns-blueprints/pp-map.blueprint.md`
- Motivo: lib cobre toolbar sobreposta e painéis; superfície do mapa é Leaflet/Mapbox.

### Calendário / Agenda

- Preferir: `PP-CALENDAR` (vista Agenda list)
- Combinar com: `UIP-NAV-STEPPER_INDICATOR` para navegação de período, `UIP-OVERLAY-MODAL` para formulário de evento
- Evitar como padrão: `UIP-SURFACE-CALENDAR` (lib externa obrigatória para grade semana/mês)
- Abrir depois: `patterns-blueprints/pp-calendar.blueprint.md`
- Motivo: vista "Agenda" (agrupada por dia) tem cobertura plena; grade semana/mês requer lib externa.

---

## Patterns preferenciais

| Intenção | Preferir | Usar quando | Evitar quando |
|---|---|---|---|
| Nav hierárquica | `UIP-NAV-BREADCRUMB` | Sempre que houver 2+ níveis | Página root sem hierarquia |
| Toasts / alertas temporários | `UIP-FEEDBACK-TOAST_ALERT` | Resultado de ação, erro remoto | Alerta persistente → `UIP-CONTENT-CALLOUT_BLOCK` |
| Diálogo destrutivo | `UIP-FEEDBACK-CONFIRMATION_DIALOG` | Excluir, sobrescrever, encerrar sessão | Confirmações triviais sem risco |
| Menu contextual por item | `UIP-ACTION-CONTEXTUAL_MENU` | 3+ ações por linha/card | 1-2 ações → botões diretos |
| Overlay de detalhe contextual | `UIP-OVERLAY-DRAWER` | Detalhe sem bloqueio total da tela | Formulário crítico → `UIP-OVERLAY-MODAL` |
| Paginação | `UIP-NAV-PAGINATION` | Lista server-side com múltiplas páginas | Lista curta client-side → scroll |
| Cabeçalho de seção | `UIP-CONTENT-CONTENT_HEADER` | Toda página com título + ações | Seção interna sem ação → apenas `<h2>` |
| Grade de conteúdo | `UIP-STRUCT-GRID_CONTAINER` | Catálogo, KPIs, features, galeria | Lista linear → `UIP-STRUCT-STACK_CONTAINER` |
| Seleção múltipla em tabela | `UIP-INTERACTION-SELECTION` | Ações em lote sobre itens | Seleção única → radio/highlight de linha |
| Undo/Redo | `UIP-INTERACTION-UNDO_REDO` | Editors, forms com histórico | CRUD simples sem operações reversíveis |

---

## Combinações recomendadas

| Tela | Shell/Page | Estrutura | Dados/Conteúdo | Entrada/Ações | Feedback |
|---|---|---|---|---|---|
| Admin CRUD | `SHP-WORKSPACE_ADMIN` | `UIP-STRUCT-STACK_CONTAINER` | `UIP-DATA-DATA_TABLE` | `PP-FORM`, `UIP-ACTION-CONTEXTUAL_MENU` | `UIP-FEEDBACK-TOAST_ALERT`, `UIP-FEEDBACK-CONFIRMATION_DIALOG` |
| Dashboard | `SHP-DASHBOARD_ANALYTICS` | `UIP-STRUCT-GRID_CONTAINER` | `UIP-CONTENT-METRIC_CARD` | `UIP-INPUT-FILTER_PANEL` | `UIP-FEEDBACK-EMPTY_STATE`, `UIP-FEEDBACK-ERROR_STATE` |
| Listagem com filtros | `SHP-WORKSPACE_ADMIN` | `UIP-STRUCT-STACK_CONTAINER` | `UIP-DATA-DATA_TABLE` | `UIP-INPUT-SEARCH_BAR`, `UIP-INPUT-FILTER_PANEL` | `UIP-FEEDBACK-EMPTY_STATE`, `UIP-FEEDBACK-LOADING_STATE` |
| Formulário guiado | `SHP-WORKSPACE_ADMIN` | `PP-WIZARD` | `UIP-CONTENT-DETAIL_BLOCK` | `UIP-INPUT-FORM_FIELD_GROUP` | `UIP-FEEDBACK-ERROR_STATE`, `UIP-FEEDBACK-CONFIRMATION_DIALOG` |
| Catálogo com busca | `SHP-MEDIA_CONTENT` | `UIP-STRUCT-GRID_CONTAINER` | `UIP-DATA-CARD_GRID` | `UIP-INPUT-SEARCH_BAR`, `UIP-INPUT-FILTER_PANEL` | `UIP-FEEDBACK-EMPTY_STATE` |
| Portal público | `SHP-PORTAL` | `UIP-STRUCT-GRID_CONTAINER` | `UIP-CONTENT-RICH_TEXT_BLOCK` | `PP-FORM` (contato/newsletter) | `UIP-CONTENT-CALLOUT_BLOCK` |
| Comunicação | `SHP-COMMUNICATION` | `PP-CONVERSATION` | `UIP-DATA-LIST_ITEM` | `UIP-INPUT-INPUT_FIELD` | `UIP-FEEDBACK-EMPTY_STATE` |
| Board ágil | `SHP-WORKSPACE_ADMIN` | `PP-BOARD` | `UIP-DATA-KANBAN_COLUMN` | `UIP-ACTION-CONTEXTUAL_MENU` | `UIP-FEEDBACK-LOADING_STATE` |

---

## Uso de blueprints

- `UIP-STRUCT-DOCKED_PANEL_SET`: usar blueprint para workspaces com 3+ painéis coordenados (explorador + editor + inspector + console).
- `UIP-DATA-DATA_TABLE`: usar blueprint para tabela com seleção múltipla, ordenação, skeleton e paginação coordenados.
- `UIP-DATA-TREE_VIEW`: usar blueprint — requer componente Razor recursivo próprio.
- `UIP-DATA-KANBAN_COLUMN`: usar blueprint para coordenação de estado multi-coluna e movimentação via menu.
- `PP-LIST-DETAIL`: usar blueprint para split panel com toggle mobile e coordenação lista↔detalhe.
- `PP-WIZARD`: usar blueprint para stepper CSS manual, validação por etapa e tela de conclusão.
- `PP-DASHBOARD`: usar blueprint para KPI grid + fallback de gráfico e esqueleto de loading.
- `PP-CONVERSATION`: usar blueprint para layout de balões, scroll programático e painel contextual.
- `PP-BOARD`: usar blueprint para scroll horizontal multi-coluna, movimentação e formulário de card.
- `SHP-PORTAL`: usar blueprint para shell público com header responsivo + footer editorial sem AppLayout.
- `SHP-COMMUNICATION`: usar blueprint para split inbox+thread com toggle mobile.
- `SHP-MEDIA_CONTENT`: usar blueprint para shell de catálogo/mídia com NavLink de categorias.
- `SHP-DASHBOARD_ANALYTICS`: usar blueprint para AppLayout com KPIs, filtros globais e drill-down via OffCanvas.
- `SHP-STUDIO_WORKBENCH`: usar blueprint para shell multi-painel dark-theme sem AppLayout.
- `SHP-KIOSK_EMBEDDED`: usar blueprint para shell full-screen com timeout de sessão e CTAs oversized.
- `PP-MAP`: usar blueprint para toolbar sobreposta ao mapa e painel de detalhe.
- `PP-CALENDAR`: usar blueprint para vista Agenda como alternativa à grade de calendário.

---

## Evitar

- `UIP-SURFACE-CHART`: gráficos requerem biblioteca externa — Chart.js, Radzen, ApexCharts etc.; lib yasamen não cobre a superfície.
- `UIP-SURFACE-MAP`: superfície de mapa requer Leaflet, Mapbox, Google Maps etc.
- `UIP-SURFACE-CANVAS`: superfície de canvas requer Fabric.js, Konva.js, tldraw etc.
- `UIP-SURFACE-CALENDAR`: grade de semana/mês requer biblioteca externa; usar `PP-CALENDAR` (Agenda) como alternativa nativa.
- `UIP-SURFACE-DOCUMENT_VIEWER`: exibição de PDF/DOCX requer PDF.js ou visualizador externo.
- `UIP-SURFACE-CAMERA_CAPTURE`: fora da plataforma Web — `getUserMedia` via JS externo.
- `UIP-SURFACE-SCANNER`: visão computacional externa sem participação da lib.
- `UIP-INTERACTION-DRAG_DROP`: HTML5 DnD API sem componente yasamen; para Kanban, alternativa via `UIP-ACTION-CONTEXTUAL_MENU` é suficiente.
- `UIP-INTERACTION-PAN_ZOOM`: manipulação de superfície visual; lib externa obrigatória.
- `UIP-INTERACTION-SWIPE_ACTION`: gesto touch nativo; sem participação da lib.
- `UIP-INTERACTION-PULL_REFRESH`: padrão mobile nativo; alternativa: `Button "Atualizar"`.
- `UIP-INTERACTION-CROSS_WINDOW_DND`: API do browser/SO sem participação da lib.
- `UIP-OVERLAY-FLOATING_PANEL`: drag/resize/dock requerem JS customizado; sem componente yasamen.
- `UIP-OVERLAY-BOTTOM_SHEET`: padrão mobile nativo; `UIP-OVERLAY-DRAWER` com Position=End é a alternativa mais próxima.
- `UIP-SYSTEM-APP_LIFECYCLE`: ciclo de vida nativo de app; Blazor WASM/Server não expõe este padrão.
- `UIP-SYSTEM-MULTI_WINDOW`: gerenciamento de janelas é responsabilidade do browser/SO.
- `UIP-SYSTEM-TRAY`: exclusivo de app desktop nativo; não aplicável a Blazor Web.
- `UIP-SYSTEM-DOCK_INTEGRATION`: exclusivo de app desktop nativo.
- `UIP-NAV-NAV_STACK`: coberto pelo Blazor Router via `NavigationManager`; lib não participa.
