# AsideBox - Sample

## Visão geral
- **Propósito**: caixa padrão para conteúdo de `OffCanvas`, com título e fechar.
- **Complexidade**: 4
- **Patterns cobertos**: UIP-INPUT-FILTER_PANEL, UIP-STRUCT-LAYOUT_ZONE
- **Variações demonstradas**: uso indireto e direto.

## Exemplos

### Uso via OffCanvas

**Objetivo**: obter header/título padrão.

```razor
<OffCanvas Handler="filters" Title="Filtros" Closeable="true">
    <TextField Label="Status" @bind-Value="status" />
</OffCanvas>

@code {
    private readonly OffCanvasHandler filters = new();
    private string status = string.Empty;
}
```

**Props usadas**: `Title`, `Closeable` repassados pelo offcanvas.  
**Eventos relevantes**: close via handler.  
**Por que atende o pattern**: estrutura painel lateral com título.

### Uso direto avançado

**Objetivo**: compor caixa dentro de contexto de offcanvas.

```razor
<AsideBox Title="Detalhes" Closeable="true" Size="Sizes.Medium">
    <p>Conteúdo lateral.</p>
</AsideBox>
```

**Props usadas**: `Title`, `Closeable`, `Size`, `ChildContent`.  
**Eventos relevantes**: botão fechar usa handler cascated.  
**Por que atende o pattern**: padroniza estrutura do painel.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Title` | `string?` | header | título |
| `Closeable` | `bool` | permitir fechar | botão |
| `Size` | `Sizes` | dimensão | largura/altura |
| `ChildContent` | `RenderFragment` | sempre | corpo |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| close por contexto | clique no fechar | fechar offcanvas |

## Limitações
- Requer handler cascated para fechar quando usado diretamente.

## Combinações frágeis
- Usar fora de offcanvas pode quebrar o botão fechar.
