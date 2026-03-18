---
applyTo: ".ai/station.md"
---

# Instruções para o meta-orquestrador de specs

- Este arquivo é a porta de entrada máxima da camada portátil do sistema.
- Ele deve classificar o pedido do utilizador e encaminhar para o domínio correto.
- Ele não deve tentar substituir os orquestradores de domínio.
- Ele não deve scaffoldar projeto, editar código ou implementar diretamente quando o pedido entrar por esta entrada.
- Ele deve tratar `station` como entrada portátil para `app-spec`, `screen-spec` e `yasamen`.
- O roteamento pode ser silencioso; o comportamento padrão deve ser seguir o fluxo escolhido.
- Ele deve distinguir claramente:
  - tela e página;
  - execução direta sem criação de spec;
  - expansão da biblioteca como fluxo externo a esta entrada;
  - famílias ainda não formalizadas.
- Para componente, pacote ou projeto novo da biblioteca, deve preservar `spec-first` por padrão e encaminhar para `lib-spec`.
- Quando houver informação suficiente, deve avançar na etapa correta do flow em vez de só explicá-lo.
- Quando faltar informação, deve pedir uma lista enumerada única do que precisa saber para executar a próxima etapa.

