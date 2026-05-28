# Patterns table

## UI-STRUCT — Estruturais

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-STRUCT-LAYOUT_ZONE | Layout Zone | Box, Bar, Container+Slot, AppLayout | Stack, AsideBox | Sim | 8 |
| UIP-STRUCT-STACK_CONTAINER | Stack Container | Stack | Box | Não | 9 |
| UIP-STRUCT-GRID_CONTAINER | Grid Container | Container + Slot | Box | Sim | 9 |
| UIP-STRUCT-SCROLLABLE_REGION | Scrollable Region | — | — | Sim (CSS) | 2 |
| UIP-STRUCT-SPLIT_PANEL | Split Panel | — | Box, Stack | Sim | 3 |
| UIP-STRUCT-COLLAPSIBLE_SECTION | Collapsible Section | — | Bar, Box, Badge, Feedback | Sim | 4 |
| UIP-STRUCT-DOCKED_PANEL_SET | Docked Panel Set | — | AppLayout, AppSideBar, Box, Bar, Stack | Sim | 2 |

## UI-FEEDBACK — Feedback e Estado

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-FEEDBACK-EMPTY_STATE | Empty State | Feedback | Box, Stack | Sim | 5 |
| UIP-FEEDBACK-LOADING_STATE | Loading State | — | RotationMotion, Button (IconAnimation), Pagination (Loading) | Sim | 3 |
| UIP-FEEDBACK-ERROR_STATE | Error State | Feedback | Box, Stack | Sim | 6 |
| UIP-FEEDBACK-TOAST_ALERT | Toast / Alert | Notification, Feedback | — | Não | 9 |
| UIP-FEEDBACK-CONFIRMATION_DIALOG | Confirmation Dialog | Modal | Button | Não | 9 |

## UI-INTERACTION — Interação

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-INTERACTION-SELECTION | Selection | — | — | Não | 0 |
| UIP-INTERACTION-DRAG_DROP | Drag and Drop | — | — | Não | 0 |
| UIP-INTERACTION-PAN_ZOOM | Pan Zoom | — | — | Não | 0 |
| UIP-INTERACTION-UNDO_REDO | Undo Redo | — | — | Não | 0 |
| UIP-INTERACTION-SWIPE_ACTION | Swipe Action | — | — | Não | 0 |
| UIP-INTERACTION-PULL_REFRESH | Pull to Refresh | — | — | Não | 0 |
| UIP-INTERACTION-KEYBOARD_FLOW | Keyboard Flow | — | Button, FieldText (focus ring nativo) | Sim | 3 |
| UIP-INTERACTION-CROSS_WINDOW_DND | Cross Window Drag and Drop | — | — | Não | 0 |

## UI-NAV — Navegação

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-NAV-NAVIGATION_MENU | Navigation Menu | AppMenu, AppSideBar | AppSideItem, DropButton | Não | 8 |
| UIP-NAV-BREADCRUMB | Breadcrumb | Breadcrumb, DescribesBreadcrumbs | BreadcrumbItem, DropButton | Não | 9 |
| UIP-NAV-SECTION_NAV | Section Nav | — | Bar, Button | Sim | 3 |
| UIP-NAV-TABS | Tabs | — | Bar, Button, Box | Sim | 3 |
| UIP-NAV-PAGINATION | Pagination | Pagination | — | Não | 9 |
| UIP-NAV-STEPPER_INDICATOR | Stepper Indicator | — | Bar, Badge | Sim | 3 |
| UIP-NAV-NAV_STACK | Navigation Stack | — | — | Não | 0 |
| UIP-NAV-TAB_BAR | Tab Bar | AppSideBar (ícones) | AppSideItem | Fraca | 5 |

## UI-ACTION — Ação

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-ACTION-ACTION_BAR | Action Bar | Bar | Button, ButtonGroup, IconButton | Não | 9 |
| UIP-ACTION-CONTEXTUAL_MENU | Contextual Menu | DropButton, DropIconButton | DropItem | Não | 9 |
| UIP-ACTION-FLOATING_ACTION | Floating Action | — | Button | Sim (CSS) | 2 |
| UIP-ACTION-COMMAND_PALETTE | Command Palette | — | Modal, FieldText | Sim | 2 |

## UI-SURFACE — Superfícies Especializadas

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-SURFACE-CALENDAR | Calendar Surface | — | — | Não | 0 |
| UIP-SURFACE-MAP | Map Surface | — | — | Não | 0 |
| UIP-SURFACE-CANVAS | Canvas Surface | — | — | Não | 0 |
| UIP-SURFACE-CHART | Chart Surface | — | — | Não | 0 |
| UIP-SURFACE-DOCUMENT_VIEWER | Document Viewer Surface | — | — | Não | 0 |
| UIP-SURFACE-CAMERA_CAPTURE | Camera Capture Surface | — | — | Não | 0 |
| UIP-SURFACE-SCANNER | Scanner Surface | — | — | Não | 0 |

## UI-SYSTEM — Sistema e Host

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-SYSTEM-PERMISSION_FLOW | Permission Flow | — | Modal, Feedback | Sim | 3 |
| UIP-SYSTEM-OFFLINE_SYNC | Offline Sync | — | Notification, Feedback | Sim | 3 |
| UIP-SYSTEM-APP_LIFECYCLE | App Lifecycle | — | — | Não | 0 |
| UIP-SYSTEM-MULTI_WINDOW | Multi Window | — | — | Não | 0 |
| UIP-SYSTEM-TRAY | System Tray | — | — | Não | 0 |
| UIP-SYSTEM-DOCK_INTEGRATION | Dock Integration | — | — | Não | 0 |
| UIP-SYSTEM-AUTH_SESSION | Auth Session | — | Modal, Notification, Feedback | Sim | 3 |
| UIP-SYSTEM-BACKGROUND_PROGRESS | Background Progress | — | Notification, RotationMotion | Sim | 3 |
| UIP-SYSTEM-NOTIFICATION_CENTER | Notification Center | — | Notification | Fraca | 3 |

## UI-INPUT — Entrada

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-INPUT-FORM_FIELD_GROUP | Form Field Group | — | Stack, Box | Não | 6 |
| UIP-INPUT-INPUT_FIELD | Input Field | TextField | FieldText, FieldBadge, FieldAction | Não | 7 |
| UIP-INPUT-CHOICE_GROUP | Choice Group | — | HTML nativo + FieldGroup | Sim | 2 |
| UIP-INPUT-OPTION_PICKER | Option Picker | — | HTML `<select>` + FieldGroup | Sim | 2 |
| UIP-INPUT-LOOKUP_FIELD | Lookup Field | FieldAction | FieldGroup, Button | Fraca | 4 |
| UIP-INPUT-FILE_UPLOAD | File Upload | — | HTML `<input type=file>` | Sim | 2 |
| UIP-INPUT-REPEATING_GROUP | Repeating Group | — | Container, Slot, Button | Sim | 3 |
| UIP-INPUT-VALIDATION_SUMMARY | Validation Summary | Feedback | — | Não | 7 |
| UIP-INPUT-SEARCH_BAR | Search Bar | FieldAction | FieldGroup, Button | Fraca | 5 |
| UIP-INPUT-FILTER_PANEL | Filter Panel | — | Box, Container, Slot, FieldText, Button | Sim | 4 |
| UIP-INPUT-DATE_PICKER | Date Picker | — | HTML `<input type=date>` + FieldGroup | Sim | 2 |
| UIP-INPUT-INLINE_EDITOR | Inline Editor | — | FieldText | Sim | 2 |

## UI-CONTENT — Conteúdo

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-CONTENT-CONTENT_HEADER | Content Header | Bar | Button, Badge, Breadcrumb | Não | 8 |
| UIP-CONTENT-DETAIL_BLOCK | Detail Block | Box | Stack, Bar | Sim | 6 |
| UIP-CONTENT-METRIC_CARD | Metric Card | Box | Stack, Badge, Bar | Sim | 6 |
| UIP-CONTENT-RICH_TEXT_BLOCK | Rich Text Block | Box | — | Sim (HTML) | 5 |
| UIP-CONTENT-CALLOUT_BLOCK | Callout Block | Feedback | — | Não | 8 |
| UIP-CONTENT-MEDIA_VIEWER | Media Viewer | — | Box | Sim (HTML) | 2 |
| UIP-CONTENT-MEDIA_COLLECTION | Media Collection | — | Container, Slot, Box | Sim | 3 |
| UIP-CONTENT-COMPARISON_BLOCK | Comparison Block | — | Container, Slot, Box | Sim | 4 |
| UIP-CONTENT-COMMENT_THREAD | Comment Thread | — | Stack, Box, Bar, Button | Sim | 4 |

## UI-DATA — Dados e Listagem

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-DATA-DATA_TABLE | Data Table | — | Box, HTML `<table>`, Badge, DropIconButton | Sim | 3 |
| UIP-DATA-LIST_ITEM | List Item | — | Bar, Badge, IconButton, DropIconButton | Sim | 5 |
| UIP-DATA-CARD_GRID | Card Grid | Container + Slot | Box, Stack, Badge, Button | Não | 7 |
| UIP-DATA-TREE_VIEW | Tree View | — | Box, Stack, IconButton | Sim | 2 |
| UIP-DATA-TIMELINE_ITEM | Timeline Item | — | Stack, Box, Badge | Sim | 3 |
| UIP-DATA-KANBAN_COLUMN | Kanban Column | — | Box, Stack, Badge | Sim | 3 |

## UI-OVERLAY — Overlays

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| UIP-OVERLAY-MODAL | Modal | Modal | Button, Bar, AsideBox | Não | 9 |
| UIP-OVERLAY-DRAWER | Drawer | OffCanvas | AsideBox, Button, Bar | Não | 9 |
| UIP-OVERLAY-POPOVER | Popover | DropButton, DropIconButton | DropItem | Parcial | 5 |
| UIP-OVERLAY-TOOLTIP | Tooltip | — | HTML `title` attr | Sim | 1 |
| UIP-OVERLAY-BOTTOM_SHEET | Bottom Sheet | — | — | Não | 0 |
| UIP-OVERLAY-FLOATING_PANEL | Floating Panel | — | — | Não | 0 |

## PAGE — Page Patterns

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| PP-LIST-DETAIL | List Detail | — | Bar, Box, Container+Slot, Badge, DropIconButton, Pagination, OffCanvas | Sim | 6 |
| PP-CATALOG | Catalog | — | Container+Slot, Box, TextField, OffCanvas, Button, Pagination, Badge | Sim | 8 |
| PP-FORM | Form | — | EditForm, Stack, Box, TextField, Button, Feedback, Modal | Não | 8 |
| PP-WIZARD | Wizard | — | Container+Slot, TextField, Bar, Button, Feedback, EditForm | Sim | 6 |
| PP-DASHBOARD | Dashboard | — | Container+Slot, Box, Stack, Badge, Bar, Feedback, OffCanvas | Sim | 5 |
| PP-DETAIL | Detail | — | Bar, Box, Stack, Badge, Breadcrumb, Button, Modal | Sim | 8 |
| PP-LANDING | Landing | — | Box, Container+Slot, Bar, Button | Sim | 4 |
| PP-CONVERSATION | Conversation | — | Stack, Box, Bar, Button, TextField | Sim | 5 |
| PP-FEED | Feed | — | Stack, Box, Bar, Badge, Pagination, DropIconButton | Sim | 6 |
| PP-SETTINGS | Settings | — | Box, Stack, TextField, Bar, Button, Feedback | Sim | 7 |
| PP-BOARD | Board | — | Container+Slot, Box, Stack, Badge, DropIconButton | Sim | 5 |
| PP-CALENDAR | Calendar | — | — | Não | 2 |
| PP-MAP | Map | — | — | Não | 1 |
| PP-CANVAS | Canvas | — | — | Não | 1 |
| PP-AUTH | Authentication | — | Box, Stack, TextField, Button, Feedback, Bar | Sim | 8 |

## SHELL — Shell Patterns

| Pattern Id | Pattern Name | Implementam | Compõe | Montagem | Nota |
|---|---|---|---|---|---|
| SHP-WORKSPACE_ADMIN | Workspace/Admin | AppLayout | AppSideBar, AppMenu, OffCanvas, Modal, Notification | Não | 9 |
| SHP-PORTAL | Portal | — | Bar, Box, Container+Slot, OffCanvas | Sim | 4 |
| SHP-COMMUNICATION | Communication | — | AppLayout, Box, Stack, Bar, FieldTextArea | Sim | 4 |
| SHP-MEDIA_CONTENT | Media/Content | — | Bar, Box, Container+Slot, Pagination, OffCanvas | Sim | 6 |
| SHP-DASHBOARD_ANALYTICS | Dashboard/Analytics | AppLayout | AppSideBar, Container+Slot, Box, Bar, Badge, OffCanvas | Sim | 5 |
| SHP-STUDIO_WORKBENCH | Studio/Workbench | — | Bar, IconButton, DropButton, Box, FormGroup | Sim | 2 |
| SHP-TRANSACTIONAL_COMMERCE | Transactional/Commerce | — | Bar, Badge, Container+Slot, Box, OffCanvas, FormGroup, Modal | Sim | 7 |
| SHP-KIOSK_EMBEDDED | Kiosk/Embedded | — | Bar, Box, Container+Slot, Modal, Feedback | Sim | 6 |
| SHP-FOCUSED | Focused | — | Box, Stack, Button, Feedback | Sim | 9 |

## GAP

| Pattern Id | Pattern Name | Tipo | Descrição | Componentes | Justificativa |
|---|---|---|---|---|---|
| UIP-INTERACTION-SELECTION | Selection | sem cobertura viável | Seleção de itens em coleção ou superfície. Nenhuma API de seleção nativa nos componentes. | nenhum | A biblioteca não provê mecanismo de seleção de items; toda lógica de seleção deve ser implementada pelo app com estado C# e HTML nativo. |
| UIP-INTERACTION-DRAG_DROP | Drag and Drop | sem cobertura viável | Manipulação direta por arraste. | nenhum | Nenhum componente ou primitivo da lib endereça DnD; requer HTML5 DnD API ou lib JS externa. |
| UIP-INTERACTION-PAN_ZOOM | Pan Zoom | sem cobertura viável | Navegação espacial por zoom/pan. | nenhum | Fora do escopo da lib; requer superfície especializada ou lib externa. |
| UIP-INTERACTION-UNDO_REDO | Undo Redo | sem cobertura viável | Reversão de ações. | nenhum | Nenhum suporte a histórico de ações; lógica de undo/redo é responsabilidade do app. |
| UIP-INTERACTION-SWIPE_ACTION | Swipe Action | sem cobertura viável | Ações via gesto horizontal. | nenhum | Gestos de swipe não são endereçados pela lib; requer JS nativo ou lib de gestos. |
| UIP-INTERACTION-PULL_REFRESH | Pull to Refresh | sem cobertura viável | Gesto de pull para atualizar. | nenhum | Nenhum componente ou primitivo da lib suporta pull-to-refresh. |
| UIP-INTERACTION-CROSS_WINDOW_DND | Cross Window Drag and Drop | sem cobertura viável | DnD entre janelas. | nenhum | Nenhum suporte; além do escopo web de componentes Blazor. |
| UIP-SURFACE-CALENDAR | Calendar Surface | sem cobertura viável | Superfície temporal de agenda. | nenhum | Nenhum componente de calendário na lib; requer lib externa. |
| UIP-SURFACE-MAP | Map Surface | sem cobertura viável | Superfície de mapa geográfico. | nenhum | Sem suporte; requer lib de mapas externa (Leaflet, Google Maps, etc.). |
| UIP-SURFACE-CANVAS | Canvas Surface | sem cobertura viável | Superfície editável de criação. | nenhum | Nenhum componente de canvas ou editor visual. |
| UIP-SURFACE-CHART | Chart Surface | sem cobertura viável | Visualização gráfica de dados. | nenhum | Sem componente de gráfico; requer lib externa (ChartJs, ApexCharts, etc.). |
| UIP-SURFACE-DOCUMENT_VIEWER | Document Viewer Surface | sem cobertura viável | Visualização de documento paginado. | nenhum | Nenhum viewer de documento na lib. |
| UIP-SURFACE-CAMERA_CAPTURE | Camera Capture Surface | fora da plataforma | Captura por câmera. | nenhum | Superfície primariamente mobile nativo; para Web, requer `getUserMedia` JS API diretamente. |
| UIP-SURFACE-SCANNER | Scanner Surface | fora da plataforma | Leitura de código/imagem. | nenhum | Primariamente mobile nativo; para Web, requer lib de visão computacional externa. |
| UIP-SYSTEM-APP_LIFECYCLE | App Lifecycle | fora da plataforma | Cold start, background, foreground. | nenhum | Ciclo de vida de app nativo; Blazor WASM/Server não expõe este ciclo diretamente. |
| UIP-SYSTEM-MULTI_WINDOW | Multi Window | fora da plataforma | Múltiplas janelas independentes. | nenhum | Gerenciamento de janelas é responsabilidade do browser/OS, não do componente Razor. |
| UIP-SYSTEM-TRAY | System Tray | fora da plataforma | Presença no system tray do SO. | nenhum | Exclusivo de app desktop nativo; não aplicável a Blazor Web. |
| UIP-SYSTEM-DOCK_INTEGRATION | Dock Integration | fora da plataforma | Integração com dock do SO. | nenhum | Exclusivo de app desktop nativo. |
| UIP-NAV-NAV_STACK | Navigation Stack | sem cobertura viável | Navegação hierárquica via push/pop de vistas. | nenhum | Pattern coberto pelo Blazor Router (NavigationManager), não pela biblioteca de componentes; nenhum componente da lib é necessário para este pattern na plataforma Web. |
| UIP-OVERLAY-BOTTOM_SHEET | Bottom Sheet | fora da plataforma | Superfície deslizante da base (mobile). | nenhum | Padrão primariamente mobile nativo; OffCanvas pode ser usado como alternativa parcial para Web. |
| UIP-OVERLAY-FLOATING_PANEL | Floating Panel | sem cobertura viável | Painel flutuante reposicionável. | nenhum | Nenhum componente de painel flutuante/draggable; requer implementação customizada. |
| PP-CALENDAR | Calendar | sem cobertura viável | Página de agenda/calendário. | nenhum | Sem UIP-SURFACE-CALENDAR; página de calendário requer lib externa. |
| PP-MAP | Map | sem cobertura viável | Página de mapa geográfico. | nenhum | Sem UIP-SURFACE-MAP; requer lib de mapas externa. |
| PP-CANVAS | Canvas | sem cobertura viável | Página de criação/canvas. | nenhum | Sem UIP-SURFACE-CANVAS; requer lib especializada. |
