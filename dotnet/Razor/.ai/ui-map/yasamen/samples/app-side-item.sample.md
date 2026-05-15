# AppSideItem - Sample

## Visão geral
- **Propósito**: item visual de sidebar com estado ativo.
- **Complexidade**: 2
- **Patterns cobertos**: UIP-NAV-NAVIGATION_MENU, SHP-WORKSPACE_ADMIN
- **Variações demonstradas**: ativo e conteúdo custom.

## Exemplos

### UIP-NAV-NAVIGATION_MENU

**Objetivo**: item de navegação lateral.

```razor
<AppSideItem Active="true">
    <IconButton Icon="BsIconNames.List" title="Clientes" />
</AppSideItem>
```

**Props usadas**: `Active`, `ChildContent`.  
**Eventos relevantes**: eventos no conteúdo filho.  
**Por que atende o pattern**: destaca destino ativo da navegação.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Active` | `bool` | item atual | aplica destaque |
| `ChildContent` | `RenderFragment?` | conteúdo | botão/ícone |
| `AdditionalClasses` | `string` | ajuste local | classes extras |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum direto | não aplicável | eventos nos filhos |

## Limitações
- Não carrega rota ou modelo de menu sozinho.

## Combinações frágeis
- Item ativo sem navegação real pode confundir localização.
