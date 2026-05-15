# ControlGroup - Sample

## Visão geral
- **Propósito**: agrupar prepend, controle e append em uma linha dentro de field.
- **Complexidade**: 2
- **Patterns cobertos**: UIP-INPUT-FORM_FIELD_GROUP
- **Variações demonstradas**: uso indireto.

## Exemplos

### Uso indireto via TextField

**Objetivo**: compor prefixo e sufixo sem consumir `ControlGroup` diretamente.

```razor
<TextField Label="Site" @bind-Value="site">
    <Prepend><FieldText>https://</FieldText></Prepend>
    <Append><FieldText>.com</FieldText></Append>
</TextField>

@code {
    private string site = string.Empty;
}
```

**Props usadas**: `ChildContent` é usado internamente pelo grupo.  
**Eventos relevantes**: nenhum direto.  
**Por que atende o pattern**: preserva a linha de controle com complementos.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `ChildContent` | `RenderFragment` | composição interna | conteúdo em linha |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | suporte visual |

## Limitações
- Componente interno; normalmente acessado por `TextField`.

## Combinações frágeis
- Muitos elementos inline podem estreitar demais o input.
