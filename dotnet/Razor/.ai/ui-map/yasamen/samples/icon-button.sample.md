# IconButton - Sample

## Visão geral
- **Propósito**: botão compacto baseado em ícone para toolbars, sidebars e ações de item.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-ACTION-ACTION_BAR, UIP-ACTION-FLOATING_ACTION, SHP-WORKSPACE_ADMIN
- **Variações demonstradas**: ícone enum, tema, outline, ativo, evento.

## Exemplos

### UIP-ACTION-ACTION_BAR

**Objetivo**: criar toolbar compacta com ações por ícone.

```razor
<ButtonGroup Size="Sizes.Small" AriaLabel="Ferramentas">
    <IconButton Icon="BsIconNames.Search" Style="Themes.Info" />
    <IconButton Icon="BsIconNames.Pencil" Style="Themes.Secondary" />
    <IconButton Icon="BsIconNames.Trash" Style="Themes.Danger" Outline="true" />
</ButtonGroup>
```

**Props usadas**: `Icon`, `Style`, `Outline`, `Size` herdado via `ButtonGroup`.  
**Eventos relevantes**: nenhum no exemplo.  
**Por que atende o pattern**: concentra ações compactas sem ocupar espaço textual.

### UIP-ACTION-FLOATING_ACTION

**Objetivo**: ação primária flutuante composta com posicionamento CSS.

```razor
<IconButton Icon="BsIconNames.Plus"
            Style="Themes.Primary"
            Size="Sizes.Largest"
            title="Criar item"
            AdditionalClasses="fixed right-6 bottom-6 z-notification shadow-lg"
            OnClick="@Create" />

@code {
    private Task Create(MouseEventArgs _) => Task.CompletedTask;
}
```

**Props usadas**: `Icon`, `Style`, `Size`, `AdditionalClasses`, `OnClick`.  
**Eventos relevantes**: `OnClick` executa a ação.  
**Por que atende o pattern**: mantém uma ação dominante acessível acima do conteúdo.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Icon` | `Enum` | ícone registrado | renderiza símbolo principal |
| `IconFragment` | `IconFragment?` | ícone custom | alternativa ao enum |
| `Style` | `Themes` | semântica de ação | muda cor |
| `Active` | `bool` | ferramenta selecionada | mostra estado ativo |
| `NavigateTo` | `string?` | atalho de navegação | navega sem handler |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnClick` | clique | ação compacta, abrir menu, alternar estado |

## Limitações
- `Icon` e `IconFragment` não devem ser usados juntos.
- Sem label visível, depende de contexto ou `title`/atributos para clareza.

## Combinações frágeis
- Não usar como CTA principal quando a ação exige texto para entendimento.
