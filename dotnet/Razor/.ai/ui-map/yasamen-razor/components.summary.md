# Components Summary — yasamen-razor

---

## Button

**Grupo**: UI-ACTION
**Papel de consumo**: uso-direto
**Propósito**: Botão HTML estilizado com suporte a label, ícone, tema, tamanho, outline, block, active, disabled e navegação client-side.
**Características visuais**:
- Classe raiz `ya-btn`; variantes de tema: `ya-btn-primary`, `ya-btn-secondary`, `ya-btn-danger`, etc. (mapeadas de `Themes`)
- Variantes de tamanho: `ya-btn-xs`, `ya-btn-sm`, `ya-btn-lg`, etc. (mapeadas de `Sizes`)
- `Outline=true` aplica estilo de borda sem preenchimento
- `Block=true` adiciona `w-full` para largura total
- `Active=true` aplica classe `active`
- `Disabled` aplica `cursor-not-allowed opacity-50`
- Efeito ripple embutido via `<Ripple Dark="DarkRipple" />`
- Ícone posicionável via `IconPosition` (Start ou End)
- Ícone pode receber `IconAnimation` (ex: RotationMotion wrapping)
**Quando usar**:
- Ações primárias e secundárias em formulários, diálogos e páginas
- Ações de navegação com `NavigateTo`
- Dentro de `ButtonGroup` para agrupamento semântico
**Quando não usar**:
- Quando a ação é apenas ícone sem label — usar `IconButton`
- Links puramente de navegação sem semântica de ação
**Compõe**: Ripple, Icon
**Composto em**: ButtonGroup, FieldAction, DropButton, AppSideMenuButton, qualquer tela
**Propriedades**:
- `Label: string` [EditorRequired] — texto do botão
- `ChildContent: RenderFragment?` — conteúdo alternativo ao label
- `Type: ButtonTypes` — button|submit|reset
- `Style: Themes` — variante de cor semântica
- `Size: Sizes` — densidade/tamanho
- `Icon: Enum?` — ícone registrado no sistema de ícones
- `IconAnimation: AnimationFragment?` — animação aplicada ao ícone
- `IconPosition: Positions` — Start (default) ou End
- `Outline: bool` — estilo outline
- `Block: bool` — largura total
- `Active: bool` — estado ativo visual
- `Disabled: bool` — desabilitado
- `NavigateTo: string?` — URI para navegação após click
- `OnClick: EventCallback<MouseEventArgs>` — callback de click
- `AdditionalClasses: string?` / `AdditionalAttributes` (splatting)
- Recebe `ButtonGroupContext` via cascading: herda Style, Size, Disabled do grupo
**Referências**:
- `RoyalCode.Razor.Buttons/Components/Button.razor`
- `RoyalCode.Razor.Buttons/Components/Button.razor.cs`
- `RoyalCode.Razor.Docs/.../ButtonsPage.razor`
**Notas**: Label é obrigatório mesmo quando se usa ChildContent; IconPosition.Center não é válido e é coercido para Start.

---

## ButtonGroup

**Grupo**: UI-ACTION
**Papel de consumo**: uso-direto
**Propósito**: Agrupa botões relacionados aplicando defaults cascading de Style, Size e Disabled, com layout horizontal ou vertical.
**Características visuais**:
- Classe raiz `ya-btn-group`
- `ya-btn-group-horizontal` ou `ya-btn-group-vertical` por `Orientation`
- `ya-btn-group-disabled` quando todo o grupo está desabilitado
- Botões filhos herdam Style e Size via `ButtonGroupContext` (cascading)
**Quando usar**:
- Conjunto de ações relacionadas (ex: Salvar / Cancelar)
- Toolbars de botões com estilo uniforme
- Toggle groups (com Active individual nos botões)
**Quando não usar**:
- Ações não relacionadas que não devem ser percebidas como grupo semântico
**Compõe**: Button, IconButton
**Composto em**: Formulários, toolbars, headers de card/page
**Propriedades**:
- `ChildContent: RenderFragment` [EditorRequired] — botões filhos
- `Orientation: ButtonGroupOrientation` — Horizontal (default) | Vertical
- `Style: Themes` — tema default aplicado aos filhos
- `Size: Sizes` — tamanho default aplicado aos filhos
- `Disabled: bool` — desabilita todos os filhos
- `AriaLabel: string?` — rótulo acessível do grupo
- `AdditionalClasses / AdditionalAttributes`
**Referências**:
- `RoyalCode.Razor.Buttons/Components/ButtonGroup.razor`
- `RoyalCode.Razor.Buttons/Components/ButtonGroup.razor.cs`
- `RoyalCode.Razor.Docs/.../Buttons/ButtonGroupPage.razor`
**Notas**: -

---

## IconButton

**Grupo**: UI-ACTION
**Papel de consumo**: uso-direto
**Propósito**: Botão HTML apenas com ícone, sem label textual visível. Sempre usa ripple dark.
**Características visuais**:
- Classe raiz `ya-i-btn`
- Variantes de tema: `ya-i-btn-primary`, etc.
- Variantes de tamanho: `ya-i-btn-xs`, etc.
- `Active=true` adiciona classe `active`
- `Outline=true` estilo outline
- Efeito ripple dark embutido
**Quando usar**:
- Ações representadas apenas por ícone (fechar, editar, mais opções)
- Sidebar de aplicação, toolbars compactas
- Dentro de `DropIconButton`
**Quando não usar**:
- Quando a ação precisa de texto explícito para clareza — usar `Button`
**Compõe**: Ripple, Icon
**Composto em**: AppSideBar, AppSideMenuButton, DropIconButton, toolbars
**Propriedades**:
- `Type: ButtonTypes` — tipo HTML
- `Style: Themes` — tema
- `Size: Sizes` — tamanho
- `Icon: Enum?` — ícone via sistema de ícones
- `IconFragment: Func<RenderFragment>?` — fragmento de ícone direto (alternativa a Icon)
- `IconAnimation: AnimationFragment?` — animação no ícone
- `Outline: bool` — estilo outline
- `Active: bool` — estado ativo
- `Disabled: bool` — desabilitado
- `OnClick: EventCallback<MouseEventArgs>`
- `AdditionalClasses / AdditionalAttributes`
- Recebe `ButtonGroupContext` via cascading
**Referências**:
- `RoyalCode.Razor.Buttons/Components/IconButton.razor`
- `RoyalCode.Razor.Buttons/Components/IconButton.razor.cs`
- `RoyalCode.Razor.Docs/.../IconButtonPage.razor`
**Notas**: Requer ao menos `Icon` ou `IconFragment`.

---

## Badge

**Grupo**: UI-CONTENT
**Papel de consumo**: uso-direto
**Propósito**: Rótulo/pill compacto para indicar estado, categoria, contagem ou classificação inline.
**Características visuais**:
- Classe raiz `ya-badge`
- Variantes de tema: `ya-badge-primary`, `ya-badge-success`, `ya-badge-danger`, etc.
- Variantes de tamanho via `ya-badge-{size}`
- Suporta ícone (Start ou End) com `Icon` e `IconPosition`
- Default fallback: `ya-badge-secondary` quando Style não definido
**Quando usar**:
- Indicadores de status em listas, tabelas, cards
- Contadores de notificação ou itens
- Tags de classificação/categoria
**Quando não usar**:
- Mensagens de feedback extensas — usar `Feedback`
- Feedback de sistema em overlay — usar `Notification`
**Compõe**: Icon
**Composto em**: Tabelas, listas, cards, headers; FieldBadge (dentro de form fields)
**Propriedades**:
- `Text: string?` — texto do badge
- `ChildContent: RenderFragment?` — conteúdo custom
- `Style: Themes` — variante de cor
- `Size: Sizes` — tamanho
- `Icon: Enum?` — ícone
- `IconPosition: Positions` — Start ou End (Center inválido, lança exceção)
- `AdditionalClasses / AdditionalAttributes`
**Referências**:
- `RoyalCode.Razor.Alerts/Components/Badge.razor`
- `RoyalCode.Razor.Docs/.../BadgesPage.razor`
**Notas**: IconPosition.Center lança InvalidOperationException.

---

## Feedback

**Grupo**: UI-FEEDBACK
**Papel de consumo**: uso-direto
**Propósito**: Painel de feedback inline com título, texto, ícone e botão de fechar opcional. Comunica resultado, erro, aviso ou informação contextual em tela.
**Características visuais**:
- Classe raiz `ya-feedback`
- Variantes de tema: `ya-feedback-success`, `ya-feedback-danger`, `ya-feedback-warning`, etc.
- Variantes de tamanho afetam heading (`h2`–`h6`) e padding
- `Block=true` (default) adiciona `ya-feedback-block` (w-full)
- `Closeable=true` exibe botão de fechar; ajusta padding do título/texto para não sobrepor
- Ícone dimensionado conforme Size e presença de título
- Desaparece ao fechar (estado local `closed`)
**Quando usar**:
- Resultado de operação (salvo com sucesso, erro de validação)
- Alertas contextuais inline dentro de página ou seção
- Mensagens de aviso não-bloqueantes
**Quando não usar**:
- Notificações toast temporárias — usar `Notification`
- Pequenos indicadores de status — usar `Badge`
**Compõe**: Icon
**Composto em**: Formulários, páginas de resultado, seções de conteúdo
**Propriedades**:
- `Title: string?` — título (tag h varia com Size)
- `Text: string?` — texto descritivo
- `ChildContent: RenderFragment?` — conteúdo adicional
- `Style: Themes` — variante de cor
- `Size: Sizes` — tamanho
- `Icon: Enum?` — ícone
- `Closeable: bool` — exibe botão fechar
- `OnClose: EventCallback` — callback ao fechar
- `Block: bool` (default true) — largura total
- `AdditionalClasses / AdditionalAttributes`
**Referências**:
- `RoyalCode.Razor.Alerts/Components/Feedback.razor`
- `RoyalCode.Razor.Docs/.../FeedbacksPage.razor`
**Notas**: -

---

## Notification

**Grupo**: UI-FEEDBACK
**Papel de consumo**: uso-direto
**Propósito**: Notificação toast com ícone temático automático, timer visual de auto-dismiss, pausa no hover e suporte a abertura/fechamento programático.
**Características visuais**:
- Classe raiz `ya-notification`
- Variantes de tema: `ya-notification-success`, `ya-notification-danger`, etc.
- Barra de progresso animada (timer) com `animation-play-state: paused` no hover
- Ícone automático por tema (Success→ícone success, Danger→ícone error, etc.)
- `Closeable=true` exibe botão fechar
- `CloseOnClick=true` fecha ao clicar
- `StartClosed=true` começa fechado (controlado externamente)
**Quando usar**:
- Feedback temporário de ações (ex: "Item salvo", "Erro ao enviar")
- Notificações geradas via `NotificationService` programaticamente
- Alertas com auto-dismiss após timeout
**Quando não usar**:
- Mensagens inline persistentes — usar `Feedback`
- Confirmações críticas que exigem ação do usuário — usar `Modal`
**Compõe**: Icon (temático automático)
**Composto em**: `NotificationOutlet` (interno), gerenciado por `NotificationService`
**Propriedades**:
- `Text: string?` — texto da notificação
- `ChildContent: RenderFragment?` — conteúdo custom
- `Theme: Themes` — variante visual (determina ícone automático)
- `Icon: bool` — exibe ícone temático
- `Timer: TimeSpan?` — duração do auto-dismiss
- `CloseOnClick: bool` — fecha ao clicar
- `StartClosed: bool` — inicia fechado
- `Closeable: bool` — botão fechar manual
- `OnClose: EventCallback` — callback ao fechar
- `OnOpen: EventCallback` — callback ao abrir
- `AdditionalClasses / AdditionalAttributes`
- Métodos públicos: `OpenAsync()`, `CloseAsync()`
**Referências**:
- `RoyalCode.Razor.Alerts/Components/Notification.razor`
- `RoyalCode.Razor.Alerts/Components/NotificationContent.razor`
- `RoyalCode.Razor.Docs/.../NotificationsPage.razor`
**Notas**: Requer `AddYasamenNotification()` no DI. `NotificationContent` é componente helper para texto+detalhes estruturados dentro da notificação.

---

## NotificationContent

**Grupo**: UI-FEEDBACK
**Papel de consumo**: uso-direto
**Propósito**: Conteúdo estruturado para `Notification` com texto principal e linha de detalhes.
**Características visuais**:
- `ya-notification-content-group` como wrapper
- `ya-notification-content-text` e `ya-notification-content-details`
**Quando usar**: Dentro de `<Notification>` quando se precisa de texto + detalhes em duas linhas.
**Quando não usar**: Quando o conteúdo é texto simples — usar parâmetro `Text` do `Notification`.
**Compõe**: -
**Composto em**: Notification
**Propriedades**:
- `Text: string` [EditorRequired]
- `Details: string` [EditorRequired]
**Referências**: `RoyalCode.Razor.Alerts/Components/NotificationContent.razor`
**Notas**: -

---

## DropButton

**Grupo**: UI-ACTION
**Papel de consumo**: uso-direto
**Propósito**: Botão que ao clicar abre um menu dropdown. Combina `Button` com infraestrutura de drop (posição, alinhamento, comportamento de fechamento).
**Características visuais**:
- Renderiza `Button` como trigger + container `ya-drop` com conteúdo `ya-drop-content`
- Direções: `ya-drop-down`, `ya-drop-up`, `ya-drop-left`, `ya-drop-right`
- Alinhamentos: `ya-drop-start`, `ya-drop-center`, `ya-drop-end`
- `ya-drop-open` quando aberto; `aria-expanded` dinâmico
- `MinWidth` controla largura mínima do conteúdo
- `ContentType` define se o conteúdo é `<ul>` (List) ou `<div>` (Default)
**Quando usar**:
- Menu de ações secundárias acionado por botão com label
- Split-button com ações adicionais
**Quando não usar**:
- Quando o trigger deve ser apenas ícone — usar `DropIconButton`
**Compõe**: Button, DropBase (interno)
**Composto em**: Toolbars, headers de cards, ações de linha em tabelas; Breadcrumb (overflow menu)
**Propriedades**:
- Herda todos os parâmetros de `Button` (Label, Style, Size, Icon, etc.) via ButtonContent slot
- `Direction: Directions` — Down (default), Up, Left, Right
- `Align: Positions` — Start, Center, End
- `MinWidth: Sizes?` — largura mínima do menu
- `ContentType: DropContentType` — List | Default
- `CloseBehavior: DropCloseBehavior` — CloseOnClick | CloseOnClickOutside | CloseManually
- `Title: string?` — atributo title do dropdown
- `Handler: DropHandler?` — controle programático externo
- `OnOpened: EventCallback<DropEventArgs>` / `OnClosed: EventCallback<DropEventArgs>`
- `DropAdditionalClasses / ButtonAdditionalClasses`
- `ChildContent: RenderFragment` — conteúdo do menu (DropItems)
- `ButtonContent: RenderFragment` — conteúdo customizado do botão trigger
**Referências**:
- `RoyalCode.Razor.Drops/Components/DropButton.razor`
- `RoyalCode.Razor.Drops/Internal/Drops/DropBase.razor`
- `RoyalCode.Razor.Docs/.../DropsPage.razor`
**Notas**: Fecha automaticamente ao clicar fora (default). O handler interno controla estado open/close.

---

## DropIconButton

**Grupo**: UI-ACTION
**Papel de consumo**: uso-direto
**Propósito**: Botão de ícone que abre dropdown. Equivalente ao `DropButton` mas com `IconButton` como trigger.
**Características visuais**: Idêntico ao `DropButton` mas o trigger usa `ya-i-btn` em vez de `ya-btn`.
**Quando usar**: Menus de contexto em tabelas, cards e toolbars onde o trigger deve ser compacto (apenas ícone).
**Quando não usar**: Quando o trigger precisa de label — usar `DropButton`.
**Compõe**: IconButton, DropBase (interno)
**Composto em**: Linhas de tabela (ações), AppMenu (overflow), toolbars compactas
**Propriedades**:
- Herda parâmetros de `IconButton` (Style, Size, Icon, IconFragment, Outline, Active, Disabled)
- Mesmos parâmetros de drop de `DropButton` (Direction, Align, MinWidth, ContentType, CloseBehavior, etc.)
- `IconAdditionalClasses / DropAdditionalClasses`
**Referências**:
- `RoyalCode.Razor.Drops/Components/DropIconButton.razor`
**Notas**: -

---

## DropItem

**Grupo**: UI-OVERLAY
**Papel de consumo**: uso-direto
**Propósito**: Item de menu dentro de um dropdown. Renderiza como `<li>` quando ContentType=List ou `<div>` caso contrário.
**Características visuais**:
- Classe raiz `ya-drop-item`
- Role dinâmico: `button` quando tem OnClick, `menuitem` caso contrário
**Quando usar**: Dentro do slot de conteúdo de `DropButton` ou `DropIconButton`.
**Quando não usar**: Fora de um contexto de dropdown.
**Compõe**: -
**Composto em**: DropButton, DropIconButton, Breadcrumb (overflow menu)
**Propriedades**:
- `ChildContent: RenderFragment` — conteúdo do item
- `OnClick: EventCallback<MouseEventArgs>` — ação ao clicar
- `AdditionalClasses / Attributes`
- `ContentType: DropContentType` (cascading do DropBase)
**Referências**: `RoyalCode.Razor.Drops/Components/DropItem.razor`
**Notas**: -

---

## FieldText

**Grupo**: UI-INPUT
**Papel de consumo**: uso-direto
**Propósito**: Wrapper estrutural para campos de texto. Envolve um input/control com a classe `ya-field-text`.
**Características visuais**:
- Classe raiz `ya-field-text`
- Wrapper simples sem lógica adicional
**Quando usar**: Para envolver um `<input>` ou control customizado que precisa do estilo de campo de texto da biblioteca.
**Quando não usar**: Quando se precisa de label, erro e estrutura completa — usar `FieldGroup` (interno) ou construir via layout.
**Compõe**: Qualquer input HTML ou control
**Composto em**: FieldGroup (interno), formulários
**Propriedades**:
- `ChildContent: RenderFragment` [EditorRequired]
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Forms/Components/FieldText.razor`
**Notas**: Componente de wrapper simples; lógica de label/error/grupo fica em `FieldGroup` (interno).

---

## FieldAction

**Grupo**: UI-INPUT
**Papel de consumo**: uso-direto
**Propósito**: Botão estilizado para uso dentro de grupos de campos de formulário (prepend/append). Aplica `ya-field-action` ao `Button`.
**Características visuais**:
- Wrapper fino em torno de `Button` que adiciona classe `ya-field-action`
- Herda todo visual do `Button` subjacente
**Quando usar**: Como botão de ação dentro de um campo de formulário (ex: botão "Buscar" ao lado de input, ação de ícone toggle de password).
**Quando não usar**: Ações independentes fora de formulários — usar `Button` diretamente.
**Compõe**: Button
**Composto em**: FieldGroup (slot Prepend/Append), formulários
**Propriedades**:
- `Label: string?`, `Style: Themes`, `Icon: Enum?`, `IconPosition`, `Outline`, `Active`, `Disabled`
- `OnClick: EventCallback<MouseEventArgs>`
- `ChildContent: RenderFragment?`
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Forms/Components/FieldAction.razor`
**Notas**: -

---

## FieldBadge

**Grupo**: UI-INPUT
**Papel de consumo**: uso-direto
**Propósito**: Badge estilizado para uso dentro de campos de formulário (prepend/append). Aplica `ya-field-badge` com variante de tema.
**Características visuais**:
- Classe raiz `ya-field-badge` + variante `ya-badge-{tema}`
- Default fallback: `ya-badge-highlight`
**Quando usar**: Prefixo/sufixo visual em campos de formulário (ex: prefixo de moeda "R$", unidade "kg").
**Quando não usar**: Badges de status fora de formulários — usar `Badge`.
**Compõe**: -
**Composto em**: FieldGroup (slot Prepend/Append)
**Propriedades**:
- `Text: string?` / `ChildContent: RenderFragment?`
- `Style: Themes`
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Forms/Components/FieldBadge.razor`
**Notas**: -

---

## Bar

**Grupo**: UI-STRUCT
**Papel de consumo**: uso-direto
**Propósito**: Container horizontal com três zonas (Start, Middle, End) para distribuição de conteúdo em linha — típico para toolbars e headers de seção.
**Características visuais**:
- Classe raiz `ya-bar flex justify-between items-center w-full`
- Cada zona é um `div` com alinhamento correspondente
**Quando usar**:
- Header de page com título (Start) e ações (End)
- Toolbar com filtros (Start/Middle) e botões de ação (End)
**Quando não usar**: Quando o layout é vertical — usar `Stack`. Quando precisa de grid responsivo — usar `Container`+`Slot`.
**Compõe**: Qualquer conteúdo (botões, títulos, badges)
**Composto em**: AppTopBar, headers de page/section, toolbars
**Propriedades**:
- `Start: RenderFragment` (default EmptyFragment)
- `Middle: RenderFragment` (default EmptyFragment)
- `End: RenderFragment` (default EmptyFragment)
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Layouts/Components/Bar.razor`
**Notas**: -

---

## Box

**Grupo**: UI-STRUCT
**Papel de consumo**: uso-direto
**Propósito**: Container estilizado com borda, padding e margin configuráveis via builders declarativos.
**Características visuais**:
- Classe raiz `ya-box`
- Borda via `BorderBuilder` (Box default = borda completa arredondada)
- Padding via `PaddingBuilder`
- Margin via `MarginBuilder`
**Quando usar**:
- Cards, painéis, seções com borda e espaçamento visual
- Containers com separação visual dentro de layouts
**Quando não usar**: Quando não há necessidade de borda ou espaçamento próprio — usar `Stack` ou `Container`.
**Compõe**: Qualquer conteúdo
**Composto em**: AppLayout main content, seções de página
**Propriedades**:
- `Border: BorderBuilder` (default BorderBuilder.Box)
- `Padding: PaddingBuilder` (default PaddingBuilder.None)
- `Margin: MarginBuilder` (default MarginBuilder.None)
- `ChildContent: RenderFragment`
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Layouts/Components/Box.razor`
**Notas**: Os builders usam API fluente; ex: `Css.Padding.Side.Top().Size.Small()`.

---

## Container

**Grupo**: UI-STRUCT
**Papel de consumo**: uso-direto
**Propósito**: Container de layout responsivo que suporta Grid ou Flex, com configuração de tamanho e altura para os filhos `Slot`.
**Características visuais**:
- Classe raiz `ya-container`
- Grid: usa classe de grid via `Size.ToGridCssClass()` (nº de colunas por breakpoint)
- Flex: `flex flex-wrap grow justify-start`
- Propaga `ContainerContext` (Type, Sizes, Height) via cascading para `Slot` filhos
**Quando usar**:
- Layout de página com grid responsivo de colunas
- Layouts flex com slots de largura variável
**Quando não usar**: Quando a estrutura é simples linear — usar `Stack` ou `Bar`.
**Compõe**: Slot
**Composto em**: Conteúdo principal de páginas, seções de formulário
**Propriedades**:
- `Type: LayoutTypes` (default Grid) — Grid | Flex
- `Size: LayoutSizes` (default Default) — Default | Tablet | Laptop | Desktop
- `Height: SpacingSize?` — altura default dos Slots filhos
- `ChildContent: RenderFragment`
- `AdditionalClasses / AdditionalAttributes`
**Referências**:
- `RoyalCode.Razor.Layouts/Components/Container.razor`
- `RoyalCode.Razor.Layouts/Components/Container.razor.cs`
**Notas**: Deve conter `Slot` como filhos para layout responsivo.

---

## Slot

**Grupo**: UI-STRUCT
**Papel de consumo**: uso-direto
**Propósito**: Coluna responsiva dentro de `Container`. Define span em colunas para diferentes breakpoints (default, tablet, laptop, desktop) e herda tipo de layout do contexto.
**Características visuais**:
- Classe raiz `ya-column`
- Grid: `xs:col-span-1` base + colspan responsivo via `AddGridColClass`
- Flex: `flex-initial px-4` + classe de largura proporcional
- Altura via `height.ToMinHeightCssClass()`
**Quando usar**: Como filho direto de `Container` para ocupar N colunas do grid/flex.
**Quando não usar**: Fora de `Container` — o layout depende do contexto cascading.
**Compõe**: Qualquer conteúdo de página
**Composto em**: Container
**Propriedades**:
- `Span: int` (default 4) — colunas no breakpoint default
- `TabletSpan: int` (default 0) — colunas no tablet
- `LaptopSpan: int` (default 0) — colunas no laptop
- `DesktopSpan: int` (default 0) — colunas no desktop
- `Height: SpacingSize?` — override de altura (default: herda do Container)
- `ChildContent: RenderFragment`
- `AdditionalClasses / AdditionalAttributes`
- `Context: ContainerContext` (cascading do Container)
**Referências**:
- `RoyalCode.Razor.Layouts/Components/Slot.razor`
- `RoyalCode.Razor.Layouts/Components/Slot.razor.cs`
**Notas**: Span 0 nos breakpoints opcionais significa "herdar do default".

---

## Stack

**Grupo**: UI-STRUCT
**Papel de consumo**: uso-direto
**Propósito**: Container vertical flex simples para empilhar elementos na direção de coluna.
**Características visuais**:
- Classe raiz `ya-stack flex flex-col w-100`
**Quando usar**: Empilhamento vertical simples de componentes (form fields, cards, sections).
**Quando não usar**: Layout horizontal — usar `Bar` ou `Container` Flex. Grid responsivo — usar `Container`.
**Compõe**: Qualquer conteúdo
**Composto em**: Conteúdo de páginas, seções, formulários
**Propriedades**:
- `ChildContent: RenderFragment`
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Layouts/Components/Stack.razor`
**Notas**: -

---

## AppLayout

**Grupo**: SHELL
**Papel de consumo**: uso-direto
**Propósito**: Shell completo de aplicação com header fixo (AppTopBar), sidebars opcionais (AppSideBar), área de conteúdo principal (main), footer e suporte integrado a Modal, OffCanvas e Notification outlets.
**Características visuais**:
- Classe raiz `ya-app-layout`
- `ya-app-header` para o header
- `ya-app-page` para a área de página (abaixo do header)
- `ya-app-content` para o conteúdo central entre as sidebars
- `ya-app-main` para o main
- `ya-app-footer` para o footer
- Espaçamento dinâmico via `TopSize`, `FooterSize`, `LeftMenuSize`, `RightMenuSize` (SpacingSize)
- Inclui automaticamente `ModalOutlet`, `OffCanvasOutlet`, `NotificationOutlet`
- Expõe `AppLayoutContext` via cascading (referências de elementos DOM)
**Quando usar**: Como layout raiz de aplicação web completa.
**Quando não usar**: Em páginas sem necessidade de shell completo; para layouts simples sem navegação lateral.
**Compõe**: AppTopBar, AppSideBar (opcional ×2), ModalOutlet, OffCanvasOutlet, NotificationOutlet
**Composto em**: AppMainLayout (herdado de LayoutComponentBase)
**Propriedades**:
- `PreContent / PostContent: RenderFragment` — conteúdo antes/depois do layout principal
- `TopSize: SpacingSize` (default LargerX2) — altura do topbar
- `FooterSize: SpacingSize` (default LargerX2)
- `LeftMenuSize / RightMenuSize: SpacingSize` (default LargerX2)
- `TopStart / TopCenter / TopEnd: RenderFragment` — slots do AppTopBar
- `LeftMenu / RightMenu: RenderFragment` — slots das sidebars (opcional)
- `Main: RenderFragment` [EditorRequired]
- `Footer: RenderFragment` [EditorRequired]
- `AdditionalClasses / AdditionalHeaderClasses / AdditionalPageClasses / AdditionalContentClasses / AdditionalMainClasses / AdditionalFooterClasses`
- `AdditionalAttributes`
**Referências**:
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMainLayout.razor` (exemplo de uso)
- `RoyalCode.Razor.Docs/.../AppLayoutPage.razor`
**Notas**: Requer DI registrado para Modal, OffCanvas e Notifications. O `AppLayoutContext` é propagado por cascading para componentes filhos.

---

## AppTopBar

**Grupo**: SHELL
**Papel de consumo**: uso-direto
**Propósito**: Barra superior do app com três zonas de conteúdo (Start, Center, End) e altura configurável.
**Características visuais**:
- Classe raiz `ya-top-bar`
- Altura via `Size.ToHeightCssClass()` (SpacingSize)
- Zonas: `ya-top-bar-start`, `ya-top-bar-center`, `ya-top-bar-end`
**Quando usar**: Dentro de `AppLayout` no header; pode ser usado standalone em shells customizados.
**Quando não usar**: Para toolbars internas de página — usar `Bar`.
**Compõe**: Qualquer conteúdo (logo, nav, usuário, ações)
**Composto em**: AppLayout (header)
**Propriedades**:
- `Size: SpacingSize` — altura do topbar
- `StartContent / CenterContent / EndContent: RenderFragment`
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppTopBar.razor`
**Notas**: Geralmente recebe `AppSideMenuButton` no Start e ações do usuário no End.

---

## AppSideBar

**Grupo**: SHELL
**Papel de consumo**: uso-direto
**Propósito**: Barra lateral fixa com largura e posição configuráveis (Start ou End).
**Características visuais**:
- Classe raiz `ya-side-bar`
- Largura via `Size.ToWidthCssClass()` e `Size.ToMinWidthCssClass()`
- Posição: Start (esquerda) ou End (direita) — Center inválido
**Quando usar**: Sidebars de aplicação com menus de ícones, controles de seção ou painel lateral.
**Quando não usar**: Painéis deslizantes (drawer) — usar `OffCanvas`.
**Compõe**: AppSideItem, AppSideMenuButton, IconButton, OffCanvas
**Composto em**: AppLayout (LeftMenu/RightMenu)
**Propriedades**:
- `Size: SpacingSize` [EditorRequired]
- `Position: Positions` [EditorRequired] — Start | End
- `ChildContent: RenderFragment`
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppSideBar.razor`
**Notas**: -

---

## AppSideItem

**Grupo**: SHELL
**Papel de consumo**: uso-direto
**Propósito**: Slot de item dentro da AppSideBar com estado ativo visual.
**Características visuais**:
- Classe raiz `ya-side-bar-item` + `active` quando `Active=true`
**Quando usar**: Para envolver cada item/botão da sidebar com estado ativo gerenciado.
**Quando não usar**: Fora de sidebar.
**Compõe**: IconButton, outros componentes de ação
**Composto em**: AppSideBar, AppSideMenuButton
**Propriedades**:
- `Active: bool`
- `ChildContent: RenderFragment?`
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppSideItem.razor`
**Notas**: -

---

## AppSideMenuButton

**Grupo**: SHELL
**Papel de consumo**: uso-direto
**Propósito**: Botão pré-montado para abrir/fechar o `AppMenu` via OffCanvas. Integra `AppSideItem` + `IconButton` + `AppMenu` em um único componente de conveniência.
**Características visuais**:
- Renderiza `AppSideItem` com `IconButton` (ícone Menu) e `AppMenu` dentro de `OffCanvas`
- IconButton muda de tema (Default → Primary) quando o menu está aberto
**Quando usar**: Na sidebar esquerda do `AppLayout` para o botão principal de navegação.
**Quando não usar**: Quando se quer controle manual sobre o handler do menu.
**Compõe**: AppSideItem, IconButton, AppMenu
**Composto em**: AppSideBar, AppLayout (LeftMenu)
**Propriedades**: nenhum parâmetro público — autocontido
**Referências**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppSideMenuButton.razor`
**Notas**: Usa `OffCanvasHandler` interno; gerencia o subscribe/unsubscribe de `StateHasChanged`. Requer `AddYasamenMenu()` no DI.

---

## AppMenu

**Grupo**: UI-NAV
**Papel de consumo**: uso-direto
**Propósito**: Menu de navegação do app exibido via `OffCanvas`. Carrega itens de menu sob demanda via `MenuService`, suporta busca, breadcrumbs de navegação em submenus e favoritos.
**Características visuais**:
- Classe raiz `ya-app-menu`
- Usa `OffCanvas` como container deslizante
- Exibe `DescribesBreadcrumbs` para trilha de submenu ativo
- Exibe `AppMenuList` com os itens
**Quando usar**: Navegação principal do app em modo OffCanvas (slide-in lateral).
**Quando não usar**: Menus inline ou topbar — usar componentes de nav mais simples.
**Compõe**: OffCanvas, DescribesBreadcrumbs, AppMenuList, CloseOffCanvasButton
**Composto em**: AppSideMenuButton
**Propriedades**:
- `Handler: OffCanvasHandler` [EditorRequired] — controle de visibilidade
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenu.razor`
**Notas**: Requer `MenuService` (serviço injetado — `AddYasamenMenu()`). Fecha automaticamente ao navegar para outra rota. Suporta favoritos via `ToggleFavoriteAsync`.

---

## AppMenuList

**Grupo**: UI-NAV
**Papel de consumo**: interno
**Propósito**: Renderiza a lista de itens do menu atual (filhos do `CurrentMenuItem`). Componente interno usado por `AppMenu`.
**Características visuais**: Monta `AppMenuItem` para cada item filho.
**Quando usar**: Não usar diretamente — é gerenciado pelo `AppMenu`.
**Quando não usar**: -
**Compõe**: AppMenuItem
**Composto em**: AppMenu
**Propriedades**: `CurrentMenuItem: MenuItem?`
**Referências**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenuList.razor`
**Notas**: -

---

## AppMenuItem

**Grupo**: UI-NAV
**Papel de consumo**: interno
**Propósito**: Item de menu que suporta três tipos: Link (NavLink navegável), Module (nó com filhos, expande submenu), Divider. Suporta favoritos toggle.
**Características visuais**:
- Classe `ya-menu-item` + `ya-menu-item-link` | `ya-menu-item-module` | `ya-menu-item-divider`
- Link: NavLink com `ya-menu-item-content`
- Module: texto + ícone expand com `ya-menu-item-module-text` / `ya-menu-item-icon`
**Quando usar**: Não usar diretamente — gerenciado por `AppMenuList`.
**Quando não usar**: -
**Compõe**: NavLink, WellKnownIcons (MenuExpand, FavoriteOn/Off)
**Composto em**: AppMenuList
**Propriedades**: `Item: MenuItem` [EditorRequired]; `AppMenuContext` (cascading)
**Referências**: `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenuItem.razor`
**Notas**: -

---

## Modal

**Grupo**: UI-OVERLAY
**Papel de consumo**: uso-direto
**Propósito**: Modal overlay com transições de abertura/fechamento. Renderiza via `SectionContent` com gestão centralizada por `ModalService`.
**Características visuais**:
- Classe raiz `ya-modal`
- Estados de transição: `ya-modal-opening-start`, `ya-modal-opening`, `ya-modal-open`, `ya-modal-closing-start`, `ya-modal-closing`, `ya-modal-closed`
- `Center=true` adiciona `ya-modal-center` (centralizado vertical/horizontal)
- Backdrop gerenciado pelo `ModalOutlet` (interno)
**Quando usar**:
- Diálogos de confirmação, formulários modais, detalhes em overlay
- Qualquer interação que requeira bloqueio da tela principal
**Quando não usar**:
- Painéis laterais — usar `OffCanvas`
- Notificações temporárias — usar `Notification`
**Compõe**: Qualquer conteúdo (ChildContent via CascadingValue ModalContext)
**Composto em**: AppLayout (via ModalOutlet automático), qualquer página
**Propriedades**:
- `Id: string` [EditorRequired] — identificador único do modal
- `ChildContent: RenderFragment`
- `Handler: ModalHandler?` — controle programático externo
- `Closeable: bool` (default true) — permite fechar
- `Center: bool` (default true) — centraliza na viewport
- `OnOpenClose: EventCallback<ModalEventArgs>` — callback de abertura/fechamento
- Métodos públicos: `OpenAsync()`, `CloseAsync()`
**Referências**:
- `RoyalCode.Razor.Modals/Components/Modal.razor`
- `RoyalCode.Razor.Docs/.../ModalPage.razor`
**Notas**: Requer `AddYasamenModal()` no DI. O `ModalService` garante que apenas um modal abre por vez.

---

## Pagination

**Grupo**: UI-NAV
**Papel de consumo**: uso-direto
**Propósito**: Controle de paginação com versões desktop (janela de páginas, ellipsis, first/prev/next/last) e mobile (prev/next + summary). Totalmente acessível com aria-labels.
**Características visuais**:
- Classe raiz `ya-pagination` + variante de tamanho `ToPaginationSize()`
- `ya-pagination-loading` quando `Loading=true`
- Desktop: `ya-pagination-desktop` com `ya-pagination-list` / `ya-pagination-item`
- Mobile: `ya-pagination-mobile` com summary "Página X de Y"
- Link ativo: `ya-pagination-link-active`; desabilitado: `ya-pagination-link-disabled`
- Não renderiza se `TotalPages ≤ 1` (a menos que `SinglePageMode=Render`)
**Quando usar**:
- Listagens paginadas de dados
- Qualquer conjunto de páginas navegáveis
**Quando não usar**:
- Navegação entre seções/abas — usar `AppMenu` ou nav por rota
**Compõe**: WellKnownIcons (First/Previous/Next/Last)
**Composto em**: Páginas de listagem, tabelas de dados
**Propriedades**:
- `CurrentPage: int` [EditorRequired]
- `TotalPages: int` [EditorRequired]
- `PageSize: int?` — tamanho de página (informativo)
- `Loading: bool` — estado de carregamento
- `Size: Sizes` — tamanho
- `SinglePageMode: PaginationSinglePageMode` — Hide | Render | Message
- `SinglePageMessage: string` (default PT-BR)
- `DesktopWindowSize: int` (default 7) — número de páginas visíveis
- `OnPageChanged: EventCallback<int>` — callback de mudança de página
- `PreviousLabel / NextLabel: string` (PT-BR default)
- `AdditionalClasses / AdditionalAttributes`
**Referências**:
- `RoyalCode.Razor.Navigation/Components/Pagination.razor`
- `RoyalCode.Razor.Navigation/Components/Pagination.razor.cs`
- `RoyalCode.Razor.Docs/.../Navigation/PaginationPage.razor`
**Notas**: Labels default em PT-BR. Suporta `aria-label` via `AdditionalAttributes` (extraído internamente).

---

## OffCanvas

**Grupo**: UI-OVERLAY
**Papel de consumo**: uso-direto
**Propósito**: Painel deslizante lateral (drawer) com suporte a posição Start/End, fitting Overlaying/Float, backdrop e título opcional via `AsideBox`.
**Características visuais**:
- Classe raiz `ya-offcanvas`
- `ya-offcanvas-show` quando visível
- `ya-offcanvas-start` | `ya-offcanvas-end` por posição
- `ya-offcanvas-overlaying` quando sobrepõe o conteúdo
- `ya-offcanvas-float` para modo float
- Backdrop: `ya-offcanvas-backdrop` + `ya-offcanvas-backdrop-show ya-modal-visible` quando Modal=true
- Renderiza via `SectionContent` com `OffCanvasService`
**Quando usar**:
- Menus laterais de navegação (AppMenu)
- Painéis de detalhes, filtros, configurações
- Formulários em slide-in
**Quando não usar**:
- Diálogos que bloqueiam interação completa — usar `Modal`
**Compõe**: AsideBox (opcional), CloseOffCanvasButton (dentro do AsideBox)
**Composto em**: AppMenu, AppSideMenuButton, AppMainLayout; qualquer página que necessite de drawer
**Propriedades**:
- `Position: Positions` — Start | End
- `Fitting: Fitting` — Overlaying | Float
- `Modal: bool` — exibe backdrop de modal ao abrir
- `UseBox: bool` — envolve conteúdo em `AsideBox` com título
- `Title: string?` — título do AsideBox (quando `UseBox=true`)
- `BoxSize: Sizes` — tamanho do AsideBox
- `Closeable: bool` — exibe botão fechar no AsideBox
- `Handler: OffCanvasHandler` (propagado por CascadingValue para `CloseOffCanvasButton`)
- `OnVisibilityChanged: EventCallback<bool>`
- `AdditionalClasses / Attributes`
**Referências**:
- `RoyalCode.Razor.OffCanvas/Components/OffCanvas.razor`
- `RoyalCode.Razor.OffCanvas/Components/AsideBox.razor`
**Notas**: Requer `AddYasamenOffCanvas()` no DI. O `OffCanvasHandler` é o contrato externo de controle (Show/Hide/Toggle).

---

## AsideBox

**Grupo**: UI-OVERLAY
**Papel de consumo**: uso-direto
**Propósito**: Container de conteúdo interno do `OffCanvas` com cabeçalho opcional (título + botão fechar) e largura controlada por tamanho.
**Características visuais**:
- Classe raiz `ya-aside-box max-w-full p-6 h-auto flex flex-col bg-white overflow-y-auto`
- Largura via `Size.ToContentCssClass()`
- Header: flex com título h5 e CloseOffCanvasButton
**Quando usar**: Normalmente gerenciado automaticamente pelo `OffCanvas` quando `UseBox=true`.
**Quando não usar**: Quando o conteúdo do OffCanvas é livre/customizado — usar `UseBox=false` e estruturar manualmente.
**Compõe**: CloseOffCanvasButton
**Composto em**: OffCanvas
**Propriedades**:
- `Title: string?`
- `Closeable: bool`
- `Size: Sizes` (default Medium)
- `ChildContent: RenderFragment`
- `AdditionalClasses / AdditionalAttributes`
- `Handler: OffCanvasHandler` (cascading)
**Referências**: `RoyalCode.Razor.OffCanvas/Components/AsideBox.razor`
**Notas**: -

---

## CloseOffCanvasButton

**Grupo**: UI-ACTION
**Papel de consumo**: uso-direto
**Propósito**: Botão de fechar para OffCanvas. Obtém o handler via cascading e chama `Hide()` ao clicar.
**Características visuais**:
- Botão com classe `ya-btn-close` e ícone `WellKnownIcons.Close`
**Quando usar**: Dentro de `AsideBox` ou OffCanvas com UseBox=false para fechar manualmente.
**Quando não usar**: Fora de um OffCanvas — o handler cascading é obrigatório.
**Compõe**: WellKnownIcons.Close
**Composto em**: AsideBox, AppMenu
**Propriedades**: `Handler: OffCanvasHandler` (cascading, obrigatório)
**Referências**: `RoyalCode.Razor.OffCanvas/Components/CloseOffCanvasButton.razor`
**Notas**: Lança `InvalidOperationException` se Handler não estiver disponível no cascading.

---

## Breadcrumb

**Grupo**: UI-NAV
**Papel de consumo**: uso-direto
**Propósito**: Trilha de navegação (breadcrumb) com suporte a menu dropdown de overflow para itens ocultos.
**Características visuais**:
- Classe raiz `ya-breadcrumb` em `<ol>` dentro de `<nav>`
- Itens ocultos renderizados em `DropButton` com ícone de "..."
- Itens visíveis via slot `Items`
**Quando usar**: Navegação hierárquica em páginas com múltiplos níveis. Dentro de `AppMenu` para trilha de submenu.
**Quando não usar**: Navegação flat sem hierarquia.
**Compõe**: BreadcrumbItem, DropButton (overflow), DropItem (overflow itens)
**Composto em**: AppMenu, cabeçalhos de páginas com hierarquia
**Propriedades**:
- `Items: RenderFragment` — itens visíveis (BreadcrumbItem)
- `MenuItems: RenderFragment` — itens no dropdown overflow (DropItem)
- `AdditionalClasses`
**Referências**: `RoyalCode.Razor.Breadcrumbs/Components/Breadcrumb.razor`
**Notas**: -

---

## BreadcrumbItem

**Grupo**: UI-NAV
**Papel de consumo**: uso-direto
**Propósito**: Item individual de breadcrumb. Renderiza como `NavLink` (href) ou `<a>` com click-callback.
**Características visuais**:
- `ya-breadcrumb-item` como `<li>`
- Link com classe `ya-breadcrumb-link` + `active` quando `Active=true`
**Quando usar**: Dentro do slot `Items` de `Breadcrumb`.
**Quando não usar**: Diretamente fora de um Breadcrumb.
**Compõe**: NavLink
**Composto em**: Breadcrumb, DescribesBreadcrumbs
**Propriedades**:
- `Href: string` — URL de destino
- `ChildContent: RenderFragment?` — texto/conteúdo
- `Match: NavLinkMatch` (default Prefix)
- `Active: bool` — estado ativo (último item da trilha)
- `OnClick: EventCallback<MouseEventArgs>` — alternativa ao href
- `AdditionalClasses / AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Breadcrumbs/Components/BreadcrumbItem.razor`
**Notas**: -

---

## DescribesBreadcrumbs

**Grupo**: UI-NAV
**Papel de consumo**: uso-direto
**Propósito**: Breadcrumb inteligente que recebe lista de `BreadcrumbDescription` e aplica automaticamente limite de visíveis, com overflow no dropdown. Gerencia navegação ao clicar.
**Características visuais**: Renderiza `Breadcrumb` com `BreadcrumbItem` e `DropItem` baseado nos dados.
**Quando usar**: Quando o número de itens é dinâmico e pode exceder `MaxVisibleItems`. Dentro de `AppMenu` para trilha de submenu.
**Quando não usar**: Quando o breadcrumb é estático e de tamanho fixo — usar `Breadcrumb`+`BreadcrumbItem` diretamente.
**Compõe**: Breadcrumb, BreadcrumbItem, DropItem
**Composto em**: AppMenu
**Propriedades**:
- `Items: IReadOnlyList<BreadcrumbDescription>` [EditorRequired]
- `MaxVisibleItems: int` [EditorRequired] — máximo de itens visíveis
- `OnClick: EventCallback<BreadcrumbDescription>` — callback ao clicar em item
**Referências**: `RoyalCode.Razor.Breadcrumbs/Components/DescribesBreadcrumbs.razor`
**Notas**: Navega via `NavigationManager.NavigateTo` se `HRef` estiver definido no `BreadcrumbDescription`.

---

## RotateEffect

**Grupo**: UI-INTERACTION
**Papel de consumo**: foundation
**Propósito**: Wrapper que aplica rotação estática ao conteúdo via CSS custom property `--rotate-effect-deg`.
**Características visuais**:
- `<div>` com `style="--rotate-effect-deg: {N}deg"`
**Quando usar**: Para rotacionar ícones ou elementos em ângulo fixo (ex: chevron rotacionado 90°).
**Quando não usar**: Para animações — usar `RotationMotion`.
**Compõe**: Qualquer conteúdo (ícones principalmente)
**Composto em**: Internamente em animações de ícone de botões/drops
**Propriedades**:
- `Degrees: int` [EditorRequired]
- `ChildContent: RenderFragment`
- `AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Animations/Animations/RotateEffect.razor`
**Notas**: -

---

## RotationMotion

**Grupo**: UI-INTERACTION
**Papel de consumo**: foundation
**Propósito**: Wrapper que aplica animação CSS de rotação contínua (clockwise ou counter-clockwise) via atributos HTML customizados.
**Características visuais**:
- `<div ya-rotation>` ou `<div ya-rotation-clockwise>` (atributo, não classe)
**Quando usar**: Para ícones de loading/spinner e indicadores de rotação contínua em botões.
**Quando não usar**: Para rotação estática — usar `RotateEffect`.
**Compõe**: Qualquer conteúdo (ícones)
**Composto em**: Como `IconAnimation` em Button/IconButton via `AnimationFragment`
**Propriedades**:
- `ChildContent: RenderFragment`
- `CounterClockwise: bool` — rotação anti-horária
- `AdditionalAttributes`
**Referências**: `RoyalCode.Razor.Animations/Animations/RotationMotion.razor`
**Notas**: Usa atributos HTML (não classes) como âncora CSS; aplicar estilos via `[ya-rotation]` selector em CSS.

---

## Ripple

**Grupo**: UI-INTERACTION
**Papel de consumo**: foundation
**Propósito**: Efeito visual de onda material ao clicar em botões. Componente de infraestrutura injetado pelo Button e IconButton.
**Características visuais**: Animação de onda a partir do ponto de clique.
**Quando usar**: Não usar diretamente — é injetado automaticamente pelos componentes de botão.
**Quando não usar**: -
**Compõe**: -
**Composto em**: Button, IconButton (embutido no markup)
**Propriedades**: `Dark: bool` — variante dark do ripple
**Referências**: `RoyalCode.Razor.Commons/Ripple.razor`
**Notas**: Componente de infraestrutura; não faz parte da API pública de uso direto.

---

## Icon

**Grupo**: UI-CONTENT
**Papel de consumo**: foundation
**Propósito**: Renderiza um ícone por `Enum Kind` via sistema extensível de `IIconContentFactory`. Sem ícones embutidos — requer pacote de ícones como `RoyalCode.Razor.Icons.Bootstrap`.
**Características visuais**: Renderiza SVG ou HTML do ícone registrado. Fallback é ícone de "ban" quando não registrado.
**Quando usar**: Renderizar ícones via enum typed dentro de componentes customizados.
**Quando não usar**: Ícones well-known usados internamente pela lib — usar `WellKnownIcons` estático diretamente.
**Compõe**: -
**Composto em**: Badge, Feedback, Notification (internamente)
**Propriedades**: `Kind: Enum` — enum de ícone registrado
**Referências**:
- `RoyalCode.Razor.Icons/Icons/Icon.cs`
- `RoyalCode.Razor.Icons/Icons/WellKnownIcons.cs`
**Notas**: Requer pacote de implementação de ícones (ex: `RoyalCode.Razor.Icons.Bootstrap`). `WellKnownIcons` é um registro estático de `IconFragment` delegates por nome semântico.

---

## YasamenStyles

**Grupo**: UI-SYSTEM
**Papel de consumo**: uso-direto
**Propósito**: Injeta o bundle CSS da biblioteca (`yasamen.css` + todos os imports de componentes) no `<head>` da aplicação.
**Características visuais**: Sem renderização visual própria — apenas `<link>` tags para os CSS.
**Quando usar**: Uma vez no `<head>` da aplicação host (em `App.razor` ou `MainLayout.razor`).
**Quando não usar**: Se a aplicação gerencia o CSS de outra forma (bundle manual, CDN).
**Compõe**: -
**Composto em**: App.razor / layout raiz da aplicação
**Propriedades**: nenhum
**Referências**: `RoyalCode.Razor.Styles/Styles/YasamenStyles.razor`
**Notas**: Ponto de entrada único para o CSS público da biblioteca; CSS em `wwwroot/yasamen.css` com imports de todos os componentes.
