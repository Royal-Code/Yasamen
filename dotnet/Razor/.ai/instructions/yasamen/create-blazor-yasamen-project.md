# Instrução Operacional - Criar Projeto Blazor com Yasamen

> Use este arquivo quando a tarefa for criar um projeto front-end Blazor consumidor da biblioteca Yasamen.

## Fontes obrigatórias

Antes de agir, ler:

- `.ai/guides/yasamen/using-yasamen-in-blazor.md`
- `.ai/screen-spec.md`, quando o projeto já nascer acoplado a uma tela ainda não definida

## Objetivo

Criar um projeto consumidor que já nasça:

- com referências corretas aos pacotes Yasamen;
- com estilos públicos carregados;
- com `_Imports` coerente;
- com DI básica pronta;
- com estrutura limpa para telas e showcases.

## Fluxo

1. Criar o projeto Blazor alvo.
2. Adicionar referências ou pacotes Yasamen necessários.
3. Configurar `_Imports.razor` com namespaces públicos.
4. Configurar estilos da biblioteca.
5. Registrar serviços públicos necessários no `Program.cs`.
6. Criar a estrutura inicial de páginas, layout e navegação.
7. Validar build e inicialização.

## Regras

- Não tratar este fluxo como criação de pacote da biblioteca.
- Não usar `.ai/instructions/expand/create-library-project.md` para projeto consumidor.
- Se o projeto tiver demo, showcase ou docs próprias, definir convenção local do projeto consumidor em vez de depender do guide interno de showcase da biblioteca.
- Se a tela ainda não estiver definida, preferir `screen-spec` antes de implementar páginas complexas.
- Se o projeto revelar gaps na biblioteca, registrar e encaminhar para `lib-spec`.

