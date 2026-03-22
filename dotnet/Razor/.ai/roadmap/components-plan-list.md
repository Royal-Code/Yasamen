
# ROADMAP 1

> Auditado em 15/03/2026 — marcações corrigidas com base nos componentes realmente presentes na biblioteca.

Componentes básicos iniciais:

- [x] Ripple — `RoyalCode.Razor.Commons` › `Ripple.razor`
- [x] Button — `RoyalCode.Razor.Buttons` › `Button.razor`
- [x] ButtonGroup — `RoyalCode.Razor.Buttons` › `ButtonGroup.razor`
- [x] IconButton — `RoyalCode.Razor.Buttons` › `IconButton.razor`
- [x] Alert — `RoyalCode.Razor.Alerts` › `Feedback.razor`
- [x] Messages — `RoyalCode.Razor.Alerts` › `Notification.razor` + `Notify` (serviço DI)
- [x] Badge — `RoyalCode.Razor.Alerts` › `Badge.razor`
- [x] Dropdown — `RoyalCode.Razor.Drops` › `DropButton`, `DropIconButton`, `DropItem`
- [x] Animations — `RoyalCode.Razor.Animations` › `RotateEffect`, `RotationMotion`

Componentes essenciais para formulários

- [x] FormControl — `RoyalCode.Razor.Forms` › `InputFieldBase` + `FieldGroup` + `ControlGroup` (infraestrutura completa com input group / addons)
- [x] TextField — `RoyalCode.Razor.Forms` › `TextField` (único input concreto implementado; usa InputType: Text, Password)
- [ ] TextArea
- [ ] Select
- [ ] CheckBox
- [ ] RadioBox / RadioGroup
- [ ] DatePicker (Data/Hora/DataHora)
- [ ] NumberField

Componentes de Formulários adicionais:

- [ ] FileInput
- [ ] ColorPicker
- [ ] Range (slider)
- [ ] AutoComplete
- [ ] Switch (toggle)
- [ ] FileInput (Uploader)

Melhorias para Formulários e componentes:

- [x] Criar campo Size para os inputs — parâmetro `Size: Sizes` já implementado em `FieldBase` e `FieldGroup`
- [ ] Criar opção Compact para os inputs, onde o label fica em cima da borda do input ou grupo.

Componentes peculiares:

- [ ] ValueBadge (Badge que contém um valor e uma função para gerar a descrição)
- [ ] BadgeListField (Campo com vários itens exibidos como ValueBadge)
- [ ] CascaderSelect
- [ ] CheckBoxSelect
- [ ] CheckBoxTreeSelect
- [ ] TimeSpanPicker (Range de data ou hora)
- [ ] Rate
- [ ] TreeSelect
- [ ] SignatureInput
- [ ] DashboardLayout

Componentes diversos:

- [ ] Accordion
- [ ] Affix
- [x] Breadcrumb — `RoyalCode.Razor.Breadcrumbs` › `Breadcrumb`, `BreadcrumbItem`, `DescribesBreadcrumbs`
- [ ] Card *(parcial — `Box` serve como card genérico, mas sem semântica de Card dedicada)*
- [ ] Carousel
- [ ] CheckTree
- [ ] Collapse
- [ ] ListGroup
- [x] Dialog (Modal) — `RoyalCode.Razor.Modals` › `Modal`, `ModalHandler`
- [ ] Tabs
- [ ] Tree
- [x] Pagination
- [ ] Panel *(parcial — `Box` + `OffCanvas/AsideBox` cobrem casos de painel)*
- [ ] Placeholders / Skeleton
- [ ] Popover
- [ ] ProgressBar
- [ ] Scrollspy
- [x] Spinner (Loader) — `RoyalCode.Razor.Animations` › `RotationMotion` (spinner por rotação)
- [ ] Steps / Stepper
- [ ] Timeline
- [x] Toast — `RoyalCode.Razor.Alerts` › `Notification` + `NotificationContent` + `Notify`
- [ ] Tooltip

Componentes Complexos:

- [ ] Agenda (Calendar)
- [ ] DataGrid (do simples ao complexo)
- [ ] QueryBuilder
- [ ] TreeGrid
- [ ] Charts
- [ ] BarCode
- [ ] QRCode
- [ ] Kanban
- [ ] Maps
- [ ] StockChart (velas - trade)
- [ ] GanttChart (grid de acompanhamento de projetos)


# ROADMAP 2

- [ ] Drag & Drop (deve ter uma área e item, onde eles se repetem e os itens podem ser movidos entre as áreas).
- [ ] VideoPlayer
- [ ] Camera
- [ ] Speech
- [x] Split (painel com linha divisória) — parcial: `Container`+`Slot` cobrem layout lado a lado, mas sem divisor arrastável
- [ ] GoTop (botão para mover o scroll para o topo [fixo na tela ou incorporado no documento])
- [ ] RibbonTab (tipo do word, várias abas, sessões e botões com um ícone grande e uma descrição)
- [ ] IpAddressField
- [ ] Captcha (Quebra cabeça tipo binance)
- [ ] ProgressCircle
- [ ] Geolocation (busca as coordenadas)
- [ ] SearchField (Campo/componente de busca/pesquisa, utilizado no topbar)
- [ ] Dispatch (Botão que envia uma requisição async e habilita uma notificação de progresso, enquanto uma animação de load é exibida no botão)
- [ ] PopConfirm (um dialog com uma mensagem de confirmação e botões, exibido como popup)
- [ ] Transfer (duas listas de itens, e pode se mover de uma lista para outra)
- [ ] Empty (componente que é exibido quando nenhuma informação/dados são encontrados)
- [ ] Result (visualiza o resultado de uma operação)

# ROADMAP 3

- [ ] Avatar e AvatarGroup (https://vaadin.com/docs/latest/ds/components/avatar)
- [ ] Board e BoardRow (layout) (https://vaadin.com/docs/latest/ds/components/board)
- [x] ConfirmDialog — parcial: `Modal`+`ModalHandler` cobrem a estrutura; falta template pronto de confirmação
- [ ] ResultDialog
- [ ] ContextMenu (componente que abre um menu tipo dropdown ao clicar com o botão direito)
- [ ] Details (https://vaadin.com/docs/latest/ds/components/details)
- [ ] MessageList (https://vaadin.com/docs/latest/ds/components/message-list)
- [ ] Scroller
- [ ] LoadPanel (abre um modal sobre os elementos internos mostrando um mini painel com spinner de loading)
- [ ] UserProfile (exibe o nome do usuário e um ícone ou avatar que é um dropdown tipo popup. Usado na TopBar.)
- [ ] Gauge (existem vários, desde várias barras agrupadas, barra única, ou com ponteiros)
- [ ] Windows (tipo um dialog, mas que pode se mover pela tela, maximizar, minimizar, alterar tamanho e fechar)

---

# MAPA DE COMPONENTES

> Inventário do que existe hoje na biblioteca RoyalCode.Razor (auditado em 15/03/2026).
> Organizado por pacote/projeto.

## RoyalCode.Razor.Commons
| Componente | Tipo | Descrição |
|---|---|---|
| `Ripple` | Componente | Efeito material ripple em botões |
| `TransitionState` | Classe | Gerencia fases CSS de transição (usado por Modal e Notifications) |
| `VisibleState` | Classe | Toggle de visibilidade assíncrono (usado por OffCanvas) |

## RoyalCode.Razor.Animations
| Componente | Tipo | Descrição |
|---|---|---|
| `RotateEffect` | Componente | Aplica rotação CSS estática via variável `--rotate-effect-deg` |
| `RotationMotion` | Componente | Animação de rotação contínua (spinner). Suporta `CounterClockwise` |
| `Effects` | Utilitário | Factory: `Effects.Rotate(degrees)` → `AnimationFragment` |
| `Motions` | Utilitário | Factory: `Motions.Rotation(clockwise)` → `AnimationFragment` |

## RoyalCode.Razor.Icons
| Componente | Tipo | Descrição |
|---|---|---|
| `Icon` | Componente | Renderiza SVG a partir de enum de ícone (via `IconContentFactories`) |
| `WellKnownIcons` | Utilitário | ~40 ícones semânticos (Home, Add, Edit, Close, Menu, etc.) |
| `IconContentFactories` | Infraestrutura | Registry de factories por tipo de enum |

## RoyalCode.Razor.Icons.Bootstrap
| Componente | Tipo | Descrição |
|---|---|---|
| `BsIconNames` | Enum | 1.000+ ícones Bootstrap Icons |
| `BootstrapIcons` | Config | `Include()` registra factory e mapeia `WellKnownIcons` |

## RoyalCode.Razor.Alerts
| Componente | Tipo | Descrição |
|---|---|---|
| `Badge` | Componente | Badge/chip colorida com ícone, texto ou slot |
| `Feedback` | Componente | **Alert** — caixa tematizada com ícone, título, texto e botão de fechar |
| `Notification` | Componente | **Toast** — notificação flutuante com timer, barra de progresso e auto-dismiss |
| `NotificationContent` | Componente | Slot rico para `Notification`: texto principal + detalhe |
| `Notify` | Serviço DI | API programática de notificações: `Success()`, `Danger()`, `Warning()`, etc. |

## RoyalCode.Razor.Buttons
| Componente | Tipo | Descrição |
|---|---|---|
| `Button` | Componente | Botão com label, ícone, tema, tamanho, outline, ripple e navegação |
| `IconButton` | Componente | Botão apenas com ícone (compacto), com ripple escuro |

## RoyalCode.Razor.Drops
| Componente | Tipo | Descrição |
|---|---|---|
| `DropButton` | Componente | **Dropdown** disparado por `Button`; menu de itens |
| `DropIconButton` | Componente | **Dropdown** disparado por `IconButton` |
| `DropItem` | Componente | Item individual dentro de um dropdown (li ou div) |

## RoyalCode.Razor.Breadcrumbs
| Componente | Tipo | Descrição |
|---|---|---|
| `Breadcrumb` | Componente | Nav > ol de breadcrumb com overflow em dropdown |
| `BreadcrumbItem` | Componente | Item individual (NavLink ou link com evento) |
| `DescribesBreadcrumbs` | Componente | Wrapper data-driven — atualiza via `NavigationManager` |

## RoyalCode.Razor.Forms
| Componente | Tipo | Descrição |
|---|---|---|
| `TextField` | Componente | Campo de texto (Text/Password) com label, addons, validação e tamanho |
| `FieldAction` | Componente | Botão estilizado para uso ao lado de campos de formulário |
| `FieldBadge` | Componente | Badge colorida para rotular campos ("Obrigatório", "Beta") |
| `FieldText` | Componente | Wrapper de texto descritivo dentro de input group |
| `InputFieldBase<T>` | Base interna | Base genérica para inputs: label, addons, validação, sizes |
| `FieldGroup` | Interno | Layout de campo: label + control + informação + erro |
| `ControlGroup` | Interno | Wrapper `ya-control-group` para agrupamento com addons |

## RoyalCode.Razor.Layouts
| Componente | Tipo | Descrição |
|---|---|---|
| `Bar` | Componente | Toolbar horizontal com slots Start/Middle/End |
| `Box` | Componente | Container com borda, padding e margin configuráveis |
| `Container` | Componente | Grid ou Flex responsivo; cascateia `ContainerContext` |
| `Slot` | Componente | Coluna responsiva dentro de `Container` (spans por breakpoint) |
| `Stack` | Componente | Coluna vertical flex (`flex-col w-100`) |

## RoyalCode.Razor.Layouts.Apps
| Componente | Tipo | Descrição |
|---|---|---|
| `AppLayout` | Componente | **Shell completo**: header, sidebar esquerda/direita, main, footer |
| `AppMainLayout` | Componente | Layout simplificado (sem sidebar) para páginas internas |
| `AppTopBar` | Componente | Barra superior fixa com slots Start/Center/End |
| `AppSideBar` | Componente | `<aside>` lateral com largura configurável (Start ou End) |
| `AppSideItem` | Componente | Item individual da sidebar vertical de ícones |
| `AppSideMenuButton` | Componente | Botão hamburger que abre o `AppMenu` via `OffCanvas` |
| `AppMenu` | Componente | Painel de navegação (OffCanvas Start) com busca e breadcrumb |
| `AppMenuList` | Componente | Lista de itens do nível de menu atual |
| `AppMenuItem` | Componente | Item de menu: link, módulo (drill-down) ou divisor |

## RoyalCode.Razor.Modals
| Componente | Tipo | Descrição |
|---|---|---|
| `Modal` | Componente | **Dialog/Modal** com transições CSS, overlay e cascata de contexto |
| `ModalHandler` | Classe | API de controle: `OpenAsync()`, `CloseAsync()`, event listeners |

## RoyalCode.Razor.OffCanvas
| Componente | Tipo | Descrição |
|---|---|---|
| `OffCanvas` | Componente | **Painel deslizante** (Start/End), com backdrop, fitting e `VisibleState` |
| `AsideBox` | Componente | Frame de conteúdo dentro do OffCanvas: título + header + body |
| `CloseOffCanvasButton` | Componente | Botão `×` que fecha o `OffCanvas` via `OffCanvasHandler` |

