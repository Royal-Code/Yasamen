# Bar - Sample

## Visão geral
- **Propósito**: barra horizontal com slots `Start`, `Middle` e `End`.
- **Complexidade**: 3
- **Patterns cobertos**: UIP-ACTION-ACTION_BAR, UIP-STRUCT-LAYOUT_ZONE
- **Variações demonstradas**: título e ações alinhadas.

## Exemplos

### UIP-ACTION-ACTION_BAR

**Objetivo**: organizar título e comandos.

```razor
<Bar AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
    <Start><h2 class="font-medium">Clientes</h2></Start>
    <End>
        <Button Label="Novo" Style="Themes.Primary" Size="Sizes.Small" />
    </End>
</Bar>
```

**Props usadas**: `Start`, `End`, `AdditionalClasses`.  
**Eventos relevantes**: eventos ficam nos filhos.  
**Por que atende o pattern**: separa contexto e ações visíveis.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Start` | `RenderFragment` | conteúdo esquerdo | contexto |
| `Middle` | `RenderFragment` | centro | filtros/título |
| `End` | `RenderFragment` | ações | comandos |
| `AdditionalClasses` | `string?` | ajuste visual | classes extras |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum direto | não aplicável | eventos nos filhos |

## Limitações
- Não faz overflow responsivo automático.

## Combinações frágeis
- Muitas ações no `End` podem quebrar em mobile.
