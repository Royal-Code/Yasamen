# DropButton - Sample

## Visão geral
- **Propósito**: botão textual com menu suspenso.
- **Complexidade**: 7
- **Patterns cobertos**: UIP-ACTION-CONTEXTUAL_MENU, UIP-NAV-BREADCRUMB, PP-CATALOG
- **Variações demonstradas**: direção, alinhamento, largura mínima, conteúdo customizado.

## Exemplos

### UIP-ACTION-CONTEXTUAL_MENU

**Objetivo**: menu de ações locais com rótulo explícito.

```razor
<DropButton Label="Ações" Direction="Directions.Down" Align="Positions.End" MinWidth="Sizes.Smaller">
    <DropItem OnClick="@Edit">Editar</DropItem>
    <DropItem OnClick="@Archive">Arquivar</DropItem>
</DropButton>

@code {
    private Task Edit(MouseEventArgs _) => Task.CompletedTask;
    private Task Archive(MouseEventArgs _) => Task.CompletedTask;
}
```

**Props usadas**: `Label`, `Direction`, `Align`, `MinWidth`, `ChildContent`.  
**Eventos relevantes**: `OnOpened`, `OnClosed` disponíveis; `DropItem.OnClick` executa item.  
**Por que atende o pattern**: expõe ações sob demanda sem ocupar espaço permanente.

### UIP-NAV-BREADCRUMB

**Objetivo**: overflow de níveis ocultos no breadcrumb.

```razor
<Breadcrumb>
    <MenuItems>
        <DropItem>Admin</DropItem>
        <DropItem>Clientes</DropItem>
    </MenuItems>
    <Items>
        <BreadcrumbItem Active="true">Contrato</BreadcrumbItem>
    </Items>
</Breadcrumb>
```

**Props usadas**: uso indireto pelo `Breadcrumb`.  
**Eventos relevantes**: eventos ficam nos `DropItem`.  
**Por que atende o pattern**: preserva navegação hierárquica compacta.

### Variação com conteúdo custom

**Objetivo**: botão compacto textual ou icônico usando slot `ButtonContent`.

```razor
<DropButton MinWidth="Sizes.Smaller" Size="Sizes.Smallest" Style="Themes.Light">
    <ButtonContent>
        <Icon Kind="BsIconNames.ThreeDots" />
    </ButtonContent>
    <DropMenu>
        <DropItem>Duplicar</DropItem>
        <DropItem>Excluir</DropItem>
    </DropMenu>
</DropButton>
```

**Props usadas**: `ButtonContent`, `DropMenu`, `Style`, `Size`.  
**Eventos relevantes**: `OnOpened`, `OnClosed`.  
**Por que atende o pattern**: mantém menu contextual compacto com trigger custom.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Label` | `string` | trigger textual | nomeia a ação |
| `ButtonContent` | `RenderFragment` | trigger custom | substitui label visual |
| `Direction` | `Directions` | posição do menu | controla abertura |
| `Align` | `Positions` | alinhamento | ajusta ancoragem |
| `MinWidth` | `Sizes?` | menu mínimo | evita menu estreito |
| `CloseBehavior` | `DropCloseBehavior` | fechar por clique | controla persistência |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnOpened` | menu abre | telemetria ou estado |
| `OnClosed` | menu fecha | limpeza local |

## Limitações
- `Loading` existe, mas renderização de loading não foi confirmada.

## Combinações frágeis
- `ButtonContent` sem texto precisa de `title` ou contexto claro.
