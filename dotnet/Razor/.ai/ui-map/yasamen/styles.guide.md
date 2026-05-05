# Styles Guide - yasamen

## Biblioteca de estilos detectada

`yasamen` usa Tailwind CSS 4.1.11 com entrada própria em `RoyalCode.Razor.Styles/wwwroot/yasamen.css` e scripts Bun:

- `build:tw:css`: `bunx @tailwindcss/cli -i ./wwwroot/yasamen.css -o ./wwwroot/yasamen.dist.css`
- `build:tw:css:min`: gera `yasamen.min.css`
- `watch:css`: watch para `yasamen.dist.css`
- `bundle:css`: usa gulp para gerar bundle

O projeto `RoyalCode.Razor.Styles.csproj` executa build de CSS:

- Debug: `bun run build:tw:css`
- Release: `build:tw:css`, `build:tw:css:min`, `bundle:css`

## Entradas e saidas CSS

Entradas humanas:

- `wwwroot/yasamen.css`: importa Tailwind e CSS de componentes/forms.
- `wwwroot/styles.css`: importa `variables.css`, `reboot.css`, `ripple.css`.
- `wwwroot/css/components/*.css`: estilos de componentes visuais.
- `wwwroot/css/forms/*.css`: estilos de fields/forms.
- `wwwroot/css/utilities.css`: utilities customizadas.

Saidas geradas:

- `wwwroot/yasamen.dist.css`
- `wwwroot/yasamen.min.css`
- `wwwroot/styles.bundle.css`

`YasamenStyles.razor` carrega:

- Debugger anexado: `yasamen.dist.css` + `styles.css`.
- Runtime normal: `styles.bundle.css` via `Assets["/_content/RoyalCode.Razor.Styles/styles.bundle.css"]`.

## Tokens principais

### Breakpoints

Definidos em `@theme`:

| Token | Valor |
|---|---|
| `--breakpoint-xs` | `30rem` / 480px |
| `--breakpoint-sm` | `40rem` / 640px |
| `--breakpoint-md` | `48rem` / 768px |
| `--breakpoint-lg` | `64rem` / 1024px |
| `--breakpoint-xl` | `80rem` / 1280px |
| `--breakpoint-2xl` | `96rem` / 1536px |

### Temas cromaticos

Enum C#: `Themes.Default`, `Primary`, `Secondary`, `Tertiary`, `Info`, `Highlight`, `Success`, `Warning`, `Alert`, `Danger`, `Light`, `Dark`.

Tokens CSS base:

| Tema | Base |
|---|---|
| primary | `#0d6dfd` |
| secondary | `#6c757d` |
| tertiary | `#7c3aed` |
| info | `#7db8f0` |
| highlight | `#4169E1` |
| success | `#10b981` |
| warning | `#fbbf24` |
| alert | `#f97316` |
| danger | `#DC3545` |
| light | `#F2F1F3` |
| dark | `#38333c` |

Cada tema tem escala `100` a `900` no `@theme`, e alguns temas também usam aliases diretos como `--color-primary`.

### Tipografia

Fontes:

- `--font-sans`: system UI, Segoe UI, Roboto, Helvetica Neue, Arial.
- `--font-serif`: Georgia/Times.
- `--font-mono`: SFMono-Regular, Consolas, Liberation Mono, Menlo.

Tamanhos extras:

- `--text-4xs: 0.5rem`
- `--text-3xs: 0.5625rem`
- `--text-2xs: 0.625rem`

### Espacamento

Escala customizada:

| Token | Valor |
|---|---|
| `--spacing-0` | `0` |
| `--spacing-1` | `.0625rem` |
| `--spacing-2` | `.125rem` |
| `--spacing-3` | `.25rem` |
| `--spacing-4` | `.5rem` |
| `--spacing-5` | `.75rem` |
| `--spacing-6` | `1rem` |
| `--spacing-7` | `1.5rem` |
| `--spacing-8` | `2rem` |
| `--spacing-9` | `3rem` |
| `--spacing-10` | `4rem` |
| `--spacing-11` | `5rem` |
| `--spacing-12` | `6rem` |
| `--spacing-13` | `8rem` |
| `--spacing-14` | `12rem` |
| `--spacing-15` | `16rem` |
| `--spacing-16` | `32rem` |

Enum C# `SpacingSize` mapeia valores como `None`, `One`, `Two`, `SmallerX2`, `Smaller`, `Small`, `Medium`, `Large`, `Larger`, `LargerX2` ... `Largest`.

## Classes e prefixos

Padrão raiz:

- Componentes usam `ya-*`.
- Botões: `ya-btn`, `ya-i-btn`, `ya-btn-group`.
- Feedback: `ya-badge`, `ya-feedback`, `ya-notification`.
- Form fields: `ya-field-*`, `ya-input-field`, `ya-control-group`.
- Layout shell: `ya-app-*`, `ya-top-bar`, `ya-side-bar`, `ya-menu-item`.
- Overlay: `ya-modal-*`, `ya-offcanvas-*`, `ya-drop-*`.
- Navigation: `ya-breadcrumb-*`, `ya-pagination-*`.

## Regras por família de componente

### Botões

Base `ya-btn`:

- `relative`, `overflow-hidden`, `border-1`, `transition-all`, `duration-150`, `focus:outline-none`.
- Tamanhos `ya-btn-2xs` a `ya-btn-2xl` controlam `text-*`, `px-*`, `py-*`, `focus-within:ring-*`, `rounded-*`.
- Temas filled: `ya-btn-primary`, `ya-btn-secondary`, `ya-btn-tertiary`, `ya-btn-info`, `ya-btn-highlight`, `ya-btn-success`, `ya-btn-warning`, `ya-btn-alert`, `ya-btn-danger`, `ya-btn-light`, `ya-btn-dark`.
- Temas outline e active seguem o mesmo sufixo: `-outline`, `-active`, `-outline-active`.

`IconButton` usa `ya-i-btn` e tamanhos quadrados; `ButtonGroup` ajusta bordas entre filhos e suporta orientação horizontal/vertical.

### Badges

`ya-badge`:

- `font-normal`, `text-sm`, `inline-block`, `align-middle`, `rounded-full`, padding horizontal.
- Temas usam background `*-100`, texto `*-800`, borda `*-200`.
- Tamanhos `ya-badge-2xs` a `ya-badge-2xl`.

### Feedback

`ya-feedback` e variantes:

- Usa temas e tamanhos.
- Suporta close button `ya-btn-close`.
- Títulos mudam por tamanho no componente (`h6`, `h5`, `h4`, `h3`, `h2`).
- Ícone usa `ya-feedback-icon`, conteúdo `ya-feedback-content`, texto `ya-feedback-text`.

### Notifications

`ya-notification`:

- Usa tema, barra lateral ou ícone, conteúdo e botão fechar.
- `ya-notification-timer` usa animation-duration inline.
- Grupos por placement usam classes `ya-notification-group-top`, `bottom`, `left`, `right`, `center`, e combinacoes `top-start`, `top-end`, etc.

### Forms

`ya-input-field`:

- `block`, `w-full`, `bg-white`, `text-dark-800`, `border-light-400`, `rounded-md`, `transition-all`.
- Focus: `focus:border-primary-500`, `focus:ring-primary-300/50`.
- Disabled/read-only: fundo `light-100`, texto `dark-300`/`dark-600`.
- Invalid: `border-danger-500`, `text-danger-700`, `focus:border-danger-600`.

`ya-field-group` estrutura:

- label/description: `ya-field-group-description`, `ya-field-group-label`.
- info/footer: `ya-field-group-informative`, `ya-field-group-footer`.
- erro: `ya-field-error-message`.
- sizes `ya-field-2xs` a `ya-field-2xl` alteram texto, margin, padding e ring dos subcomponentes.

### Layout

`Container` usa `LayoutSizes`:

- Default/Desktop: `grid xs:grid-cols-1 gap-5 items-start grid-cols-4 md:grid-cols-8 lg:grid-cols-12 2xl:grid-cols-16`.
- Laptop: até `lg:grid-cols-12`.
- Tablet: até `md:grid-cols-8`.
- Phone: até `sm:grid-cols-4`.

`Slot` aplica spans por breakpoint:

- default `Span` mapeia `sm:col-span-*`.
- `TabletSpan` mapeia `md:col-span-*`.
- `LaptopSpan` mapeia `lg:col-span-*`.
- `DesktopSpan` mapeia `2xl:col-span-*`.

### App shell

`AppLayout`:

- `ya-app-layout`: grid, full width, min height screen.
- `ya-app-header`: fixed top/right/left, `z-app-bar`.
- `ya-app-page`: flex, full width/height.
- `ya-app-content`: grid, full width, self stretch.
- `ya-app-footer`: flex, full width, bottom aligned, white background.

`AppTopBar`:

- `ya-top-bar`: flex between, center aligned, white background, inset bottom shadow.

`AppSideBar`:

- `ya-side-bar`: hidden on max-sm, fixed on sm+, top/bottom, white background.
- `ya-side-bar-item.active`: primary left border and subtle primary background.

### Overlays

`Modal`:

- `ya-modal-outlet`, `ya-modal-backdrop`, `ya-modal`.
- Transition phases classes: opening-start, opening, open, closing-start, closing, closed.
- `ya-modal-center` centralizes when applicable.

`OffCanvas`:

- `ya-offcanvas`, `ya-offcanvas-start`, `ya-offcanvas-end`, `ya-offcanvas-show`.
- Supports backdrop classes and overlaying mode.

`Drop`:

- `ya-drop`, `ya-drop-open`, direction classes, alignment classes.
- `ya-drop-content` uses min width classes from `Sizes.ToContentMinWidthCssClass()`.

### Navigation

`Breadcrumb`:

- `ya-breadcrumb`, `ya-breadcrumb-item`, `ya-breadcrumb-link`.
- Separator textual `»` via CSS.

`Pagination`:

- `ya-pagination`, desktop/mobile containers, list/item/link/control/icon.
- Size classes `ya-pagination-2xs` a `ya-pagination-2xl`.
- Active: `border-primary-500 bg-primary-500 text-white`.
- Disabled: `cursor-not-allowed opacity-50`.
- Empty state: `rounded-md border border-light-300 bg-light-50`.

## Utilitários customizados

`utilities.css` define:

- `transition-default`
- z-index utilities: `z-app-bar`, `z-offcanvas-backdrop`, `z-offcanvas`, `z-offcanvas-overlay-backdrop`, `z-offcanvas-overlay`, `z-backdrop`, `z-modal`, `z-notification`
- fitting variables: `fit-top-*`, `fit-left-*`, `fit-right-*`, `fit-bottom-*`

Esses utilitários são usados por app shell, modal, offcanvas e layout-aware outlets.

## Regras de uso para novas telas

1. Usar componentes Yasamen antes de HTML puro quando houver componente correspondente.
2. Usar `Themes` para estado semântico: `Primary` para ação principal, `Secondary` para padrão, `Success`/`Warning`/`Danger` para feedback de estado, `Info`/`Highlight` para informação/destaque.
3. Usar `Sizes` para controles (`Smallest` a `Largest`) e `SpacingSize` para shell/layout.
4. Usar `Container` + `Slot` para grids responsivos de formulário/conteúdo.
5. Usar `ButtonGroup` quando ações relacionadas precisam parecer um único grupo.
6. Usar `FieldText`, `FieldBadge`, `FieldAction` dentro dos slots de `TextField`, não como badges genericos fora do contexto de field.
7. Usar `Feedback` para mensagem inline persistente; usar `Notification`/`Notify` para toast transiente.
8. Usar `Modal` para dialogos com foco global; usar `OffCanvas` para painel lateral ou menu contextual.
9. Ao criar classes novas, manter prefixo `ya-` e colocar CSS fonte em `wwwroot/css/components` ou `wwwroot/css/forms`.
10. Ao adicionar CSS novo, importar em `yasamen.css`; não editar bundle/minificado manualmente.

## Gaps e limites de evidência

### GAP-001 - Uso canônico de componentes internos demonstrados
- tipo: escopo
- descrição: `NotificationGroup` e `NotificationAnimation` estão em pasta `Internal`, mas aparecem em demo pública.
- impacto: baixo
- escopo afetado: componentes-summary
- afeta próxima etapa: não
- consequência se ignorado: a próxima etapa pode tratar como componentes avançados em vez de internos estritos.
- hipótese adotada: tratar como suporte avançado, não primeira escolha de tela.
- exige Questão: não
- Questão relacionada: não aplicavel
- status: aberto

### GAP-002 - Busca do AppMenu não implementada
- tipo: implementação
- descrição: `AppMenu` renderiza texto literal `search component` no lugar de um componente real de busca.
- impacto: baixo
- escopo afetado: componente AppMenu
- afeta próxima etapa: não
- consequência se ignorado: screen-designer não deve prometer busca pronta no menu.
- hipótese adotada: tratar busca do AppMenu como placeholder.
- exige Questão: não
- Questão relacionada: não aplicavel
- status: aberto
