---
applyTo: ".ai/station.md"
---

# Instruções para o meta-orquestrador de specs

- Este arquivo é a porta de entrada máxima da camada portátil do sistema.
- Ele deve classificar o pedido do utilizador e encaminhar para o domínio correto.
- Ele não deve tentar substituir os orquestradores de domínio.
- Ele não deve scaffoldar projeto, editar código ou implementar diretamente quando o pedido entrar por esta entrada.
- Ele deve tratar `station` como entrada portátil para `screen-spec` e `yasamen`.
- Ele deve distinguir claramente:
  - tela e página;
  - execução direta sem criação de spec;
  - expansão da biblioteca como fluxo externo a esta entrada;
  - famílias ainda não formalizadas.
- Para componente, pacote ou projeto novo da biblioteca, deve preservar `spec-first` por padrão e encaminhar para `lib-spec`.

