# UIP-INPUT-LOOKUP_FIELD - Blueprint resumido

## Pattern

UIP-INPUT-LOOKUP_FIELD — Lookup Field — ver `uip-input-lookup-field.ui-map.md`

## Gap coberto

A lib não tem entity picker ou autocomplete remoto. O gap é orientar dois cenários: lookup via modal (entidades ricas com metadados) e lookup via dropdown inline (busca simples com sugestões da API).

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: para entidades ricas usar `Button "Selecionar"` + `Modal` com `TextField` de filtro + lista de resultados; para autocomplete simples usar `TextField + @oninput + lista absoluta`.

## Componentes usados

- `Modal` — papel: principal (janela de lookup) — ver `modal.sample.md`
- `TextField` — papel: composição (campo de filtro) — ver `field-text.sample.md`
- `Button / IconButton` — papel: composição (trigger e ações) — ver `button.sample.md`
- `Box` — papel: composição (item de resultado) — ver `box.sample.md`
- `Stack` — papel: composição (lista de resultados) — ver `stack.sample.md`

## Recursos visuais

- `cursor-pointer hover:bg-primary-50` — item de resultado clicável
- `flex items-center gap-2` — display da entidade selecionada + botão remover
- Estado selecionado: `(int? Id, string? Display)` em C#

## Receita

Lookup via `Modal` para entidades ricas; estado `(Id, Display)` para entidade selecionada; botão limpar.

```razor
@code {
    private Modal? modalLookup;
    private int? clienteId;
    private string? clienteNome;
    private string filtroCliente = "";
    private List<ClienteDto> resultados = [];

    private async Task BuscarClientes()
        => resultados = await ClienteService.BuscarAsync(filtroCliente);

    private async Task SelecionarCliente(ClienteDto c)
    {
        clienteId = c.Id;
        clienteNome = c.Nome;
        await modalLookup!.CloseAsync();
    }

    private void LimparSelecao()
    {
        clienteId = null;
        clienteNome = null;
    }
}

@* Campo de seleção *@
<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">Cliente</label>
    @if (clienteNome is not null)
    {
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-2 flex items-center gap-2">
            <span class="text-sm flex-1">@clienteNome</span>
            <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                        Size="Sizes.Small" OnClick="LimparSelecao" />
        </Box>
    }
    else
    {
        <Button Style="Themes.Secondary" Outline=true
                Label="Selecionar cliente..."
                Icon="WellKnownIcons.Search"
                OnClick="async () => await modalLookup!.OpenAsync()" />
    }
</div>

@* Modal de lookup *@
<Modal @ref="modalLookup" Id="lookup-cliente" Title="Selecionar cliente">
    <ChildContent>
        <div class="mb-3">
            <TextField @bind-Value="filtroCliente"
                       Placeholder="Buscar por nome ou documento..."
                       @oninput="BuscarClientes" />
        </div>
        <Stack Gap="Gaps.Small">
            @if (!resultados.Any())
            {
                <p class="text-sm text-dark-400 text-center py-4">
                    @(string.IsNullOrWhiteSpace(filtroCliente)
                        ? "Digite para buscar clientes."
                        : "Nenhum resultado encontrado.")
                </p>
            }
            @foreach (var c in resultados)
            {
                <Box Border="BorderBuilder.Box"
                     AdditionalClasses="p-3 cursor-pointer hover:bg-primary-50"
                     @onclick="() => SelecionarCliente(c)">
                    <span class="font-semibold text-sm">@c.Nome</span>
                    <span class="text-xs text-dark-400 ml-2">@c.Documento</span>
                </Box>
            }
        </Stack>
    </ChildContent>
</Modal>
```

## Limites

- Debounce em `@oninput` requer `Task.Delay` + `CancellationToken` manual para evitar excesso de chamadas à API;
- Multi-lookup (seleção múltipla) requer `List<(int Id, string Display)>` + badges removíveis — composição adicional;
- Sem acessibilidade nativa de combobox (`aria-combobox`, `aria-activedescendant`).
