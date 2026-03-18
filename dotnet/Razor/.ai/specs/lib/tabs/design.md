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

- `string? ActiveTab` — quando fornecido, o componente funciona em modo controlado
- `EventCallback<string?> ActiveTabChanged` — notifica mudança de aba (para `@bind-ActiveTab`)
- `EventCallback<string?> OnTabChanged` — callback simples de mudança, sem binding
- `TabOrientation Orientation = TabOrientation.Horizontal` — enum definido no pacote `Navigation`
- `RenderFragment ChildContent` — obrigatório; deve conter apenas filhos `Tab`
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

- `Tabs` fornece um contexto em cascata (`CascadingValue`) via `TabsContext` para as `Tab`.
- Cada `Tab` registra seus metadados no `TabsContext` durante `OnInitialized` e os remove em `Dispose`.
- O cabeçalho (a lista de botões de aba) é renderizado pelo `Tabs` com base na lista de registros — **não** pelas `Tab`. As `Tab` apenas fornecem os dados e o conteúdo do painel.
- Os IDs são gerados via `YasamenExtensions.GenerateId()` no `Tabs`, com dois derivados por aba: `tab-{id}` e `tabpanel-{id}`.

### Contrato do `TabsContext`

```csharp
internal sealed class TabsContext
{
    // lista ordenada das tabs registradas
    public IReadOnlyList<TabRegistration> Registrations => registrations;

    // aba ativa no momento
    public string? ActiveTab { get; private set; }

    // Registra uma tab; chamado por cada Tab no OnInitialized
    public void Register(TabRegistration registration);

    // Remove uma tab; chamado por cada Tab no Dispose
    public void Unregister(TabRegistration registration);

    // Ativa uma aba; chamado pelo clique ou pelo teclado
    public Task ActivateAsync(string value);

    // Callback para notificar o Tabs pai após mudança
    internal Func<string?, Task>? OnChanged { get; set; }
}
```

### Contrato do `TabRegistration`

```csharp
internal sealed class TabRegistration
{
    public string Value { get; init; }   // obrigatório, estável
    public string Title { get; init; }   // rótulo do botão
    public string? BadgeText { get; init; }
    public bool Disabled { get; init; }
    public RenderFragment ChildContent { get; init; }  // conteúdo do painel
    public string TabId { get; init; }        // id do botão (tab-{gerado})
    public string PanelId { get; init; }      // id do painel (tabpanel-{gerado})
}
```

### Roving Tabindex

- Apenas a aba ativa recebe `tabindex="0"`; todas as demais recebem `tabindex="-1"`.
- No modo horizontal: `ArrowLeft` / `ArrowRight` movem o foco; `Home` / `End` saltam para a primeira/última.
- No modo vertical: `ArrowUp` / `ArrowDown` movem o foco; `Home` / `End` saltam para a primeira/última.
- `Enter` e `Space` ativam a aba com foco (para o padrão em que foco e ativação são separados).
- Tabs desabilitadas são puladas na navegação por teclado.
- O foco deve ser movido via `ElementReference.FocusAsync()` nos botões do cabeçalho.

## CSS e Contrato Visual

- Criar `RoyalCode.Razor.Styles/wwwroot/css/components/tabs.css`.
- Registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- Classes públicas previstas:

| Classe | Uso |
|---|---|
| `ya-tabs` | Container raiz do componente |
| `ya-tabs-vertical` | Modificador de orientação vertical |
| `ya-tabs-list` | O `<div role="tablist">` com os botões |
| `ya-tab` | Botão de gatilho de aba |
| `ya-tab-active` | Estado ativo do botão |
| `ya-tab-disabled` | Estado desabilitado do botão |
| `ya-tab-badge` | Texto de contagem ao lado do rótulo |
| `ya-tab-panel` | Contêiner do conteúdo ativo |

- Estados adicionais a cobrir no CSS: `hover` (não desabilitado), `focus-visible`.
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

## Decisões Fechadas

| Questão | Decisão |
|---|---|
| `TabOrientation` — enum novo ou reaproveitar existente? | Novo enum local em `Internal/Navigation/TabOrientation.cs`; não conflita com enums existentes e mantém o pacote autossuficiente |
| Primeiro release: `BadgeText` string ou slot de cabeçalho customizado? | Apenas `BadgeText` string no primeiro release; slot `HeaderContent` pode ser adicionado depois sem quebrar a API |
| Painéis inativos: fora do DOM ou apenas ocultos? | Fora do DOM — renderizar apenas o painel ativo (`@if (IsActive)`); facilita ciclo de vida e é o comportamento esperado para primeira versão |

## Validação Esperada

- `dotnet build` do pacote novo e do `RoyalCode.Razor.Docs.Client`.
- Testes cobrindo clique, teclado, tab desabilitada e modo controlado.
- Validação manual do showcase em `/demo/navigation/tabs`.
- Atualização da nota correspondente no `ui-map.md` após a entrega.

