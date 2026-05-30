# SHP-STUDIO_WORKBENCH - Blueprint completo

## Pattern

SHP-STUDIO_WORKBENCH — Studio/Workbench — ver `shp-studio-workbench.ui-map.md`

## Gap coberto

A lib cobre controles periféricos mas não tem shell de workbench. O gap é coordenar: layout `flex flex-col h-screen` sem `AppLayout`; toolbar principal com `Bar + DropButton(Arquivo/Editar) + ferramentas + `ButtonGroup(undo/redo)`; painel explorador esquerdo (`w-56 border-r`); canvas central (`flex-1 relative`); inspector direito (`w-64 border-l`) com campos agrupados; console inferior (`h-32 border-t`). **GAP crítico:** superfície de canvas requer biblioteca externa.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `StudioLayout.razor` com `div.flex.flex-col.h-screen.overflow-hidden`; toolbar `Bar + DropButton(menus) + seletor de ferramenta` no topo; área de trabalho `div.flex.flex-1.overflow-hidden`; explorador `w-56 bg-dark-800 border-r border-dark-700`; canvas `flex-1 bg-light-200 relative overflow-hidden + <canvas id>` gerenciado por lib externa; inspector `w-64 border-l bg-dark-800` com `Box + seções colapsáveis + InputNumber`; console `h-32 border-t` opcional; sem `AppLayout`.
- `eixos cobertos sem componente novo`:
  - toolbar → `Bar + DropButton(menus arquivo/editar) + botões de ferramenta`;
  - explorador → `Bar(título) + Tree view (UIP-DATA-TREE_VIEW)`;
  - inspector → `Bar + Box(seção) + seções colapsáveis + InputNumber/input color`;
  - console → `Bar(título+fechar) + div.font-mono.text-green-400`;
  - canvas → `<canvas>` gerenciado por lib externa via `IJSRuntime`;
  - undo/redo → `IconButton(Undo/Redo) + JS interop`.

## Componentes usados

- `Bar` — papel: principal (toolbar, header de painel) — ver `bar.sample.md`
- `DropButton` — papel: composição (menus Arquivo/Editar) — ver `button.sample.md`
- `DropItem` — papel: composição (itens dos menus) — ver `button.sample.md`
- `IconButton` — papel: composição (undo/redo, fechar painel) — ver `button.sample.md`
- `Box` — papel: composição (seções do inspector) — ver `box.sample.md`
- `Stack` — papel: composição (campos do inspector) — ver `stack.sample.md`
- `Button` — papel: composição (publicar, salvar) — ver `button.sample.md`
- `Modal` — papel: composição (confirmações de arquivo) — ver `modal.sample.md`

## Recursos visuais

- `flex flex-col h-screen overflow-hidden` — shell full-height
- `bg-dark-800 border-dark-700` — painéis laterais escuros (tema de studio)
- `bg-dark-900 text-light-100` — cor de fundo do shell de studio
- `font-mono text-xs text-green-400` — output do console
- `accent-primary-500` — controles de formulário no inspector

## Receita

### Estrutura base

`StudioLayout.razor` com toolbar, explorador, canvas central, inspector e console.

```razor
@* StudioLayout.razor — shell de Studio/Workbench *@
@inherits LayoutComponentBase
@inject IJSRuntime JS
@code {
    private Modal? confirmarNovoModal;
    private bool explorerAberto = true;
    private bool inspectorAberto = true;
    private bool consoleAberto;
    private string ferramentaAtiva = "select";
    private bool modificado;

    private readonly string[] ferramentasList = ["select", "rect", "circle", "text", "line", "hand"];

    private async Task AlterarFerramenta(string f)
    {
        ferramentaAtiva = f;
        await JS.InvokeVoidAsync("studio.setTool", f);
    }

    private async Task Salvar()
    {
        var json = await JS.InvokeAsync<string>("studio.exportJson");
        await StudioService.SalvarAsync(ProjetoAtualId, json);
        modificado = false;
    }
}

<div class="flex flex-col h-screen overflow-hidden bg-dark-900 text-light-100">

    @* Toolbar principal *@
    <div class="flex-shrink-0 border-b border-dark-700 bg-dark-800">
        <Bar AdditionalClasses="px-4 py-1.5">
            <StartContent>
                <span class="font-bold text-sm text-white mr-3">Studio</span>

                <DropButton Label="Arquivo" Style="Themes.Default" Size="Sizes.Small">
                    <DropItem Label="Novo projeto" OnClick="NovoComConfirmacao" />
                    <DropItem Label="Abrir..." OnClick="Abrir" />
                    <DropItem Label="Salvar (Ctrl+S)" OnClick="Salvar" />
                    <hr class="my-1 border-dark-600" />
                    <DropItem Label="Exportar PNG" OnClick='() => JS.InvokeVoidAsync("studio.exportPng")' />
                    <DropItem Label="Exportar SVG" OnClick='() => JS.InvokeVoidAsync("studio.exportSvg")' />
                </DropButton>

                <DropButton Label="Editar" Style="Themes.Default" Size="Sizes.Small">
                    <DropItem Label="Desfazer (Ctrl+Z)"
                              OnClick='() => JS.InvokeVoidAsync("studio.undo")' />
                    <DropItem Label="Refazer (Ctrl+Y)"
                              OnClick='() => JS.InvokeVoidAsync("studio.redo")' />
                    <hr class="my-1 border-dark-600" />
                    <DropItem Label="Selecionar tudo"
                              OnClick='() => JS.InvokeVoidAsync("studio.selectAll")' />
                    <DropItem Label="Excluir selecionado" Style="Themes.Danger"
                              OnClick='() => JS.InvokeVoidAsync("studio.deleteSelected")' />
                </DropButton>
            </StartContent>
            <EndContent>
                @* Seletor de ferramentas *@
                <div class="flex gap-0.5">
                    @foreach (var f in ferramentasList)
                    {
                        <button class="px-2 py-1 text-xs rounded transition-colors
                                       @(ferramentaAtiva == f
                                         ? "bg-primary-600 text-white"
                                         : "text-dark-300 hover:bg-dark-700")"
                                @onclick="() => AlterarFerramenta(f)"
                                title="@f">
                            @f
                        </button>
                    }
                </div>

                <div class="w-px h-4 bg-dark-600"></div>

                <IconButton Icon="WellKnownIcons.Terminal" Style="Themes.Default"
                            Size="Sizes.Small"
                            OnClick="() => consoleAberto = !consoleAberto"
                            Title="Console" />

                <Button Style="Themes.Primary" Size="Sizes.Small"
                        Label="@(modificado ? "Salvar *" : "Salvar")"
                        OnClick="Salvar" />
            </EndContent>
        </Bar>
    </div>

    @* Área de trabalho *@
    <div class="flex flex-1 overflow-hidden">

        @* Explorador de layers (esquerda) *@
        @if (explorerAberto)
        {
            <div class="w-56 flex-shrink-0 border-r border-dark-700 bg-dark-800 flex flex-col">
                <Bar AdditionalClasses="px-3 py-2 border-b border-dark-700">
                    <StartContent>
                        <span class="text-xs font-semibold text-dark-400 uppercase tracking-wide">
                            Layers
                        </span>
                    </StartContent>
                    <EndContent>
                        <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                                    Size="Sizes.Small"
                                    OnClick="() => explorerAberto = false" />
                    </EndContent>
                </Bar>
                <div class="flex-1 overflow-y-auto p-2 text-xs text-dark-300">
                    @* TreeNode de layers — ver UIP-DATA-TREE_VIEW *@
                    @Body
                </div>
            </div>
        }

        @* Canvas central — lib externa *@
        <div class="flex-1 flex flex-col overflow-hidden">
            <div class="flex-1 bg-light-200 relative overflow-hidden">
                <canvas id="studio-canvas" class="absolute inset-0 w-full h-full"></canvas>

                @* Botões para reabrir painéis fechados *@
                @if (!explorerAberto || !inspectorAberto)
                {
                    <div class="absolute top-2 left-2 flex gap-1 z-10">
                        @if (!explorerAberto)
                        {
                            <button class="bg-white/80 rounded px-2 py-1 text-xs
                                           text-dark-600 hover:bg-white shadow-sm"
                                    @onclick="() => explorerAberto = true">
                                Layers
                            </button>
                        }
                        @if (!inspectorAberto)
                        {
                            <button class="bg-white/80 rounded px-2 py-1 text-xs
                                           text-dark-600 hover:bg-white shadow-sm"
                                    @onclick="() => inspectorAberto = true">
                                Props
                            </button>
                        }
                    </div>
                }
            </div>

            @* Console *@
            @if (consoleAberto)
            {
                <div class="h-32 flex-shrink-0 border-t border-dark-700 bg-dark-900 flex flex-col">
                    <Bar AdditionalClasses="px-3 py-1 border-b border-dark-700">
                        <StartContent>
                            <span class="text-xs font-semibold text-dark-400 uppercase">Console</span>
                        </StartContent>
                        <EndContent>
                            <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                                        Size="Sizes.Small"
                                        OnClick="() => consoleAberto = false" />
                        </EndContent>
                    </Bar>
                    <div class="flex-1 overflow-y-auto p-2 font-mono text-xs text-green-400">
                        @* Linhas de output *@
                    </div>
                </div>
            }
        </div>

        @* Inspector de propriedades (direita) *@
        @if (inspectorAberto)
        {
            <div class="w-64 flex-shrink-0 border-l border-dark-700 bg-dark-800 flex flex-col overflow-hidden">
                <Bar AdditionalClasses="px-3 py-2 border-b border-dark-700">
                    <StartContent>
                        <span class="text-xs font-semibold text-dark-400 uppercase tracking-wide">
                            Propriedades
                        </span>
                    </StartContent>
                    <EndContent>
                        <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                                    Size="Sizes.Small"
                                    OnClick="() => inspectorAberto = false" />
                    </EndContent>
                </Bar>
                <div class="flex-1 overflow-y-auto">
                    @* Seção de posição/tamanho *@
                    <div class="border-b border-dark-700">
                        <button class="w-full flex items-center justify-between px-3 py-2 text-xs
                                       text-dark-400 hover:bg-dark-700 font-semibold uppercase">
                            Layout
                        </button>
                        <div class="px-3 pb-3">
                            <Stack Gap="Gaps.Small">
                                <div class="grid grid-cols-2 gap-2">
                                    <div class="flex flex-col gap-0.5">
                                        <label class="text-xs text-dark-500">X</label>
                                        <InputNumber @bind-Value="elementoX"
                                                     @onchange="AtualizarPosicao"
                                                     class="w-full bg-dark-900 border border-dark-600
                                                            rounded px-2 py-1 text-xs text-light-100
                                                            focus:ring-1 focus:ring-primary-500" />
                                    </div>
                                    <div class="flex flex-col gap-0.5">
                                        <label class="text-xs text-dark-500">Y</label>
                                        <InputNumber @bind-Value="elementoY"
                                                     @onchange="AtualizarPosicao"
                                                     class="w-full bg-dark-900 border border-dark-600
                                                            rounded px-2 py-1 text-xs text-light-100" />
                                    </div>
                                </div>
                            </Stack>
                        </div>
                    </div>
                    @* Mais seções do inspector... *@
                </div>
            </div>
        }
    </div>
</div>

@* Modal de confirmação *@
<Modal @ref="confirmarNovoModal" Id="confirmar-novo" Title="Novo projeto">
    <ChildContent>
        <p class="text-sm text-dark-600">
            Você tem alterações não salvas. Deseja descartar e criar um novo projeto?
        </p>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Cancelar"
                OnClick='async () => await confirmarNovoModal!.CloseAsync()' />
        <Button Style="Themes.Danger" Label="Descartar e criar"
                OnClick="CriarNovoProjeto" />
    </FooterContent>
</Modal>
```

### Cenários de composição

#### Confirmar antes de criar novo

```razor
@code {
    private async Task NovoComConfirmacao()
    {
        if (modificado)
            await confirmarNovoModal!.OpenAsync();
        else
            await CriarNovoProjeto();
    }

    private async Task CriarNovoProjeto()
    {
        await JS.InvokeVoidAsync("studio.reset");
        modificado = false;
        await confirmarNovoModal!.CloseAsync();
    }
}
```

### Estados de página

- `canvas vazio`: placeholder `div.absolute.inset-0.flex.items-center.justify-center` com texto "Comece adicionando um elemento";
- `loading (inicializando lib)`: overlay `absolute inset-0 bg-light-100/50 flex items-center justify-center` com spinner;
- `erro de lib externa`: `Feedback(Danger)` flutuante no canvas.

## Limites

- **Superfície de canvas é GAP crítico** — Fabric.js, Konva.js, tldraw, etc. são obrigatórios; a lib cobre apenas a camada de controles;
- `AppLayout` NÃO deve ser usado — layout do studio é `flex flex-col h-screen` sem sidebar de admin;
- Resize de painéis laterais requer JS drag com `mousedown + mousemove` — sem nativo;
- Persistência do layout (larguras dos painéis) requer `localStorage` via `IJSRuntime`;
- Inspector com `InputNumber` e `input[type=color]` recebem classes Tailwind manuais — sem estilo da lib;
- `[JSInvokable]` necessário para receber eventos do canvas (clique, seleção, modificação) de volta para C#.

### Responsividade

Workbench não é adequado para mobile. Em telas < md: exibir aviso "Utilize um dispositivo maior para o editor" em vez do layout completo.
