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
- Criar página de documentação `src/stories/components/<Nome>.mdx` por componente.
- Declarar `args` e `argTypes` funcionais para as props públicas.
- Mapear cada caso de uso (`UC<n>`) para ao menos uma história com `play` function.
- Criar história para cada tema, tamanho e estado relevante.
- Executar validação automática de acessibilidade (axe/addon-a11y) nas stories.
- Aplicar as regras de forma orientativa: a IA pode enriquecer com histórias adicionais conforme a complexidade do componente.

## JSDoc

Regras que a IA deve seguir estritamente:
- Documentar toda prop pública da interface `<Nome>Props` com JSDoc de uma linha.
- Documentar valor padrão com `@default`.
