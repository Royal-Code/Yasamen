# DropBase - Sample

## Visão geral
- **Propósito**: base interna que posiciona trigger e conteúdo dos drops.
- **Complexidade**: 7
- **Patterns cobertos**: UIP-ACTION-CONTEXTUAL_MENU
- **Variações demonstradas**: uso indireto via `DropButton` e `DropIconButton`.

## Exemplos

### Uso via DropButton

**Objetivo**: usar base sem instanciar diretamente.

```razor
<DropButton Label="Ações" MinWidth="Sizes.Smaller">
    <DropItem>Editar</DropItem>
    <DropItem>Excluir</DropItem>
</DropButton>
```

**Props usadas**: `Direction`, `Align`, `MinWidth` repassadas ao `DropBase`.  
**Eventos relevantes**: `OnOpened`, `OnClosed`.  
**Por que atende o pattern**: entrega popover de ações com API pública.

### Uso via DropIconButton

**Objetivo**: overflow compacto.

```razor
<DropIconButton Icon="BsIconNames.ThreeDots" Align="Positions.End">
    <DropItem>Duplicar</DropItem>
</DropIconButton>
```

**Props usadas**: props de drop.  
**Eventos relevantes**: `OnOpened`, `OnClosed`.  
**Por que atende o pattern**: usa a base para posicionar menu por ícone.

### Uso direto avançado

**Objetivo**: compor trigger custom quando necessário.

```razor
<DropBase Direction="Directions.Down" Align="Positions.Start" MinWidth="Sizes.Smaller">
    <Action><Button Label="Abrir" /></Action>
    <DropContent><DropItem>Item</DropItem></DropContent>
</DropBase>
```

**Props usadas**: `Action`, `DropContent`, `Direction`, `Align`.  
**Eventos relevantes**: `OnOpened`, `OnClosed`.  
**Por que atende o pattern**: mantém contrato de drop com composição avançada.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Action` | `RenderFragment` | trigger | elemento acionador |
| `DropContent` | `RenderFragment` | menu | conteúdo aberto |
| `Direction` | `Directions` | posição | sentido |
| `Align` | `Positions` | alinhamento | ancoragem |
| `CloseBehavior` | `DropCloseBehavior` | fechamento | persistência |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnOpened` | abertura | estado |
| `OnClosed` | fechamento | limpeza |

## Limitações
- Componente interno; preferir wrappers públicos.

## Combinações frágeis
- Uso direto exige cuidar de acessibilidade do trigger.
