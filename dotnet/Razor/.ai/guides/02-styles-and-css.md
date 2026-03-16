# Guide 02 - Sistema de Estilos e CSS

> Como a biblioteca define o contrato visual dos componentes, onde o CSS deve morar e como tratar o legado de `*.razor.css`.

---

## Visao Geral

`RoyalCode.Razor.Styles` concentra o contrato visual compartilhado da biblioteca. Ele contem:

1. enums semanticos como `Themes`, `Sizes`, `Positions`;
2. extension methods que convertem enums em classes CSS;
3. builders como `CssClasses`, `BorderBuilder` e `PaddingBuilder`;
4. utilitarios estaticos `Css.*`;
5. o componente `YasamenStyles`, que inclui os estilos na aplicacao.

O CSS publico da biblioteca deve viver em `RoyalCode.Razor.Styles/wwwroot/`.

---

## Politica Atual de CSS

### Regra canonica

Para componentes da biblioteca:

- a API visual publica deve ser expressa em classes `ya-*`;
- o CSS dessas classes deve ficar centralizado em `RoyalCode.Razor.Styles/wwwroot/`;
- `*.razor.css` em projetos de componentes nao sao o padrao desejado.

### Excecoes existentes

Hoje existem `*.razor.css` em alguns pacotes, como:

- `RoyalCode.Razor.Animations`
- `RoyalCode.Razor.Drops`
- `RoyalCode.Razor.OffCanvas`

Esses casos devem ser tratados como legado ou divida tecnica, nao como referencia para novos componentes.

### Regra para novos componentes

Nao introduzir novos `*.razor.css` em pacotes da biblioteca sem justificativa arquitetural explicita.

Se surgir uma excecao real, ela deve ser:

- pequena;
- local;
- documentada;
- dificil de transformar em classe `ya-*` sem regressao.

### Caminho de correcao para o legado

Antes de migrar um `*.razor.css` existente para `RoyalCode.Razor.Styles`, revisar caso a caso:

- seletores com `::deep`;
- dependencia de hierarquia DOM;
- acoplamento ao markup interno do componente;
- risco de transformar detalhe local em contrato CSS publico.

O objetivo da migracao e mover para `Styles` tudo que for contrato visual estavel e deixar o minimo possivel como detalhe estritamente interno.

---

## Enums Semanticos

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

Uso esperado: o componente transforma o enum em classes como `ya-btn-primary`, `ya-feedback-danger`, `ya-badge-info`.

### `Sizes`

Usado para variantes de tamanho.

```csharp
size.ToCssClassName()
size.ToCssClassName("ya-badge")
```

### Outros enums relevantes

| Enum | Uso tipico |
|---|---|
| `Positions` | alinhamento, posicao |
| `Directions` | direcao de dropdown |
| `Fitting` | fitting do OffCanvas |
| `ButtonTypes` | tipo do botao HTML |
| `BorderSide` | lados de borda |
| `BorderRound` | arredondamento |

---

## `CssClasses`

O padrao esperado para montar classes no componente e:

```csharp
private string Classes => "ya-badge"
    .AddClass(GetStyle())
    .AddClass(Size.ToCssClassName("ya-badge"))
    .AddClass(Block, "w-full")
    .AddClass(AdditionalClasses);
```

### Regras

- a classe base deve aparecer primeiro;
- `AdditionalClasses` deve entrar por ultimo;
- `AdditionalAttributes` e separado de `AdditionalClasses`;
- evitar interpolacao manual de strings para `class`.

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

Esses builders ajudam a manter estilo declarativo e consistente na API dos componentes.

---

## Convencao de Classes `ya-*`

Todas as classes publicas do design system usam prefixo `ya-`.

Formato esperado:

```text
ya-{componente}
ya-{componente}-{tema}
ya-{componente}-{tamanho}
ya-{componente}-{modificador}
```

Exemplos:

- `ya-btn`
- `ya-btn-primary`
- `ya-badge`
- `ya-feedback-danger`
- `ya-field-group`
- `ya-input-field-invalid`
- `ya-offcanvas`
- `ya-modal`

**Regra:** nao expor classes Tailwind como contrato de componente publico. O contrato publico da biblioteca e `ya-*`.

---

## Inclusao dos Estilos na Aplicacao

O projeto expõe `YasamenStyles`:

```razor
<YasamenStyles />
```

Uso esperado: incluir no `<head>` da aplicacao.

Isso resolve automaticamente o carregamento do CSS empacotado em dev e prod.

---

## Onde Criar CSS de Novo Componente

Os arquivos ficam em `RoyalCode.Razor.Styles/wwwroot/`, tipicamente em:

| Tipo | Pasta |
|---|---|
| Componentes visuais | `wwwroot/css/components/` |
| Formularios | `wwwroot/css/forms/` |
| Utilitarios globais | `wwwroot/css/` |

O ponto de entrada e `wwwroot/yasamen.css`.

Exemplo:

```css
@import './css/components/btn.css';
@import './css/components/badge.css';
@import './css/forms/fieldgroup.css';
```

### Passos

1. Criar o arquivo CSS em `RoyalCode.Razor.Styles/wwwroot/css/...`
2. Registrar o `@import` em `wwwroot/yasamen.css`
3. Definir as classes `ya-*` do contrato publico
4. Mapear enums para classes via extension methods quando necessario
5. Montar `Classes` no componente com `CssClasses`

---

## Exemplo de CSS de Componente

```css
.ya-meucomponente {
    @apply relative flex items-center gap-2 rounded-md;
}

.ya-meucomponente-sm {
    @apply text-sm px-3 py-1;
}

.ya-meucomponente-primary {
    @apply bg-primary-100 text-primary-800 border border-primary-200;
}

.ya-meucomponente-disabled {
    @apply opacity-50 cursor-not-allowed pointer-events-none;
}
```

---

## Checklist

1. O CSS foi criado em `RoyalCode.Razor.Styles/wwwroot/`?
2. O contrato publico usa classes `ya-*`?
3. O componente usa `CssClasses` para montar `class`?
4. `AdditionalClasses` entra por ultimo?
5. Foi evitado `*.razor.css` no pacote do componente?
6. Em migracao de legado, foram revisados `::deep` e dependencias de hierarquia?
