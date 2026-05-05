# Components Summary - yasamen

## Visão geral

- Total de componentes mapeados: 53 componentes/artefatos UI.
- Componentes de consumo direto: 39.
- Componentes internos ou de suporte visual: 14.
- Grupos identificados: action, feedback, input, navigation, overlay, layout, app-shell, icon, animation, style-host, utility.
- Ambiguidades: 4.
- Fonte: repo.
- Fonte principal: projetos `RoyalCode.Razor.*` com demos em `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/`.

## Ambiguidades registradas

1. `NotificationGroup` e `NotificationAnimation`: ficam em `Internal/Notifications`, mas são usados diretamente na demo `NotificationsPage.razor`; hipótese: componentes de suporte avançado, não primeira escolha para telas simples.
2. `AppMainLayout`: herda `LayoutComponentBase` e parece layout pronto para app/docs; hipótese: wrapper de aplicação, não componente atômico.
3. `AppMenu`: contém placeholder textual `search component`; hipótese: menu de aplicação ainda incompleto para busca.
4. `YasamenStyles`: componente de host de estilos, sem UI própria; hipótese: deve ser usado no shell/root para carregar CSS.

## Tabela rápida

| Componente | Grupo | Variações | Complexidade | Notas |
|---|---|---|---:|---|
| `Button` | action | `Themes`, `Sizes`, outline, active, disabled, block, icon, navigation | 5 | Consumo direto |
| `IconButton` | action | `Themes`, `Sizes`, outline, active, disabled, icon enum ou fragment | 5 | Exige `Icon` ou `IconFragment` |
| `ButtonGroup` | action | horizontal/vertical, style/size/disabled herdados | 4 | Cascateia defaults para `Button` e `IconButton` |
| `DropButton` | overlay/action | button + drop direction/alignment/min-width/close behavior | 7 | Compõe `Button`, `DropBase`, `DropItem` |
| `DropIconButton` | overlay/action | icon button + drop direction/alignment/min-width/close behavior | 7 | Compõe `IconButton`, `DropBase`, `DropItem` |
| `DropItem` | overlay | list/div content, click | 3 | Item para drop menus |
| `Badge` | feedback/content | `Themes`, `Sizes`, icon position | 3 | Inline label/chip |
| `Feedback` | feedback | `Themes`, `Sizes`, icon, closeable, block | 5 | Alert/banner inline |
| `Notification` | feedback | theme, icon/bar, timer, close, open/close callbacks | 6 | Toast individual |
| `NotificationContent` | feedback | text/details required | 2 | Conteúdo estruturado para notification |
| `Notify` | feedback/service | methods por tema | 4 | Serviço, não componente visual |
| `NotificationGroup` | feedback/internal | `Placements` | 4 | Interno/avançado; usado em demo |
| `NotificationAnimation` | feedback/internal | open/close via component ref | 5 | Interno/avançado; usado em demo |
| `Breadcrumb` | navigation | items + optional menu items | 5 | Usa `DropButton` para overflow inicial |
| `BreadcrumbItem` | navigation | href/onClick, active, match | 3 | Item de breadcrumb |
| `DescribesBreadcrumbs` | navigation | max visible items, descriptions, click | 5 | Gera breadcrumb a partir de modelo |
| `Pagination` | navigation | size, loading, single-page mode, window size, labels | 6 | Desktop e mobile |
| `TextField` | input | input type, bind event, maxlength, value binding, field slots | 7 | Herda `InputFieldBase<string>` |
| `FieldText` | input/content | child content | 2 | Prepend/append textual |
| `FieldBadge` | input/content | theme, text/children | 3 | Complemento visual de campo |
| `FieldAction` | input/action | button style/icon/outline/active/disabled | 4 | Botão para footer de campo |
| `FieldGroup` | input/internal | label, info, error, slots | 6 | Interno usado por fields |
| `ControlGroup` | input/internal | child content | 2 | Agrupa prepend/control/append |
| `FieldError` | input/internal | error message | 2 | Mensagem de erro visual |
| `InputFieldBase` | input/internal | type, maxlength, bind event | 7 | Base de campo |
| `Box` | layout | border/padding/margin builders | 3 | Container simples |
| `Bar` | layout | start/middle/end slots | 3 | Barra horizontal |
| `Container` | layout | grid/flex, layout size, height | 5 | Cascateia contexto para `Slot` |
| `Slot` | layout | span por breakpoint, height | 5 | Coluna/slot responsivo |
| `Stack` | layout | child content | 2 | Pilha vertical |
| `AppLayout` | app-shell | top/footer/menu sizes, slots, class hooks | 8 | Inclui outlets de modal/offcanvas/notificação |
| `AppTopBar` | app-shell | size, start/center/end slots | 4 | Top bar fixa |
| `AppSideBar` | app-shell | size, position start/end | 4 | Sidebar fixa |
| `AppSideItem` | app-shell | active, child content | 2 | Item da sidebar |
| `AppSideMenuButton` | app-shell | internal handler | 5 | Toggle de menu com `OffCanvas` |
| `AppMenu` | app-shell/navigation | menu service, offcanvas, breadcrumbs | 8 | Busca ainda placeholder |
| `AppMenuList` | app-shell/navigation | current menu item, loading/error/empty | 5 | Lista recursiva via `AppMenuItem` |
| `AppMenuItem` | app-shell/navigation | link/module/divider, favorite | 5 | Renderiza item de menu |
| `AppMainLayout` | app-shell | layout component with body/footer/top/menu | 6 | Layout pronto |
| `Modal` | overlay | id, handler, closeable, center, events | 7 | Usa `SectionContent` e `ModalService` |
| `ModalOutlet` | overlay/internal | service-driven outlet | 6 | Necessário no shell |
| `ModalBackdrop` | overlay/internal | transition phases | 5 | Backdrop interno |
| `OffCanvas` | overlay | position, fitting, modal, box, handler | 7 | Usa `SectionContent` e service |
| `AsideBox` | overlay/layout | title, closeable, size | 4 | Caixa padrão dentro de offcanvas |
| `CloseOffCanvasButton` | overlay/action | cascading handler | 3 | Botão fechar por contexto |
| `OffCanvasOutlet` | overlay/internal | layout-aware outlet | 6 | Necessário no shell |
| `Icon` | icon | kind enum ou fragment, classes/attrs | 4 | Usa `IconContentFactories` |
| `RotateEffect` | animation | degrees, child content | 3 | Efeito estatico por CSS var |
| `RotationMotion` | animation | clockwise/counterclockwise | 3 | Motion para envolver ícones/conteúdo |
| `Ripple` | utility | dark ripple | 3 | Efeito JS/CSS em botões |
| `YasamenStyles` | style-host | debug/release stylesheet selection | 3 | Carrega CSS da lib |
| `DropBase` | overlay/internal | action/drop slots + JS body click | 7 | Base interna |
| `NotificationOutlet` | feedback/internal | service groups | 6 | Outlet interno |
| `NotificationSection` | feedback/internal | item to notification | 5 | Ponte service -> UI |

## Detalhamento por componente

### Button

**Grupo**: action  
**Propósito**: Renderiza um `<button>` estilizado com tema, tamanho, ícone opcional, ripple, estados e navegação opcional via `NavigateTo`.  
**Compõe**: `Icon` via `IconRender`, `Ripple`, `ChildContent`.  
**Composto em**: `ButtonGroup`, `DropButton`, `FieldAction`, formulários, barras e ações gerais.  
**Variações**: `ButtonTypes`, `Themes`, `Sizes`, `Icon`, `IconAnimation`, `IconPosition`, `Outline`, `Block`, `Active`, `Disabled`, `NavigateTo`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Buttons/Components/Button.razor`, `RoyalCode.Razor.Buttons/Components/Button.razor.cs`, `RoyalCode.Razor.Buttons/Components/Button.Extensions.razor.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/ButtonsPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/ButtonsPage.razor`, `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Buttons/ButtonGroupPage.razor`, `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/ModalPage.razor`  
**Notas**: `Label` e obrigatório por atributo; aceita `ChildContent`, mas o markup também renderiza `Label`.

### IconButton

**Grupo**: action  
**Propósito**: Renderiza botão quadrado/compacto baseado em ícone, com tema, tamanho, estados e navegação opcional.  
**Compõe**: `IconRender`, `IconFragment`, `Ripple`.  
**Composto em**: `ButtonGroup`, `DropIconButton`, `AppSideMenuButton`, barras e toolbars.  
**Variações**: `ButtonTypes`, `Themes`, `Sizes`, `Icon`, `IconFragment`, `IconAnimation`, `Outline`, `Active`, `Disabled`, `NavigateTo`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Buttons/Components/IconButton.razor`, `RoyalCode.Razor.Buttons/Components/IconButton.razor.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/IconButtonPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/IconButtonPage.razor`, `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Buttons/ButtonGroupPage.razor`  
**Notas**: lanca excecao se `Icon` e `IconFragment` estiverem ambos ausentes; lanca excecao se ambos forem informados.

### ButtonGroup

**Grupo**: action  
**Propósito**: Agrupa botões relacionados e distribui defaults de estilo, tamanho e disabled para filhos.  
**Compõe**: `Button`, `IconButton`, qualquer conteúdo compativel dentro do grupo.  
**Composto em**: toolbars, formulários, cards e barras de ação.  
**Variações**: `ButtonGroupOrientation.Horizontal`, `ButtonGroupOrientation.Vertical`, `Style`, `Size`, `Disabled`, `AriaLabel`.  
**Complexidade**: 4  
**Referência**: `RoyalCode.Razor.Buttons/Components/ButtonGroup.razor`, `RoyalCode.Razor.Buttons/Components/ButtonGroup.razor.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Buttons/ButtonGroupPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Buttons/ButtonGroupPage.razor`  
**Notas**: extrai `class` e `aria-label` de atributos adicionais.

### DropButton

**Grupo**: overlay/action  
**Propósito**: Combina `Button` com menu suspenso controlado por `DropBase`.  
**Compõe**: `Button`, `DropBase`, `DropItem`, `ButtonContent`, `DropMenu`/`ChildContent`.  
**Composto em**: breadcrumbs com menu, menus de ações, toolbars.  
**Variações**: parametros de `Button`, `Direction`, `Align`, `MinWidth`, `ContentType`, `CloseBehavior`, `Handler`, eventos `OnOpened`/`OnClosed`.  
**Complexidade**: 7  
**Referência**: `RoyalCode.Razor.Drops/Components/DropButton.razor`, `RoyalCode.Razor.Drops/Components/DropButton.razor.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/DropsPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/DropsPage.razor`, `RoyalCode.Razor.Breadcrumbs/Components/Breadcrumb.razor`  
**Notas**: propriedade `Loading` existe, mas não há evidência de renderizacao de loading no markup atual.

### DropIconButton

**Grupo**: overlay/action  
**Propósito**: Combina `IconButton` com menu suspenso.  
**Compõe**: `IconButton`, `DropBase`, `DropItem`, `IconFragment`, `AnimationFragment`.  
**Composto em**: menus compactos, barras de ferramentas, ações de item.  
**Variações**: parametros de `IconButton`, `Direction`, `Align`, `MinWidth`, `ContentType`, `CloseBehavior`, `Handler`, eventos.  
**Complexidade**: 7  
**Referência**: `RoyalCode.Razor.Drops/Components/DropIconButton.razor`, `RoyalCode.Razor.Drops/Components/DropIconButton.razor.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/DropsPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/DropsPage.razor`  
**Notas**: propriedade `Loading` existe, mas não há evidência de renderizacao de loading no markup atual.

### DropItem

**Grupo**: overlay/navigation  
**Propósito**: Item clicavel ou estrutural dentro de um drop menu.  
**Compõe**: `ChildContent`.  
**Composto em**: `DropButton`, `DropIconButton`, `Breadcrumb` overflow.  
**Variações**: `ContentType` cascated (`List` gera `li`, `NotDefined` gera `div`), `OnClick`, `AdditionalClasses`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.Drops/Components/DropItem.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/DropsPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/DropsPage.razor`  
**Notas**: role muda para `button` quando há `OnClick`.

### DropBase

**Grupo**: overlay/internal  
**Propósito**: Base interna que posiciona trigger e conteúdo, controla abertura/fechamento e escuta clique fora via JS.  
**Compõe**: `Action`, `DropContent`, `ClickJs`.  
**Composto em**: `DropButton`, `DropIconButton`.  
**Variações**: `Direction`, `Align`, `MinWidth`, `ContentType`, `CloseBehavior`, `Title`.  
**Complexidade**: 7  
**Referência**: `RoyalCode.Razor.Drops/Internal/Drops/DropBase.razor`, `RoyalCode.Razor.Drops/Internal/Drops/DropBase.razor.css`  
**Docs**: não documentado para consumo direto  
**Exemplos**: indiretamente em `DropsPage.razor`  
**Notas**: componente interno.

### Badge

**Grupo**: feedback/content  
**Propósito**: Label/chip inline com tema, tamanho, texto/conteúdo e ícone opcional.  
**Compõe**: `Icon`, `ChildContent`, `Text`.  
**Composto em**: listas, cards, tabelas, headers e status inline.  
**Variações**: `Themes`, `Sizes`, `Icon`, `IconPosition`, `Text`, `ChildContent`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.Alerts/Components/Badge.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/BadgesPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/BadgesPage.razor`  
**Notas**: `IconPosition.Center` e inválido e gera excecao.

### Feedback

**Grupo**: feedback  
**Propósito**: Bloco de feedback inline para mensagens com título, texto, ícone e ação de fechar.  
**Compõe**: `Icon`, `WellKnownIcons.Close`, `ChildContent`.  
**Composto em**: formulários, páginas de erro/sucesso, banners dentro de cards.  
**Variações**: `Themes`, `Sizes`, `Icon`, `Closeable`, `Block`, `Title`, `Text`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Alerts/Components/Feedback.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/FeedbacksPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/FeedbacksPage.razor`  
**Notas**: tamanho altera tag de título (`h6` a `h2`) e tamanho do ícone.

### Notification

**Grupo**: feedback  
**Propósito**: Toast/notificação individual com tema, ícone ou barra lateral, timer e fechamento manual/automático.  
**Compõe**: `NotificationContent`, `WellKnownIcons`, `ChildContent`.  
**Composto em**: `NotificationGroup`, `NotificationSection`, demos de toast.  
**Variações**: `Theme`, `Icon`, `Timer`, `CloseOnClick`, `StartClosed`, `Closeable`, `OnOpen`, `OnClose`.  
**Complexidade**: 6  
**Referência**: `RoyalCode.Razor.Alerts/Components/Notification.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/NotificationsPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/NotificationsPage.razor`  
**Notas**: pausar timer em hover e fechar por animação do progress bar.

### NotificationContent

**Grupo**: feedback/content  
**Propósito**: Conteúdo padrão para notificação com texto principal e detalhes.  
**Compõe**: texto/detalhes.  
**Composto em**: `Notification`, `NotificationSection`.  
**Variações**: `Text`, `Details`.  
**Complexidade**: 2  
**Referência**: `RoyalCode.Razor.Alerts/Components/NotificationContent.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/NotificationsPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/NotificationsPage.razor`  
**Notas**: `Text` e `Details` marcados como obrigatorios.

### Notify

**Grupo**: feedback/service  
**Propósito**: Serviço para disparar notificações por tema com calculo de timer baseado nos detalhes.  
**Compõe**: `NotificationService`, `NotificationItem`.  
**Composto em**: fluxos que precisem emitir toast sem montar `Notification` manualmente.  
**Variações**: `Primary`, `Secondary`, `Tertiary`, `Info`, `Highlight`, `Success`, `Warning`, `Alert`, `Danger`, `Light`, `Dark`.  
**Complexidade**: 4  
**Referência**: `RoyalCode.Razor.Alerts/Components/Notify.cs`, `RoyalCode.Razor.Alerts/Extensions/AlertServiceCollectionExtensions.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Program.cs` registra `AddYasamenNotification()`  
**Exemplos**: uso direto não localizado nas demos permitidas  
**Notas**: não e componente visual.

### NotificationGroup

**Grupo**: feedback/internal  
**Propósito**: Posiciona notificações em grupos por placement.  
**Compõe**: `Notification`, `ChildContent`.  
**Composto em**: `NotificationOutlet`; também usado diretamente em demo.  
**Variações**: `Placements`, `AdditionalClasses`.  
**Complexidade**: 4  
**Referência**: `RoyalCode.Razor.Alerts/Internal/Notifications/NotificationGroup.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/NotificationsPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/NotificationsPage.razor`  
**Notas**: ambiguo por estar em `Internal` e ser demonstrado diretamente.

### NotificationAnimation

**Grupo**: feedback/internal  
**Propósito**: Wrapper animado para entrada/saida de notificações.  
**Compõe**: `ChildContent`.  
**Composto em**: `NotificationSection`, demo avançada de notificações.  
**Variações**: métodos/ref internos de abertura/fechamento; parametros publicos apenas `ChildContent`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Alerts/Internal/Notifications/NotificationAnimation.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/NotificationsPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/NotificationsPage.razor`  
**Notas**: ambiguo por estar em `Internal` e ser demonstrado diretamente.

### NotificationOutlet

**Grupo**: feedback/internal  
**Propósito**: Renderiza grupos de notificação gerenciados por `NotificationService`.  
**Compõe**: `NotificationGroup`, `NotificationSection`.  
**Composto em**: `AppLayout`.  
**Variações**: service-driven, sem parametros publicos evidenciados.  
**Complexidade**: 6  
**Referência**: `RoyalCode.Razor.Alerts/Internal/Notifications/NotificationOutlet.razor`  
**Docs**: não documentado para consumo direto  
**Exemplos**: usado em `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`  
**Notas**: componente interno de shell.

### NotificationSection

**Grupo**: feedback/internal  
**Propósito**: Converte `NotificationItem` do serviço em `Notification` visual com animação.  
**Compõe**: `NotificationAnimation`, `Notification`, `NotificationContent`.  
**Composto em**: `NotificationOutlet`.  
**Variações**: `Item`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Alerts/Internal/Notifications/NotificationSection.razor`  
**Docs**: não documentado para consumo direto  
**Exemplos**: indiretamente via `NotificationOutlet`  
**Notas**: componente interno.

### Breadcrumb

**Grupo**: navigation  
**Propósito**: Renderiza breadcrumb com lista ordenada e dropdown opcional no inicio para itens ocultos.  
**Compõe**: `BreadcrumbItem`, `DropButton`, `MenuItems`, `Items`.  
**Composto em**: páginas, `DescribesBreadcrumbs`, `AppMenu`.  
**Variações**: `MenuItems`, `Items`, `AdditionalClasses`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Breadcrumbs/Components/Breadcrumb.razor`, `RoyalCode.Razor.Breadcrumbs/Components/Breadcrumb.razor.cs`  
**Docs**: usado por `DescribesBreadcrumbs`; demo direta não localizada  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenu.razor`  
**Notas**: overflow inicial usa `DropButton` com `WellKnownIcons.Dots`.

### BreadcrumbItem

**Grupo**: navigation  
**Propósito**: Item de breadcrumb com `NavLink` ou callback de clique.  
**Compõe**: `ChildContent`.  
**Composto em**: `Breadcrumb`, `DescribesBreadcrumbs`.  
**Variações**: `Href`, `Match`, `Active`, `OnClick`, `AdditionalClasses`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.Breadcrumbs/Components/BreadcrumbItem.razor`  
**Docs**: usado por `DescribesBreadcrumbs`; demo direta não localizada  
**Exemplos**: `RoyalCode.Razor.Breadcrumbs/Components/DescribesBreadcrumbs.razor`  
**Notas**: quando `OnClick` existe renderiza `<a>` sem `href`; caso contrario usa `NavLink`.

### DescribesBreadcrumbs

**Grupo**: navigation  
**Propósito**: Gera breadcrumb responsivo a partir de `BreadcrumbDescription` e esconde itens excedentes em dropdown.  
**Compõe**: `Breadcrumb`, `BreadcrumbItem`, `DropItem`.  
**Composto em**: `AppMenu` breadcrumbs.  
**Variações**: `Items`, `MaxVisibleItems`, `OnClick`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Breadcrumbs/Components/DescribesBreadcrumbs.razor`, `RoyalCode.Razor.Breadcrumbs/Components/BreadcrumbDescription.cs`  
**Docs**: não documentado fora do código  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenu.razor`  
**Notas**: se `OnClick` não for fornecido e `HRef` existir, navega via `NavigationManager`.

### Pagination

**Grupo**: navigation  
**Propósito**: Paginação responsiva com controles first/prev/next/last, janela desktop com ellipsis e resumo mobile.  
**Compõe**: `WellKnownIcons.Pagination*`, botões internos.  
**Composto em**: páginas de listagem e data views.  
**Variações**: `CurrentPage`, `TotalPages`, `PageSize`, `Loading`, `Size`, `SinglePageMode`, `SinglePageMessage`, `DesktopWindowSize`, labels.  
**Complexidade**: 6  
**Referência**: `RoyalCode.Razor.Navigation/Components/Pagination.razor`, `RoyalCode.Razor.Navigation/Components/Pagination.razor.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Navigation/PaginationPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Navigation/PaginationPage.razor`  
**Notas**: `PageSize` existe como parametro, mas não há evidência de uso no markup/lógica atual.

### TextField

**Grupo**: input  
**Propósito**: Campo de texto com label, placeholder, binding, validação, slots de prepend/append/complement/footer e integração `EditForm`.  
**Compõe**: `InputFieldBase<string>`, `FieldGroup`, `ControlGroup`, `FieldText`, `FieldBadge`, `FieldAction`.  
**Composto em**: formulários.  
**Variações**: `Value`, `ValueChanged`, `ValueExpression`, `OnChange`, `Type`, `MaxLength`, `BindEvent`, `Id`, `Name`, `Label`, `Placeholder`, `Information`, `Error`, `Disabled`, `ReadOnly`, `Size`, slots.  
**Complexidade**: 7  
**Referência**: `RoyalCode.Razor.Forms/Components/TextField.cs`, `RoyalCode.Razor.Forms/Internal/Forms/InputFieldBase.razor`, `RoyalCode.Razor.Forms/Internal/Forms/FieldBase.cs`, `RoyalCode.Razor.Forms/Internal/Forms/FieldBase'1.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Notas**: `TextField` e class-only e herda markup de `InputFieldBase<TValue>`.

### FieldText

**Grupo**: input/content  
**Propósito**: Conteúdo textual visual para prepend/append de campos.  
**Compõe**: `ChildContent`.  
**Composto em**: slots `Prepend` e `Append` de `TextField`.  
**Variações**: `AdditionalClasses`, attributes adicionais.  
**Complexidade**: 2  
**Referência**: `RoyalCode.Razor.Forms/Components/FieldText.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Notas**: tamanho e herdado por classes do container `.ya-field-*`.

### FieldBadge

**Grupo**: input/content  
**Propósito**: Badge compacto para complemento de descrição em campos.  
**Compõe**: `Text`, `ChildContent`.  
**Composto em**: `DescriptionComplement` de `TextField`.  
**Variações**: `Themes`, `Text`, `ChildContent`, `AdditionalClasses`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.Forms/Components/FieldBadge.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Notas**: reaproveita classes de badge temático (`ya-badge-*`).

### FieldAction

**Grupo**: input/action  
**Propósito**: Botão de ação para footer de campo, baseado em `Button`.  
**Compõe**: `Button`, `ChildContent`.  
**Composto em**: `FooterAction` de `TextField`/`FieldGroup`.  
**Variações**: `Label`, `Style`, `Icon`, `IconPosition`, `Outline`, `Active`, `Disabled`, `OnClick`.  
**Complexidade**: 4  
**Referência**: `RoyalCode.Razor.Forms/Components/FieldAction.razor`, `RoyalCode.Razor.Forms/Components/FieldAction.razor.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Notas**: default `Style` e `Themes.Tertiary`.

### FieldGroup

**Grupo**: input/internal  
**Propósito**: Estrutura visual de campo com label, controle, informação, erro, prepend/append e footer.  
**Compõe**: `ControlGroup`, `FieldError`, slots.  
**Composto em**: `InputFieldBase<TValue>`.  
**Variações**: `Expanded`, `Size`, label ids, `Information`, `ErrorMessage`, slots.  
**Complexidade**: 6  
**Referência**: `RoyalCode.Razor.Forms/Internal/Forms/FieldGroup.razor`  
**Docs**: indiretamente via `TextFieldPage.razor`  
**Exemplos**: `RoyalCode.Razor.Forms/Internal/Forms/InputFieldBase.razor`  
**Notas**: componente interno.

### ControlGroup

**Grupo**: input/internal  
**Propósito**: Flex group para unir prepend, input e append em uma linha.  
**Compõe**: `ChildContent`.  
**Composto em**: `FieldGroup`.  
**Variações**: `ChildContent`.  
**Complexidade**: 2  
**Referência**: `RoyalCode.Razor.Forms/Internal/Forms/ControlGroup.razor`  
**Docs**: indiretamente via `TextFieldPage.razor`  
**Exemplos**: `RoyalCode.Razor.Forms/Internal/Forms/FieldGroup.razor`  
**Notas**: componente interno.

### FieldError

**Grupo**: input/internal  
**Propósito**: Mensagem visual de erro de campo.  
**Compõe**: texto de erro.  
**Composto em**: `FieldGroup`.  
**Variações**: `ErrorMessage`.  
**Complexidade**: 2  
**Referência**: `RoyalCode.Razor.Forms/Internal/Forms/FieldError.razor`  
**Docs**: indiretamente via `TextFieldPage.razor`  
**Exemplos**: `RoyalCode.Razor.Forms/Internal/Forms/FieldGroup.razor`  
**Notas**: componente interno.

### InputFieldBase

**Grupo**: input/internal  
**Propósito**: Base genérica de input que renderiza `<input>` com binding, ids, validação e field shell.  
**Compõe**: `FieldBase<TValue>`, `FieldGroup`.  
**Composto em**: `TextField`.  
**Variações**: `InputType`, `MaxLength`, `BindEvent` mais parametros herdados de `FieldBase<TValue>`.  
**Complexidade**: 7  
**Referência**: `RoyalCode.Razor.Forms/Internal/Forms/InputFieldBase.razor`, `RoyalCode.Razor.Forms/Internal/Forms/InputFieldBase.razor.cs`  
**Docs**: indiretamente via `TextFieldPage.razor`  
**Exemplos**: `RoyalCode.Razor.Forms/Components/TextField.cs`  
**Notas**: componente interno/base.

### Box

**Grupo**: layout  
**Propósito**: Container simples para envolver conteúdo com builders de borda, padding e margin.  
**Compõe**: `ChildContent`.  
**Composto em**: demos, páginas, blocos de conteúdo.  
**Variações**: `BorderBuilder`, `PaddingBuilder`, `MarginBuilder`, `AdditionalClasses`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.Layouts/Components/Box.razor`  
**Docs**: usado amplamente nas demos  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/*.razor`  
**Notas**: classe base `ya-box`; variações dependem dos builders de estilo.

### Bar

**Grupo**: layout  
**Propósito**: Barra horizontal de tres áreas (`Start`, `Middle`, `End`) para ações e conteúdo alinhado.  
**Compõe**: slots `Start`, `Middle`, `End`.  
**Composto em**: toolbars, card headers/footers, exemplos de button groups.  
**Variações**: slots e `AdditionalClasses`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.Layouts/Components/Bar.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Buttons/ButtonGroupPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Buttons/ButtonGroupPage.razor`  
**Notas**: usa classes `d-flex justify-content-*` dentro dos slots, além de `ya-bar flex justify-between items-center w-full`.

### Container

**Grupo**: layout  
**Propósito**: Container responsivo que organiza filhos em grid ou flex e passa contexto para `Slot`.  
**Compõe**: `Slot`, `ChildContent`.  
**Composto em**: formulários, grids de demos, páginas responsivas.  
**Variações**: `LayoutTypes.Grid/Flex`, `LayoutSizes`, `SpacingSize? Height`, `AdditionalClasses`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Layouts/Components/Container.razor`, `RoyalCode.Razor.Layouts/Components/Container.razor.cs`, `RoyalCode.Razor.Layouts/Components/LayoutSizes.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Notas**: default grid usa `xs:grid-cols-1`, `sm:grid-cols-4`, `md:grid-cols-8`, `lg:grid-cols-12`, `2xl:grid-cols-16`.

### Slot

**Grupo**: layout  
**Propósito**: Coluna/slot responsivo dentro de `Container`, com span por breakpoint e altura minima.  
**Compõe**: `ChildContent`.  
**Composto em**: `Container`.  
**Variações**: `Span`, `TabletSpan`, `LaptopSpan`, `DesktopSpan`, `Height`, `AdditionalClasses`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Layouts/Components/Slot.razor`, `RoyalCode.Razor.Layouts/Components/Slot.razor.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/TextFieldPage.razor`  
**Notas**: default `Span=4`; herda `Type`, `Size` e `Height` do `Container`.

### Stack

**Grupo**: layout  
**Propósito**: Pilha vertical simples para conteúdo em coluna.  
**Compõe**: `ChildContent`.  
**Composto em**: layouts e blocos de conteúdo.  
**Variações**: `AdditionalClasses`.  
**Complexidade**: 2  
**Referência**: `RoyalCode.Razor.Layouts/Components/Stack.razor`  
**Docs**: demo direta não localizada  
**Exemplos**: não localizado nas demos permitidas  
**Notas**: classes base `ya-stack flex flex-col w-100`.

### AppLayout

**Grupo**: app-shell  
**Propósito**: Shell de aplicação com top bar fixa, menus laterais opcionais, conteúdo principal, footer e outlets globais.  
**Compõe**: `AppTopBar`, `AppSideBar`, `ModalOutlet`, `OffCanvasOutlet`, `NotificationOutlet`, `Main`, `Footer`, slots de top/menu.  
**Composto em**: `AppMainLayout`, aplicativos Blazor.  
**Variações**: `TopSize`, `FooterSize`, `LeftMenuSize`, `RightMenuSize`, `TopStart`, `TopCenter`, `TopEnd`, `LeftMenu`, `RightMenu`, classes adicionais por área.  
**Complexidade**: 8  
**Referência**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/AppLayoutPage.razor`  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMainLayout.razor`  
**Notas**: integra modal/offcanvas/notificação no próprio layout.

### AppTopBar

**Grupo**: app-shell/layout  
**Propósito**: Top bar de aplicação com slots start/center/end e altura configuravel.  
**Compõe**: `StartContent`, `CenterContent`, `EndContent`.  
**Composto em**: `AppLayout`.  
**Variações**: `SpacingSize Size`, slots, `AdditionalClasses`.  
**Complexidade**: 4  
**Referência**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppTopBar.razor`, `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppTopBar.razor.cs`  
**Docs**: indiretamente via `AppLayoutPage.razor`  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`  
**Notas**: CSS base `ya-top-bar` com `bg-white` e sombra inset inferior.

### AppSideBar

**Grupo**: app-shell/layout  
**Propósito**: Sidebar fixa lateral para menus/ações, com largura baseada em `SpacingSize`.  
**Compõe**: `ChildContent`.  
**Composto em**: `AppLayout`.  
**Variações**: `Size`, `Position` (`Start` ou `End`), `AdditionalClasses`.  
**Complexidade**: 4  
**Referência**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppSideBar.razor`  
**Docs**: indiretamente via `AppLayoutPage.razor`  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`  
**Notas**: valida `Position` e aceita apenas `Start` ou `End`.

### AppSideItem

**Grupo**: app-shell/navigation  
**Propósito**: Item visual de sidebar com estado ativo.  
**Compõe**: `ChildContent`.  
**Composto em**: `AppSideMenuButton`, menus laterais.  
**Variações**: `Active`, `AdditionalClasses`.  
**Complexidade**: 2  
**Referência**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppSideItem.razor`  
**Docs**: indiretamente via `AppMainLayout.razor`  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppSideMenuButton.razor`  
**Notas**: classe ativa adiciona `active`.

### AppSideMenuButton

**Grupo**: app-shell/action  
**Propósito**: Botão de sidebar que alterna o menu principal por `OffCanvasHandler`.  
**Compõe**: `AppSideItem`, `IconButton`, `AppMenu`.  
**Composto em**: `AppMainLayout`, `LeftMenu` de `AppLayout`.  
**Variações**: sem parametros publicos evidenciados.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppSideMenuButton.razor`  
**Docs**: indiretamente via `AppMainLayout.razor`  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMainLayout.razor`  
**Notas**: alterna style entre `Themes.Primary` e `Themes.Default`.

### AppMenu

**Grupo**: app-shell/navigation  
**Propósito**: Menu de aplicação em offcanvas, carregado por `MenuService`, com breadcrumbs e lista de itens.  
**Compõe**: `OffCanvas`, `CloseOffCanvasButton`, `DescribesBreadcrumbs`, `AppMenuList`.  
**Composto em**: `AppSideMenuButton`.  
**Variações**: `Handler`, `AdditionalClasses`.  
**Complexidade**: 8  
**Referência**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenu.razor`, `RoyalCode.Razor.Layouts.Apps/Layouts/Models/MenuService.cs`  
**Docs**: indiretamente via `AppMainLayout.razor`; setup em `AddYasamenMenu()`  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppSideMenuButton.razor`, `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`  
**Notas**: possui placeholder literal `search component`; busca não esta implementada.

### AppMenuList

**Grupo**: app-shell/navigation  
**Propósito**: Renderiza estado de loading/error/empty ou filhos do item de menu atual.  
**Compõe**: `AppMenuItem`, motion de `WellKnownIcons.Working`.  
**Composto em**: `AppMenu`.  
**Variações**: `CurrentMenuItem`; estado vem de `AppMenuContext`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenuList.razor`  
**Docs**: indiretamente via `AppMenu`  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenu.razor`  
**Notas**: texto de loading/error/empty esta no componente.

### AppMenuItem

**Grupo**: app-shell/navigation  
**Propósito**: Renderiza item do menu como link, módulo expansivel ou divider; suporta favorito.  
**Compõe**: `NavLink`, `WellKnownIcons.Favorite*`, `WellKnownIcons.MenuExpand`.  
**Composto em**: `AppMenuList`.  
**Variações**: `MenuItemType.Link`, `Module`, `Divider`, `IsFavorite`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenuItem.razor`, `RoyalCode.Razor.Layouts.Apps/Layouts/Models/MenuItem.cs`  
**Docs**: indiretamente via `AppMenu`  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenuList.razor`  
**Notas**: toggle favorite atualmente escreve erro no console quando falha.

### AppMainLayout

**Grupo**: app-shell  
**Propósito**: Layout Blazor pronto que envolve `@Body` com `AppLayout`, top slots, menu lateral e footer.  
**Compõe**: `AppLayout`, `AppSideMenuButton`, `IconButton`, `OffCanvas`.  
**Composto em**: aplicações Blazor como layout principal.  
**Variações**: sem parametros publicos além de `Body` herdado.  
**Complexidade**: 6  
**Referência**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMainLayout.razor`  
**Docs**: indiretamente por app docs  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Components/Layout/MainLayout.razor` e demos de layout  
**Notas**: ambiguo: e layout pronto, não componente atômico.

### Modal

**Grupo**: overlay  
**Propósito**: Modal com transições, handler programatico, backdrop e estado global via service.  
**Compõe**: `ModalContext`, `ModalService`, `ChildContent`.  
**Composto em**: páginas com dialogos; requer outlet no shell.  
**Variações**: `Id`, `Handler`, `Closeable`, `Center`, `OnOpenClose`.  
**Complexidade**: 7  
**Referência**: `RoyalCode.Razor.Modals/Components/Modal.razor`, `RoyalCode.Razor.Modals/Components/ModalHandler.cs`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/ModalPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/ModalPage.razor`  
**Notas**: `Id` e obrigatório; usa `SectionContent SectionId="state"` e `ModalOutlet`.

### ModalOutlet

**Grupo**: overlay/internal  
**Propósito**: Outlet global que renderiza modais registrados e backdrop.  
**Compõe**: `SectionOutlet`, `ModalBackdrop`.  
**Composto em**: `AppLayout`.  
**Variações**: service-driven.  
**Complexidade**: 6  
**Referência**: `RoyalCode.Razor.Modals/Internal/Modals/ModalOutlet.razor`  
**Docs**: não documentado para consumo direto  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`  
**Notas**: fecha via Escape chamando `ModalService.BackdropActionAsync()`.

### ModalBackdrop

**Grupo**: overlay/internal  
**Propósito**: Backdrop de modal com fases de transição e clique para fechar quando permitido pelo service.  
**Compõe**: `ModalService`, `TransitionState`.  
**Composto em**: `ModalOutlet`.  
**Variações**: fases `TransitionPhases`.  
**Complexidade**: 5  
**Referência**: `RoyalCode.Razor.Modals/Internal/Modals/ModalBackdrop.razor`  
**Docs**: não documentado para consumo direto  
**Exemplos**: `RoyalCode.Razor.Modals/Internal/Modals/ModalOutlet.razor`  
**Notas**: componente interno.

### OffCanvas

**Grupo**: overlay  
**Propósito**: Painel lateral start/end com modos incorporated, overlaying ou float, opcionalmente modal e com box padrão.  
**Compõe**: `AsideBox`, `CloseOffCanvasButton`, `OffCanvasService`, `OffCanvasHandler`.  
**Composto em**: `AppMenu`, paineis laterais, drawers.  
**Variações**: `Position`, `Fitting`, `Modal`, `Closeable`, `Handler`, `UseBox`, `BoxSize`, `Title`, `OnVisibilityChanged`.  
**Complexidade**: 7  
**Referência**: `RoyalCode.Razor.OffCanvas/Components/OffCanvas.razor`, `RoyalCode.Razor.OffCanvas/Components/OffCanvas.razor.cs`, `RoyalCode.Razor.OffCanvas/Components/OffCanvasHandler.cs`  
**Docs**: demo direta não localizada; usado em app shell  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenu.razor`, `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMainLayout.razor`  
**Notas**: valida `Position` e aceita apenas `Positions.Start` ou `Positions.End`.

### AsideBox

**Grupo**: overlay/layout  
**Propósito**: Caixa padrão de conteúdo para `OffCanvas`, com header, título e botão fechar.  
**Compõe**: `CloseOffCanvasButton`, `ChildContent`.  
**Composto em**: `OffCanvas` quando `UseBox=true`.  
**Variações**: `Title`, `Closeable`, `Size`, `AdditionalClasses`.  
**Complexidade**: 4  
**Referência**: `RoyalCode.Razor.OffCanvas/Components/AsideBox.razor`, `RoyalCode.Razor.OffCanvas/Components/AsideBox.razor.css`  
**Docs**: indiretamente via `OffCanvas`  
**Exemplos**: `RoyalCode.Razor.OffCanvas/Components/OffCanvas.razor`  
**Notas**: usa `Sizes.ToContentCssClass()` para largura/altura base.

### CloseOffCanvasButton

**Grupo**: overlay/action  
**Propósito**: Botão de fechar offcanvas baseado em handler cascated.  
**Compõe**: `WellKnownIcons.Close`.  
**Composto em**: `AsideBox`, `AppMenu`.  
**Variações**: nenhuma evidenciada além do cascading `OffCanvasHandler`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.OffCanvas/Components/CloseOffCanvasButton.razor`  
**Docs**: indiretamente via `OffCanvas`/`AppMenu`  
**Exemplos**: `RoyalCode.Razor.OffCanvas/Components/AsideBox.razor`, `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenu.razor`  
**Notas**: lanca excecao sem `OffCanvasHandler` cascated.

### OffCanvasOutlet

**Grupo**: overlay/internal  
**Propósito**: Outlet global de offcanvas ajustado ao contexto de layout.  
**Compõe**: `SectionOutlet`, `OffCanvasService`, `ILayoutContext`.  
**Composto em**: `AppLayout`.  
**Variações**: espacamentos derivados de `TopSize`, `RightMenuSize`, `FooterSize`, `LeftMenuSize`.  
**Complexidade**: 6  
**Referência**: `RoyalCode.Razor.OffCanvas/Internal/OffCanvas/OffCanvasOutlet.razor`  
**Docs**: não documentado para consumo direto  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`  
**Notas**: componente interno.

### Icon

**Grupo**: icon  
**Propósito**: Renderiza ícone por enum registrado ou por `IconFragment`.  
**Compõe**: `IconContentFactories`, `WellKnownIcons`.  
**Composto em**: botões, badges, feedback, notificações, menus.  
**Variações**: `Kind`, `Fragment`, `AdditionalClasses`, attributes adicionais.  
**Complexidade**: 4  
**Referência**: `RoyalCode.Razor.Icons/Icons/Icon.cs`, `RoyalCode.Razor.Icons/Icons/IconRender.cs`, `RoyalCode.Razor.Icons/Icons/Factory/*`  
**Docs**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/DropsPage.razor`, `IconButtonPage.razor`  
**Exemplos**: `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/DropsPage.razor`  
**Notas**: `BootstrapIcons.Include()` registra `BsIconNames` e mapeia `WellKnownIcons`.

### RotateEffect

**Grupo**: animation  
**Propósito**: Wrapper de conteúdo que define `--rotate-effect-deg` para efeito de rotacao por CSS.  
**Compõe**: `ChildContent`.  
**Composto em**: fragments retornados por `Effects.Rotate`.  
**Variações**: `Degrees`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.Animations/Animations/RotateEffect.razor`, `RotateEffect.razor.css`, `Effects.cs`  
**Docs**: não documentado nas demos permitidas  
**Exemplos**: uso indireto por `Effects.Rotate(...)`  
**Notas**: `Effects.Rotate(double)` passa `double` para parametro `int Degrees`; potencial inconsistencia de tipo a validar em etapa futura se necessário.

### RotationMotion

**Grupo**: animation  
**Propósito**: Wrapper para animação de rotacao continua.  
**Compõe**: `ChildContent`.  
**Composto em**: `Motions.Rotation()`, loading de `AppMenuList`.  
**Variações**: `CounterClockwise`; helper `Motions.Rotation(bool clockwise=true)`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.Animations/Animations/RotationMotion.razor`, `RotationMotion.razor.css`, `Motions.cs`  
**Docs**: uso indireto em `AppMenuList`  
**Exemplos**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenuList.razor`  
**Notas**: markup build manual usa `builder.AddAttribute(2, CounterClockwise ? "ya-rotation-clockwise" : "ya-rotation")`; possível intenção de classe, mas sem nome de atributo evidente.

### Ripple

**Grupo**: utility  
**Propósito**: Efeito ripple usado em botões.  
**Compõe**: JS/CSS de ripple.  
**Composto em**: `Button`, `IconButton`.  
**Variações**: `Dark`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.Commons/Ripple.razor`, `RoyalCode.Razor.Commons/wwwroot/ripple.js`, `RoyalCode.Razor.Styles/wwwroot/css/ripple.css`  
**Docs**: indiretamente via demos de botões  
**Exemplos**: `RoyalCode.Razor.Buttons/Components/Button.razor`, `IconButton.razor`  
**Notas**: depende de `AddYasamenCommons()` para `RippleJs`.

### YasamenStyles

**Grupo**: style-host  
**Propósito**: Inclui folhas de estilo da biblioteca no app, escolhendo dist/debug quando debugger anexado e bundle em runtime normal.  
**Compõe**: links CSS para static web assets.  
**Composto em**: shell/root do app Blazor.  
**Variações**: comportamento por `Debugger.IsAttached`.  
**Complexidade**: 3  
**Referência**: `RoyalCode.Razor.Styles/Styles/YasamenStyles.razor`  
**Docs**: não documentado nas demos permitidas  
**Exemplos**: não localizado nas demos permitidas  
**Notas**: ambiguo como componente visual; e componente de setup de estilos.
