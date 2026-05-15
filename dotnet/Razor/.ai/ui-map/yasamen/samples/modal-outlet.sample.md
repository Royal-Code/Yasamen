# ModalOutlet - Sample

## Visão geral
- **Propósito**: outlet global que renderiza modais e backdrop.
- **Complexidade**: 6
- **Patterns cobertos**: SHP-WORKSPACE_ADMIN, UIP-FEEDBACK-CONFIRMATION_DIALOG
- **Variações demonstradas**: uso indireto pelo shell e uso direto.

## Exemplos

### Uso recomendado via AppLayout

**Objetivo**: incluir infraestrutura de modal no shell.

```razor
<AppLayout>
    <Main>@Body</Main>
</AppLayout>
```

**Props usadas**: indiretas pelo shell.  
**Eventos relevantes**: internos do serviço de modal.  
**Por que atende o pattern**: garante camada global para modais.

### Uso direto em shell custom

**Objetivo**: adicionar outlet quando não usar `AppLayout`.

```razor
<main class="min-h-screen bg-light-100">
    @Body
    <ModalOutlet />
</main>
```

**Props usadas**: service-driven.  
**Eventos relevantes**: internos.  
**Por que atende o pattern**: permite que `Modal` apareça em camada adequada.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| nenhuma pública evidenciada | service-driven | shell | renderização global |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| internos | modal/backdrop | fechar por Escape/backdrop |

## Limitações
- Infraestrutura interna; normalmente não precisa ser usado diretamente.

## Combinações frágeis
- Esquecer outlet em shell custom impede modais globais de renderizarem corretamente.
