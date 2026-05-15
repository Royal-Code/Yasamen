# Yasamen Styles And Assets Guide

## Objetivo
Orientar a IA a aplicar estilos Yasamen, temas, tamanhos, assets CSS e classes utilitárias sem quebrar o pipeline visual da biblioteca.

## Quando usar
Use este guide ao gerar:
- Qualquer tela Yasamen com estilos visuais.
- Componentes com `Style`, `Size`, `AdditionalClasses` ou classes `ya-*`.
- Setup de assets CSS em `App.razor`.
- Ajustes de tema, densidade, responsividade, espaçamento ou build visual.

## Decisão corporativa
O CSS Yasamen deve ser carregado via `<YasamenStyles />`. Telas devem usar parâmetros tipados (`Themes`, `Sizes`, `Positions`, `Placements`) e classes existentes da biblioteca antes de criar CSS novo. O pipeline de estilos pertence ao projeto `RoyalCode.Razor.Styles`, que usa Tailwind 4 e bundle próprio.

## Regras
- Sempre carregue `<YasamenStyles />` no app raiz; ele escolhe os assets corretos para debug e release.
- Em debug, `YasamenStyles` carrega `yasamen.dist.css` e `styles.css`; em release, carrega `styles.bundle.css`.
- Use parâmetros de componentes para tema e tamanho antes de usar classes manuais.
- Use `Themes` para intenção semântica: `Primary`, `Secondary`, `Tertiary`, `Info`, `Highlight`, `Success`, `Warning`, `Alert`, `Danger`, `Light`, `Dark`.
- Use `Sizes` para escala: `Smallest`, `Smaller`, `Small`, `Medium`, `Large`, `Larger`, `Largest`.
- Não invente nomes de classes `ya-*`; use apenas classes evidenciadas em componentes, CSS ou artefatos do ui-map.
- Use `AdditionalClasses` para ajustes de layout, espaçamento e largura quando o componente expõe esse parâmetro.
- Preserve a classe base do componente (`ya-btn`, `ya-i-btn`, `ya-field-group`, `ya-modal`, `ya-offcanvas`, etc.); não substitua o styling do componente por uma classe própria.
- Para telas, prefira utilitários Tailwind já presentes no pipeline (`flex`, `gap-*`, `p-*`, `mt-*`, `w-full`, etc.) combinados com componentes Yasamen.
- Para alterações de fonte CSS da biblioteca, edite fontes do projeto `RoyalCode.Razor.Styles`, não os arquivos gerados sem necessidade.
- Ao alterar CSS base, respeite o pipeline local: `bun run build:tw:css` gera `yasamen.dist.css`, `bun run build:tw:css:min` gera `yasamen.min.css` e `bun run bundle:css` gera `styles.bundle.css`.
- Não gere instruções que dependam de tokens inexistentes; use tokens do `@theme` em `wwwroot/yasamen.css` quando precisar referenciar cores, spacing ou breakpoints.
- Não carregue manualmente `yasamen.dist.css` e `styles.bundle.css` ao mesmo tempo em uma tela; deixe `YasamenStyles` controlar isso.

## Exemplos / Passo-a-passo

### Carregar estilos no app raiz

```razor
<head>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.13.1/font/bootstrap-icons.min.css">
    <YasamenStyles />
    <HeadOutlet />
</head>
```

### Usar tema e tamanho por parâmetro

```razor
<Button Label="Salvar"
        Style="Themes.Primary"
        Size="Sizes.Medium" />

<Button Label="Excluir"
        Style="Themes.Danger"
        Outline="true"
        Size="Sizes.Small" />
```

### Ajustar layout com `AdditionalClasses`

```razor
<TextField Label="Nome"
           @bind-Value="model.Name"
           AdditionalClasses="max-w-150" />

<Box AdditionalClasses="p-8 bg-white border-none">
    <h1>Clientes</h1>
</Box>
```

### Referenciar tokens existentes de tema

```css
.customer-summary {
    color: var(--color-secondary-700);
    background: var(--color-light-50);
}
```

### Pipeline local de estilos

```json
{
  "scripts": {
    "build:tw:css": "bunx @tailwindcss/cli -i ./wwwroot/yasamen.css -o ./wwwroot/yasamen.dist.css",
    "build:tw:css:min": "bunx @tailwindcss/cli -i ./wwwroot/yasamen.css -o ./wwwroot/yasamen.min.css --minify",
    "bundle:css": "bunx gulp bundle-css"
  }
}
```

## Anti-padrões
- Não criar CSS paralelo para substituir estados de botão, input, modal, offcanvas ou notificação já cobertos por classes Yasamen.
- Não usar string manual como `"primary"` quando o componente espera `Themes.Primary`.
- Não usar classes inventadas como `ya-btn-super-primary` ou `ya-field-huge`.
- Não linkar assets gerados diretamente em cada página.
- Não alterar `wwwroot/yasamen.dist.css`, `yasamen.min.css` ou `styles.bundle.css` como fonte principal de design.
- Não assumir que `Themes.Default` sempre gera aparência primária; o enum declara que costuma mapear para secundário.

## Fontes
- `RoyalCode.Razor.Styles/Styles/YasamenStyles.razor`
- `RoyalCode.Razor.Styles/Styles/Themes.cs`
- `RoyalCode.Razor.Styles/Styles/Sizes.cs`
- `RoyalCode.Razor.Styles/Styles/Css.Extensions.cs`
- `RoyalCode.Razor.Styles/wwwroot/yasamen.css`
- `RoyalCode.Razor.Styles/wwwroot/css/variables.css`
- `RoyalCode.Razor.Styles/package.json`
- `RoyalCode.Razor.Styles/RoyalCode.Razor.Styles.csproj`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs/Components/App.razor`
