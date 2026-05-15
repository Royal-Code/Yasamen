# ButtonGroup - Sample

## Visão geral
- **Propósito**: agrupar botões relacionados e cascatear estilo, tamanho e disabled.
- **Complexidade**: 4
- **Patterns cobertos**: UIP-ACTION-ACTION_BAR, UIP-NAV-TABS, PP-FORM
- **Variações demonstradas**: horizontal, vertical, estado ativo.

## Exemplos

### UIP-ACTION-ACTION_BAR

**Objetivo**: ações principais de formulário com continuidade visual.

```razor
<ButtonGroup AriaLabel="Ações do formulário" Size="Sizes.Small">
    <Button Label="Salvar" Style="Themes.Primary" />
    <Button Label="Cancelar" Style="Themes.Light" />
</ButtonGroup>
```

**Props usadas**: `AriaLabel`, `Size`, filhos `Button`.  
**Eventos relevantes**: eventos ficam nos filhos.  
**Por que atende o pattern**: mantém ações relacionadas próximas e hierarquizadas.

### UIP-NAV-TABS

**Objetivo**: simular tabs locais quando não houver componente dedicado.

```razor
<ButtonGroup AriaLabel="Visões">
    <Button Label="Lista" Active="@(view == "list")" OnClick="@(_ => view = "list")" />
    <Button Label="Quadro" Active="@(view == "board")" OnClick="@(_ => view = "board")" />
</ButtonGroup>

@code {
    private string view = "list";
}
```

**Props usadas**: `Active`, `OnClick` nos filhos.  
**Eventos relevantes**: `OnClick` troca a visão.  
**Por que atende o pattern**: oferece alternância visual local, embora sem semântica completa de tabs.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Orientation` | `ButtonGroupOrientation` | barra horizontal ou vertical | muda composição |
| `Style` | `Themes` | default para filhos | reduz repetição |
| `Size` | `Sizes` | densidade | cascateia tamanho |
| `Disabled` | `bool` | bloquear grupo | desabilita filhos |
| `AriaLabel` | `string?` | grupos sem texto externo | melhora acessibilidade |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| eventos dos filhos | clique em cada botão | ação específica |

## Limitações
- Não é tab semântica por si só.

## Combinações frágeis
- Muitos botões horizontais em largura estreita; usar `Orientation="ButtonGroupOrientation.Vertical"`.
