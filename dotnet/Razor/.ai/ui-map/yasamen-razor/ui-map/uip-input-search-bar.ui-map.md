# UIP-INPUT-SEARCH_BAR - Search Bar

## Componentes

**Principais**:

1. TextField
- `cobertura`: campo textual de busca com `Placeholder="Buscar..."`, `@oninput` ou `@onchange` para disparar busca; `@bind-Value` para debounce em C#; adorno de ícone de busca via `Prepend` + `FieldBadge`; botão "limpar" via `IconButton` ao lado;
- `limitações`: sem sugestões/autocomplete nativo; sem botão de limpar integrado com ícone X dentro do campo; sem expansão animada;
- `nota`: 7;
- `justificativa`: campo de busca textual funcional com semântica correta — cobre a variante mais comum sem sugestões.

**Composição**:

1. Bar (com TextField + IconButton)
- `cobertura`: `TextField` de busca + `IconButton` de limpar ao lado (quando necessário); campo de busca com botão "Pesquisar" explícito ao lado;
- `nota`: 7;
- `justificativa`: variante de busca com ação explícita ou botão de limpar posicionado ao lado.

2. Button (Themes.Default / Outline)
- `cobertura`: botão "Pesquisar" explícito para busca não-reativa (por clique);
- `nota`: 7;
- `justificativa`: trigger de busca explícita para coleções grandes onde busca reativa não é adequada.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `sugestões/autocomplete durante digitação`: composição manual com lista dropdown absoluta;
  - `botão X integrado dentro do campo`: compor `<div class="relative">` + `TextField` + `IconButton` absoluto;
  - `indicador de loading dentro do campo`: ícone de spinner manual ao lado direito via composição;
  - `debounce de busca reativa`: `System.Timers.Timer` ou `Task.Delay` em C# com cancellation token.

- `tipo de adaptação`: componente parcial + composição
- `o que precisa ser feito`:
  - Para busca simples (reativa): `TextField` com `@oninput="Buscar"` + debounce em C#;
  - Para busca por clique: `Bar` com `TextField` + `Button "Pesquisar"`;
  - Para busca com limpar: `TextField` + `IconButton X` ao lado ou em div relativo.

## Como usar

### Busca reativa com debounce

```razor
@code {
    private string termoBusca = "";
    private CancellationTokenSource? _cts;

    private async Task OnBuscar(ChangeEventArgs e)
    {
        termoBusca = e.Value?.ToString() ?? "";
        _cts?.Cancel();
        _cts = new CancellationTokenSource();
        try
        {
            await Task.Delay(300, _cts.Token);
            await CarregarResultados(termoBusca);
        }
        catch (TaskCanceledException) { }
    }
}

<TextField Value="@termoBusca" Placeholder="Buscar usuários..."
           @oninput="OnBuscar" />
```

### Busca com botão explícito e limpar

```razor
<Bar AdditionalClasses="mb-4">
    <StartContent AdditionalClasses="flex-1">
        <div class="flex gap-2 w-full">
            <TextField @bind-Value="termoBusca" Placeholder="Buscar..."
                       AdditionalClasses="flex-1" />
            @if (!string.IsNullOrEmpty(termoBusca))
            {
                <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                            OnClick="() => { termoBusca = ""; CarregarResultados(""); }" />
            }
            <Button Style="Themes.Primary" Label="Buscar"
                    Icon="WellKnownIcons.Search" OnClick="() => CarregarResultados(termoBusca)" />
        </div>
    </StartContent>
</Bar>
```

### Busca integrada na barra com filtros

```razor
<Bar AdditionalClasses="mb-4">
    <StartContent AdditionalClasses="flex-1">
        <TextField @bind-Value="termoBusca" Placeholder="Buscar por nome ou código..."
                   AdditionalClasses="w-full max-w-md" @oninput="OnBuscar" />
    </StartContent>
    <EndContent>
        <Button Style="Themes.Secondary" Outline=true Label="Filtros"
                Icon="WellKnownIcons.Filter" OnClick="AbrirFiltros" />
    </EndContent>
</Bar>
```

## Decisão de uso

- `nota geral`: 5;
- `limitações`: sem sugestões/autocomplete nativo; sem botão X integrado dentro do campo; debounce requer lógica C# manual; sem expansão animada; sem histórico de buscas;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `TextField` com `Type="search"` cobre a busca textual simples e reativa;
  - Debounce manual em C# + composição com `Bar`/`IconButton` completa os casos comuns;
  - Nota 5 reflete cobertura parcial — funcional para a maioria dos casos mas sem sugestões nativas.
