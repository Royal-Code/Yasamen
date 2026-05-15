# YasamenStyles - Sample

## Visão geral
- **Propósito**: carregar folhas de estilo da biblioteca no app.
- **Complexidade**: 3
- **Patterns cobertos**: SHP-WORKSPACE_ADMIN
- **Variações demonstradas**: uso no root/shell.

## Exemplos

### Setup visual da aplicação

**Objetivo**: disponibilizar CSS Yasamen para todos os componentes.

```razor
<head>
    <YasamenStyles />
</head>
```

**Props usadas**: nenhuma pública evidenciada.  
**Eventos relevantes**: nenhum.  
**Por que atende o pattern**: garante que tokens, classes e componentes renderizem corretamente.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| comportamento debug/release | interno | sempre no app | escolhe CSS dist/bundle |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum | não aplicável | setup |

## Limitações
- Não é componente visual de tela.

## Combinações frágeis
- Sem ele, classes `ya-*` podem não aparecer como esperado.
