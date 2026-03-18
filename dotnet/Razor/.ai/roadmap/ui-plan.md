# Plano de Desenvolvimento — RoyalCode.Razor

> Gerado em 15/03/2026.
> Relaciona os componentes do Roadmap com os UI Patterns do Catálogo Global (`catalogo-ui.md`).
> Prioridade guiada pelos gaps de cobertura identificados no ui-map.md.

---

## Critérios de Prioridade

| Prioridade | Critério |
|---|---|
| **P1 — Crítico** | Padrão do catálogo com nota 0 e alta frequência de uso em apps reais |
| **P2 — Alto** | Padrão com nota <= 4 ou componente que desbloqueia múltiplos outros |
| **P3 — Médio** | Componente de roadmap sem cobertura de catálogo, mas de uso comum |
| **P4 — Baixo** | Componentes avançados / nicho, sem impacto em padrões core |

---

## Fase 1 — Fundações de Dados, Busca e Navegação

> Itens ausentes que bloqueiam a maioria dos cenários reais de aplicação e destravam listagens, fluxos e shells básicos.

### F1.1 — Tabs
**Roadmap:** R1 › Componentes Diversos › `Tabs`
**Cobre:** `UIP-NAV-TABS` (nota atual: 0/10)
**P1**

Componentes a criar:
- `Tabs` — container com barra de tabs e slot de conteúdo ativo
- `Tab` — item individual com `Title`, `Disabled`, `Badge` e `ChildContent`
- Parâmetros: `ActiveTab`, `OnTabChanged`, direção (horizontal/vertical), tema

Comportamento essencial:
- Tab ativa controlada por estado externo ou interno
- Suporte a badge/contagem por tab individual
- Scroll lateral em Mobile quando tabs excedem a largura

Dependência de: `Button`, `Badge` (já existem), CSS `ya-tabs`

---

### F1.2 — Pagination
**Roadmap:** R1 › Componentes Diversos › `Pagination`
**Cobre:** `UIP-NAV-PAGINATION` (nota atual: 0/10)
**P1**

Componente a criar:
- `Pagination` — barra com botões de navegação e indicador de página

Parâmetros: `CurrentPage`, `TotalPages`, `PageSize`, `OnPageChanged`, `Loading`

Comportamento essencial:
- Desktop: botões anterior/próxima + páginas numeradas (máx. 7 visíveis) + primeira/última
- Mobile: simplificado — anterior, indicador "X de Y", próxima
- Botões desativados durante loading e nos extremos

Dependência de: `Button`, `IconButton` (já existem)

---

### F1.3 — Empty State
**Roadmap:** R2 › `Empty`
**Cobre:** `UIP-FEEDBACK-EMPTY_STATE` (nota atual: 4/10 — melhoria)
**P1**

Componente a criar:
- `EmptyState` — área centrada com ícone/ilustração, título, subtítulo e CTA opcional

Parâmetros: `Icon`, `Title`, `Subtitle`, `ActionLabel`, `OnAction`, `ChildContent` (slot para CTA customizado)

Variantes:
- `Variant="EmptyVariant.NoData"` — sem dados, com CTA de criação
- `Variant="EmptyVariant.NoResults"` — sem resultados para busca/filtro ativo
- `Variant="EmptyVariant.NoPermission"` — sem permissão de acesso

Dependência de: `Icon`, `Button` (já existem)

---

### F1.4 — Placeholder / Skeleton
**Roadmap:** R1 › Componentes Diversos › `Placeholders`
**Cobre:** `UIP-FEEDBACK-LOADING_STATE` (nota atual: 3/10 — melhoria)
**P1**

Componentes a criar:
- `Skeleton` — bloco animado de placeholder com largura/altura/forma configuráveis
- `SkeletonText` — linha(s) de texto em skeleton (1–N linhas)
- `SkeletonCard` — card completo em skeleton (imagem + título + linhas)
- `SkeletonTable` — tabela em skeleton (N linhas × M colunas)

Parâmetros do `Skeleton`: `Width`, `Height`, `Rounded`, `Lines`, `AdditionalClasses`

Nota: `RotationMotion` (spinner) permanece para casos pontuais; skeleton é preferido para conteúdo de área.

---

### F1.5 — SearchField
**Roadmap:** R2 › `SearchField`
**Cobre:** `UIP-INPUT-SEARCH_BAR` (nota atual: 1/10 → ~8)
**P1**

Componente a criar:
- `SearchField` — campo de busca com ícone, botão de limpar, debounce e sugestões dropdown opcionais

Parâmetros: `Value`, `OnSearch`, `Placeholder`, `DebounceMs`, `Suggestions`, `OnSuggestionSelected`, `SearchOnEnter`, `SearchOnInput`

Comportamento essencial:
- Busca por Enter, por digitação ou por ambos
- Botão de limpar quando houver valor
- Debounce configurável para toolbars e listagens
- Modo compacto para barras de ação e cabeçalhos de listagem
- Estrutura pronta para fechar o gap de busca no `AppMenu`

Dependência de: `Icon`, `Button` e infraestrutura de campo já existente

---

### F1.6 — ScrollRegion
**Roadmap:** — (gap do catálogo)
**Cobre:** `UIP-STRUCT-SCROLLABLE_REGION` (nota atual: 2/10 → ~7)
**P2**

Componente a criar:
- `ScrollRegion` — wrapper com scroll independente, dimensões controladas e estados auxiliares de loading/fim

Parâmetros: `MaxHeight`, `MaxWidth`, `Orientation`, `Loading`, `ReachedEnd`, `ChildContent`

Comportamento essencial:
- Scroll independente do restante da página
- Suporte a eixo vertical e horizontal
- Classe raiz `ya-scroll-region`
- Hooks visuais para loading e fim de conteúdo sem impor lazy loading interno

Dependência de: CSS `ya-scroll-region`

---

### F1.7 — Steps / Stepper
**Roadmap:** R1 › Componentes Diversos › `Steps`
**Cobre:** `UIP-NAV-STEPPER_INDICATOR` (nota atual: 0/10)
**P2**

Componentes a criar:
- `Steps` — container do indicador de progresso multi-etapas
- `Step` — etapa individual com `Title`, `Description`, `Status`

Parâmetros do `Steps`: `Current`, `Direction` (horizontal/vertical), `OnStepClick`
Status por etapa: `Pending` / `InProgress` / `Complete` / `Error` / `Disabled`

Mobile: exibe "Passo X de Y" compacto com nome da etapa atual.

---
## Fase 2 — Expansão de Inputs Concretos

> A infraestrutura base de formulários já existe (`FieldGroup`, `ControlGroup`, `InputFieldBase<TValue>` e `TextField`); esta fase amplia o catálogo de campos concretos e variações de layout.

### F2.1 — NumberField
**Roadmap:** R1 › Forms › `NumberField`
**Cobre:** `UIP-INPUT-FORM_FIELD_GROUP` (melhoria)
**P1**

Componente a criar:
- `NumberField<TValue>` onde `TValue` : `INumber<TValue>` (`int`, `decimal`, `double`…)

Parâmetros adicionais: `Min`, `Max`, `Step`, `Format` (string de formato C#), `ShowSpinner` (botões +/-)

---

### F2.2 — TextArea
**Roadmap:** R1 › Forms › `TextArea`
**Cobre:** `UIP-INPUT-FORM_FIELD_GROUP`
**P1**

Componente a criar:
- `TextAreaField` — `<textarea>` com label, validação, addons e resize controlado

Parâmetros: `Rows`, `MaxLength`, `Resize` (`none`/`vertical`/`auto`), `Placeholder`, `ReadOnly`

---

### F2.3 — Select / SelectField
**Roadmap:** R1 › Forms › `Select`
**Cobre:** `UIP-INPUT-FORM_FIELD_GROUP`
**P1**

Componentes a criar:
- `SelectField<TValue>` — `<select>` nativo com label e validação
- `SelectOption` — item de opção (`<option>`)

Parâmetros: `Items`, `ValueField`, `TextField`, `Multiple`, `Placeholder`

---

### F2.4 — CheckBox e CheckBoxGroup
**Roadmap:** R1 › Forms › `CheckBox`
**Cobre:** `UIP-INPUT-FORM_FIELD_GROUP`
**P1**

Componentes a criar:
- `CheckBoxField` — checkbox `bool` com label inline
- `CheckBoxGroup<TValue>` — grupo de checkboxes que acumula valores em lista

---

### F2.5 — RadioBox e RadioGroup
**Roadmap:** R1 › Forms › `RadioBox / RadioGroup`
**Cobre:** `UIP-INPUT-FORM_FIELD_GROUP`
**P2**

Componentes a criar:
- `RadioField<TValue>` — radio individual
- `RadioGroup<TValue>` — grupo que gerencia seleção exclusiva

Parâmetros do grupo: `Items`, `ValueField`, `TextField`, `Orientation` (horizontal/vertical)

---

### F2.6 — Switch (Toggle)
**Roadmap:** R1 › Forms Adicionais › `Switch`
**Cobre:** `UIP-INPUT-FORM_FIELD_GROUP`
**P2**

Componente a criar:
- `SwitchField` — toggle on/off com label e estado ativado/desativado

---

### F2.7 — DatePicker
**Roadmap:** R1 › Forms › `DatePicker`
**Cobre:** `UIP-INPUT-DATE_PICKER` (nota atual: 0/10)
**P2**

Componentes a criar:
- `DateField` — data simples com calendário dropdown
- `DateTimeField` — data + hora
- `DateRangeField` — intervalo de datas (data início / data fim)

Comportamento: calendário em dropdown no Desktop, modal no Mobile, navegação por mês/ano e datas desativadas por callback `IsDisabled(DateTime)`.

Dependência de: `Modal` ou lógica de dropdown própria.

---

### F2.8 — Compact / Inline Label
**Roadmap:** R1 › Melhorias
**Cobre:** `UIP-INPUT-FORM_FIELD_GROUP`
**P3**

Melhoria em `FieldGroup`:
- Parâmetro `LabelVariant: FieldLabelVariant` — `Default` (acima do campo) | `Compact` (label flutua sobre a borda do input, estilo Material/Bootstrap floating label) | `Inline` (label à esquerda do campo)

---
## Fase 3 — Conteúdo e Apresentação

### F3.1 — Card
**Roadmap:** R1 › Componentes Diversos › `Card`
**Cobre:** `UIP-DATA-CARD_GRID` (melhoria de nota 5 → 8)
**P2**

Componentes a criar:
- `Card` — container com header, body, footer e imagem opcional
- `CardHeader` — slot de cabeçalho (título + subtítulo + ação)
- `CardFooter` — slot de rodapé

Parâmetros do `Card`: `ImageSrc`, `ImageAlt`, `Hoverable`, `Selectable`, `Selected`, `OnClick`

Nota: `Box` não tem estado `Hoverable`, `Selectable` nem imagem — `Card` será o componente semântico dedicado.

---

### F3.2 — ListGroup / ListItem
**Roadmap:** R1 › Componentes Diversos › `ListGroup`
**Cobre:** `UIP-DATA-LIST_ITEM` (nota atual: 2/10 → ~7)
**P2**

Componentes a criar:
- `ListGroup` — container de lista com divisores automáticos
- `ListItem` — item com ícone/avatar, título, subtítulo, badge e ação contextual

Parâmetros do `ListItem`: `Icon`, `Title`, `Subtitle`, `Metadata`, `Selected`, `Disabled`, `OnClick`, `Actions` (slot)

---

### F3.3 — Panel
**Roadmap:** R1 › Componentes Diversos › `Panel`
**Cobre:** uso interno como zona colapsável
**P3**

Componente a criar:
- `Panel` — container com cabeçalho clicável (`Collapsible`), corpo e rodapé opcionais

Parâmetros: `Title`, `Collapsible`, `IsOpen`, `OnToggle`, `HeaderActions` (slot)

---

### F3.4 — Accordion / Collapse
**Roadmap:** R1 › Componentes Diversos › `Accordion`, `Collapse`
**Cobre:** uso de detalhe expansível em `UIP-CONTENT-DETAIL_BLOCK`
**P3**

Componentes a criar:
- `Accordion` — grupo de `Panel` onde apenas um pode estar aberto
- `Collapse` — bloco expansível simples

---

### F3.5 — DetailBlock
**Roadmap:** — (gap do catálogo)
**Cobre:** `UIP-CONTENT-DETAIL_BLOCK` (nota atual: 3/10 → ~8)
**P2**

Componentes a criar:
- `DetailBlock` — bloco semântico para exibir grupos de atributos
- `DetailRow` — linha responsiva de `rótulo + valor`
- `DetailGroup` — agrupador opcional para subseções com divisor

Parâmetros do `DetailBlock`: `Title`, `Subtitle`, `Loading`, `Columns`, `Actions`, `ChildContent`
Parâmetros do `DetailRow`: `Label`, `Value`, `LabelWidth`, `StackOnMobile`

Dependência de: `SkeletonText` (F1.4) para estado de carregamento.

---

### F3.6 — MetricCard
**Roadmap:** — (gap do catálogo)
**Cobre:** `UIP-CONTENT-METRIC_CARD` (nota atual: 2/10 → ~8)
**P3**

Componentes a criar:
- `MetricCard` — cartão de métrica com valor, variação e período
- `MetricTrend` — região auxiliar para tendência, comparação e sparkline opcional

Parâmetros: `Title`, `Value`, `Variation`, `VariationTheme`, `Period`, `Icon`, `Loading`, `ChildContent`

Dependência de: `Badge`, `Icon` e `Skeleton`.

---

### F3.7 — Timeline
**Roadmap:** R1 › Componentes Diversos › `Timeline`
**Cobre:** `UIP-DATA-TIMELINE_ITEM` (nota atual: 0/10)
**P3**

Componentes a criar:
- `Timeline` — container de feed cronológico
- `TimelineItem` — entrada com indicador temporal, ícone, conteúdo e ação

Parâmetros: `OccurredAt`, `Icon`, `Theme` (`Success`/`Danger`/`Info`), `IsNew`, `Expandable`

---
## Fase 4 — Dados Complexos

### F4.1 — DataGrid
**Roadmap:** R1 › Complexos › `DataGrid`
**Cobre:** `UIP-DATA-DATA_TABLE` (nota atual: 0/10)
**P1**

Componentes a criar (progressivo — do simples ao complexo):

**DataGrid básico:**
- `DataGrid<TItem>` — tabela com colunas declarativas, paginação e loading
- `DataGridColumn<TItem>` — coluna com `Field`, `Header`, `Sortable`, `Width`

**DataGrid intermediário:**
- `DataGridActionColumn` — coluna de ações com `DropIconButton`
- `DataGridSelectColumn` — coluna de checkbox para seleção
- `DataGridActionBar` — barra de ações acima integrada à seleção múltipla

**DataGrid avançado:**
- `DataGridFilterRow` — linha de filtro inline abaixo do cabeçalho
- `DataGridExpandRow<TDetail>` — linha expansível com template de detalhe
- `DataGridEditableColumn` — célula editável inline

Dependência de: `Pagination` (F1.2), `EmptyState` (F1.3), `Skeleton`/`SkeletonTable` (F1.4), `DropIconButton` (já existe), `CheckBoxField` (F2.4)

---

### F4.2 — Kanban
**Roadmap:** R1 › Complexos › `Kanban`
**Cobre:** `UIP-DATA-KANBAN_COLUMN` (nota atual: 0/10)
**P4**

Componentes a criar:
- `KanbanBoard` — container horizontal com scroll
- `KanbanColumn` — coluna com cabeçalho, contagem e itens arrastáveis
- `KanbanCard` — card arrastável com título e metadados

Dependência de: suporte a Drag & Drop (R2) — **este componente deve aguardar a fase de DnD**.

---

## Fase 5 — Interações Avançadas

### F5.1 — Tooltip
**Roadmap:** R1 › Componentes Diversos › `Tooltip`
**Cobre:** uso auxiliar em qualquer padrão
**P2**

Componente a criar:
- `Tooltip` — popup de texto ao hover/focus em qualquer elemento filho

Parâmetros: `Text`, `Position` (`Top`/`Bottom`/`Start`/`End`), `Delay`, `ChildContent`

---

### F5.2 — Popover
**Roadmap:** R1 › Componentes Diversos › `Popover`
**Cobre:** uso auxiliar em `UIP-INPUT-FILTER_PANEL` e Detail
**P3**

Componente a criar:
- `Popover` — painel flutuante posicionado relativamente ao trigger, com `ChildContent` livre

Diferença do `Tooltip`: tem conteúdo rico (não só texto), persiste até fechar.

---

### F5.3 — PopConfirm
**Roadmap:** R2 › `PopConfirm`
**Cobre:** confirmações leves sem modal completo (alternativa ao `UIP-FEEDBACK-CONFIRMATION_DIALOG`)
**P2**

Componente a criar:
- `PopConfirm` — popover com mensagem, botão confirmar e cancelar

Parâmetros: `Title`, `Message`, `ConfirmLabel`, `CancelLabel`, `OnConfirm`, `OnCancel`, `Theme` (`Danger` para ações destrutivas)

Dependência de: `Popover` (F5.2) ou infraestrutura do `DropBase`.

---

### F5.4 — ConfirmDialog
**Roadmap:** R3 › `ConfirmDialog`
**Cobre:** `UIP-FEEDBACK-CONFIRMATION_DIALOG` (melhoria de nota 7 → 9)
**P2**

Componente a criar:
- `ConfirmDialog` — template de `Modal` específico para confirmação com props de alto nível

Parâmetros: `Title`, `Message`, `ConfirmLabel`, `ConfirmStyle` (default `Danger`), `CancelLabel`, `OnConfirm`, `OnCancel`, `Handler`

---

### F5.5 — DispatchButton
**Roadmap:** R2 › `Dispatch`
**Cobre:** padrão de ação assíncrona com feedback visual no botão
**P2**

Componente a criar:
- `DispatchButton` — `Button` + spinner + notificação automática de resultado

Parâmetros: `Label`, `OnDispatch` (`Func<Task>`), `SuccessMessage`, `ErrorMessage`, `LoadingLabel`

Dependência de: `Button`, `RotationMotion` e `Notify` (todos já existem)

---

### F5.6 — FloatingActionButton
**Roadmap:** — (gap do catálogo)
**Cobre:** `UIP-ACTION-FLOATING_ACTION` (nota atual: 3/10 → ~8)
**P3**

Componentes a criar:
- `FloatingActionButton` — botão de ação flutuante com posicionamento fixo e variante circular
- `FloatingActionGroup` — agrupador opcional para ação principal + ações secundárias

Parâmetros: `Icon`, `Label`, `Position`, `Visible`, `Loading`, `Expanded`, `OnClick`

Comportamento:
- Tamanho mínimo adequado para Mobile
- Posição fixa configurável
- Suporte a modo ícone e modo expandido com label
- Visibilidade condicionada a estado e permissão externa

---

### F5.7 — FilterPanel
**Roadmap:** R1 › Componentes Diversos (implícito no catálogo)
**Cobre:** `UIP-INPUT-FILTER_PANEL` (nota atual: 4/10 → ~7)
**P3**

Componentes a criar:
- `FilterPanel` — container inteligente para filtros com estado "ativos" e botão "limpar todos"
- `FilterIndicator` — badge que indica quantos filtros estão ativos (para o botão do painel mobile)

Comportamento:
- Desktop: painel lateral visível
- Mobile: usa `OffCanvas` (já existe) como gaveta; `FilterIndicator` aparece no botão de abertura

---
## Fase 6 — Layout e Shell Avançados

### F6.1 — Split (painel dividido com divisor arrastável)
**Roadmap:** R2 › `Split`
**Cobre:** `UIP-STRUCT-SPLIT_PANEL` (nota atual: 4/10 → ~8)
**P3**

Componentes a criar:
- `SplitPanel` — dois painéis com divisor arrastável
- `SplitPaneStart` / `SplitPaneEnd` — slots dos dois painéis

Parâmetros: `InitialSize` (% ou px), `MinSize`, `MaxSize`, `Direction` (horizontal/vertical), `Resizable`

Mobile: painéis alternam (apenas um visível); tab de navegação entre painéis.

---

### F6.2 — GoTop
**Roadmap:** R2 › `GoTop`
**Cobre:** UX de navegação longa
**P4**

Componente a criar:
- `GoTop` — botão fixo que aparece quando scroll > threshold e volta ao topo

Parâmetros: `Threshold`, `Smooth`, `Position` (Start/End), `Fixed`

---

### F6.3 — UserProfile
**Roadmap:** R3 › `UserProfile`
**Cobre:** elemento do AppTopBar
**P3**

Componente a criar:
- `UserProfile` — avatar ou ícone + nome abreviado + dropdown de perfil/logout

Parâmetros: `Name`, `AvatarSrc`, `AvatarInitials`, `ChildContent` (itens do dropdown)

Dependência de: `DropButton` ou `DropIconButton` (já existem), `Avatar` (R3 — pode vir antes)

---

### F6.4 — Avatar e AvatarGroup
**Roadmap:** R3 › `Avatar e AvatarGroup`
**Cobre:** uso em ListItem, UserProfile, Timeline
**P3**

Componentes a criar:
- `Avatar` — ícone de usuário com imagem, iniciais ou ícone padrão; variantes de tamanho/tema
- `AvatarGroup` — grupo empilhado de avatares com "+N" quando excede max

---

### F6.5 — DashboardLayout
**Roadmap:** R1 › Peculiares › `DashboardLayout`
**Cobre:** `UIP-STRUCT-GRID_CONTAINER` para dashboards com widgets reposicionáveis
**P4**

Componente a criar:
- `DashboardLayout` — grid configurável com widgets de tamanho variável
- `DashboardWidget` — slot de widget com título, ações de cabeçalho e conteúdo

Nota: complexidade alta; pode integrar Drag & Drop (R2) para reposicionamento.

---

## Fase 7 — Componentes Complexos

### F7.1 — DataGrid avançado (continuação de F4.1)
Ver F4.1 — fase avançada.

### F7.2 — Kanban (após DnD)
Ver F4.2.

### F7.3 — TreeSelect / CheckTree / Tree
**Roadmap:** R1 › Peculiares + Componentes Diversos
**Cobre:** casos de seleção hierárquica
**P4**

Componentes a criar:
- `Tree` — exibição de estrutura hierárquica expansível com ícones de nó
- `TreeSelect` — campo que abre `Tree` em dropdown para seleção
- `CheckTree` — árvore com checkboxes para seleção múltipla

---

### F7.4 — Agenda (Calendar)
**Roadmap:** R1 › Complexos
**P4**

### F7.5 — Charts
**Roadmap:** R1 › Complexos
**P4** — recomendado integrar biblioteca de terceiros (ex.: ApexCharts.Blazor, ChartJs.Blazor).

### F7.6 — BarCode / QRCode
**Roadmap:** R1 › Complexos
**P4** — recomendado integrar biblioteca de geração SVG ou usar `IJSRuntime` com lib JS.

---

## Resumo de Prioridades

| Fase | Item | Roadmap | Padrão Coberto | Prioridade |
|---|---|---|---|---|
| F1.1 | Tabs | R1 | UIP-NAV-TABS | P1 |
| F1.2 | Pagination | R1 | UIP-NAV-PAGINATION | P1 |
| F1.3 | EmptyState | R2 | UIP-FEEDBACK-EMPTY_STATE | P1 |
| F1.4 | Skeleton | R1 | UIP-FEEDBACK-LOADING_STATE | P1 |
| F1.5 | SearchField | R2 | UIP-INPUT-SEARCH_BAR | P1 |
| F1.6 | ScrollRegion | — | UIP-STRUCT-SCROLLABLE_REGION | P2 |
| F1.7 | Steps | R1 | UIP-NAV-STEPPER_INDICATOR | P2 |
| F2.1 | NumberField | R1 | UIP-INPUT-FORM_FIELD_GROUP | P1 |
| F2.2 | TextArea | R1 | UIP-INPUT-FORM_FIELD_GROUP | P1 |
| F2.3 | Select | R1 | UIP-INPUT-FORM_FIELD_GROUP | P1 |
| F2.4 | CheckBox / Group | R1 | UIP-INPUT-FORM_FIELD_GROUP | P1 |
| F2.5 | RadioBox / Group | R1 | UIP-INPUT-FORM_FIELD_GROUP | P2 |
| F2.6 | Switch | R1 | UIP-INPUT-FORM_FIELD_GROUP | P2 |
| F2.7 | DatePicker | R1 | UIP-INPUT-DATE_PICKER | P2 |
| F2.8 | Compact Label | R1 | UIP-INPUT-FORM_FIELD_GROUP | P3 |
| F3.1 | Card | R1 | UIP-DATA-CARD_GRID | P2 |
| F3.2 | ListGroup / ListItem | R1 | UIP-DATA-LIST_ITEM | P2 |
| F3.3 | Panel | R1 | — | P3 |
| F3.4 | Accordion / Collapse | R1 | — | P3 |
| F3.5 | DetailBlock | — | UIP-CONTENT-DETAIL_BLOCK | P2 |
| F3.6 | MetricCard | — | UIP-CONTENT-METRIC_CARD | P3 |
| F3.7 | Timeline | R1 | UIP-DATA-TIMELINE_ITEM | P3 |
| F4.1 | DataGrid | R1 | UIP-DATA-DATA_TABLE | P1 |
| F4.2 | Kanban | R1 | UIP-DATA-KANBAN_COLUMN | P4 |
| F5.1 | Tooltip | R1 | — | P2 |
| F5.2 | Popover | R1 | — | P3 |
| F5.3 | PopConfirm | R2 | UIP-FEEDBACK-CONFIRMATION_DIALOG | P2 |
| F5.4 | ConfirmDialog | R3 | UIP-FEEDBACK-CONFIRMATION_DIALOG | P2 |
| F5.5 | DispatchButton | R2 | — | P2 |
| F5.6 | FloatingActionButton | — | UIP-ACTION-FLOATING_ACTION | P3 |
| F5.7 | FilterPanel | — | UIP-INPUT-FILTER_PANEL | P3 |
| F6.1 | SplitPanel | R2 | UIP-STRUCT-SPLIT_PANEL | P3 |
| F6.2 | GoTop | R2 | — | P4 |
| F6.3 | UserProfile | R3 | — | P3 |
| F6.4 | Avatar / AvatarGroup | R3 | — | P3 |
| F6.5 | DashboardLayout | R1 | UIP-STRUCT-GRID_CONTAINER | P4 |
| F7.x | Tree, Agenda, Charts… | R1/R3 | — | P4 |

---
## Gaps de Catálogo Sem Plano Ainda

> Os gaps abaixo permanecem fora das fases principais e podem virar backlog dedicado depois que as frentes P1/P2 estiverem estabilizadas.

| ID_UI_PATTERN | Gap | Nota Atual | Ação Sugerida |
|---|---|:---:|---|
| `UIP-CONTENT-RICH_TEXT_BLOCK` | Apenas `MarkupString` | 1 | Criar `RichTextBlock` com tipografia editorial e `prose` aplicado |
| `UIP-CONTENT-MEDIA_VIEWER` | Ausente | 0 | Criar `MediaViewer` para imagem/vídeo/documento — ou integrar biblioteca de terceiros |

