# AppMenu - Sample

## Visão geral
- **Propósito**: menu de aplicação em offcanvas, com breadcrumbs e lista de itens.
- **Complexidade**: 8
- **Patterns cobertos**: UIP-NAV-NAVIGATION_MENU, SHP-WORKSPACE_ADMIN, UIP-INPUT-SEARCH_BAR
- **Variações demonstradas**: uso via botão, offcanvas handler e limitação de busca.

## Exemplos

### Uso recomendado via AppSideMenuButton

**Objetivo**: consumir menu global sem manipular handler diretamente.

```razor
<AppLayout>
    <LeftMenu>
        <AppSideMenuButton />
    </LeftMenu>
    <Main>@Body</Main>
</AppLayout>
```

**Props usadas**: nenhuma no `AppMenu` diretamente.  
**Eventos relevantes**: internos.  
**Por que atende o pattern**: integra menu, offcanvas e navegação global.

### Uso direto avançado

**Objetivo**: controlar menu com handler próprio.

```razor
<Button Label="Abrir menu" OnClick="@(async _ => await menuHandler.OpenAsync())" />
<AppMenu Handler="menuHandler" />

@code {
    private readonly OffCanvasHandler menuHandler = new();
}
```

**Props usadas**: `Handler`.  
**Eventos relevantes**: eventos do handler.  
**Por que atende o pattern**: abre o menu de aplicação sob demanda.

### Busca não pronta

**Objetivo**: compor busca externa ao menu quando necessária.

```razor
<TextField Label="Buscar módulo" @bind-Value="menuSearch" Placeholder="Digite para filtrar" />
<AppSideMenuButton />

@code {
    private string menuSearch = string.Empty;
}
```

**Props usadas**: composição externa.  
**Eventos relevantes**: binding do `TextField`.  
**Por que atende o pattern**: evita prometer busca interna do `AppMenu`.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Handler` | `OffCanvasHandler` | uso direto | controla abertura |
| `AdditionalClasses` | `string?` | ajuste visual | classes extras |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| handler externo | abrir/fechar | controle do menu |

## Limitações
- Busca interna aparece como placeholder textual.

## Combinações frágeis
- Não tratar `AppMenu` como componente de search pronto.
