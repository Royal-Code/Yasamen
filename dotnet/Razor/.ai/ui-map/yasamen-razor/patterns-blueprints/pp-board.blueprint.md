# PP-BOARD - Blueprint completo

## Pattern

PP-BOARD — Board — ver `pp-board.ui-map.md`

## Gap coberto

A lib não tem componente de kanban. O gap é coordenar: scroll horizontal de colunas sem quebra de linha, `Dictionary<string, List<T>>` como estado do board, filtro de cards por busca e responsável, movimento de card entre colunas via `DropItem` como alternativa ao drag/drop, e `Modal` para criação e edição de card com campos completos.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `div.overflow-x-auto.pb-4 + div.flex.gap-4` com `style="min-width: max-content"` para scroll horizontal sem wrapping; coluna `div.w-64.flex-shrink-0.flex.flex-col + Box(bg-light-50)`; card `Box(bg-white cursor-pointer hover:shadow-sm) + Bar + Badge + DropIconButton`; `DropItem("→ Destino")` para movimentação; `Modal` para CRUD.
- `eixos cobertos sem componente novo`:
  - layout de colunas → `div.flex.gap-4` com `overflow-x-auto`;
  - header de coluna → `Bar + Badge(count) + IconButton add`;
  - card → `Box(bg-white) + Bar(título+DropIconButton) + Badge(prioridade/tags)`;
  - movimento → `DropItem` por coluna de destino;
  - filtro → `TextField(@oninput) + DropButton(responsável)`;
  - CRUD → `Modal + EditForm + TextField + InputSelect`.

## Componentes usados

- `Box` — papel: principal (container de coluna e de card) — ver `box.sample.md`
- `Stack` — papel: composição (lista de cards por coluna) — ver `stack.sample.md`
- `Bar` — papel: composição (header da página, coluna e card) — ver `bar.sample.md`
- `Badge` — papel: composição (contagem, prioridade, tags) — ver `badge.sample.md`
- `DropIconButton` — papel: composição (ações por card) — ver `button.sample.md`
- `DropItem` — papel: composição (mover para coluna) — ver `button.sample.md`
- `DropButton` — papel: composição (filtros dropdown) — ver `button.sample.md`
- `IconButton` — papel: composição (adicionar card à coluna) — ver `button.sample.md`
- `Button` — papel: composição (nova tarefa, filtros) — ver `button.sample.md`
- `Modal` — papel: composição (criar/editar card) — ver `modal.sample.md`
- `TextField` — papel: composição (busca, campos do card) — ver `field-text.sample.md`

## Recursos visuais

- `overflow-x-auto pb-4 -mx-2 px-2` — scroll horizontal com compensação de margem
- `flex gap-4` + `style="min-width: max-content"` — colunas sem quebra de linha
- `w-64 flex-shrink-0` — largura fixa de coluna
- `bg-light-50` — fundo da coluna
- `bg-white cursor-pointer hover:shadow-sm transition-shadow` — card com efeito hover
- `min-h-32` — altura mínima da área de cards (espaço para drop futuro)

## Receita

### Estrutura base

Board com 5 colunas, filtros por busca e responsável, e CRUD via modal.

```razor
@page "/board"

@code {
    private Modal? cardFormModal;
    private Dictionary<string, List<TarefaDto>> colunas = new()
    {
        ["Backlog"]       = [],
        ["A fazer"]       = [],
        ["Em andamento"]  = [],
        ["Revisão"]       = [],
        ["Concluído"]     = [],
    };
    private bool carregando = true;
    private string busca = "";
    private string? filtroResponsavel;
    private TarefaDto? cardEdicao;
    private string? colunaNovoCard;

    protected override async Task OnInitializedAsync()
    {
        var tarefas = await TarefaService.ListarAsync();
        foreach (var t in tarefas)
            if (colunas.ContainsKey(t.Status))
                colunas[t.Status].Add(t);
        carregando = false;
    }

    private void MoverParaColuna(TarefaDto tarefa, string origem, string destino)
    {
        colunas[origem].Remove(tarefa);
        colunas[destino].Insert(0, tarefa);
        _ = TarefaService.AtualizarStatusAsync(tarefa.Id, destino);
    }

    private IEnumerable<TarefaDto> CardsFiltrados(IEnumerable<TarefaDto> cards) =>
        cards.Where(t =>
            (string.IsNullOrEmpty(busca) ||
             t.Titulo.Contains(busca, StringComparison.OrdinalIgnoreCase)) &&
            (filtroResponsavel is null || t.ResponsavelId == filtroResponsavel));

    private async Task AbrirNovoCard(string coluna)
    {
        colunaNovoCard = coluna;
        cardEdicao = new TarefaDto { Status = coluna };
        await cardFormModal!.OpenAsync();
    }

    private async Task AbrirEdicaoCard(TarefaDto tarefa, string coluna)
    {
        colunaNovoCard = coluna;
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
            var colunaAtual = colunas.First(c => c.Value.Any(t => t.Id == cardEdicao.Id));
            var idx = colunaAtual.Value.FindIndex(t => t.Id == cardEdicao.Id);
            colunaAtual.Value[idx] = cardEdicao;
        }
        await cardFormModal!.CloseAsync();
    }

    private async Task ExcluirCard(TarefaDto tarefa, string coluna)
    {
        await TarefaService.ExcluirAsync(tarefa.Id);
        colunas[coluna].Remove(tarefa);
        await cardFormModal!.CloseAsync();
    }
}

@* Header do board *@
<Bar AdditionalClasses="mb-4">
    <StartContent>
        <h1 class="text-lg font-semibold text-dark-700">Board</h1>
        <TextField @bind-Value="busca" Placeholder="Buscar cards..."
                   AdditionalClasses="w-48 ml-4"
                   @oninput='e => busca = e.Value?.ToString() ?? ""' />
    </StartContent>
    <EndContent>
        <DropButton Label="@(filtroResponsavel is null ? "Responsável" : "Filtrado")"
                    Style="@(filtroResponsavel is null ? Themes.Default : Themes.Primary)"
                    Outline="@(filtroResponsavel is not null)">
            <DropItem Label="Minhas tarefas"
                      OnClick="() => filtroResponsavel = UsuarioAtualId" />
            <DropItem Label="Limpar filtro"
                      OnClick="() => filtroResponsavel = null" />
        </DropButton>
        <Button Style="Themes.Primary" Label="Nova tarefa"
                OnClick="() => AbrirNovoCard("Backlog")" />
    </EndContent>
</Bar>

@if (carregando)
{
    <div class="flex gap-4">
        @for (int i = 0; i < 5; i++)
        {
            <div class="w-64 flex-shrink-0">
                <div class="animate-pulse">
                    <div class="h-10 bg-light-200 rounded-t mb-2"></div>
                    @for (int j = 0; j < 3; j++)
                    {
                        <div class="h-16 bg-light-100 rounded mb-2"></div>
                    }
                </div>
            </div>
        }
    </div>
}
else
{
    @* Board — scroll horizontal *@
    <div class="overflow-x-auto pb-4 -mx-2 px-2">
        <div class="flex gap-4" style="min-width: max-content;">
            @foreach (var coluna in colunas)
            {
                var nomeColuna = coluna.Key;
                var cards = CardsFiltrados(coluna.Value).ToList();

                <div class="w-64 flex-shrink-0 flex flex-col">
                    <Box Border="BorderBuilder.Box"
                         AdditionalClasses="flex flex-col bg-light-50 overflow-hidden">

                        @* Header da coluna *@
                        <Bar AdditionalClasses="p-3 border-b border-light-200 bg-white flex-shrink-0">
                            <StartContent>
                                <div class="flex items-center gap-2">
                                    <span class="text-sm font-semibold text-dark-600">
                                        @nomeColuna
                                    </span>
                                    <Badge Style="Themes.Light"
                                           Text="@cards.Count.ToString()" />
                                </div>
                            </StartContent>
                            <EndContent>
                                <IconButton Icon="WellKnownIcons.Add" Style="Themes.Default"
                                            Size="Sizes.Small"
                                            OnClick="() => AbrirNovoCard(nomeColuna)" />
                            </EndContent>
                        </Bar>

                        @* Cards *@
                        <div class="p-2 min-h-32 flex-1">
                            <Stack Gap="Gaps.Small">
                                @foreach (var tarefa in cards)
                                {
                                    var tarefaLocal = tarefa;
                                    var colunaLocal = nomeColuna;

                                    <Box Border="BorderBuilder.Box"
                                         AdditionalClasses="p-3 bg-white cursor-pointer hover:shadow-sm transition-shadow"
                                         @onclick="() => AbrirEdicaoCard(tarefaLocal, colunaLocal)">

                                        @if (tarefa.Prioridade is not null)
                                        {
                                            <div class="mb-1.5">
                                                <Badge Style="@tarefa.PrioridadeTema"
                                                       Text="@tarefa.Prioridade" />
                                            </div>
                                        }

                                        <Bar>
                                            <StartContent>
                                                <p class="text-sm font-medium text-dark-600">
                                                    @tarefa.Titulo
                                                </p>
                                            </StartContent>
                                            <EndContent>
                                                <DropIconButton
                                                    Icon="WellKnownIcons.MoreVertical"
                                                    Style="Themes.Default"
                                                    Size="Sizes.Small"
                                                    OnClick:stopPropagation>
                                                    @foreach (var dest in colunas.Keys.Where(k => k != colunaLocal))
                                                    {
                                                        var d = dest;
                                                        <DropItem Label="@($"→ {d}")"
                                                                  OnClick="() => MoverParaColuna(tarefaLocal, colunaLocal, d)" />
                                                    }
                                                    <hr class="my-1 border-light-200" />
                                                    <DropItem Label="Excluir" Style="Themes.Danger"
                                                              OnClick="() => ExcluirCard(tarefaLocal, colunaLocal)" />
                                                </DropIconButton>
                                            </EndContent>
                                        </Bar>

                                        @if (tarefa.Tags?.Any() == true)
                                        {
                                            <div class="flex flex-wrap gap-1 mt-1.5">
                                                @foreach (var tag in tarefa.Tags)
                                                {
                                                    <Badge Style="Themes.Light" Text="@tag" />
                                                }
                                            </div>
                                        }

                                        @if (tarefa.ResponsavelNome is not null)
                                        {
                                            <div class="flex items-center gap-1 mt-2">
                                                <div class="w-5 h-5 rounded-full bg-primary-100
                                                            flex items-center justify-center
                                                            text-xs font-bold text-primary-600">
                                                    @tarefa.ResponsavelNome[0]
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
                                                border-dashed border-light-200 rounded
                                                text-xs text-dark-300">
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
}

@* Modal de criar/editar card *@
<Modal @ref="cardFormModal" Id="card-form"
       Title="@(cardEdicao?.Id > 0 ? "Editar tarefa" : $"Nova tarefa em \"{colunaNovoCard}\"")">
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
                            <option value="">Sem prioridade</option>
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
                                    OnClick="() => ExcluirCard(cardEdicao, colunaNovoCard!)" />
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

#### Mobile: uma coluna por vez com seletor

```razor
@* Substituição do scroll horizontal para mobile *@
<div class="block md:hidden mb-4">
    <div class="flex flex-col gap-1">
        <label class="text-xs font-medium text-dark-500">Coluna atual</label>
        <InputSelect @bind-Value="colunaVisivel"
                     class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
            @foreach (var col in colunas.Keys)
            {
                <option value="@col">@col (@colunas[col].Count)</option>
            }
        </InputSelect>
    </div>
</div>
@* No board, usar: class="@(col == colunaVisivel ? "block" : "hidden") md:block" *@
```

### Estados de página

- `loading`: esqueleto por coluna com `animate-pulse` (header + 3 cards falsos);
- `empty` por coluna: `div.border-dashed.border-light-200` com texto "Sem tarefas";
- `filtered empty`: mesmo padrão — filtro ativo não interfere na estrutura da coluna.

## Limites

- **Drag & drop entre colunas não coberto** — `UIP-INTERACTION-DRAG_DROP` é GAP; alternativa: menu "→ Destino";
- `var colunaLocal = coluna.Key` dentro do `@foreach` é obrigatório para captura correta de closure em C#;
- `style="min-width: max-content"` é necessário para que colunas não quebrem em flex container sem largura fixa;
- Persistência da ordem dos cards dentro da coluna requer campo `Ordem` no modelo e atualização na API;
- Colunas dinâmicas (adicionar/remover colunas em runtime) requerem `Modal` adicional de gerenciamento.

### Coordenação

`MoverParaColuna()` atualiza o estado local imediatamente (otimista) e chama a API de forma fire-and-forget. Em caso de erro na API, um mecanismo de rollback é necessário no app consumidor.
