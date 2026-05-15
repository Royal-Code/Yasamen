# Breadcrumb - Sample

## Visão geral
- **Propósito**: trilha hierárquica com itens e overflow opcional.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-NAV-BREADCRUMB, PP-DETAIL
- **Variações demonstradas**: itens diretos e menu de overflow.

## Exemplos

### UIP-NAV-BREADCRUMB

**Objetivo**: mostrar hierarquia completa.

```razor
<Breadcrumb>
    <Items>
        <BreadcrumbItem Href="/clientes">Clientes</BreadcrumbItem>
        <BreadcrumbItem Href="/clientes/42">Cliente 42</BreadcrumbItem>
        <BreadcrumbItem Active="true">Contratos</BreadcrumbItem>
    </Items>
</Breadcrumb>
```

**Props usadas**: `Items`; filhos `BreadcrumbItem`.  
**Eventos relevantes**: eventos nos itens.  
**Por que atende o pattern**: mostra caminho e item atual.

### Overflow

**Objetivo**: compactar níveis intermediários.

```razor
<Breadcrumb>
    <MenuItems>
        <DropItem>Admin</DropItem>
        <DropItem>Cadastros</DropItem>
    </MenuItems>
    <Items>
        <BreadcrumbItem Href="/clientes">Clientes</BreadcrumbItem>
        <BreadcrumbItem Active="true">Cliente 42</BreadcrumbItem>
    </Items>
</Breadcrumb>
```

**Props usadas**: `MenuItems`, `Items`.  
**Eventos relevantes**: `DropItem.OnClick` quando aplicável.  
**Por que atende o pattern**: preserva hierarquia compacta.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Items` | `RenderFragment` | itens visíveis | trilha principal |
| `MenuItems` | `RenderFragment` | níveis ocultos | overflow inicial |
| `AdditionalClasses` | `string?` | ajuste visual | classes extras |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| eventos dos filhos | clique em item | navegação ou callback |

## Limitações
- Loading/skeleton não é nativo.

## Combinações frágeis
- Não usar breadcrumb quando a página não tiver hierarquia real.
