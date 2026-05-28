# UIP-OVERLAY-POPOVER - Popover

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de popover. O `DropButton`/`DropIconButton` cobre o caso de menu dropdown contextual, mas popover com conteúdo arbitrário requer composição com estado local + posicionamento CSS absoluto/relativo + `@onclick:stopPropagation` para fechar.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. DropButton / DropIconButton
- `cobertura`: popover de menu de ações ancorado a botão; `DropItem` por ação; fechar por seleção, clique fora ou escape; posicionamento automático;
- `nota`: 8;
- `justificativa`: cobre o subconjunto de "popover de comandos/opções" com alta qualidade — é o caso mais frequente.

2. Box (wrapper do popover manual)
- `cobertura`: container de popover com borda, sombra e padding; posicionamento `absolute` relativo a `relative` no pai;
- `nota`: 5;
- `justificativa`: container visual do popover de conteúdo arbitrário.

3. Button / IconButton (trigger)
- `cobertura`: trigger do popover; toggle `bool aberto` on click; `@onclick:stopPropagation`;
- `nota`: 7;
- `justificativa`: elemento de origem do popover.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `posicionamento automático (collision detection)`: sem biblioteca de posicionamento — posição é CSS estático (`top-full left-0` ou similar);
  - `popover com conteúdo arbitrário (controles, pickers, quick preview)`: composição manual com `absolute` + estado `bool`;
  - `fechamento por click fora`: `@onclick` no `<body>` via `@onclick` no backdrop transparente ou `IJSRuntime` para click-outside listener;
  - `acessibilidade (aria-expanded, role=dialog)`: manual.

- `tipo de adaptação`: composição manual para casos além de dropdown de ações
- `o que precisa ser feito`:
  - Para menu de ações: usar `DropButton`/`DropIconButton` diretamente;
  - Para conteúdo arbitrário: `<div class="relative">` + toggle `bool` + `Box` com `absolute top-full`;
  - Backdrop transparente para fechar por click fora.

## Como usar

### Caso coberto: popover de ações via DropButton

```razor
<DropButton Label="Opções" Style="Themes.Default">
    <DropItem Label="Ver detalhes" OnClick="VerDetalhes" />
    <DropItem Label="Editar" OnClick="Editar" />
    <hr class="my-1 border-light-200" />
    <DropItem Label="Excluir" Style="Themes.Danger" OnClick="Excluir" />
</DropButton>
```

### Popover de conteúdo arbitrário (composição manual)

```razor
@code {
    private bool popoverAberto;

    private void TogglePopover() => popoverAberto = !popoverAberto;
    private void FecharPopover() => popoverAberto = false;
}

@if (popoverAberto)
{
    @* Backdrop transparente para fechar por click fora *@
    <div class="fixed inset-0 z-20" @onclick="FecharPopover"></div>
}

<div class="relative inline-block">
    <IconButton Icon="WellKnownIcons.Info" Style="Themes.Default"
                OnClick="TogglePopover" />

    @if (popoverAberto)
    {
        <div class="absolute top-full left-0 mt-1 z-30 w-64" @onclick:stopPropagation>
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-3 shadow-lg bg-white">
                <p class="text-sm font-medium text-dark-600 mb-1">Informação extra</p>
                <p class="text-xs text-dark-400">
                    Este campo aceita valores entre 1 e 999.
                    Utilize vírgula como separador decimal.
                </p>
                <div class="mt-2 pt-2 border-t border-light-100">
                    <Button Style="Themes.Default" Size="Sizes.Small"
                            Label="Entendi" OnClick="FecharPopover" />
                </div>
            </Box>
        </div>
    }
</div>
```

### Quick preview de item (popover de detalhe)

```razor
@code {
    private bool previewAberto;
    private int? itemHover;

    private void AbrirPreview(int id) { itemHover = id; previewAberto = true; }
    private void FecharPreview() { previewAberto = false; itemHover = null; }
}

@foreach (var item in itens)
{
    <div class="relative inline-block">
        <span class="text-sm text-primary-600 cursor-pointer underline"
              @onclick="() => AbrirPreview(item.Id)">
            @item.Nome
        </span>

        @if (previewAberto && itemHover == item.Id)
        {
            <div class="absolute bottom-full left-0 mb-1 z-30 w-72" @onclick:stopPropagation>
                <Box Border="BorderBuilder.Box" AdditionalClasses="p-3 shadow-xl bg-white">
                    <Bar AdditionalClasses="mb-2">
                        <StartContent>
                            <p class="text-sm font-semibold text-dark-600">@item.Nome</p>
                        </StartContent>
                        <EndContent>
                            <Badge Style="@item.StatusTema" Text="@item.Status" />
                        </EndContent>
                    </Bar>
                    <p class="text-xs text-dark-400">@item.Descricao</p>
                    <Button Style="Themes.Primary" Size="Sizes.Small"
                            Label="Abrir" AdditionalClasses="mt-2"
                            OnClick="() => Nav.NavigateTo($\"/itens/{item.Id}\")" />
                </Box>
            </div>
            <div class="fixed inset-0 z-20" @onclick="FecharPreview"></div>
        }
    </div>
}
```

## Decisão de uso

- `nota geral`: 5;
- `limitações`: sem componente de popover nativo; `DropButton`/`DropIconButton` cobrem apenas menu de ações; conteúdo arbitrário requer composição manual com posicionamento CSS estático; sem collision detection automático; sem gerenciamento de foco nativo para popovers interativos;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `DropButton`/`DropIconButton` cobrem 80% dos casos reais de popover (menu de ações) com alta qualidade;
  - Para popover de conteúdo arbitrário: composição manual funcional mas sem abstração de posicionamento;
  - Nota 5 reflete cobertura parcial — excelente para menus, manual para conteúdo livre.
