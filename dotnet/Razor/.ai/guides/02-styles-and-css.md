# Guide 02 — Sistema de Estilos e CSS

> Como funciona o projeto `RoyalCode.Razor.Styles`, os enums semânticos, o builder `CssClasses` e a convenção de nomenclatura CSS `ya-`.

---

## Visão Geral

O projeto `RoyalCode.Razor.Styles` **não contém componentes Razor** — contém apenas:

1. **Enums semânticos** que abstraem valores de CSS (Sizes, Themes, Positions, etc.)
2. **Extension methods** para converter enums em classes CSS
3. **Builders fluentes** para construir strings de classes CSS de forma type-safe (`CssClasses`, `BorderBuilder`, `PaddingBuilder`, etc.)
4. **Utilitários estáticos** (`Css.*`) que expõem os builders via propriedades estáticas
5. **O componente `YasamenStyles.razor`** que inclui os arquivos CSS no `<head>`

O CSS real (`.css`, `.bundle.css`) fica em `wwwroot/` e é construído pelo **gulpfile** a partir de Tailwind + estilos customizados.

---

## Enums Semânticos

### `Themes` — Temas de cor

```csharp
public enum Themes
{
    Default,    // mapeia para Secondary na maioria dos componentes
    Primary,
    Secondary,
    Tertiary,
    Info,
    Highlight,
    Success,
    Warning,
    Alert,
    Danger,
    Light,
    Dark
}
```

**Uso:** todos os componentes visuais têm um parâmetro `Style` ou `Theme` do tipo `Themes`. O componente converte para classe CSS `ya-{component}-{theme}` via extension method.

---

### `Sizes` — Tamanhos de componente

```csharp
public enum Sizes
{
    Default,    // sem classe CSS (tamanho padrão / medium)
    Smallest,   // → "2xs"
    Smaller,    // → "xs"
    Small,      // → "sm"
    Medium,     // → "md"
    Large,      // → "lg"
    Larger,     // → "xl"
    Largest,    // → "2xl"
}
```

**Conversão:**
```csharp
// Sem prefixo: "sm"
size.ToCssClassName()

// Com prefixo: "ya-badge-sm"
size.ToCssClassName("ya-badge")
```

---

### `SpacingSize` — Tamanhos de espaçamento (px)

```csharp
public enum SpacingSize
{
    None,       // 0px
    One,        // 1px
    Two,        // 2px
    SmallerX2,  // 4px
    Smaller,    // 8px
    Small,      // 12px
    Medium,     // 16px
    Large,      // 24px
    Larger,     // 32px
    LargerX2,   // 48px
    LargerX3,   // 64px
    LargerX4,   // 80px
    LargerX5,   // 96px
    LargerX6,   // 128px
    LargerX7,   // 196px
    LargerX8,   // 256px
    Largest,    // 512px
    Initial
}
```

Usado para alturas de header (`AppTopBar`), larguras de sidebar (`AppSideBar`), etc.

---

### Outros enums relevantes

| Enum | Valores | Uso típico |
|---|---|---|
| `Positions` | Start, Center, End | Alinhamento de ícone, posição de sidebar |
| `Directions` | Up, Down, Left, Right | Direção do dropdown |
| `Fitting` | Incorporated, Overlaying, Float | Fitting do OffCanvas |
| `ButtonTypes` | Button, Submit, Reset | Tipo do `<button>` |
| `BorderSide` | Flags: Top, End, Bottom, Start, All... | Lados da borda |
| `BorderRound` | Flags: Top, End, Bottom, Start, Circle, Pill... | Arredondamento |

---

## `CssClasses` — Builder de Classes CSS

`CssClasses` é uma `struct` que constrói strings de classes CSS de forma eficiente (sem StringBuilder por padrão para 1-2 classes).

### Padrão obrigatório para propriedade `Classes`

Todos os componentes expõem as classes via uma propriedade privada `Classes`:

```csharp
// No @code do .razor ou no .razor.cs:
private string Classes => "ya-badge"           // classe base
    .AddClass(GetStyle())                       // tema: "ya-badge-primary"
    .AddClass(Size.ToCssClassName("ya-badge"))  // tamanho: "ya-badge-sm"
    .AddClass(Block, "w-full")                  // condicional
    .AddClass(Disabled, "cursor-not-allowed opacity-50")
    .AddClass(AdditionalClasses);               // sempre o último!
```

No markup `.razor`:
```razor
<div class="@Classes" @attributes="AdditionalAttributes">
```

### Extension methods disponíveis em `string`

| Método | Descrição |
|---|---|
| `.AddClass(string? other)` | Adiciona classe se `other` não for null/vazio |
| `.AddClass(bool condition, string? other)` | Adiciona se condição for true |
| `.AddClass(bool cond, string? whenTrue, string? whenFalse)` | Ternário de classe |
| `.AddClass<T>(T? value, Func<T, string?> func)` | Adiciona via função se value não for null |

### Regras

- **Classe base sempre hardcoded** como string literal inicial
- **`AdditionalClasses` sempre no final** da cadeia
- **`AdditionalAttributes` nunca misturado** com `AdditionalClasses` — são parâmetros separados

---

## `BorderBuilder` — Builder de Bordas

Pré-configurações prontas:

```csharp
BorderBuilder.Default           // borda padrão do design system
BorderBuilder.None              // sem borda
BorderBuilder.Box               // borda completa, 1px
BorderBuilder.BoxRounded        // borda completa, arredondada
BorderBuilder.BoxWithShadow     // borda completa + sombra
BorderBuilder.BoxRoundedWithShadow
BorderBuilder.Header            // borda inferior (separador de header)
BorderBuilder.Footer            // borda superior (separador de footer)
```

Uso em componente:
```razor
<Box Border="@BorderBuilder.Box" Padding="@PaddingBuilder.Medium">
```

---

## `PaddingBuilder` — Builder de Padding

```csharp
PaddingBuilder.None         // sem padding
Css.Padding.Size.Medium()   // padding medium em todos os lados
Css.Padding.Side.Top().Size.Small()  // padding top small
```

---

## Convenção de Nomenclatura CSS `ya-`

**Todas** as classes customizadas do design system usam o prefixo `ya-`.

Padrão de nomenclatura:

```
ya-{componente}
ya-{componente}-{tema}
ya-{componente}-{tamanho}
ya-{componente}-{modificador}
```

Exemplos reais:
| Classe | Significado |
|---|---|
| `ya-btn` | botão base |
| `ya-btn-primary` | botão tema primary |
| `ya-btn-sm` | botão tamanho small |
| `ya-i-btn` | icon-button base |
| `ya-badge` | badge base |
| `ya-badge-danger` | badge tema danger |
| `ya-feedback` | alert/feedback base |
| `ya-feedback-block` | alert de largura total |
| `ya-notification` | toast base |
| `ya-drop` | dropdown base |
| `ya-drop-item` | item de dropdown |
| `ya-field-group` | grupo de campo de formulário |
| `ya-field-group-invalid` | estado de erro do grupo |
| `ya-input-field` | input de texto base |
| `ya-input-field-invalid` | input com erro |
| `ya-bar` | barra horizontal |
| `ya-box` | container genérico |
| `ya-stack` | coluna vertical |
| `ya-container` | grid/flex container |
| `ya-column` | coluna responsiva |
| `ya-top-bar` | barra superior do app |
| `ya-side-bar` | sidebar do app |
| `ya-offcanvas` | painel deslizante |
| `ya-modal` | modal overlay |
| `ya-breadcrumb` | nav breadcrumb |
| `ya-btnclose` | botão de fechar (×) |

**Regra:** nunca usar classes Tailwind como classes de componente público. Tailwind é usado internamente nas implementações. A API pública expõe classes `ya-*`.

---

## Como Incluir os Estilos na App

O projeto `RoyalCode.Razor.Styles` expõe o componente `YasamenStyles`:

```razor
@* No <head> do App.razor ou index.html *@
<YasamenStyles />
```

Isso injeta automaticamente o CSS correto:
- **Dev** (Debugger attached): `yasamen.dist.css` + `styles.css` separados
- **Prod**: `styles.bundle.css` (tudo minificado em um arquivo, com fingerprint)

---

## Criando CSS para um Novo Componente

### Estrutura do pipeline de build

O arquivo `wwwroot/yasamen.css` é o **ponto de entrada do Tailwind v4**:

```css
@import 'tailwindcss' source('../../../Razor');

@import './css/components/btn.css';
@import './css/components/badge.css';
@import './css/components/feedback.css';
/* ... demais componentes ... */

@import './css/forms/fieldgroup.css';
@import './css/forms/inputfield.css';
/* ... demais formulários ... */

@theme {
    --breakpoint-xs: 30rem;
    --color-primary: #0d6dfd;
    --color-primary-100: #cfe2ff;
    /* ... todas as cores e tokens ... */
}
```

**Ponto crítico:** `source('../../../Razor')` faz o Tailwind escanear **toda a solução** (todos os projetos `.razor`, `.cs`, `.html`) em busca de classes utilizadas. Isso significa que classes `@apply` nos arquivos CSS são detectadas via uso real nos componentes — não há purge manual.

### Locais dos arquivos CSS

| Tipo | Pasta | Exemplo |
|---|---|---|
| Componentes visuais | `wwwroot/css/components/` | `btn.css`, `badge.css`, `modal.css` |
| Componentes de formulário | `wwwroot/css/forms/` | `fieldgroup.css`, `inputfield.css` |
| Utilitários globais | `wwwroot/css/` | `utilities.css`, `variables.css`, `reboot.css` |

### Como criar o CSS de um novo componente

**Passo 1** — Criar o arquivo CSS em `wwwroot/css/components/{nome}.css`:

```css
/* Classe base */
.ya-meucomponente {
    @apply relative flex items-center gap-2 rounded-md;
}

/* Variantes de tamanho */
.ya-meucomponente-sm {
    @apply text-sm px-3 py-1;
}
.ya-meucomponente-md {
    @apply text-base px-4 py-2;
}
.ya-meucomponente-lg {
    @apply text-lg px-5 py-3;
}

/* Variantes de tema — seguir o padrão 100/800 para bg/text */
.ya-meucomponente-primary {
    @apply bg-primary-100 text-primary-800 border border-primary-200;
}
.ya-meucomponente-secondary {
    @apply bg-secondary-100 text-secondary-800 border border-secondary-200;
}
.ya-meucomponente-success {
    @apply bg-success-100 text-success-800 border border-success-200;
}
.ya-meucomponente-warning {
    @apply bg-warning-100 text-warning-800 border border-warning-200;
}
.ya-meucomponente-danger {
    @apply bg-danger-100 text-danger-800 border border-danger-200;
}
/* ... demais temas ... */

/* Modificadores de estado */
.ya-meucomponente-disabled {
    @apply opacity-50 cursor-not-allowed pointer-events-none;
}
```

**Passo 2** — Registrar o `@import` no `yasamen.css`:

```css
@import './css/components/meucomponente.css';
```

> Colocar o import **em ordem alfabética** junto aos demais componentes.

### Paleta de cores disponível

Todos os tokens de cor são definidos no bloco `@theme` de `yasamen.css` e seguem o padrão `{cor}-{shade}`:

| Token | Shades disponíveis | Uso típico |
|---|---|---|
| `primary` | 100–900 | Ação principal, CTA |
| `secondary` | 100–900 | Ação secundária, neutro |
| `tertiary` | 100–900 | Destaque alternativo |
| `success` | 100–900 | Confirmação, estado OK |
| `warning` | 100–900 | Aviso, atenção |
| `alert` | 100–900 | Alerta leve |
| `danger` | 100–900 | Erro, ação destrutiva |
| `info` | 100–900 | Informação |
| `highlight` | 100–900 | Destaque especial |
| `light` | 100–900 | Fundo claro |
| `dark` | 100–900 | Fundo escuro, texto |

**Convenção de shade por uso:**
- `{cor}-100` → background suave (badge, feedback)
- `{cor}-200` → borda suave
- `{cor}-400` → cor sólida (botão filled) 
- `{cor}-600` → hover de botão filled
- `{cor}-700` → active/pressed de botão filled
- `{cor}-800` → texto sobre fundo claro (badge)

### Exemplo real — badge.css

```css
.ya-badge {
    @apply font-normal text-sm inline-block align-middle rounded-full px-4;
}

.ya-badge-primary {
    @apply bg-primary-100 text-primary-800 border border-primary-200;
}

.ya-badge-success {
    @apply bg-success-100 text-success-800 border border-success-200;
}

.ya-badge-sm {
    @apply text-sm px-3.5;
}

.ya-badge-md {
    @apply text-base px-4;
}
```

### Variantes interativas (botões, itens clicáveis)

Para estados hover/active usar os modificadores do Tailwind v4 com `not-disabled`:

```css
.ya-btn-primary {
    @apply bg-primary-400 text-white
           hover:not-disabled:bg-primary-600
           active:not-disabled:bg-primary-700
           border-primary-400
           focus-within:ring-primary-300/50;
}
```

---

## Adicionando Classes a um Novo Componente — Checklist

1. Criar `wwwroot/css/components/{nome}.css` com as classes `ya-{nome}`
2. Registrar `@import './css/components/{nome}.css'` em `yasamen.css`
3. Definir variantes de tema (`ya-{nome}-{theme}`) para todos os valores do enum `Themes` que o componente suportar
4. Definir variantes de tamanho (`ya-{nome}-{size}`) para os valores do enum `Sizes` relevantes
5. Criar extension method `To{Nome}Theme(this Themes t)` e `To{Nome}Size(this Sizes s)` no projeto do componente
6. Usar `CssClasses` builder na propriedade `Classes` do componente — nunca `string.Concat` ou interpolação
7. `AdditionalClasses` sempre no **final** da cadeia `.AddClass()`
