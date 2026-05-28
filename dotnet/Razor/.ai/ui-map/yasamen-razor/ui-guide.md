# UI Guide — yasamen-razor

**Família técnica**: `web`
**CSS engine**: Tailwind CSS v4 via `@theme` tokens em `yasamen.css`

---

## Arquitetura de Estilos

### Camadas

| Camada | Localização | Papel |
|---|---|---|
| Tokens / Design Tokens | `yasamen.css` via `@theme` | Paleta semântica, breakpoints, tipografia, espaçamento |
| Estilos de componente | `wwwroot/css/components/*.css` | Classes públicas estáveis por componente |
| Estilos de formulário | `wwwroot/css/forms/*.css` | Classes de form fields |
| Utilitários | Tailwind + classes utilitárias ad hoc | Layout interno, composição local |
| Injeção | `YasamenStyles.razor` | Entry point para aplicação consumidora |

### Fluxo de consumo
```
yasamen.css
  @import './css/components/btn.css'
  @import './css/components/badge.css'
  @import './css/forms/fieldgroup.css'
  ...
```

A aplicação consumidora inclui apenas `<YasamenStyles />` no `<head>`.

---

## Tokens de Design (yasamen.css)

### Paleta semântica de temas

Cada tema tem escala de cores. Convenção: `{tema}-{shade}` (ex: `primary-500`).

| Tema | Uso semântico |
|---|---|
| `primary` | Ação principal, identidade da marca |
| `secondary` | Ação secundária, conteúdo complementar |
| `tertiary` | Terceiro nível de hierarquia |
| `success` | Confirmação, conclusão, estado positivo |
| `warning` | Atenção, risco moderado |
| `danger` | Erro, ação destrutiva, risco alto |
| `alert` | Alerta (tom amarelo/âmbar) |
| `info` | Informação neutra |
| `highlight` | Destaque especial, novidade |
| `light` | Fundo claro, superfícies neutras |
| `dark` | Fundo escuro, texto em fundos claros |

### Breakpoints

| Token | Uso |
|---|---|
| `xs` | Mobile pequeno |
| `sm` | Mobile |
| `md` | Tablet |
| `lg` | Laptop |
| `xl` | Desktop |
| `2xl` | Wide desktop |

### Enums de estilo (C#)

```csharp
// Temas visuais
public enum Themes { Default, Primary, Secondary, Tertiary, Info, Highlight, Success, Warning, Alert, Danger, Light, Dark }

// Tamanhos
public enum Sizes { Default, Smallest, Smaller, Small, Medium, Large, Larger, Largest }

// Posições
public enum Positions { Start, Center, End }

// Direções
public enum Directions { Down, Up, Left, Right }
```

---

## Padrão de Classes por Componente

### Anatomia CSS pública

```
ya-{componente}                   ← classe raiz (sempre presente)
ya-{componente}-{tema}            ← ex: ya-btn-primary, ya-feedback-danger
ya-{componente}-{tamanho}         ← ex: ya-btn-sm, ya-pagination-lg
ya-{componente}-{estado}          ← ex: ya-modal-open, ya-pagination-loading
ya-{componente}-{slot}            ← ex: ya-pagination-list, ya-top-bar-start
```

### Inventário de classes raiz

| Componente | Classe raiz |
|---|---|
| Button | `ya-btn` |
| ButtonGroup | `ya-btn-group` |
| IconButton | `ya-i-btn` |
| Badge | `ya-badge` |
| Feedback | `ya-feedback` |
| Notification | `ya-notification` |
| DropButton/DropIconButton | `ya-drop` (container) |
| DropItem | `ya-drop-item` |
| FieldText | `ya-field-text` |
| FieldAction | `ya-field-action` |
| FieldBadge | `ya-field-badge` |
| FieldGroup (interno) | `ya-field-group` |
| Bar | `ya-bar` |
| Box | `ya-box` |
| Container | `ya-container` |
| Slot | `ya-column` |
| Stack | `ya-stack` |
| AppLayout | `ya-app-layout` |
| AppTopBar | `ya-top-bar` |
| AppSideBar | `ya-side-bar` |
| AppSideItem | `ya-side-bar-item` |
| AppMenu | `ya-app-menu` |
| AppMenuItem | `ya-menu-item` |
| Modal | `ya-modal` |
| Pagination | `ya-pagination` |
| OffCanvas | `ya-offcanvas` |
| AsideBox | `ya-aside-box` |
| Breadcrumb | `ya-breadcrumb` |
| BreadcrumbItem | `ya-breadcrumb-item` |

---

## Variantes por Enum

### Themes → Button

```
ya-btn-primary    ya-btn-secondary    ya-btn-tertiary
ya-btn-success    ya-btn-warning      ya-btn-danger
ya-btn-info       ya-btn-highlight    ya-btn-alert
ya-btn-light      ya-btn-dark
```
Com `Outline=true`: mesmas classes + variante outline (controlada por helper `ToButtonTheme(active, outline)`)

### Themes → Badge / Feedback / Notification

Padrão: `ya-{comp}-{tema}` ex: `ya-badge-success`, `ya-feedback-warning`, `ya-notification-danger`

### Sizes → Componente

Exemplo para Button:
```
ya-btn-xs   ya-btn-sm   ya-btn-md   ya-btn-lg   ya-btn-xl
```
Padrão via `Size.ToCssClassName("ya-btn")`.

---

## Builders de Estilo

### BorderBuilder (Box)

```csharp
BorderBuilder.Default      ← sem borda
BorderBuilder.Box          ← borda completa arredondada (padrão do Box)
BorderBuilder.BoxRounded   ← borda arredondada maior
BorderBuilder.BoxWithShadow ← borda com sombra
```

### PaddingBuilder

```csharp
PaddingBuilder.None
Css.Padding.Size.Medium()
Css.Padding.Side.Top().Size.Small()
Css.Padding.Side.All().Size.Large()
```

### MarginBuilder

```csharp
MarginBuilder.None
Css.Margin.Side.Top().WithSize(SpacingSize.Small)
Css.Margin.Side.Left().WithSize(LeftMenuSize)
```

---

## Estados Visuais

### Button / IconButton

| Estado | Classe CSS |
|---|---|
| Disabled | `cursor-not-allowed opacity-50` (via Tailwind) |
| Active | `active` |
| Outline | variante `-outline` no tema |
| Block | `w-full` |

### Modal

| Fase | Classe CSS |
|---|---|
| Fechado | `ya-modal-closed` |
| Abrindo início | `ya-modal-opening-start` |
| Abrindo | `ya-modal-opening` |
| Aberto | `ya-modal-open` |
| Fechando início | `ya-modal-closing-start` |
| Fechando | `ya-modal-closing` |
| Centralizado | `ya-modal-center` |

### OffCanvas

| Estado | Classe CSS |
|---|---|
| Visível | `ya-offcanvas-show` |
| Posição start | `ya-offcanvas-start` |
| Posição end | `ya-offcanvas-end` |
| Overlay | `ya-offcanvas-overlaying` |
| Float | `ya-offcanvas-float` |

### Pagination

| Estado | Classe CSS |
|---|---|
| Loading | `ya-pagination-loading` |
| Link ativo | `ya-pagination-link-active` |
| Link desabilitado | `ya-pagination-link-disabled` |

### AppSideItem

| Estado | Classe CSS |
|---|---|
| Ativo | `ya-side-bar-item active` |

---

## Como Aplicar Estilos

### Em componente novo (dentro da lib)

```csharp
private string Classes => "ya-meucomp"
    .AddClass(Style.ToMeuCompTheme())    // helper de tema
    .AddClass(Size.ToCssClassName("ya-meucomp"))  // helper de tamanho
    .AddClass(Flag, "ya-meucomp-estado") // modificador condicional
    .AddClass(AdditionalClasses);        // sempre por último
```

### Em aplicação consumidora

```razor
<Button Style="Themes.Primary" Size="Sizes.Small" AdditionalClasses="mt-4" />
<Badge Style="Themes.Success" Text="Ativo" />
<Feedback Style="Themes.Danger" Title="Erro" Text="Algo deu errado." />
```

Customização via `AdditionalClasses` (classes Tailwind ou custom passadas sem sobrescrever as classes base).

---

## Sistema de Espaçamento (SpacingSize)

Usado por `AppLayout` para configurar alturas/larguras de regiões:

| Valor | Uso |
|---|---|
| `SpacingSize.Small` | Compacto |
| `SpacingSize.Medium` | Padrão (default de `Slot.Height`) |
| `SpacingSize.Large` | Ampliado |
| `SpacingSize.LargerX2` | Default de TopBar, Sidebars, Footer no `AppLayout` |

Mapeamento para classes via helpers: `ToHeightCssClass()`, `ToWidthCssClass()`, `ToMinWidthCssClass()`, `ToMinHeightCssClass()`.

---

## Responsividade

### Layout responsivo via Container + Slot

```razor
<Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default">
    <Slot Span="12" TabletSpan="6" LaptopSpan="4">
        ...
    </Slot>
    <Slot Span="12" TabletSpan="6" LaptopSpan="8">
        ...
    </Slot>
</Container>
```

Grid de 12 colunas. Span define quantas o Slot ocupa. TabletSpan/LaptopSpan/DesktopSpan sobrescrevem em breakpoints específicos.

### Pagination mobile/desktop

`Pagination` renderiza duas versões simultaneamente:
- `.ya-pagination-desktop` — janela de páginas + first/last/ellipsis
- `.ya-pagination-mobile` — apenas prev/next + "Página X de Y"
CSS controla visibilidade por breakpoint.

---

## Limitações e Zonas de Cuidado

- CSS público APENAS em `RoyalCode.Razor.Styles/wwwroot/` — não criar `*.razor.css` novo
- Pacotes com legado `*.razor.css`: Animations, Drops, OffCanvas (tratar como tech debt)
- `Themes.Default` é o fallback; cada componente define seu fallback real (ex: Badge → secondary)
- Ícones sem pacote de implementação registrado mostram ícone de "ban" como fallback
- `AppLayout` requer DI completo (Modal + OffCanvas + Notifications) para funcionar sem erros de outlet
- `DropBase` usa interop JS (`ClickJs`) para detectar cliques externos — requer `AddYasamenCommons()`
- `Modal` e `OffCanvas` usam `SectionContent`/`SectionOutlet` — precisam dos outlets no DOM antes do uso

---

## Exemplo: CSS de Componente

```css
/* wwwroot/css/components/btn.css */
.ya-btn {
    @apply relative inline-flex items-center justify-center gap-2 
           rounded-md font-medium transition-colors cursor-pointer;
}

.ya-btn-primary {
    @apply bg-primary-600 text-white hover:bg-primary-700;
}

.ya-btn-primary-outline {
    @apply border border-primary-600 text-primary-600 hover:bg-primary-50;
}

.ya-btn-sm {
    @apply px-3 py-1.5 text-sm;
}

.ya-btn-lg {
    @apply px-6 py-3 text-lg;
}
```
