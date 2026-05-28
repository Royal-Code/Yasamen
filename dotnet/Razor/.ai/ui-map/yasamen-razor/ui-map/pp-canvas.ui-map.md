# PP-CANVAS - Canvas

**GAP crítico — UIP-SURFACE-CANVAS é GAP (nota 0)**

A biblioteca não tem componente de canvas/superfície de edição. PP-CANVAS depende de `UIP-SURFACE-CANVAS` como superfície principal, que é GAP completo. A implementação requer biblioteca externa especializada (Fabric.js, Konva.js, Excalidraw, tldraw, etc.).

## Componentes por zona funcional

### Zona: Superfície (canvas) — GAP

1. (UIP-SURFACE-CANVAS — nota 0)
- `cobertura`: sem cobertura nativa; superfície de desenho/composição requer biblioteca externa;
- `nota`: 0;
- `justificativa`: GAP crítico — toda a área de canvas é responsabilidade de biblioteca externa.

### Zona: Toolbar de ferramentas

1. Bar + IconButton (toolbar persistente)
- `cobertura`: ferramentas ativas (selecionar, desenhar, texto, formas); toggle de ferramenta atual;
- `nota`: 7;
- `justificativa`: toolbar de ferramentas — barra de ações adaptada.

2. ButtonGroup (grupo de ferramentas)
- `cobertura`: agrupamento de ferramentas relacionadas com seleção ativa;
- `nota`: 7;
- `justificativa`: grupo de ferramentas com estado ativo.

### Zona: Inspector / Propriedades

1. Box + Bar + FormGroup (inspector de propriedades)
- `cobertura`: painel lateral de propriedades do objeto selecionado; `FieldText`, `FieldSelect`, `FieldNumber`;
- `nota`: 6;
- `justificativa`: inspector de propriedades — composição manual funcional.

### Zona: Ações

1. Bar + Button (barra de ações do canvas)
- `cobertura`: "Salvar", "Exportar", "Desfazer", "Refazer"; ações de arquivo;
- `nota`: 7;
- `justificativa`: ações globais do canvas — cobertura direta.

2. Modal (UIP-FEEDBACK-CONFIRMATION_DIALOG)
- `cobertura`: "Descartar alterações?", "Exportar para...";
- `nota`: 9;
- `justificativa`: confirmações de ação destrutiva.

3. DropButton (opções de exportação)
- `cobertura`: exportar como PNG, SVG, PDF, JSON;
- `nota`: 8;
- `justificativa`: menu de formatos de exportação.

**Descartados**: nenhum.

## Estrutura de shell para PP-CANVAS

```razor
@* Layout de canvas: toolbar + canvas central + inspector *@
@page "/editor"
@inject IJSRuntime JS

@code {
    private string ferramentaAtiva = "select";
    private ObjetoDto? objetoSelecionado;
    private bool inspectorAberto = true;
    private bool confirmandoSaida;

    private readonly string[] ferramentas = ["select", "rect", "circle", "line", "text"];
}

<div class="flex flex-col h-full">
    @* Toolbar superior *@
    <Bar AdditionalClasses="px-4 py-2 border-b border-light-200 bg-white flex-shrink-0">
        <StartContent>
            @* Título e arquivo *@
            <span class="text-sm font-semibold text-dark-700">Editor</span>
        </StartContent>
        <EndContent>
            @* Ferramentas *@
            <div class="flex gap-1 mr-4">
                @foreach (var ferramenta in ferramentas)
                {
                    <button class="p-1.5 rounded text-sm transition-colors
                                   @(ferramentaAtiva == ferramenta
                                     ? "bg-primary-100 text-primary-700"
                                     : "text-dark-400 hover:bg-light-100")"
                            title="@ferramenta"
                            @onclick="() => ferramentaAtiva = ferramenta">
                        @* Ícone da ferramenta *@
                    </button>
                }
            </div>

            @* Ações *@
            <IconButton Icon="WellKnownIcons.Undo" Style="Themes.Default"
                       OnClick='async () => await JS.InvokeVoidAsync("editorUndo")' />
            <IconButton Icon="WellKnownIcons.Redo" Style="Themes.Default"
                       OnClick='async () => await JS.InvokeVoidAsync("editorRedo")' />

            <DropButton Label="Exportar" Style="Themes.Default">
                <DropItem Label="PNG" OnClick='async () => await JS.InvokeVoidAsync("exportPng")' />
                <DropItem Label="SVG" OnClick='async () => await JS.InvokeVoidAsync("exportSvg")' />
            </DropButton>

            <Button Style="Themes.Primary" Label="Salvar" OnClick="Salvar" />
        </EndContent>
    </Bar>

    @* Área de trabalho *@
    <div class="flex flex-1 overflow-hidden">
        @* Canvas central (preenchido por Fabric.js / Konva.js / etc.) *@
        <div class="flex-1 bg-light-100 relative overflow-hidden">
            <canvas id="editor-canvas" class="w-full h-full"></canvas>
        </div>

        @* Inspector de propriedades *@
        @if (inspectorAberto && objetoSelecionado is not null)
        {
            <div class="w-64 flex-shrink-0 border-l border-light-200 flex flex-col overflow-hidden">
                <Bar AdditionalClasses="px-3 py-2 border-b border-light-200 bg-light-50">
                    <StartContent>
                        <span class="text-xs font-semibold text-dark-500 uppercase">
                            Propriedades
                        </span>
                    </StartContent>
                    <EndContent>
                        <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                                   Size="Sizes.Small"
                                   OnClick="() => inspectorAberto = false" />
                    </EndContent>
                </Bar>
                <div class="flex-1 overflow-y-auto p-3">
                    @* [inferido] FormGroup/FieldNumber não existem — usar Stack + InputNumber/TextField *@
                    <Stack Gap="Gaps.Small">
                        <div class="grid grid-cols-2 gap-2">
                            <div class="flex flex-col gap-0.5">
                                <label class="text-xs text-dark-400">X</label>
                                <InputNumber @bind-Value="objetoSelecionado.X" class="w-full border border-light-300 rounded px-2 py-1 text-sm" />
                            </div>
                            <div class="flex flex-col gap-0.5">
                                <label class="text-xs text-dark-400">Y</label>
                                <InputNumber @bind-Value="objetoSelecionado.Y" class="w-full border border-light-300 rounded px-2 py-1 text-sm" />
                            </div>
                            <div class="flex flex-col gap-0.5">
                                <label class="text-xs text-dark-400">Largura</label>
                                <InputNumber @bind-Value="objetoSelecionado.Largura" class="w-full border border-light-300 rounded px-2 py-1 text-sm" />
                            </div>
                            <div class="flex flex-col gap-0.5">
                                <label class="text-xs text-dark-400">Altura</label>
                                <InputNumber @bind-Value="objetoSelecionado.Altura" class="w-full border border-light-300 rounded px-2 py-1 text-sm" />
                            </div>
                        </div>
                        <TextField @bind-Value="objetoSelecionado.Cor" Label="Cor (hex)" />
                    </Stack>
                </div>
            </div>
        }
    </div>
</div>

@* Confirmação de saída *@
<Modal Title="Descartar alterações?"
       @bind-IsOpen="confirmandoSaida"
       Size="ModalSize.Small">
    <ChildContent>
        <p class="text-sm text-dark-600">
            Existem alterações não salvas. Deseja sair sem salvar?
        </p>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Continuar editando"
                OnClick="() => confirmandoSaida = false" />
        <Button Style="Themes.Danger" Label="Descartar"
                OnClick='() => Nav.NavigateTo("/")' />
    </FooterContent>
</Modal>
```

## Decisão de uso

- `nota geral`: 1;
- `limitações`: sem componente de canvas nativo — GAP crítico; toda a superfície de edição requer biblioteca externa especializada; pan/zoom, seleção, layers e manipulação de objetos são fora do escopo da lib;
- `recomendação`: `usar apenas como apoio`
- `justificativa geral`:
  - `Bar` + `IconButton` + `DropButton` cobrem toolbar e ações globais do canvas com boa qualidade;
  - Inspector de propriedades via `FormGroup` é funcional para objetos simples;
  - A superfície de edição é 100% responsabilidade de biblioteca externa;
  - Nota 1 reflete que a lib cobre apenas a camada de shell do PP-CANVAS.
