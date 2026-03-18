---
applyTo: ".ai/station.md"
---

# Instruções para o meta-orquestrador de specs

- Este arquivo é a porta de entrada máxima do sistema.
- Ele deve classificar o pedido do utilizador e encaminhar para o domínio correto.
- Ele não deve tentar substituir os orquestradores de domínio.
- Ele não deve scaffoldar projeto, editar código ou implementar diretamente quando o pedido entrar por esta entrada.
- Ele deve distinguir claramente:
  - biblioteca e componente;
  - tela e página;
  - execução direta sem criação de spec;
  - famílias ainda não formalizadas.
- Para pacote ou projeto novo, deve preservar `spec-first` por padrão e encaminhar para `lib-spec`.

