# RotateEffect - Sample

## Visão geral
- **Propósito**: aplicar rotação estática por CSS var ao conteúdo.
- **Complexidade**: 3
- **Patterns cobertos**: UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-LOADING_STATE
- **Variações demonstradas**: rotação de ícone.

## Exemplos

### Variação visual de ícone

**Objetivo**: rotacionar símbolo em ação.

```razor
<RotateEffect Degrees="90">
    <Icon Kind="BsIconNames.ChevronRight" />
</RotateEffect>
```

**Props usadas**: `Degrees`, `ChildContent`.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: ajusta orientação visual sem novo ícone.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Degrees` | `int` | rotação estática | define ângulo |
| `ChildContent` | `RenderFragment` | sempre | conteúdo rotacionado |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | efeito visual |

## Limitações
- Não é animação contínua; use `RotationMotion` para movimento.

## Combinações frágeis
- Evitar rotação em conteúdo textual.
