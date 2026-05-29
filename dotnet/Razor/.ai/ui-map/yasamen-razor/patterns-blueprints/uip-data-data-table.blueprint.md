# UIP-DATA-DATA_TABLE - Blueprint completo

## Pattern

UIP-DATA-DATA_TABLE — Data Table — ver `uip-data-data-table.ui-map.md`

## Gap coberto

A lib não tem componente de DataTable. A tabela é HTML `<table>` + Tailwind CSS. O gap é coordenar: toolbar de busca e ações, skeleton de loading por linha, seleção múltipla com checkboxes, cabeçalhos com ordenação clicável, ações por linha via `DropIconButton`, paginação com `Pagination`, e estados de empty/error dentro da tabela.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: HTML `<table class="min-w-full divide-y divide-light-200">` + `div.overflow-x-auto` para scroll horizontal; `Bar` para toolbar; `Pagination` para paginação; `DropIconButton` por linha; `Feedback` para empty state; todo estado C# no componente pai.
- `eixos cobertos sem componente novo`:
  - toolbar → `Bar` (busca + filtros + ação primária);
  - paginação → `Pagination` (nativo);
  - ações por linha → `DropIconButton + DropItem`;
  - empty state → `Feedback(Light)` em `<td colspan>`;
  - skeleton → `<tr>` com `<td class="animate-pulse">`.

## Componentes usados

- `Bar` — papel: principal (toolbar da tabela) — ver `bar.sample.md`
- `Pagination` — papel: principal (paginação) — ver `bar.sample.md`
- `DropIconButton` — papel: composição (ações por linha) — ver `button.sample.md`
- `DropItem` — papel: composição (itens de ação) — ver `button.sample.md`
- `Badge` — papel: composição (status por célula) — ver `badge.sample.md`
- `Button` — papel: composição (ação primária na toolbar) — ver `button.sample.md`
- `TextField` — papel: composição (busca na toolbar) — ver `field-text.sample.md`
- `Feedback` — papel: composição (empty state e error state) — ver `feedback.sample.md`

## Recursos visuais

- `overflow-x-auto` — wrapper para scroll horizontal em telas pequenas
- `min-w-full divide-y divide-light-200` — tabela com separadores
- `bg-light-50` — cabeçalho da tabela
- `px-4 py-3 text-xs font-semibold text-dark-400 text-left` — célula de cabeçalho
- `hover:bg-light-50 transition-colors` — linha hover
- `animate-pulse bg-light-200 h-4 rounded` — skeleton de célula

## Receita

### Estrutura base

Tabela completa com busca, seleção múltipla, ordenação, skeleton e paginação.

```razor
@code {
    private List<UsuarioDto> itens = [];
    private int pagina = 1;
    private int totalPaginas = 1;
    private bool carregando = true;
    private string busca = "";
    private (string coluna, bool desc) ordenacao = ("nome", false);
    private HashSet<int> selecionados = [];
    private string? erro;

    protected override async Task OnInitializedAsync()
        => await CarregarDados();

    private async Task CarregarDados()
    {
        carregando = true;
        erro = null;
        try
        {
            var resultado = await UsuarioService.ListarAsync(pagina, busca,
                ordenacao.coluna, ordenacao.desc);
            itens = resultado.Itens;
            totalPaginas = resultado.TotalPaginas;
            selecionados.Clear();
        }
        catch (Exception ex)
        {
            erro = ex.Message;
        }
        finally { carregando = false; }
    }

    private async Task OnPagina(int p)
    {
        pagina = p;
        await CarregarDados();
    }

    private async Task Ordenar(string coluna)
    {
        ordenacao = ordenacao.coluna == coluna
            ? (coluna, !ordenacao.desc)
            : (coluna, false);
        pagina = 1;
        await CarregarDados();
    }

    private bool TodosSelecionados
        => itens.Any() && selecionados.Count == itens.Count;

    private void ToggleTodos()
    {
        if (TodosSelecionados) selecionados.Clear();
        else selecionados = itens.Select(i => i.Id).ToHashSet();
    }

    private void ToggleItem(int id)
    {
        if (!selecionados.Remove(id)) selecionados.Add(id);
    }

    private string SetaOrdenacao(string coluna) =>
        ordenacao.coluna == coluna ? (ordenacao.desc ? " ↓" : " ↑") : "";
}

@* Toolbar principal *@
<Bar AdditionalClasses="mb-4">
    <StartContent>
        <TextField @bind-Value="busca" Placeholder="Buscar..."
                   @oninput='async e => { pagina=1; await CarregarDados(); }' />
        @if (selecionados.Any())
        {
            <span class="text-sm text-dark-500">@selecionados.Count selecionados</span>
            <Button Style="Themes.Danger" Outline="true" Size="Sizes.Small"
                    Label="Excluir selecionados"
                    OnClick="ExcluirSelecionados" />
        }
    </StartContent>
    <EndContent>
        <Button Style="Themes.Primary" Label="Novo"
                Icon="WellKnownIcons.Add" OnClick="Novo" />
    </EndContent>
</Bar>

@* Tabela *@
<div class="overflow-x-auto rounded-lg border border-light-200">
    <table class="min-w-full divide-y divide-light-200">
        <thead class="bg-light-50">
            <tr>
                <th class="px-4 py-3 w-10">
                    <input type="checkbox"
                           checked="@TodosSelecionados"
                           @onchange="ToggleTodos"
                           class="accent-primary-500" />
                </th>
                <th class="px-4 py-3 text-left text-xs font-semibold text-dark-400 cursor-pointer select-none"
                    @onclick='() => Ordenar("nome")'>
                    Nome @SetaOrdenacao("nome")
                </th>
                <th class="px-4 py-3 text-left text-xs font-semibold text-dark-400 cursor-pointer select-none"
                    @onclick='() => Ordenar("email")'>
                    E-mail @SetaOrdenacao("email")
                </th>
                <th class="px-4 py-3 text-left text-xs font-semibold text-dark-400">Status</th>
                <th class="px-4 py-3 text-right text-xs font-semibold text-dark-400">Ações</th>
            </tr>
        </thead>
        <tbody class="divide-y divide-light-100 bg-white">
            @if (carregando)
            {
                @for (int i = 0; i < 5; i++)
                {
                    <tr>
                        <td class="px-4 py-3"></td>
                        <td class="px-4 py-3">
                            <div class="animate-pulse bg-light-200 h-4 rounded w-32"></div>
                        </td>
                        <td class="px-4 py-3">
                            <div class="animate-pulse bg-light-200 h-4 rounded w-48"></div>
                        </td>
                        <td class="px-4 py-3">
                            <div class="animate-pulse bg-light-200 h-4 rounded w-16"></div>
                        </td>
                        <td class="px-4 py-3"></td>
                    </tr>
                }
            }
            else if (erro is not null)
            {
                <tr>
                    <td colspan="5" class="px-4 py-8">
                        <Feedback Style="Themes.Danger" Text="@erro">
                            <ChildContent>
                                <Button Style="Themes.Danger" Outline="true"
                                        Size="Sizes.Small" Label="Tentar novamente"
                                        OnClick="CarregarDados" />
                            </ChildContent>
                        </Feedback>
                    </td>
                </tr>
            }
            else if (!itens.Any())
            {
                <tr>
                    <td colspan="5" class="px-4 py-8">
                        <Feedback Style="Themes.Light"
                                  Text="@(string.IsNullOrEmpty(busca) ? "Nenhum resultado." : $"Sem resultados para \"{busca}\".")" />
                    </td>
                </tr>
            }
            else
            {
                @foreach (var item in itens)
                {
                    <tr class="hover:bg-light-50 transition-colors
                               @(selecionados.Contains(item.Id) ? "bg-primary-50" : "")">
                        <td class="px-4 py-3">
                            <input type="checkbox"
                                   checked="@selecionados.Contains(item.Id)"
                                   @onchange="() => ToggleItem(item.Id)"
                                   class="accent-primary-500" />
                        </td>
                        <td class="px-4 py-3 text-sm font-medium text-dark-700">@item.Nome</td>
                        <td class="px-4 py-3 text-sm text-dark-400">@item.Email</td>
                        <td class="px-4 py-3">
                            <Badge Style="@(item.Ativo ? Themes.Success : Themes.Light)"
                                   Text="@(item.Ativo ? "Ativo" : "Inativo")" />
                        </td>
                        <td class="px-4 py-3 text-right">
                            <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                            Style="Themes.Default" Size="Sizes.Small">
                                <DropItem Label="Visualizar" OnClick="() => Ver(item.Id)" />
                                <DropItem Label="Editar" OnClick="() => Editar(item.Id)" />
                                <hr class="my-1 border-light-200" />
                                <DropItem Label="Excluir" Style="Themes.Danger"
                                          OnClick="() => Excluir(item.Id)" />
                            </DropIconButton>
                        </td>
                    </tr>
                }
            }
        </tbody>
    </table>
</div>

<Pagination CurrentPage="@pagina" TotalPages="@totalPaginas"
            OnPageChanged="OnPagina" Loading="@carregando"
            AdditionalClasses="mt-4" />
```

### Cenários de composição

#### Tabela simples sem seleção (leitura)

```razor
@* Apenas a tabela mínima sem seleção múltipla *@
<div class="overflow-x-auto">
    <table class="min-w-full divide-y divide-light-200">
        <thead class="bg-light-50">
            <tr>
                <th class="px-4 py-3 text-left text-xs font-semibold text-dark-400">Nome</th>
                <th class="px-4 py-3 text-left text-xs font-semibold text-dark-400">Status</th>
                <th class="px-4 py-3 text-right text-xs font-semibold text-dark-400">Ações</th>
            </tr>
        </thead>
        <tbody class="divide-y divide-light-100">
            @foreach (var item in itens)
            {
                <tr class="hover:bg-light-50">
                    <td class="px-4 py-3 text-sm text-dark-600">@item.Nome</td>
                    <td class="px-4 py-3">
                        <Badge Style="Themes.Success" Text="Ativo" />
                    </td>
                    <td class="px-4 py-3 text-right">
                        <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                        Style="Themes.Default" Size="Sizes.Small">
                            <DropItem Label="Ver" OnClick="() => Ver(item.Id)" />
                        </DropIconButton>
                    </td>
                </tr>
            }
        </tbody>
    </table>
</div>
```

#### Barra de contexto de seleção múltipla

```razor
@* Aparece quando selecionados.Any() — substituir o toolbar normal *@
@if (selecionados.Any())
{
    <Bar AdditionalClasses="mb-4 bg-primary-50 border border-primary-200 rounded-lg px-4 py-2">
        <StartContent>
            <span class="text-sm font-medium text-primary-700">
                @selecionados.Count item(s) selecionado(s)
            </span>
        </StartContent>
        <EndContent>
            <Button Style="Themes.Default" Size="Sizes.Small" Label="Desmarcar todos"
                    OnClick="() => selecionados.Clear()" />
            <Button Style="Themes.Danger" Outline="true" Size="Sizes.Small"
                    Label="Excluir selecionados" OnClick="ExcluirSelecionados" />
        </EndContent>
    </Bar>
}
```

### Estados de página

- `loading`: 5 linhas skeleton com `animate-pulse bg-light-200 h-4 rounded` em cada célula;
- `empty`: `<Feedback Style="Themes.Light">` dentro de `<td colspan="N">`;
- `error`: `<Feedback Style="Themes.Danger">` com `Button "Tentar novamente"` dentro da célula;
- linha selecionada: `bg-primary-50` na `<tr>` quando `selecionados.Contains(id)`.

## Limites

- Sem componente de tabela nativo — toda estrutura é HTML `<table>` + Tailwind;
- Sem virtualização para listas muito grandes (> 500 linhas) — usar paginação server-side;
- Ordenação multi-coluna requer estado adicional no C# — não coberto aqui;
- Células editáveis inline requerem composição com `UIP-INPUT-INLINE_EDITOR`;
- Colunas com largura fixa podem quebrar layout — usar `min-w-max` no wrapper ou `table-fixed` com larguras explícitas;
- `overflow-x-auto` no wrapper é essencial para mobile — sem ele a tabela quebra o layout.

### Responsividade

Para mobile: ocultar colunas secundárias com `hidden sm:table-cell`; manter apenas coluna principal e ações. Alternativa: substituir tabela por `UIP-DATA-LIST_ITEM` (lista de cards) em telas pequenas com `hidden sm:block` / `block sm:hidden`.
