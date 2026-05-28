# UIP-DATA-KANBAN_COLUMN - Kanban Column

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de kanban/board. Requer composição com `Container+Slot` (layout de colunas) + `Box` (coluna) + `Stack` (itens) + `DropButton` (mover item por menu — sem drag/drop nativo).

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Container+Slot
- `cobertura`: layout horizontal de colunas side-by-side; cada `Slot` é uma coluna de kanban; scroll horizontal via `AdditionalClasses="overflow-x-auto"`;
- `nota`: 6;
- `justificativa`: grade horizontal de colunas — layout básico do board.

2. Box
- `cobertura`: container de coluna com fundo diferenciado (`bg-light-50`) + stack de cards; header de coluna com `Bar` (título + contagem + botão adicionar);
- `nota`: 7;
- `justificativa`: container visual de coluna com header.

3. Stack
- `cobertura`: sequência de cards dentro da coluna com `min-h-32` para área de drop;
- `nota`: 7;
- `justificativa`: lista de itens da coluna.

4. DropButton / DropItem (para mover item)
- `cobertura`: ação "Mover para..." no menu contextual de cada card; `DropItem` por coluna de destino;
- `nota`: 7;
- `justificativa`: alternativa ao drag/drop — mover item via menu de ações.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `drag/drop entre colunas`: sem nativo — `UIP-INTERACTION-DRAG_DROP` é GAP; alternativa: menu "Mover para" via `DropButton`;
  - `scroll horizontal de colunas`: `overflow-x-auto` no container + largura fixa por coluna (`w-64 flex-shrink-0`);
  - `coluna com limite WIP`: contagem no header + badge de aviso quando limite atingido.

- `tipo de adaptação`: composição + menu de movimentação como alternativa ao drag/drop
- `o que precisa ser feito`:
  - `Container+Slot` com `overflow-x-auto` para colunas; cada slot com `Box` de coluna;
  - Cards em `Stack` dentro de cada coluna; `DropIconButton` por card para mover entre colunas.

## Como usar

### Board kanban com movimento via menu

```razor
@code {
    private Dictionary<string, List<TarefaDto>> colunas = new()
    {
        ["A fazer"] = [...],
        ["Em andamento"] = [...],
        ["Concluído"] = [...],
    };

    private void MoverParaColuna(TarefaDto tarefa, string colunaOrigem, string colunaDestino)
    {
        colunas[colunaOrigem].Remove(tarefa);
        colunas[colunaDestino].Insert(0, tarefa);
    }
}

<div class="overflow-x-auto pb-4">
    <div class="flex gap-4 min-w-max">
        @foreach (var coluna in colunas)
        {
            <div class="w-64 flex-shrink-0">
                <Box Border="BorderBuilder.Box" AdditionalClasses="bg-light-50">
                    <Bar AdditionalClasses="p-3 border-b border-light-200">
                        <StartContent>
                            <div class="flex items-center gap-2">
                                <span class="text-sm font-semibold text-dark-600">@coluna.Key</span>
                                <Badge Style="Themes.Light" Text="@coluna.Value.Count.ToString()" />
                            </div>
                        </StartContent>
                        <EndContent>
                            <IconButton Icon="WellKnownIcons.Add" Style="Themes.Default"
                                        Size="Sizes.Small"
                                        OnClick="() => NovoItem(coluna.Key)" />
                        </EndContent>
                    </Bar>
                    <div class="p-2 min-h-32">
                        <Stack Gap="Gaps.Small">
                            @foreach (var tarefa in coluna.Value)
                            {
                                <Box Border="BorderBuilder.Box" AdditionalClasses="p-3 bg-white">
                                    <Bar AdditionalClasses="mb-1">
                                        <StartContent>
                                            <p class="text-sm font-medium text-dark-600">@tarefa.Titulo</p>
                                        </StartContent>
                                        <EndContent>
                                            <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                                           Style="Themes.Default" Size="Sizes.Small">
                                                <DropItem Label="Editar" OnClick="() => Editar(tarefa)" />
                                                @foreach (var destino in colunas.Keys.Where(k => k != coluna.Key))
                                                {
                                                    var destinoLocal = destino;
                                                    <DropItem Label="@($"Mover para {destinoLocal}")"
                                                              OnClick="() => MoverParaColuna(tarefa, coluna.Key, destinoLocal)" />
                                                }
                                                <hr class="my-1 border-light-200" />
                                                <DropItem Label="Excluir" Style="Themes.Danger"
                                                          OnClick="() => Excluir(tarefa)" />
                                            </DropIconButton>
                                        </EndContent>
                                    </Bar>
                                    @if (tarefa.Tags.Any())
                                    {
                                        <div class="flex flex-wrap gap-1 mt-1">
                                            @foreach (var tag in tarefa.Tags)
                                            {
                                                <Badge Style="Themes.Light" Text="@tag" />
                                            }
                                        </div>
                                    }
                                </Box>
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

- `nota geral`: 3;
- `limitações`: sem drag/drop nativo entre colunas (substituído por menu "Mover para"); sem scroll horizontal automático; toda estrutura é composição HTML manual; `Container+Slot` não é responsivo para boards com 4+ colunas no mobile;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Container+Slot` + `Box` + `Stack` + `DropIconButton` cobrem board kanban funcional com movimentação por menu;
  - Para drag/drop entre colunas: biblioteca externa ou implementação customizada com HTML5 DnD;
  - Nota 3 reflete cobertura estrutural básica sem abstração de kanban e sem drag/drop nativo.
