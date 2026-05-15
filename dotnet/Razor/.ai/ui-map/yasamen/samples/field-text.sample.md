# FieldText - Sample

## Visão geral
- **Propósito**: texto complementar para prepend/append de campos.
- **Complexidade**: 2
- **Patterns cobertos**: UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-SEARCH_BAR
- **Variações demonstradas**: prefixo e sufixo.

## Exemplos

### UIP-INPUT-FORM_FIELD_GROUP

**Objetivo**: adicionar prefixo e sufixo ao `TextField`.

```razor
<TextField Label="Site" @bind-Value="site" Placeholder="exemplo">
    <Prepend><FieldText>https://</FieldText></Prepend>
    <Append><FieldText>.com</FieldText></Append>
</TextField>

@code {
    private string site = string.Empty;
}
```

**Props usadas**: `ChildContent`.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: contextualiza o valor sem criar campo custom.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `ChildContent` | `RenderFragment` | sempre | texto exibido |
| `AdditionalClasses` | `string?` | ajuste visual | classes extras |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | conteúdo passivo |

## Limitações
- Deve ser usado como complemento de campo, não como texto genérico.

## Combinações frágeis
- Texto longo no prepend/append pode comprimir o input.
