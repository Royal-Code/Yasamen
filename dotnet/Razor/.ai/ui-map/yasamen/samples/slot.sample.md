# Slot - Sample

## Visão geral
- **Propósito**: coluna/área responsiva dentro de `Container`.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-STRUCT-GRID_CONTAINER, PP-LIST-DETAIL
- **Variações demonstradas**: spans por breakpoint.

## Exemplos

### UIP-STRUCT-GRID_CONTAINER

**Objetivo**: definir largura por faixa.

```razor
<Container>
    <Slot Span="4" TabletSpan="4" LaptopSpan="8" DesktopSpan="8">
        <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">Conteúdo principal</Box>
    </Slot>
    <Slot Span="4" TabletSpan="4" LaptopSpan="4" DesktopSpan="4">
        <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">Aside</Box>
    </Slot>
</Container>
```

**Props usadas**: `Span`, `TabletSpan`, `LaptopSpan`, `DesktopSpan`.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: controla distribuição responsiva do grid.

### PP-LIST-DETAIL

**Objetivo**: lista e detalhe em colunas.

```razor
<Container>
    <Slot Span="4" LaptopSpan="4">Lista</Slot>
    <Slot Span="4" LaptopSpan="8">Detalhe</Slot>
</Container>
```

**Props usadas**: spans responsivos.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: cria master-detail por composição.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Span` | `int` | base/sm | largura base |
| `TabletSpan` | `int` | md | largura tablet |
| `LaptopSpan` | `int` | lg | largura laptop |
| `DesktopSpan` | `int` | 2xl | largura desktop amplo |
| `Height` | `SpacingSize?` | altura | dimensão vertical |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | estrutural |

## Limitações
- Não define semântica do conteúdo.

## Combinações frágeis
- Spans inconsistentes com o tamanho do `Container` podem gerar layout estranho.
