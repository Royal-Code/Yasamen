# UIP-STRUCT-DOCKED_PANEL_SET - Docked Panel Set

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de workspace multi-painel. `AppLayout` + `AppSideBar` cobrem dois painéis (sidebar + main). Para três ou mais painéis acoplados requer composição CSS com `flex` aninhado + divisores + estado de colapso por painel.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. AppLayout + AppSideBar
- `cobertura`: layout de dois painéis (sidebar esquerda + área principal); colapso da sidebar; scroll independente; sem painel inferior ou direito nativo;
- `nota`: 5;
- `justificativa`: cobre o caso mais comum de workspace admin com dois painéis — base para composição de mais painéis.

2. Box (container de painel)
- `cobertura`: painel visual com borda; cabeçalho com `Bar`; scroll interno com `overflow-y-auto`;
- `nota`: 6;
- `justificativa`: container de painel individual com header e scroll.

3. Bar (header de painel)
- `cobertura`: título do painel + ações de colapso/toggle + badge de contagem;
- `nota`: 7;
- `justificativa`: cabeçalho de painel com controles.

4. Stack (conteúdo de painel de lista)
- `cobertura`: lista de itens dentro de um painel lateral;
- `nota`: 7;
- `justificativa`: conteúdo de painel de explorador/navegação.

5. uip-struct-collapsible-section (seção dentro de painel)
- `cobertura`: subgrupos colapsáveis dentro de painel lateral (ex.: seções de explorador de arquivos);
- `nota`: 5;
- `justificativa`: composição de seções colapsáveis dentro de painel acoplado.

**Descartados**: Container+Slot (grade responsiva, não workspace fixo); OffCanvas (temporário, não acoplado).

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `painel inferior (output/console)`: CSS `flex-col` na área principal + `h-40` no painel inferior;
  - `divisores redimensionáveis`: JS com drag para ajustar widths/heights dinamicamente;
  - `abas nos painéis`: `uip-nav-tabs` dentro de cada painel (ver nota 3 da cobertura de tabs);
  - `persistência de layout (widths/estado)`: `localStorage` via JS interop;
  - `três ou mais painéis simultâneos`: composição CSS `flex` aninhada manual.

- `tipo de adaptação`: composição CSS manual com AppLayout como base
- `o que precisa ser feito`:
  - `AppLayout` para estrutura raiz; `AppSideBar` para painel esquerdo;
  - Painel direito de inspector: `div.w-72 border-l flex-col` dentro da área de conteúdo;
  - Painel inferior: `div.h-40 border-t` no flex-col da área principal;
  - Estado de colapso por painel: `bool painelDireitoAberto`, `bool painelInferiorAberto`.

## Como usar

### Layout IDE com três painéis (explorador + editor + inspector)

```razor
@code {
    private bool explorerAberto = true;
    private bool inspectorAberto = true;
    private bool consoleAberto = false;
}

<AppLayout>
    @* Painel esquerdo: explorador *@
    <AppSideBar>
        <div class="flex flex-col h-full">
            <Bar AdditionalClasses="px-3 py-2 border-b border-light-200 bg-light-50">
                <StartContent>
                    <span class="text-xs font-semibold text-dark-500 uppercase tracking-wide">
                        Explorador
                    </span>
                </StartContent>
                <EndContent>
                    <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                               Size="Sizes.Small"
                               OnClick="() => explorerAberto = false" />
                </EndContent>
            </Bar>
            <div class="flex-1 overflow-y-auto p-2">
                @* tree view ou lista de arquivos *@
            </div>
        </div>
    </AppSideBar>

    @* Área principal *@
    <div class="flex flex-1 overflow-hidden">
        @* Editor central *@
        <div class="flex-1 flex flex-col overflow-hidden">
            @* tabs de arquivos abertos *@
            <div class="flex border-b border-light-200 bg-light-50 overflow-x-auto">
                @foreach (var aba in abasAbertas)
                {
                    <button class="px-4 py-2 text-xs border-r border-light-200 flex-shrink-0
                                   @(aba.Ativa ? "bg-white text-dark-700" : "text-dark-400 hover:bg-light-100")">
                        @aba.Nome
                    </button>
                }
            </div>
            @* área de edição *@
            <div class="flex-1 overflow-auto p-4">
                @* conteúdo do editor *@
            </div>

            @* painel inferior: console/output *@
            @if (consoleAberto)
            {
                <div class="h-40 border-t border-light-200 flex flex-col">
                    <Bar AdditionalClasses="px-3 py-1 bg-light-50 border-b border-light-200">
                        <StartContent>
                            <span class="text-xs font-semibold text-dark-500">Console</span>
                        </StartContent>
                        <EndContent>
                            <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                                       Size="Sizes.Small"
                                       OnClick="() => consoleAberto = false" />
                        </EndContent>
                    </Bar>
                    <div class="flex-1 overflow-y-auto p-2 font-mono text-xs text-dark-600 bg-dark-900 text-green-300">
                        @* output do console *@
                    </div>
                </div>
            }
        </div>

        @* Painel direito: inspector de propriedades *@
        @if (inspectorAberto)
        {
            <div class="w-64 flex-shrink-0 border-l border-light-200 flex flex-col overflow-hidden">
                <Bar AdditionalClasses="px-3 py-2 border-b border-light-200 bg-light-50">
                    <StartContent>
                        <span class="text-xs font-semibold text-dark-500 uppercase tracking-wide">
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
                    @* propriedades do elemento selecionado *@
                </div>
            </div>
        }
    </div>
</AppLayout>
```

### Toolbar para abrir painéis fechados

```razor
@* Toolbar compacta na borda *@
<div class="flex items-center gap-1 p-1 border-b border-light-200 bg-light-50">
    <IconButton Icon="WellKnownIcons.Folder" Style="Themes.Default" Size="Sizes.Small"
               OnClick="() => explorerAberto = true"
               title="Explorador" />
    <IconButton Icon="WellKnownIcons.Terminal" Style="Themes.Default" Size="Sizes.Small"
               OnClick="() => consoleAberto = !consoleAberto"
               title="Console" />
    <IconButton Icon="WellKnownIcons.Settings" Style="Themes.Default" Size="Sizes.Small"
               OnClick="() => inspectorAberto = true"
               title="Propriedades" />
</div>
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem componente de docked panel set nativo; `AppLayout`+`AppSideBar` cobrem apenas dois painéis; painel inferior, direito e painéis tabulados são CSS manual; sem resize de painéis; sem persistência de layout; toda a coordenação entre painéis é responsabilidade do app;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `AppLayout` + CSS `flex` aninhado cobre workspace com dois a quatro painéis estáticos;
  - Para IDE/workbench real com resize e docking: implementação substancial necessária ou biblioteca externa;
  - Nota 2 reflete cobertura estrutural mínima — adequado para variantes simples de SHP-WORKSPACE_ADMIN, não para SHP-STUDIO_WORKBENCH.
