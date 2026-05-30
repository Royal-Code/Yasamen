# UIP-DATA-KANBAN_COLUMN - Blueprint completo

## Pattern

UIP-DATA-KANBAN_COLUMN — Kanban Column — ver `uip-data-kanban-column.ui-map.md`

## Gap coberto

A lib não tem componente de kanban ou board. O gap é coordenar: layout horizontal de colunas com scroll, coluna com header (`Bar`) e lista de cards (`Stack + Box`), movimentação de card entre colunas via menu `DropItem` (alternativa ao drag/drop), estado global do board como `Dictionary<string, List<T>>`, e formulário de novo card via `Modal`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `div.overflow-x-auto + div.flex.gap-4.min-w-max` para scroll horizontal; cada coluna `div.w-64.flex-shrink-0 + Box(bg-light-50)`; `Bar(título + Badge(count) + IconButton add)` no header; `Stack + Box(bg-white)` por card; `DropIconButton + DropItem("Mover para X")` por card; sem drag/drop nativo.
- `eixos cobertos sem componente novo`:
  - layout de colunas → `div.flex.gap-4.min-w-max` com scroll horizontal;
  - header de coluna → `Bar + Badge + IconButton`;
  - card de item → `Box + Bar + Badge + DropIconButton`;
  - movimento entre colunas → `DropItem` por coluna de destino;
  - novo card → `Modal + EditForm + TextField`.

## Componentes usados

- `Box` — papel: principal (container de coluna e de card) — ver `box.sample.md`
- `Stack` — papel: composição (lista de cards por coluna) — ver `stack.sample.md`
- `Bar` — papel: composição (header de coluna e de card) — ver `bar.sample.md`
- `Badge` — papel: composição (contagem de cards, tags) — ver `badge.sample.md`
- `DropIconButton` — papel: composição (ações por card) — ver `button.sample.md`
- `DropItem` — papel: composição (mover para coluna) — ver `button.sample.md`
- `IconButton` — papel: composição (adicionar card à coluna) — ver `button.sample.md`
- `Modal` — papel: composição (formulário de novo/editar card) — ver `modal.sample.md`
- `TextField` — papel: composição (campos do card) — ver `field-text.sample.md`

## Recursos visuais

- `overflow-x-auto pb-4` — scroll horizontal com espaço para scrollbar
- `flex gap-4 min-w-max` — colunas lado a lado sem quebra de linha
- `w-64 flex-shrink-0` — largura fixa de coluna
- `bg-light-50` — fundo da coluna
- `min-h-32` — área mínima da coluna para aceitar drops futuros
- `bg-white` — card destacado do fundo da coluna

## Receita

### Estrutura base

Board kanban com três colunas e movimentação via menu.

```razor
@page "/board"
@inject TarefaService TarefaService

@code {
    private Modal? cardFormModal;
    private Dictionary<string, List<TarefaDto>> colunas = new()
    {
        ["A fazer"]       = [],
        ["Em andamento"]  = [],
        ["Em revisão"]    = [],
        ["Concluído"]     = [],
    };
    private TarefaDto? cardEdicao;
    private string? colunaNovoCard;

    protected override async Task OnInitializedAsync()
    {
        var todasTarefas = await TarefaService.ListarAsync();
        foreach (var tarefa in todasTarefas)
        {
            if (colunas.ContainsKey(tarefa.Status))
                colunas[tarefa.Status].Add(tarefa);
        }
    }

    private void MoverParaColuna(TarefaDto tarefa, string colunaOrigem, string colunaDestino)
    {
        colunas[colunaOrigem].Remove(tarefa);
        colunas[colunaDestino].Insert(0, tarefa);
    }

    private async Task AbrirNovoCard(string coluna)
    {
        colunaNovoCard = coluna;
        cardEdicao = new TarefaDto { Status = coluna };
        await cardFormModal!.OpenAsync();
    }

    private async Task EditarCard(TarefaDto tarefa)
    {
        colunaNovoCard = tarefa.Status;
        cardEdicao = tarefa with { };
        await cardFormModal!.OpenAsync();
    }

    private async Task SalvarCard()
    {
        if (cardEdicao is null) return;
        if (cardEdicao.Id == 0)
        {
            var novo = await TarefaService.CriarAsync(cardEdicao);
            colunas[colunaNovoCard!].Add(novo);
        }
        else
        {
            await TarefaService.AtualizarAsync(cardEdicao);
            var coluna = colunas.First(c => c.Value.Any(t => t.Id == cardEdicao.Id));
            var idx = coluna.Value.FindIndex(t => t.Id == cardEdicao.Id);
            coluna.Value[idx] = cardEdicao;
        }
        await cardFormModal!.CloseAsync();
    }

    private async Task ExcluirCard(TarefaDto tarefa, string coluna)
    {
        await TarefaService.ExcluirAsync(tarefa.Id);
        colunas[coluna].Remove(tarefa);
    }
}

@* Board — scroll horizontal *@
<div class="overflow-x-auto pb-4">
    <div class="flex gap-4 min-w-max">
        @foreach (var coluna in colunas)
        {
            <div class="w-64 flex-shrink-0">
                <Box Border="BorderBuilder.Box" AdditionalClasses="bg-light-50">
                    @* Header da coluna *@
                    <Bar AdditionalClasses="p-3 border-b border-light-200">
                        <StartContent>
                            <div class="flex items-center gap-2">
                                <span class="text-sm font-semibold text-dark-600">@coluna.Key</span>
                                <Badge Style="Themes.Light"
                                       Text="@coluna.Value.Count.ToString()" />
                            </div>
                        </StartContent>
                        <EndContent>
                            <IconButton Icon="WellKnownIcons.Add" Style="Themes.Default"
                                        Size="Sizes.Small"
                                        OnClick="() => AbrirNovoCard(coluna.Key)" />
                        </EndContent>
                    </Bar>

                    @* Cards da coluna *@
                    <div class="p-2 min-h-32">
                        <Stack Gap="Gaps.Small">
                            @foreach (var tarefa in coluna.Value)
                            {
                                var colunaAtual = coluna.Key;
                                <Box Border="BorderBuilder.Box"
                                     AdditionalClasses="p-3 bg-white cursor-pointer hover:shadow-sm"
                                     @onclick="() => EditarCard(tarefa)">
                                    <Bar AdditionalClasses="mb-1">
                                        <StartContent>
                                            <p class="text-sm font-medium text-dark-600">
                                                @tarefa.Titulo
                                            </p>
                                        </StartContent>
                                        <EndContent>
                                            <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                                            Style="Themes.Default" Size="Sizes.Small"
                                                            OnClick:stopPropagation>
                                                @foreach (var destino in colunas.Keys.Where(k => k != colunaAtual))
                                                {
                                                    var destinoLocal = destino;
                                                    <DropItem Label="@($"Mover para {destinoLocal}")"
                                                              OnClick="() => MoverParaColuna(tarefa, colunaAtual, destinoLocal)" />
                                                }
                                                <hr class="my-1 border-light-200" />
                                                <DropItem Label="Excluir" Style="Themes.Danger"
                                                          OnClick="() => ExcluirCard(tarefa, colunaAtual)" />
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
                                    @if (tarefa.Responsavel is not null)
                                    {
                                        <div class="flex items-center gap-1 mt-2">
                                            <div class="w-5 h-5 rounded-full bg-primary-100 flex items-center
                                                        justify-center text-xs font-bold text-primary-600">
                                                @tarefa.Responsavel[0]
                                            </div>
                                            <span class="text-xs text-dark-400">@tarefa.Responsavel</span>
                                        </div>
                                    }
                                </Box>
                            }
                        </Stack>

                        @if (!coluna.Value.Any())
                        {
                            <p class="text-xs text-dark-400 text-center py-4">Sem itens</p>
                        }
                    </div>
                </Box>
            </div>
        }
    </div>
</div>

@* Modal de criar/editar card *@
<Modal @ref="cardFormModal" Id="card-form"
       Title="@(cardEdicao?.Id > 0 ? "Editar card" : $"Novo card em \"{colunaNovoCard}\"")">
    <ChildContent>
        @if (cardEdicao is not null)
        {
            <EditForm Model="cardEdicao" OnValidSubmit="SalvarCard">
                <DataAnnotationsValidator />
                <Stack Gap="Gaps.Medium">
                    <TextField @bind-Value="cardEdicao.Titulo" Label="Título" required />
                    <TextField @bind-Value="cardEdicao.Descricao" Label="Descrição (opcional)" />
                    <div class="flex flex-col gap-1">
                        <label class="text-sm font-medium text-dark-600">Prioridade</label>
                        <InputSelect @bind-Value="cardEdicao.Prioridade"
                                     class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                            <option value="baixa">Baixa</option>
                            <option value="media">Média</option>
                            <option value="alta">Alta</option>
                        </InputSelect>
                    </div>
                </Stack>
                <Bar AdditionalClasses="mt-4">
                    <StartContent>
                        @if (cardEdicao.Id > 0)
                        {
                            <Button Style="Themes.Danger" Outline="true" Size="Sizes.Small"
                                    Label="Excluir"
                                    OnClick='async () => await ExcluirCard(cardEdicao, colunaNovoCard!)' />
                        }
                    </StartContent>
                    <EndContent>
                        <Button Style="Themes.Default" Label="Cancelar"
                                OnClick='async () => await cardFormModal!.CloseAsync()' />
                        <Button Style="Themes.Primary" Label="Salvar" Type="submit" />
                    </EndContent>
                </Bar>
            </EditForm>
        }
    </ChildContent>
</Modal>
```

### Cenários de composição

#### Coluna com limite WIP (work in progress)

```razor
@* Cabeçalho de coluna com aviso de limite *@
<Bar AdditionalClasses="p-3 border-b border-light-200">
    <StartContent>
        <div class="flex items-center gap-2">
            <span class="text-sm font-semibold text-dark-600">@coluna.Key</span>
            <Badge Style="@(coluna.Value.Count > limiteWip ? Themes.Danger : Themes.Light)"
                   Text="@($"{coluna.Value.Count}/{limiteWip}")" />
        </div>
    </StartContent>
    <EndContent>
        <IconButton Icon="WellKnownIcons.Add" Style="Themes.Default" Size="Sizes.Small"
                    Disabled="@(coluna.Value.Count >= limiteWip)"
                    OnClick="() => AbrirNovoCard(coluna.Key)" />
    </EndContent>
</Bar>
```

### Estados de página

- `loading`: substituir `Stack` por 3 boxes `animate-pulse h-16 bg-light-200 rounded` por coluna;
- `empty` por coluna: `<p class="text-xs text-dark-400 text-center py-4">Sem itens</p>` dentro de `div.min-h-32`;
- `error` geral: `<Feedback Style="Themes.Danger">` acima do board com `Button "Tentar novamente"`.

## Limites

- **Drag & drop entre colunas não coberto** — `UIP-INTERACTION-DRAG_DROP` é GAP; alternativa: menu "Mover para" via `DropItem`;
- `var colunaAtual = coluna.Key` dentro do `@foreach` é necessário para captura correta em lambdas do C#;
- `Container+Slot` não serve para boards com 4+ colunas — usar `div.flex.gap-4.min-w-max` com `overflow-x-auto`;
- Persistência da ordem dos cards dentro da coluna requer campo `Ordem` no modelo e save na API;
- Mobile: considerar substituir scroll horizontal por seletor de coluna (`ButtonGroup` ou `InputSelect`) + lista vertical da coluna selecionada.

### Responsividade

Mobile (< md): ocultar scroll horizontal e exibir uma coluna por vez. Exemplo: `ButtonGroup` para selecionar coluna ativa + `@if (colunaSelecionada == coluna.Key)` para mostrar apenas a coluna ativa.
