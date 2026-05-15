# Badge - Sample

## Visão geral
- **Propósito**: rótulo inline/chip para status, metadado e destaque leve.
- **Complexidade**: 3
- **Patterns cobertos**: UIP-DATA-LIST_ITEM, UIP-CONTENT-METRIC_CARD, UIP-FEEDBACK-EMPTY_STATE
- **Variações demonstradas**: tema, tamanho, texto.

## Exemplos

### UIP-DATA-LIST_ITEM

**Objetivo**: sinalizar status de item em lista.

```razor
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
    <div class="flex items-center justify-between">
        <span class="font-medium">Cliente 001</span>
        <Badge Text="Ativo" Style="Themes.Success" Size="Sizes.Small" />
    </div>
</Box>
```

**Props usadas**: `Text`, `Style`, `Size`.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: comunica estado sem roubar foco do conteúdo principal.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Text` | `string?` | rótulo simples | conteúdo textual |
| `ChildContent` | `RenderFragment?` | conteúdo custom | substitui texto |
| `Style` | `Themes` | semântica | cor |
| `Size` | `Sizes` | densidade | tamanho |
| `Icon` | `Enum?` | reforço visual | adiciona ícone |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | componente informativo |

## Limitações
- Não é botão nem filtro ativo interativo.

## Combinações frágeis
- `IconPosition.Center` foi identificado como inválido.
