# Instrução Operacional - Instalar Pacotes Yasamen

> Use este arquivo quando a tarefa for instalar ou ajustar o uso da biblioteca Yasamen em um projeto consumidor.

## Fontes obrigatórias

Antes de agir, ler:

- `.ai/guides/yasamen/using-yasamen-in-blazor.md`
- `.ai/guides/expand/showcases-and-docs.md`, se houver showcase ou docs
- `.ai/guides/expand/styles-and-css.md`, quando a tarefa envolver estilos

## Objetivo

Garantir que o projeto consumidor:

- referencie os pacotes corretos;
- use apenas API pública;
- carregue o CSS público da biblioteca;
- registre serviços públicos necessários;
- não copie detalhes internos da biblioteca.

## Fluxo

1. Identificar quais famílias de componentes serão usadas.
2. Adicionar os pacotes Yasamen mínimos necessários.
3. Ajustar `_Imports.razor` com namespaces públicos.
4. Garantir carga de `yasamen.css` ou equivalente público.
5. Registrar extensões públicas de DI, quando houver.
6. Validar build e conflitos de namespace.

## Regras

- Não usar namespaces internos da biblioteca.
- Não instalar pacotes por analogia sem necessidade real.
- Não duplicar estilos da biblioteca no projeto consumidor.
- Se faltar componente ou pacote, registrar gap e encaminhar para `lib-spec`.

