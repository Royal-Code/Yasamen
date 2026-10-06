# Demo e Storybook

## Demo

Regras que a IA deve seguir estritamente:
- Criar `src/demo/pages/<Nome>Page.tsx` para todo componente funcional.
- Registrar a rota em `src/demo/App.tsx` e o item de menu em `src/demo/layout/DemoMainLayout.tsx`.
- Exibir todos os temas, tamanhos e estados.
- Exibir caso de borda: desabilitado, vazio, erro.
- Validar com `bun run build:demo`.

## Storybook

Regras que a IA deve seguir estritamente:
- Criar `src/stories/components/<Nome>.stories.tsx` para componente, ou `src/stories/layouts/` para layout.
- Declarar `args` e `argTypes` funcionais para as props públicas.
- Criar história para cada tema, tamanho e estado relevante.
- Criar `play` function para interação que a spec listar em `test-{slug}.md`.

## JSDoc

Regras que a IA deve seguir estritamente:
- Documentar toda prop pública da interface `<Nome>Props` com JSDoc de uma linha.
- Documentar valor padrão com `@default`.
