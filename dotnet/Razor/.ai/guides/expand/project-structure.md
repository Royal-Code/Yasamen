# Estrutura de Projetos

> Como a biblioteca esta organizada em projetos, quais dependencias existem de fato e como estruturar novos pacotes.

---

## Visao Geral

A solucao `RoyalCode.Razor` e composta por varios projetos `Microsoft.NET.Sdk.Razor`. Cada pacote tem responsabilidade propria e pode ser consumido isoladamente.

Para evitar leitura errada da arquitetura, e importante separar:

1. **visao logica**: como os pacotes se organizam conceitualmente;
2. **referencias diretas**: quais `<ProjectReference>` existem hoje nos `.csproj`.

---

## Visao Logica

```text
Base
  - RoyalCode.Razor.Styles
  - RoyalCode.Razor.Icons
  - RoyalCode.Razor.Animations
  - RoyalCode.Razor.Commons

Componentes e infra de UI
  - RoyalCode.Razor.Buttons
  - RoyalCode.Razor.Drops
  - RoyalCode.Razor.Forms
  - RoyalCode.Razor.Alerts
  - RoyalCode.Razor.Breadcrumbs
  - RoyalCode.Razor.Modals
  - RoyalCode.Razor.OffCanvas
  - RoyalCode.Razor.Layouts

Composicao de aplicacao
  - RoyalCode.Razor.Layouts.Apps
```

Essa visao e conceitual. Ela ajuda a manter o desenho da biblioteca, mas nao deve ser copiada mecanicamente para os `.csproj`.

---

## Referencias Diretas Atuais

| Projeto | Referencias diretas |
|---|---|
| `RoyalCode.Razor.Styles` | *(nenhuma)* |
| `RoyalCode.Razor.Icons` | *(nenhuma)* |
| `RoyalCode.Razor.Animations` | *(nenhuma)* |
| `RoyalCode.Razor.Commons` | `Styles` |
| `RoyalCode.Razor.Buttons` | `Animations`, `Commons`, `Icons` |
| `RoyalCode.Razor.Drops` | `Buttons` |
| `RoyalCode.Razor.Forms` | `Buttons` |
| `RoyalCode.Razor.Alerts` | `Commons`, `Icons` |
| `RoyalCode.Razor.Breadcrumbs` | `Drops` |
| `RoyalCode.Razor.Modals` | `Commons`, `Styles` |
| `RoyalCode.Razor.OffCanvas` | `Buttons`, `Styles` |
| `RoyalCode.Razor.Layouts` | `Commons` |
| `RoyalCode.Razor.Layouts.Apps` | `Alerts`, `Breadcrumbs`, `Layouts`, `Modals`, `OffCanvas` |

### Regras

- Nunca criar dependencia circular.
- Adicionar apenas referencias diretas realmente necessarias.
- Nao inflar o `.csproj` com dependencias "conceituais" que entram apenas por analogia.

---

## Estrutura Basica de um `.csproj`

```xml
<Project Sdk="Microsoft.NET.Sdk.Razor">

    <Import Project="..\\pack.targets" />

    <PropertyGroup>
        <TargetFramework>$(RuntimeVer)</TargetFramework>
        <RootNamespace>RoyalCode.Razor</RootNamespace>
    </PropertyGroup>

    <ItemGroup>
        <SupportedPlatform Include="browser" />
    </ItemGroup>

    <ItemGroup>
        <PackageReference Include="Microsoft.AspNetCore.Components.Web" Version="$(AspNetVer)" />
    </ItemGroup>

    <ItemGroup>
        <ProjectReference Include="..\\RoyalCode.Razor.Commons\\RoyalCode.Razor.Commons.csproj" />
    </ItemGroup>

</Project>
```

### Variaveis centrais

| Variavel | Uso |
|---|---|
| `$(RuntimeVer)` | `TargetFramework` compartilhado |
| `$(AspNetVer)` | versao do pacote ASP.NET |
| `$(LibVer)` | versao do pacote NuGet |

**Regra:** nao hardcodar versoes no `.csproj`.

---

## Namespaces

| Contexto | Namespace |
|---|---|
| Componentes publicos | `RoyalCode.Razor.Components` |
| Infra interna | `RoyalCode.Razor.Internal.<NomeProjeto>` |
| Extensoes de DI | `Microsoft.Extensions.DependencyInjection` |
| Extensoes utilitarias | `RoyalCode.Razor.Commons.Extensions` |
| Enums e builders de estilo | `RoyalCode.Razor.Styles` |

O `RootNamespace` e `RoyalCode.Razor` para manter coerencia entre componentes publicos, tipos internos e arquivos `.razor`.

---

## `_Imports.razor`

Cada pacote Razor tem um `_Imports.razor` na raiz. Exemplo comum:

```razor
@using Microsoft.AspNetCore.Components.Web

@using RoyalCode.Razor.Commons
@using RoyalCode.Razor.Icons
@using RoyalCode.Razor.Styles
```

Pacotes que usam animacoes podem incluir:

```razor
@using RoyalCode.Razor.Animations
```

### Regra real para namespaces internos

O steering anterior estava rigido demais. A regra correta e:

- `RoyalCode.Razor.Internal.*` nao faz parte da API publica do pacote;
- em arquivos publicos isolados, prefira usar namespaces internos apenas onde forem necessarios;
- no `_Imports.razor` **do proprio pacote**, e aceitavel incluir `@using RoyalCode.Razor.Internal.*` quando isso simplifica a implementacao interna dos componentes Razor.

Em outras palavras: namespace interno no `_Imports.razor` do pacote e um detalhe de implementacao valido. O que nao pode acontecer e trata-lo como contrato para consumidores externos.

---

## Estrutura Interna de Pastas

```text
RoyalCode.Razor.XYZ/
|-- _Imports.razor
|-- RoyalCode.Razor.XYZ.csproj
|-- Components/
|   |-- MyComponent.razor
|   |-- MyComponent.razor.cs
|   `-- MyComponent.cs
|-- Internal/
|   `-- XYZ/
|       |-- InternalHelper.cs
|       `-- InternalComponent.razor
`-- Extensions/
    `-- XYZServiceCollectionExtensions.cs
```

### Regras

- `Components/` e a superficie publica do pacote.
- `Internal/` concentra infraestrutura e componentes que nao devem ser consumidos diretamente.
- `Extensions/` concentra integracao publica, principalmente DI.

---

## Criando um Novo Projeto

1. Copiar o `.csproj` de um pacote semelhante.
2. Ajustar nome do projeto e referencias diretas.
3. Criar `_Imports.razor` com os `@using` realmente necessarios.
4. Adicionar o projeto em `Razor.sln`.
5. Criar `Components/`, `Internal/` e `Extensions/` conforme o papel do pacote.
6. Se houver integracao DI, expor `AddYasamenXYZ(this IServiceCollection services)`.

---

## Padrao para DI

Cada pacote que precisa registrar servicos deve expor uma extensao no namespace `Microsoft.Extensions.DependencyInjection`.

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

Exemplos reais:

- `AddYasamenCommons()`
- `AddYasamenNotification()`
- `AddYasamenModal()`
- `AddYasamenOffCanvas()`
- `AddYasamenMenu()`

### Lifetimes

- JS modules tendem a `Transient`.
- Servicos de estado de UI tendem a `Scoped`.
- Utilitarios sem estado podem ser `Transient` ou estaticos.

