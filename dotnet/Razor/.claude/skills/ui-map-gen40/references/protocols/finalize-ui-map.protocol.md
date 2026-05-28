# Protocolo de Finalização do UI-Map

## Regras gerais

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

## Arquivos a ler

[INSTRUÇÃO] Não ler nenhum arquivo antes de ser pedido nas seções abaixo.

- `state.yaml`
- `manifest.template.md`

## 1. Setup

[INSTRUÇÃO] Ler `state.yaml` e `manifest.template.md`.

1. Ler `state.yaml`:
- confirmar que todas as etapas anteriores estão concluídas: `project-summary`, `visual-language`, `ui-map`, `create-samples`, `patterns-blueprints`, `corporate-rules`, `patterns-orientations`.

2. Verificar retomada:
- se `manifest.md` já existir, ler antes de continuar;
- preservar conteúdo existente apenas quando ainda estiver coerente com este protocolo.

### GATE FIM.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- etapa autorizada pelo workflow;
- `state.yaml` lido e etapas anteriores confirmadas;
- retomada verificada quando aplicável.

## 2. Coleta de dados

[INSTRUÇÃO] Somente após gate `FIM.1` satisfeito.

1. Coletar metadados do `state.yaml`:
- `library.name`, `library.version`, `library.source_ref`, `library.platforms`, `library.technical_family`;
- `auxiliary_libraries`;
- versão do catálogo de patterns se disponível, caso contrário registrar `desconhecida`.

2. Contar artefatos gerados:
- **Componentes mapeados**: contar componentes listados em `components.summary.md`;
- **Patterns avaliados**: contar linhas de pattern em `patterns.table.md`;
- **Samples gerados**: contar arquivos `*.sample.md` em `samples/`;
- **Blueprints gerados**: contar arquivos `*.blueprint.md` em `patterns-blueprints/`;
- **Rules corporativas**: contar arquivos `*.rules.md` em `rules/`;
- **Orientações de patterns**: contar seções `### {tipo de tela}` em `patterns.orientations.md`.

3. Listar artefatos de release:
- percorrer diretório de trabalho e subdiretórios;
- artefatos de **release** (consumíveis por IA em skills consumidoras):
  - `visual.language.md`;
  - `visual.map.md`;
  - `ui-map/patterns.table.md`;
  - `ui-map/*.ui-map.md`;
  - `samples/*.sample.md`;
  - `patterns-blueprints/blueprints.table.md`;
  - `patterns-blueprints/*.blueprint.md` — somente os existentes;
  - `rules/corporate.rules.md`;
  - `rules/*.rules.md` — demais arquivos de rules;
  - `patterns.orientations.md`.
- artefatos **auxiliares** (não entram na tabela de release):
  - `state.yaml`;
  - `components.summary.md`;
  - `structure.md`;
  - `ui-guide.md`;
  - `visual.language.evidence.md`;
  - arquivos em `analysis/`.

### GATE FIM.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- metadados coletados do `state.yaml`;
- todos os contadores levantados;
- artefatos de release separados dos auxiliares.

## 3. Escrita do manifest

[INSTRUÇÃO] Somente após gate `FIM.2` satisfeito.

1. Criar ou substituir `manifest.md` usando `manifest.template.md`.

2. Preencher bloco de metadados YAML:
- usar dados coletados na seção 2;
- `generated_at`: data atual no formato `YYYY-MM-DD`;
- `manifest_version: 4`.

3. Preencher `Resumo da rodada` com os contadores levantados.

4. Preencher tabela `Artefatos — release`:
- uma linha por artefato ou conjunto (usar `*` para conjuntos, como `ui-map/*.ui-map.md`);
- coluna `Artefato`: tipo ou nome descritivo do artefato;
- coluna `Local`: caminho relativo ao diretório de trabalho;
- coluna `Utilidade`: frase curta descrevendo o que contém e para que serve à IA consumidora;
- incluir somente artefatos de release presentes no diretório de trabalho;
- não incluir o próprio `manifest.md` na tabela.

### GATE FIM.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `manifest.md` criado e persistido;
- metadados YAML preenchidos a partir de `state.yaml`;
- contadores preenchidos;
- tabela de artefatos de release preenchida com artefatos existentes;
- nenhum artefato auxiliar incluído na tabela.

## 4. Encerramento

[INSTRUÇÃO] Somente após gate `FIM.3` satisfeito.

1. Atualizar `state.yaml`:
- etapa `finalize` concluída;
- task de ui-map marcada como finalizada;
- `next_action`: `none`.

2. Apresentar resumo ao humano:
- totais do Resumo da rodada;
- lista de artefatos de release gerados;
- etapas que não foram executadas ou artefatos ausentes, se houver.

### GATE FIM.FINAL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todas as seções executadas em ordem: 1, 2, 3, 4;
- gates `FIM.1`, `FIM.2`, `FIM.3` satisfeitos;
- `manifest.md` criado e persistido;
- `state.yaml` atualizado com processo de ui-map finalizado;
- resumo apresentado ao humano.
