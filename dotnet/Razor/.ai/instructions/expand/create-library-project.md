# Instrução Operacional - Criar um Novo Projeto de Biblioteca

> Use este arquivo como base em novos chats para que a IA crie um novo pacote `RoyalCode.Razor.*` de forma consistente com a solução.

## Objetivo

Quando o utilizador pedir para criar um novo projeto de biblioteca, a IA deve criar ou preparar o pacote com estrutura, dependências, namespaces e integração coerentes com o padrão do repositório.

Este fluxo pode ser usado de dois modos:

1. diretamente, quando o pedido for explicitamente de pacote ou projeto novo;
2. como subfluxo técnico de uma spec, quando o `design.md` concluir que o componente precisa de um pacote novo.

Regra de precedência no sistema atual:

- quando o pedido entrar por `.ai/station.md` ou `.ai/lib-spec.md`, o padrão preferencial é `spec-first`;
- esta instrução deve ser usada diretamente apenas quando o utilizador quiser scaffolding explícito ou quando a spec já tiver fechado a necessidade do projeto.

## Fontes Obrigatórias

Antes de criar o projeto, a IA deve ler:

- `.ai/guides/expand/project-structure.md`
- `.ai/guides/expand/styles-and-css.md`, se o pacote tiver componentes visuais
- `.ai/guides/expand/component-anatomy.md`, se o pacote expuser componentes públicos
- `.ai/guides/expand/showcases-and-docs.md`, se o pacote precisar de showcase
- `.ai/guides/expand/css-visual-contract.md`, se houver contrato visual público
- `.ai/guides/expand/outlet-patterns.md`, se o pacote usar service/outlet
- `.ai/guides/expand/navigation-patterns.md`, se o pacote for de navegação
- `.ai/guides/rules/component-composition-and-dependencies.md`, quando houver dúvida sobre reuso, dependências ou ordem de implementação
- `.ai/guides/rules/cross-cutting-component-decisions.md`, para fechar pacote, `Style`, `Size`, tokens, composição, showcase e entrega
- `.ai/roadmap/components-plan-list.md`, quando a criação do pacote estiver ligada a uma família de componentes ainda em planeamento

## Fluxo Obrigatório

### 1. Definir o papel do pacote

A IA deve identificar:

- se o pacote é base, infraestrutura, componente visual, composição de aplicação ou suporte a showcases;
- se ele será consumido isoladamente;
- se ele é um pacote primitivo ou se depende de outro pacote mais básico já existente ou ainda ausente.

### Regra especial quando o fluxo nascer de uma spec

Se esta instrução estiver sendo usada por causa de uma spec:

- o nome do pacote alvo deve vir do `design.md`;
- a necessidade do pacote novo já deve estar justificada na spec;
- as decisões de showcase, dependências e surface pública devem respeitar a spec;
- esta instrução não deve rediscutir o escopo funcional do componente.

### 2. Escolher um projeto semelhante como referência

A IA deve copiar a estrutura de um pacote já existente que tenha papel próximo.

Exemplos:

- pacote de componente visual simples: `RoyalCode.Razor.Breadcrumbs`, `RoyalCode.Razor.Alerts`
- pacote com service/outlet: `RoyalCode.Razor.Modals`, `RoyalCode.Razor.OffCanvas`
- pacote de base: `RoyalCode.Razor.Commons`, `RoyalCode.Razor.Styles`

### 3. Criar o `.csproj`

O projeto deve seguir o padrão:

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

</Project>
```

### Regras do `.csproj`

- não hardcodar versões;
- adicionar apenas `ProjectReference` realmente necessários;
- não inflar dependências por analogia;
- não criar dependência circular.

### 4. Criar a estrutura de pastas

Estrutura padrão:

```text
RoyalCode.Razor.XYZ/
|-- _Imports.razor
|-- RoyalCode.Razor.XYZ.csproj
|-- Components/
|-- Internal/
`-- Extensions/
```

Regras:

- `Components/` é a superfície pública;
- `Internal/` concentra helpers, services e componentes internos;
- `Extensions/` concentra integração pública, principalmente DI.

### 5. Configurar namespaces

Usar:

- `RoyalCode.Razor.Components` para componentes públicos;
- `RoyalCode.Razor.Internal.<NomeProjeto>` para infraestrutura interna;
- `Microsoft.Extensions.DependencyInjection` para extensões de DI.

### 6. Criar `_Imports.razor`

Adicionar apenas os `@using` realmente necessários.

Base comum:

```razor
@using Microsoft.AspNetCore.Components.Web
@using RoyalCode.Razor.Commons
@using RoyalCode.Razor.Styles
```

Opcionalmente:

- `@using RoyalCode.Razor.Icons`
- `@using RoyalCode.Razor.Animations`
- `@using RoyalCode.Razor.Internal.<NomeProjeto>`, quando isso simplificar a implementação interna do próprio pacote

Regra:

- namespace interno no `_Imports.razor` do próprio pacote é aceitável;
- namespace interno não pode virar contrato para consumidores externos.

### 7. Expor integração de DI, quando necessário

Se o pacote registrar serviços, criar:

```csharp
namespace Microsoft.Extensions.DependencyInjection;

public static class XYZServiceCollectionExtensions
{
    public static IServiceCollection AddYasamenXYZ(this IServiceCollection services)
    {
        return services;
    }
}
```

Regra:

- services de estado de UI tendem a `Scoped`;
- JS modules tendem a `Transient`;
- utilitários sem estado podem ser `Transient` ou estáticos.

### 8. Se houver UI, fechar o contrato visual

Se o pacote expuser componentes visuais:

- colocar o CSS público em `RoyalCode.Razor.Styles/wwwroot/css/...`;
- registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`;
- decidir explicitamente `Style: Themes`, `Size: Sizes`, fallback de `Themes.Default` e tokens de `yasamen.css`;
- usar classes públicas `ya-*`.

### 9. Adicionar o projeto à solução

A IA deve incluir o novo projeto em `Razor.sln`.

Se o pacote pedir testes dedicados, avaliar também a criação de `RoyalCode.Razor.<Pacote>.Tests`.

### 10. Criar showcase, quando aplicável

Se o pacote trouxer componente público com demonstração de uso:

- criar página em `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/...`;
- registrar a navegação em `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`;
- seguir o padrão de `showcases-and-docs.md`.

### 11. Validar

A IA deve, ao final:

- executar build dos projetos afetados;
- validar referências e namespaces;
- confirmar que não criou dependências desnecessárias;
- informar limitações ou pontos ainda em aberto.

## Regras de Qualidade

- Usar sempre acentuação.
- Preferir copiar um pacote semelhante e ajustar, em vez de inventar estrutura nova.
- Quando usada por uma spec, agir como subfluxo técnico, não como fluxo paralelo de produto.
- Não criar `*.razor.css` novo em pacote visual sem justificativa arquitetural.
- Não tratar `RoyalCode.Razor.Show` como host atual de showcase.
- Se houver dúvida sobre composição ou pré-requisitos, consultar `components-plan-list.md` no roadmap.

## Prompt Curto Recomendado

```text
Leia `.ai/instructions/expand/create-library-project.md` e crie o projeto `RoyalCode.Razor.Navigation`.
```

Ou:

```text
Leia `.ai/instructions/expand/create-library-project.md` e prepare o novo pacote `RoyalCode.Razor.ButtonGroups`.
```


