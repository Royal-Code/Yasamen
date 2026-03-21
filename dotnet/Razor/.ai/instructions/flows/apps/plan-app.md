# Instrução Operacional - Planejar um App com Yasamen

> Use este arquivo como base em novos chats para que a IA planeje um app consumidor por gates antes de abrir telas ou partir para scaffolding.

## Fontes obrigatórias

Antes de iniciar o planeamento, a IA deve ler:

- `.ai/guides/yasamen/using-yasamen-in-blazor.md`
- `.ai/guides/yasamen/consumer-app-conventions.md`
- `.ai/guides/rules/cross-cutting-app-decisions.md`
- `.ai/templates/apps/spec/requirements.md`
- `.ai/templates/apps/spec/design.md`
- `.ai/templates/apps/spec/tasks.md`
- `.ai/templates/apps/spec/delivery.md`

## Gates obrigatórios

1. objetivo, contexto e tipo do app;
2. shell, layout e navegação;
3. pacotes, serviços e estilos públicos;
4. telas, módulos e dependências de `screen spec`;
5. convenções locais de docs, demo ou showcase;
6. fechamento da `app spec`.

## Regras

- Trabalhar em gates.
- Em cada gate, apresentar proposta curta, decisões e pontos em aberto.
- Se faltar informação para avançar no gate atual, pedir uma lista enumerada única do que precisa ser conhecido.
- Se o app já existir, começar pelo quadro `As-Is` antes de propor o `To-Be`.
- Não detalhar componente dentro da `app spec`.
- Se a solução estiver madura, a `app spec` pode encaminhar depois para `yasamen` ou `screen-spec`.
- Não transformar o fluxo em uma pergunta por vez.
- Derivar o máximo possível a partir do pedido e dos guides, mas não inventar.
- Se já houver informação suficiente para abrir a `app spec`, preferir escalar para `create-app-spec`.
- Não narrar o meta-processo em excesso; mostrar apenas o necessário para o utilizador acompanhar o avanço.
- Quando fizer perguntas, preferir linguagem neutra e de domínio do utilizador.
- Não sugerir exemplos de módulos por famílias de componentes da biblioteca quando o pedido já estiver num domínio de negócio.
- Quando o pedido for apenas de fundação do projeto, não exigir detalhamento funcional para abrir a spec.
- Antes de abrir a `app spec` de fundação, fechar obrigatoriamente:
  - nome canônico do app e dos projetos;
  - interpretação exata do host, quando houver ambiguidade;
  - arquétipo de shell.
- Sem esse gate, o fluxo deve parar na lista enumerada do que falta.
- Fechar explicitamente a estratégia inicial de dados, autenticação e integrações apenas quando o utilizador já estiver a descrever o escopo funcional do app ou pedir esse nível de definição.
- Usar sempre acentuação.
