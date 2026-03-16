# Design — EmptyState

## Decisões de Estrutura

- Implementar `EmptyState` em `RoyalCode.Razor.Alerts`.
- Manter `namespace RoyalCode.Razor.Components`.
- Não criar `Internal/` específico neste primeiro release, salvo se surgir helper pequeno de variante.
- Preservar as referências diretas atuais do pacote, evitando adicionar `RoyalCode.Razor.Buttons` agora.
- Reaproveitar `Icon` do pacote atual e padrões visuais próximos a `Feedback`, mas sem fundir os dois componentes.

## API Pública Proposta

### Componente público

- `EmptyState`
- `EmptyStateVariant` como enum público

### Parâmetros

- `EmptyStateVariant Variant = EmptyStateVariant.NoData`
- `string? Title`
- `string? Subtitle`
- `Enum? Icon`
- `RenderFragment Graphic = EmptyFragment.Delegate`
- `RenderFragment ActionContent = EmptyFragment.Delegate`
- `RenderFragment ChildContent = EmptyFragment.Delegate`
- `string? AdditionalClasses`
- `Dictionary<string, object>? AdditionalAttributes`

### Slots e comportamento

- `Graphic` substitui o ícone padrão quando preenchido.
- `ActionContent` hospeda CTA livre, incluindo `Button`, link ou outra composição externa.
- `ChildContent` hospeda descrição expandida, links auxiliares ou filtros aplicados.

## Estrutura Interna

Arquivos previstos:

- `Components/EmptyState.razor`
- `Components/EmptyState.razor.cs`
- `Components/EmptyStateVariant.cs`

Estratégia:

- O componente deve ser simples e declarativo, sem serviço, handler ou outlet.
- O variant pode influenciar classe CSS e ícone padrão sugerido, mas não deve impor textos localizados.
- O markup deve ser semântico e centralizado em um único elemento raiz.

## CSS e Contrato Visual

- Criar `RoyalCode.Razor.Styles/wwwroot/css/components/empty-state.css`.
- Registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- Classes públicas previstas:
  - `ya-empty-state`
  - `ya-empty-state-graphic`
  - `ya-empty-state-title`
  - `ya-empty-state-subtitle`
  - `ya-empty-state-actions`
  - `ya-empty-state-no-data`
  - `ya-empty-state-no-results`
  - `ya-empty-state-no-permission`
- Não criar `EmptyState.razor.css`.

## Testes e Documentação

- Cobrir:
  - renderização mínima;
  - variante padrão;
  - uso com ícone;
  - uso com `Graphic`;
  - uso com `ActionContent`;
  - composição em contêiner pequeno e grande.
- Adicionar showcase no `RoyalCode.Razor.Docs.Client`.

## Showcase no Docs

- Rota inicial: `/demo/feedback/empty-state`.
- Página alvo: `RoyalCode.Razor.Docs.Client/Pages/Demo/Feedback/EmptyStatePage.razor`.
- Menu: grupo `Feedback` em `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`.
- Estrutura mínima da página:
  - introdução curta;
  - seção `NoData`;
  - seção `NoResults`;
  - seção `NoPermission`;
  - seção `Composição com CTA`.
- A página deve mostrar variação em área estreita e em bloco maior.

## Riscos e Questões em Aberto

- Confirmar se `Variant` também deve selecionar `Theme` implicitamente.
- Confirmar se vale oferecer textos padrão opcionais no futuro.
- Confirmar se `Feedback` deve continuar existindo como alternativa genérica, sem overlap excessivo com `EmptyState`.

## Validação Esperada

- `dotnet build` do pacote `RoyalCode.Razor.Alerts` e do `RoyalCode.Razor.Docs.Client`.
- Testes cobrindo variantes, slots e fallback visual.
- Validação manual do showcase em `/demo/feedback/empty-state`.
- Atualização da nota correspondente no `ui-map.md` após a entrega.
