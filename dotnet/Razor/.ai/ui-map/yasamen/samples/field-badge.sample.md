# FieldBadge - Sample

## Visão geral
- **Propósito**: badge leve no complemento de descrição do campo.
- **Complexidade**: 3
- **Patterns cobertos**: UIP-INPUT-FORM_FIELD_GROUP
- **Variações demonstradas**: texto e tema.

## Exemplos

### UIP-INPUT-FORM_FIELD_GROUP

**Objetivo**: indicar metadado de campo.

```razor
<TextField Label="E-mail" @bind-Value="email" Information="Usado para notificações.">
    <DescriptionComplement>
        <FieldBadge Text="Obrigatório" Style="Themes.Warning" />
    </DescriptionComplement>
</TextField>

@code {
    private string email = string.Empty;
}
```

**Props usadas**: `Text`, `Style`.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: adiciona indicação visual vinculada ao campo.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Text` | `string?` | badge simples | conteúdo |
| `ChildContent` | `RenderFragment?` | conteúdo custom | substitui texto |
| `Style` | `Themes` | semântica | cor |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | conteúdo passivo |

## Limitações
- Não é badge genérico preferencial fora de fields; use `Badge`.

## Combinações frágeis
- Usar muitos badges no mesmo label gera ruído.
