# Feedback - Sample

## Visão geral
- **Propósito**: alerta/banner inline para sucesso, erro, aviso e informação.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-FEEDBACK-TOAST_ALERT, UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-EMPTY_STATE
- **Variações demonstradas**: tema, título, texto, closeable, block.

## Exemplos

### UIP-FEEDBACK-ERROR_STATE

**Objetivo**: erro contextual com retry externo.

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <Feedback Style="Themes.Danger"
              Title="Não foi possível carregar"
              Text="Tente novamente em instantes."
              Block="true" />
    <Button Label="Tentar novamente" Style="Themes.Primary" AdditionalClasses="mt-4" />
</Box>
```

**Props usadas**: `Style`, `Title`, `Text`, `Block`.  
**Eventos relevantes**: nenhum no exemplo.  
**Por que atende o pattern**: comunica falha no contexto da zona e oferece ação de recuperação.

### UIP-FEEDBACK-TOAST_ALERT

**Objetivo**: alerta inline persistente e dispensável.

```razor
<Feedback Style="Themes.Success"
          Title="Alterações salvas"
          Text="Os dados foram atualizados."
          Closeable="true"
          OnClose="@Closed" />

@code {
    private Task Closed() => Task.CompletedTask;
}
```

**Props usadas**: `Closeable`, `OnClose`.  
**Eventos relevantes**: `OnClose` dispara ao fechar.  
**Por que atende o pattern**: feedback não bloqueante após ação concluída.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Style` | `Themes` | tipo da mensagem | cor semântica |
| `Title` | `string?` | mensagem estruturada | cria cabeçalho |
| `Text` | `string?` | mensagem simples | corpo textual |
| `Icon` | `Enum?` | reforço | mostra ícone |
| `Closeable` | `bool` | alerta dispensável | mostra fechar |
| `Block` | `bool` | largura total | ocupa bloco |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnClose` | fechar feedback | limpar estado local |

## Limitações
- Não substitui toast flutuante global.

## Combinações frágeis
- Não usar para confirmação prévia de ação destrutiva; usar `Modal`.
