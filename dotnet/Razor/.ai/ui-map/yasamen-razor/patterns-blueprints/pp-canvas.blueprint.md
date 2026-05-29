# PP-CANVAS - Blueprint resumido

## Pattern

PP-CANVAS — Canvas / Visual Editor Page — ver `pp-canvas.ui-map.md`

## Gap coberto

**GAP crítico (nota 1):** A lib não tem componente de canvas ou editor visual. A superfície de desenho/edição requer biblioteca externa (Fabric.js, Konva.js, Excalidraw, etc.) via JS interop. O gap é orientar: shell do editor com toolbar de ferramentas via `Bar + ButtonGroup`, painel inspector via `Box + Stack + InputNumber`, e integração com `IJSRuntime` para a superfície. A lib cobre o shell; a lib externa cobre a superfície.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `flex flex-col h-full` como shell do editor; toolbar superior com `Bar + ButtonGroup(ferramentas) + DropButton(exportar) + Button(salvar)`; `<canvas id="editor-canvas" class="w-full h-full">` gerenciado por lib externa; inspector lateral `w-64 shrink-0 border-l` com `Box + Stack + InputNumber` para propriedades do elemento selecionado; `ModalService` para diálogo de exportação.

## Componentes usados

- `Bar` — papel: principal (toolbar do editor) — ver `bar.sample.md`
- `ButtonGroup + Button` — papel: composição (seletor de ferramenta, ações) — ver `button.sample.md`
- `IconButton` — papel: composição (undo/redo, zoom, fechar inspector) — ver `button.sample.md`
- `DropButton` — papel: composição (menu de exportação) — ver `button.sample.md`
- `Box` — papel: composição (seção do inspector) — ver `box.sample.md`
- `Stack` — papel: composição (campos do inspector) — ver `bar.sample.md`
- `Modal` — papel: composição (confirmar exportação/fechar sem salvar) — ver `modal.sample.md`

## Recursos visuais

- `flex flex-col h-full overflow-hidden` — shell ocupa toda a área disponível
- `flex flex-1 overflow-hidden` — área de trabalho (canvas + inspector)
- `w-64 flex-shrink-0 border-l border-light-200 overflow-y-auto` — inspector lateral
- `bg-light-100` — fundo da superfície de canvas

## Receita

Toolbar `Bar` no topo; `div.flex.flex-1` com `<canvas>` e inspector lateral; `IJSRuntime` inicializa lib no `OnAfterRenderAsync`.

```razor
@page "/editor/{ProjetoId:int}"
@inject IJSRuntime JS
@inject ModalService ModalService
@inject ProjetoService ProjetoService
@implements IAsyncDisposable

@code {
    [Parameter] public int ProjetoId { get; set; }

    private string ferramentaAtiva = "selecionar"; // "selecionar" | "retangulo" | "circulo" | "texto" | "mao"
    private ElementoSelecionadoDto? elementoSelecionado;
    private bool salvando;
    private bool modificado;

    private string[] ferramentas = ["selecionar", "retangulo", "circulo", "texto", "mao"];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var projeto = await ProjetoService.ObterAsync(ProjetoId);
            await JS.InvokeVoidAsync("canvas.inicializar", "editor-canvas",
                DotNetObjectReference.Create(this), projeto.DadosJson);
        }
    }

    [JSInvokable]
    public void OnElementoSelecionado(ElementoSelecionadoDto? elemento)
    {
        elementoSelecionado = elemento;
        StateHasChanged();
    }

    [JSInvokable]
    public void OnCanvasModificado()
    {
        modificado = true;
        StateHasChanged();
    }

    private async Task AlterarFerramenta(string ferramenta)
    {
        ferramentaAtiva = ferramenta;
        await JS.InvokeVoidAsync("canvas.setFerramenta", ferramenta);
    }

    private async Task Salvar()
    {
        salvando = true;
        var json = await JS.InvokeAsync<string>("canvas.exportarJson");
        await ProjetoService.SalvarAsync(ProjetoId, json);
        modificado = false;
        salvando = false;
    }

    private async Task Desfazer() => await JS.InvokeVoidAsync("canvas.undo");
    private async Task Refazer()  => await JS.InvokeVoidAsync("canvas.redo");

    public async ValueTask DisposeAsync()
        => await JS.InvokeVoidAsync("canvas.destruir");
}

<div class="flex flex-col h-full overflow-hidden">

    @* Toolbar superior *@
    <Bar AdditionalClasses="border-b border-light-200 px-3 py-1.5 flex-shrink-0">
        <StartContent>
            @* Seletor de ferramentas *@
            <ButtonGroup>
                @foreach (var f in ferramentas)
                {
                    <Button Style="@(ferramentaAtiva == f ? Themes.Primary : Themes.Default)"
                            Size="Sizes.Small"
                            Label="@f"
                            OnClick="() => AlterarFerramenta(f)" />
                }
            </ButtonGroup>
        </StartContent>
        <EndContent>
            @* Undo / Redo *@
            <IconButton Icon="WellKnownIcons.Undo" Style="Themes.Default"
                        Size="Sizes.Small" OnClick="Desfazer" Title="Desfazer" />
            <IconButton Icon="WellKnownIcons.Redo" Style="Themes.Default"
                        Size="Sizes.Small" OnClick="Refazer" Title="Refazer" />

            @* Exportar *@
            <DropButton Style="Themes.Default" Size="Sizes.Small" Label="Exportar">
                <DropItem Label="Exportar como PNG"
                          OnClick="() => JS.InvokeVoidAsync("canvas.exportarPng")" />
                <DropItem Label="Exportar como SVG"
                          OnClick="() => JS.InvokeVoidAsync("canvas.exportarSvg")" />
                <DropItem Label="Exportar como JSON"
                          OnClick="() => JS.InvokeVoidAsync("canvas.exportarJsonDownload")" />
            </DropButton>

            @* Salvar *@
            <Button Style="Themes.Primary" Size="Sizes.Small"
                    Label="@(modificado ? "Salvar *" : "Salvar")"
                    Loading="@salvando"
                    OnClick="Salvar" />
        </EndContent>
    </Bar>

    @* Área de trabalho *@
    <div class="flex flex-1 overflow-hidden">

        @* Superfície do canvas — gerenciada por biblioteca externa *@
        <div class="flex-1 overflow-hidden bg-light-100 flex items-center justify-center">
            <canvas id="editor-canvas" class="w-full h-full"></canvas>
        </div>

        @* Inspector lateral *@
        @if (elementoSelecionado is not null)
        {
            <div class="w-64 flex-shrink-0 border-l border-light-200 overflow-y-auto">
                <Bar AdditionalClasses="px-3 py-2 border-b border-light-100">
                    <StartContent>
                        <span class="text-xs font-semibold text-dark-600 uppercase tracking-wide">
                            Inspector
                        </span>
                    </StartContent>
                    <EndContent>
                        <IconButton Icon="WellKnownIcons.X" Style="Themes.Default"
                                    Size="Sizes.Small"
                                    OnClick="() => { elementoSelecionado = null; }" />
                    </EndContent>
                </Bar>

                <div class="p-3 space-y-4">
                    @* Posição e tamanho *@
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
                        <p class="text-xs font-semibold text-dark-600 mb-2">Posição e tamanho</p>
                        <Stack Gap="Gaps.Small">
                            <div class="grid grid-cols-2 gap-2">
                                <div class="flex flex-col gap-1">
                                    <label class="text-xs text-dark-400">X</label>
                                    <InputNumber @bind-Value="elementoSelecionado.X"
                                                 @onchange="AtualizarElemento"
                                                 class="w-full border border-light-300 rounded px-2 py-1 text-sm" />
                                </div>
                                <div class="flex flex-col gap-1">
                                    <label class="text-xs text-dark-400">Y</label>
                                    <InputNumber @bind-Value="elementoSelecionado.Y"
                                                 @onchange="AtualizarElemento"
                                                 class="w-full border border-light-300 rounded px-2 py-1 text-sm" />
                                </div>
                            </div>
                            <div class="grid grid-cols-2 gap-2">
                                <div class="flex flex-col gap-1">
                                    <label class="text-xs text-dark-400">Largura</label>
                                    <InputNumber @bind-Value="elementoSelecionado.Largura"
                                                 @onchange="AtualizarElemento"
                                                 class="w-full border border-light-300 rounded px-2 py-1 text-sm" />
                                </div>
                                <div class="flex flex-col gap-1">
                                    <label class="text-xs text-dark-400">Altura</label>
                                    <InputNumber @bind-Value="elementoSelecionado.Altura"
                                                 @onchange="AtualizarElemento"
                                                 class="w-full border border-light-300 rounded px-2 py-1 text-sm" />
                                </div>
                            </div>
                        </Stack>
                    </Box>

                    @* Aparência *@
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
                        <p class="text-xs font-semibold text-dark-600 mb-2">Aparência</p>
                        <Stack Gap="Gaps.Small">
                            <div class="flex flex-col gap-1">
                                <label class="text-xs text-dark-400">Cor de preenchimento</label>
                                <input type="color" @bind="elementoSelecionado.CorPreenchimento"
                                       @onchange="AtualizarElemento"
                                       class="w-full h-8 rounded border border-light-300 cursor-pointer" />
                            </div>
                            <div class="flex flex-col gap-1">
                                <label class="text-xs text-dark-400">Cor da borda</label>
                                <input type="color" @bind="elementoSelecionado.CorBorda"
                                       @onchange="AtualizarElemento"
                                       class="w-full h-8 rounded border border-light-300 cursor-pointer" />
                            </div>
                        </Stack>
                    </Box>
                </div>
            </div>
        }
    </div>
</div>
```

## Limites

- **Superfície de canvas requer biblioteca JS externa** — Fabric.js, Konva.js, Excalidraw, tldraw, etc.; a lib Yasamen não cobre;
- `[JSInvokable]` exige `DotNetObjectReference` gerenciado manualmente — descartar no `DisposeAsync`;
- Inspector com `InputNumber` e `input[type=color]` não recebem estilo da lib — estilo Tailwind manual;
- Colaboração em tempo real requer SignalR + CRDT — fora do escopo da lib;
- `modificado = true` rastreado por evento JS — alternativa: polling `canvas.contemAlteracoes()` com `Timer`;
- Para salvar ao navegar: interceptar `NavigationManager.RegisterLocationChangingHandler` com modal de confirmação.
