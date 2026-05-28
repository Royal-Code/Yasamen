# Slot - Sample

## Contrato de uso

**Entrada pública**: `<Slot>` — namespace `RoyalCode.Razor.Layouts`
**Grupo**: UI-STRUCT
**Propósito**: Coluna responsiva dentro de `Container`. Define span em colunas para diferentes breakpoints e herda tipo de layout do `ContainerContext` cascading.
**Patterns**:
- `implementa`: UIP-STRUCT-GRID_CONTAINER, UIP-DATA-CARD_GRID
- `compõe`: UIP-INPUT-REPEATING_GROUP, UIP-CONTENT-COMPARISON_BLOCK, UIP-CONTENT-MEDIA_COLLECTION
**Setup necessário**: `<YasamenStyles />` no `<head>`; deve estar dentro de `Container`

## Regras rápidas

- **Use para**: definir o espaço de coluna de um elemento dentro de uma grade `Container`
- **Evite quando**: fora de `Container` — o layout depende do `ContainerContext` cascading e não funciona sozinho
- **Cuidado**: `Span=0` nos breakpoints opcionais significa "herdar o span do breakpoint anterior"; declare `Span` explicitamente para cada contexto responsivo desejado

## Exemplos

### `UIP-STRUCT-GRID_CONTAINER, UIP-DATA-CARD_GRID` — Span básico em grade de 12 colunas

Cada unidade de `Span` ocupa uma fração da grade; spans somados na mesma linha devem resultar em 12.

```razor
@* Layout 2/3 + 1/3 *@
<Container>
    <Slot Span="8">
        @* conteúdo principal 2/3 *@
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <p class="text-sm text-dark-600">Conteúdo principal</p>
        </Box>
    </Slot>
    <Slot Span="4">
        @* sidebar 1/3 *@
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <p class="text-sm text-dark-600">Painel lateral</p>
        </Box>
    </Slot>
</Container>

@* Grade uniforme 1/4 *@
<Container>
    @foreach (var metrica in metricas)
    {
        <Slot Span="3">
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <p class="text-xs text-dark-400">@metrica.Label</p>
                <p class="text-xl font-semibold text-dark-700">@metrica.Valor</p>
            </Box>
        </Slot>
    }
</Container>
```

**API usada**: `Span` — número de colunas (de 12)

### `UIP-CONTENT-COMPARISON_BLOCK, UIP-CONTENT-MEDIA_COLLECTION` — Breakpoints responsivos

Use spans por breakpoint para adaptar a grade ao tamanho de tela.

```razor
@* 1 col mobile → 2 cols tablet → 3 cols laptop → 4 cols desktop *@
<Container>
    @foreach (var plano in planos)
    {
        <Slot Span="12" TabletSpan="6" LaptopSpan="4" DesktopSpan="3">
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <h3 class="text-base font-semibold text-dark-700">@plano.Nome</h3>
                <p class="text-2xl font-bold text-primary-500 my-2">R$ @plano.Preco</p>
                <ul class="text-sm text-dark-500 space-y-1">
                    @foreach (var feature in plano.Features)
                    {
                        <li>✓ @feature</li>
                    }
                </ul>
                <Button Style="Themes.Primary" Label="Assinar" Block=true
                        AdditionalClasses="mt-4" OnClick="() => Assinar(plano.Id)" />
            </Box>
        </Slot>
    }
</Container>
```

**API usada**: `Span`, `TabletSpan`, `LaptopSpan`, `DesktopSpan`

## API relevante

- **Props/parâmetros**: `Span: int` (default 4), `TabletSpan: int` (default 0), `LaptopSpan: int` (default 0), `DesktopSpan: int` (default 0), `Height: SpacingSize?` (override de altura)
- **Cascading**: `Context: ContainerContext` (recebe Type, Size, Height do Container pai)
- **Slots**: `ChildContent: RenderFragment`

## Defaults importantes

- `Span` default `4`: equivale a 1/3 de uma grade de 12 colunas — declare explicitamente quando quiser spans diferentes
- `TabletSpan/LaptopSpan/DesktopSpan` default `0`: herda o span do breakpoint anterior quando é 0
