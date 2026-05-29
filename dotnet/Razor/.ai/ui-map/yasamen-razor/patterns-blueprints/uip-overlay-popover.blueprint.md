# UIP-OVERLAY-POPOVER - Blueprint resumido

## Pattern

UIP-OVERLAY-POPOVER — Popover — ver `uip-overlay-popover.ui-map.md`

## Gap coberto

A lib não tem componente de popover de conteúdo arbitrário. `DropButton`/`DropIconButton` cobrem popover de menu de ações (80% dos casos). O gap é orientar o caso restante: popover com controles, preview ou informação rica.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: para menu de ações usar `DropButton` diretamente; para conteúdo livre usar `div.relative + bool + Box(absolute)` + backdrop transparente para fechar por clique fora.

## Componentes usados

- `DropButton / DropIconButton` — papel: principal (caso de menu) — ver `button.sample.md`
- `Box` — papel: composição (container de conteúdo arbitrário) — ver `box.sample.md`
- `IconButton / Button` — papel: composição (trigger) — ver `button.sample.md`

## Recursos visuais

- `relative inline-block` — âncora de posicionamento do pai
- `absolute top-full left-0 mt-1 z-30` — popover abaixo do trigger
- `absolute bottom-full left-0 mb-1 z-30` — popover acima do trigger
- `fixed inset-0 z-20` — backdrop transparente para fechar por clique fora
- `shadow-lg bg-white` — elevação do popover sobre o conteúdo

## Receita

Para menu de ações: `DropButton` direto. Para conteúdo livre: `div.relative` + `bool` + `Box` absoluto + backdrop.

```razor
@* Caso coberto nativamente: popover de menu de ações *@
<DropButton Label="Opções" Style="Themes.Default">
    <DropItem Label="Ver detalhes" OnClick="VerDetalhes" />
    <DropItem Label="Editar" OnClick="Editar" />
    <hr class="my-1 border-light-200" />
    <DropItem Label="Excluir" Style="Themes.Danger" OnClick="Excluir" />
</DropButton>

@* Popover de conteúdo arbitrário (composição manual) *@
@code {
    private bool popoverAberto;
    private void TogglePopover() => popoverAberto = !popoverAberto;
    private void FecharPopover() => popoverAberto = false;
}

@if (popoverAberto)
{
    <div class="fixed inset-0 z-20" @onclick="FecharPopover"></div>
}

<div class="relative inline-block">
    <IconButton Icon="WellKnownIcons.Info" Style="Themes.Default"
                OnClick="TogglePopover" />

    @if (popoverAberto)
    {
        <div class="absolute top-full left-0 mt-1 z-30 w-64" @onclick:stopPropagation>
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-3 shadow-lg bg-white">
                <p class="text-sm font-medium text-dark-600 mb-1">Informação</p>
                <p class="text-xs text-dark-400">
                    Texto de ajuda com mais detalhes sobre o campo ou ação.
                </p>
                <Button Style="Themes.Default" Size="Sizes.Small"
                        Label="Entendi" AdditionalClasses="mt-2"
                        OnClick="FecharPopover" />
            </Box>
        </div>
    }
</div>

@* Quick preview de item em lista *@
@foreach (var item in itens)
{
    @code { private bool previewAberto; private int? idHover; }
    <div class="relative inline-block">
        <span class="text-sm text-primary-600 cursor-pointer underline"
              @onclick="() => { idHover = item.Id; previewAberto = true; }">
            @item.Nome
        </span>

        @if (previewAberto && idHover == item.Id)
        {
            <div class="fixed inset-0 z-20"
                 @onclick="() => previewAberto = false"></div>
            <div class="absolute bottom-full left-0 mb-1 z-30 w-72"
                 @onclick:stopPropagation>
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
                </Box>
            </div>
        }
    </div>
}
```

## Limites

- Sem collision detection — posicionamento é CSS estático; popover pode sair da viewport em bordas;
- Para fechar por `Esc` requer `@onkeydown` manual no componente pai;
- Acessibilidade (`aria-expanded`, `role="dialog"`) deve ser adicionada manualmente;
- Em listas longas com um popover por item, preferir um único popover com dados do item `idHover` a um por item para evitar excesso de DOM.
