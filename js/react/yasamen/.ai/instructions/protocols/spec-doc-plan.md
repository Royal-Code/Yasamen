# Protocolo: Plano de documentação

## Regras

Regras que a IA deve seguir estritamente:
- Planejar demo, Storybook, JSDoc e roadmap para todo componente.
- Planejar atualização de `.ai/rules/` somente quando a spec criar convenção nova.
- Seguir `.ai/rules/demo-and-stories.md`.

## Arquivos a ler

- `ds-{slug}.md`: obter props, temas, tamanhos e estados.
- `.ai/rules/demo-and-stories.md`: aplicar regras de demo e Storybook.
- `templates/doc.md`: seguir o shape.

## 1. Planejar

1. Mapear a tabela de rastreabilidade `UC` ↔ Story ↔ `CA` ↔ `TC` de `templates/doc.md`.
2. Listar os itens de documentação (demo, Storybook, MDX, JSDoc e roadmap).
3. Descrever em cada item o que ele exibe e a condição de pronto.
4. Escrever `doc-{slug}.md` conforme `templates/doc.md`.
5. Apresentar ao humano os itens e as condições de pronto.

### GATE DP.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- todo item tem condição de pronto observável;
- a matriz UC ↔ Story ↔ CA ↔ TC está preenchida;
- o item de roadmap está listado.
