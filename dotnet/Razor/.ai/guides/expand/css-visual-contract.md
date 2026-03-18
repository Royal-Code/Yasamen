# Contrato Visual Público

> Como decidir o que vira API visual estável da biblioteca, sem confundir contrato público com detalhe interno de markup.

---

## Papel Deste Guide

Este guide complementa o [styles-and-css.md](styles-and-css.md).

O guide 02 trata da mecânica:

- tokens;
- `yasamen.css`;
- `Themes` e `Sizes`;
- mapeamento para classes;
- localização do CSS.

Este guide trata da fronteira semântica:

- o que vira contrato visual público;
- o que deve permanecer interno;
- como escolher classes raiz, variantes, estados e slots públicos.

---

## O que é Contrato Visual

Contrato visual é tudo aquilo que um consumidor pode depender legitimamente ao usar um componente.

Exemplos de contrato visual:

- classe raiz pública do componente;
- variantes públicas como tema e tamanho;
- estados visuais reconhecíveis como `active`, `disabled`, `loading`;
- slots ou regiões estáveis;
- atributos ARIA quando fizerem parte do comportamento público.

Não é contrato visual:

- profundidade da árvore DOM;
- ordem exata de wrappers internos;
- classes utilitárias locais;
- detalhes de alinhamento temporário;
- seletores acoplados a `::deep` ou à hierarquia interna.

---

## Regra Principal

Se uma decisão visual precisa ser:

- documentada;
- testada;
- mostrada em showcase;
- ou reutilizada de fora;

ela deve virar contrato público.

Se a decisão existe só para viabilizar o markup interno, ela deve continuar interna.

Regra prática:

- contrato público deve aparecer como classes estáveis da biblioteca;
- detalhe interno não deve exigir conhecimento do DOM interno pelo consumidor;
- a mecânica para materializar esse contrato continua no guide 02.

---

## Anatomia Mínima do Contrato

Quando fizer sentido, o contrato público de um componente tende a assumir esta forma:

```text
ya-{componente}
ya-{componente}-{variante}
ya-{componente}-{estado}
ya-{componente}-{slot}
```

Exemplos reais:

- `ya-btn`
- `ya-btn-primary`
- `ya-badge`
- `ya-feedback-danger`
- `ya-modal`
- `ya-offcanvas`
- `ya-pagination`
- `ya-pagination-link-active`

---

## O que Vale a Pena Expor

### 1. Classe raiz

Todo componente visual deve ter uma classe raiz pública estável.

Exemplos:

- `ya-pagination`
- `ya-modal`
- `ya-offcanvas`

### 2. Variantes públicas

Tema, tamanho, direção ou outra variante devem ser expostos quando fizerem parte da API pública.

Exemplos:

- `ya-btn-primary`
- `ya-btn-sm`
- `ya-feedback-warning`

### 3. Estados públicos

Estados que o consumidor reconhece e que afetam a experiência devem ter representação clara.

Exemplos:

- `ya-pagination-loading`
- `ya-pagination-link-disabled`
- `ya-modal-open`

### 4. Slots públicos

Quando o componente tem regiões estáveis e reaproveitáveis, elas podem virar contrato público.

Exemplos:

- `ya-pagination-list`
- `ya-pagination-item`
- `ya-pagination-mobile-summary`

---

## O que Não Deve Virar Contrato

Evitar expor:

- wrappers apenas estruturais;
- classes dependentes da ordem dos filhos;
- nomes genéricos como `content`, `inner`, `wrapper`, `box`, sem prefixo do componente;
- classes nascidas de um experimento local;
- detalhes temporários usados só para fechar layout.

Se a classe não sobreviveria a uma refatoração normal do markup, ela não é um bom contrato público.

---

## Relação com `*.razor.css`

Contrato público não deve nascer em `*.razor.css` de pacotes da biblioteca.

Motivo:

- CSS isolation tende a capturar detalhe local;
- isso mistura API pública com markup interno;
- também dificulta consolidar a linguagem visual compartilhada.

Quando houver legado em `*.razor.css`, a regra é:

1. identificar o que é contrato estável;
2. migrar esse contrato para `RoyalCode.Razor.Styles`;
3. deixar no componente apenas o que for estritamente interno.

Os detalhes mecânicos dessa migração continuam no guide 02.

---

## Relação com Parâmetros, Enums e Helpers

Quando uma variante pública existir, o ideal é fechar este circuito:

```text
parâmetro público
  -> mapeamento semântico
  -> classe pública estável
  -> CSS em `RoyalCode.Razor.Styles`
```

Exemplos:

- `Style: Themes` -> `GetStyle()` -> `ya-feedback-success`
- `Size: Sizes` -> `Size.ToCssClassName("ya-btn")` -> `ya-btn-lg`

Este guide decide **que** a variante é pública. O guide 02 decide **como** materializá-la.

---

## Critérios para Promover Algo a Contrato Público

Faça estas perguntas:

1. O consumidor reconhece essa região, variante ou estado como parte do componente?
2. Isso provavelmente continuará existindo após refatoração interna?
3. O showcase ou os testes deveriam depender disso?
4. Isso ajuda a compor a API sem expor Tailwind diretamente?
5. Isso aparece em mais de um cenário de uso real?

Se a maioria for "sim", provavelmente é contrato público.

---

## Aplicação em Componentes do Repositório

### `Button`

Bom exemplo de contrato orientado por variantes públicas:

- raiz estável;
- tema público;
- tamanho público;
- estados reconhecíveis.

### `Pagination`

Bom exemplo de contrato enxuto com slots públicos bem delimitados:

- `ya-pagination`
- `ya-pagination-list`
- `ya-pagination-item`
- `ya-pagination-link`
- `ya-pagination-link-active`
- `ya-pagination-link-disabled`
- `ya-pagination-mobile-summary`
- `ya-pagination-loading`

### `Modal` e `OffCanvas`

Bons exemplos de componente que precisa de classe raiz estável e poucos slots públicos, sem transformar toda a árvore interna em contrato.

---

## Anti-padrões

Evitar:

1. criar contrato visual baseado em utilitários Tailwind soltos;
2. depender de seletor por profundidade do DOM;
3. expor nomes genéricos sem prefixo do componente;
4. fazer o consumidor depender de classe interna não documentada;
5. adicionar classe pública só para resolver um caso local de showcase.

---

## Checklist

- [ ] O componente tem classe raiz pública estável?
- [ ] Variantes públicas realmente necessárias foram expostas?
- [ ] Estados públicos relevantes têm representação clara?
- [ ] Slots expostos são poucos e realmente estáveis?
- [ ] Nenhum detalhe interno frágil foi promovido a contrato público?
- [ ] A decisão sobre contrato público está coerente com o guide 02?




