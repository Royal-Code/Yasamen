# Container - Sample

## Visão geral
- **Propósito**: grid/flex responsivo que fornece contexto para `Slot`.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-STRUCT-GRID_CONTAINER, PP-FORM, PP-DASHBOARD
- **Variações demonstradas**: grid padrão e layout flex.

## Exemplos

### UIP-STRUCT-GRID_CONTAINER

**Objetivo**: distribuir blocos por colunas responsivas.

```razor
<Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default">
    <Slot Span="4" LaptopSpan="6">
        <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">Resumo</Box>
    </Slot>
    <Slot Span="4" LaptopSpan="6">
        <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">Detalhe</Box>
    </Slot>
</Container>
```

**Props usadas**: `Type`, `Size`, `ChildContent`.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: usa grid oficial 4/8/12/16.

### PP-FORM

**Objetivo**: organizar campos em colunas.

```razor
<EditForm Model="model">
    <Container>
        <Slot Span="4" LaptopSpan="6"><TextField Label="Nome" @bind-Value="model.Name" /></Slot>
        <Slot Span="4" LaptopSpan="6"><TextField Label="E-mail" @bind-Value="model.Email" /></Slot>
    </Container>
</EditForm>

@code {
    private FormModel model = new();
    private sealed class FormModel { public string Name { get; set; } = string.Empty; public string Email { get; set; } = string.Empty; }
}
```

**Props usadas**: `ChildContent`.  
**Eventos relevantes**: eventos nos campos.  
**Por que atende o pattern**: reduz colunas por breakpoint via slots.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Type` | `LayoutTypes` | grid ou flex | modo de layout |
| `Size` | `LayoutSizes` | capacidade por breakpoint | quantidade de colunas |
| `Height` | `SpacingSize?` | altura contextual | dimensão vertical |
| `AdditionalClasses` | `string?` | ajuste visual | classes extras |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | estrutural |

## Limitações
- Não traz estados de loading/empty por si só.

## Combinações frágeis
- Usar `Slot` fora do contexto de `Container` perde parte da intenção responsiva.
