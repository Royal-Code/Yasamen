# IconButton - Sample

## Contrato de uso

**Entrada pública**: `<IconButton>` — namespace `RoyalCode.Razor.Buttons`
**Grupo**: UI-ACTION
**Propósito**: Botão HTML apenas com ícone, sem label textual visível. Sempre usa ripple dark.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-ACTION-ACTION_BAR, UIP-DATA-LIST_ITEM
**Setup necessário**: `builder.Services.AddYasamenCommons()` + pacote de ícones (ex: `AddYasamenBootstrapIcons()`) + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: ações representadas por ícone em toolbars compactas, linhas de lista, sidebars — quando label não é necessário pela convenção visual do contexto
- **Evite quando**: a ação não é óbvia sem texto — use `Button` com label; para menus de ação de item, prefira `DropIconButton`
- **Cuidado**: requer ao menos `Icon` ou `IconFragment` — sem ícone, o botão renderiza vazio

## Exemplos

### `UIP-ACTION-ACTION_BAR` — Toolbar com IconButtons de ação rápida

Use em toolbars compactas para ações cujo ícone é auto-explicativo; adicione `title` via `AdditionalAttributes` para acessibilidade.

```razor
<Bar AdditionalClasses="px-4 py-2 border-b border-light-200">
    <StartContent>
        <h2 class="text-base font-semibold text-dark-700">Editor</h2>
    </StartContent>
    <EndContent>
        @* Toggle de visualização *@
        <IconButton Icon="@(modoLista ? WellKnownIcons.Grid : WellKnownIcons.List)"
                   Style="Themes.Default" Size="Sizes.Small"
                   Active="@modoLista"
                   OnClick="() => modoLista = !modoLista"
                   title="Alternar visualização" />
        @* Atualizar *@
        <IconButton Icon="WellKnownIcons.Refresh"
                   Style="Themes.Default"
                   OnClick="Atualizar"
                   title="Atualizar" />
        @* Configurações — estado ativo quando painel aberto *@
        <IconButton Icon="WellKnownIcons.Settings"
                   Style="Themes.Default"
                   Active="@painelConfig"
                   OnClick="() => painelConfig = !painelConfig"
                   title="Configurações" />
    </EndContent>
</Bar>
```

**API usada**: `Icon`, `Style`, `Size`, `Active`, `OnClick`
**Nota**: `title` é passado via `AdditionalAttributes` (splatting) — não é um parâmetro declarado; funciona por `CaptureUnmatchedValues`.

### `UIP-DATA-LIST_ITEM` — Ação em linha de lista

Use em cada item de lista para ações inline simples (favoritar, arquivar, fechar).

```razor
@foreach (var item in itens)
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
        <Bar>
            <StartContent>
                <div>
                    <p class="text-sm font-semibold text-dark-700">@item.Nome</p>
                    <p class="text-xs text-dark-400">@item.Data.ToString("dd/MM/yyyy")</p>
                </div>
            </StartContent>
            <EndContent>
                <IconButton Icon="@(item.Favorito ? WellKnownIcons.FavoriteOn : WellKnownIcons.FavoriteOff)"
                           Style="@(item.Favorito ? Themes.Warning : Themes.Default)"
                           Size="Sizes.Small"
                           OnClick="() => ToggleFavorito(item)"
                           title="@(item.Favorito ? "Remover favorito" : "Favoritar")" />
                <IconButton Icon="WellKnownIcons.Archive"
                           Style="Themes.Default" Size="Sizes.Small"
                           OnClick="() => Arquivar(item)"
                           title="Arquivar" />
            </EndContent>
        </Bar>
    </Box>
}
```

**API usada**: `Icon` dinâmico, `Style` dinâmico, `Size`, `OnClick`

## API relevante

- **Props/parâmetros**: `Style: Themes`, `Size: Sizes`, `Icon: Enum?`, `IconFragment: Func<RenderFragment>?`, `IconAnimation: AnimationFragment?`, `Outline: bool`, `Active: bool`, `Disabled: bool`
- **Eventos/comandos**: `OnClick: EventCallback<MouseEventArgs>`
- **Slots/children**: recebe `ButtonGroupContext` via cascading quando dentro de `ButtonGroup`
- **Estados/variantes**: `Active=true` adiciona classe `active`; ripple dark é sempre ativado (não configurável)
