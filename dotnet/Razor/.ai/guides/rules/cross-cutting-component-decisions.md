# Cross-Cutting Component Decisions

> Checklist normativo curto para garantir que toda spec e todo componente novo fechem as mesmas decisões estruturais, visuais, composicionais e de entrega.

---

## Objetivo

Este guide existe para reduzir drift entre:

- guides;
- instructions;
- templates de spec;
- agentes.

Ele não substitui os guides especializados. Ele apenas consolida as decisões que não podem ficar implícitas quando um componente novo entra no fluxo.

---

## Quando usar

Use este guide em qualquer destes casos:

1. criação de spec nova;
2. refinamento de spec;
3. implementação de spec;
4. revisão crítica de entrega de componente;
5. pedido de componente novo ao orquestrador.

---

## Fontes complementares

Este guide depende dos seguintes guides:

- `project-structure.md`
- `styles-and-css.md`
- `component-anatomy.md`
- `showcases-and-docs.md`
- `spec-execution-and-delivery.md`
- `component-composition-and-dependencies.md`

Se o componente for de navegação, formulário ou service/outlet, combinar também com o guide especializado da família.

---

## Decisão 1 - Backlog e contexto do roadmap

Antes de abrir ou implementar uma spec, é obrigatório consultar:

- `.ai/ui-map/ui-map.md`
- `.ai/roadmap/ui-plan.md`
- `.ai/roadmap/components-plan-list.md`

Objetivo:

- saber se o componente já está mapeado;
- saber a prioridade e a fase;
- detectar se ele é primitivo, derivado, dependência natural ou item fora do plano.

Se o componente não aparecer nesses documentos:

- registrar a ausência;
- justificar por que o trabalho segue assim mesmo.

---

## Decisão 2 - Pacote alvo e estrutura

Toda spec deve decidir explicitamente:

1. o pacote alvo já existe; ou
2. o componente exige pacote novo.

Se exigir pacote novo:

- registrar isso no `design.md`;
- indicar o pacote alvo;
- indicar que a implementação deverá seguir `.ai/instructions/expand/create-library-project.md`.

Não é aceitável deixar a criação de pacote como palpite da implementação.

---

## Decisão 3 - Anatomia e API pública

Toda spec deve explicitar:

- componentes públicos;
- subcomponentes públicos, se houver;
- parâmetros obrigatórios;
- parâmetros opcionais;
- `AdditionalClasses`;
- `AdditionalAttributes`;
- slots;
- eventos;
- comportamento para ausência ou combinação inválida de parâmetros.

Essa decisão deve refletir `component-anatomy.md`.

---

## Decisão 4 - Variação visual com `Style: Themes`

Todo componente novo deve avaliar explicitamente se suporta `Style: Themes`.

Se suportar:

- indicar quais temas entram no primeiro release;
- registrar o fallback de `Themes.Default`;
- explicar como o tema afeta CSS público e showcase.

Se não suportar:

- justificar explicitamente por que `Style` não é cabível.

---

## Decisão 5 - Variação dimensional com `Size: Sizes`

Todo componente novo deve avaliar explicitamente se suporta `Size: Sizes`.

Se suportar:

- indicar quais tamanhos entram no primeiro release;
- explicar impacto em densidade, tipografia, ícones, espaçamento e showcase.

Se não suportar:

- justificar explicitamente por que `Size` não é cabível.

Essa decisão deve refletir `component-composition-and-dependencies.md`.

---

## Decisão 6 - Tokens e CSS público

Toda spec deve explicitar:

- quais tokens de `RoyalCode.Razor.Styles/wwwroot/yasamen.css` sustentam cor, espaçamento, tipografia e responsividade;
- qual arquivo CSS público em `RoyalCode.Razor.Styles/wwwroot/css/...` será criado ou atualizado;
- quais classes `ya-*` farão parte do contrato público;
- que `*.razor.css` novo não será criado sem exceção justificada.

Essa decisão deve refletir `styles-and-css.md` e `css-visual-contract.md`.

---

## Decisão 7 - Composição, reuso e pré-requisitos

Toda spec deve decidir explicitamente:

1. o componente é primitivo base ou composto;
2. quais componentes existentes serão reutilizados;
3. se existe um componente-base ausente que deveria vir antes.

Se existir dependência natural de um componente-base ausente:

- abrir a spec do componente-base primeiro;
- ou registrar esse componente-base como pré-requisito;
- ou justificar por que o alvo seguirá sem essa abstração no primeiro release.

Essa decisão deve refletir `component-composition-and-dependencies.md`.

---

## Decisão 8 - Showcase e documentação

Toda spec com UI deve decidir:

- rota inicial em `RoyalCode.Razor.Docs.Client`;
- página em `Pages/Demo/...`;
- grupo/item de menu em `ConfigureMenu.cs`;
- cenários mínimos de showcase.

Essa decisão deve refletir `showcases-and-docs.md`.

---

## Decisão 9 - Evidência de entrega

Toda implementação de spec deve fechar:

- build;
- testes;
- validação manual relevante;
- `delivery.md`;
- `tasks.md`;
- atualização de `ui-map.md` e `ui-plan.md`, quando a cobertura ou o roadmap mudarem.

Se houver UI ou showcase:

- tentar validação visual com Playwright MCP;
- se o MCP não estiver disponível, registrar isso com clareza.

Essa decisão deve refletir `spec-execution-and-delivery.md`.

---

## O que cada artefato deve conter

### `requirements.md`

- problema;
- escopo;
- pacote sugerido;
- avaliação de `Style`;
- avaliação de `Size`;
- backlog e contexto;
- critérios de aceite.

### `design.md`

- decisão estrutural de pacote;
- anatomia pública;
- composição e reuso;
- CSS e tokens;
- showcase;
- validação esperada.

### `tasks.md`

- checklist executável para estrutura, implementação, estilos, testes, showcase e encerramento.

### `delivery.md`

- changelog;
- rastreabilidade;
- validação executada;
- review;
- status final e pendências.

---

## Sinais de que a spec está fraca

Há um gap claro quando:

1. `Style` ou `Size` ficaram implícitos;
2. o pacote alvo não foi decidido;
3. tokens de `yasamen.css` não foram citados;
4. o componente parece depender de outro mais básico e isso não foi discutido;
5. o showcase não foi planejado;
6. a entrega não define como será validada.

---

## Checklist

- [ ] `ui-map.md`, `ui-plan.md` e `components-plan-list.md` foram consultados?
- [ ] O pacote alvo foi classificado como existente ou novo?
- [ ] A API pública foi descrita?
- [ ] A decisão sobre `Style: Themes` foi tomada?
- [ ] O fallback de `Themes.Default` foi registrado quando necessário?
- [ ] A decisão sobre `Size: Sizes` foi tomada?
- [ ] Os tokens de `yasamen.css` foram identificados?
- [ ] O CSS público e as classes `ya-*` foram definidos?
- [ ] A decisão sobre composição e pré-requisitos foi registrada?
- [ ] O showcase foi planejado?
- [ ] A evidência final de entrega foi definida?



