# Navigation Patterns

> Como modelar componentes de navegação e progressão na biblioteca com estado previsível, acessibilidade básica e contrato visual consistente.

---

## Visão Geral

Este guide cobre a família de navegação da biblioteca:

- `Breadcrumb`
- `Pagination`
- `Tabs`
- `Stepper`
- `Navigation Menu`

Nem todos esses componentes existem hoje, mas o repositório já oferece exemplos suficientes para extrair um padrão parcial, sobretudo com `Breadcrumb`, `Pagination` e `AppMenu`.

---

## O que um componente de navegação precisa resolver

Em geral, componentes dessa família precisam resolver uma combinação de:

- estado ativo ou item atual;
- navegação para destino anterior, próximo ou específico;
- semântica de localização do utilizador;
- resposta adequada em Mobile;
- acessibilidade básica com `aria-*` e foco;
- composição com `Button`, `IconButton`, `Badge` ou conteúdo declarativo.

---

## Regra principal

O estado de navegação deve ser explícito e previsível.

Sempre que possível, o componente deve deixar claro:

- qual é o item atual;
- como o estado muda;
- se o componente é controlado externamente;
- e quais eventos a mudança dispara.

---

## Modo controlado vs. estado interno

### Preferência

Para navegação reutilizável, preferir API controlada ou controlável.

Exemplos:

- `CurrentPage` + `OnPageChanged`
- `ActiveTab` + `OnTabChanged`
- `CurrentItem` + `OnCurrentItemChanged`

### Estado interno

É aceitável quando:

- houver modo simples de uso;
- o componente ainda expuser opção clara de controle externo;
- o estado interno não esconda decisões importantes do consumidor.

---

## Padrões por tipo

### 1. Navegação posicional

Casos:

- `Pagination`
- `Stepper`

Características:

- item atual numérico ou ordinal;
- anterior e próximo;
- extremos e bordas bem definidos;
- resumo simplificado em Mobile.

### 2. Navegação por seções

Casos:

- `Tabs`
- `Navigation Menu`

Características:

- item ativo;
- mudança explícita de contexto;
- possibilidade de badges;
- scroll horizontal ou colapso em Mobile, se necessário.

### 3. Navegação contextual

Casos:

- `Breadcrumb`

Características:

- mostra caminho atual;
- permite retorno a estados anteriores;
- normalmente não precisa estado interno complexo.

---

## Exemplos atuais do repositório

### `Breadcrumb`

É o melhor exemplo de navegação contextual.

### `Pagination`

É o melhor exemplo atual de navegação posicional com:

- estado atual explícito;
- janela numérica;
- modo Mobile;
- `aria-current`;
- teste dedicado.

### `AppMenu`

É o melhor exemplo de navegação por coleção hierárquica, embora ainda esteja mais ligado a layout de aplicação do que a um componente genérico de navegação.

---

## Regras de API pública

### Parâmetros

Preferir nomes diretos:

- `CurrentPage`
- `TotalPages`
- `ActiveTab`
- `Disabled`
- `Loading`
- `Items`

### Eventos

Eventos devem expressar intenção de navegação:

- `OnPageChanged`
- `OnTabChanged`
- `OnSelectedChanged`

O evento só deve disparar quando a mudança for válida.

### Bordas

Todo componente de navegação deve tratar:

- item atual inválido;
- extremidades;
- loading;
- item desabilitado;
- coleção vazia, quando aplicável.

---

## Regras de markup e semântica

Quando possível:

- usar `<nav>` para regiões de navegação;
- usar lista quando houver coleção de itens;
- marcar item atual com `aria-current` quando fizer sentido;
- rotular a região com `aria-label` ou equivalente.

Exemplos já visíveis no repositório:

- `Breadcrumb` com `<nav aria-label="breadcrumb">`
- `Pagination` com `<nav aria-label="Paginação">`

---

## Regras de responsividade

Componentes de navegação devem definir cedo como degradam em Mobile.

### `Pagination`

Bom padrão atual:

- Desktop: janela numérica e navegação completa;
- Mobile: anterior, resumo, próxima.

### `Tabs`

Recomendação:

- scroll horizontal antes de inventar quebra visual complexa.

### Menus

Recomendação:

- lidar explicitamente com colapso, hierarquia ou truncamento.

---

## Relação com outros componentes

Componentes de navegação podem compor com:

- `Button`
- `IconButton`
- `Badge`
- `BreadcrumbDescription`

Mas o componente de navegação não deve delegar toda a sua identidade ao componente base. Ele precisa manter markup, semântica e estados próprios.

---

## Regras de CSS

O contrato visual deve seguir o [css-visual-contract.md](css-visual-contract.md).

Espera-se:

- classe raiz `ya-*`;
- variantes públicas claras;
- estados públicos claros;
- CSS em `RoyalCode.Razor.Styles`.

Exemplos:

- `ya-pagination`
- `ya-pagination-link-active`
- futuro `ya-tabs`
- futuro `ya-stepper`

---

## Sinais de bom design

Um componente de navegação está bem modelado quando:

1. o item atual é óbvio;
2. a API externa deixa claro como navegar;
3. o comportamento de borda é previsível;
4. o modo Mobile é explícito;
5. a semântica HTML e ARIA está presente;
6. o CSS público é pequeno e estável.

---

## Anti-padrões

Evitar:

1. esconder o estado atual dentro de lógica interna opaca;
2. disparar evento para destino inválido;
3. usar só grade visual sem semântica de navegação;
4. depender exclusivamente de cor para indicar item ativo;
5. não definir comportamento em Mobile;
6. construir o componente inteiro só com composição solta de `Button` sem semântica própria.

---

## Checklist

- [ ] O estado atual está explícito?
- [ ] O componente pode ser controlado externamente?
- [ ] Eventos só disparam para mudanças válidas?
- [ ] O comportamento em bordas está definido?
- [ ] O comportamento em Mobile está definido?
- [ ] A semântica de navegação e `aria-*` está adequada?
- [ ] O contrato visual segue `ya-*` e `RoyalCode.Razor.Styles`?



