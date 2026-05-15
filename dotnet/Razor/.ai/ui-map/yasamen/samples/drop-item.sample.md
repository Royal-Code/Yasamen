# DropItem - Sample

## Visão geral
- **Propósito**: item clicável ou estrutural dentro de `DropButton` e `DropIconButton`.
- **Complexidade**: 3
- **Patterns cobertos**: UIP-ACTION-CONTEXTUAL_MENU, UIP-NAV-BREADCRUMB
- **Variações demonstradas**: conteúdo e evento.

## Exemplos

### UIP-ACTION-CONTEXTUAL_MENU

**Objetivo**: representar uma ação local dentro de dropdown.

```razor
<DropIconButton Icon="BsIconNames.ThreeDots" MinWidth="Sizes.Smaller">
    <DropItem OnClick="@Edit">Editar</DropItem>
    <DropItem OnClick="@Delete">Excluir</DropItem>
</DropIconButton>

@code {
    private Task Edit(MouseEventArgs _) => Task.CompletedTask;
    private Task Delete(MouseEventArgs _) => Task.CompletedTask;
}
```

**Props usadas**: `ChildContent`, `OnClick`.  
**Eventos relevantes**: `OnClick` executa a ação.  
**Por que atende o pattern**: cada item representa uma operação contextual.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `ChildContent` | `RenderFragment` | sempre | texto ou conteúdo do item |
| `OnClick` | `EventCallback<MouseEventArgs>` | item acionável | adiciona comportamento |
| `AdditionalClasses` | `string?` | ajuste visual | acrescenta classes |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnClick` | clique | executar item |

## Limitações
- Não há prop disabled documentada.

## Combinações frágeis
- Ações destrutivas precisam de confirmação fora do `DropItem`.
