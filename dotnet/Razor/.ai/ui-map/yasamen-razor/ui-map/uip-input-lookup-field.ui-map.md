# UIP-INPUT-LOOKUP_FIELD - Lookup Field

**GAP parcial — sem componente dedicado de lookup**

A biblioteca não tem componente de autocomplete remoto ou entity picker. Requer composição com `FieldText` + API + lista de sugestões ou `Modal` para lookup em janela.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. FieldText
- `cobertura`: campo de busca de entidade; `@oninput` para debounce de chamada à API; estado de carregamento via ícone de spinner manual;
- `limitações`: sem dropdown de sugestões nativo; sem `@bind-Value` para entidade complexa (id + display);
- `nota`: 6;
- `justificativa`: input de busca como trigger — base do lookup field.

2. Modal
- `cobertura`: janela de busca de entidade com campo de filtro + lista de resultados ricos; fecha ao selecionar; alternativa mais robusta ao dropdown;
- `nota`: 7;
- `justificativa`: lookup em modal — adequado quando resultados precisam de metadados e layout rico.

3. Feedback / Badge
- `cobertura`: indicador de entidade selecionada exibida após seleção (nome, badge, status);
- `nota`: 6;
- `justificativa`: display da entidade selecionada no campo.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `autocomplete dropdown com debounce`: composição manual — `FieldText` + `@oninput` + timer + lista absoluta;
  - `seleção de entidade com id + display`: estado C# `(int? Id, string? Display) selecao`;
  - `criação rápida inline`: botão "+ Criar" no dropdown ou no modal;
  - `multi-lookup (seleção múltipla)`: coleção de entidades selecionadas com badges removíveis.

- `tipo de adaptação`: composição + lógica de API
- `o que precisa ser feito`:
  - Para lookup simples via dropdown: `FieldText` + lista absoluta com resultados da API;
  - Para lookup rico: `Button "Selecionar"` + `Modal` com `FieldText` de filtro + lista de resultados;
  - Estado `(int? Id, string? Display)` no modelo para entidade selecionada.

## Como usar

### Lookup via Modal

```razor
@inject ModalService ModalService

@code {
    private int? clienteId;
    private string? clienteNome;
    private string filtroCliente = "";
    private List<ClienteDto> resultados = [];

    private async Task BuscarClientes()
        => resultados = await ClienteService.BuscarAsync(filtroCliente);

    private void SelecionarCliente(ClienteDto c)
    {
        clienteId = c.Id;
        clienteNome = c.Nome;
        ModalService.CloseAsync("lookup-cliente");
    }
}

<div class="flex items-center gap-2 mb-4">
    <div class="flex-1">
        @if (clienteNome is not null)
        {
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-2 flex items-center gap-2">
                <span class="text-sm">@clienteNome</span>
                <Button Style="Themes.Default" Size="Sizes.Small" Icon="WellKnownIcons.Close"
                        OnClick="() => { clienteId = null; clienteNome = null; }" />
            </Box>
        }
        else
        {
            <Button Style="Themes.Secondary" Outline=true Label="Selecionar cliente..."
                    Icon="WellKnownIcons.Search"
                    OnClick="() => ModalService.OpenAsync("lookup-cliente")" />
        }
    </div>
</div>

<Modal Id="lookup-cliente" Title="Selecionar cliente">
    <ChildContent>
        <div class="mb-3">
            <TextField @bind-Value="filtroCliente" Placeholder="Buscar por nome..."
                       @oninput="BuscarClientes" />
        </div>
        <Stack Gap="Gaps.Small">
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

## Decisão de uso

- `nota geral`: 4;
- `limitações`: sem componente de lookup nativo; autocomplete dropdown requer composição manual completa; lookup em modal é mais robusto mas mais verboso; sem multi-lookup nativo; estado de entidade selecionada (id + display) é gerenciado pelo app;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Modal` + `FieldText` + lista manual cobrem lookup funcional para entidades ricas;
  - Nota 4 reflete cobertura estrutural parcial — toda lógica de busca, debounce e seleção é do app.
