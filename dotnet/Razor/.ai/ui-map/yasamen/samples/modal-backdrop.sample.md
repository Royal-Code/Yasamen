# ModalBackdrop - Sample

## Visão geral
- **Propósito**: backdrop interno de modal com fases de transição.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-FEEDBACK-CONFIRMATION_DIALOG, SHP-WORKSPACE_ADMIN
- **Variações demonstradas**: uso indireto via `ModalOutlet`.

## Exemplos

### Uso indireto

**Objetivo**: obter backdrop leve sem instanciar diretamente.

```razor
<Modal Id="confirm" Handler="handler">
    <Box AdditionalClasses="p-6 bg-white rounded-md">
        <Feedback Style="Themes.Warning" Text="Confirme a operação." />
    </Box>
</Modal>

@code {
    private readonly ModalHandler handler = new();
}
```

**Props usadas**: indiretas pelo `ModalOutlet`.  
**Eventos relevantes**: clique no backdrop é tratado pelo serviço quando permitido.  
**Por que atende o pattern**: cria bloqueio visual e separação de camada.

### Shell com outlet

**Objetivo**: garantir que backdrop exista no shell custom.

```razor
<main>
    @Body
    <ModalOutlet />
</main>
```

**Props usadas**: service-driven.  
**Eventos relevantes**: internos.  
**Por que atende o pattern**: `ModalBackdrop` é renderizado pelo outlet.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| fases internas | `TransitionPhases` | interno | animação |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| internos | clique/escape | fechar quando permitido |

## Limitações
- Não usar diretamente como backdrop genérico.

## Combinações frágeis
- Backdrop duplicado com CSS custom pode competir com z-index do modal.
