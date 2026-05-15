# Components Table

## Tabela consolidada

| Componente | Variações | Patterns cobertos | Props críticas | Eventos | Complexidade |
|---|---|---|---|---|---:|
| `Button` | tema, tamanho, outline, submit, block, navegação | UIP-ACTION-ACTION_BAR, PP-FORM, UIP-FEEDBACK-CONFIRMATION_DIALOG | `Label`, `Style`, `Size`, `Type`, `Outline`, `Block`, `NavigateTo` | `OnClick` | 5 |
| `IconButton` | ícone enum/fragment, tema, outline, active | UIP-ACTION-ACTION_BAR, UIP-ACTION-FLOATING_ACTION, SHP-WORKSPACE_ADMIN | `Icon`, `IconFragment`, `Style`, `Size`, `Active`, `NavigateTo` | `OnClick` | 5 |
| `ButtonGroup` | horizontal, vertical, defaults herdados | UIP-ACTION-ACTION_BAR, UIP-NAV-TABS, PP-FORM | `Orientation`, `Style`, `Size`, `Disabled`, `AriaLabel` | eventos dos filhos | 4 |
| `DropButton` | direção, alinhamento, min-width, conteúdo custom | UIP-ACTION-CONTEXTUAL_MENU, UIP-NAV-BREADCRUMB, PP-CATALOG | `Label`, `ButtonContent`, `Direction`, `Align`, `MinWidth`, `CloseBehavior` | `OnOpened`, `OnClosed`, eventos dos itens | 7 |
| `DropIconButton` | direção, alinhamento, min-width, icon-only | UIP-ACTION-CONTEXTUAL_MENU, PP-FEED, UIP-DATA-DATA_TABLE | `Icon`, `IconFragment`, `Direction`, `Align`, `MinWidth` | `OnOpened`, `OnClosed`, eventos dos itens | 7 |
| `DropItem` | item clicável ou estrutural | UIP-ACTION-CONTEXTUAL_MENU, UIP-NAV-BREADCRUMB | `ChildContent`, `OnClick`, `AdditionalClasses` | `OnClick` | 3 |
| `Badge` | tema, tamanho, ícone, texto/conteúdo | UIP-DATA-LIST_ITEM, UIP-CONTENT-METRIC_CARD, UIP-FEEDBACK-EMPTY_STATE | `Text`, `ChildContent`, `Style`, `Size`, `Icon` | nenhum | 3 |
| `Feedback` | tema, tamanho, título, closeable, block | UIP-FEEDBACK-TOAST_ALERT, UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-EMPTY_STATE | `Style`, `Title`, `Text`, `Icon`, `Closeable`, `Block` | `OnClose` | 5 |
| `Notification` | tema, ícone, timer, close, conteúdo | UIP-FEEDBACK-TOAST_ALERT, SHP-WORKSPACE_ADMIN | `Text`, `Theme`, `Icon`, `Timer`, `Closeable`, `CloseOnClick` | `OnOpen`, `OnClose` | 6 |
| `NotificationContent` | texto e detalhe | UIP-FEEDBACK-TOAST_ALERT | `Text`, `Details` | nenhum | 2 |
| `Notify` | disparo por tema, placement via callback | UIP-FEEDBACK-TOAST_ALERT, SHP-WORKSPACE_ADMIN | tema, texto, detalhes, callback de item | callbacks no item | 4 |
| `NotificationGroup` | placement, lista dinâmica | UIP-FEEDBACK-TOAST_ALERT | `Placement`, `ChildContent`, `AdditionalClasses` | eventos nos filhos | 4 |
| `NotificationAnimation` | open/close via ref | UIP-FEEDBACK-TOAST_ALERT, UIP-FEEDBACK-LOADING_STATE | `ChildContent` | `OpenAsync`, `CloseAsync` via ref | 5 |
| `Breadcrumb` | itens, menu overflow | UIP-NAV-BREADCRUMB, PP-DETAIL | `Items`, `MenuItems`, `AdditionalClasses` | eventos dos filhos | 5 |
| `BreadcrumbItem` | href, callback, active, match | UIP-NAV-BREADCRUMB | `Href`, `Active`, `Match`, `OnClick` | `OnClick` | 3 |
| `DescribesBreadcrumbs` | max visible, model list, callback | UIP-NAV-BREADCRUMB, PP-DETAIL | `Items`, `MaxVisibleItems`, `OnClick` | `OnClick` | 5 |
| `Pagination` | loading, size, single page, window | UIP-NAV-PAGINATION, PP-CATALOG, PP-LIST-DETAIL | `CurrentPage`, `TotalPages`, `Loading`, `Size`, `SinglePageMode` | `OnPageChanged` | 6 |
| `TextField` | text/password, bind event, slots, erro | UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-SEARCH_BAR, PP-FORM | `Label`, `Value`, `Type`, `Information`, `Error`, slots | `ValueChanged`, `OnChange` | 7 |
| `FieldText` | prepend/append textual | UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-SEARCH_BAR | `ChildContent`, `AdditionalClasses` | nenhum | 2 |
| `FieldBadge` | tema, texto/conteúdo | UIP-INPUT-FORM_FIELD_GROUP | `Text`, `ChildContent`, `Style` | nenhum | 3 |
| `FieldAction` | ação no footer, tema, outline | UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-SEARCH_BAR | `Label`, `Style`, `Icon`, `Outline`, `Disabled` | `OnClick` | 4 |
| `FieldGroup` | label, info, erro, slots, control | UIP-INPUT-FORM_FIELD_GROUP | `Label`, `Information`, `ErrorMessage`, `Control`, slots | eventos do controle | 6 |
| `ControlGroup` | linha interna de controle | UIP-INPUT-FORM_FIELD_GROUP | `ChildContent` | nenhum | 2 |
| `FieldError` | mensagem de erro | UIP-INPUT-FORM_FIELD_GROUP, UIP-FEEDBACK-ERROR_STATE | `ErrorMessage` | nenhum | 2 |
| `InputFieldBase` | tipo, maxlength, bind event, slots herdados | UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-SEARCH_BAR, PP-FORM | `Type`, `MaxLength`, `BindEvent`, props de `FieldBase` | `ValueChanged`, `OnChange` | 7 |
| `Box` | borda, padding, margin, classes | UIP-STRUCT-LAYOUT_ZONE, UIP-CONTENT-DETAIL_BLOCK, UIP-DATA-LIST_ITEM | `Border`, `Padding`, `Margin`, `AdditionalClasses` | nenhum | 3 |
| `Bar` | start, middle, end | UIP-ACTION-ACTION_BAR, UIP-STRUCT-LAYOUT_ZONE | `Start`, `Middle`, `End`, `AdditionalClasses` | eventos dos filhos | 3 |
| `Container` | grid/flex, size, height | UIP-STRUCT-GRID_CONTAINER, PP-FORM, PP-DASHBOARD | `Type`, `Size`, `Height`, `AdditionalClasses` | nenhum | 5 |
| `Slot` | spans por breakpoint, height | UIP-STRUCT-GRID_CONTAINER, PP-LIST-DETAIL | `Span`, `TabletSpan`, `LaptopSpan`, `DesktopSpan`, `Height` | nenhum | 5 |
| `Stack` | child content, classes | UIP-STRUCT-STACK_CONTAINER, PP-SETTINGS | `ChildContent`, `AdditionalClasses` | eventos dos filhos | 2 |
| `AppLayout` | top, footer, side menus, main, classes | SHP-WORKSPACE_ADMIN, UIP-NAV-NAVIGATION_MENU, PP-DASHBOARD | slots de shell, sizes, classes adicionais | eventos dos filhos | 8 |
| `AppTopBar` | start, center, end, size | SHP-WORKSPACE_ADMIN, UIP-ACTION-ACTION_BAR | `Size`, `StartContent`, `CenterContent`, `EndContent` | eventos dos filhos | 4 |
| `AppSideBar` | start/end, size | SHP-WORKSPACE_ADMIN, UIP-NAV-NAVIGATION_MENU | `Size`, `Position`, `ChildContent` | eventos dos filhos | 4 |
| `AppSideItem` | active, content | UIP-NAV-NAVIGATION_MENU, SHP-WORKSPACE_ADMIN | `Active`, `ChildContent`, `AdditionalClasses` | eventos dos filhos | 2 |
| `AppSideMenuButton` | toggle interno | SHP-WORKSPACE_ADMIN, UIP-NAV-NAVIGATION_MENU | nenhuma pública evidenciada | nenhum público evidenciado | 5 |
| `AppMenu` | handler, offcanvas, breadcrumbs, lista | UIP-NAV-NAVIGATION_MENU, SHP-WORKSPACE_ADMIN, UIP-INPUT-SEARCH_BAR | `Handler`, `AdditionalClasses` | handler externo | 8 |
| `AppMenuList` | current item, estados internos | UIP-NAV-NAVIGATION_MENU, UIP-DATA-LIST_ITEM | `CurrentMenuItem` | internos | 5 |
| `AppMenuItem` | link, módulo, divider, favorito | UIP-NAV-NAVIGATION_MENU, UIP-DATA-LIST_ITEM | `Item`, `AppMenuContext` | internos | 5 |
| `AppMainLayout` | layout pronto com body | SHP-WORKSPACE_ADMIN, UIP-NAV-NAVIGATION_MENU | `Body` herdado | nenhum direto | 6 |
| `Modal` | id, handler, closeable, center | UIP-FEEDBACK-CONFIRMATION_DIALOG, PP-FORM, SHP-WORKSPACE_ADMIN | `Id`, `Handler`, `Closeable`, `Center`, `OnOpenClose` | `OnOpenClose` | 7 |
| `ModalOutlet` | outlet global | SHP-WORKSPACE_ADMIN, UIP-FEEDBACK-CONFIRMATION_DIALOG | service-driven | internos | 6 |
| `ModalBackdrop` | fases de transição | UIP-FEEDBACK-CONFIRMATION_DIALOG, SHP-WORKSPACE_ADMIN | fases internas | internos | 5 |
| `OffCanvas` | position, fitting, modal, box, handler | UIP-INPUT-FILTER_PANEL, UIP-NAV-NAVIGATION_MENU, SHP-WORKSPACE_ADMIN | `Position`, `Fitting`, `Modal`, `Handler`, `UseBox`, `Title` | `OnVisibilityChanged` | 7 |
| `AsideBox` | title, closeable, size | UIP-INPUT-FILTER_PANEL, UIP-STRUCT-LAYOUT_ZONE | `Title`, `Closeable`, `Size`, `ChildContent` | close por contexto | 4 |
| `CloseOffCanvasButton` | handler cascated | UIP-INPUT-FILTER_PANEL, UIP-NAV-NAVIGATION_MENU | handler cascated | clique interno | 3 |
| `OffCanvasOutlet` | outlet layout-aware | SHP-WORKSPACE_ADMIN, UIP-NAV-NAVIGATION_MENU, UIP-INPUT-FILTER_PANEL | contexto de layout | internos | 6 |
| `Icon` | enum, fragment, classes | UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-EMPTY_STATE, UIP-CONTENT-MEDIA_VIEWER | `Kind`, `Fragment`, `AdditionalClasses` | nenhum | 4 |
| `RotateEffect` | graus, conteúdo | UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-LOADING_STATE | `Degrees`, `ChildContent` | nenhum | 3 |
| `RotationMotion` | direção, conteúdo | UIP-FEEDBACK-LOADING_STATE | `CounterClockwise`, `ChildContent` | nenhum | 3 |
| `Ripple` | dark | UIP-ACTION-ACTION_BAR | `Dark` | nenhum público | 3 |
| `YasamenStyles` | debug/release CSS | SHP-WORKSPACE_ADMIN | comportamento interno | nenhum | 3 |
| `DropBase` | action, content, direction, align | UIP-ACTION-CONTEXTUAL_MENU | `Action`, `DropContent`, `Direction`, `Align`, `CloseBehavior` | `OnOpened`, `OnClosed` | 7 |
| `NotificationOutlet` | outlet de serviço | UIP-FEEDBACK-TOAST_ALERT, SHP-WORKSPACE_ADMIN | service-driven | internos | 6 |
| `NotificationSection` | item para notification | UIP-FEEDBACK-TOAST_ALERT | `Item` | internos | 5 |

## Justificativas por componente

### Button
- Exemplos: 2 (patterns: 2, variações: 5, propriedades: 7, eventos: 1).
- Justificativa: complexidade média; cobre ação visível e submit, que são os usos mais críticos.
- Atendido: CTA, ação secundária e submit.

### IconButton
- Exemplos: 2 (patterns: 2, variações: 4, propriedades: 6, eventos: 1).
- Justificativa: complexidade média; cobre toolbar e ação flutuante.
- Atendido: ação compacta, estado visual e posicionamento composto.

### ButtonGroup
- Exemplos: 2 (patterns: 2, variações: 3, propriedades: 5, eventos: filhos).
- Justificativa: complexidade média; cobre grupo de ações e tabs simuladas.
- Atendido: agrupamento visual e alternância local.

### DropButton
- Exemplos: 3 (patterns: 3, variações: 4, propriedades: 6, eventos: 3).
- Justificativa: alta complexidade por slots, direção, alinhamento e eventos.
- Atendido: menu contextual, overflow de breadcrumb e trigger custom.

### DropIconButton
- Exemplos: 3 (patterns: 3, variações: 4, propriedades: 5, eventos: 3).
- Justificativa: alta complexidade por uso em lista, tabela e feed.
- Atendido: overflow compacto e ações por item.

### DropItem
- Exemplos: 1 (patterns: 1, variações: 2, propriedades: 3, eventos: 1).
- Justificativa: baixa complexidade; o uso principal é item de drop.
- Atendido: ação contextual.

### Badge
- Exemplos: 1 (patterns: 1, variações: 3, propriedades: 5, eventos: 0).
- Justificativa: baixa complexidade; status inline é o caso principal.
- Atendido: status leve.

### Feedback
- Exemplos: 2 (patterns: 2, variações: 5, propriedades: 6, eventos: 1).
- Justificativa: complexidade média; cobre erro estrutural e alerta inline.
- Atendido: mensagem persistente, closeable e recuperação.

### Notification
- Exemplos: 2 (patterns: 1, variações: 4, propriedades: 6, eventos: 2).
- Justificativa: complexidade média; cobre toast simples e conteúdo estruturado.
- Atendido: notificação temporária e detalhada.

### NotificationContent
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: 2, eventos: 0).
- Justificativa: baixa complexidade; serve apenas como conteúdo.
- Atendido: texto e detalhes de toast.

### Notify
- Exemplos: 2 (patterns: 1, variações: 2, propriedades: 4, eventos: callbacks).
- Justificativa: complexidade média por ser serviço e configurar item.
- Atendido: toast global e placement.

### NotificationGroup
- Exemplos: 2 (patterns: 1, variações: 2, propriedades: 3, eventos: filhos).
- Justificativa: complexidade média; cobre placement e lista dinâmica.
- Atendido: agrupamento de toasts.

### NotificationAnimation
- Exemplos: 2 (patterns: 1, variações: 2, propriedades: 1, eventos: 2 métodos).
- Justificativa: complexidade média; uso depende de `@ref`.
- Atendido: abrir/fechar animado.

### Breadcrumb
- Exemplos: 2 (patterns: 1, variações: 2, propriedades: 3, eventos: filhos).
- Justificativa: complexidade média; cobre trilha e overflow.
- Atendido: navegação hierárquica.

### BreadcrumbItem
- Exemplos: 1 (patterns: 1, variações: 2, propriedades: 4, eventos: 1).
- Justificativa: baixa complexidade; item individual.
- Atendido: link e item ativo.

### DescribesBreadcrumbs
- Exemplos: 2 (patterns: 1, variações: 2, propriedades: 3, eventos: 1).
- Justificativa: complexidade média por modelo e callback.
- Atendido: geração por descrição e truncamento.

### Pagination
- Exemplos: 2 (patterns: 1, variações: 3, propriedades: 5, eventos: 1).
- Justificativa: complexidade média; cobre estado externo e loading/single page.
- Atendido: navegação paginada.

### TextField
- Exemplos: 3 (patterns: 3, variações: 5, propriedades: 7, eventos: 2).
- Justificativa: alta complexidade por slots, binding, validação e tipos.
- Atendido: form, busca e senha.

### FieldText
- Exemplos: 1 (patterns: 1, variações: 2, propriedades: 2, eventos: 0).
- Justificativa: baixa complexidade; complemento textual.
- Atendido: prepend/append.

### FieldBadge
- Exemplos: 1 (patterns: 1, variações: 2, propriedades: 3, eventos: 0).
- Justificativa: baixa complexidade; badge de field.
- Atendido: complemento de descrição.

### FieldAction
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 5, eventos: 1).
- Justificativa: complexidade média por ser ação local com tema/evento.
- Atendido: buscar e validar.

### FieldGroup
- Exemplos: 2 (patterns: 1, variações: 2, propriedades: 6, eventos: controle).
- Justificativa: complexidade média/alta, mas uso recomendado é indireto.
- Atendido: field shell público via `TextField` e composição avançada.

### ControlGroup
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: 1, eventos: 0).
- Justificativa: baixa complexidade e interno.
- Atendido: uso indireto por field.

### FieldError
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: 1, eventos: 0).
- Justificativa: baixa complexidade e interno.
- Atendido: erro de campo via `TextField`.

### InputFieldBase
- Exemplos: 3 (patterns: 3, variações: 3, propriedades: 4, eventos: 2).
- Justificativa: alta complexidade por ser base de input.
- Atendido: uso público por `TextField`, senha e bind oninput.

### Box
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: 4, eventos: 0).
- Justificativa: baixa complexidade.
- Atendido: zona funcional.

### Bar
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: 4, eventos: filhos).
- Justificativa: baixa complexidade.
- Atendido: action bar simples.

### Container
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 4, eventos: 0).
- Justificativa: complexidade média por contexto responsivo.
- Atendido: grid e formulário.

### Slot
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 5, eventos: 0).
- Justificativa: complexidade média por spans responsivos.
- Atendido: grid e split/list-detail.

### Stack
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: 2, eventos: filhos).
- Justificativa: baixa complexidade.
- Atendido: stack vertical.

### AppLayout
- Exemplos: 3 (patterns: 3, variações: 3, propriedades: 5, eventos: filhos).
- Justificativa: alta complexidade por shell e slots globais.
- Atendido: workspace admin, menu lateral e classes de zona.

### AppTopBar
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 4, eventos: filhos).
- Justificativa: complexidade média.
- Atendido: topbar via shell e uso direto.

### AppSideBar
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 3, eventos: filhos).
- Justificativa: complexidade média.
- Atendido: sidebar direta e via shell.

### AppSideItem
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: 3, eventos: filhos).
- Justificativa: baixa complexidade.
- Atendido: item ativo.

### AppSideMenuButton
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 0, eventos: internos).
- Justificativa: complexidade média por orquestrar offcanvas/menu.
- Atendido: acesso ao menu global.

### AppMenu
- Exemplos: 3 (patterns: 3, variações: 3, propriedades: 2, eventos: handler).
- Justificativa: alta complexidade por serviço, offcanvas e breadcrumbs.
- Atendido: menu global, uso direto e limitação de busca.

### AppMenuList
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 1, eventos: internos).
- Justificativa: complexidade média, majoritariamente interna.
- Atendido: lista de menu por composição.

### AppMenuItem
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 2, eventos: internos).
- Justificativa: complexidade média por tipos de item e favorito.
- Atendido: unidade de menu.

### AppMainLayout
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 1, eventos: 0).
- Justificativa: complexidade média como layout pronto.
- Atendido: uso como layout e equivalente custom.

### Modal
- Exemplos: 3 (patterns: 3, variações: 3, propriedades: 5, eventos: 1).
- Justificativa: alta complexidade por handler, estados e overlay.
- Atendido: confirmação, formulário e bloqueio.

### ModalOutlet
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 0, eventos: internos).
- Justificativa: complexidade média como infraestrutura global.
- Atendido: shell com outlet.

### ModalBackdrop
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: fases internas, eventos: internos).
- Justificativa: complexidade média como suporte de transição.
- Atendido: backdrop indireto.

### OffCanvas
- Exemplos: 3 (patterns: 3, variações: 3, propriedades: 6, eventos: 1).
- Justificativa: alta complexidade por handler, posição, fitting e modalidade.
- Atendido: filtros, menu e painel.

### AsideBox
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 4, eventos: close).
- Justificativa: complexidade média.
- Atendido: caixa de offcanvas.

### CloseOffCanvasButton
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: handler cascated, eventos: clique).
- Justificativa: baixa complexidade.
- Atendido: fechar painel.

### OffCanvasOutlet
- Exemplos: 2 (patterns: 3, variações: 2, propriedades: contexto, eventos: internos).
- Justificativa: complexidade média como infraestrutura layout-aware.
- Atendido: outlet via shell e direto.

### Icon
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: 3, eventos: 0).
- Justificativa: complexidade média por enum/fragment/classes.
- Atendido: ação e estado visual.

### RotateEffect
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: 2, eventos: 0).
- Justificativa: baixa complexidade.
- Atendido: rotação estática.

### RotationMotion
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: 2, eventos: 0).
- Justificativa: baixa complexidade.
- Atendido: indicador de movimento.

### Ripple
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: 1, eventos: 0).
- Justificativa: baixa complexidade e uso indireto.
- Atendido: microinteração de botão.

### YasamenStyles
- Exemplos: 1 (patterns: 1, variações: 1, propriedades: comportamento interno, eventos: 0).
- Justificativa: baixa complexidade como setup.
- Atendido: carregamento de CSS.

### DropBase
- Exemplos: 3 (patterns: 1, variações: 3, propriedades: 5, eventos: 2).
- Justificativa: alta complexidade, mas preferencialmente via wrappers.
- Atendido: wrappers públicos e composição avançada.

### NotificationOutlet
- Exemplos: 2 (patterns: 2, variações: 2, propriedades: service-driven, eventos: internos).
- Justificativa: complexidade média como infraestrutura.
- Atendido: outlet via shell e direto.

### NotificationSection
- Exemplos: 2 (patterns: 1, variações: 2, propriedades: 1, eventos: internos).
- Justificativa: complexidade média como ponte service -> UI.
- Atendido: uso via `Notify` e outlet.
