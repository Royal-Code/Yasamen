# PROTOCOLO OPERACIONAL D007 - PAGE-PATTERNS

documento: "protocolo operacional page-patterns"
versão: 5.0.0

## DESCRIÇÃO

[INSTRUÇÃO] D007 mapeia módulos e fluxos para páginas concretas e atribui page patterns do catálogo oficial a cada uma.

[INSTRUÇÃO] D007 não define componentes de interface nem preset visual final. Isso pertence ao D008.

## Regra Geral de Disciplina Metodológica

[Aplicar REGRAS GLOBAIS DE EXECUÇÃO do Kernel. Regras específicas deste protocolo abaixo:]
- Fazer um módulo por vez, não trabalhar em dois módulos de uma vez, iniciar outro somente após confirmação do humano.

## DEPENDÊNCIAS

[INSTRUÇÃO] Exigir dependências abaixo. Não prosseguir sem checklist satisfeito.
Exigir:
- Kernel v5
- Template D007
- D006 consolidado
- D003 consolidado
- Plataforma alvo (herdada de D006)
- DG1, DG2 e DG3
- Modo de interação definido. Se não informado, perguntar ao humano. Sem resposta, não prosseguir.

[INSTRUÇÃO] Se este documento é produzido no contexto de C2B (ciclos N):
- Incluir D013 (Jornadas da iteração corrente) como entrada obrigatória.
- Incluir D014 (Capacidades da iteração corrente) como entrada obrigatória.
- D015 (ADRs) como entrada opcional — consumir itens com impacto no ramo atual.
- No diagnóstico, mapear: jornadas da iteração → fluxos/módulos/entidades afetados.

### Checklist - GATE F1
- Kernel v5
- Template D007
- D006 consolidado
- D003 consolidado
- Plataforma alvo definida
- DGs fornecidos
- Modo de interação definido. Se não informado, perguntar ao humano. Sem resposta, não prosseguir.
- Contexto definido: C2A (Ciclo 1) ou C2B (Ciclos N)?

## LEITURA E DIAGNÓSTICO

[INSTRUÇÃO] Apenas após gate F1 satisfeito.

[INSTRUÇÃO] Mapear fontes por parte do documento:
- Parte A / §1 Mapeamento por Módulo:
  - D006 → módulos, shells e papel estrutural dos fluxos
  - D003 → fluxos, contextos, modelos mentais e princípios UX
- Parte B / §2 Fluxos Contextuais Globais:
  - D006 → fluxos com impacto transversal
  - D003 → contexto e impacto de interação
- Parte C / §3 Fluxos Sistêmicos:
  - D006 → fluxos sistêmicos pendentes
- §4 Inventário de Páginas:
  - derivado de §1, §2 e §3
- DG1 → BK-* do ramo EF
- DG2 → EST-* marcados para D007

[INSTRUÇÃO] Organizar o trabalho em 3 partes:
- Parte A: Mapeamento por Módulo — processar módulo a módulo
- Parte B: Fluxos Contextuais Globais — processar após todos módulos
- Parte C: Fluxos Sistêmicos — resolver pendências

[INSTRUÇÃO] Apresentar diagnóstico ao humano:
- Quantidade de módulos a processar
- Fluxos estruturais por módulo (quantos → quantas páginas esperadas)
- Fluxos contextuais globais pendentes
- Fluxos sistêmicos pendentes

### Checklist - GATE F2
- Leitura realizada
- Diagnóstico apresentado ao humano

## MAPEAMENTO POR MÓDULO (PARTE A)

[INSTRUÇÃO] Apenas após gate F2 satisfeito.

[INSTRUÇÃO] Executar módulo a módulo, na ordem declarada no diagnóstico.

[INSTRUÇÃO] Para cada módulo:

Passo 1 — Separar fluxos do módulo por tipo (do D006).

Passo 2 — Para cada fluxo estrutural, agrupar por tipo de interação e atribuir page pattern:
- Operacional (gestão de entidades) → PP-LIST-DETAIL (alternativa: PP-DASHBOARD)
- Exploratório (descoberta em coleção) → PP-CATALOG (alternativa: PP-FEED)
- Comunicacional (troca de mensagens) → PP-CONVERSATION (alternativa: PP-FEED)
- Informativo (leitura, visualização) → PP-DETAIL (alternativa: PP-LANDING)
- Transacional simples → PP-FORM
- Transacional multi-etapa → PP-WIZARD (alternativa: PP-FORM)
- Analítico (métricas) → PP-DASHBOARD (alternativa: PP-DETAIL)
Se fluxo não se enquadra → declarar ambiguidade, apresentar duas opções ao humano.

Passo 3 — Atribuir IDs: PAGE-{MOD}-NNN para cada página. Registrar PP atribuído e FLX-NNN de origem.

Passo 4 — Validar compatibilidade de cada página com Shell (SHL-NNN).

Passo 5 — Registrar estados transversais obrigatórios por página: No Permission, Not Found, Empty, Offline/Degraded, Loading.

Passo 6 — Registrar fluxos contextuais locais: em que página ocorrem, tipo de impacto (estado, UI, navegação).

Passo 7 — Apresentar proposta do módulo ao humano:

```
Módulo: MOD-{NNN}
Confiança: {Alta | Média | Baixa}

Fluxos Estruturais:
  FLX-{NNN} — {nome} → interação: {tipo} → Pattern: PP-{X}
    Página: PAGE-{MOD}-{NNN}
    Justificativa: {ancoragem}

Fluxos Contextuais Locais:
  FLX-{NNN} — {nome} → ocorre em: PAGE-{MOD}-{NNN} → impacto: {estado|UI|nav}

Compatibilidade com SHL-{NNN}: {confirmada}
Estados: {lista por página}
```

Passo 8 — Humano valida. Aprovar / Ajustar / Rejeitar → loop até aprovação.

[INSTRUÇÃO] Regra adaptativa: Se todos os patterns do módulo têm confiança Alta → pode apresentar módulo completo em bloco. Se algum tem Média/Baixa → validação item a item.

[INSTRUÇÃO] Repetir para cada módulo. Só avançar para Parte B após todos módulos validados.

## FLUXOS CONTEXTUAIS GLOBAIS (PARTE B)

[INSTRUÇÃO] Processar APÓS todos os módulos da Parte A validados.

[INSTRUÇÃO] Para cada fluxo Contextual Global (de D006):
- Listar páginas afetadas (PAGE-{MOD}-NNN)
- Declarar tipo de influência (estado / UI pattern / regra de navegação)
- Registrar nota para D008 (impacto em UI patterns)

[INSTRUÇÃO] Apresentar ao humano. Loop de validação.

## FLUXOS SISTÊMICOS (PARTE C)

[INSTRUÇÃO] Para cada fluxo sistêmico ainda pendente:
- Se complexo (múltiplas páginas, regras próprias) → propor módulo e processar na Parte A
- Se simples → registrar como dependência sistêmica

### Checklist - GATE F3
- Todos módulos mapeados com pelo menos 1 página
- Todos fluxos estruturais têm página associada
- Todos page patterns são do catálogo oficial
- Contextuais globais processados
- Sistêmicos resolvidos
- Documento completo apresentado ao humano
- Sem GAP Alto ou autorizado pelo humano

## CONSOLIDAÇÃO DO DOCUMENTO

[INSTRUÇÃO] Apenas após gate F3 satisfeito.

### ANÁLISE ESTRUTURAL

[INSTRUÇÃO] Informar ao humano que o documento está completo e será feita análise estrutural. Fazer:
- Ler Kernel e template
- Verificar que todos fluxos de D006 foram tratados
- Verificar que todas páginas têm page pattern do catálogo
- Gerar Inventário de Páginas completo
- Exibir problemas encontrados. Quando nenhum: informar.

[INSTRUÇÃO] Caso tenha inconsistência, validar com humano.

Se SIM: Ajustar e exibir novamente.
Se NÃO: Registrar decisão do humano e seguir.

#### Checklist - GATE F3.1
- Análise realizada
- Inventário de Páginas gerado
- Inconsistências informadas (ou nenhuma encontrada)
- Ajustes aprovados incorporados

### CONSOLIDAÇÃO

[INSTRUÇÃO] Apenas após gate F3.1 satisfeito.

[INSTRUÇÃO] Perguntar ao humano se pode consolidar o documento.

Se SIM:
- Criar o arquivo conforme template e nome definido.
- Analisar todos itens identificados para DG1 e apresentar ao humano.
- Analisar todos itens identificados para DG2 e apresentar ao humano.
- Analisar todos itens identificados para DG3 e apresentar ao humano.
- Seguir para Finalização.

Se NÃO:
- Perguntar o que quer alterar.
- Prosseguir até atendê-lo e perguntar novamente.

[INSTRUÇÃO] Em IDE: gerar arquivo. Perguntar pasta se não informada. Em CHAT: fornecer link para download.

### Checklist - GATE F4
- Humano confirmou consolidação
- Análise e exibição ao humano do que entra em DG1, DG2, DG3
- Arquivo criado ou link fornecido

## FINALIZAÇÃO

[INSTRUÇÃO] Apenas após gate F4 satisfeito.

### CRIAÇÃO DOS DGs

[INSTRUÇÃO] Criar ou atualizar DG1, DG2 e DG3:
- DG1: acumular — nunca deletar anteriores. Adicionar novos BK-*.
- DG2: substituir completamente. Organizar por documento de destino (D008). Remover EST-* consumidos.
- DG3: atualizar tabelas. Acrescentar PAGE-{MOD}-NNN identificados neste documento.

#### Checklist - GATE F5
- DG1, DG2, DG3 criados ou atualizados

### Próximo passo

[INSTRUÇÃO] Apenas após gate F5 satisfeito.

[INSTRUÇÃO] Sugerir ao humano:
- "D007 consolidado. Próximo documento do Ramo EF: D008 (UI-Patterns + Validação + Tech Preset)."
- "D008 compõe UI patterns por zona funcional em cada página, valida a cadeia completa e define preset de UI."
- Perguntar: "Deseja iniciar D008?"

