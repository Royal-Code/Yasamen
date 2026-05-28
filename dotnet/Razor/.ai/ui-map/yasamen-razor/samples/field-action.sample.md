# FieldAction - Sample

## Contrato de uso

**Entrada pública**: `<FieldAction>` — namespace `RoyalCode.Razor.Forms`
**Grupo**: UI-INPUT
**Propósito**: Botão estilizado para uso dentro de grupos de campos de formulário (Prepend/Append/FooterAction). Aplica classe `ya-field-action` ao `Button` interno.
**Patterns**:
- `implementa`: UIP-INPUT-SEARCH_BAR, UIP-INPUT-LOOKUP_FIELD
- `compõe`: UIP-INPUT-INPUT_FIELD
**Setup necessário**: `builder.Services.AddYasamenCommons()` + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: botão de ação integrado a um campo de formulário (buscar, limpar, toggle de senha, abrir lookup)
- **Evite quando**: a ação é independente do campo e não está visualmente acoplada — use `Button` avulso
- **Cuidado**: herda todos os parâmetros de `Button`; declarar `Label` ou `Icon`, nunca ambos como parâmetro — use o `Button` normal para botões com label longo

## Exemplos

### `UIP-INPUT-SEARCH_BAR, UIP-INPUT-INPUT_FIELD` — Ação de busca integrada ao campo

Use no slot `Prepend` ou `Append` de `TextField` para criar uma barra de busca com botão.

```razor
@* Search bar: ícone de busca antes do input *@
<TextField @bind-Value="busca"
           Placeholder="Buscar produtos..."
           AdditionalClasses="w-72">
    <Prepend>
        <FieldAction Icon="WellKnownIcons.Search"
                     Style="Themes.Default"
                     OnClick="Buscar" />
    </Prepend>
    @if (!string.IsNullOrEmpty(busca))
    {
        <Append>
            <FieldAction Icon="WellKnownIcons.Close"
                         Style="Themes.Default"
                         OnClick="() => { busca = string.Empty; Buscar(); }" />
        </Append>
    }
</TextField>

@* Toggle de visibilidade de senha *@
<TextField @bind-Value="senha"
           Label="Senha"
           Type="@(mostrarSenha ? InputType.Text : InputType.Password)">
    <Append>
        <FieldAction Icon="@(mostrarSenha ? WellKnownIcons.EyeOff : WellKnownIcons.Eye)"
                     Style="Themes.Default"
                     OnClick="() => mostrarSenha = !mostrarSenha" />
    </Append>
</TextField>
```

**API usada**: `Icon`, `Style`, `OnClick` — slots `Prepend`/`Append` são do `TextField`

### `UIP-INPUT-LOOKUP_FIELD` — Lookup com botão de abertura de seletor

Use no `Append` para abrir um modal ou OffCanvas de seleção.

```razor
@code {
    private string? clienteSelecionadoNome;
    private int? clienteSelecionadoId;
}

<TextField @bind-Value="clienteSelecionadoNome"
           Label="Cliente"
           ReadOnly=true
           Placeholder="Selecione um cliente...">
    <Append>
        <FieldAction Icon="WellKnownIcons.Search"
                     Label="Buscar"
                     Style="Themes.Secondary"
                     OnClick="AbrirSeletorCliente" />
    </Append>
    @if (clienteSelecionadoId.HasValue)
    {
        <FooterAction>
            <FieldAction Icon="WellKnownIcons.Close"
                         Style="Themes.Default"
                         Size="Sizes.Small"
                         OnClick="LimparCliente" />
        </FooterAction>
    }
</TextField>
```

**API usada**: `Icon`, `Label`, `Style`, `Size`, `OnClick` — slots `Append`/`FooterAction` do `TextField`

## API relevante

- **Props/parâmetros**: herda parâmetros de `Button` — `Label: string?`, `Style: Themes`, `Icon: Enum?`, `IconPosition`, `Size`, `Outline`, `Active`, `Disabled`, `OnClick: EventCallback<MouseEventArgs>`
- **Slots**: `ChildContent: RenderFragment?`
