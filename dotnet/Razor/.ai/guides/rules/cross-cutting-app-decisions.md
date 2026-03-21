# Decisões Transversais de App

> Checklist curto para qualquer `app spec` de projeto consumidor que usa Yasamen.

## Objetivo

Este guide existe para fechar decisões de app antes de partir para telas, projeto novo ou implementação direta.

Ele não substitui:

- `using-yasamen-in-blazor.md`
- `consumer-app-conventions.md`
- `screen-spec`

Ele apenas consolida os checkpoints mínimos que uma `app spec` não pode deixar implícitos.

## Níveis de detalhe

Uma `app spec` pode nascer em dois níveis:

- `Fundação do app`:
  - suficiente para criar o projeto, configurar host, shell base, referências, estilos e bootstrapping;
  - é o padrão quando o utilizador pede apenas um projeto novo ou a base estrutural do app.
- `Escopo funcional do app`:
  - entra quando o utilizador também quer fechar módulos, telas, dados, autenticação e integrações.

Regra:

- não forçar uma `app spec` de escopo funcional quando o pedido real for apenas criar a fundação do projeto;
- quando o detalhe funcional ainda não existir, registrar isso como `adiado para telas, screen specs ou evolução futura`.

## Gate mínimo da fundação do app

Antes de materializar uma `app spec` no nível `fundação do app`, é obrigatório conhecer:

- nome canônico do app e dos projetos, ou convenção explícita de nome;
- interpretação exata do host quando o pedido for ambíguo, por exemplo `client/server` em Blazor;
- arquétipo de shell esperado, por exemplo administrativo, portal, catálogo, workspace operacional ou equivalente.

Regra:

- sem esse gate, a IA pode planejar e explicar opções, mas não deve criar a `app spec`;
- esses três pontos exigem confirmação do utilizador, não só inferência.

## Entradas mínimas

Antes de fechar uma `app spec`, garantir leitura de:

- `.ai/guides/yasamen/using-yasamen-in-blazor.md`
- `.ai/guides/yasamen/consumer-app-conventions.md`

Se o app já tiver backlog, roadmap ou inventário de telas:

- consultar também esse material;
- neste repositório, telas e gaps podem ser aprofundados depois com `screen-spec`.

## Checkpoints obrigatórios

### 1. Contexto do app

- objetivo do app;
- utilizadores principais;
- natureza do sistema;
- tipo do host Blazor;
- se é app nova ou evolução de app existente.

### 2. Estrutura do app

- shell principal;
- layout base;
- navegação global;
- convenção de rota;
- módulos, áreas ou grupos principais.

### 3. Consumo de Yasamen

- referências ou pacotes base confirmados;
- referências ou pacotes candidatos, quando ainda dependerem das telas;
- estilos públicos carregados;
- serviços públicos necessários;
- limites claros entre consumo e expansão.

### 4. Dados, autenticação e integrações

- estratégia inicial de dados da primeira entrega;
- uso de mocks, estado local, API real ou backend ainda não definido;
- política inicial de autenticação e autorização;
- integrações externas relevantes ao escopo do app.

Regra:

- quando o app já tiver escopo funcional definido, não deixar implícito como a primeira entrega lida com dados e autenticação;
- quando o pedido for apenas de fundação do projeto, esse bloco pode ficar explicitamente `adiado`, sem bloquear a spec.

### 5. Relação com telas

- lista inicial de telas ou áreas;
- telas prioritárias;
- dependências de `screen spec`, quando houver;
- lacunas que ainda precisam de planeamento de tela.

Regra:

- se o utilizador ainda não tiver descrito módulos ou telas, a `app spec` pode registrar esse bloco como `derivação futura`, sem inventar backlog funcional.

### 6. Convenções locais do projeto

- docs, demo ou showcase;
- menu e agrupamento;
- estratégia de layout;
- política de override visual local.

## Critérios de qualidade

- Usar sempre acentuação.
- Não transformar `app spec` em detalhamento de componente.
- Não esconder gaps de biblioteca como decisão local de app.
- Não abrir várias `screen specs` sem antes fechar convenções que são globais do app.
- Não tratar referência local do repositório atual como justificativa de produto do app.
- Se um projeto local existente for citado, tratá-lo apenas como referência técnica de implementação.
- Distinguir claramente `spec completa` de `app implementado`.

## Checklist rápido

- [ ] O contexto do app está claro?
- [ ] Shell, layout e navegação estão claros?
- [ ] O consumo de Yasamen foi definido?
- [ ] A estratégia inicial de dados, autenticação e integrações foi definida ou explicitamente adiada?
- [ ] As telas prioritárias foram identificadas ou explicitamente adiadas?
- [ ] Convenções locais do projeto foram registradas?
- [ ] Está claro quando o próximo passo é `screen-spec`, `yasamen` ou `lib-spec`?
