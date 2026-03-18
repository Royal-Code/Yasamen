# Plano de ReestruturaÃ§Ã£o de Guides, Instructions e Agents

> Plano de trabalho para reduzir atrito entre guides, instruÃ§Ãµes operacionais e agentes, e para integrar corretamente a criaÃ§Ã£o de novos projetos ao fluxo orientado por spec.

---

## Request

Hoje o sistema estÃ¡ funcional, mas jÃ¡ apresenta alguns sinais de atrito estrutural:

1. o fluxo de criaÃ§Ã£o de componente novo ainda nÃ£o fecha completamente a relaÃ§Ã£o entre:
   - `components-plan-list.md`;
   - `ui-plan.md`;
   - criaÃ§Ã£o de spec;
   - criaÃ§Ã£o de projeto novo, quando necessÃ¡rio;
   - implementaÃ§Ã£o guiada por instruÃ§Ã£o;
2. alguns guides se sobrepÃµem mais do que deveriam;
3. algumas regras transversais foram replicadas em vÃ¡rias instruÃ§Ãµes e agentes;
4. o orquestrador ainda nÃ£o Ã© verdadeiramente o ponto Ãºnico de entrada para todos os fluxos relevantes.

O objetivo deste plano Ã© corrigir esses pontos sem desmontar a base jÃ¡ construÃ­da.

---

## Requisitos

### RQ-01 - Componente novo deve seguir fluxo orientado por spec

Quando o utilizador pedir um componente novo ao orquestrador, a IA deve saber que:

1. o caminho preferencial comeÃ§a por spec;
2. o componente pode jÃ¡ estar mapeado em `components-plan-list.md`;
3. o componente pode jÃ¡ estar priorizado ou contextualizado em `ui-plan.md`;
4. a necessidade de criar um projeto novo deve aparecer no `design.md`, quando aplicÃ¡vel;
5. na implementaÃ§Ã£o, a IA deve seguir as instruÃ§Ãµes corretas para criaÃ§Ã£o do projeto e nÃ£o â€œinventarâ€ o fluxo.

### RQ-02 - `create-library-project` deve ser subordinado ao fluxo de spec quando o pedido for de componente

`create-library-project.md` faz sentido como instruÃ§Ã£o operacional prÃ³pria, mas, para componente novo, ele deve funcionar como subfluxo tÃ©cnico de implementaÃ§Ã£o ou de design, nÃ£o como caminho paralelo desconectado da spec.

### RQ-03 - Guides devem ter fronteiras mais nÃ­tidas

Os guides precisam continuar complementares, mas com menos repetiÃ§Ã£o factual. A divisÃ£o entre â€œcomo Ã© hojeâ€, â€œcomo decidirâ€ e â€œcomo executarâ€ deve ficar mais clara.

### RQ-04 - Instructions devem ser operacionais, nÃ£o repositÃ³rios paralelos de regra

As instruÃ§Ãµes devem:

- apontar para guides;
- fechar sequÃªncia de execuÃ§Ã£o;
- evitar duplicar blocos normativos longos.

### RQ-05 - Agents devem herdar o sistema, nÃ£o criar outro sistema

Os agentes devem:

- depender do mesmo desenho conceitual dos guides e instructions;
- evitar regras exclusivas que nÃ£o existam no nÃºcleo do sistema;
- refletir o orquestrador, e nÃ£o competir com ele.

---

## Design

## Ponto 1 - Integrar criaÃ§Ã£o de projeto ao fluxo de spec

### Problema

Hoje existe uma boa instruÃ§Ã£o para criaÃ§Ã£o de projeto novo, mas ela ainda estÃ¡ solta em relaÃ§Ã£o ao orquestrador e ao ciclo completo de spec.

Isso Ã© aceitÃ¡vel quando o pedido Ã© claramente â€œcrie um novo projetoâ€. Mas, quando o pedido Ã© â€œcrie um novo componenteâ€, o comportamento desejado Ã© outro:

- primeiro entender o componente como item de backlog;
- depois planejar/criar/refinar a spec;
- registrar no design se serÃ¡ necessÃ¡rio um pacote novo;
- e sÃ³ na implementaÃ§Ã£o criar o projeto, seguindo a instruÃ§Ã£o correta.

Se isso nÃ£o estiver amarrado, a IA pode:

- criar projeto cedo demais;
- pular a anÃ¡lise de `components-plan-list.md` e `ui-plan.md`;
- ou tratar criaÃ§Ã£o de pacote como decisÃ£o improvisada em vez de decisÃ£o de design.

### DecisÃ£o proposta

Manter `create-library-project.md`, mas reposicionÃ¡-lo assim:

1. fluxo direto para pedidos explÃ­citos de pacote novo;
2. subfluxo chamado por specs quando o `design.md` determinar um novo projeto;
3. referÃªncia explÃ­cita dentro do orquestrador, das instruÃ§Ãµes de spec e dos agentes.

### Efeito esperado

Quando o utilizador pedir um componente novo:

1. o orquestrador consulta `components-plan-list.md` e `ui-plan.md`;
2. escolhe ou cria o fluxo de spec;
3. o `design.md` decide se o pacote jÃ¡ existe ou se precisa nascer;
4. a implementaÃ§Ã£o chama o fluxo de criaÃ§Ã£o de projeto, se necessÃ¡rio;
5. a criaÃ§Ã£o do projeto deixa de ser decisÃ£o implÃ­cita.

### Arquivos afetados

- `.ai/spec.md`
- `.ai/instructions/create-spec.md`
- `.ai/instructions/refine-spec.md`
- `.ai/instructions/implement-spec.md`
- `.ai/instructions/create-library-project.md`
- `.github/agents/spec-orchestrator.agent.md`
- `.github/agents/spec-author.agent.md`
- `.github/agents/spec-implementer.agent.md`
- possivelmente `.github/instructions/spec-orchestrator.instructions.md`

---

## Ponto 2 - Clarificar fronteira entre Guide 02 e Guide 11

### Problema

`styles-and-css.md` e `css-visual-contract.md` estÃ£o corretos, mas ainda cobrem territÃ³rio semelhante demais:

- `ya-*`;
- contrato pÃºblico;
- Tailwind nÃ£o como API pÃºblica;
- relaÃ§Ã£o com `*.razor.css`;
- raiz pÃºblica, variantes e estados.

Isso nÃ£o quebra o sistema hoje, mas aumenta custo de manutenÃ§Ã£o e risco de divergÃªncia futura.

### DecisÃ£o proposta

Separar os papÃ©is desta forma:

- `Guide 02`: mecÃ¢nica de estilos
  - `yasamen.css`
  - tokens
  - `Themes`
  - `Sizes`
  - `CssClasses`
  - localizaÃ§Ã£o do CSS
  - regras de uso de escala
- `Guide 11`: contrato visual pÃºblico
  - o que vira API visual;
  - o que nÃ£o vira;
  - classes raiz, estados e slots;
  - critÃ©rios para promover algo a contrato pÃºblico.

### Efeito esperado

Quem cria CSS saberÃ¡:

- onde o estilo mora e com quais tokens trabalhar;
- e, separadamente, o que pode ser exposto como contrato estÃ¡vel.

### Arquivos afetados

- `.ai/guides/expand/styles-and-css.md`
- `.ai/guides/expand/css-visual-contract.md`
- `.ai/guides/README.md`
- instruÃ§Ãµes e templates apenas se alguma referÃªncia ficar inconsistente

---

## Ponto 3 - Clarificar fronteira entre Guide 08 e Guide 12

### Problema

`service-pattern.md` e `outlet-patterns.md` tambÃ©m estÃ£o bem direcionados, mas repetem bastante:

- `Notification`, `Modal`, `OffCanvas`;
- padrÃµes A e B;
- outlets no layout;
- surface pÃºblica;
- checklist semelhante.

Hoje ainda Ã© possÃ­vel entender, mas o par pode se tornar redundante demais.

### DecisÃ£o proposta

Separar os papÃ©is assim:

- `Guide 08`: documentaÃ§Ã£o factual do estado real do repositÃ³rio
  - como `Notification`, `Modal` e `OffCanvas` funcionam hoje;
  - exemplos reais;
  - contratos concretos;
  - requisitos reais de layout;
- `Guide 12`: heurÃ­stica de decisÃ£o
  - quando usar A, B ou C;
  - matriz de decisÃ£o;
  - sinais de erro;
  - regras arquiteturais curtas.

### Efeito esperado

O guide 12 deixa de ser quase uma segunda explicaÃ§Ã£o do 08 e passa a ser realmente o layer de decisÃ£o.

### Arquivos afetados

- `.ai/guides/expand/service-pattern.md`
- `.ai/guides/expand/outlet-patterns.md`
- `.ai/guides/README.md`

---

## Ponto 4 - Reduzir repetiÃ§Ã£o de regras transversais

### Problema

Regras como estas aparecem em muitos lugares:

- decidir `Style: Themes`;
- decidir `Size: Sizes`;
- registrar `Themes.Default`;
- usar tokens de `yasamen.css`;
- fechar `delivery.md`;
- verificar Playwright MCP;
- atualizar `ui-map.md` e `ui-plan.md`.

A repetiÃ§Ã£o ajuda no curto prazo, mas pode criar drift entre:

- guides;
- instructions;
- templates;
- agents;
- Copilot instructions.

### DecisÃ£o proposta

Ter uma fonte primÃ¡ria curta para regras transversais e reduzir duplicaÃ§Ã£o textual nas camadas operacionais.

OpÃ§Ã£o preferida:

- deixar os guides como fonte normativa;
- deixar instructions como sequÃªncia de execuÃ§Ã£o;
- deixar agents como adaptadores mÃ­nimos.

Na prÃ¡tica, as instruÃ§Ãµes e agentes continuariam citando essas regras, mas de forma mais curta e remissiva.

### Efeito esperado

- menos texto para sincronizar;
- menos chance de um agente divergir do guide;
- menos manutenÃ§Ã£o duplicada.

### Arquivos afetados

- `.ai/instructions/create-spec.md`
- `.ai/instructions/plan-spec.md`
- `.ai/instructions/refine-spec.md`
- `.ai/instructions/implement-spec.md`
- `.ai/specs/_template/*.md`
- `.github/copilot-instructions.md`
- `.github/agents/spec-author.agent.md`
- `.github/agents/spec-planner.agent.md`
- `.github/agents/spec-implementer.agent.md`

---

## Ponto 5 - Fechar a navegaÃ§Ã£o entre guides, instructions e agents

### Problema

Hoje hÃ¡ trÃªs Ã­ndices mentais:

1. guides por domÃ­nio;
2. instructions por fluxo;
3. agents por papel.

Tudo isso Ã© Ãºtil, mas ainda exige que o utilizador ou a IA â€œadivinhemâ€ a camada certa em alguns momentos.

### DecisÃ£o proposta

Adicionar uma camada de navegaÃ§Ã£o explÃ­cita, curta e prÃ¡tica:

- tarefa -> instruction principal;
- instruction -> guides obrigatÃ³rios;
- instruction -> agents mais indicados;
- pedido de componente novo -> fluxo orientado por spec;
- pedido de pacote novo -> fluxo direto de projeto.

Isso pode viver em:

- `.ai/spec.md`
- `.ai/instructions/README.md`
- possivelmente um pequeno quadro em `.ai/guides/README.md`

### Efeito esperado

- menos ambiguidade de entrada;
- menos prompts â€œquase certosâ€;
- agentes mais previsÃ­veis.

### Arquivos afetados

- `.ai/spec.md`
- `.ai/instructions/README.md`
- `.ai/guides/README.md`
- `.github/agents/spec-orchestrator.agent.md`
- `.github/instructions/spec-orchestrator.instructions.md`

---

## Tasks

## Fase 1 - Fluxo de componente novo e criaÃ§Ã£o de projeto

- [x] Atualizar `.ai/spec.md` para tratar componente novo como fluxo orientado por spec.
- [x] Registrar explicitamente no orquestrador que criaÃ§Ã£o de projeto pode nascer do `design.md`.
- [x] Atualizar `create-spec.md` para exigir decisÃ£o explÃ­cita sobre pacote existente versus pacote novo.
- [x] Atualizar `implement-spec.md` para chamar `create-library-project.md` quando a spec exigir novo projeto.
- [x] Ajustar `create-library-project.md` para se declarar subfluxo tÃ©cnico quando usado por uma spec.
- [x] Atualizar `spec-orchestrator.agent.md` para refletir esse comportamento.
- [x] Atualizar `spec-author.agent.md` e `spec-implementer.agent.md` para manter coerÃªncia.

## Fase 2 - Limpeza da camada de guides

- [x] Reestruturar `styles-and-css.md` e `css-visual-contract.md` para reduzir sobreposiÃ§Ã£o.
- [x] Reestruturar `service-pattern.md` e `outlet-patterns.md` para reduzir repetiÃ§Ã£o factual.
- [x] Revisar `README.md` dos guides para refletir as novas fronteiras.

## Fase 3 - Limpeza da camada operacional

- [x] Reduzir duplicaÃ§Ã£o entre `create-spec.md`, `plan-spec.md`, `refine-spec.md` e `implement-spec.md`.
- [x] Validar o que deve ficar nos templates versus nas instruÃ§Ãµes.
- [x] Revisar `copilot-instructions.md` para garantir que ele referencia as regras centrais sem replicar demais.

## Fase 4 - Fechamento com agents

- [x] Revisar todos os agentes de spec contra o fluxo final.
- [x] Verificar se algum agente mantÃ©m regra que jÃ¡ nÃ£o existe no nÃºcleo do sistema.
- [x] Garantir que o `spec-orchestrator` Ã© coerente com `.ai/spec.md`.
- [x] Garantir que agentes especializados continuam complementares, e nÃ£o paralelos ao sistema principal.

## Fase 5 - ValidaÃ§Ã£o final

- [x] Revisar consistÃªncia entre guides, instructions, templates e agents.
- [x] Fazer uma passada final de linguagem e acentuaÃ§Ã£o.
- [x] Confirmar que exemplos de uso curtos continuam corretos.
- [x] Registrar quais fluxos passam a ser oficialmente preferenciais.

---

## CritÃ©rios de ConclusÃ£o

- [x] Pedido de componente novo ao orquestrador passa a seguir claramente o fluxo de spec.
- [x] Necessidade de projeto novo fica explÃ­cita no design e executÃ¡vel na implementaÃ§Ã£o.
- [x] `create-library-project.md` fica corretamente integrado ao sistema, sem competir com ele.
- [x] Pairs `02/11` e `08/12` ficam com fronteiras mais nÃ­tidas.
- [x] Instructions ficam mais operacionais e menos redundantes.
- [x] Agents ficam coerentes com guides e instructions.
- [x] O sistema fica mais previsÃ­vel para humano e para IA em chat novo.

---

## Ordem Recomendada

1. Fase 1
2. Fase 2
3. Fase 3
4. Fase 4
5. Fase 5

Motivo:

- o maior risco hoje estÃ¡ no fluxo de entrada de componente novo;
- depois disso, vale reduzir sobreposiÃ§Ã£o documental;
- por fim, alinhar a camada de agentes ao nÃºcleo revisado.

