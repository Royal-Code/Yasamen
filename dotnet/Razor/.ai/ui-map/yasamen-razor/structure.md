# Structure — yasamen-razor

## Stack e Plataforma

- **Framework**: .NET (Blazor Razor Components)
- **Renderização**: Blazor WASM ou Server (componentes são agnósticos)
- **CSS**: Tailwind CSS v4 via `yasamen.css` (tokens de tema via `@theme`)
- **Target**: Web (SPA / SSR Blazor)
- **Namespace raiz público**: `RoyalCode.Razor.Components`
- **Namespace interno**: `RoyalCode.Razor.Internal.{NomeProjeto}`
- **Namespace de extensões DI**: `Microsoft.Extensions.DependencyInjection`
- **Namespace de estilos**: `RoyalCode.Razor.Styles`

---

## Organização em Projetos (Pacotes)

Cada pacote é um projeto `Microsoft.NET.Sdk.Razor` independente, consumível isoladamente. A visão lógica em camadas:

```
Base
  RoyalCode.Razor.Styles          ← CSS, tokens, enums, helpers de classe
  RoyalCode.Razor.Icons           ← Sistema de ícones extensível
  RoyalCode.Razor.Animations      ← Efeitos de animação (RotateEffect, RotationMotion)
  RoyalCode.Razor.Commons         ← Ripple, utilitários, módulos JS, extensões

Componentes UI
  RoyalCode.Razor.Buttons         ← Button, ButtonGroup, IconButton
  RoyalCode.Razor.Drops           ← DropButton, DropIconButton, DropItem
  RoyalCode.Razor.Forms           ← FieldText, FieldAction, FieldBadge, FieldGroup*
  RoyalCode.Razor.Alerts          ← Badge, Feedback, Notification
  RoyalCode.Razor.Breadcrumbs     ← Breadcrumb, BreadcrumbItem, DescribesBreadcrumbs
  RoyalCode.Razor.Modals          ← Modal + ModalService
  RoyalCode.Razor.OffCanvas       ← OffCanvas, AsideBox, CloseOffCanvasButton
  RoyalCode.Razor.Layouts         ← Bar, Box, Container, Slot, Stack
  RoyalCode.Razor.Navigation      ← Pagination

Composição de Aplicação
  RoyalCode.Razor.Layouts.Apps    ← AppLayout, AppTopBar, AppSideBar, AppMenu, etc.
```

*FieldGroup e outros componentes de formulário internos estão em `Internal/Forms/`

**Dependências entre projetos:**
| Projeto | Depende de |
|---|---|
| Styles | — |
| Icons | — |
| Animations | — |
| Commons | Styles |
| Buttons | Animations, Commons, Icons |
| Drops | Buttons |
| Forms | Buttons |
| Alerts | Commons, Icons |
| Breadcrumbs | Drops |
| Modals | Commons, Styles |
| OffCanvas | Buttons, Styles |
| Layouts | Commons |
| Navigation | (Commons, Styles via Buttons) |
| Layouts.Apps | Alerts, Breadcrumbs, Layouts, Modals, OffCanvas |

---

## Estrutura Interna de Cada Pacote

```
RoyalCode.Razor.XYZ/
├── _Imports.razor             ← @using globais do pacote
├── RoyalCode.Razor.XYZ.csproj
├── Components/                ← Superfície pública do pacote
│   ├── MyComponent.razor      ← markup only (Form A)
│   ├── MyComponent.razor.cs   ← code-behind partial (Form B)
│   └── MyComponent.cs         ← 100% C# sem markup (Form C)
├── Internal/
│   └── XYZ/                   ← Infra e componentes não-públicos
│       ├── InternalService.cs
│       └── InternalComponent.razor
└── Extensions/
    └── XYZServiceCollectionExtensions.cs  ← DI integration
```

### Formas de implementação de componente

**Forma A** — `.razor` com `@code` inline (componentes simples, sem lógica complexa)

**Forma B** — `.razor` + `.razor.cs` code-behind partial (lógica de parâmetros separada):
```csharp
// MyComponent.razor.cs
namespace RoyalCode.Razor.Components;
public partial class MyComponent { ... }
```

**Forma C** — 100% C# via `BuildRenderTree` (componentes sem markup, ex: `Icon.cs`)

---

## CSS e Estilos

### Localização canônica do CSS
```
RoyalCode.Razor.Styles/
├── wwwroot/
│   ├── yasamen.css             ← entry point, @import de todos os arquivos
│   └── css/
│       ├── components/
│       │   ├── btn.css
│       │   ├── badge.css
│       │   ├── modal.css
│       │   └── ...
│       └── forms/
│           └── fieldgroup.css
└── Styles/
    ├── YasamenStyles.razor     ← componente que injeta o CSS
    ├── Themes.cs               ← enum Themes
    ├── Sizes.cs                ← enum Sizes
    ├── Positions.cs            ← enum Positions
    └── ...                     ← builders, extension methods
```

**Regra**: CSS público SEMPRE em `RoyalCode.Razor.Styles/wwwroot/`. Componentes individuais NÃO devem ter `*.razor.css` novos. Pacotes com `*.razor.css` legados: Animations, Drops, OffCanvas.

### Tokens em `yasamen.css`
Definidos via `@theme` (Tailwind v4):
- Breakpoints: `xs`, `sm`, `md`, `lg`, `xl`, `2xl`
- Paleta semântica: `primary-*`, `secondary-*`, `success-*`, `warning-*`, `danger-*`, `info-*`, `highlight-*`, `tertiary-*`, `light-*`, `dark-*`
- Tipografia base e escala adicional
- Escala de espaçamento
- Escala de line-height

### Padrão de construção de classes em componente
```csharp
private string Classes => "ya-{componente}"
    .AddClass(GetStyle())              // variante de tema
    .AddClass(Size.ToCssClassName("ya-{comp}"))  // variante de tamanho
    .AddClass(flag, "ya-{comp}-modifier")        // modificadores condicionais
    .AddClass(AdditionalClasses);      // SEMPRE por último
```

### Nomenclatura CSS
```
ya-{componente}                  ← classe raiz
ya-{componente}-{tema}           ← variante de cor (ex: ya-btn-primary)
ya-{componente}-{tamanho}        ← variante dimensional (ex: ya-btn-sm)
ya-{componente}-{estado}         ← estado visual (ex: ya-modal-open)
ya-{componente}-{slot}           ← região interna pública (ex: ya-pagination-list)
```

---

## Sistema de Ícones

### Arquitetura
- **`Icon.cs`** (Forma C) — componente que recebe `Enum Kind` e delega para `IIconContentFactory`
- **`IconFragment`** — `delegate RenderFragment(string? classes, Dictionary<string, object>? attrs)`
- **`WellKnownIcons`** — registro estático de `IconFragment` por nome semântico (Close, Menu, Success, etc.)
- **`RoyalCode.Razor.Icons.Bootstrap`** — implementação dos ícones Bootstrap (preenche `WellKnownIcons`)

### Uso em componentes
```razor
<Icon Kind="MyEnum.SomeIcon" />          ← via IIconContentFactory
@WellKnownIcons.Close("text-sm")         ← fragmento direto com classes
```

---

## Sistema de Animações

### Tipos
- **`AnimationFragment`** — `delegate RenderFragment(RenderFragment content)` — wrapping de conteúdo
- **`RotationMotion`** — anima com `ya-rotation` ou `ya-rotation-clockwise` (atributos HTML)
- **`RotateEffect`** — rotação estática via CSS var `--rotate-effect-deg`

### Uso em botão
```razor
<Button Icon="MyIcons.Load" IconAnimation="@((content) => @<RotationMotion>@content</RotationMotion>)" />
```

---

## DI (Dependency Injection)

Cada pacote que precisa de serviços expõe extension method:
```csharp
services.AddYasamenCommons();
services.AddYasamenNotification();   // Alerts
services.AddYasamenModal();          // Modals
services.AddYasamenOffCanvas();      // OffCanvas
services.AddYasamenMenu();           // Layouts.Apps (MenuService)
```

**Lifetimes**: serviços de estado de UI → `Scoped`; módulos JS → `Transient`.

---

## Parâmetros Obrigatórios em Todo Componente Visual

Todo componente público DEVE ter:
```csharp
[Parameter]
public string? AdditionalClasses { get; set; }

[Parameter(CaptureUnmatchedValues = true)]
public Dictionary<string, object>? AdditionalAttributes { get; set; }
```
- `AdditionalClasses` é separado de `AdditionalAttributes` (não sobrescreve as classes do componente)
- No markup: `<div class="@Classes" @attributes="AdditionalAttributes">`

---

## Cascading Values

Padrão usado para propagação de contexto entre componentes pai/filho:
- `ButtonGroupContext` → propagado pelo `ButtonGroup` para `Button`/`IconButton`
- `ContainerContext` → propagado pelo `Container` para `Slot`
- `AppLayoutContext` → propagado pelo `AppLayout` para toda a árvore
- `AppMenuContext` → propagado pelo `AppMenu` para `AppMenuList`/`AppMenuItem`
- `OffCanvasHandler` → propagado pelo `OffCanvas` para `CloseOffCanvasButton`/`AsideBox`
- `DropContentType` → propagado pelo `DropBase` para `DropItem`
- `ModalContext` → propagado pelo `Modal` para conteúdo interno

---

## Outlets (SectionContent Pattern)

Modals, OffCanvas e Notifications usam o padrão `SectionContent`/`SectionOutlet`:
- `Modal` → registra em `ModalService` → renderizado pelo `ModalOutlet` (interno ao `AppLayout`)
- `OffCanvas` → registra em `OffCanvasService` → renderizado pelo `OffCanvasOutlet`
- `Notification` → gerenciado pelo `NotificationService` → renderizado pelo `NotificationOutlet`

Regra: estes outlets são injetados automaticamente pelo `AppLayout`. Em aplicações sem `AppLayout`, devem ser incluídos manualmente.

---

## Convenções de Nomenclatura

| Contexto | Convenção |
|---|---|
| Componentes públicos | PascalCase, sem prefixo (`Button`, `Modal`, `Pagination`) |
| Componentes internos | Idem, mas em `Internal/` e namespace `RoyalCode.Razor.Internal.*` |
| CSS classes | `ya-{componente}` com prefixo `ya-` sempre |
| Enums de parâmetro | PascalCase singular (`Themes`, `Sizes`, `Positions`) |
| Event callbacks | `On{Ação}` (`OnClick`, `OnClose`, `OnPageChanged`) |
| Handlers programáticos | `{Componente}Handler` (`ModalHandler`, `OffCanvasHandler`, `DropHandler`) |
| DI extensions | `AddYasamen{Pacote}()` |

---

## Criando um Novo Componente

1. Identificar o pacote correto baseado nas dependências necessárias
2. Criar `Components/MyComponent.razor` (ou `.razor` + `.razor.cs`)
3. Namespace: `namespace RoyalCode.Razor.Components;`
4. Classe raiz CSS: `ya-{nome-em-kebab}`
5. CSS: criar em `RoyalCode.Razor.Styles/wwwroot/css/components/` e importar em `yasamen.css`
6. Se precisar de serviço: criar em `Internal/` e expor via `Extensions/AddYasamenXXX()`
7. Incluir `AdditionalClasses` e `AdditionalAttributes` obrigatoriamente
8. Usar `EmptyFragment.Delegate` como default de `RenderFragment?` opcionais
9. Verificar slots com `.IsNotEmptyFragment()` e textos com `.IsPresent()`
