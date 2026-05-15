# Ripple - Sample

## Visão geral
- **Propósito**: efeito de ripple JS/CSS usado em botões.
- **Complexidade**: 3
- **Patterns cobertos**: UIP-ACTION-ACTION_BAR
- **Variações demonstradas**: uso indireto via `Button`.

## Exemplos

### Uso indireto via Button

**Objetivo**: obter microinteração sem instanciar `Ripple`.

```razor
<Button Label="Salvar" Style="Themes.Primary" OnClick="@Save" />

@code {
    private Task Save(MouseEventArgs _) => Task.CompletedTask;
}
```

**Props usadas**: `Ripple` é composto internamente pelo botão.  
**Eventos relevantes**: evento no botão.  
**Por que atende o pattern**: reforça clique de ação de forma consistente.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Dark` | `bool` | fundo escuro | ajusta ripple |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum público | clique via JS/CSS | efeito visual |

## Limitações
- Depende de setup JS/CSS da biblioteca.

## Combinações frágeis
- Não usar como feedback de operação; é apenas microinteração.
