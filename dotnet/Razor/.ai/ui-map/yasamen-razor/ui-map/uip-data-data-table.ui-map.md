# UIP-DATA-DATA_TABLE - Data Table

**GAP parcial — sem componente de tabela nativo**

A biblioteca não tem componente de DataTable. A tabela é construída com HTML `<table>` + Tailwind CSS. Seleção múltipla, ordenação e paginação requerem composição com `Pagination` e lógica C#.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Pagination
- `cobertura`: paginação da tabela — `CurrentPage`, `TotalPages`, `OnPageChanged`, `Loading`; responsividade mobile/desktop automática;
- `nota`: 9;
- `justificativa`: paginação nativa de alta qualidade para tabelas.

2. Bar (action bar acima da tabela)
- `cobertura`: barra de busca + filtros + ação "Novo" + contagem; barra contextual de seleção múltipla;
- `nota`: 9;
- `justificativa`: toolbar da tabela com ações da coleção.

3. DropIconButton + DropItem (ações por linha)
- `cobertura`: menu de ações por linha na última coluna; ícone de overflow por linha;
- `nota`: 9;
- `justificativa`: contextual menu por linha — cobre ações de editar, excluir, visualizar.

4. Feedback / Box (empty state + error state)
- `cobertura`: estado vazio dentro da tabela; estado de erro com retry;
- `nota`: 8;
- `justificativa`: feedback de estado da tabela.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `tabela HTML responsiva`: usar `<div class="overflow-x-auto">` como wrapper + `<table class="min-w-full">`;
  - `skeleton de linhas`: `<tr>` com `<td class="animate-pulse bg-light-100 h-4 rounded">`;
  - `seleção múltipla`: `HashSet<int>` de IDs + `<input type="checkbox">` na primeira coluna;
  - `ordenação de colunas`: estado `(string coluna, bool desc)` + `@onclick` no `<th>`.

- `tipo de adaptação`: HTML nativo + Tailwind + composição
- `o que precisa ser feito`:
  - HTML `<table>` com classes Tailwind para estilo; `Bar` para toolbar; `Pagination` para paginação;
  - `DropIconButton` por linha para ações; `Feedback` para empty state.

## Como usar

### Tabela básica com paginação e ações

```razor
@code {
    private int pagina = 1;
    private int totalPaginas = 5;
    private bool carregando = false;

    private async Task OnPage(int p)
    {
        carregando = true;
        pagina = p;
        await CarregarDados(p);
        carregando = false;
    }
}

<Bar AdditionalClasses="mb-4">
    <StartContent>
        <TextField @bind-Value="busca" Placeholder="Buscar..." @oninput="Buscar" />
    </StartContent>
    <EndContent>
        <Button Style="Themes.Primary" Label="Novo" Icon="WellKnownIcons.Add" OnClick="Novo" />
    </EndContent>
</Bar>

<div class="overflow-x-auto">
    <table class="min-w-full divide-y divide-light-200">
        <thead class="bg-light-50">
            <tr>
                <th class="px-4 py-3 text-left text-xs font-semibold text-dark-400">Nome</th>
                <th class="px-4 py-3 text-left text-xs font-semibold text-dark-400">E-mail</th>
                <th class="px-4 py-3 text-left text-xs font-semibold text-dark-400">Status</th>
                <th class="px-4 py-3 text-right text-xs font-semibold text-dark-400">Ações</th>
            </tr>
        </thead>
        <tbody class="divide-y divide-light-100">
            @if (carregando)
            {
                @for (int i = 0; i < 5; i++)
                {
                    <tr>
                        <td class="px-4 py-3"><div class="animate-pulse bg-light-200 h-4 rounded w-32"></div></td>
                        <td class="px-4 py-3"><div class="animate-pulse bg-light-200 h-4 rounded w-48"></div></td>
                        <td class="px-4 py-3"><div class="animate-pulse bg-light-200 h-4 rounded w-16"></div></td>
                        <td class="px-4 py-3"></td>
                    </tr>
                }
            }
            else if (!itens.Any())
            {
                <tr>
                    <td colspan="4" class="px-4 py-8 text-center">
                        <Feedback Style="Themes.Light" Text="Nenhum resultado encontrado." />
                    </td>
                </tr>
            }
            else
            {
                @foreach (var item in itens)
                {
                    <tr class="hover:bg-light-50 transition-colors">
                        <td class="px-4 py-3 text-sm text-dark-600">@item.Nome</td>
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
            OnPageChanged="OnPage" Loading="@carregando"
            AdditionalClasses="mt-4" />
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de data table nativo; tabela HTML + Tailwind manual; seleção múltipla via checkboxes HTML; ordenação de colunas via estado C#; skeleton de linhas manual; sem virtualização para listas grandes;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Pagination` + `Bar` + `DropIconButton` + `Feedback` + `Badge` cobrem os elementos periféricos da tabela;
  - A tabela em si é HTML `<table>` com Tailwind — funcional e suficiente para a maioria dos casos;
  - Nota 3 reflete que nenhum componente dedicado de tabela existe — apenas primitivos de suporte.
