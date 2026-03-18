# Design — Pagination

## Decisões de Estrutura

- Implementar `Pagination` no novo pacote `RoyalCode.Razor.Navigation`.
- Usar `namespace RoyalCode.Razor.Components` para o componente público.
- Usar `namespace RoyalCode.Razor.Internal.Navigation` para o cálculo da janela de páginas.
- Referências diretas aplicadas no `.csproj`:
  - `RoyalCode.Razor.Commons`, para reaproveitar helpers de `AdditionalAttributes`.
  - `RoyalCode.Razor.Styles`, para `CssClasses` e classes semânticas.
- O primeiro release usa botões nativos estilizados com classes `ya-pagination*`, sem depender de `Button` ou `IconButton`.

## API Pública Proposta

### Componente público

- `Pagination`

### Parâmetros

- `[EditorRequired] int CurrentPage`
- `[EditorRequired] int TotalPages`
- `int? PageSize`
- `bool Loading`
- `int DesktopWindowSize = 7`
- `EventCallback<int> OnPageChanged`
- `string? PreviousLabel`
- `string? NextLabel`
- `string? AdditionalClasses`
- `Dictionary<string, object>? AdditionalAttributes`

### Eventos e comportamento

- `OnPageChanged` só dispara quando o destino é válido e diferente da página atual.
- A navegação para primeira e última página é exibida apenas no Desktop.
- Quando `TotalPages <= 1`, o componente continua renderizando apenas se isso for desejável para manter layout estável; a recomendação inicial é ocultar o componente.
- `PageSize` entra apenas como dado informativo nesta release e não altera o resumo renderizado.

## Estrutura Interna

Arquivos previstos:

- `Components/Pagination.razor`
- `Components/Pagination.razor.cs`
- `Internal/Navigation/PaginationWindow.cs`
- `Internal/Navigation/PaginationWindowBuilder.cs`

Estratégia:

- O cálculo da janela numérica deve ficar isolado em helper interno testável.
- O componente deve tratar cliques em páginas inválidas como no-op.
- O markup deve usar um `<nav>` com lista de itens e botões internos.

## CSS e Contrato Visual

- Criar `RoyalCode.Razor.Styles/wwwroot/css/components/pagination.css`.
- Registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- Classes públicas previstas:
  - `ya-pagination`
  - `ya-pagination-desktop`
  - `ya-pagination-list`
  - `ya-pagination-item`
  - `ya-pagination-link`
  - `ya-pagination-control`
  - `ya-pagination-link-active`
  - `ya-pagination-link-disabled`
  - `ya-pagination-ellipsis`
  - `ya-pagination-mobile`
  - `ya-pagination-mobile-summary`
  - `ya-pagination-loading`
- Não criar `Pagination.razor.css`.

## Testes e Documentação

- Cobrir:
  - janela numérica no começo, meio e fim;
  - estado `Loading`;
  - clique em primeira, anterior, próxima e última;
  - renderização compacta em Mobile;
  - `aria-current` da página ativa.
- Adicionar showcase no `RoyalCode.Razor.Docs.Client`.

## Showcase no Docs

- Rota inicial: `/demo/navigation/pagination`.
- Página alvo: `RoyalCode.Razor.Docs.Client/Pages/Demo/Navigation/PaginationPage.razor`.
- Menu: grupo `Navigation` em `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`.
- Estrutura mínima da página:
  - introdução curta;
  - seção `Básico`;
  - seção `Janela Numérica`;
  - seção `Estados`;
  - seção `Integração com Lista`.
- A página deve mostrar o comportamento em largura reduzida com um contêiner `max-width` estreito.

## Riscos e Questões em Aberto

- Decisão tomada: usar botões nativos estilizados para manter a API enxuta e sem dependência extra de ícones.
- Decisão tomada: `PageSize` permanece informativo, reservado para integrações futuras.
- Decisão tomada: ocultar quando `TotalPages <= 1` para evitar ruído visual em listas sem paginação efetiva.

## Validação Esperada

- `dotnet build` do pacote novo e do `RoyalCode.Razor.Docs.Client`.
- Testes cobrindo janela numérica, loading, limites e `aria-current`.
- Validação manual do showcase em `/demo/navigation/pagination`.
- Atualização da nota correspondente no `ui-map.md` após a entrega.

