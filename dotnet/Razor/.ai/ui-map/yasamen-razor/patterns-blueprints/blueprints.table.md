# Blueprints table

## Triagem

### UI-STRUCT — Estruturais

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-STRUCT-LAYOUT_ZONE | Layout Zone | `não gerar` | Nota 8 — Box, Bar, Container+Slot e AppLayout cobrem diretamente; blueprint redundante. |
| UIP-STRUCT-STACK_CONTAINER | Stack Container | `não gerar` | Nota 9 — Stack implementa nativamente; sem gap. |
| UIP-STRUCT-GRID_CONTAINER | Grid Container | `não gerar` | Nota 9 — Container+Slot implementa nativamente; sem gap. |
| UIP-STRUCT-SCROLLABLE_REGION | Scrollable Region | `resumido` | Nota 2 — apenas CSS (overflow-y-auto + max-h); orientação de 1-2 linhas basta. |
| UIP-STRUCT-SPLIT_PANEL | Split Panel | `resumido` | Nota 3 — flex CSS 2-painel; composição simples sem componente dedicado. |
| UIP-STRUCT-COLLAPSIBLE_SECTION | Collapsible Section | `resumido` | Nota 4 — Bar + Box + bool state; composição localizada. |
| UIP-STRUCT-DOCKED_PANEL_SET | Docked Panel Set | `completo` | Nota 2 — múltiplos painéis com estado de colapso coordenado; sem abstração dedicada; guia de orquestração necessário. |

### UI-FEEDBACK — Feedback e Estado

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-FEEDBACK-EMPTY_STATE | Empty State | `resumido` | Nota 5 — Feedback Light ou Box+Stack centralizado; composição direta. |
| UIP-FEEDBACK-LOADING_STATE | Loading State | `resumido` | Nota 3 — RotationMotion+Button (inline) + CSS animate-pulse (zona); dois cenários claros mas simples. |
| UIP-FEEDBACK-ERROR_STATE | Error State | `resumido` | Nota 6 — Feedback(Danger) ou Box+Stack; composição idêntica ao Empty State. |
| UIP-FEEDBACK-TOAST_ALERT | Toast / Alert | `não gerar` | Nota 9 — Notification + NotificationService implementam nativamente; sem gap. |
| UIP-FEEDBACK-CONFIRMATION_DIALOG | Confirmation Dialog | `não gerar` | Nota 9 — Modal + Button implementam nativamente; sem gap. |

### UI-INTERACTION — Interação

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-INTERACTION-KEYBOARD_FLOW | Keyboard Flow | `resumido` | Nota 3 — focus ring nativo do browser + tabindex; orientação sobre quais controles focar. |
| UIP-INTERACTION-SELECTION | Selection | `resumido` | Nota 0 — checkbox HTML nativo + HashSet C# + Bar de ações condicionais; padrão repetível útil ao screen-designer. |
| UIP-INTERACTION-DRAG_DROP | Drag and Drop | `não gerar` | Nota 0 — HTML5 DnD API sem participação da lib; ui-map já documenta a abordagem. |
| UIP-INTERACTION-PAN_ZOOM | Pan Zoom | `não gerar` | Nota 0 — lib externa obrigatória; sem componente yasamen-razor envolvido. |
| UIP-INTERACTION-UNDO_REDO | Undo Redo | `resumido` | Nota 0 — Notification com ChildContent de botão "Desfazer" é padrão reutilizável da lib. |
| UIP-INTERACTION-SWIPE_ACTION | Swipe Action | `não gerar` | Nota 0 — gesto touch externo; alternativa DropIconButton já documentada nos samples. |
| UIP-INTERACTION-PULL_REFRESH | Pull to Refresh | `não gerar` | Nota 0 — padrão mobile; alternativa Button "Atualizar" já coberta nos samples. |
| UIP-INTERACTION-CROSS_WINDOW_DND | Cross Window Drag and Drop | `não gerar` | Nota 0 — API nativa do browser/SO sem componente yasamen-razor. |

### UI-NAV — Navegação

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-NAV-NAVIGATION_MENU | Navigation Menu | `não gerar` | Nota 8 — AppMenu + AppSideBar implementam nativamente; sem gap. |
| UIP-NAV-BREADCRUMB | Breadcrumb | `não gerar` | Nota 9 — Breadcrumb + DescribesBreadcrumbs implementam nativamente; sem gap. |
| UIP-NAV-SECTION_NAV | Section Nav | `resumido` | Nota 3 — Bar + Button(Active) + JS scrollIntoView; composição localizada. |
| UIP-NAV-TABS | Tabs | `resumido` | Nota 3 — Bar + ButtonGroup + @if para conteúdo; painel visual via preenchimento de background. |
| UIP-NAV-PAGINATION | Pagination | `não gerar` | Nota 9 — Pagination implementa nativamente; sem gap. |
| UIP-NAV-STEPPER_INDICATOR | Stepper Indicator | `resumido` | Nota 3 — Bar + Badge + linha de progresso CSS; composição sem componente dedicado. |
| UIP-NAV-NAV_STACK | Navigation Stack | `não gerar` | Nota 0 — coberto pelo Blazor Router (NavigationManager); lib não participa. |
| UIP-NAV-TAB_BAR | Tab Bar | `resumido` | Nota 5 — AppSideBar como navigation rail (desktop/web); barra inferior mobile via CSS manual. |

### UI-ACTION — Ação

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-ACTION-ACTION_BAR | Action Bar | `não gerar` | Nota 9 — Bar + Button implementam nativamente; sem gap. |
| UIP-ACTION-CONTEXTUAL_MENU | Contextual Menu | `não gerar` | Nota 9 — DropButton + DropIconButton + DropItem implementam nativamente; sem gap. |
| UIP-ACTION-FLOATING_ACTION | Floating Action | `resumido` | Nota 2 — Button + CSS position:fixed; composição de 2 linhas. |
| UIP-ACTION-COMMAND_PALETTE | Command Palette | `resumido` | Nota 2 — Modal + TextField + lista @foreach + atalho JS; composição localizada. |

### UI-SURFACE — Superfícies Especializadas

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-SURFACE-CALENDAR | Calendar Surface | `não gerar` | Nota 0 — lib externa obrigatória; sem componente yasamen-razor para a superfície. |
| UIP-SURFACE-MAP | Map Surface | `não gerar` | Nota 0 — lib externa obrigatória (Leaflet, Google Maps); sem componente yasamen-razor. |
| UIP-SURFACE-CANVAS | Canvas Surface | `não gerar` | Nota 0 — lib externa obrigatória (Fabric.js, Konva, etc.); sem componente yasamen-razor. |
| UIP-SURFACE-CHART | Chart Surface | `não gerar` | Nota 0 — lib externa obrigatória (Chart.js, Radzen, etc.); sem componente yasamen-razor. |
| UIP-SURFACE-DOCUMENT_VIEWER | Document Viewer Surface | `não gerar` | Nota 0 — lib externa obrigatória (PDF.js, etc.); sem componente yasamen-razor. |
| UIP-SURFACE-CAMERA_CAPTURE | Camera Capture Surface | `não gerar` | Fora da plataforma Web; getUserMedia via JS sem participação da lib. |
| UIP-SURFACE-SCANNER | Scanner Surface | `não gerar` | Fora da plataforma Web; visão computacional externa sem participação da lib. |

### UI-SYSTEM — Sistema e Host

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-SYSTEM-PERMISSION_FLOW | Permission Flow | `resumido` | Nota 3 — Modal + Feedback + Button; composição localizada para fluxo de permissão. |
| UIP-SYSTEM-OFFLINE_SYNC | Offline Sync | `resumido` | Nota 3 — Notification + Feedback + Badge + JS interop; orientação de componentes por estado. |
| UIP-SYSTEM-APP_LIFECYCLE | App Lifecycle | `não gerar` | Fora da plataforma — ciclo de vida nativo; Blazor WASM/Server não expõe este ciclo. |
| UIP-SYSTEM-MULTI_WINDOW | Multi Window | `não gerar` | Fora da plataforma — gerenciamento de janelas é responsabilidade do browser/OS. |
| UIP-SYSTEM-TRAY | System Tray | `não gerar` | Fora da plataforma — exclusivo de app desktop nativo; não aplicável a Blazor Web. |
| UIP-SYSTEM-DOCK_INTEGRATION | Dock Integration | `não gerar` | Fora da plataforma — exclusivo de app desktop nativo. |
| UIP-SYSTEM-AUTH_SESSION | Auth Session | `resumido` | Nota 3 — Modal + Feedback + AuthorizeView Blazor; fluxo de sessão com componentes da lib. |
| UIP-SYSTEM-BACKGROUND_PROGRESS | Background Progress | `resumido` | Nota 3 — Notification + Bar + CSS progress + serviço singleton; composição com padrão de serviço C#. |
| UIP-SYSTEM-NOTIFICATION_CENTER | Notification Center | `resumido` | Nota 3 — OffCanvas + Badge + Stack + Box; composição de centro de notificações. |

### UI-INPUT — Entrada

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-INPUT-FORM_FIELD_GROUP | Form Field Group | `resumido` | Nota 6 — Stack + Box + heading HTML; sem FormGroup dedicado, agrupamento manual. |
| UIP-INPUT-INPUT_FIELD | Input Field | `resumido` | Nota 7 — TextField cobre texto/senha; gaps em date/select/textarea documentados. |
| UIP-INPUT-CHOICE_GROUP | Choice Group | `resumido` | Nota 2 — ButtonGroup para segmented control; checkbox/radio via HTML nativo. |
| UIP-INPUT-OPTION_PICKER | Option Picker | `resumido` | Nota 2 — InputSelect Blazor + label manual Tailwind; sem FieldSelect dedicado. |
| UIP-INPUT-LOOKUP_FIELD | Lookup Field | `resumido` | Nota 4 — FieldAction abre Modal com busca+lista; padrão de lookup via overlay. |
| UIP-INPUT-FILE_UPLOAD | File Upload | `resumido` | Nota 2 — InputFile Blazor + Button como label; composição simples. |
| UIP-INPUT-REPEATING_GROUP | Repeating Group | `resumido` | Nota 3 — Stack + @for + Bar de item + Button adicionar/remover; padrão de lista editável. |
| UIP-INPUT-VALIDATION_SUMMARY | Validation Summary | `resumido` | Nota 7 — Feedback(Danger) + ValidationSummary Blazor; composição direta. |
| UIP-INPUT-SEARCH_BAR | Search Bar | `resumido` | Nota 5 — TextField + FieldAction + Bar + Button; composição de barra de busca. |
| UIP-INPUT-FILTER_PANEL | Filter Panel | `resumido` | Nota 4 — OffCanvas (drawer) ou Box inline com filtros; dois cenários de composição. |
| UIP-INPUT-DATE_PICKER | Date Picker | `resumido` | Nota 2 — input[type=date] nativo ou InputDate Blazor; sem FieldDate dedicado. |
| UIP-INPUT-INLINE_EDITOR | Inline Editor | `resumido` | Nota 2 — TextField + IconButton + bool editando; toggle de edição inline simples. |

### UI-CONTENT — Conteúdo

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-CONTENT-CONTENT_HEADER | Content Header | `não gerar` | Nota 8 — Bar + Button + Badge + Breadcrumb implementam nativamente; sem gap. |
| UIP-CONTENT-DETAIL_BLOCK | Detail Block | `resumido` | Nota 6 — Box + Bar + dl HTML grid + Badge; composição de bloco de detalhes. |
| UIP-CONTENT-METRIC_CARD | Metric Card | `resumido` | Nota 6 — Box + Bar + Badge + Container+Slot; composição de card de KPI. |
| UIP-CONTENT-RICH_TEXT_BLOCK | Rich Text Block | `resumido` | Nota 5 — Box + MarkupString; composição simples com nota sobre Markdig. |
| UIP-CONTENT-CALLOUT_BLOCK | Callout Block | `não gerar` | Nota 8 — Feedback implementa nativamente; sem gap. |
| UIP-CONTENT-MEDIA_VIEWER | Media Viewer | `resumido` | Nota 2 — Box + HTML img/video/audio; composição direta com note de responsividade. |
| UIP-CONTENT-MEDIA_COLLECTION | Media Collection | `resumido` | Nota 3 — Container+Slot + Box + Bar; grade de mídia via grid container. |
| UIP-CONTENT-COMPARISON_BLOCK | Comparison Block | `resumido` | Nota 4 — Container+Slot + Box + separador CSS; composição de comparação lado a lado. |
| UIP-CONTENT-COMMENT_THREAD | Comment Thread | `resumido` | Nota 4 — Stack + Box + InputTextArea + Button + recursão; thread de comentários. |

### UI-DATA — Dados e Listagem

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-DATA-DATA_TABLE | Data Table | `completo` | Nota 3 — HTML table+Tailwind sem abstração; coordenação de sort, seleção, skeleton e paginação exige guia estruturado. |
| UIP-DATA-LIST_ITEM | List Item | `resumido` | Nota 5 — Bar + Box + Badge + DropIconButton; composição direta de item de lista. |
| UIP-DATA-CARD_GRID | Card Grid | `resumido` | Nota 7 — Container+Slot (nota 9) + Box + Badge; solução trivialmente derivável, orientação breve basta. |
| UIP-DATA-TREE_VIEW | Tree View | `completo` | Nota 2 — componente recursivo Razor sem abstração; estrutura de nó, estados de expand e recursão exigem blueprint. |
| UIP-DATA-TIMELINE_ITEM | Timeline Item | `resumido` | Nota 3 — Stack + Box + Bar + Badge + linha vertical CSS; composição de timeline. |
| UIP-DATA-KANBAN_COLUMN | Kanban Column | `completo` | Nota 3 — Box+Stack por coluna + movimentação via DropItem; coordenação multi-coluna e estado de card exigem blueprint. |

### UI-OVERLAY — Overlays

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| UIP-OVERLAY-MODAL | Modal | `não gerar` | Nota 9 — Modal implementa nativamente; sem gap. |
| UIP-OVERLAY-DRAWER | Drawer | `não gerar` | Nota 9 — OffCanvas implementa nativamente; sem gap. |
| UIP-OVERLAY-POPOVER | Popover | `resumido` | Nota 5 — DropButton/DropIconButton para ações; Box+position:absolute para conteúdo arbitrário. |
| UIP-OVERLAY-TOOLTIP | Tooltip | `resumido` | Nota 1 — atributo title HTML ou CSS group hover; orientação de 1 parágrafo basta. |
| UIP-OVERLAY-BOTTOM_SHEET | Bottom Sheet | `não gerar` | Fora da plataforma — padrão mobile nativo; OffCanvas(End) é alternativa parcial já documentada. |
| UIP-OVERLAY-FLOATING_PANEL | Floating Panel | `não gerar` | Nota 0 — drag/resize/dock requerem JS customizado sem componente yasamen-razor; ui-map já documenta a abordagem. |

### PAGE — Padrões de Página

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| PP-LIST-DETAIL | List Detail | `completo` | Nota 6 — split panel CSS + coordenação lista↔detalhe + responsividade mobile/desktop exigem blueprint de orquestração. |
| PP-CATALOG | Catalog | `não gerar` | Nota 8 — Container+Slot + filtros + Pagination cobrem nativamente; sem gap. |
| PP-FORM | Form | `não gerar` | Nota 8 — EditForm + Stack + TextField + Button cobrem nativamente; sem gap. |
| PP-WIZARD | Wizard | `completo` | Nota 6 — stepper CSS manual + EditContext por etapa + validação por passo + coordenação de navegação exigem blueprint. |
| PP-DASHBOARD | Dashboard | `completo` | Nota 5 — KPI grid + GAP de charts documentado + múltiplas zonas coordenadas + skeleton exigem guia estrutural. |
| PP-DETAIL | Detail | `não gerar` | Nota 8 — Bar + Box + Badge + Breadcrumb cobrem nativamente; sem gap. |
| PP-LANDING | Landing | `resumido` | Nota 4 — hero HTML livre + Container+Slot para features + Button CTA; composição com orientação de adaptação. |
| PP-CONVERSATION | Conversation | `completo` | Nota 5 — split lista+thread + balões de mensagem CSS + scroll JS + composição envolve coordenação estrutural. |
| PP-FEED | Feed | `resumido` | Nota 6 — Stack + Box de itens + FAB + estados de loading/empty; composição sem coordenação complexa. |
| PP-SETTINGS | Settings | `resumido` | Nota 7 — sidebar nav CSS + EditForm + Box/Stack por seção; composição direta com nota sobre select/checkbox sem estilo nativo. |
| PP-BOARD | Board | `completo` | Nota 5 — múltiplas colunas scroll-horizontal + movimentação por DropItem + coordenação de estado exigem blueprint. |
| PP-CALENDAR | Calendar | `resumido` | Nota 2 — vista "Agenda" como alternativa (Bar+Box+Badge) é padrão útil sem lib externa; blueprint breve de orientação. |
| PP-MAP | Map | `resumido` | Nota 1 — Bar+OffCanvas+Modal cobrem controles e overlays do mapa; blueprint mostra integração da lib com lib externa de mapa. |
| PP-CANVAS | Canvas | `resumido` | Nota 1 — Bar+IconButton+DropButton(toolbar) + Box+Stack(inspector); blueprint mostra shell yasamen ao redor do canvas externo. |
| PP-AUTH | Authentication | `não gerar` | Nota 8 — Box + EditForm + TextField + Button + Feedback cobrem nativamente; sem gap. |

### SHELL — Padrões de Shell

| Pattern Id | Pattern Name | Classificação inicial | Justificativa |
|---|---|---|---|
| SHP-WORKSPACE_ADMIN | Workspace/Admin | `não gerar` | Nota 9 — AppLayout + AppSideBar + AppMenu implementam nativamente; sem gap. |
| SHP-PORTAL | Portal | `completo` | Nota 4 — shell público com header+nav responsivo+OffCanvas mobile+footer editorial sem AppLayout; estrutura de shell exige blueprint. |
| SHP-COMMUNICATION | Communication | `completo` | Nota 4 — AppLayout + split panel inbox+thread + coordenação de estado de thread exigem guia de orquestração. |
| SHP-MEDIA_CONTENT | Media/Content | `completo` | Nota 6 — shell de catálogo/mídia com header leve+nav de categorias+OffCanvas mobile+discovery grid; estrutura de shell exige blueprint. |
| SHP-DASHBOARD_ANALYTICS | Dashboard/Analytics | `completo` | Nota 5 — AppLayout + KPI grid + GAP de charts + drill-down via OffCanvas + filtros globais; coordenação de zonas exige blueprint. |
| SHP-STUDIO_WORKBENCH | Studio/Workbench | `completo` | Nota 2 — layout multi-painel CSS + toolbar + inspector via FormGroup + canvas GAP; estrutura de workbench sem AppLayout exige blueprint. |
| SHP-TRANSACTIONAL_COMMERCE | Transactional/Commerce | `resumido` | Nota 7 — header+cart badge + OffCanvas(carrinho) + Container+Slot(catálogo) + checkout; composição bem coberta, orientação de shell basta. |
| SHP-KIOSK_EMBEDDED | Kiosk/Embedded | `completo` | Nota 6 — shell full-screen sem AppLayout + timeout de sessão + fluxo guiado + botões oversized para toque; estrutura de kiosk exige blueprint. |
| SHP-FOCUSED | Focused | `não gerar` | Nota 9 — Box + Stack + Button + Feedback cobrem nativamente; sem gap. |

---

## Resultado da geração

### UI-STRUCT — Estruturais

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| UIP-STRUCT-SCROLLABLE_REGION | resumido | gerado | composição apenas | - | min-h-0 obrigatório em filhos flex; scroll programático requer JS |
| UIP-STRUCT-SPLIT_PANEL | resumido | gerado | composição apenas | - | resize requer JS drag; sem nativo |
| UIP-STRUCT-COLLAPSIBLE_SECTION | resumido | gerado | composição apenas | - | animação de abertura requer JS ou transition CSS |
| UIP-STRUCT-DOCKED_PANEL_SET | completo | gerado | composição apenas | - | resize de painéis requer JS; persistência requer localStorage; abas manuais |

### UI-FEEDBACK — Feedback e Estado

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| UIP-FEEDBACK-EMPTY_STATE | resumido | gerado | composição apenas | - | ilustrações/SVG a cargo do app |
| UIP-FEEDBACK-LOADING_STATE | resumido | gerado | composição apenas | - | skeleton por zona é CSS manual animate-pulse |
| UIP-FEEDBACK-ERROR_STATE | resumido | gerado | composição apenas | - | sem retry automático nativo |

### UI-INTERACTION — Interação

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| UIP-INTERACTION-KEYBOARD_FLOW | resumido | gerado | composição apenas | - | focus ring nativo do browser; tabindex manual |
| UIP-INTERACTION-SELECTION | resumido | gerado | composição apenas | - | sem componente de checkbox com estilo nativo da lib |
| UIP-INTERACTION-UNDO_REDO | resumido | gerado | composição apenas | - | histórico de estado é responsabilidade do app |

### UI-NAV — Navegação

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| UIP-NAV-SECTION_NAV | resumido | gerado | composição apenas | - | scroll suave requer JS scrollIntoView; IntersectionObserver para seção ativa |
| UIP-NAV-TABS | resumido | gerado | composição apenas | - | animação de conteúdo requer CSS transition manual |
| UIP-NAV-STEPPER_INDICATOR | resumido | gerado | composição apenas | - | sem componente nativo; CSS manual com flex |
| UIP-NAV-TAB_BAR | resumido | gerado | composição apenas | - | barra inferior mobile é CSS manual; sem nativo |

### UI-ACTION — Ação

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| UIP-ACTION-FLOATING_ACTION | resumido | gerado | composição apenas | - | position:fixed; z-index manual |
| UIP-ACTION-COMMAND_PALETTE | resumido | gerado | composição apenas | - | atalho de teclado requer JS; sem nativo |

### UI-INPUT — Entrada

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| UIP-INPUT-FORM_FIELD_GROUP | resumido | gerado | composição apenas | - | sem FormGroup dedicado; agrupamento por Box+Stack manual |
| UIP-INPUT-INPUT_FIELD | resumido | gerado | composição apenas | - | date/select/textarea sem FieldDate/FieldSelect/FieldTextArea nativos |
| UIP-INPUT-CHOICE_GROUP | resumido | gerado | composição apenas | - | checkbox/radio HTML nativo sem estilo da lib |
| UIP-INPUT-OPTION_PICKER | resumido | gerado | composição apenas | - | InputSelect Blazor com label Tailwind manual; sem FieldSelect |
| UIP-INPUT-LOOKUP_FIELD | resumido | gerado | composição apenas | - | FieldAction + Modal; sem autocomplete nativo |
| UIP-INPUT-FILE_UPLOAD | resumido | gerado | composição apenas | - | InputFile Blazor; sem preview de imagem nativo |
| UIP-INPUT-REPEATING_GROUP | resumido | gerado | composição apenas | - | @for obrigatório (não @foreach) para closures corretas |
| UIP-INPUT-VALIDATION_SUMMARY | resumido | gerado | composição apenas | - | Feedback(Danger) + ValidationSummary Blazor |
| UIP-INPUT-SEARCH_BAR | resumido | gerado | composição apenas | - | debounce requer Timer C# ou JS; sugestões requerem dropdown manual |
| UIP-INPUT-FILTER_PANEL | resumido | gerado | composição apenas | - | OffCanvas (drawer) ou Box inline; sem componente de filtro dedicado |
| UIP-INPUT-DATE_PICKER | resumido | gerado | composição apenas | - | input[type=date] nativo sem customização visual cross-browser |
| UIP-INPUT-INLINE_EDITOR | resumido | gerado | composição apenas | - | toggle bool + TextField; sem componente de edição inline |

### UI-CONTENT — Conteúdo

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| UIP-CONTENT-DETAIL_BLOCK | resumido | gerado | composição apenas | - | dl HTML com grid Tailwind; sem FieldDisplay dedicado |
| UIP-CONTENT-METRIC_CARD | resumido | gerado | composição apenas | - | tendência CSS manual; gráfico sparkline requer lib externa |
| UIP-CONTENT-RICH_TEXT_BLOCK | resumido | gerado | composição apenas | - | MarkupString requer sanitização — risco XSS; Markdig externo |
| UIP-CONTENT-MEDIA_VIEWER | resumido | gerado | composição apenas | - | video/audio HTML nativo sem customização cross-browser |
| UIP-CONTENT-MEDIA_COLLECTION | resumido | gerado | composição apenas | - | carrossel requer CSS snap ou lib externa |
| UIP-CONTENT-COMPARISON_BLOCK | resumido | gerado | composição apenas | - | slider de comparação requer JS drag |
| UIP-CONTENT-COMMENT_THREAD | resumido | gerado | composição apenas | - | recursão Razor para respostas aninhadas; sem paginação lazy nativa |

### UI-DATA — Dados e Listagem

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| UIP-DATA-LIST_ITEM | resumido | gerado | composição apenas | - | sem componente de item dedicado; Bar+Box+DropIconButton |
| UIP-DATA-CARD_GRID | resumido | gerado | composição apenas | - | Container+Slot cobre; sem gap |
| UIP-DATA-TIMELINE_ITEM | resumido | gerado | composição apenas | - | linha vertical CSS manual; sem componente de timeline |
| UIP-DATA-DATA_TABLE | completo | gerado | composição apenas | - | sem DataTable nativo; HTML table+Tailwind; sem virtualização |
| UIP-DATA-TREE_VIEW | completo | gerado | composição apenas | - | componente recursivo Razor próprio; lazy load requer Func<> |
| UIP-DATA-KANBAN_COLUMN | completo | gerado | composição apenas | - | DnD requer HTML5 DnD API ou lib; movimentação via DropItem |

### UI-OVERLAY — Overlays

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| UIP-OVERLAY-POPOVER | resumido | gerado | composição apenas | - | DropButton para ações; position:absolute para conteúdo arbitrário |
| UIP-OVERLAY-TOOLTIP | resumido | gerado | composição apenas | - | title HTML ou CSS group hover; sem posicionamento inteligente |

### UI-SYSTEM — Sistema e Host

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| UIP-SYSTEM-PERMISSION_FLOW | resumido | gerado | composição apenas | - | lógica de permissão é responsabilidade do app |
| UIP-SYSTEM-OFFLINE_SYNC | resumido | gerado | composição apenas | - | Service Worker/IndexedDB externos ao scope da lib |
| UIP-SYSTEM-AUTH_SESSION | resumido | gerado | composição apenas | - | AuthorizeView + Modal de expiração; refresh token a cargo do app |
| UIP-SYSTEM-BACKGROUND_PROGRESS | resumido | gerado | composição apenas | - | progresso real requer IProgress<T> ou serviço singleton C# |
| UIP-SYSTEM-NOTIFICATION_CENTER | resumido | gerado | composição apenas | - | OffCanvas + Badge + Stack; sem centro de notificações nativo |

### PAGE — Padrões de Página

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| PP-LANDING | resumido | gerado | composição apenas | - | hero/testimonials/pricing HTML livre; sem componente de seção nativo |
| PP-FEED | resumido | gerado | composição apenas | - | infinite scroll requer IntersectionObserver JS |
| PP-SETTINGS | resumido | gerado | composição apenas | - | sidebar CSS manual; select/checkbox sem estilo nativo da lib |
| PP-CALENDAR | resumido | gerado | composição apenas | - | vista Agenda como alternativa; grade semana/mês requer lib externa |
| PP-MAP | resumido | gerado | composição apenas | - | superfície de mapa GAP crítico — Leaflet/Google Maps obrigatório |
| PP-CANVAS | resumido | gerado | composição apenas | - | superfície de canvas GAP crítico — Fabric.js/Konva obrigatório |
| PP-LIST-DETAIL | completo | gerado | composição apenas | - | resize requer JS; mobile toggle via hidden/flex CSS |
| PP-WIZARD | completo | gerado | composição apenas | - | stepper CSS manual; sem componente nativo; EditContext por etapa |
| PP-DASHBOARD | completo | gerado | composição apenas | - | gráficos GAP crítico — lib externa obrigatória; fallback CSS bars |
| PP-CONVERSATION | completo | gerado | composição apenas | - | balões CSS manual; scroll programático JS; tempo real requer SignalR |
| PP-BOARD | completo | gerado | composição apenas | - | DnD requer lib externa; movimentação via DropItem; scroll horizontal |

### SHELL — Padrões de Shell

| Pattern Id | Classificação final | Status | Tipo de artefato | Componentes propostos | Limites declarados |
|---|---|---|---|---|---|
| SHP-TRANSACTIONAL_COMMERCE | resumido | gerado | composição apenas | - | CarrinhoService.OnChanged requer IDisposable; checkout externo |
| SHP-PORTAL | completo | gerado | composição apenas | - | sem mega-menu nativo; hero/pricing HTML livre; SEO via HeadContent |
| SHP-COMMUNICATION | completo | gerado | composição apenas | - | SignalR externo; balões CSS manual; sem indicadores de presença |
| SHP-MEDIA_CONTENT | completo | gerado | composição apenas | - | MarkupString requer sanitização XSS; carrossel requer lib externa |
| SHP-DASHBOARD_ANALYTICS | completo | gerado | composição apenas | - | gráficos GAP crítico — lib externa; periodoGlobal via CascadingValue |
| SHP-STUDIO_WORKBENCH | completo | gerado | composição apenas | - | canvas GAP crítico — lib externa; resize JS; mobile não suportado |
| SHP-KIOSK_EMBEDDED | completo | gerado | composição apenas | - | Timer? IDisposable obrigatório; hardware via IJSRuntime externo |
