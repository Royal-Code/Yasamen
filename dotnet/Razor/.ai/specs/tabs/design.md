# Design — Tabs

## Decisões de Estrutura

- Criar um novo pacote `RoyalCode.Razor.Navigation`.
- Usar `namespace RoyalCode.Razor.Components` para `Tabs` e `Tab`.
- Usar `namespace RoyalCode.Razor.Internal.Navigation` para tipos de apoio.
- Referências diretas recomendadas no `.csproj`:
  - `RoyalCode.Razor.Commons` para `EmptyFragment`, helpers de fragmento e geração de IDs.
  - `RoyalCode.Razor.Styles` para `CssClasses`, enums semânticos e montagem de classes.
- Não adicionar DI nem `Extensions/` neste primeiro componente, porque o comportamento é puramente declarativo.

## API Pública Proposta

### Componentes públicos

- `Tabs`
- `Tab`

### Parâmetros do `Tabs`

- `string? ActiveTab`
- `EventCallback<string?> ActiveTabChanged`
- `EventCallback<string?> OnTabChanged`
- `TabOrientation Orientation = TabOrientation.Horizontal`
- `RenderFragment ChildContent`
- `string? AdditionalClasses`
- `Dictionary<string, object>? AdditionalAttributes`

### Parâmetros do `Tab`

- `[EditorRequired] string Value`
- `[EditorRequired] string Title`
- `bool Disabled`
- `string? BadgeText`
- `RenderFragment ChildContent`

### Slots e eventos

- O conteúdo de cada `Tab` será projetado no painel ativo.
- A troca de aba deve ocorrer por clique e por teclado.
- O `Tabs` é o dono do estado ativo; `Tab` é declarativo.

## Estrutura Interna

Arquivos previstos:

- `Components/Tabs.razor`
- `Components/Tabs.razor.cs`
- `Components/Tab.razor`
- `Components/Tab.razor.cs`
- `Internal/Navigation/TabsContext.cs`
- `Internal/Navigation/TabRegistration.cs`

Estratégia:

- `Tabs` fornece um contexto em cascata para as `Tab`.
- Cada `Tab` registra metadados no pai durante o ciclo de vida.
- O cabeçalho é renderizado pelo `Tabs`, não pelas `Tab`.
- Os IDs de `tab` e `tabpanel` devem ser gerados de forma estável para suportar ARIA.

## CSS e Contrato Visual

- Criar `RoyalCode.Razor.Styles/wwwroot/css/components/tabs.css`.
- Registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- Classes públicas previstas:
  - `ya-tabs`
  - `ya-tabs-list`
  - `ya-tabs-vertical`
  - `ya-tab`
  - `ya-tab-active`
  - `ya-tab-disabled`
  - `ya-tab-badge`
  - `ya-tab-panel`
- O badge da tab deve ser renderizado com classe própria `ya-tab-badge`, sem depender do componente `Badge`.
- Não criar `Tabs.razor.css` nem `Tab.razor.css`.

## Testes e Documentação

- Criar projeto de testes do pacote quando `RoyalCode.Razor.Navigation` for criado.
- Cobrir:
  - seleção inicial;
  - troca de aba por clique;
  - troca por teclado;
  - tab desabilitada;
  - modo controlado;
  - renderização vertical.
- Adicionar showcase no `RoyalCode.Razor.Docs.Client`.

## Showcase no Docs

- Rota inicial: `/demo/navigation/tabs`.
- Página alvo: `RoyalCode.Razor.Docs.Client/Pages/Demo/Navigation/TabsPage.razor`.
- Menu: grupo `Navigation` em `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`.
- Estrutura mínima da página:
  - introdução curta;
  - seção `Básico`;
  - seção `Orientação`;
  - seção `Estados`;
  - seção `Largura reduzida`.
- O showcase deve usar apenas `Tabs` e `Tab` públicos, sem `RoyalCode.Razor.Internal.*`.

## Riscos e Questões em Aberto

- Decidir se `TabOrientation` será enum novo do pacote ou se vale reaproveitar um enum já existente.
- Decidir se o primeiro release deve expor apenas `BadgeText` ou também um slot de cabeçalho customizado.
- Decidir se painéis inativos ficam fora do DOM ou apenas ocultos; a recomendação inicial é renderizar somente o ativo.
