# UIP-DATA-CARD_GRID - Blueprint

## Identificação
- **Pattern**: UIP-DATA-CARD_GRID - Card Grid.
- **Nível final**: resumido.
- **Cobertura atual**: 4.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_data.pattern.md`, samples de `Container`, `Slot`, `Box`, `Badge`, `Button`, `DropIconButton`, `DropItem`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen fornece grid e boxes, mas não define card de coleção, ação primária, imagem/preview ou estados de grid.

## Decisão arquitetural principal
Criar `[API proposta] CardGrid` e `[API proposta] DataCard` para coleções exploratórias.

## Componentes reaproveitados
`Container`, `Slot`, `Box`, `Badge`, `Button`, `DropIconButton`, `Feedback`.

## Bloco principal de código

```razor
@* [API proposta] CardGrid *@
<Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default" AdditionalClasses="gap-6">
    @foreach (var item in Items)
    {
        <Slot Span="4" LaptopSpan="4" DesktopSpan="4">
            <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-4">
                <div class="aspect-video bg-light-200 rounded-sm">@item.Media</div>
                <div class="flex justify-between gap-3">
                    <h3 class="font-medium text-dark-900">@item.Title</h3>
                    <DropIconButton Icon="BsIconNames.ThreeDots">
                        <DropItem OnClick="@(() => Open(item))">Abrir</DropItem>
                    </DropIconButton>
                </div>
                <Badge Text="@item.Status" Style="Themes.Info" Size="Sizes.Small" />
                <Button Label="Ver detalhes" Style="Themes.Primary" Block="true" />
            </Box>
        </Slot>
    }
</Container>
```

## Exemplo principal de uso
Use em catálogo, coleção visual, cards de dashboard ou resultados exploratórios.

## Justificativa breve da cobertura proposta
O blueprint define a composição do card e comportamento de grid. A mídia real continua sendo slot externo.

## Limitações remanescentes
- Sem skeleton nativo.
- Sem lazy loading de imagem nativo.

## Pontos de adaptação
- Garantir ação primária visível.
- Reduzir para uma ou duas colunas em mobile.
