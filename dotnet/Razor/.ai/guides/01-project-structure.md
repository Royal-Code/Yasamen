# Guide 01 — Estrutura de Projetos

> Como a biblioteca é organizada em projetos, quais são as dependências entre eles e como criar um novo pacote.

---

## Visão Geral da Solução

A biblioteca **RoyalCode.Razor** é organizada em múltiplos projetos `SDK="Microsoft.NET.Sdk.Razor"`, cada um com uma responsabilidade clara. Não existe um projeto monolítico — cada grupo de componentes tem seu próprio pacote NuGet.

### Grafo de Dependências

```
RoyalCode.Razor.Styles          (zero deps — raiz de estilos)
      ↑
RoyalCode.Razor.Icons           (depende: Styles)
      ↑
RoyalCode.Razor.Animations      (depende: Styles)
      ↑
RoyalCode.Razor.Commons         (depende: Styles, Icons, Animations implicitamente via Extensions)
      ↑                ↑
RoyalCode.Razor.Buttons    RoyalCode.Razor.Alerts
(Commons, Animations,       (Commons, Icons)
 Icons)
      ↑
RoyalCode.Razor.Drops       (Commons, Icons, Animations, Buttons)
      ↑
RoyalCode.Razor.Forms       (Commons, Styles, Buttons)
      ↑
RoyalCode.Razor.Breadcrumbs (Commons, Drops, Icons)
RoyalCode.Razor.Modals      (Commons)
RoyalCode.Razor.OffCanvas   (Commons)
      ↑
RoyalCode.Razor.Layouts     (Commons, Styles)
      ↑
RoyalCode.Razor.Layouts.Apps (Commons, Styles, Buttons, OffCanvas, Modals, Alerts, Breadcrumbs, Icons, Layouts)
```

**Regra:** nunca criar dependência circular. Projetos de UI de baixo nível (Styles, Icons, Commons) **não dependem** de projetos de componente.

---

## Estrutura do Projeto `.csproj`

Todo projeto de componentes segue este padrão:

```xml
<Project Sdk="Microsoft.NET.Sdk.Razor">

    <!-- Importa configurações de empacotamento NuGet -->
    <Import Project="..\pack.targets" />

    <PropertyGroup>
        <!-- Usa a variável do Directory.Build.props -->
        <TargetFramework>$(RuntimeVer)</TargetFramework>
        <!-- Namespace raiz sempre igual para componentes públicos -->
        <RootNamespace>RoyalCode.Razor</RootNamespace>
    </PropertyGroup>

    <ItemGroup>
        <!-- Obrigatório em projetos Blazor para browser -->
        <SupportedPlatform Include="browser" />
    </ItemGroup>

    <ItemGroup>
        <PackageReference Include="Microsoft.AspNetCore.Components.Web" Version="$(AspNetVer)" />
    </ItemGroup>

    <ItemGroup>
        <!-- Dependências do projeto — apenas o necessário -->
        <ProjectReference Include="..\RoyalCode.Razor.Commons\RoyalCode.Razor.Commons.csproj" />
    </ItemGroup>

</Project>
```

### Variáveis Centrais (`Directory.Build.props`)

| Variável | Valor | Uso |
|---|---|---|
| `$(RuntimeVer)` | `net10.0` | TargetFramework de todos os projetos |
| `$(AspNetVer)` | `10.0.1` | Versão do pacote ASP.NET |
| `$(LibVer)` | `0.0.0.1` | Versão do NuGet (todos os projetos têm a mesma versão) |

**Regra:** nunca hardcodar versões no `.csproj`. Usar sempre as variáveis do `Directory.Build.props`.

---

## Namespace Padrão

| Contexto | Namespace |
|---|---|
| Componentes públicos (`.razor` e `.cs`) | `RoyalCode.Razor.Components` |
| Componentes internos (não para consumo direto) | `RoyalCode.Razor.Internal.<NomeProjeto>` |
| Extensões de DI (`IServiceCollection`) | `Microsoft.Extensions.DependencyInjection` |
| Extensões gerais de utilidade | `RoyalCode.Razor.Commons.Extensions` |
| Estilos e enums | `RoyalCode.Razor.Styles` |

O `RootNamespace` do `.csproj` é sempre `RoyalCode.Razor` para que o compilador resolva corretamente.

---

## Arquivo `_Imports.razor`

Todo projeto de componentes tem um `_Imports.razor` na raiz com os usings globais para os arquivos `.razor`:

```razor
@using Microsoft.AspNetCore.Components.Web

@using RoyalCode.Razor.Commons
@using RoyalCode.Razor.Icons
@using RoyalCode.Razor.Styles
```

Projetos que usam animações adicionam:
```razor
@using RoyalCode.Razor.Animations
```

**Regra:** `@using` de namespaces internos (ex: `RoyalCode.Razor.Internal.*`) **não entram** em `_Imports.razor` — são resolvidos apenas nos arquivos onde são necessários.

---

## Estrutura de Pastas Dentro de um Projeto

```
RoyalCode.Razor.XYZ/
├── _Imports.razor              # Usings globais do projeto
├── RoyalCode.Razor.XYZ.csproj
├── Components/                 # Componentes públicos
│   ├── MyComponent.razor
│   ├── MyComponent.razor.cs    # Code-behind (quando necessário)
│   └── MyComponent.cs          # Alternativa: componente 100% C# (sem .razor)
├── Internal/                   # Infraestrutura interna (não pública)
│   └── XYZ/
│       ├── InternalHelper.cs
│       └── InternalComponent.razor
└── Extensions/                 # Extensões de DI e utilitários públicos
    └── XYZServiceCollectionExtensions.cs
```

**Regra:** pasta `Internal/` agrupa tudo que **não** deve ser usado diretamente pelo consumidor do pacote. Pasta `Components/` é a API pública.

---

## Criando um Novo Projeto

1. Copiar o `.csproj` de um projeto existente similar e ajustar o nome.
2. Criar `_Imports.razor` com os usings necessários.
3. Adicionar o projeto à solução `Razor.sln`.
4. Adicionar `<ProjectReference>` apenas nos projetos que este **consome** (não o inverso).
5. Se o projeto registra serviços DI, criar `Extensions/XYZServiceCollectionExtensions.cs` com método `AddYasamenXYZ(this IServiceCollection services)`.

---

## Registros DI — Padrão

Cada projeto que precisa de DI cria uma extensão no namespace `Microsoft.Extensions.DependencyInjection`:

```csharp
namespace Microsoft.Extensions.DependencyInjection;

public static class XYZServiceCollectionExtensions
{
    public static IServiceCollection AddYasamenXYZ(this IServiceCollection services)
    {
        services.AddScoped<MyService>();
        return services;
    }
}
```

| Projeto | Método DI |
|---|---|
| Commons | `AddYasamenCommons()` |
| Alerts (Notifications) | `AddYasamenNotification()` |

**Regra de lifetime:** JS Modules → `Transient`. Serviços de estado de UI (ex: NotificationService) → `Scoped`. Utilitários sem estado → `Transient` ou estático.
