# SHP-STUDIO_WORKBENCH - Studio/Workbench

**GAP parcial — lib cobre shell primitivo, não workbench completo**

A biblioteca não tem shell de workbench nativo. SHP-STUDIO_WORKBENCH com canvas central + painéis laterais + toolbar persistente requer composição substancial com CSS e JavaScript. A lib cobre a camada de controles (toolbars, botões, formulários de inspector) mas não a superfície de edição.

## Componentes por zona funcional

### Zona: Shell (estrutura)

1. CSS flex (estrutura do workbench)
- `cobertura`: layout `flex h-screen` com toolbar topo + explorador esquerdo + canvas central + inspector direito + console inferior;
- `nota`: 4;
- `justificativa`: estrutura CSS manual — UIP-STRUCT-DOCKED_PANEL_SET (nota 2) sem abstração.

2. Bar (toolbar principal)
- `cobertura`: barra de ferramentas superior com ações de arquivo, edição, visualização; undo/redo;
- `nota`: 7;
- `justificativa`: toolbar principal do workbench.

### Zona: Superfície — GAP

1. (UIP-SURFACE-CANVAS — nota 0)
- `cobertura`: sem componente de canvas nativo — GAP crítico;
- `nota`: 0;
- `justificativa`: toda a superfície de edição é responsabilidade de biblioteca externa.

### Zona: Painel de ferramentas

1. IconButton (ferramentas de tool palette)
- `cobertura`: toggle de ferramenta ativa (selecionar, mover, formas, texto, etc.);
- `nota`: 7;
- `justificativa`: palette de ferramentas com estado ativo.

2. Bar (header de painel)
- `cobertura`: título do painel + ações de minimizar/fechar;
- `nota`: 8;
- `justificativa`: cabeçalho compacto de painel lateral.

### Zona: Inspector

1. Box + FormGroup + FieldText/FieldNumber/FieldSelect (inspector de propriedades)
- `cobertura`: propriedades do elemento selecionado (posição, tamanho, cor, fonte);
- `nota`: 7;
- `justificativa`: inspector de propriedades — composição com campos de formulário.

2. uip-struct-collapsible-section (grupos de propriedades)
- `cobertura`: seções colapsáveis no inspector (Layout, Aparência, Interação, Dados);
- `nota`: 5;
- `justificativa`: agrupamento de propriedades por categoria.

### Zona: Explorador

1. uip-data-tree-view (explorador de assets/layers)
- `cobertura`: árvore de layers, componentes ou assets; seleção, renomear, excluir;
- `nota`: 3;
- `justificativa`: explorador de hierarquia — componente recursivo manual (ver UIP-DATA-TREE_VIEW).

### Zona: Console/Output

1. Box + HTML `<code>` (painel de console)
- `cobertura`: output de logs, erros, mensagens do compilador;
- `nota`: 4;
- `justificativa`: painel de output — container básico.

### Zona: Ações

1. DropButton (exportar/publicar)
- `cobertura`: "Exportar como PNG/SVG/JSON", "Publicar";
- `nota`: 8;
- `justificativa`: ações de publicação do workbench.

2. Modal (confirmações: novo, abrir, salvar como)
- `cobertura`: confirmações de arquivo ("Descartar alterações?");
- `nota`: 9;
- `justificativa`: diálogos de operação de arquivo.

**Descartados**: AppLayout (shell de admin, não de workbench).

## Estrutura de shell

```razor
@* StudioLayout.razor — shell de Studio/Workbench *@
@inherits LayoutComponentBase

@code {
    private bool explorerAberto = true;
    private bool inspectorAberto = true;
    private bool consoleAberto;
    private string ferramentaAtiva = "select";
}

<div class="flex flex-col h-screen overflow-hidden bg-dark-900 text-light-100">
    @* Toolbar superior *@
    <div class="flex-shrink-0 border-b border-dark-700 bg-dark-800">
        <Bar AdditionalClasses="px-4 py-2">
            <StartContent>
                <span class="font-bold text-sm text-white mr-4">Studio</span>
                <DropButton Label="Arquivo" Style="Themes.Default" Size="Sizes.Small">
                    <DropItem Label="Novo" OnClick="Novo" />
                    <DropItem Label="Abrir" OnClick="Abrir" />
                    <DropItem Label="Salvar" OnClick="Salvar" />
                    <hr class="my-1 border-dark-600" />
                    <DropItem Label="Exportar" OnClick="Exportar" />
                </DropButton>
                <DropButton Label="Editar" Style="Themes.Default" Size="Sizes.Small">
                    <DropItem Label="Desfazer (Ctrl+Z)" OnClick='async () => await JS.InvokeVoidAsync("undo")' />
                    <DropItem Label="Refazer (Ctrl+Y)" OnClick='async () => await JS.InvokeVoidAsync("redo")' />
                </DropButton>
            </StartContent>
            <EndContent>
                @* Ferramentas *@
                <div class="flex gap-1">
                    @foreach (var f in new[] { "select", "rect", "circle", "text", "line" })
                    {
                        <button class="px-2 py-1 text-xs rounded transition-colors
                                       @(ferramentaAtiva == f
                                         ? "bg-primary-600 text-white"
                                         : "text-dark-300 hover:bg-dark-700")"
                                @onclick="() => ferramentaAtiva = f">
                            @f
                        </button>
                    }
                </div>
                <div class="w-px h-4 bg-dark-600"></div>
                @* Zoom *@
                <span class="text-xs text-dark-400">100%</span>
                <Button Style="Themes.Default" Size="Sizes.Small" Label="Publicar"
                        AdditionalClasses="ml-2" />
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
                        <span class="text-xs font-semibold text-dark-400 uppercase">Layers</span>
                    </StartContent>
                    <EndContent>
                        <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                                   Size="Sizes.Small"
                                   OnClick="() => explorerAberto = false" />
                    </EndContent>
                </Bar>
                <div class="flex-1 overflow-y-auto p-2 text-xs text-dark-300">
                    @* TreeNode de layers *@
                </div>
            </div>
        }

        @* Canvas central *@
        <div class="flex-1 flex flex-col overflow-hidden">
            <div class="flex-1 bg-light-200 relative overflow-hidden">
                <canvas id="studio-canvas" class="absolute inset-0 w-full h-full"></canvas>
            </div>

            @* Console inferior *@
            @if (consoleAberto)
            {
                <div class="h-32 flex-shrink-0 border-t border-dark-700 bg-dark-900 flex flex-col">
                    <Bar AdditionalClasses="px-3 py-1 border-b border-dark-700">
                        <StartContent>
                            <span class="text-xs font-semibold text-dark-400 uppercase">
                                Console
                            </span>
                        </StartContent>
                        <EndContent>
                            <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                                       Size="Sizes.Small"
                                       OnClick="() => consoleAberto = false" />
                        </EndContent>
                    </Bar>
                    <div class="flex-1 overflow-y-auto p-2 font-mono text-xs text-green-400">
                        @* output *@
                    </div>
                </div>
            }
        </div>

        @* Inspector de propriedades (direita) *@
        @if (inspectorAberto)
        {
            <div class="w-64 flex-shrink-0 border-l border-dark-700 bg-dark-800 flex flex-col
                        overflow-hidden">
                <Bar AdditionalClasses="px-3 py-2 border-b border-dark-700">
                    <StartContent>
                        <span class="text-xs font-semibold text-dark-400 uppercase">
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
                    @Body
                </div>
            </div>
        }
    </div>
</div>
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem shell de workbench nativo; canvas é GAP crítico; painéis laterais sem resize; drag/drop entre painéis sem suporte; toda a estrutura multi-painel é CSS manual; para IDE/studio completo requer implementação substancial ou biblioteca dedicada;
- `recomendação`: `usar apenas como apoio`
- `justificativa geral`:
  - `Bar` + `IconButton` + `DropButton` + `FormGroup` no inspector cobrem a camada de controles do workbench;
  - A superfície de edição e a estrutura de docking são GAP — requerem biblioteca externa (Fabric.js, Konva.js, Monaco, etc.);
  - Nota 2 reflete que a lib cobre apenas os controles periféricos do SHP-STUDIO_WORKBENCH.
