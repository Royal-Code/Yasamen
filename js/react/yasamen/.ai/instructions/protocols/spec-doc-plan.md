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

1. Listar os itens de `templates/doc.md`.
2. Descrever em cada item o que ele exibe e a condição de pronto.
3. Escrever `doc-{slug}.md` conforme `templates/doc.md`.
4. Apresentar ao humano os itens e as condições de pronto.

### GATE DP.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- todo item tem condição de pronto observável;
- o item de roadmap está listado.
