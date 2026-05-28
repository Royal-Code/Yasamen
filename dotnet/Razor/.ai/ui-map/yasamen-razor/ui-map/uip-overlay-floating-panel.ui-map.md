# UIP-OVERLAY-FLOATING_PANEL - Floating Panel

**GAP — sem cobertura viável**

A biblioteca não tem componente de painel flutuante. Painel reposicionável com drag, dock/undock e persistência de posição requer implementação customizada com CSS `position:fixed` + `pointer-events` + `IJSRuntime` para drag. A única aproximação parcial é `OffCanvas` ancorado, mas sem flutuação nem reposicionamento.

## Componentes

**Principais**: nenhum dedicado.

**Composição aproximada**:

1. Box (estrutura do painel)
- `cobertura`: container visual com borda e sombra; `position:fixed` via CSS; header com título e controles;
- `nota`: 2;
- `justificativa`: container visual apenas — drag, resize e dock são totalmente manuais.

2. Bar (header do painel)
- `cobertura`: linha de cabeçalho com título, botão de fechar e botão de pin;
- `nota`: 3;
- `justificativa`: header compacto do painel flutuante.

3. IconButton
- `cobertura`: controles de fechar, minimizar, dock/undock;
- `nota`: 4;
- `justificativa`: ações de controle do painel.

**Descartados**: OffCanvas (sem suporte a flutuação e reposicionamento livre).

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `drag para reposicionar`: JavaScript via `IJSRuntime` para `mousedown/mousemove/mouseup`;
  - `resize de borda`: CSS `resize:both` + JS para capturar dimensões;
  - `dock/undock`: lógica C# de estado `bool isDocked` + CSS dinâmico;
  - `persistência de posição`: `localStorage` via JS interop;
  - `colisão com viewport`: cálculo JS de bounds.

- `tipo de adaptação`: implementação customizada substancial
- `o que precisa ser feito`:
  - Componente Razor `FloatingPanel.razor` com `position:fixed` e `top`/`left` via style;
  - `IJSRuntime` para eventos de drag no header;
  - Estado `bool isDocked` para alternar entre docked (sidebar) e floating;
  - `Box` + `Bar` como estrutura visual.

## Como usar

### Painel flutuante simples (proof-of-concept)

```razor
@* FloatingPanel.razor — implementação básica sem drag *@
@code {
    [Parameter] public string Title { get; set; } = "Painel";
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public EventCallback OnFechar { get; set; }

    private bool minimizado;
    private int posTop = 100;
    private int posLeft = 100;
    private string PosStyle => $"top:{posTop}px; left:{posLeft}px;";
}

<div class="fixed z-50" style="@PosStyle; width:320px;">
    <Box Border="BorderBuilder.Box" AdditionalClasses="shadow-xl bg-white">
        @* Header arrastável *@
        <Bar AdditionalClasses="px-3 py-2 bg-light-50 border-b border-light-200 cursor-grab">
            <StartContent>
                <span class="text-sm font-semibold text-dark-600">@Title</span>
            </StartContent>
            <EndContent>
                <IconButton Icon="@(minimizado ? WellKnownIcons.ChevronDown : WellKnownIcons.ChevronUp)"
                           Style="Themes.Default" Size="Sizes.Small"
                           OnClick="() => minimizado = !minimizado" />
                <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                           Size="Sizes.Small" OnClick="OnFechar" />
            </EndContent>
        </Bar>

        @* Conteúdo *@
        @if (!minimizado)
        {
            <div class="p-3 max-h-64 overflow-y-auto">
                @ChildContent
            </div>
        }
    </Box>
</div>
```

### Painel dockável (sem flutuação — alternativa simplificada)

```razor
@* Para a maioria dos casos em Web, um drawer lateral é mais adequado *@
@code {
    private bool painelAberto = true;
}

<div class="flex h-full">
    @* Conteúdo principal *@
    <div class="flex-1 overflow-auto">
        @* conteúdo *@
    </div>

    @* Painel de propriedades fixo à direita *@
    @if (painelAberto)
    {
        <div class="w-72 border-l border-light-200 flex flex-col flex-shrink-0">
            <Bar AdditionalClasses="px-3 py-2 border-b border-light-200 bg-light-50">
                <StartContent>
                    <span class="text-sm font-semibold text-dark-600">Propriedades</span>
                </StartContent>
                <EndContent>
                    <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                               Size="Sizes.Small"
                               OnClick="() => painelAberto = false" />
                </EndContent>
            </Bar>
            <div class="p-3 overflow-y-auto flex-1">
                @* conteúdo do painel *@
            </div>
        </div>
    }
</div>
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: sem componente de painel flutuante nativo; drag e reposicionamento requerem JS customizado; resize requer JS; persistência de posição requer localStorage via interop; sem docking automático; toda a implementação é responsabilidade do app;
- `recomendação`: `evitar`
- `justificativa geral`:
  - Para casos simples onde o "painel flutuante" é na verdade um painel lateral fixo, usar `UIP-STRUCT-SPLIT_PANEL` (split manual) ou `UIP-OVERLAY-DRAWER` (OffCanvas);
  - Para floating panel com drag real em SHP-STUDIO_WORKBENCH: requer implementação Razor customizada ou biblioteca externa;
  - Nota 0 reflete ausência total de abstração — todo o comportamento de painel flutuante é responsabilidade do app.
