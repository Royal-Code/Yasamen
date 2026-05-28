# UIP-INTERACTION-SELECTION - Selection

**GAP — sem cobertura viável**

A biblioteca não provê mecanismo de seleção de itens. Toda lógica de seleção deve ser implementada pelo app com estado C# e HTML nativo.

## Componentes

**Principais**: nenhum.

**Composição**:

1. Button / IconButton
- `cobertura`: pode representar botão de "selecionar tudo" / "desmarcar tudo" na action bar de seleção;
- `limitações`: não tem estado de seleção interno;
- `nota`: 4;
- `justificativa`: serve como ação sobre seleção, não como mecanismo de seleção.

**Descartados**: todos os demais — sem papel em seleção de itens.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `checkbox por item`: sem componente de checkbox — usar `<input type="checkbox">` HTML nativo;
  - `estado selecionado visual`: sem suporte nativo — implementar com classe CSS condicional (`bg-primary-50 border-primary-200`);
  - `seleção múltipla e range`: implementar com estado `HashSet<id>` em C#;
  - `action bar contextual ao selecionar`: usar `Bar` com botões condicionais baseados em contagem de selecionados.

- `tipo de adaptação`: nova implementação + estilos
- `o que precisa ser feito`:
  - Checkbox HTML nativo por item da lista;
  - Estado `HashSet<TId> selecionados` no componente;
  - Classe CSS condicional para visual de seleção;
  - Bar com ações em lote (excluir selecionados, exportar) mostrada condicionalmente quando `selecionados.Any()`.

## Como usar

### Seleção simples com checkbox (implementação manual)

```razor
@code {
    private HashSet<int> selecionados = new();
    
    private void ToggleSelecionado(int id)
    {
        if (selecionados.Contains(id)) selecionados.Remove(id);
        else selecionados.Add(id);
    }
}

@if (selecionados.Any())
{
    <Bar AdditionalClasses="mb-3 p-2 bg-primary-50 rounded-md">
        <StartContent>
            <Badge Style="Themes.Primary" Text="@($"{selecionados.Count} selecionados")" />
        </StartContent>
        <EndContent>
            <Button Style="Themes.Danger" Label="Excluir Selecionados"
                    OnClick="ExcluirSelecionados" />
        </EndContent>
    </Bar>
}

@foreach (var item in itens)
{
    <div class="flex items-center gap-3 p-3 border-b border-light-100
                @(selecionados.Contains(item.Id) ? "bg-primary-50" : "hover:bg-light-50")">
        <input type="checkbox" checked="@selecionados.Contains(item.Id)"
               @onchange="() => ToggleSelecionado(item.Id)" />
        <span class="text-sm text-dark-600">@item.Nome</span>
    </div>
}
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: nenhum componente de seleção nativo; toda lógica de seleção é implementação manual do app;
- `recomendação`: `evitar`
- `justificativa geral`:
  - A biblioteca não provê checkbox, seleção múltipla, range selection nem action bar contextual de seleção;
  - Implementável com HTML nativo + estado C# + classes Tailwind condicionais + `Bar` e `Button` para ações em lote;
  - Nota 0 porque nenhum componente da lib cobre o pattern de seleção diretamente.
