# ButtonGroup - Sample

## Contrato de uso

**Entrada pública**: `<ButtonGroup>` — namespace `RoyalCode.Razor.Buttons`
**Grupo**: UI-ACTION
**Propósito**: Agrupa botões relacionados aplicando defaults cascading de Style, Size e Disabled, com layout horizontal ou vertical.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-ACTION-ACTION_BAR
**Setup necessário**: `builder.Services.AddYasamenCommons()` + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: conjunto de ações relacionadas com estilo uniforme (Salvar/Cancelar), toolbars de botões, toggle groups com `Active` individual
- **Evite quando**: os botões não têm relação semântica — use `Button` avulsos; quando precisa de comportamento de rádio/tab com routing, prefira nav components
- **Cuidado**: Style e Size declarados no `ButtonGroup` sobrescrevem os do `Button` filho via cascading — defina-os no grupo, não nos filhos

## Exemplos

### `UIP-ACTION-ACTION_BAR` — Grupo de ações com estilo uniforme

`ButtonGroup` propaga `Style` e `Size` para todos os botões filhos; cada filho pode sobrescrever `Active` e `Outline` individualmente.

```razor
@* Ações de formulário: Cancelar (outline) + Salvar (filled) *@
<ButtonGroup Style="Themes.Primary" AriaLabel="Ações do formulário">
    <Button Outline=true Label="Cancelar" OnClick="Cancelar" />
    <Button Label="Salvar" Type="ButtonTypes.Submit" />
</ButtonGroup>

@* Toolbar compacta: ações de edição *@
<ButtonGroup Style="Themes.Default" Size="Sizes.Small" AriaLabel="Edição">
    <Button Label="Recortar" Icon="WellKnownIcons.Cut" />
    <Button Label="Copiar" Icon="WellKnownIcons.Copy" />
    <Button Label="Colar" Icon="WellKnownIcons.Paste" />
</ButtonGroup>
```

**API usada**: `Style`, `Size`, `AriaLabel`, `Outline` individual por filho

### `UIP-ACTION-ACTION_BAR` — Toggle group (período / filtro de visualização)

Use `Active` em cada `Button` para marcar a seleção corrente; troque o estado ao clicar.

```razor
@code {
    private string periodo = "30d";
}

<ButtonGroup Style="Themes.Secondary" Size="Sizes.Small" AriaLabel="Período">
    @foreach (var (id, label) in new[] { ("7d","7 dias"), ("30d","30 dias"), ("90d","90 dias") })
    {
        <Button Label="@label"
                Active="@(periodo == id)"
                Outline="@(periodo != id)"
                OnClick="() => periodo = id" />
    }
</ButtonGroup>
```

**API usada**: `Active`, `Outline` dinâmico por item
**Nota**: `Active` aplica classe visual `active` no botão; a lógica de seleção exclusiva é responsabilidade do app (C# state).

### `UIP-ACTION-ACTION_BAR` — Orientação vertical e desabilitado em lote

```razor
@code { private bool processando; }

<ButtonGroup Orientation="ButtonGroupOrientation.Vertical"
             Style="Themes.Default"
             Disabled="@processando"
             AriaLabel="Ações do item">
    <Button Label="Editar" Icon="WellKnownIcons.Edit" OnClick="Editar" />
    <Button Label="Duplicar" Icon="WellKnownIcons.Copy" OnClick="Duplicar" />
    <Button Label="Excluir" Style="Themes.Danger" Icon="WellKnownIcons.Delete" OnClick="Excluir" />
</ButtonGroup>
```

**Nota**: `Disabled=true` no grupo desabilita todos os filhos. O botão "Excluir" com `Style="Themes.Danger"` sobrescreve o `Style` do grupo — estilos declarados no filho têm precedência somente para a prop `Style`; `Size` e `Disabled` sempre vêm do grupo.

## API relevante

- **Props/parâmetros**: `Style: Themes`, `Size: Sizes`, `Disabled: bool`, `Orientation: ButtonGroupOrientation` (Horizontal|Vertical, default Horizontal), `AriaLabel: string?`
- **Eventos/comandos**: -
- **Slots/children**: `ChildContent: RenderFragment` — botões filhos (Button, IconButton)
- **Estados/variantes**: filhos recebem `ButtonGroupContext` via cascading; `Active` e `Outline` são individuais por filho

## Defaults importantes

- `Orientation` default `Horizontal`: para stack vertical de ações (ex: sidebar de ações), usar `Orientation="ButtonGroupOrientation.Vertical"`
