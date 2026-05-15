# Stack - Sample

## Visão geral
- **Propósito**: pilha vertical simples.
- **Complexidade**: 2
- **Patterns cobertos**: UIP-STRUCT-STACK_CONTAINER, PP-SETTINGS
- **Variações demonstradas**: gap via classes.

## Exemplos

### UIP-STRUCT-STACK_CONTAINER

**Objetivo**: sequência vertical de blocos.

```razor
<Stack AdditionalClasses="gap-4">
    <Feedback Style="Themes.Info" Text="Revise os dados." />
    <TextField Label="Nome" @bind-Value="name" />
    <Button Label="Salvar" Style="Themes.Primary" />
</Stack>

@code {
    private string name = string.Empty;
}
```

**Props usadas**: `ChildContent`, `AdditionalClasses`.  
**Eventos relevantes**: eventos ficam nos filhos.  
**Por que atende o pattern**: organiza fluxo vertical simples.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `ChildContent` | `RenderFragment` | sempre | conteúdo empilhado |
| `AdditionalClasses` | `string?` | espaçamento | gap/space-y |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum direto | não aplicável | eventos nos filhos |

## Limitações
- Não tem prop própria de spacing.

## Combinações frágeis
- Evitar empilhar zonas que deveriam ser grid.
