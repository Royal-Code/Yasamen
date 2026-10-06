# Protocolo: Avaliação de revisão

## Regras

Regras que a IA deve seguir estritamente:
- Avaliar cada achado. Não aceitar achado sem verificação.
- Verificar a validade e a veracidade das afirmações no código ou na spec.
- Corrigir o achado válido. Aplicar a parte válida do achado parcial.
- Justificar com evidência a discordância do achado parcial ou inválido.
- Salvar em `.ai/specs/spec-{slug}/aval-{tipo}-{slug}-{nn}.md` conforme `templates/aval.md`.
- Usar o mesmo `{tipo}` e `{nn}` da revisão avaliada.
- Perguntar ao humano quando a correção alterar decisão confirmada (`DC<n>`).

## Arquivos a ler

- `rev-{tipo}-{slug}-{nn}.md`: obter os achados.
- `templates/aval.md`: seguir o shape.
- Arquivos citados nos achados: verificar.

## 1. Avaliar

Para cada achado `<N>.<N>`:
1. Ler o local citado e verificar a afirmação.
2. Classificar: `válido`, `parcial` ou `inválido`.
3. Escrever a verificação e, quando parcial ou inválido, a justificativa.

### GATE RE.1

Use as regras de GATE de `kernel.rules.md` para validar os itens, a cada achado:
- verificação escrita com local;
- classificação definida;
- justificativa escrita quando parcial ou inválido.

A iteração só termina com o gate `RE.1` satisfeito para todos os achados.

## 2. Corrigir

Somente após gate `RE.1` satisfeito.

1. Aplicar a correção de cada achado válido ou parcial.
2. Converter a correção grande em `T<n>` em `tasks-{slug}.md` e citar a tarefa.
3. Executar a validação aplicável (`bun run test`, `bun run build`, `bun run lint`, ou releitura da spec).
4. Registrar correção e verificação da correção em `aval-{tipo}-{slug}-{nn}.md`.
5. Preencher o `Resumo` do `aval-`.
6. Alterar o `Status` da revisão para `Avaliada`.

### GATE RE.FINAL

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- todo achado tem avaliação;
- todo achado válido tem correção registrada ou tarefa;
- `Resumo` confere com as avaliações.
