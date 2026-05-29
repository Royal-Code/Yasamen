# Container - Sample

## Contrato de uso

**Entrada pública**: `<Container>` — namespace `RoyalCode.Razor.Layouts`
**Grupo**: UI-STRUCT
**Propósito**: Container de layout responsivo que suporta Grid ou Flex, com configuração de tamanho e altura para os filhos `Slot`.
**Patterns**:
- `implementa`: UIP-STRUCT-LAYOUT_ZONE, UIP-STRUCT-GRID_CONTAINER, UIP-DATA-CARD_GRID
- `compõe`: UIP-INPUT-REPEATING_GROUP, UIP-INPUT-FILTER_PANEL, UIP-CONTENT-COMPARISON_BLOCK, UIP-CONTENT-MEDIA_COLLECTION
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: grades responsivas de cards/métricas, layouts de múltiplas colunas, distribuição flex com slots de largura variável
- **Evite quando**: o layout é simplesmente vertical — use `Stack`; quando precisa de toolbar horizontal — use `Bar`
- **Cuidado**: deve conter `Slot` como filhos diretos; sem `Slot`, o layout responsivo não funciona

## Exemplos

### `UIP-STRUCT-GRID_CONTAINER, UIP-DATA-CARD_GRID` — Grade de cards com Slot responsivo

`Slot.Span` controla colunas no breakpoint default; `TabletSpan`, `LaptopSpan`, `DesktopSpan` permitem adaptação responsiva.

```razor
@* Grade 3 colunas: cada Slot ocupa 4 de 12 (3 colunas × 4 = 12) *@
<Container>
    @foreach (var produto in produtos)
    {
        <Slot Span="4">
            <Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
                @if (produto.ImagemUrl is not null)
                {
                    <img src="@produto.ImagemUrl" alt="@produto.Nome"
                         class="w-full h-36 object-cover" />
                }
                <div class="p-3">
                    <Bar AdditionalClasses="mb-1">
                        <StartContent>
                            <p class="text-sm font-semibold text-dark-700">@produto.Nome</p>
                        </StartContent>
                        <EndContent>
                            <Badge Style="Themes.Success" Text="@produto.Categoria" />
                        </EndContent>
                    </Bar>
                    <p class="text-xs text-dark-400">R$ @produto.Preco.ToString("N2")</p>
                </div>
            </Box>
        </Slot>
    }
</Container>
```

**API usada**: `Container` default (Type=Grid, Size=Default), `Slot.Span`
**Nota**: `Span=4` ocupa 4 de 12 colunas = largura de 1/3 da grade. `[inferido]` — confirmar total de colunas default do grid.

### `UIP-STRUCT-LAYOUT_ZONE` — Layout de página com formulário em colunas

Use `Container` para formulários com campos em múltiplas colunas; `Slot` com span diferente para label+input.

```razor
@* Formulário 2 colunas com campos distribuídos *@
<Container>
    <Slot Span="6">
        <TextField @bind-Value="model.Nome" Label="Nome" required />
    </Slot>
    <Slot Span="6">
        <TextField @bind-Value="model.Sobrenome" Label="Sobrenome" required />
    </Slot>
    <Slot Span="8">
        <TextField @bind-Value="model.Endereco" Label="Endereço" />
    </Slot>
    <Slot Span="4">
        <TextField @bind-Value="model.Cep" Label="CEP" />
    </Slot>
    @* Linha de ações — ocupa toda a largura *@
    <Slot Span="12">
        <Bar>
            <EndContent>
                <Button Style="Themes.Default" Label="Cancelar" OnClick="Cancelar" />
                <Button Style="Themes.Primary" Label="Salvar" Type="ButtonTypes.Submit" />
            </EndContent>
        </Bar>
    </Slot>
</Container>
```

**API usada**: `Slot.Span` variável para distribuição de colunas

### `UIP-INPUT-REPEATING_GROUP, UIP-CONTENT-COMPARISON_BLOCK, UIP-INPUT-FILTER_PANEL` — Grupo repetitivo, comparação e painel de filtros

```razor
@* Repeating group: linha de campos replicável *@
<Stack AdditionalClasses="gap-2">
    @foreach (var (contato, idx) in contatos.Select((c, i) => (c, i)))
    {
        <Container>
            <Slot Span="5">
                <TextField @bind-Value="contato.Nome" Label="@(idx == 0 ? "Nome" : null)" />
            </Slot>
            <Slot Span="5">
                <TextField @bind-Value="contato.Email" Label="@(idx == 0 ? "E-mail" : null)" />
            </Slot>
            <Slot Span="2">
                <IconButton Icon="WellKnownIcons.Delete"
                           Style="Themes.Danger"
                           AdditionalClasses="@(idx == 0 ? "mt-5" : "")"
                           OnClick="() => contatos.RemoveAt(idx)" />
            </Slot>
        </Container>
    }
    <Button Style="Themes.Default" Size="Sizes.Small"
            Icon="WellKnownIcons.Add" Label="Adicionar contato"
            OnClick="() => contatos.Add(new())" />
</Stack>
```

### `UIP-DATA-CARD_GRID, UIP-CONTENT-MEDIA_COLLECTION` — Grade responsiva com breakpoints

```razor
@* Grade adaptável: 1 col mobile → 2 tablet → 3 laptop → 4 desktop *@
<Container>
    @foreach (var item in midias)
    {
        <Slot Span="12" TabletSpan="6" LaptopSpan="4" DesktopSpan="3">
            <Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
                <img src="@item.Thumbnail" alt="@item.Titulo"
                     class="w-full h-40 object-cover" />
                <div class="p-2">
                    <p class="text-sm font-semibold text-dark-700 truncate">@item.Titulo</p>
                </div>
            </Box>
        </Slot>
    }
</Container>
```

**API usada**: `Slot.TabletSpan`, `Slot.LaptopSpan`, `Slot.DesktopSpan`

## API relevante

- **Props/parâmetros**: `Type: LayoutTypes` (Grid|Flex, default Grid), `Size: LayoutSizes` (Default|Tablet|Laptop|Desktop, default Default), `Height: SpacingSize?` (altura default dos Slots)
- **Slots**: `ChildContent: RenderFragment` — deve conter `Slot` filhos
- **Cascading**: propaga `ContainerContext` (Type, Size, Height) para os `Slot` filhos

## Defaults importantes

- `Type` default `Grid`: para Flex (slots de largura variável), usar `Type="LayoutTypes.Flex"`
- `Slot.Span` default `4`: cada Slot ocupa 4 de 12 colunas por default — declare spans explicitamente para controlar a grade
- `Slot.TabletSpan` / `LaptopSpan` / `DesktopSpan` default `0`: valor 0 herda o span do breakpoint anterior
