# AppMainLayout - Sample

## Visão geral
- **Propósito**: layout Blazor pronto baseado em `AppLayout`.
- **Complexidade**: 6
- **Patterns cobertos**: SHP-WORKSPACE_ADMIN, UIP-NAV-NAVIGATION_MENU
- **Variações demonstradas**: uso como layout e composição equivalente.

## Exemplos

### Uso como layout de página

**Objetivo**: aplicar shell padrão à página.

```razor
@page "/clientes"
@layout AppMainLayout

<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <h1 class="text-xl font-medium">Clientes</h1>
</Box>
```

**Props usadas**: layout herdado; `Body` é fornecido pelo Blazor.  
**Eventos relevantes**: nenhum direto.  
**Por que atende o pattern**: entrega shell administrativo pronto.

### Equivalente custom com AppLayout

**Objetivo**: customizar zonas quando o layout pronto não basta.

```razor
<AppLayout>
    <LeftMenu><AppSideMenuButton /></LeftMenu>
    <Main>@Body</Main>
    <Footer>Footer</Footer>
</AppLayout>
```

**Props usadas**: slots de `AppLayout`.  
**Eventos relevantes**: nos filhos.  
**Por que atende o pattern**: preserva estrutura com mais controle.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Body` | herdado | layout Blazor | conteúdo da página |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| nenhum direto | não aplicável | layout |

## Limitações
- Pouca customização via parâmetros; use `AppLayout` para variações.

## Combinações frágeis
- Não usar como componente atômico dentro de uma página.
