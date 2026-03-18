# Sistema de Estilos, Tokens e CSS

> Como a biblioteca organiza os estilos em `RoyalCode.Razor.Styles`, como `yasamen.css` define os tokens do design system e como montar o CSS público de um componente.

---

## Papel Deste Guide

Este guide trata da mecânica do sistema de estilos:

- onde o CSS público deve morar;
- como `yasamen.css` organiza imports e tokens;
- como usar `Themes`, `Sizes`, `CssClasses` e builders;
- como escrever CSS consistente com a escala do projeto.

Ele **não** é o guide principal para decidir o que vira contrato visual público. Para isso, usar [css-visual-contract.md](css-visual-contract.md).

---

## Visão Geral

`RoyalCode.Razor.Styles` concentra a infraestrutura visual compartilhada da biblioteca. Ele contém:

1. enums semânticos como `Themes`, `Sizes` e `Positions`;
2. extension methods que transformam enums em classes CSS;
3. builders como `CssClasses`, `BorderBuilder` e `PaddingBuilder`;
4. utilitários estáticos `Css.*`;
5. o componente `YasamenStyles`, que injeta os estilos na aplicação;
6. o arquivo `wwwroot/yasamen.css`, que concentra imports e tokens do Tailwind via `@theme`.

Regra base:

- CSS público da biblioteca vive em `RoyalCode.Razor.Styles/wwwroot/`;
- componentes não devem nascer com `*.razor.css` novo sem justificativa arquitetural explícita.

---

## `yasamen.css` como Fonte Canônica de Tokens

O arquivo `RoyalCode.Razor.Styles/wwwroot/yasamen.css` cumpre dois papéis:

1. importar os arquivos CSS públicos do design system;
2. definir os tokens usados pela escala visual da biblioteca.

Hoje ele concentra tokens para:

- breakpoints `xs`, `sm`, `md`, `lg`, `xl`, `2xl`;
- paleta semântica de temas (`primary`, `secondary`, `success`, `warning`, `danger` etc.);
- fontes base;
- tamanhos tipográficos adicionais;
- escala de espaçamento;
- escala de line-height.

### Regra prática

Ao criar CSS novo:

- preferir tokens e escalas já definidos;
- evitar valores arbitrários se a escala existente já cobre o caso;
- preferir breakpoints do tema a media queries soltas;
- preferir cores semânticas em vez de hexs ad hoc.

Se um caso realmente pedir um valor novo, isso deve ser exceção justificada, não hábito.

---

## Política de Arquivos CSS

### Regra canônica

Para componentes da biblioteca:

- o CSS público vai para `RoyalCode.Razor.Styles/wwwroot/`;
- os imports entram em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`;
- o componente monta classes públicas e estáveis;
- o detalhe de markup local não deve virar regra nova em `*.razor.css`.

### Estrutura esperada

| Tipo | Pasta |
|---|---|
| Componentes visuais | `wwwroot/css/components/` |
| Formulários | `wwwroot/css/forms/` |
| Utilitários globais | `wwwroot/css/` |

Exemplo:

```css
@import './css/components/btn.css';
@import './css/components/badge.css';
@import './css/forms/fieldgroup.css';
```

### Exceções existentes

Hoje ainda existem `*.razor.css` em alguns pacotes, como:

- `RoyalCode.Razor.Animations`
- `RoyalCode.Razor.Drops`
- `RoyalCode.Razor.OffCanvas`

Tratar esses casos como legado ou dívida técnica.

### Regra para novos componentes

Não introduzir `*.razor.css` novo sem justificativa arquitetural explícita.

Se houver exceção real, ela deve ser:

- pequena;
- local;
- documentada;
- difícil de migrar para `RoyalCode.Razor.Styles` sem regressão.

---

## Decisões Obrigatórias em Componente Novo

Todo componente novo deve registrar no `design.md`:

1. se expõe `Style: Themes`;
2. se expõe `Size: Sizes`;
3. qual é o fallback de `Themes.Default`, quando houver `Style`;
4. como `Size` altera densidade, tipografia, ícones, largura, altura ou padding;
5. quais tokens de `yasamen.css` sustentam o desenho.

Se `Style` ou `Size` não forem cabíveis, isso deve ser justificado explicitamente.

Para decidir **se** uma variante, estado ou slot deve virar contrato público, usar o guide 11.

---

## Enums Semânticos

### `Themes`

Usado para variantes visuais de cor.

```csharp
public enum Themes
{
    Default,
    Primary,
    Secondary,
    Tertiary,
    Info,
    Highlight,
    Success,
    Warning,
    Alert,
    Danger,
    Light,
    Dark
}
```

Regras:

- `Themes` representa papel semântico, não apelido arbitrário de cor;
- `Themes.Default` costuma mapear para o fallback real do componente;
- o fallback deve ser documentado;
- não adicionar `Style` por automatismo se o componente não precisa de variação temática pública.

### `Sizes`

Usado para variantes dimensionais.

```csharp
size.ToCssClassName()
size.ToCssClassName("ya-badge")
size.ToContentCssClass()
size.ToContentWidthCssClass()
```

Regras:

- `Sizes` é semântico e transversal;
- pode afetar padding, font-size, line-height, ícone, altura, largura mínima, largura máxima ou ritmo interno;
- `Sizes.Default` costuma representar o baseline do componente;
- o componente deve aplicar a escala de forma coerente, não arbitrária.

### Quando usar `Sizes`

Use `Sizes` quando a API pública realmente admitir densidade ou proporção variável, como em:

- botões;
- badges;
- feedbacks;
- componentes de navegação;
- componentes cuja área de clique ou legibilidade muda por tamanho.

Não use `Sizes` só porque o enum existe.

### Outros enums relevantes

| Enum | Uso típico |
|---|---|
| `Positions` | alinhamento, posição |
| `Directions` | direção de dropdown |
| `Fitting` | fitting do OffCanvas |
| `ButtonTypes` | tipo do botão HTML |
| `BorderSide` | lados de borda |
| `BorderRound` | arredondamento |

---

## Mapeamento de Enums para Classes

O padrão preferido é:

1. definir a classe base do componente;
2. mapear tema e tamanho para classes públicas previsíveis;
3. encapsular a tradução em helpers ou extension methods quando houver reuso.

Exemplos reais:

- `size.ToCssClassName("ya-btn")` para `ya-btn-sm`, `ya-btn-lg` etc.;
- `theme.ToButtonTheme(active, outline)` para variantes compostas de botão;
- `Size.ToCssClassName("ya-feedback")` para feedbacks;
- `Size.ToContentWidthCssClass()` e semelhantes para casos que realmente expõem largura ou altura semântica.

Regra:

- manter o mapeamento semântico e previsível;
- preferir helpers existentes;
- evitar duplicar manualmente contratos já consolidados em outro componente-base, quando houver reuso real.

---

## `CssClasses`

O padrão esperado para montar classes no componente é:

```csharp
private string Classes => "ya-badge"
    .AddClass(GetStyle())
    .AddClass(Size.ToCssClassName("ya-badge"))
    .AddClass(Block, "w-full")
    .AddClass(AdditionalClasses);
```

Regras:

- a classe base deve aparecer primeiro;
- `AdditionalClasses` entra por último;
- `AdditionalAttributes` é separado de `AdditionalClasses`;
- evitar interpolação manual de `class`.

---

## Builders de Estilo

### `BorderBuilder`

Exemplos:

```csharp
BorderBuilder.Default
BorderBuilder.Box
BorderBuilder.BoxRounded
BorderBuilder.BoxWithShadow
```

### `PaddingBuilder`

Exemplos:

```csharp
PaddingBuilder.None
Css.Padding.Size.Medium()
Css.Padding.Side.Top().Size.Small()
```

Esses builders ajudam a manter estilo declarativo e consistente.

---

## Escrevendo CSS com a Escala do Projeto

Ao escrever o CSS do componente:

- prefira utilitários e `@apply` coerentes com a escala de `yasamen.css`;
- use as cores semânticas do tema (`primary-*`, `success-*`, `danger-*` etc.);
- use espaçamento e tipografia da escala existente;
- use breakpoints do tema (`sm`, `md`, `lg` etc.) para responsividade;
- evite valores avulsos se o sistema já cobre o caso.

### Quando fugir da escala

Só introduza valor novo quando:

- o caso não existir na escala atual;
- o componente realmente pedir proporção nova;
- a escolha estiver documentada e fizer sentido além de um único caso local.

Se isso começar a acontecer com frequência, o problema pode estar nos tokens, não no componente.

---

## Inclusão dos Estilos na Aplicação

O projeto expõe `YasamenStyles`:

```razor
<YasamenStyles />
```

Uso esperado: incluir no `<head>` da aplicação.

Isso resolve o carregamento do CSS empacotado em dev e prod.

---

## Exemplo de CSS de Componente

```css
.ya-meucomponente {
    @apply relative flex items-center gap-2 rounded-md;
}

.ya-meucomponente-sm {
    @apply px-3 py-1 text-sm;
}

.ya-meucomponente-primary {
    @apply border border-primary-200 bg-primary-100 text-primary-800;
}

.ya-meucomponente-disabled {
    @apply pointer-events-none cursor-not-allowed opacity-50;
}
```

---

## Checklist

1. O CSS foi criado em `RoyalCode.Razor.Styles/wwwroot/`?
2. O `@import` foi registrado em `yasamen.css`?
3. O componente avaliou explicitamente `Style: Themes`?
4. O componente avaliou explicitamente `Size: Sizes`?
5. O `design.md` registrou fallback de tema e estratégia de escala, quando aplicável?
6. O componente usa `CssClasses` para montar `class`?
7. `AdditionalClasses` entra por último?
8. O CSS usa tokens e escalas já expostos em `yasamen.css`?
9. Foi evitado `*.razor.css` novo no pacote do componente?
10. Em migração de legado, foram revisados `::deep` e dependências de hierarquia?



