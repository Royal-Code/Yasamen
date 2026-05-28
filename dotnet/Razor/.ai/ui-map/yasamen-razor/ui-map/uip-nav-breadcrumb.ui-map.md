# UIP-NAV-BREADCRUMB - Breadcrumb

## Componentes

**Principais**:

1. Breadcrumb
- `cobertura`: trilha hierárquica com `BreadcrumbItem`; separadores automáticos; item atual não navegável; `DescribesBreadcrumbs` para composição automática com `MaxVisibleItems`; overflow via `DropButton` (itens ocultos ficam em dropdown); adequado para hierarquia fixa; rendering como `<nav>` HTML semântico;
- `limitações`: itens configurados em markup (não dinâmicos por rota automaticamente — necessário `DescribesBreadcrumbs`); `DescribesBreadcrumbs` requer que as páginas descendentes cooperem (padrão observer); sem skeleton de loading nativo;
- `nota`: 9;
- `justificativa`: cobertura nativa completa — trilha hierárquica, overflow via dropdown, item atual, separadores automáticos.

2. DescribesBreadcrumbs
- `cobertura`: componente inteligente que coleta itens de breadcrumb de páginas descendentes (padrão observer); `MaxVisibleItems` para truncamento; alternativo ao `Breadcrumb` manual;
- `limitações`: requer que as páginas filhas usem o mesmo mecanismo de registro de itens;
- `nota`: 8;
- `justificativa`: boa cobertura para breadcrumb dinâmico baseado em rota.

**Composição**:

1. BreadcrumbItem
- `cobertura`: item individual com texto e href opcional;
- `nota`: 9;
- `justificativa`: item atômico do breadcrumb.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `skeleton de loading`: sem suporte nativo — condicionalmente ocultar o breadcrumb ou exibir placeholder textual enquanto a rota carrega;
  - `truncamento mobile (exibir só último nível)`: ajustar com `MaxVisibleItems=1` ou `MaxVisibleItems=2` em `DescribesBreadcrumbs`.

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Breadcrumb simples: `<Breadcrumb>` + `<BreadcrumbItem>` por nível;
  - Breadcrumb dinâmico por rota: `<DescribesBreadcrumbs MaxVisibleItems="4" />` no layout + registrar itens nas páginas filhas;
  - Truncamento mobile: passar `MaxVisibleItems` menor para viewports pequenas.

## Como usar

### Breadcrumb manual (definição inline)

```razor
<Breadcrumb AdditionalClasses="mb-4">
    <BreadcrumbItem Text="Início" Href="/" />
    <BreadcrumbItem Text="Usuários" Href="/usuarios" />
    <BreadcrumbItem Text="João Silva" />
</Breadcrumb>
```

### DescribesBreadcrumbs (dinâmico por rota)

```razor
@* No layout raiz — renderiza a trilha baseada nas páginas ativas *@
<DescribesBreadcrumbs MaxVisibleItems="4" AdditionalClasses="mb-4" />

@* Na página de detalhe — registra seu nível na trilha *@
@* [inferido: mecanismo exato de registro depende da API do DescribesBreadcrumbs] *@
```

### Breadcrumb com overflow (muitos níveis)

```razor
@* Quando há mais de MaxVisibleItems, os intermediários ficam em dropdown *@
<DescribesBreadcrumbs MaxVisibleItems="3" />
@* Resultado: [Início] / [...] / [Nível Atual] — itens ocultados em DropButton *@
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: itens manuais requerem markup explícito; `DescribesBreadcrumbs` requer cooperação das páginas filhas; sem skeleton de loading; truncamento mobile requer `MaxVisibleItems` ajustado;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `Breadcrumb` + `BreadcrumbItem` é componente nativo da biblioteca com overflow via dropdown, separadores automáticos e semântica de `<nav>`;
  - `DescribesBreadcrumbs` cobre o caso de breadcrumb dinâmico por rota;
  - Nota 9 — cobertura nativa completa do pattern; único gap menor é a coordenação necessária entre `DescribesBreadcrumbs` e as páginas filhas.
