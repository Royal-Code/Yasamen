# Screen Planning and UI Mapping

> Método adaptado para planejar telas a partir de requisitos funcionais, escolher `Page Pattern`, compor zonas com `UIP-*` do catálogo e mapear a solução para a biblioteca Yasamen.

---

## Objetivo

Este guide adapta a lógica das etapas equivalentes a `D007` e `D008` para o contexto deste repositório, sem importar o protocolo original por inteiro.

Ele existe para responder a esta cadeia:

1. qual é o contexto estrutural da tela;
2. qual `Page Pattern` melhor representa a página;
3. quais zonas funcionais a tela precisa;
4. quais `UIP-*` do catálogo entram em cada zona;
5. como isso mapeia para Yasamen;
6. quais gaps de componente impedem a implementação.

---

## O que este guide faz

- planeja tela nova;
- ajuda a alterar tela existente;
- organiza a conversa por gates;
- usa `catalogo-ui.md` como base agnóstica;
- usa `ui-map.md` como adapter tecnológico;
- gera uma `screen spec` pronta para handoff técnico.

---

## O que este guide não faz

- não redefine o catálogo de `UIP-*`;
- não cria `UIP` local;
- não substitui a spec de componente;
- não obriga o uso de jornadas e capacidades nesta primeira versão;
- não decide implementação de detalhe de componente além do necessário para o mapeamento.

Jornadas e capacidades podem entrar como entrada opcional, mas não devem bloquear o fluxo.

---

## Fontes obrigatórias

Para qualquer planeamento de tela, ler:

- `.ai/ui-map/catalogo-ui.md`
- `.ai/ui-map/ui-map.md`
- `.ai/guides/rules/cross-cutting-screen-decisions.md`

Se o projeto tiver backlog, roadmap ou mapa local de gaps, ler também.

Neste repositório, as referências padrão são:

- `.ai/roadmap/components-plan-list.md`
- `.ai/roadmap/ui-plan.md`

Se a tela for virar demonstração, protótipo navegável ou artefato em `Docs.Client`, combinar também com:

- `.ai/guides/expand/showcases-and-docs.md`

---

## Cadeia de planeamento

A cadeia obrigatória é:

`Shell -> Screen -> Page Pattern -> Zona -> UIP -> Mapeamento Yasamen -> Gaps de componente`

Se qualquer elo ficar implícito, a screen spec fica fraca.

---

## Etapa 1 - Contexto estrutural da tela

Antes de escolher qualquer `Page Pattern`, é preciso fechar:

- nome da tela;
- objetivo principal;
- utilizador ou papel dominante;
- ação principal;
- se a tela é nova ou uma alteração de tela existente;
- se já existe shell conhecido no sistema;
- rota, módulo ou contexto de navegação, quando já existir.

Se a tela já existir:

- primeiro capturar o estado atual;
- depois declarar a mudança desejada.

---

## Etapa 2 - Shell de referência

O shell pode vir de três formas:

1. já existe no sistema e deve ser reaproveitado;
2. é inferido a partir do tipo de aplicação;
3. ainda está indefinido e precisa ser declarado como hipótese.

Regra:

- não reinventar shell se o sistema já tiver um;
- registrar o grau de confiança da escolha;
- usar shell apenas como contexto estrutural da tela, não como desculpa para desenhar a página de forma vaga.

---

## Etapa 3 - Escolha de `Page Pattern`

O `Page Pattern` é o modelo estrutural da página.

Catálogo mínimo de `Page Pattern` desta adaptação:

- `PP-LIST-DETAIL`
- `PP-CATALOG`
- `PP-FORM`
- `PP-WIZARD`
- `PP-DASHBOARD`
- `PP-DETAIL`
- `PP-LANDING`
- `PP-CONVERSATION`
- `PP-FEED`
- `PP-SETTINGS`

Regra:

- a tela deve ter exatamente um `Page Pattern` principal;
- variações internas podem existir, mas não substituem a decisão principal;
- se houver ambiguidade real, registrar duas opções e a decisão tomada.

---

## Etapa 4 - Zonas funcionais

Depois do `Page Pattern`, a tela deve ser dividida em zonas funcionais.

Base inicial por `Page Pattern`:

- `PP-LIST-DETAIL` -> `Header`, `Filter`, `List`, `Detail-Panel`, `Actions`
- `PP-CATALOG` -> `Header`, `Search`, `Filter-Bar`, `Grid`, `Pagination`
- `PP-FORM` -> `Header`, `Form-Body`, `Validation`, `Actions`
- `PP-WIZARD` -> `Header`, `Step-Indicator`, `Step-Body`, `Navigation`
- `PP-DASHBOARD` -> `Header`, `KPI-Row`, `Chart-Area`, `Table-Area`
- `PP-DETAIL` -> `Header`, `Content-Body`, `Sidebar`, `Actions`
- `PP-LANDING` -> `Hero`, `Features`, `CTA`, `Footer`
- `PP-CONVERSATION` -> `Header`, `Thread-List`, `Message-Area`, `Input`
- `PP-FEED` -> `Header`, `Feed-List`, `Actions`
- `PP-SETTINGS` -> `Header`, `Nav-Sidebar`, `Form-Area`, `Actions`

Regra:

- essas zonas são ponto de partida, não camisa de força;
- qualquer adição, remoção ou renomeação deve ser justificada pela tela.

---

## Etapa 5 - Seleção de `UIP-*` por zona

Para cada zona funcional:

1. escolher `UIP-*` do catálogo;
2. verificar compatibilidade com o `Page Pattern`;
3. justificar a escolha;
4. registrar estados relevantes da zona.

Regras obrigatórias:

- não criar `UIP` local;
- se a compatibilidade for secundária, justificar;
- se houver incompatibilidade explícita no catálogo, não usar;
- se nenhum `UIP-*` oficial atender, registrar gap estrutural da tela.

---

## Etapa 6 - Mapeamento para Yasamen

Depois da composição agnóstica da tela, mapear cada `UIP-*` para a biblioteca com apoio de `ui-map.md`.

Toda zona e todo `UIP-*` devem cair em uma destas classes:

1. `Existente`
2. `Composição com existentes`
3. `Gap de componente`
4. `Gap estrutural da tela`

### 1. Existente

Há componente dedicado ou cobertura alta na biblioteca.

### 2. Composição com existentes

A tela é viável, mas exige combinar componentes e containers já disponíveis.

### 3. Gap de componente

Falta um componente ou padrão reutilizável da biblioteca.

Nesse caso, a screen spec deve:

- apontar o gap;
- identificar se já existe spec de componente;
- ou registrar a necessidade de abrir spec filha.

### 4. Gap estrutural da tela

O problema não está em um componente isolado, mas na ausência de infraestrutura, shell, layout ou comportamento de página.

---

## Etapa 7 - Dependências de componente

Tela não deve esconder dependências.

Se a implementação da tela exigir componentes ausentes:

- listar os componentes necessários;
- indicar quais já têm spec;
- indicar quais ainda precisam de spec;
- decidir se a tela pode seguir em paralelo ou fica bloqueada.

Regra:

- uma screen spec pode depender de várias component specs;
- a screen spec não substitui essas specs filhas.

---

## Etapa 8 - Tela existente versus tela nova

Para alteração de tela existente, a screen spec deve conter dois quadros:

1. `As-Is`
2. `To-Be`

### As-Is

- shell atual, se houver;
- `Page Pattern` atual, mesmo que implícito;
- zonas atuais;
- `UIP-*` observáveis;
- principais problemas.

### To-Be

- nova proposta da tela;
- mudanças por zona;
- impacto em componentes;
- impacto em navegação, estados e responsividade.

Regra:

- não propor a mudança sem antes fixar o estado atual.

---

## Artefatos esperados

A saída deve ser uma `screen spec` em:

`.ai/specs/screens/<nome-da-tela>/`

Arquivos:

- `requirements.md`
- `design.md`
- `tasks.md`
- `delivery.md`

---

## Relação com specs de componente

Uma `screen spec` responde:

- o que a tela precisa;
- como a tela se organiza;
- quais `UIP-*` entram;
- como isso mapeia para Yasamen;
- quais specs de componente são pré-requisito.

Uma spec de componente responde:

- como construir um componente específico da biblioteca.

Regra:

- screen spec e component spec são complementares, não concorrentes.

---

## Jornadas e capacidades

Nesta primeira versão:

- jornadas e capacidades são entrada opcional;
- se existirem, podem reforçar contexto e prioridade;
- se não existirem, o fluxo de tela não deve parar.

Recomendação:

- tratar jornadas e capacidades como camada acima, em uma evolução posterior do sistema.

---

## Checklist

- [ ] A tela foi classificada como nova ou alteração de existente?
- [ ] O shell de referência foi definido ou herdado?
- [ ] O `Page Pattern` principal foi escolhido?
- [ ] As zonas funcionais foram definidas?
- [ ] Cada zona recebeu `UIP-*` do catálogo com justificativa?
- [ ] A cadeia `Shell -> Screen -> Page Pattern -> Zona -> UIP` foi fechada?
- [ ] O mapeamento para Yasamen foi classificado como `Existente`, `Composição`, `Gap de componente` ou `Gap estrutural`?
- [ ] As dependências de component spec foram listadas?
- [ ] A screen spec ficou pronta para handoff técnico?




