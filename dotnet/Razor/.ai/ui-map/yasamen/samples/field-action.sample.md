# FieldAction - Sample

## Visão geral
- **Propósito**: ação acoplada ao footer de um campo.
- **Complexidade**: 4
- **Patterns cobertos**: UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-SEARCH_BAR
- **Variações demonstradas**: ação primária e outline.

## Exemplos

### UIP-INPUT-SEARCH_BAR

**Objetivo**: executar busca a partir do campo.

```razor
<TextField Label="Buscar" @bind-Value="query">
    <FooterAction>
        <FieldAction Label="Pesquisar" Style="Themes.Primary" OnClick="@Search" />
    </FooterAction>
</TextField>

@code {
    private string query = string.Empty;
    private Task Search(MouseEventArgs _) => Task.CompletedTask;
}
```

**Props usadas**: `Label`, `Style`, `OnClick`.  
**Eventos relevantes**: `OnClick`.  
**Por que atende o pattern**: mantém comando associado ao campo.

### Ação secundária

**Objetivo**: ação de menor peso no footer.

```razor
<TextField Label="Código" @bind-Value="code">
    <FooterAction>
        <FieldAction Label="Validar" Style="Themes.Secondary" Outline="true" OnClick="@Validate" />
    </FooterAction>
</TextField>

@code {
    private string code = string.Empty;
    private Task Validate(MouseEventArgs _) => Task.CompletedTask;
}
```

**Props usadas**: `Outline`, `Style`.  
**Eventos relevantes**: `OnClick`.  
**Por que atende o pattern**: permite ação contextual sem criar barra externa.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Label` | `string` | ação textual | rótulo |
| `Style` | `Themes` | semântica | cor |
| `Icon` | `Enum?` | reforço | ícone |
| `Outline` | `bool` | ação secundária | peso menor |
| `Disabled` | `bool` | estado bloqueado | impede ação |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnClick` | clique | validar, buscar, salvar campo |

## Limitações
- Deve ficar dentro de contexto de field.

## Combinações frágeis
- Não usar como substituto de action bar de formulário inteiro.
