# DropIconButton - Sample

## Contrato de uso

**Entrada pública**: `<DropIconButton>` — namespace `RoyalCode.Razor.Drops`
**Grupo**: UI-ACTION
**Propósito**: Botão de ícone que abre dropdown. Equivalente ao `DropButton` com `IconButton` como trigger — compacto para menus contextuais em listas e tabelas.
**Patterns**:
- `implementa`: UIP-ACTION-CONTEXTUAL_MENU, UIP-OVERLAY-POPOVER
- `compõe`: UIP-DATA-LIST_ITEM, UIP-DATA-DATA_TABLE
**Setup necessário**: `builder.Services.AddYasamenCommons()` + pacote de ícones + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: menus de contexto em linhas de tabela, cards e listas onde o trigger deve ser compacto (só ícone)
- **Evite quando**: o trigger precisa de label textual — use `DropButton`
- **Cuidado**: herda todos os parâmetros de drop de `DropButton`; mesmas regras de `CloseBehavior` se aplicam

## Exemplos

### `UIP-ACTION-CONTEXTUAL_MENU, UIP-DATA-LIST_ITEM` — Menu de contexto em linha de lista

Use `WellKnownIcons.MoreVertical` como ícone padrão de "mais ações" em listas.

```razor
@foreach (var usuario in usuarios)
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
        <Bar>
            <StartContent>
                <div>
                    <p class="text-sm font-semibold text-dark-700">@usuario.Nome</p>
                    <Badge Style="@(usuario.Ativo ? Themes.Success : Themes.Default)"
                           Text="@(usuario.Ativo ? "Ativo" : "Inativo")" />
                </div>
            </StartContent>
            <EndContent>
                <DropIconButton Icon="WellKnownIcons.MoreVertical"
                               Style="Themes.Default" Size="Sizes.Small"
                               ContentType="DropContentType.List"
                               Align="Positions.End">
                    <DropItem Label="Ver detalhes" OnClick="() => AbrirDetalhe(usuario.Id)" />
                    <DropItem Label="Editar" OnClick="() => Editar(usuario.Id)" />
                    <DropItem Label="Desativar" OnClick="() => Desativar(usuario.Id)" />
                    <DropItem Label="Excluir" Style="Themes.Danger"
                              OnClick="() => ConfirmarExclusao(usuario.Id)" />
                </DropIconButton>
            </EndContent>
        </Bar>
    </Box>
}
```

**API usada**: `Icon`, `Style`, `Size`, `ContentType`, `Align`, `ChildContent` (DropItems)

### `UIP-ACTION-CONTEXTUAL_MENU, UIP-DATA-DATA_TABLE` — Menu de ações em coluna de tabela

Em tabelas, posicione ao final de cada linha na coluna de ações.

```razor
<table class="w-full text-sm">
    <thead>
        <tr class="border-b border-light-200">
            <th class="text-left p-3 text-dark-500 font-medium">Produto</th>
            <th class="text-left p-3 text-dark-500 font-medium">Estoque</th>
            <th class="p-3 w-10"></th>
        </tr>
    </thead>
    <tbody>
        @foreach (var produto in produtos)
        {
            <tr class="border-b border-light-100 hover:bg-light-50">
                <td class="p-3 text-dark-700">@produto.Nome</td>
                <td class="p-3">
                    <Badge Style="@(produto.Estoque > 0 ? Themes.Success : Themes.Danger)"
                           Text="@produto.Estoque.ToString()" />
                </td>
                <td class="p-3">
                    <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                   Style="Themes.Default" Size="Sizes.Small"
                                   Align="Positions.End"
                                   ContentType="DropContentType.List">
                        <DropItem Label="Editar" OnClick="() => Editar(produto.Id)" />
                        <DropItem Label="Excluir" OnClick="() => Excluir(produto.Id)" />
                    </DropIconButton>
                </td>
            </tr>
        }
    </tbody>
</table>
```

## API relevante

- **Props/parâmetros**: herda parâmetros de `IconButton` (Style, Size, Icon, IconFragment, Outline, Active, Disabled) + parâmetros de drop: `Direction`, `Align`, `MinWidth`, `ContentType`, `CloseBehavior`, `Handler`
- **Eventos**: `OnOpened`, `OnClosed` (EventCallback<DropEventArgs>)
- **Slots**: `ChildContent` — DropItems ou conteúdo livre
