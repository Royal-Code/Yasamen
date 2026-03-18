# PROTOCOLO OPERACIONAL D006 - TAXONOMIA, SHELL E MÓDULOS

documento: "protocolo operacional taxonomia shell e módulos"
versão: 5.0.0

## DESCRIÇÃO

[INSTRUÇÃO] D006 produz a taxonomia estrutural do frontend por plataforma: shell principal, shells adicionais quando existirem, módulos e papel estrutural dos fluxos.

[INSTRUÇÃO] D006 não define páginas nem page-patterns. Isso pertence ao D007.

[INSTRUÇÃO] Neste protocolo, "documento de concepção" significa:
- fluxo completo: D003 + D004
- fluxo Express: D002_XPS

## Regra Geral de Disciplina Metodológica

[Aplicar REGRAS GLOBAIS DE EXECUÇÃO do Kernel. Regras específicas deste protocolo abaixo:]
- Fazer uma seção por vez, não trabalhar em duas ou mais seções de uma vez, iniciar outra seção somente após a confirmação do humano.

## DEPENDÊNCIAS

[INSTRUÇÃO] Exigir dependências abaixo. Não prosseguir sem checklist satisfeito.
Exigir:
- Kernel v5
- Template D006
- D005 consolidado
- Documento de concepção consolidado
- Plataforma alvo (confirmada em D005)
- DG1, DG2 e DG3
- Modo de interação definido. Se não informado, perguntar ao humano. Sem resposta, não prosseguir.

[INSTRUÇÃO] Se este documento é produzido no contexto de C2B (ciclos N):
- Incluir D013 (Jornadas da iteração corrente) como entrada obrigatória.
- Incluir D014 (Capacidades da iteração corrente) como entrada obrigatória.
- D015 (ADRs) como entrada opcional — consumir itens com impacto no ramo atual.
- No diagnóstico, mapear: jornadas da iteração → fluxos/módulos/entidades afetados.

### Checklist - GATE F1
- Kernel v5
- Template D006
- D005 consolidado
- Documento de concepção disponível:
  - D003 + D004
  - ou D002_XPS
- Plataforma alvo definida
- DGs fornecidos
- Modo de interação definido. Se não informado, perguntar ao humano. Sem resposta, não prosseguir.
- Contexto definido: C2A (Ciclo 1) ou C2B (Ciclos N)?

## LEITURA E DIAGNÓSTICO

[INSTRUÇÃO] Apenas após gate F1 satisfeito.

[INSTRUÇÃO] Identificar qual documento de concepção está disponível:
- completo: D003 + D004
- express: D002_XPS

[INSTRUÇÃO] Mapear fontes por seção do template:
- §2 Shells:
  - documento de concepção → fluxos, contextos e sinais estruturais
  - D005 → restrições arquiteturais
- §3 Módulos:
  - documento de concepção → fluxos, BCs e entidades
  - DG3/D014 → capacidades formais, se existirem
- §4 Fluxos e Papel Estrutural:
  - documento de concepção → FLX
  - §3 deste documento → módulos e shells
- DG1 → BK-* do ramo EF
- DG2 → EST-* marcados para D006

[INSTRUÇÃO] Diagnosticar:
- O que está completo e pode ser derivado diretamente
- O que está vago e gerará perguntas de clarificação
- Se documento de concepção tem GAP Alto nas seções estruturais: informar — fluxos e módulos herdarão incerteza

[INSTRUÇÃO] Apresentar diagnóstico resumido ao humano.

### Checklist - GATE F2
- Modo de entrada identificado (completo ou Express)
- Leitura realizada
- Diagnóstico apresentado ao humano

## ELICITAÇÃO DAS SEÇÕES DO TEMPLATE

[INSTRUÇÃO] Apenas após gate F2 satisfeito.

[INSTRUÇÃO] Iterar seções em 2 blocos, sem saltar seções dentro de cada bloco:
- Bloco 1: Iterar as seções [ELICITAR] do template (§1 Plataforma), uma a uma, sem saltar.
- Bloco 2: Iterar as seções [DERIVAR] do template (§2 Shell Principal e Shells Adicionais, §3 Módulos, §4 Fluxos e Papel Estrutural), uma a uma, sem saltar.

[INSTRUÇÃO] Não iniciar uma seção antes do humano confirmar a anterior.

[INSTRUÇÃO] Para cada seção, verificar o marcador no template:

Se [ELICITAR]:
- Preencher como sugestão as informações já extraídas dos documentos anteriores.
- Perguntar ao humano o que for necessário para atender a densidade da seção.
- Adequar perguntas ao Modo de Interação.
- Se humano não sabe responder, sugerir opções.

Se [DERIVAR]:
- Propor conteúdo da seção baseado nas seções anteriores confirmadas e documentos anteriores.
- Apresentar proposta ao humano como sugestão, marcada claramente.
- Humano valida, ajusta ou rejeita.

Para ambos:
- Validar densidade da seção conforme definido no template.
- Apresentar checklist da seção ao humano.
- Só avançar com confirmação explícita do humano.
- Itens de densidade não satisfeitos → GAP da seção + DG1.

[INSTRUÇÃO] Regras específicas de D006:

Para §2 Shell:

#### Passo Pré-Shell — Extração de sinais estruturais
[INSTRUÇÃO] Executar antes de propor qualquer shell. Não prosseguir sem completar.
- Ler documento de concepção:
  - FLX/CTX/PUX → fluxos, contextos e sinais de navegação
  - BC → bounded contexts com impacto na estrutura
- Ler D005: ARC-NNN → padrões com restrição no frontend
- Para cada sinal: registrar sinal + fonte exata (documento e seção) + trecho justificativo.

Checklist — Pré-Shell:
- Sinais extraídos com fonte rastreável
- Nenhum sinal inferido sem documento de origem

[INSTRUÇÃO] Após extração de sinais:
- Se empate entre shells → priorizar tipo dominante de interação. Se ainda ambíguo → apresentar duas opções ao humano.
- Declarar 1 shell principal por padrão.
- Só propor shell adicional quando houver justificativa estrutural rastreável a FLX-NNN, CTX-NNN, PUX-NNN, BC-NNN ou restrição explícita de D005.
- Shell nunca é consolidado automaticamente, independentemente da confiança.

Para §3 Módulos:
- Derivar MOD-NNN neste documento a partir de FLX-NNN, BC-NNN e restrições de D005.
- Classificar cada módulo como Usuário ou Sistema.
- Associar cada módulo a um SHL-NNN.
- Verificar rastreabilidade: fluxo (D003 ou D002_XPS)? conceito estrutural (D004 ou D002_XPS)? restrição arquitetural (D005)?
- Se existirem capacidades formais em DG3, mapear capacidades por módulo e sinalizar capacidades órfãs.
- Se este documento estiver em C2B, usar D014 como fonte prioritária de capacidades da iteração corrente.
- IA pode sugerir módulos adicionais (System Config, Notifications) — marcados como sugestão, não canônicos sem validação.

Para §4 Fluxos e Papel Estrutural:
- Reutilizar FLX-NNN do documento de concepção.
- Para cada fluxo, declarar: módulo responsável, papel estrutural, shell de referência e observação para D007.
- Papel estrutural permitido: Página dedicada, Comportamento local, Comportamento transversal, Suporte sistêmico.
- Esta seção não define page-patterns nem páginas finais — isso é responsabilidade de D007.
- Se um fluxo exigir tratamento sistêmico complexo, sinalizar a implicação para o módulo correspondente ou registrar decisão emergente.

[INSTRUÇÃO] Seções 5 (Decisões Emergentes), 6 (GAP) e 7 (SES) não são iteradas nos blocos.
Seção 5 é analisada após todas seções iteradas. Seções 6 e 7 são derivadas automaticamente na consolidação.

[INSTRUÇÃO] Caso existir GAP Alto, informá-los ao humano, incluindo implicações para D007 e D008. Perguntar se quer resolver, precisa de ajuda, ou quer prosseguir com GAP.

### Checklist - GATE F3
- Todas seções iteradas
- Checklist Final do template satisfeito
- Documento completo seguindo o template apresentado ao humano
- Sem GAP Alto ou autorizado pelo humano

## CONSOLIDAÇÃO DO DOCUMENTO

[INSTRUÇÃO] Apenas após gate F3 satisfeito.

### ANÁLISE ESTRUTURAL

[INSTRUÇÃO] Informar ao humano que o documento está completo e será feita análise estrutural. Fazer:
- Ler Kernel e template
- Analisar documento completo contra regras, instruções e definições
- Verificar que todos FLX-NNN do documento de concepção foram tratados
- Verificar que existe exatamente 1 shell principal
- Verificar que todo shell adicional tem justificativa estrutural rastreável
- Verificar que todos MOD-NNN declarados têm justificativa e rastreabilidade
- Verificar que todo MOD-NNN tem tipo declarado (Usuário ou Sistema)
- Verificar que todo MOD-NNN está associado a um SHL-NNN
- Se existirem capacidades formais em DG3/D014: verificar que toda capacidade tem pelo menos um módulo responsável, ou foi declarada explicitamente como órfã/pendente
- Exibir problemas encontrados. Quando nenhum: informar que não achou inconsistência.

[INSTRUÇÃO] Caso tenha inconsistência, validar com humano se deve ser ajustado.

Se SIM: Ajustar e exibir novamente.
Se NÃO: Registrar decisão do humano e seguir.

#### Checklist - GATE F3.1
- Análise realizada
- Inconsistências informadas (ou nenhuma encontrada)
- Ajustes aprovados incorporados

### CONSOLIDAÇÃO

[INSTRUÇÃO] Apenas após gate F3.1 satisfeito.

[INSTRUÇÃO] Perguntar ao humano se pode consolidar o documento.

Se SIM:
- Criar o arquivo conforme template e nome definido.
- Gerar §7 (SES) automaticamente conforme o template.
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
- SES gerada (§7)
- Análise e exibição ao humano do que entra em DG1, DG2, DG3
- Arquivo criado ou link fornecido

## FINALIZAÇÃO

[INSTRUÇÃO] Apenas após gate F4 satisfeito.

### CRIAÇÃO DOS DGs

[INSTRUÇÃO] Criar ou atualizar DG1, DG2 e DG3:
- DG1: acumular — nunca deletar anteriores. Adicionar novos BK-*.
- DG2: substituir completamente. Organizar por documento de destino (D007, D008). Remover EST-* consumidos.
- DG3: atualizar tabelas. Acrescentar MOD-NNN e SHL-NNN identificados neste documento.

[INSTRUÇÃO] Exportar frontend.steering.md derivada da §7 (SES). Densidade: 15-40 linhas.
- Destino: `.ai-friendly/steering/frontend.steering.md`
- Se ambiente IDE: gerar arquivo. Se Chat Web + MCP: push via MCP.

#### Checklist - GATE F5
- DG1, DG2, DG3 criados ou atualizados
- frontend.steering.md exportada

### Próximo passo

[INSTRUÇÃO] Apenas após gate F5 satisfeito.

[INSTRUÇÃO] Sugerir ao humano:
- "D006 consolidado. Próximo documento do Ramo EF: D007 (Page-Patterns)."
- "D007 lê módulos, shells e o papel estrutural dos fluxos em D006 para derivar páginas concretas e atribuir page-patterns."
- Perguntar: "Deseja iniciar D007?"

