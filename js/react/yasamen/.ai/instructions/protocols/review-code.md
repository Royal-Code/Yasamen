# Protocolo: Revisão de código

## Regras

Regras que a IA deve seguir estritamente:
- Revisar sem alterar código.
- Verificar cada achado no código antes de registrá-lo.
- Citar arquivo e linha em cada achado.
- Salvar em `.ai/specs/spec-{slug}/rev-code-{slug}-{nn}.md` conforme `templates/rev.md`.
- Escolher `{nn}` como o próximo número de dois dígitos entre os arquivos `rev-code-{slug}-*` da spec.

## Arquivos a ler

- `templates/rev.md`: seguir o shape e as áreas de revisão de código.
- `req`, `ds`, `test`, `tasks` da spec: obter `CA<n>`, contrato, `TC<n>` e escopo.
- `.ai/rules/`: aplicar como critério.
- Arquivos alterados pelas tarefas do escopo: revisar.

## 1. Delimitar

1. Receber o escopo: tarefas `T<n>` ou a spec inteira.
2. Listar os arquivos alterados pelo escopo.

## 2. Revisar

1. Percorrer as áreas de `templates/rev.md` para código, na ordem.
2. Executar `bun run test`, `bun run build` e `bun run lint`. Registrar falhas como achado.
3. Reintroduzir um defeito em teste suspeito de ser inútil e confirmar que ele falha, quando a área `Testes` indicar dúvida.
4. Restaurar qualquer alteração temporária.
5. Escrever os achados com severidade, local, impacto e recomendação.

### GATE RC.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- todas as áreas de código foram percorridas;
- todo achado tem local, impacto e recomendação;
- nenhuma alteração temporária permaneceu no código.

## 3. Encaminhar

Somente após gate `RC.1` satisfeito.

1. Informar ao chamador o caminho do arquivo e a contagem de achados por severidade.
2. Encaminhar para `protocols/review-evaluation.md`.
