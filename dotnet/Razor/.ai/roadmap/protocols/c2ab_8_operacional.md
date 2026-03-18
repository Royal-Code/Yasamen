# PROTOCOLO OPERACIONAL D008 - UI-PATTERNS, VALIDAÇÃO E TECH PRESET

documento: "protocolo operacional ui-patterns"
versão: 5.0.0

## DESCRIÇÃO

[INSTRUÇÃO] D008 compõe UI patterns por zona funcional em cada página, valida a cadeia estrutural completa SHL→MOD→PAGE→PP→ZONA→UIP, define preset de UI (tokens, responsive, accessibility, motion) e exporta SES (Steering Export Sections) para frontend.steering.md.

[INSTRUÇÃO] D008 não cria páginas nem define estrutura macro do frontend. Isso pertence a D006 e D007.

## Regra Geral de Disciplina Metodológica

[Aplicar REGRAS GLOBAIS DE EXECUÇÃO do Kernel. Regras específicas deste protocolo abaixo:]
- Fazer uma página por vez, não trabalhar em duas páginas de uma vez, iniciar outra somente após confirmação do humano.

## DEPENDÊNCIAS

[INSTRUÇÃO] Exigir dependências abaixo. Não prosseguir sem checklist satisfeito.
Exigir:
- Kernel v5
- Template D008
- D006 consolidado (shells, módulos e papel estrutural dos fluxos)
- D007 consolidado (Inventário de Páginas, page patterns)
- D005 consolidado (convenções técnicas)
- Catálogo Global de UI Patterns (`c2ab_8_catalogo_ui.md`)
- Plataforma alvo (herdada de D006)
- DG1, DG2 e DG3
- Modo de interação definido. Se não informado, perguntar ao humano. Sem resposta, não prosseguir.

[INSTRUÇÃO] Se este documento é produzido no contexto de C2B (ciclos N):
- Incluir D013 (Jornadas da iteração corrente) como entrada obrigatória.
- Incluir D014 (Capacidades da iteração corrente) como entrada obrigatória.
- D015 (ADRs) como entrada opcional — consumir itens com impacto no ramo atual.
- No diagnóstico, mapear: jornadas da iteração → fluxos/módulos/páginas afetados.

### Checklist - GATE F1
- Kernel v5
- Template D008
- D006 consolidado
- D007 consolidado
- D005 consolidado
- Catálogo Global de UI Patterns
- Plataforma alvo definida
- DGs fornecidos
- Modo de interação definido. Se não informado, perguntar ao humano. Sem resposta, não prosseguir.
- Contexto definido: C2A (Ciclo 1) ou C2B (Ciclos N)?

## LEITURA E DIAGNÓSTICO

[INSTRUÇÃO] Apenas após gate F1 satisfeito.

[INSTRUÇÃO] Mapear fontes por parte do documento:
- Parte A / §1 Composição por Módulo:
  - D007 → inventário de páginas e page patterns
  - D006 → shells e módulos
  - D005 → convenções técnicas aplicáveis
  - Catálogo Global → compatibilidade e seleção de UIP
- Parte B / §2 Fluxos Contextuais Globais:
  - D007 → notas de impacto UI
  - Catálogo Global → UIP adicionais compatíveis
- Parte C / §3 Validação da Cadeia:
  - §1 e §2 deste documento
  - D006/D007 → cadeia estrutural de origem
  - Catálogo Global → compatibilidade primária, secundária e incompatibilidades explícitas
- Parte D / §4 Tech Preset:
  - D005 → stack e convenções
  - D006 → plataforma e shell
- DG1 → BK-* do ramo EF
- DG2 → EST-* marcados para D008

[INSTRUÇÃO] Organizar o trabalho em 4 partes:
- Parte A: Composição por Página — zona funcional e UI patterns por página
- Parte B: Fluxos Contextuais Globais — impacto em UI patterns
- Parte C: Validação da Cadeia — SHL→MOD→PAGE→PP→ZONA→UIP
- Parte D: Tech Preset — tokens, responsive, accessibility, motion

[INSTRUÇÃO] Apresentar diagnóstico ao humano:
- Total de páginas a processar (do Inventário)
- Páginas agrupadas por módulo
- Contextuais globais com impacto em UI
- Complexidade estimada (Alta/Média/Baixa)

### Checklist - GATE F2
- Leitura de D005, D006, D007 e Catálogo Global realizada
- Diagnóstico apresentado ao humano

## COMPOSIÇÃO POR PÁGINA (PARTE A)

[INSTRUÇÃO] Apenas após gate F2 satisfeito.

[INSTRUÇÃO] Processar página a página, agrupadas por módulo. Uma página por vez.

[INSTRUÇÃO] Para cada página (PAGE-{MOD}-NNN):

Passo 1 — Identificar page pattern (PP-{X}) atribuído no D007.

Passo 2 — Dividir página em zonas funcionais baseadas no page pattern:
- PP-LIST-DETAIL → zonas: Header, Filter, List, Detail-Panel, Actions
- PP-CATALOG → zonas: Header, Search, Filter-Bar, Grid, Pagination
- PP-FORM → zonas: Header, Form-Body, Validation, Actions
- PP-WIZARD → zonas: Header, Step-Indicator, Step-Body, Navigation
- PP-DASHBOARD → zonas: Header, KPI-Row, Chart-Area, Table-Area
- PP-DETAIL → zonas: Header, Content-Body, Sidebar, Actions
- PP-LANDING → zonas: Hero, Features, CTA, Footer
- PP-CONVERSATION → zonas: Header, Thread-List, Message-Area, Input
- PP-FEED → zonas: Header, Feed-List, Actions
- PP-SETTINGS → zonas: Header, Nav-Sidebar, Form-Area, Actions

Passo 3 — Para cada zona, selecionar UI patterns do Catálogo Global de UI Patterns. Não criar UIP novo no projeto.
- Verificar compatibilidade primária com o PP-{X}.
- Se a compatibilidade for secundária, justificar explicitamente.
- Se houver incompatibilidade explícita, não usar.
- Se nenhum padrão oficial atender, registrar EMG-NNN e levar ao humano. Não cunhar UIP local.

Passo 4 — Apresentar proposta da página ao humano:

```
Página: PAGE-{MOD}-NNN — {Nome}
Page Pattern: PP-{X}
Confiança: {Alta | Média | Baixa}

Zona: {nome}
  UIP-{GRUPO}-{NOME_CANONICO} — {justificativa}
  UIP-{GRUPO}-{NOME_CANONICO} — {justificativa}

Zona: {nome}
  UIP-{GRUPO}-{NOME_CANONICO} — {justificativa}
```

Passo 5 — Humano valida. Aprovar / Ajustar / Rejeitar → loop até aprovação.

[INSTRUÇÃO] Regra adaptativa: Se confiança Alta em todas zonas → pode apresentar página completa em bloco. Se alguma zona Média/Baixa → zona a zona.

## FLUXOS CONTEXTUAIS GLOBAIS — IMPACTO UI (PARTE B)

[INSTRUÇÃO] Processar APÓS todas as páginas da Parte A validadas.

[INSTRUÇÃO] Para cada fluxo contextual global com nota de D007:
- Identificar páginas afetadas
- Selecionar UI patterns adicionais ou modificados do Catálogo Global (ex: UIP-FEEDBACK-TOAST_ALERT para notificação global)
- Registrar impacto

[INSTRUÇÃO] Apresentar ao humano. Loop de validação.

## VALIDAÇÃO DA CADEIA (PARTE C)

[INSTRUÇÃO] Apenas após Partes A e B validadas.

[INSTRUÇÃO] Validar cadeia completa: SHL → MOD → PAGE → PP → ZONA → UIP

Para cada elemento da cadeia, verificar:
- SHL-NNN contém MOD-NNN?
- MOD-NNN contém PAGE-{MOD}-NNN?
- PAGE tem PP do catálogo?
- PP tem zonas definidas?
- Zonas têm UIP do Catálogo Global?
- Cada UIP é compatível com o PP como compatibilidade primária ou secundária?
- Nenhum UIP viola incompatibilidade explícita do Catálogo Global?

[INSTRUÇÃO] Listar quebras encontradas. Se nenhuma → informar cadeia íntegra.

[INSTRUÇÃO] Apresentar resultado ao humano.

### Checklist - GATE F3
- Todas páginas compostas com UI patterns
- Contextuais globais processados
- Cadeia SHL→MOD→PAGE→PP→ZONA→UIP validada
- Sem quebras ou quebras autorizadas
- Sem GAP Alto ou autorizado pelo humano

## TECH PRESET (PARTE D)

[INSTRUÇÃO] Apenas após gate F3 satisfeito.

[INSTRUÇÃO] Definir preset de UI baseado na plataforma e Shell:

Passo 1 — Design Tokens: propor paleta base (primary, secondary, neutral, semantic), tipografia (font-family, escala), espaçamento (base unit), bordas e sombras.

Passo 2 — Responsive: definir breakpoints (mobile, tablet, desktop, wide) e comportamento por página.

Passo 3 — Accessibility: definir nível alvo (WCAG AA mínimo), requisitos por categoria de UI pattern.

Passo 4 — Motion: definir regras de animação (duração, easing, quando aplicar).

[INSTRUÇÃO] Apresentar preset ao humano. Loop de validação.

[INSTRUÇÃO] O Tech Preset é declarativo — não deve conter código. Apenas intenções e regras para implementação.

### Checklist - GATE F3.1
- Design Tokens definidos
- Responsive definido
- Accessibility definido
- Motion definido
- Humano validou preset

## CONSOLIDAÇÃO DO DOCUMENTO

[INSTRUÇÃO] Apenas após gate F3.1 satisfeito.

### CONSOLIDAÇÃO

[INSTRUÇÃO] Perguntar ao humano se pode consolidar o documento.

Se SIM:
- Criar o arquivo conforme template e nome definido.
- Gerar SES (Steering Export Sections) para frontend.steering.md:
  - Inventário de Páginas com zonas e UI patterns
  - Tech Preset completo
  - Cadeia validada
- Se D005 declarar biblioteca de componentes, gerar também `ui-mapping.steering.md` com `UIP -> componente da biblioteca | custom`.
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
- SES gerado
- ui-mapping gerado quando aplicável
- Análise e exibição ao humano do que entra em DG1, DG2, DG3
- Arquivo criado ou link fornecido

## FINALIZAÇÃO

[INSTRUÇÃO] Apenas após gate F4 satisfeito.

### CRIAÇÃO DOS DGs

[INSTRUÇÃO] Criar ou atualizar DG1, DG2 e DG3:
- DG1: acumular — nunca deletar anteriores. Adicionar novos BK-*.
- DG2: substituir completamente. Não deve haver pendências de frontend — Ramo EF completo.
- DG3: atualizar tabelas. Acrescentar UIP-{GRUPO}-{NOME_CANONICO} selecionados do Catálogo Global e usados neste documento.

#### Checklist - GATE F5
- DG1, DG2, DG3 criados ou atualizados
- SES exportado (frontend.steering.md)

### Próximo passo

[INSTRUÇÃO] Apenas após gate F5 satisfeito.

[INSTRUÇÃO] Sugerir ao humano:
- "D008 consolidado. Ramo EF (Estrutural Frontend) completo."
- "SES exportado para frontend.steering.md — disponível para implementação frontend."
- "Próximo documento do Ramo EB: D009 (Modelo de Domínio)."
- "D009 modela Bounded Contexts com Aggregates, Value Objects, Domain Events e invariantes."
- Perguntar: "Deseja iniciar D009?"

