# PP-BOARD - Board

## Componentes por zona funcional

### Zona: Filtros

1. Bar + FieldText + DropButton (filtros de board)
- `cobertura`: busca de cards + filtro por responsável/prioridade/tag;
- `nota`: 8;
- `justificativa`: toolbar de filtros do board.

### Zona: Colunas (UIP-DATA-KANBAN_COLUMN)

1. flex + Box + Stack (layout do board)
- `cobertura`: scroll horizontal de colunas com `overflow-x-auto`; cada coluna com `w-64 flex-shrink-0`; `Box` como container de coluna; `Stack` para cards;
- `nota`: 6;
- `justificativa`: estrutura do board — funcional sem componente dedicado.

2. Bar (header da coluna)
- `cobertura`: título da coluna + badge de contagem + botão "+" para novo item;
- `nota`: 8;
- `justificativa`: header de coluna com indicadores.

3. Box (card de item)
- `cobertura`: card com título, tags, ações e responsável; `bg-white` com borda;
- `nota`: 7;
- `justificativa`: card de kanban — container visual.

4. Badge (tags, prioridade, status)
- `cobertura`: categorias e prioridades por card; contagem na coluna;
- `nota`: 9;
- `justificativa`: decoradores visuais do card.

### Zona: Movimentação (substituto de drag/drop)

1. DropIconButton + DropItem (mover via menu)
- `cobertura`: "Mover para [Coluna]" no menu de cada card; alternativa ao drag/drop;
- `nota`: 8;
- `justificativa`: movimentação de cards sem drag/drop nativo.

### Zona: Ações

1. Bar + Button (barra de ações do board)
- `cobertura`: "Nova tarefa" + "Gerenciar colunas";
- `nota`: 9;
- `justificativa`: ações da página de board.

2. Modal (criar/editar card)
- `cobertura`: modal de criação/edição de item do board;
- `nota`: 9;
- `justificativa`: criação e edição de card.

**Descartados**: nenhum.

## Composição completa da página

```razor
@page "/board"
@code {
    private Dictionary<string, List<TarefaDto>> colunas = new()
    {
        ["Backlog"] = [],
        ["A fazer"] = [],
        ["Em andamento"] = [],
        ["Revisão"] = [],
        ["Concluído"] = [],
    };

    private void MoverParaColuna(TarefaDto tarefa, string origem, string destino)
    {
        colunas[origem].Remove(tarefa);
        colunas[destino].Insert(0, tarefa);
    }

    private string busca = "";
    private string? filtroResponsavel;
}

@* Header do board *@
<Bar AdditionalClasses="mb-4">
    <StartContent>
        <h1 class="text-lg font-semibold text-dark-700">Board de tarefas</h1>
        <FieldText @bind-Value="busca" Placeholder="Buscar cards..."
                   @oninput="FiltrarCards" AdditionalClasses="w-48 ml-4" />
    </StartContent>
    <EndContent>
        <DropButton Label="Filtros" Style="Themes.Default">
            <DropItem Label="Minhas tarefas" OnClick="() => filtroResponsavel = usuarioId" />
            <DropItem Label="Sem responsável" OnClick="() => filtroResponsavel = null" />
            <DropItem Label="Limpar filtros" OnClick="() => filtroResponsavel = null" />
        </DropButton>
        <Button Style="Themes.Primary" Label="Nova tarefa"
                OnClick='() => ModalService.Open<NovaTarefaModal>()' />
    </EndContent>
</Bar>

@* Board — scroll horizontal *@
<div class="overflow-x-auto pb-4 -mx-2 px-2">
    <div class="flex gap-4" style="min-width: max-content;">
        @foreach (var coluna in colunas)
        {
            var nomeColuna = coluna.Key;
            var cards = coluna.Value
                .Where(t => string.IsNullOrEmpty(busca) ||
                            t.Titulo.Contains(busca, StringComparison.OrdinalIgnoreCase))
                .ToList();

            <div class="w-64 flex-shrink-0 flex flex-col">
                <Box Border="BorderBuilder.Box"
                     AdditionalClasses="flex flex-col overflow-hidden bg-light-50">
                    @* Header da coluna *@
                    <Bar AdditionalClasses="p-3 border-b border-light-200 bg-white flex-shrink-0">
                        <StartContent>
                            <div class="flex items-center gap-2">
                                <span class="text-sm font-semibold text-dark-600">@nomeColuna</span>
                                <Badge Style="Themes.Light" Text="@cards.Count.ToString()" />
                            </div>
                        </StartContent>
                        <EndContent>
                            <IconButton Icon="WellKnownIcons.Add" Style="Themes.Default"
                                       Size="Sizes.Small"
                                       OnClick='() => ModalService.Open<NovaTarefaModal>(
                                           p => p.Add(x => x.ColunaInicial, nomeColuna))' />
                        </EndContent>
                    </Bar>

                    @* Cards *@
                    <div class="p-2 min-h-32 flex-1 overflow-y-auto">
                        <Stack Gap="Gaps.Small">
                            @foreach (var tarefa in cards)
                            {
                                var tarefaLocal = tarefa;
                                var colunaLocal = nomeColuna;

                                <Box Border="BorderBuilder.Box"
                                     AdditionalClasses="p-3 bg-white cursor-pointer hover:shadow-sm transition-shadow"
                                     @onclick='() => ModalService.Open<DetalheTarefaModal>(
                                         p => p.Add(x => x.Tarefa, tarefaLocal))'>
                                    @* Prioridade *@
                                    @if (tarefa.Prioridade is not null)
                                    {
                                        <div class="mb-1">
                                            <Badge Style="@tarefa.PrioridadeTema"
                                                   Text="@tarefa.Prioridade" />
                                        </div>
                                    }

                                    @* Título e ações *@
                                    <Bar AdditionalClasses="mb-1">
                                        <StartContent>
                                            <p class="text-sm font-medium text-dark-600">
                                                @tarefa.Titulo
                                            </p>
                                        </StartContent>
                                        <EndContent>
                                            <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                                           Style="Themes.Default"
                                                           Size="Sizes.Small">
                                                <DropItem Label="Editar"
                                                          OnClick='() => ModalService.Open<EditarTarefaModal>(
                                                              p => p.Add(x => x.Tarefa, tarefaLocal))' />
                                                @foreach (var destino in colunas.Keys
                                                    .Where(k => k != colunaLocal))
                                                {
                                                    var destinoLocal = destino;
                                                    <DropItem
                                                        Label="@($"→ {destinoLocal}")"
                                                        OnClick="() => MoverParaColuna(tarefaLocal, colunaLocal, destinoLocal)" />
                                                }
                                                <hr class="my-1 border-light-200" />
                                                <DropItem Label="Excluir" Style="Themes.Danger"
                                                          OnClick="() => Excluir(tarefaLocal, colunaLocal)" />
                                            </DropIconButton>
                                        </EndContent>
                                    </Bar>

                                    @* Tags *@
                                    @if (tarefa.Tags?.Any() == true)
                                    {
                                        <div class="flex flex-wrap gap-1 mt-1">
                                            @foreach (var tag in tarefa.Tags)
                                            {
                                                <Badge Style="Themes.Light" Text="@tag" />
                                            }
                                        </div>
                                    }

                                    @* Responsável *@
                                    @if (tarefa.ResponsavelNome is not null)
                                    {
                                        <div class="flex items-center gap-1 mt-2">
                                            <div class="w-5 h-5 rounded-full bg-primary-200
                                                        flex items-center justify-center
                                                        text-xs font-bold text-primary-700">
                                                @tarefa.ResponsavelNome.Substring(0, 1)
                                            </div>
                                            <span class="text-xs text-dark-400">
                                                @tarefa.ResponsavelNome
                                            </span>
                                        </div>
                                    }
                                </Box>
                            }

                            @if (!cards.Any())
                            {
                                <div class="flex items-center justify-center h-16 border-2
                                            border-dashed border-light-200 rounded text-xs
                                            text-dark-300">
                                    Sem tarefas
                                </div>
                            }
                        </Stack>
                    </div>
                </Box>
            </div>
        }
    </div>
</div>
```

## Decisão de uso

- `nota geral`: 5;
- `limitações`: sem drag/drop nativo entre colunas — movimentação via menu "Mover para"; scroll horizontal manual; sem coluna colapsável nativa; sem limite WIP com bloqueio automático; board em mobile requer adaptação para uma coluna por vez;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Box` + `Stack` + `DropIconButton` + `Bar` cobrem PP-BOARD funcional com movimentação por menu;
  - Para drag/drop real: biblioteca externa (SortableJS via JS interop) ou implementação HTML5 DnD;
  - Nota 5 reflete cobertura estrutural funcional com limitação na interação principal (drag/drop).
