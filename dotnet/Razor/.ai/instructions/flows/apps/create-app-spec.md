# Instrução Operacional - Criar uma App Spec

> Use este arquivo como base em novos chats para que a IA crie uma `app spec` completa para um projeto consumidor que usa Yasamen.

## Fontes obrigatórias

Antes de escrever a `app spec`, a IA deve ler:

- `.ai/guides/yasamen/using-yasamen-in-blazor.md`
- `.ai/guides/yasamen/consumer-app-conventions.md`
- `.ai/guides/rules/cross-cutting-app-decisions.md`
- o template em `.ai/templates/apps/spec/`

## Saída esperada

Criar a `app spec` em:

`.ai/specs/apps/<nome-do-app>/`

Arquivos obrigatórios:

- `requirements.md`
- `design.md`
- `tasks.md`
- `delivery.md`

## Regras estruturais

- Toda `app spec` deve decidir explicitamente:
  - se o app é novo ou evolução de app existente;
  - qual é o tipo de host Blazor;
  - qual é o shell principal;
  - qual é a convenção de navegação e rota;
  - quais referências ou pacotes Yasamen são confirmados;
  - quais referências ou pacotes Yasamen são apenas candidatos;
  - quais serviços públicos serão usados;
  - qual é a estratégia inicial de dados, autenticação e integrações;
  - quais telas ou módulos prioritários existem;
  - quais telas precisam de `screen spec`;
  - quais gaps devem escalar para `lib-spec`.

## Modos de criação

### 1. Fundação do app

Usar este modo por padrão quando o utilizador pedir:

- criar um projeto novo;
- montar a base do app;
- iniciar um app consumidor;
- estruturar host, shell e referências.

Neste modo, a `app spec` deve fechar:

- nome e natureza do app;
- host Blazor;
- estrutura de projetos;
- shell base;
- convenção inicial de navegação;
- estratégia de consumo de Yasamen;
- `Program.cs`, `_Imports.razor`, estilos públicos e integração local.

E pode deixar explicitamente adiados:

- módulos detalhados;
- telas prioritárias;
- dados;
- autenticação;
- integrações externas.

Gate obrigatório antes de criar os arquivos:

- nome canônico do app e dos projetos;
- interpretação exata do host quando o pedido for ambíguo;
- arquétipo de shell.

### 2. Escopo funcional do app

Usar este modo quando o utilizador já trouxer ou pedir explicitamente:

- módulos de negócio;
- telas prioritárias;
- estratégia de dados;
- autenticação;
- integrações;
- backlog funcional mais rico.

- Se o app já existir:
  - registrar o `As-Is`;
  - registrar o `To-Be`;
  - destacar o delta principal.

## Regra de completude

Antes de criar a `app spec`, a IA deve verificar se já conhece informação suficiente para preencher pelo menos:

### Para `fundação do app`

- objetivo e contexto do app;
- host Blazor pretendido e sua interpretação exata quando o pedido usar termos ambíguos como `client/server`;
- natureza do app: novo ou evolução;
- nome canônico do app e dos projetos;
- shell ou hipótese inicial de shell confirmada como arquétipo;
- estratégia de consumo de Yasamen;
- integração local com solution ou repositório, quando aplicável.

### Para `escopo funcional do app`

- objetivo e contexto do app;
- host Blazor pretendido;
- natureza do app: novo ou evolução;
- shell ou hipótese inicial de shell;
- convenção inicial de navegação ou agrupamento;
- estratégia de consumo de Yasamen;
- estratégia inicial de dados, autenticação e integrações, ou decisão explícita de que isso ficará em aberto;
- telas ou módulos iniciais.

Se isso não estiver suficientemente claro:

- não inventar;
- não responder só com explicação do fluxo;
- pedir uma lista enumerada única do que precisa saber para abrir a spec com qualidade.

## Regras de qualidade

- Não copiar o template sem adaptação.
- Não misturar `app spec` com spec de componente.
- Não esconder gaps da biblioteca dentro de convenções locais do app.
- Se o pedido envolver criar projeto novo, a spec deve cobrir explicitamente:
  - estrutura de projetos;
  - integração à solution;
  - estratégia de referências;
  - configuração de `Program.cs`, `_Imports.razor` e estilos públicos;
  - passos de scaffolding e validação.
- Se o pedido envolver apenas criação da base do projeto, não bloquear a spec por falta de módulos, telas, dados ou integrações.
- Quando esses pontos ainda não existirem, registrá-los como `adiados para evolução posterior`.
- Se faltar nome canônico, interpretação exata do host ou arquétipo de shell, bloquear a criação da spec e pedir esses itens.
- Ao criar a spec, não marcar `tasks.md` como concluído por reflexo.
- Ao criar a spec, não marcar critérios de entrega do app como concluídos por reflexo.
- Ao criar a spec, se marcar algo como completo, deixar claro que se trata de completude da spec e não de implementação do app.
- Não transformar referências locais do repositório atual em justificativa de produto do app.
- Quando usar um projeto existente da solution como referência, nomear isso como `referência técnica local`.
- Não listar pacotes como confirmados apenas porque são comuns em demos ou showcases do repositório.
- Se a lista de módulos do utilizador já estiver em linguagem de negócio, não puxar a conversa para exemplos de componentes como `Buttons`, `Forms` ou equivalentes.
- O handoff para scaffolding base pode ser declarado pronto mesmo com dados, autenticação e integrações adiados.
- O handoff para telas funcionais não deve ser declarado pronto se esses pontos continuarem ambíguos.
- Se houver informação suficiente, criar os arquivos da `app spec` em vez de só orientar o utilizador a fazê-lo.
- Usar sempre acentuação.

## Etapa pós-criação

Depois de criar ou refinar a `app spec`:

- acionar o agente `spec-review` do Copilot para revisar a spec, quando o ambiente suportar subagentes;
- se o subagente não estiver disponível, fazer revisão equivalente localmente;
- incorporar os ajustes relevantes antes de encerrar a resposta.

## Fechamento da resposta

A resposta final da criação da `app spec` deve informar:

- onde a spec foi criada;
- se a revisão da spec encontrou ou não pontos relevantes;
- qual é o próximo passo recomendado no fluxo.

Opções típicas de próximo passo:

- `refine app-spec`, quando a revisão encontrar inconsistências;
- `yasamen`, quando a fundação já estiver pronta para scaffolding;
- `screen-spec`, quando o próximo passo natural for abrir as primeiras telas.
