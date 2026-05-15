# RotationMotion - Sample

## Visão geral
- **Propósito**: wrapper para animação contínua de rotação.
- **Complexidade**: 3
- **Patterns cobertos**: UIP-FEEDBACK-LOADING_STATE
- **Variações demonstradas**: loading visual.

## Exemplos

### UIP-FEEDBACK-LOADING_STATE

**Objetivo**: indicar processamento com ícone girando.

```razor
<div class="flex items-center gap-3 text-dark-600">
    <RotationMotion>
        <Icon Kind="BsIconNames.Gear" />
    </RotationMotion>
    <span>Carregando...</span>
</div>
```

**Props usadas**: `ChildContent`.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: sinaliza espera sem bloquear layout.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `CounterClockwise` | `bool` | direção | sentido da rotação |
| `ChildContent` | `RenderFragment` | sempre | conteúdo animado |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | motion |

## Limitações
- Não substitui skeleton de carregamento.

## Combinações frágeis
- Movimento contínuo demais pode gerar ruído.
