# FieldBadge - Sample

## Contrato de uso

**Entrada pública**: `<FieldBadge>` — namespace `RoyalCode.Razor.Forms`
**Grupo**: UI-INPUT
**Propósito**: Badge estilizado para uso dentro de campos de formulário (Prepend/Append/DescriptionComplement). Aplica `ya-field-badge` com variante de tema.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-INPUT-INPUT_FIELD
**Setup necessário**: `<YasamenStyles />` no `<head>`; usado exclusivamente dentro de `TextField`

## Regras rápidas

- **Use para**: prefixo/sufixo visual com cor semântica em campos (ex: "R$", "kg", "USD", badge de obrigatoriedade)
- **Evite quando**: o adorno é texto neutro sem cor — use `FieldText`; para badges de status fora de formulários — use `Badge`

## Exemplos

### `UIP-INPUT-INPUT_FIELD` — Adorno badge em TextField

Use no slot `Prepend` ou `Append` para indicadores visuais com cor temática, e no `DescriptionComplement` para badges inline junto ao label.

```razor
@* Prefixo de moeda com badge colorido *@
<TextField @bind-Value="model.Preco" Label="Preço">
    <Prepend>
        <FieldBadge Style="Themes.Secondary" Text="R$" />
    </Prepend>
</TextField>

@* Sufixo de unidade *@
<TextField @bind-Value="model.Peso" Label="Peso">
    <Append>
        <FieldBadge Style="Themes.Secondary" Text="kg" />
    </Append>
</TextField>

@* Badge "Obrigatório" complementando o label — via DescriptionComplement *@
<TextField @bind-Value="model.Codigo" Label="Código SKU">
    <DescriptionComplement>
        <FieldBadge Style="Themes.Danger" Text="Obrigatório" />
    </DescriptionComplement>
</TextField>
```

**API usada**: `Style`, `Text` — slots `Prepend`/`Append`/`DescriptionComplement` são do `TextField`
**Nota**: `DescriptionComplement` exibe o conteúdo na mesma linha do label, à direita.

## API relevante

- **Props/parâmetros**: `Text: string?`, `Style: Themes`, `ChildContent: RenderFragment?`
- **Defaults**: fallback automático para `ya-badge-highlight` quando `Style` não definido
