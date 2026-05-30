# UIP-ACTION-COMMAND_PALETTE - Blueprint resumido

## Pattern

UIP-ACTION-COMMAND_PALETTE — Command Palette — ver `uip-action-command-palette.ui-map.md`

## Gap coberto

A lib não tem componente de command palette. O gap é orientar a composição com `Modal + FieldText + lista filtrada` e a navegação por teclado via estado C#.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Modal(HideHeader)` + `FieldText(autofocus)` + lista de `<button>` com estado `indiceAtivo` cobrem o padrão; atalho global `Ctrl+K` requer JS interop.

## Componentes usados

- `Modal` — papel: principal (container overlay) — ver `modal.sample.md`
- `FieldText` — papel: composição (campo de filtro) — ver `field-text.sample.md`
- `Button / IconButton` — papel: composição (trigger) — ver `button.sample.md`

## Recursos visuais

- `max-w-lg w-full mt-24` — modal estreito posicionado no terço superior da tela
- `max-h-64 overflow-y-auto py-1` — lista de resultados com scroll
- `hover:bg-light-100` + `bg-primary-50` — hover e item selecionado
- `HideHeader=true` — remove o cabeçalho padrão do Modal

## Receita

`Modal` com `FieldText` + lista filtrada em C# + navegação via `indiceAtivo`.

```razor
@inject NavigationManager Navigation

@code {
    private Modal? commandPalette;
    private string filtro = "";
    private int indiceAtivo = 0;

    private record CommandItem(string Label, string Icon, string? Url = null,
                               Func<Task>? Acao = null);

    private List<CommandItem> todos =
    [
        new("Novo registro", WellKnownIcons.Add, "/registros/novo"),
        new("Configurações", WellKnownIcons.Settings, "/config"),
        new("Exportar", WellKnownIcons.Export, null, () => Task.CompletedTask),
    ];

    private IEnumerable<CommandItem> Filtrados =>
        string.IsNullOrWhiteSpace(filtro)
            ? todos
            : todos.Where(c => c.Label.Contains(filtro, StringComparison.OrdinalIgnoreCase));

    private async Task AbrirPaleta()
    {
        filtro = "";
        indiceAtivo = 0;
        await commandPalette!.OpenAsync();
    }

    private async Task ExecutarItem(CommandItem item)
    {
        await commandPalette!.CloseAsync();
        if (item.Url is not null)
            Navigation.NavigateTo(item.Url);
        else if (item.Acao is not null)
            await item.Acao();
    }

    private async Task HandleKeyDown(KeyboardEventArgs e)
    {
        var lista = Filtrados.ToList();
        if (e.Key == "ArrowDown")
            indiceAtivo = Math.Min(indiceAtivo + 1, lista.Count - 1);
        else if (e.Key == "ArrowUp")
            indiceAtivo = Math.Max(indiceAtivo - 1, 0);
        else if (e.Key == "Enter" && lista.Count > 0)
            await ExecutarItem(lista[indiceAtivo]);
    }
}

@* Trigger visível *@
<Button Style="Themes.Secondary" Outline=true
        Label="Buscar comandos..."
        Icon="WellKnownIcons.Search"
        AdditionalClasses="text-dark-400 font-normal w-64"
        OnClick="AbrirPaleta" />

<Modal @ref="commandPalette" Id="command-palette" HideHeader=true AdditionalClasses="max-w-lg w-full mt-24">
    <ChildContent>
        <div class="p-2 border-b border-light-200">
            <FieldText @bind-Value="filtro"
                       Placeholder="Buscar comandos..."
                       AdditionalClasses="w-full"
                       @onkeydown="HandleKeyDown"
                       autofocus />
        </div>
        <div class="max-h-64 overflow-y-auto py-1">
            @{var lista = Filtrados.ToList();}
            @if (!lista.Any())
            {
                <p class="text-sm text-dark-400 text-center py-6">
                    Nenhum resultado para "@filtro"
                </p>
            }
            else
            {
                @for (int i = 0; i < lista.Count; i++)
                {
                    var item = lista[i];
                    var idx = i;
                    <button class="w-full flex items-center gap-3 px-4 py-2 text-sm text-left
                                   transition-colors
                                   @(idx == indiceAtivo ? "bg-primary-50 text-primary-700"
                                                        : "hover:bg-light-100 text-dark-600")"
                            @onclick="() => ExecutarItem(item)"
                            @onmouseenter="() => indiceAtivo = idx">
                        <Icon Kind="@item.Icon" class="text-base text-dark-400 flex-shrink-0" />
                        <span>@item.Label</span>
                    </button>
                }
            }
        </div>
    </ChildContent>
</Modal>
```

## Limites

- Atalho global (`Ctrl+K`) requer JS interop com `document.addEventListener('keydown', ...)` — não incluído aqui;
- Fuzzy matching é responsabilidade do app — `Contains` é busca simples sem correspondência aproximada;
- Histórico de comandos recentes requer persistência via localStorage (JS interop) ou estado de sessão;
- Command palette é padrão de nicho — adequado para apps admin/workbench com usuários avançados.
