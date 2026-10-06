# Protocolo: Revisão de spec

## Regras

Regras que a IA deve seguir estritamente:
- Revisar sem alterar os arquivos da spec.
- Verificar cada achado na spec ou no código antes de registrá-lo.
- Citar arquivo e seção em cada achado.
- Salvar em `.ai/specs/spec-{slug}/rev-spec-{slug}-{nn}.md` conforme `templates/rev.md`.
- Escolher `{nn}` como o próximo número de dois dígitos entre os arquivos `rev-spec-{slug}-*` da spec.
- Revisar `req`, `ds` e `dec` antes do gate de aprovação da spec. Revisar `tasks`, `test` e `doc` antes do gate de aprovação das tarefas.

## Arquivos a ler

- `templates/rev.md`: seguir o shape e as áreas de revisão de spec.
- Arquivos da spec no escopo: revisar.
- `.ai/rules/` e `kernel.rules.md`: aplicar como critério.
- Templates `req`, `ds`, `dec`, `tasks`, `test`, `doc`: conferir conformidade de shape.

## 1. Revisar

1. Receber o escopo: lista de arquivos da spec.
2. Percorrer as áreas de `templates/rev.md` para spec, na ordem.
3. Conferir conformidade com o shape do template de cada arquivo.
4. Conferir `CA<n>` sem `TC<n>` ou sem `T<n>`, `DC<n>` ausente para decisão material, e contradição entre arquivos.
5. Escrever os achados com severidade, local, impacto e recomendação.

### GATE RS.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- todas as áreas de spec foram percorridas;
- todo achado tem local, impacto e recomendação.

## 2. Encaminhar

Somente após gate `RS.1` satisfeito.

1. Encaminhar para `protocols/review-evaluation.md`.
2. Perguntar ao humano as correções que dependam de decisão. Registrar `Q<n>` em `dec-{slug}.md`.
