# UIP-STRUCT-DOCKED_PANEL_SET - Blueprint completo

## Pattern

UIP-STRUCT-DOCKED_PANEL_SET — Docked Panel Set — ver `uip-struct-docked-panel-set.ui-map.md`

## Gap coberto

A lib tem `AppLayout + AppSideBar` para dois painéis (sidebar esquerda + área principal). O gap é coordenar workspace com três ou mais painéis acoplados: painel direito (inspector), painel inferior (console/output) e abas de arquivos dentro da área central. Todos requerem composição CSS manual com `flex` aninhado, estado booleano por painel e gestão de scroll independente.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `AppLayout + AppSideBar` como base do painel esquerdo; painel direito via `div.w-64 flex-shrink-0 border-l`; painel inferior via `div.h-40 border-t`; abas de editor via `div.flex border-b` manual; estado de colapso com `bool` por painel.
- `eixos cobertos sem componente novo`:
  - painel esquerdo → `AppSideBar` (nativo, com colapso);
  - header de painel → `Bar` (título + IconButton de fechar);
  - conteúdo de painel → `Stack` ou `div.overflow-y-auto`;
  - seções colapsáveis dentro de painel → `uip-struct-collapsible-section` pattern.

## Componentes usados

- `AppLayout` — papel: principal (estrutura de dois painéis raiz) — ver `bar.sample.md`
- `AppSideBar` — papel: principal (painel esquerdo nativo) — ver `bar.sample.md`
- `Bar` — papel: composição (header de cada painel) — ver `bar.sample.md`
- `IconButton` — papel: composição (toggle de painel) — ver `button.sample.md`
- `Stack` — papel: composição (conteúdo de painel de lista) — ver `bar.sample.md`

## Recursos visuais

- `flex flex-col h-full overflow-hidden` — painel com layout vertical e scroll
- `w-64 flex-shrink-0 border-l border-light-200` — inspector lateral
- `h-40 flex-shrink-0 border-t border-light-200` — console/output inferior
- `text-xs font-semibold text-dark-500 uppercase tracking-wide` — título de painel
- `bg-light-50` — header de painel e tabs inativas

## Receita

### Estrutura base

Layout IDE com três painéis (explorador + editor + inspector) e console inferior opcional.

```razor
@code {
    private bool inspectorAberto = true;
    private bool consoleAberto = false;
    private List<AbaDto> abasAbertas = [];
    private AbaDto? abaAtiva;
}

<AppLayout>
    @* Painel esquerdo: explorador — AppSideBar nativo *@
    <AppSideBar>
        <div class="flex flex-col h-full">
            <Bar AdditionalClasses="px-3 py-2 border-b border-light-200 bg-light-50">
                <StartContent>
                    <span class="text-xs font-semibold text-dark-500 uppercase tracking-wide">
                        Explorador
                    </span>
                </StartContent>
            </Bar>
            <div class="flex-1 overflow-y-auto p-2">
                @* Conteúdo do explorador — tree view ou Stack de itens *@
            </div>
        </div>
    </AppSideBar>

    @* Área principal — flex horizontal *@
    <div class="flex flex-1 overflow-hidden">

        @* Editor central *@
        <div class="flex-1 flex flex-col overflow-hidden">

            @* Barra de abas de arquivos abertos *@
            <div class="flex border-b border-light-200 bg-light-50 overflow-x-auto flex-shrink-0">
                @foreach (var aba in abasAbertas)
                {
                    <button class="flex items-center gap-2 px-4 py-2 text-xs border-r border-light-200 flex-shrink-0
                                   @(aba == abaAtiva
                                     ? "bg-white text-dark-700 font-medium"
                                     : "text-dark-400 hover:bg-light-100")"
                            @onclick="() => abaAtiva = aba">
                        @aba.Nome
                        @if (aba.Modificada)
                        {
                            <span class="w-1.5 h-1.5 rounded-full bg-primary-500"></span>
                        }
                        <span class="ml-1 text-dark-300 hover:text-dark-600"
                              @onclick:stopPropagation
                              @onclick="() => FecharAba(aba)">×</span>
                    </button>
                }
            </div>

            @* Área de edição *@
            <div class="flex-1 overflow-auto">
                @* Conteúdo do editor — MonacoEditor, textarea, etc. *@
            </div>

            @* Painel inferior: console/output *@
            @if (consoleAberto)
            {
                <div class="h-40 flex-shrink-0 border-t border-light-200 flex flex-col">
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
                    <div class="flex-1 overflow-y-auto p-2
                                font-mono text-xs bg-dark-900 text-green-300">
                        @* Linhas de output *@
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
                    @* Propriedades do elemento selecionado *@
                </div>
            </div>
        }
    </div>
</AppLayout>
```

### Cenários de composição

#### Toolbar para reabrir painéis fechados

```razor
@* Barra de status inferior ou toolbar compacta *@
<div class="flex items-center gap-1 p-1 border-b border-light-200 bg-light-50">
    <IconButton Icon="WellKnownIcons.Terminal" Style="Themes.Default" Size="Sizes.Small"
                OnClick="() => consoleAberto = !consoleAberto"
                Title="Console" />
    <IconButton Icon="WellKnownIcons.Settings" Style="Themes.Default" Size="Sizes.Small"
                OnClick="() => inspectorAberto = true"
                Title="Propriedades" />
</div>
```

#### Painel lateral com seções colapsáveis (explorador de arquivos)

```razor
<AppSideBar>
    <div class="flex flex-col h-full overflow-y-auto">
        @* Seção 1 — Arquivos abertos *@
        @{
            var sec1Aberta = true;
        }
        <div>
            <button class="flex items-center gap-1 w-full px-3 py-1.5 text-xs text-dark-400
                           hover:bg-light-50 font-semibold uppercase tracking-wide"
                    @onclick="() => sec1Aberta = !sec1Aberta">
                <span class="text-dark-300">@(sec1Aberta ? "▼" : "▶")</span>
                Abertos
            </button>
            @if (sec1Aberta)
            {
                <Stack Gap="Gaps.None">
                    @foreach (var f in arquivosAbertos)
                    {
                        <button class="flex items-center gap-2 w-full px-4 py-1 text-xs text-dark-600
                                       hover:bg-light-100 @(f.Ativo ? "bg-primary-50 text-primary-600" : "")">
                            <span>@f.Nome</span>
                        </button>
                    }
                </Stack>
            }
        </div>
    </div>
</AppSideBar>
```

### Estados de página

- **loading**: skeleton `animate-pulse` no corpo do painel que está carregando;
- **empty**: `Feedback(Light)` centralizado no painel sem conteúdo;
- **sem seleção** no inspector: `<p class="text-xs text-dark-400 text-center mt-8">Nenhum elemento selecionado</p>`.

## Limites

- `AppSideBar` tem colapso nativo apenas para o painel esquerdo; painéis direito e inferior são toggle CSS `@if`;
- Resize de painéis requer JS com `mousedown + mousemove` — sem suporte nativo na lib;
- Persistência de largura/estado dos painéis requer `localStorage` via `IJSRuntime`;
- Abas de editor têm estilo manual — a lib não tem componente de abas com fechamento;
- Para workbench real com docking e redimensionamento livre: biblioteca externa necessária (GoldenLayout, etc.);
- Scroll horizontal na barra de abas pode esconder abas ativas — considerar scroll programático para aba ativa.

### Responsividade

Mobile (< lg): esconder inspector e console; manter apenas explorer (AppSideBar com colapso nativo) + área de edição. Considerar substituição por navegação por rotas em vez de split panel para telas estreitas.
