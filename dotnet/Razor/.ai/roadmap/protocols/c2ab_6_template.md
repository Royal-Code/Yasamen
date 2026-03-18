# TEMPLATE D006 - TAXONOMIA, SHELL E MÓDULOS

nome: "template taxonomia shell e módulos"
versão: 5.0.0

[INSTRUÇÃO] Nome do artefato: `{nome_do_projeto}_D006_I{NNN}_{plataforma}_taxonomia.md`

[INSTRUÇÃO] Se faltar informação relevante para fechar uma seção, explicitar a lacuna no conteúdo da seção e refletir isso no GAP da seção.

[INSTRUÇÃO] Convenção de IDs internos (dentro deste documento):
- MOD-NNN — Módulo do frontend
- SHL-NNN — Shell (estrutura raiz)
- EMG-NNN — Decisões emergentes

[INSTRUÇÃO] IDs reutilizados de outros documentos (não criar novos):
- FLX-NNN — Fluxos (de D003 ou D002_XPS)

[INSTRUÇÃO] Densidade da informação é satisfeita quando: (1) a resposta não se aplica genericamente a outro projeto do mesmo tipo, e (2) contém pelo menos um elemento concreto não-inferível (justificativa específica para este projeto). Falha nos dois = Ausente. Falha em apenas um = Parcial.

## CABEÇALHO

id: D006
projeto: {nome do projeto}
plataforma: {WEB | MOB | DESK}
versão: 1.0
criado_em: {data}
deriva_de: D005 + (D003, D004 | D002_XPS)

[INSTRUÇÃO] Neste template, "documento de concepção" significa:
- fluxo completo: D003 + D004
- fluxo Express: D002_XPS

## REGRAS DO TEMPLATE

- Definição de Densidade: lista de perguntas que o conteúdo deve responder. Responde todas → Completo. Falta alguma → Parcial. Não responde nenhuma → Ausente.
- Definição de Checklist de Seção: gate para avançar. Validar densidade, apresentar checklist ao humano e só avançar com confirmação.
- Regra: itens de densidade não satisfeitos viram GAP da seção (registrado na seção 6).
- Regra: MOD-NNN são definidos neste documento e só podem ser consolidados com rastreabilidade ao documento de concepção e a D005.
- Regra: não criar fluxos novos — usar FLX-NNN do documento de concepção. Se necessário fluxo novo, registrar como decisão emergente.
- **Seção 2 (Shell) é estruturante crítica** — GAP nesta seção eleva automaticamente o GAP do documento para Alto.

## 1. Plataforma
{Plataforma alvo para este D006}
[INSTRUÇÃO] D006 executa separadamente por plataforma. Se o projeto tem mais de uma plataforma, cada uma gera um D006.
[ELICITAR]
[DENSIDADE] Responde:
- Plataforma alvo declarada (WEB, MOB ou DESK)?
- Validada pelo humano?

### 1.1 Plataforma alvo
- Plataforma: {WEB | MOB | DESK}
- Validada pelo humano: {sim}

### Checklist
- Plataforma declarada
- Confirmado pelo humano

## 2. Shell Principal e Shells Adicionais
{Shell principal que governa o layout raiz da aplicação e shells adicionais quando houver justificativa estrutural}
[INSTRUÇÃO] Derivar de sinais estruturais do documento de concepção e de D005.
[INSTRUÇÃO] Registrar por sinal: descrição + fonte + trecho.
[INSTRUÇÃO] Declarar 1 shell principal.
[INSTRUÇÃO] Shell adicional exige justificativa rastreável a FLX/CTX/PUX/BC/D005.
[INSTRUÇÃO] Shell não consolida sem validação humana.
[DERIVAR]
[DENSIDADE] Responde:
- Shell principal selecionado do catálogo oficial?
- Cada shell adicional tem justificativa ancorada em sinais com referência a documentos anteriores?
- Confiança declarada?

### Catálogo oficial de Shells

- Workspace/Admin — backoffice, gestão, CRUD, múltiplos módulos.
- Portal — conteúdo público, navegação linear.
- Communication — chat, inbox, tempo real.
- Media/Content — feed, catálogo, descoberta.
- Dashboard/Analytics — métricas, monitoramento, visualização.

### 2.1 Sinais estruturais extraídos
Para cada sinal:
- Sinal: {descrição}
- Fonte: {documento, seção}
- Trecho: {evidência}

### 2.2 Shell principal

**SHL-{NNN} — {Tipo de Shell}**
- Papel: {Principal}
- Justificativa: {sinais que sustentam a escolha}
- Estrutura macro: {layout esperado para a plataforma}
- Confiança: {Alta | Média | Baixa}

### 2.3 Shells adicionais (opcional)

Para cada shell adicional:

**SHL-{NNN} — {Tipo de Shell}**
- Papel: {Adicional}
- Justificativa estrutural: {fluxo/contexto/modelo mental/BC/restrição de D005 que exige regime distinto}
- Escopo: {módulos ou áreas cobertas}
- Estrutura macro: {layout esperado para a plataforma}
- Confiança: {Alta | Média | Baixa}

[INSTRUÇÃO] Se empate entre shells: priorizar tipo dominante de interação. Se ainda ambíguo, apresentar duas opções ao humano.

### Checklist
- Sinais extraídos com referência a documentos
- Shell principal do catálogo oficial
- Shells adicionais, se existirem, justificados com rastreabilidade
- Confiança declarada
- Densidade satisfeita
- Confirmado pelo humano

## 3. Módulos
{Módulos do sistema com rastreabilidade}
[INSTRUÇÃO] Derivar MOD-NNN de FLX/BC e restrições de D005. Exigir rastreabilidade explícita.
[INSTRUÇÃO] Se houver capacidades formais em DG3/D014, mapear por módulo. Senão, declarar ausência formal.
[DERIVAR]
[DENSIDADE] Responde:
- Todos os módulos necessários para cobrir os fluxos estruturais e sistêmicos complexos foram identificados?
- Cada módulo tem tipo declarado (Usuário ou Sistema)?
- Cada módulo com rastreabilidade ao documento de concepção e/ou a D005?
- Se existirem capacidades formais disponíveis, cada capacidade tem pelo menos um módulo responsável?
- Compatibilidade com Shell verificada?

### 3.1 Módulos declarados

Para cada módulo:

**MOD-{NNN} — {Nome}**
- Tipo: {Usuário | Sistema}
- Shell associado: {SHL-NNN}
- Rastreabilidade: {critério primário: FLX-NNN (D003 ou D002_XPS) | critério secundário: BC-NNN (D004 ou D002_XPS) | restrição de D005 quando aplicável}
- Capacidades cobertas: {lista de capacidades do DG3/D014 | nenhuma capacidade formal disponível neste contexto}
- Compatibilidade com Shell: {Sim — motivo}
- Confiança: {Alta | Média | Baixa}

[INSTRUÇÃO] IA pode sugerir módulos adicionais (System Config, Notifications, etc.) — marcados como sugestão, não canônicos sem validação humana.

### 3.2 Mapeamento Módulos → Capacidades
[INSTRUÇÃO] Se existirem capacidades formais em DG3 ou D014, gerar a tabela abaixo. Se não existirem, declarar explicitamente que o mapeamento formal ficará pendente até a camada/iteração que formalizar capacidades canônicas.

| Módulo | Capacidades cobertas | Situação |
|---|---|---|
| MOD-{NNN} | {lista} | {Cobertura completa | Parcial | Sem capacidade formal} |

### Checklist
- Todos MOD-NNN necessários declarados
- Tipo declarado por módulo
- Rastreabilidade declarada por módulo
- Mapeamento módulos→capacidades gerado ou ausência formal declarada
- Compatibilidade com Shell verificada
- Confiança declarada por módulo
- Densidade satisfeita
- Confirmado pelo humano

## 4. Fluxos e Papel Estrutural
{Relação entre fluxos, módulos e impacto estrutural no frontend}
[INSTRUÇÃO] Reutilizar FLX-NNN do documento de concepção. Não criar IDs novos sem registrar como decisão emergente.
[INSTRUÇÃO] Esta seção não define page-patterns nem páginas finais. Ela apenas registra o papel estrutural de cada fluxo para orientar D007.
[DERIVAR]
[DENSIDADE] Responde:
- Todos FLX-NNN do documento de concepção foram tratados?
- Cada fluxo está associado a um módulo ou declarado como transversal/sistêmico?
- Está claro se o fluxo tende a página dedicada ou não?
- Impactos transversais relevantes foram sinalizados para D007?

Para cada fluxo:

**FLX-{NNN} — {Nome}**
- Módulo responsável: {MOD-NNN | transversal | sistêmico}
- Papel estrutural: {Página dedicada | Comportamento local | Comportamento transversal | Suporte sistêmico}
- Shell de referência: {SHL-NNN | shell principal | não se aplica}
- Observação para D007: {o que D007 precisa considerar ao transformar este fluxo em página/pattern}

### Checklist
- Todos FLX-NNN tratados
- Módulo responsável ou natureza transversal/sistêmica declarada
- Papel estrutural declarado
- Observações para D007 registradas quando necessário
- Densidade satisfeita
- Confirmado pelo humano

## 5. Decisões Emergentes
{Decisões que apareceram e não estavam nos documentos anteriores}
[INSTRUÇÃO] Se nenhuma emergiu: declarar "Nenhuma decisão emergente." — nunca omitir.
Novos módulos ou novos fluxos que emergem → registrar aqui com rastreabilidade.
[DERIVAR]
[DENSIDADE] Responde:
- A ausência de decisões emergentes foi declarada explicitamente quando aplicável?
- Cada decisão emergente tem tipo, origem e destino definidos?
- Contradições ou necessidades de retroalimentação foram sinalizadas?

### EMG-{NNN} — {Nome}
- Tipo: {Novo módulo | Novo fluxo | Retroalimentação | Contradição}
- Descrição: {o que é}
- Seção de origem: Seção {N}
- Destino: {DG1 | D007 | D008 | C1B}

### Checklist
- Seção declarada — "Nenhuma decisão emergente" se vazio
- Contradições sinalizadas
- Confirmado pelo humano

## 6. GAP Consolidado do Documento 006
[INSTRUÇÃO] Derivar automaticamente dos bullets [DENSIDADE] não satisfeitos.
[DERIVAR]
[DENSIDADE] Responde:
- Toda seção com densidade não satisfeita aparece com grau de incerteza e descrição do que falta?
- O GAP do documento está coerente com as regras de consolidação?
- A criticidade da seção 2 foi refletida corretamente no GAP final?

Para cada seção:
- Seção: {N}
- Grau de incerteza: {Completo | Parcial | Ausente}
- O que falta: {descrição}

### GAP do documento
- Todas Completas → Ausência de GAP
- Algumas Parciais → GAP Baixo
- Até 1 Ausente em seção não-estruturante → GAP Médio
- Seção 2 (Shell) Parcial ou Ausente → GAP Alto

**GAP declarado:** {Ausência de GAP | Baixo | Médio | Alto}

## 7. Exportação Steering (SES)
[DERIVAR]
{Steering file derivada de D006, pronta para exportação e consumo por IA}

[INSTRUÇÃO] Gerar esta seção a partir das Seções 2 a 4, no formato DEVE/NÃO DEVE/PREFERIR/EVITAR, com 15-40 linhas e rastreabilidade por ID.
[DENSIDADE] Responde:
- A SES cobre shells, taxonomia de módulos, papel estrutural dos fluxos e regras de navegação relevantes?
- Todas as regras são rastreáveis aos IDs de origem?
- O resultado está pronto para exportação direta como steering file?

Conteúdo da SES:
- Todos SHL-NNN como regra de layout/navegação, distinguindo shell principal e shells adicionais quando existirem
- Todos MOD-NNN como regra de organização e ownership
- Regras derivadas do papel estrutural dos fluxos quando impactarem navegação, página dedicada ou comportamento transversal

Formato esperado na steering file derivada:

```md
---
aplica_a: "src/frontend/**/*"
tipo: derivada
origem: D006
atualizado_em: {data}
plataforma: {WEB | MOB | DESK}
---

# frontend.steering.md

## Contexto
Steering derivada de D006 ({projeto}, {plataforma}).

## Regras

### Shells
- DEVE usar {SHL-NNN} como shell principal para {escopo}.
- PODE usar {SHL-NNN} como shell adicional para {escopo}, justificado por {origem}.

### Módulos
- DEVE manter {MOD-NNN} como módulo responsável por {escopo/capacidades}.
- NÃO DEVE misturar responsabilidades de {MOD-NNN} com {MOD-NNN} sem decisão explícita.

### Navegação e Fluxos
- FLX-{NNN} DEVE ser tratado como página dedicada.
- FLX-{NNN} DEVE permanecer como comportamento local do módulo {MOD-NNN}.
- FLX-{NNN} DEVE ser tratado como comportamento global/transversal.

## Rastreabilidade
- {Regra} → {ID origem}
```

### Checklist SES
- SES gerada com 15-40 linhas
- Todas as regras rastreadas por ID
- frontend.steering.md pronta para exportação
- Densidade satisfeita

## Confiança Geral
{Alta | Média | Baixa} — {justificativa}

## Checklist Final
[INSTRUÇÃO] Gate bloqueante para consolidação. A IA verifica e apresenta ao humano antes de prosseguir.
- Seções 1 a 4 preenchidas e com checklist de seção satisfeito
- Seção 5 declarada — "Nenhuma decisão emergente" se não houver, nunca omitida
- Seção 6 derivada automaticamente pela IA
- Seção 7 (SES) gerada automaticamente pela IA
- Confiança Geral declarada

