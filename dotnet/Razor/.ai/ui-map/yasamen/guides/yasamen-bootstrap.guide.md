# Yasamen Bootstrap Guide

## Objetivo
Garantir que uma aplicação Blazor que usa Yasamen tenha serviços, estilos, ícones, imports e renderização base configurados antes da IA gerar telas.

## Quando usar
Use este guide sempre que a IA gerar ou revisar:
- `Program.cs` de app Blazor WebAssembly, Server ou Web App interativo.
- `App.razor`, `_Imports.razor` ou layout raiz.
- Tela que dependa de estilos Yasamen, Bootstrap Icons, menu, modal, offcanvas ou notificações.

## Decisão corporativa
A aplicação que usa Yasamen deve seguir o bootstrap demonstrado nos projetos de docs: registrar os serviços Yasamen no container, inicializar Bootstrap Icons, carregar `<YasamenStyles />`, importar namespaces Yasamen e mapear os assemblies/componentes interativos quando houver host server + client.

## Regras
- Sempre chame `BootstrapIcons.Include();` antes de construir a aplicação quando usar `WellKnownIcons`, `Icon`, `IconButton` ou componentes que dependam dos ícones conhecidos.
- Sempre registre `builder.Services.AddYasamenCommons();` em apps que usam componentes Yasamen; ele registra módulos JS como `ClickJs`, `ElementJs`, `FormsJs` e `RippleJs`.
- Registre serviços por capacidade usada: `AddYasamenModal()`, `AddYasamenOffCanvas()`, `AddYasamenNotification()` e `AddYasamenMenu()`.
- Ao usar menu, registre também a configuração de itens, como `builder.Services.AddMenuItems();` ou uma configuração equivalente de `MenuOptions`.
- Em `App.razor`, carregue Bootstrap Icons CSS e `<YasamenStyles />`; não substitua isso por links manuais para CSS interno quando estiver apenas gerando telas.
- Em aplicação host server + client, use `AddRazorComponents().AddInteractiveServerComponents().AddInteractiveWebAssemblyComponents()` e mapeie `App` com render modes interativos e `AddAdditionalAssemblies(...)`.
- Em app WebAssembly puro, use `WebAssemblyHostBuilder.CreateDefault(args)` e registre os mesmos serviços Yasamen usados pela tela.
- Em `_Imports.razor`, importe namespaces Yasamen usados por páginas e componentes para evitar exemplos com nomes totalmente qualificados desnecessários.
- Não gere telas que dependam de modal, offcanvas ou notificações sem garantir que o app usa `AppLayout`/`AppMainLayout` ou outro caminho que renderize os outlets.
- Não use documentação externa para decidir setup de Yasamen sem autorização explícita; a referência oficial desta rodada é o repo local.

## Exemplos / Passo-a-passo

### Bootstrap WebAssembly

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RoyalCode.Razor.Icons.Bootstrap;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

BootstrapIcons.Include();

builder.Services.AddYasamenCommons();
builder.Services.AddYasamenModal();
builder.Services.AddYasamenOffCanvas();
builder.Services.AddYasamenNotification();
builder.Services.AddYasamenMenu();

builder.Services.AddMenuItems();

await builder.Build().RunAsync();
```

### Bootstrap server com client adicional

```csharp
using RoyalCode.Razor.Docs.Components;
using RoyalCode.Razor.Docs.Client;
using RoyalCode.Razor.Icons.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

BootstrapIcons.Include();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddYasamenCommons();
builder.Services.AddYasamenModal();
builder.Services.AddYasamenOffCanvas();
builder.Services.AddYasamenNotification();
builder.Services.AddYasamenMenu();

builder.Services.AddMenuItems();

var app = builder.Build();

app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(RoyalCode.Razor.Docs.Client._Imports).Assembly);

app.Run();
```

### App raiz

```razor
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.13.1/font/bootstrap-icons.min.css">
    <YasamenStyles />
    <ImportMap />
    <HeadOutlet />
</head>
<body>
    <Routes @rendermode="InteractiveAuto" />
    <script src="_framework/blazor.web.js"></script>
</body>
</html>
```

### Imports mínimos para páginas Yasamen

```razor
@using Microsoft.AspNetCore.Components.Forms
@using RoyalCode.Razor.Components
@using RoyalCode.Razor.Animations
@using RoyalCode.Razor.Commons
@using RoyalCode.Razor.Icons
@using RoyalCode.Razor.Icons.Bootstrap
@using RoyalCode.Razor.Layouts.Apps
@using RoyalCode.Razor.Layouts.Models
@using RoyalCode.Razor.Styles
```

## Anti-padrões
- Não gerar `<IconButton>`, `WellKnownIcons` ou `Icon` sem `BootstrapIcons.Include()` e Bootstrap Icons CSS.
- Não usar componentes com ripple, forms JS ou helpers de DOM sem `AddYasamenCommons()`.
- Não criar uma página com `Notify`, `Modal` ou `OffCanvas` assumindo que os outlets existem fora de `AppLayout`/`AppMainLayout`.
- Não copiar links diretos para `yasamen.dist.css`, `yasamen.min.css` ou `styles.bundle.css` dentro de páginas; use `<YasamenStyles />`.
- Não registrar todos os serviços como regra cega em bibliotecas isoladas; registrar no app consumidor ou host.

## Fontes
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Program.cs`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs/Program.cs`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs/Components/App.razor`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/_Imports.razor`
- `RoyalCode.Razor.Commons/Extensions/YasamenServiceCollectionExtensions.cs`
- `RoyalCode.Razor.Modals/Extensions/ModalServiceCollectionExtensions.cs`
- `RoyalCode.Razor.OffCanvas/Extensions/OffCanvasServiceCollectionExtensions.cs`
- `RoyalCode.Razor.Alerts/Extensions/AlertServiceCollectionExtensions.cs`
- `RoyalCode.Razor.Layouts.Apps/Extensions/LayoutAppsServiceCollectionExtensions.cs`
