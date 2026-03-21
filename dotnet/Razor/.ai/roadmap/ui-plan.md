# Plano de Desenvolvimento de UI — RoyalCode.Razor

> Atualizado em 21/03/2026.
> Fonte de verdade da cobertura atual: `ui-map.md`.
> Fonte de backlog histórico: `components-plan-list.md`.
> Referência canônica de catálogo: `catalogo_ui_2.md`.

---

## Como ler este plano

- O [`.ai/ui-map/ui-map.md`](../ui-map/ui-map.md) define a nota atual e o gap real de cada `ID_UI_PATTERN`.
- O [`.ai/roadmap/components-plan-list.md`](./components-plan-list.md) continua sendo o inventário histórico dos componentes e da origem no roadmap (`R1`, `R2`, `R3`).
- Quando houver divergência entre backlog histórico e auditoria atual, prevalece o `ui-map.md`.
- Este plano prioriza o que fecha lacunas transversais do catálogo e destrava `Page Patterns` frequentes: `PP-LIST`, `PP-DETAIL`, `PP-FORM`, `PP-WIZARD`, `PP-DASHBOARD`.
- `Shell Patterns` e casos de nicho (`Studio/Workbench`, `Board`, `Calendar`, `Map`, `Canvas`) entram depois das fundações de navegação, dados, formulário e feedback.

---

## Itens já cobertos ou fora do backlog ativo

| Item | Origem | Cobertura Atual | Decisão |
|---|---|---|---|
| `Pagination` | `R1` | `UIP-NAV-PAGINATION` = **10/10** | Sai do backlog de criação. Mantém apenas melhorias incrementais. |
| `Toast / Alert` | `R1` | `UIP-FEEDBACK-TOAST_ALERT` = **10/10** | Sem frente estrutural nova. |
| `Breadcrumb` | `R1` | `UIP-NAV-BREADCRUMB` = **8/10** | Não é prioridade de componente novo; sobra apenas ajuste semântico fino. |
| Infra de formulário | `R1` | `UIP-INPUT-FORM_FIELD_GROUP` = **8/10** | A base existe; o backlog agora é de campos concretos, não de infraestrutura. |
| `Confirmation Dialog` | `R3` | `UIP-FEEDBACK-CONFIRMATION_DIALOG` = **7/10** | O backlog não é criar modal do zero; é entregar `ConfirmDialog` como template de alto nível. |
| `Action Bar` / menu contextual | `R1` | `UIP-ACTION-ACTION_BAR` = **7/10** e `UIP-ACTION-CONTEXTUAL_MENU` = **9/10** | Sem urgência estrutural; melhorias ficam depois dos gaps críticos. |

---

## Critérios de prioridade

| Prioridade | Critério |
|---|---|
| **P1 — Crítico** | Gap `0–1` no `ui-map` e alta frequência de uso; destrava múltiplos fluxos reais |
| **P2 — Alto** | Gap `2–4` ou peça de apoio direta para um `P1` |
| **P3 — Médio** | Gap `5–6`, melhoria semântica importante ou complemento de shell/layout |
| **P4 — Baixo** | Casos avançados, nicho ou dependentes de infraestrutura futura |

---

## Fase 1 — Fechar gaps críticos transversais

> Objetivo: tornar a biblioteca suficiente para `PP-LIST`, `PP-FORM`, `PP-DETAIL` e `PP-WIZARD` sem composição excessiva.

### F1.1 — Skeleton / Placeholders

**Roadmap:** `R1` › Componentes Diversos › `Placeholders`
**Cobre:** `UIP-FEEDBACK-LOADING_STATE` (`3/10`)
**Prioridade:** `P1`

Entregas mínimas:
- `Skeleton`
- `SkeletonText`
- `SkeletonCard`
- `SkeletonTable`

Motivo:
- `Loading State` ainda é fraco na auditoria.
- `DataGrid`, `DetailBlock`, `Card` e dashboards dependem disso para UX consistente.

---

### F1.2 — EmptyState

**Roadmap:** `R2` › `Empty`
**Cobre:** `UIP-FEEDBACK-EMPTY_STATE` (`5/10`)
**Prioridade:** `P1`

Entregas mínimas:
- `EmptyState`
- variantes `NoData`, `NoResults`, `NoPermission`
- CTA opcional e slot livre

Motivo:
- O `Feedback` atual cobre parte do padrão, mas não a semântica de vazio.
- Fecha lacuna recorrente em listas, grids, detalhes vazios e busca sem resultado.

---

### F1.3 — SearchField

**Roadmap:** `R2` › `SearchField`
**Cobre:** `UIP-INPUT-SEARCH_BAR` (`1/10`)
**Prioridade:** `P1`

Entregas mínimas:
- `SearchField`
- debounce configurável
- limpar valor
- busca por Enter, input ou ambos
- sugestões opcionais
- modo compacto para toolbar e topbar

Motivo:
- Gap crítico em `PP-LIST`, `PP-CATALOG`, `Navigation Menu` e toolbars.
- O próprio `AppMenu` já sugere uma busca interna ainda não formalizada.

---

### F1.4 — Tabs

**Roadmap:** `R1` › Componentes Diversos › `Tabs`
**Cobre:** `UIP-NAV-TABS` (`0/10`)
**Prioridade:** `P1`

Entregas mínimas:
- `Tabs`
- `Tab`
- estado controlado e não controlado
- badge por aba
- orientação horizontal e vertical
- overflow lateral em Mobile

Motivo:
- É um dos gaps de navegação mais claros do catálogo.
- Destrava subpáginas, páginas de detalhe com secções e layouts tipo workspace leve.

---

### F1.5 — Campos concretos essenciais de formulário

**Roadmap:** `R1` › Forms
**Cobre:** expansão de `UIP-INPUT-FORM_FIELD_GROUP` (`8/10`)
**Prioridade:** `P1`

Entregas mínimas:
- `NumberField<TValue>`
- `TextAreaField`
- `SelectField<TValue>`
- `CheckBoxField`
- `CheckBoxGroup<TValue>`

Motivo:
- A infraestrutura já existe e está madura.
- O maior gap operacional de formulários hoje não é layout, é ausência de controles concretos.

Dependências:
- reutilizar `InputFieldBase<TValue>`, `FieldGroup`, `ControlGroup`, `FieldError`.

---

### F1.6 — DatePicker

**Roadmap:** `R1` › Forms › `DatePicker`
**Cobre:** `UIP-INPUT-DATE_PICKER` (`0/10`)
**Prioridade:** `P1`

Entregas mínimas:
- `DateField`
- `DateTimeField`
- `DateRangeField`

Motivo:
- Gap total em um padrão muito frequente.
- Necessário para filtros, formulários de negócio, dashboards e períodos.

Observação:
- `Desktop`: dropdown/calendário.
- `Mobile`: modal ou painel dedicado.

---

### F1.7 — DataGrid

**Roadmap:** `R1` › Complexos › `DataGrid`
**Cobre:** `UIP-DATA-DATA_TABLE` (`0/10`)
**Prioridade:** `P1`

Entregas mínimas:
- `DataGrid<TItem>`
- `DataGridColumn<TItem>`
- paginação integrada com o `Pagination` existente
- estados `loading`, `empty`, `error`
- coluna de ações
- coluna de seleção

Entregas seguintes:
- `DataGridActionBar`
- filtros inline
- linha expansível
- edição inline

Motivo:
- É o maior gap funcional do catálogo.
- Sozinho, destrava grande parte de `PP-LIST`, `PP-CATALOG`, `PP-DASHBOARD` e `PP-SPLIT_VIEW`.

Dependências:
- `Pagination` já existe.
- Depende de `Skeleton`, `EmptyState` e `CheckBoxField`.

---

## Fase 2 — Elevar cobertura para fluxos de trabalho completos

> Objetivo: reduzir composição manual em páginas operacionais, wizards e detalhes.

### F2.1 — Steps / Stepper

**Roadmap:** `R1` › Componentes Diversos › `Steps`
**Cobre:** `UIP-NAV-STEPPER_INDICATOR` (`0/10`)
**Prioridade:** `P2`

Entregas:
- `Steps`
- `Step`
- estados `Pending`, `InProgress`, `Complete`, `Error`, `Disabled`
- modo compacto Mobile

---

### F2.2 — ScrollRegion

**Roadmap:** gap do catálogo
**Cobre:** `UIP-STRUCT-SCROLLABLE_REGION` (`2/10`)
**Prioridade:** `P2`

Entregas:
- `ScrollRegion`
- orientação vertical e horizontal
- altura e largura máximas
- estados auxiliares de loading/fim

---

### F2.3 — ListGroup / ListItem

**Roadmap:** `R1` › Componentes Diversos › `ListGroup`
**Cobre:** `UIP-DATA-LIST_ITEM` (`2/10`)
**Prioridade:** `P2`

Entregas:
- `ListGroup`
- `ListItem`
- ícone ou avatar
- título, subtítulo, metadados, badge e ações
- estados `selected` e `disabled`

---

### F2.4 — Card

**Roadmap:** `R1` › Componentes Diversos › `Card`
**Cobre:** `UIP-DATA-CARD_GRID` (`5/10`)
**Prioridade:** `P2`

Entregas:
- `Card`
- `CardHeader`
- `CardFooter`
- imagem opcional
- estados `hoverable`, `selectable`, `selected`

---

### F2.5 — DetailBlock

**Roadmap:** gap do catálogo
**Cobre:** `UIP-CONTENT-DETAIL_BLOCK` (`3/10`)
**Prioridade:** `P2`

Entregas:
- `DetailBlock`
- `DetailGroup`
- `DetailRow`
- loading com `SkeletonText`
- ações por secção

---

### F2.6 — RadioGroup e Switch

**Roadmap:** `R1` › Forms + Forms Adicionais
**Cobre:** expansão de `UIP-INPUT-FORM_FIELD_GROUP`
**Prioridade:** `P2`

Entregas:
- `RadioField<TValue>`
- `RadioGroup<TValue>`
- `SwitchField`

Motivo:
- Completa o conjunto mínimo de formulários antes de partir para inputs mais especializados.

---

### F2.7 — Tooltip

**Roadmap:** `R1` › Componentes Diversos › `Tooltip`
**Cobre:** uso transversal sem `UIP-*` dedicado
**Prioridade:** `P2`

Motivo:
- Melhora densidade informacional em grids, action bars e detalhes.
- Reaproveitável por diversos componentes futuros.

---

### F2.8 — ConfirmDialog e PopConfirm

**Roadmap:** `R3` › `ConfirmDialog`, `R2` › `PopConfirm`
**Cobre:** evolução de `UIP-FEEDBACK-CONFIRMATION_DIALOG`
**Prioridade:** `P2`

Entregas:
- `ConfirmDialog` como template sobre `Modal`
- `PopConfirm` como confirmação leve sem modal completo

Motivo:
- A infraestrutura existe, mas falta ergonomia de alto nível.

---

## Fase 3 — Filtros, layout e shell operacional

> Objetivo: melhorar ergonomia de páginas densas e shells administrativos sem atacar ainda casos de nicho pesado.

### F3.1 — FilterPanel

**Roadmap:** implícito no catálogo
**Cobre:** `UIP-INPUT-FILTER_PANEL` (`5/10`)
**Prioridade:** `P3`

Entregas:
- `FilterPanel`
- `FilterIndicator`
- comportamento desktop + Mobile com `OffCanvas`

---

### F3.2 — SplitPanel

**Roadmap:** `R2` › `Split`
**Cobre:** `UIP-STRUCT-SPLIT_PANEL` (`4/10`)
**Prioridade:** `P3`

Entregas:
- `SplitPanel`
- `SplitPaneStart`
- `SplitPaneEnd`
- divisor ajustável
- alternância Mobile

---

### F3.3 — FloatingActionButton

**Roadmap:** gap do catálogo
**Cobre:** `UIP-ACTION-FLOATING_ACTION` (`3/10`)
**Prioridade:** `P3`

Entregas:
- `FloatingActionButton`
- `FloatingActionGroup`
- posição fixa configurável
- modo ícone e modo expandido

---

### F3.4 — Panel, Accordion e Collapse

**Roadmap:** `R1` › Componentes Diversos
**Cobre:** apoio a `DetailBlock`, filtros e disclosure
**Prioridade:** `P3`

Entregas:
- `Panel`
- `Accordion`
- `Collapse`

---

### F3.5 — Avatar, AvatarGroup e UserProfile

**Roadmap:** `R3`
**Cobre:** apoio a `Navigation Menu`, `ListItem`, `Timeline` e shells
**Prioridade:** `P3`

Entregas:
- `Avatar`
- `AvatarGroup`
- `UserProfile`

Motivo:
- Não fecha um gap central do catálogo sozinho, mas melhora fortemente shells e áreas de identidade.

---

### F3.6 — DispatchButton

**Roadmap:** `R2` › `Dispatch`
**Cobre:** ação assíncrona recorrente sem `UIP-*` próprio
**Prioridade:** `P3`

Motivo:
- Reaproveita `Button`, `RotationMotion` e `Notify`.
- Gera valor operacional alto com baixo risco técnico.

---

### F3.7 — Timeline

**Roadmap:** `R1` › Componentes Diversos › `Timeline`
**Cobre:** `UIP-DATA-TIMELINE_ITEM` (`0/10`)
**Prioridade:** `P3`

Motivo:
- Gap real, mas menos transversal que `DataGrid`, `ListItem` e `DetailBlock`.

---

### F3.8 — MetricCard

**Roadmap:** gap do catálogo
**Cobre:** `UIP-CONTENT-METRIC_CARD` (`2/10`)
**Prioridade:** `P3`

Motivo:
- Importante para dashboards, mas não bloqueia o uso geral da biblioteca.

---

### F3.9 — Result e ResultDialog

**Roadmap:** `R2` › `Result`, `R3` › `ResultDialog`
**Cobre:** backlog complementar sem `UIP-*` canônico próprio
**Prioridade:** `P3`

Motivo:
- Útil para conclusão de operações, onboarding e retornos de processamento.
- Pode ser derivado de `Feedback`, `Modal` e `Button`.

---

## Fase 4 — Complexos, nicho e dependentes de infraestrutura futura

> Objetivo: atacar casos especializados depois de fechar a base transversal.

### F4.1 — Kanban

**Roadmap:** `R1` › Complexos › `Kanban`
**Cobre:** `UIP-DATA-KANBAN_COLUMN` (`0/10`)
**Prioridade:** `P4`

Observação:
- Depende de `Drag & Drop` estável.

---

### F4.2 — DashboardLayout

**Roadmap:** `R1` › Peculiares › `DashboardLayout`
**Cobre:** evolução de `UIP-STRUCT-GRID_CONTAINER`
**Prioridade:** `P4`

Observação:
- Ideal depois de `MetricCard`, `DataGrid`, `Card` e, se necessário, `Drag & Drop`.

---

### F4.3 — Tree, TreeSelect e CheckTree

**Roadmap:** `R1`
**Cobre:** casos hierárquicos sem `UIP-*` central no catálogo base
**Prioridade:** `P4`

---

### F4.4 — Agenda / Calendar

**Roadmap:** `R1` › Complexos
**Cobre:** `PP-CALENDAR`
**Prioridade:** `P4`

---

### F4.5 — Media Viewer, VideoPlayer e Maps

**Roadmap:** `R2` + `R1`
**Cobre:** `UIP-CONTENT-MEDIA_VIEWER`, `PP-MAP`
**Prioridade:** `P4`

---

### F4.6 — Charts, Gauge, BarCode, QRCode

**Roadmap:** `R1` + `R3`
**Cobre:** visualizações especializadas
**Prioridade:** `P4`

Observação:
- Preferir integração com bibliotecas externas quando fizer sentido.

---

### F4.7 — QueryBuilder, GanttChart, StockChart, Windows e afins

**Roadmap:** `R1` + `R3`
**Cobre:** workbench e casos altamente especializados
**Prioridade:** `P4`

---

## Sequência operacional recomendada

1. `Skeleton`
2. `EmptyState`
3. `SearchField`
4. `Tabs`
5. campos concretos essenciais
6. `DatePicker`
7. `DataGrid`
8. `Steps`
9. `ListItem`
10. `DetailBlock`
11. `Tooltip`
12. `FilterPanel`
13. `SplitPanel`
14. `Avatar` + `UserProfile`
15. backlog complexo de nicho

---

## Resumo executivo

| Frente | Estado Atual | Ação |
|---|---|---|
| Navegação básica | boa, mas com gap em `Tabs` | atacar `Tabs` e manter `Pagination` fora do backlog de criação |
| Formulários | infraestrutura forte, controles insuficientes | priorizar campos concretos e `DatePicker` |
| Dados operacionais | fraco | priorizar `DataGrid`, `ListItem`, `Card`, `DetailBlock` |
| Feedback | bom em toast/erro, fraco em loading | entregar `Skeleton` e `EmptyState` |
| Shell e layout avançado | parcial | evoluir depois com `FilterPanel`, `SplitPanel`, `UserProfile` |
| Nicho e visualizações pesadas | ausente ou ad hoc | empurrar para a fase 4 |
