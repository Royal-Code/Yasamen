# UIP-NAV-NAV_STACK - Navigation Stack

**GAP — sem cobertura viável**

Navigation Stack via push/pop de vistas é um padrão primariamente mobile nativo. Para Web, o roteamento hierárquico é provido pelo framework Blazor (NavigationManager + rotas), não pela biblioteca yasamen-razor.

## Componentes

**Principais**: nenhum.
**Composição**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: responsabilidade do framework (Blazor Router)
- `o que precisa ser feito`:
  - Para Web: usar o roteamento Blazor padrão (`NavigationManager.NavigateTo()`); hierarquia de páginas via estrutura de rotas; botão "Voltar" via `NavigationManager.NavigateTo(-1)` ou `NavigateTo(url)`;
  - O histórico do browser já provê push/pop de vistas no modelo web.

## Como usar

```razor
@* Navegação hierárquica via router Blazor — sem componente da lib necessário *@
@page "/usuarios"
<Button Style="Themes.Primary" Label="Ver Detalhes"
        NavigateTo="@($"/usuarios/{item.Id}")" />

@page "/usuarios/{Id:int}"
<Button Style="Themes.Secondary" Outline=true Label="Voltar"
        OnClick="() => NavigationManager.NavigateTo("/usuarios")" />
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: padrão mobile nativo — para web, o Blazor Router provê navegação hierárquica nativamente sem necessidade de componente da lib;
- `recomendação`: `evitar`
- `justificativa geral`:
  - Navigation Stack é coberto pelo framework Blazor via roteamento, não pela biblioteca de componentes;
  - A biblioteca não precisa prover este pattern — é responsabilidade do framework.
