# Structure - yasamen

## Visão geral

`yasamen` esta organizado como uma solução Blazor/Razor multi-projeto. Cada pacote funcional vive em um projeto `RoyalCode.Razor.*` com `Microsoft.NET.Sdk.Razor`, `TargetFramework=$(RuntimeVer)`, `SupportedPlatform Include="browser"` e, na maioria dos projetos, `RootNamespace=RoyalCode.Razor`.

Configuração compartilhada:

- `Directory.Build.props`: define `RuntimeVer=net10.0`, nullable/implicit usings, `LibVer=0.0.0.1`, `AspNetVer=10.0.1`.
- `pack.targets`: gera pacote no build, autores Royal Code, repo `https://github.com/Royal-Code/Yasamen`, licenca `AGPL-3.0-only`.
- `test.targets`: xUnit, bUnit e coverlet para projetos `.Tests`.

## Projetos e responsabilidades

| Projeto | Responsabilidade | Componentes principais |
|---|---|---|
| `RoyalCode.Razor.Alerts` | Feedback, badges, notificações e serviço de notify | `Badge`, `Feedback`, `Notification`, `NotificationContent`, internals de notification |
| `RoyalCode.Razor.Animations` | Fragments e wrappers de animação | `RotateEffect`, `RotationMotion`, `Effects`, `Motions` |
| `RoyalCode.Razor.Breadcrumbs` | Breadcrumb manual e gerado por modelo | `Breadcrumb`, `BreadcrumbItem`, `DescribesBreadcrumbs` |
| `RoyalCode.Razor.Buttons` | Botões e agrupamento | `Button`, `IconButton`, `ButtonGroup` |
| `RoyalCode.Razor.Commons` | JS interop, extensoes, ripple, auth helpers | `Ripple`, `ClickJs`, `ElementJs`, `FormsJs`, `RippleJs` |
| `RoyalCode.Razor.Drops` | Dropdown/drop menu | `DropButton`, `DropIconButton`, `DropItem`, `DropBase` interno |
| `RoyalCode.Razor.Forms` | Campo de texto e shell de field | `TextField`, `FieldText`, `FieldBadge`, `FieldAction`, internals de field |
| `RoyalCode.Razor.Icons` | Infraestrutura de ícones | `Icon`, `IconRender`, `WellKnownIcons`, factories |
| `RoyalCode.Razor.Icons.Bootstrap` | Adaptador Bootstrap Icons | `BootstrapIcons.Include()`, `BsIconNames` |
| `RoyalCode.Razor.Layouts` | Primitivas de layout | `Box`, `Bar`, `Container`, `Slot`, `Stack` |
| `RoyalCode.Razor.Layouts.Apps` | Shell de app, sidebars e menu | `AppLayout`, `AppTopBar`, `AppSideBar`, `AppMenu`, `AppMainLayout` |
| `RoyalCode.Razor.Modals` | Modal e service/outlet | `Modal`, `ModalHandler`, internals de modal |
| `RoyalCode.Razor.Navigation` | Paginação | `Pagination` |
| `RoyalCode.Razor.OffCanvas` | Drawer/offcanvas | `OffCanvas`, `AsideBox`, `CloseOffCanvasButton` |
| `RoyalCode.Razor.Styles` | CSS, tokens e builders/classes C# | `YasamenStyles`, `Styles/*.cs`, `wwwroot/css/*` |
| `RoyalCode.Razor.Docs` | App de documentação/demos | pages em `RoyalCode.Razor.Docs.Client/Pages/Demo` |
| `RoyalCode.Razor.Show` | Projeto de exibição/showcase | sem componentes publicos identificados além de `_Imports` |

## Padrão de organizacao de componentes

Padrão principal:

- Componentes de consumo direto ficam em `Components/`.
- Componentes internos ficam em `Internal/{Área}/`.
- Modelos e serviços de app shell ficam em `Layouts/Models/`.
- Componentes de app shell ficam em `Layouts/Apps/`.
- Componentes com lógica maior usam par `.razor` + `.razor.cs` partial.
- Componentes simples mantem markup e `@code` no mesmo `.razor`.
- Serviços de DI entram em `Extensions/*ServiceCollectionExtensions.cs` com namespace `Microsoft.Extensions.DependencyInjection`.

Namespaces observados:

- A maioria dos componentes de UI usa `namespace RoyalCode.Razor.Components`.
- App shell usa `RoyalCode.Razor.Layouts.Apps` e modelos em `RoyalCode.Razor.Layouts.Models`.
- Icon infra usa `RoyalCode.Razor.Icons` e `RoyalCode.Razor.Icons.Factory`.
- Tipos de estilo usam `RoyalCode.Razor.Styles`.
- Internals usam pastas `Internal/*` e namespace derivado do projeto/pasta.

## Imports e dependencias entre projetos

Cada projeto tem `_Imports.razor` local para disponibilizar namespaces comuns. Exemplos concretos:

- `RoyalCode.Razor.Buttons/_Imports.razor`: `Microsoft.AspNetCore.Components.Web`, `RoyalCode.Razor.Commons`, `RoyalCode.Razor.Animations`, `RoyalCode.Razor.Icons`, `RoyalCode.Razor.Styles`.
- `RoyalCode.Razor.Drops/_Imports.razor`: `RoyalCode.Razor.Components`, `RoyalCode.Razor.Icons`, `RoyalCode.Razor.Styles`.
- `RoyalCode.Razor.Layouts.Apps/_Imports.razor`: `RoyalCode.Razor.Components`, `RoyalCode.Razor.Icons`, `RoyalCode.Razor.Layouts.Apps`, `RoyalCode.Razor.Layouts.Models`, `RoyalCode.Razor.Styles`.
- `RoyalCode.Razor.Navigation/_Imports.razor`: `RoyalCode.Razor.Commons.Extensions`, `RoyalCode.Razor.Icons`, `RoyalCode.Razor.Internal.Navigation`, `RoyalCode.Razor.Styles`.

Dependencias de projeto relevantes:

- `Buttons` depende de `Animations`, `Commons`, `Icons`.
- `Drops` depende de `Buttons`.
- `Forms` depende de `Buttons`.
- `Breadcrumbs` depende de `Drops`.
- `Layouts.Apps` depende de `Alerts`, `Breadcrumbs`, `Layouts`, `Modals`, `OffCanvas`.
- `Navigation` depende de `Commons`, `Icons`, `Styles`.
- `Commons` depende de `Styles`.
- `Icons.Bootstrap` depende de `Icons`.
- `Modals` e `OffCanvas` dependem de `Styles` e `Commons`/`Buttons`.

## Padrão de parametros

Convencoes evidenciadas:

- Parametros visuais recorrem a enums compartilhados: `Themes`, `Sizes`, `SpacingSize`, `Positions`, `Directions`, `Fitting`.
- Classes extras usam o nome `AdditionalClasses`.
- Atributos HTML extras usam `[Parameter(CaptureUnmatchedValues = true)]` e nomes como `AdditionalAttributes`, `Attributes` ou `UnmatchedAttributes`.
- Conteúdo usa `RenderFragment ChildContent` ou slots nomeados (`Start`, `Middle`, `End`, `TopStart`, `FooterAction`, etc.).
- Componentes complexos expoem handlers: `ModalHandler`, `OffCanvasHandler`, `DropHandler`.
- Alguns componentes validam parametros em `OnParametersSet`, por exemplo `IconButton`, `Badge`, `OffCanvas`, `AppSideBar`, `Modal`.

## Padrão de estilos

Arquivos fonte de estilo:

- Entrada Tailwind/Yasamen: `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- Reboot/ripple base: `RoyalCode.Razor.Styles/wwwroot/styles.css`.
- Componentes: `RoyalCode.Razor.Styles/wwwroot/css/components/*.css`.
- Forms: `RoyalCode.Razor.Styles/wwwroot/css/forms/*.css`.
- Utilitários customizados: `RoyalCode.Razor.Styles/wwwroot/css/utilities.css`.
- Outputs gerados: `yasamen.dist.css`, `yasamen.min.css`, `styles.bundle.css`.

Convencoes:

- Classes de componentes usam prefixo `ya-`.
- Temas usam classes como `ya-btn-primary`, `ya-badge-danger`, `ya-feedback-success`, `ya-notification-highlight`.
- Tamanhos usam sufixos derivados de `Sizes`: `2xs`, `xs`, `sm`, `md`, `lg`, `xl`, `2xl`.
- Layout de app usa classes `ya-app-*`, topbar `ya-top-bar`, sidebar `ya-side-bar`, menu `ya-app-menu`/`ya-menu-item`.
- Forms usam `ya-field-*`, `ya-input-field`, `ya-control-group`.

## Guia para criar novo componente seguindo o repositório

1. Escolher o projeto por dominio funcional. Exemplo: componente de feedback em `RoyalCode.Razor.Alerts`, componente de layout em `RoyalCode.Razor.Layouts`, componente de input em `RoyalCode.Razor.Forms`.
2. Criar componente público em `Components/{Name}.razor`; se houver lógica/parametros extensos, criar `Components/{Name}.razor.cs` com `public partial class {Name}`.
3. Usar `namespace RoyalCode.Razor.Components` para componentes gerais; usar namespace especifico apenas quando o projeto já faz isso, como `RoyalCode.Razor.Layouts.Apps`.
4. Importar namespaces no `_Imports.razor` do projeto se o componente precisar de tipos compartilhados no markup.
5. Expor `AdditionalClasses` e `AdditionalAttributes` quando o componente renderiza elemento raiz.
6. Usar `CssClasses.AddClass(...)`/extensoes de estilo existentes em vez de concatenacao manual extensa.
7. Nomear classe raiz CSS com prefixo `ya-{component-name}`.
8. Adicionar CSS fonte em `RoyalCode.Razor.Styles/wwwroot/css/components/{component}.css` ou `css/forms/{component}.css`.
9. Importar o CSS novo em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
10. Se houver interop/serviço, registrar por extension method em `Extensions/*ServiceCollectionExtensions.cs`.
11. Adicionar demo em `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/...`.
12. Se houver lógica de contrato, adicionar teste em projeto `.Tests` correspondente ou criar novo projeto de teste seguindo `test.targets`.

## Setup de aplicação observado

No app docs:

- `BootstrapIcons.Include()` registra icons Bootstrap e preenche `WellKnownIcons`.
- `builder.Services.AddYasamenCommons()` registra `ClickJs`, `ElementJs`, `FormsJs`, `RippleJs`.
- `builder.Services.AddYasamenModal()` registra `ModalService`.
- `builder.Services.AddYasamenOffCanvas()` registra `OffCanvasService`.
- `builder.Services.AddYasamenNotification()` registra notification service e `Notify`.
- `builder.Services.AddYasamenMenu()` registra menu service/loader.

Para app shell completo, `AppLayout` já inclui outlets internos de modal, offcanvas e notificação.

