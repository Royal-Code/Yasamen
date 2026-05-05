# Protocolo: Finalize

## Objetivo

Fechar a rodada do ui-map-gen: produzir o manifest de reprodutibilidade, validar e consolidar o inventário de fontes, verificar consistência final do state, e apresentar resumo de encerramento ao humano.

---

## INSTRUÇÕES DE EXECUÇÃO

[INSTRUÇÃO] Reler o kernel, workflow e este protocolo antes de iniciar.

[INSTRUÇÃO] Executar os passos na ordem.

### Passo 1: Validar state antes de fechar

[INSTRUÇÃO] Verificar que:
1. Todas as stages obrigatórias estão `done`.
2. Etapas opcionais estão `done` ou `skipped`.
3. Não há `blockers` não resolvidos.
4. Todos `open_gaps` têm status `resolved` ou `accepted`.
5. Se houver inconsistência: resolver com o humano antes de fechar.

### Passo 2: Consolidar `sources.inventory.md`

[INSTRUÇÃO] Verificar que `sources.inventory.md` existe. Se não existir: reconstruir antes de fechar.

[INSTRUÇÃO] Confirmar que o arquivo reflete:
- Biblioteca principal com nome, versão e referência.
- Bibliotecas auxiliares declaradas e seus status.
- Fontes corporativas e contextuais efetivamente usadas.

[INSTRUÇÃO] Completar campos pendentes com base no state e artefatos produzidos. Não inventar versões ou referências — manter `desconhecida` quando não souber.

### Passo 3: Produzir `manifest.md`

[INSTRUÇÃO] O manifest é o registro de reprodutibilidade mínima. Produzir com o seguinte conteúdo:

```md
---
manifest_version: 1
ui_map_id: {id do state}
generated_at: {data}
library:
  name: {nome}
  version: {versão ou desconhecida}
  source_ref: {commit|tag|path|URI|desconhecido}
auxiliary_libraries:
  - name: {nome}
    purpose: {papel}
    source_ref: {referência}
external_dependencies:
  - name: {lib externa}
    version: {versão ou desconhecida}
    used_by: {componente|pattern|sample|blueprint}
pattern_catalog:
  version: {versão dos catálogos usados}
compatibility_notes:
  - {observação relevante}
---

# UI Map Manifest — {nome da biblioteca}

## Resumo da rodada
- Componentes mapeados: {n}
- Patterns avaliados: {n}
- Samples gerados: {n}
- Blueprints gerados: {n}
- Guides corporativos: {n ou skipped}

## Artefatos produzidos
{lista de todos os arquivos gerados com path relativo}

## Gaps aceitos
{lista de gaps com status `accepted` — o que não foi resolvido e por quê}

## Sugestões para próximas ações
{recomendações: rodada de auxiliar, guides adicionais, patterns novos, etc.}
```

[INSTRUÇÃO] Para bibliotecas auxiliares: apenas auxiliares com status `done` no state entram no manifest. Registrar: nome, propósito, referência de origem, quais patterns/componentes justificaram inclusão.

[INSTRUÇÃO] Nunca inventar versão. Se não houver versão explícita, registrar `desconhecida`. Usar a referência mais precisa disponível (commit > tag > path > URI genérica).

### Passo 4: Atualizar state final

[INSTRUÇÃO] Marcar `current_stage: done` no state.

### Passo 5: Apresentar resumo final

[INSTRUÇÃO] Apresentar ao humano:
- Artefatos produzidos (lista completa).
- Gaps aceitos (não resolvidos).
- Bibliotecas auxiliares consumidas.
- Sugestões para próximas ações.
- Perguntar se há algo mais a ajustar antes de encerrar.

---

## GATE FINALIZE

- State válido: todas stages `done` ou `skipped`, sem blockers pendentes.
- `sources.inventory.md` consolidado e consistente.
- `manifest.md` produzido com todas as informações disponíveis.
- Nenhuma versão ou referência inventada.
- Resumo final apresentado ao humano.
- Aprovação explícita para encerrar.

### Checklist
- State final consistente.
- `sources.inventory.md` reflete a realidade da rodada.
- `manifest.md` tem todos os artefatos listados.
- Gaps aceitos estão documentados com justificativa.
- O humano foi informado do resultado completo.
