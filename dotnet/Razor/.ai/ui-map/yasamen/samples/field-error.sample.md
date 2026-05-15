# FieldError - Sample

## Visão geral
- **Propósito**: mensagem visual de erro dentro de campo.
- **Complexidade**: 2
- **Patterns cobertos**: UIP-INPUT-FORM_FIELD_GROUP, UIP-FEEDBACK-ERROR_STATE
- **Variações demonstradas**: uso indireto via `TextField`.

## Exemplos

### UIP-INPUT-FORM_FIELD_GROUP

**Objetivo**: exibir erro contextual de campo.

```razor
<TextField Label="E-mail"
           @bind-Value="email"
           Error="Informe um e-mail válido." />

@code {
    private string email = string.Empty;
}
```

**Props usadas**: `Error` no `TextField`, renderizado por suporte interno.  
**Eventos relevantes**: nenhum direto.  
**Por que atende o pattern**: mantém erro próximo ao campo afetado.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `ErrorMessage` | `string` | erro direto | texto de erro |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | conteúdo passivo |

## Limitações
- Preferir `TextField Error` em vez de instanciar diretamente.

## Combinações frágeis
- Mensagens longas podem quebrar ritmo do formulário.
