# Instrução Operacional - Criar ou Editar Tela com Yasamen

> Use este arquivo quando a tarefa for construir ou ajustar uma tela consumindo componentes Yasamen já existentes.

## Fontes obrigatórias

Antes de agir, ler:

- `.ai/guides/yasamen/using-yasamen-in-blazor.md`
- `.ai/ui-map/ui-map.md`, quando houver dúvida de cobertura
- `.ai/roadmap/components-plan-list.md`, quando surgir dependência de componente ausente

## Objetivo

Permitir execução direta de tela quando:

- o problema já estiver claro;
- os componentes necessários já existirem;
- não houver necessidade imediata de abrir `screen spec`.

## Fluxo

1. Confirmar o objetivo da tela e o contexto de uso.
2. Identificar quais componentes Yasamen já cobrem a necessidade.
3. Compor a tela com API pública da biblioteca.
4. Validar estados, responsividade e acessibilidade básicos.
5. Se surgir gap estrutural de tela, escalar para `screen-spec`.
6. Se surgir gap de componente, escalar para `lib-spec`.

## Regras

- Não criar componente novo da biblioteca dentro deste fluxo por reflexo.
- Não esconder gap de componente dentro de markup local excessivo.
- Se shell, navegação ou convenções do app ainda estiverem abertos, parar e usar `app-spec`.
- Se a tela for de demo ou documentação de um projeto consumidor, adotar convenção local do próprio projeto.
- Se a solução da tela estiver conceitualmente aberta, parar e usar `screen-spec`.

