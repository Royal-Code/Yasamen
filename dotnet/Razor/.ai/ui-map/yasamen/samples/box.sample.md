# Box - Sample

## Visão geral
- **Propósito**: container simples para superfícies, seções e blocos.
- **Complexidade**: 3
- **Patterns cobertos**: UIP-STRUCT-LAYOUT_ZONE, UIP-CONTENT-DETAIL_BLOCK, UIP-DATA-LIST_ITEM
- **Variações demonstradas**: superfície branca com borda e padding.

## Exemplos

### UIP-STRUCT-LAYOUT_ZONE

**Objetivo**: delimitar uma zona funcional.

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <h2 class="text-lg font-medium mb-4">Filtros</h2>
    <TextField Label="Termo" @bind-Value="term" />
</Box>

@code {
    private string term = string.Empty;
}
```

**Props usadas**: `AdditionalClasses`, `ChildContent`.  
**Eventos relevantes**: nenhum direto.  
**Por que atende o pattern**: cria região clara para responsabilidade específica.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Border` | `BorderBuilder` | borda via builder | estilo base |
| `Padding` | `PaddingBuilder` | padding via builder | respiro |
| `Margin` | `MarginBuilder` | margem via builder | espaçamento externo |
| `AdditionalClasses` | `string` | Tailwind/Yasamen | ajuste visual |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | container |

## Limitações
- Não é card semântico dedicado.

## Combinações frágeis
- Evitar aninhar muitos boxes como cards dentro de cards.
