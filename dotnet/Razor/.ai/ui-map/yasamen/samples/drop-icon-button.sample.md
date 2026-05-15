# DropIconButton - Sample

## Visão geral
- **Propósito**: botão de ícone com menu suspenso para ações compactas.
- **Complexidade**: 7
- **Patterns cobertos**: UIP-ACTION-CONTEXTUAL_MENU, PP-FEED, UIP-DATA-DATA_TABLE
- **Variações demonstradas**: direção, alinhamento, largura mínima, eventos.

## Exemplos

### UIP-ACTION-CONTEXTUAL_MENU

**Objetivo**: overflow por item.

```razor
<DropIconButton Icon="BsIconNames.ThreeDots"
                Direction="Directions.Down"
                Align="Positions.End"
                MinWidth="Sizes.Smaller">
    <DropItem OnClick="@Edit">Editar</DropItem>
    <DropItem OnClick="@Delete">Excluir</DropItem>
</DropIconButton>

@code {
    private Task Edit(MouseEventArgs _) => Task.CompletedTask;
    private Task Delete(MouseEventArgs _) => Task.CompletedTask;
}
```

**Props usadas**: `Icon`, `Direction`, `Align`, `MinWidth`.  
**Eventos relevantes**: `DropItem.OnClick`, `OnOpened`, `OnClosed`.  
**Por que atende o pattern**: coloca ações locais em menu sob demanda.

### UIP-DATA-DATA_TABLE

**Objetivo**: ações de linha em tabela manual.

```razor
<td class="p-3 text-right">
    <DropIconButton Icon="BsIconNames.ThreeDots" MinWidth="Sizes.Smaller">
        <DropItem>Ver</DropItem>
        <DropItem>Editar</DropItem>
    </DropIconButton>
</td>
```

**Props usadas**: `Icon`, `MinWidth`.  
**Eventos relevantes**: eventos nos itens.  
**Por que atende o pattern**: reduz densidade visual em linhas de dados.

### PP-FEED

**Objetivo**: menu de item em stream.

```razor
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
    <div class="flex justify-between">
        <span>Atualização publicada</span>
        <DropIconButton Icon="BsIconNames.ThreeDots">
            <DropItem>Ocultar</DropItem>
            <DropItem>Copiar link</DropItem>
        </DropIconButton>
    </div>
</Box>
```

**Props usadas**: `Icon`, `ChildContent`.  
**Eventos relevantes**: eventos dos itens.  
**Por que atende o pattern**: oferece ações secundárias sem poluir o item.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Icon` | `Enum` | trigger padrão | define símbolo |
| `IconFragment` | `IconFragment?` | ícone custom | alternativa ao enum |
| `Direction` | `Directions` | controlar abertura | posição do menu |
| `Align` | `Positions` | alinhar menu | evita overflow visual |
| `MinWidth` | `Sizes?` | legibilidade | largura mínima |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnOpened` | abertura | analytics ou estado |
| `OnClosed` | fechamento | limpeza local |

## Limitações
- Sem variante mobile sheet nativa.

## Combinações frágeis
- Não usar como única ação principal quando o usuário precisa ver a ação sem abrir menu.
