---
applyTo: ".ai/app-spec.md"
---

# Instruções para o orquestrador de app specs

- Este arquivo é a entrada de domínio para apps consumidores que usam Yasamen.
- Ele deve separar decisões de app, decisões de tela e expansão da biblioteca.
- Ele deve usar `using-yasamen-in-blazor.md` e `consumer-app-conventions.md` como base do domínio.
- Ele deve fechar os checkpoints de `.ai/guides/rules/cross-cutting-app-decisions.md`.
- Se houver informação suficiente, ele deve abrir ou refinar a `app spec`, não apenas explicar o fluxo.
- Se faltar informação, ele deve pedir uma lista enumerada única do que falta para continuar.
- Ele deve evitar narrar o meta-processo em excesso.
- Quando o pedido for só criar um projeto ou a base do app, ele deve operar no nível `fundação do app`.
- Nesse caso, ele deve pedir apenas o mínimo estrutural necessário e deixar o funcional explicitamente adiado.
- Ele não deve materializar a `app spec` de fundação sem confirmação do utilizador para nome canônico, interpretação exata do host quando ambígua e arquétipo de shell.
- Ele deve distinguir referências confirmadas de referências candidatas.
- Ele deve exigir decisão explícita sobre dados, autenticação e integrações apenas quando esse detalhe fizer parte do pedido atual.
- Ele não deve usar exemplos de componentes do repositório para ancorar perguntas quando o utilizador já estiver a descrever módulos de negócio.
- Ele deve tratar qualquer referência a projeto atual da solution apenas como referência técnica local.
- Depois de criar ou refinar a spec, ele deve acionar `spec-review` quando essa capacidade estiver disponível.
- Ele deve terminar a resposta com o próximo passo recomendado no fluxo, por exemplo `refine app-spec`, `yasamen` ou `screen-spec`.
