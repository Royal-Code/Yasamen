# UIP-INTERACTION-SELECTION - Blueprint resumido

## Pattern

UIP-INTERACTION-SELECTION — Selection — ver `uip-interaction-selection.ui-map.md`

## Gap coberto

A lib não tem componente de seleção. O gap é orientar o padrão completo: `HashSet<TId>` para estado de seleção, `<input type="checkbox">` por item, realce visual condicional, e `Bar` de ações em lote exibida ao selecionar.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `HashSet<int> selecionados` no componente; `<input type="checkbox">` HTML nativo por item; `bg-primary-50` condicional no item selecionado; `Bar` com `Badge` de contagem + `Button(Excluir)` exibida quando `selecionados.Any()`.

## Componentes usados

- `Bar` — papel: composição (action bar de seleção) — ver `bar.sample.md`
- `Badge` — papel: composição (contador de selecionados) — ver `badge.sample.md`
- `Button` — papel: composição (ações em lote) — ver `button.sample.md`

## Recursos visuais

- `bg-primary-50` — realce visual do item selecionado
- `accent-primary-500` — coloração do checkbox com cor do design system
- `bg-primary-50 rounded-md` — barra de seleção ativa
- `checked="@selecionados.Contains(item.Id)"` — estado do checkbox via binding

## Receita

`HashSet` + checkbox HTML + realce condicional + `Bar` de ações em lote.

```razor
@code {
    private HashSet<int> selecionados = new();

    private void ToggleTodos()
    {
        if (selecionados.Count == itens.Count)
            selecionados.Clear();
        else
            selecionados = itens.Select(x => x.Id).ToHashSet();
    }

    private void ToggleItem(int id)
    {
        if (selecionados.Contains(id)) selecionados.Remove(id);
        else selecionados.Add(id);
    }
}

@* Action bar contextual de seleção *@
@if (selecionados.Any())
{
    <Bar AdditionalClasses="mb-3 p-2 bg-primary-50 rounded-md border border-primary-200">
        <StartContent>
            <input type="checkbox"
                   checked="@(selecionados.Count == itens.Count)"
                   @onchange="ToggleTodos"
                   class="accent-primary-500 mr-2" />
            <Badge Style="Themes.Primary"
                   Text="@($"{selecionados.Count} selecionado{(selecionados.Count > 1 ? "s" : "")}")" />
        </StartContent>
        <EndContent>
            <Button Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                    Label="Exportar" OnClick="ExportarSelecionados" />
            <Button Style="Themes.Danger" Size="Sizes.Small"
                    Label="Excluir" OnClick="ExcluirSelecionados" />
        </EndContent>
    </Bar>
}

@* Lista com seleção *@
@foreach (var item in itens)
{
    <div class="flex items-center gap-3 p-3 border-b border-light-100 transition-colors
                @(selecionados.Contains(item.Id) ? "bg-primary-50" : "hover:bg-light-50")">
        <input type="checkbox"
               checked="@selecionados.Contains(item.Id)"
               @onchange="() => ToggleItem(item.Id)"
               class="accent-primary-500 w-4 h-4 flex-shrink-0" />
        <div class="flex-1 flex items-center gap-3">
            <span class="text-sm font-medium text-dark-600">@item.Nome</span>
            <Badge Style="@item.StatusTema" Text="@item.Status" />
        </div>
        <span class="text-xs text-dark-400">@item.Data.ToString("dd/MM")</span>
    </div>
}
```

## Limites

- Sem `FieldCheckbox` com estilo da lib — `<input type="checkbox">` HTML nativo com `accent-primary-500`;
- Range selection (Shift+click) requer lógica adicional de índice no C# — não incluído aqui;
- Para seleção em `DataTable`, ver `uip-data-data-table.blueprint.md`.
