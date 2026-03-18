# TEMPLATE D007 - PAGE-PATTERNS

nome: "template page-patterns"
versão: 5.0.0

[INSTRUÇÃO] Nome do artefato:
`{nome_do_projeto}_D007_I{NNN}_{plataforma}_page_patterns.md`

[INSTRUÇÃO] IDs a gerenciar neste documento:
- Novos: PAGE-{MOD}-NNN (página por módulo, sequencial por módulo)
- Reutilizados: MOD-NNN (D006), FLX-NNN (D003), SHL-NNN (D006)
- Emergentes: EMG-NNN (decisões emergentes)

[INSTRUÇÃO] Regra de densidade: cada página deve ter — FLX de origem, page pattern do catálogo, justificativa de mapeamento, estados obrigatórios. Ausência de qualquer item → seção inválida.

## CABEÇALHO

[INSTRUÇÃO] Cabeçalho em formato simples, seguindo o padrão dos demais templates.

id: D007
projeto: {nome do projeto}
plataforma: {WEB | MOB | DESK}
versão: 1.0
criado_em: {data}
deriva_de: D006 + D003

## REGRAS DO TEMPLATE

[INSTRUÇÃO] Consolidar todas as seções abaixo com o conteúdo validado pelo humano.

[INSTRUÇÃO] Catálogo de Page Patterns — referência obrigatória:
- PP-LIST-DETAIL — lista com painel de detalhe lateral ou navegável
- PP-CATALOG — coleção filtrável com cards ou lista
- PP-FORM — formulário de entrada de dados (1 etapa)
- PP-WIZARD — formulário multi-etapa com barra de progresso
- PP-DASHBOARD — painel de métricas e KPIs
- PP-DETAIL — página de visualização de entidade
- PP-LANDING — página institucional ou de boas-vindas
- PP-CONVERSATION — chat ou thread de mensagens
- PP-FEED — lista cronológica de itens
- PP-SETTINGS — configurações e preferências

[INSTRUÇÃO] Cada seção usa marker [ELICITAR] ou [DERIVAR] conforme abaixo.

---

## §1 Mapeamento por Módulo [DERIVAR]

[INSTRUÇÃO] Processar módulo a módulo. Para cada módulo declarado no D006:

[DENSIDADE]
- MOD-NNN identificado
- Cada fluxo estrutural → 1 página com PAGE-{MOD}-NNN
- Page pattern do catálogo oficial atribuído
- Justificativa: tipo de interação → pattern
- Fluxos contextuais locais associados à página de ocorrência
- Estados obrigatórios registrados (No Permission, Not Found, Empty, Offline, Loading)

Formato por módulo:

### Módulo: {Nome} (MOD-NNN)
- Confiança do bloco: {Alta | Média | Baixa}
- Shell: SHL-NNN (compatibilidade confirmada)

#### Páginas

PAGE-{MOD}-001 — {Nome da Página}
- FLX de origem: FLX-NNN — {nome}
- Tipo de interação: {Operacional | Exploratório | Comunicacional | Informativo | Transacional | Analítico}
- Page Pattern: PP-{X}
- Justificativa: {ancoragem no tipo de interação}
- Estados: No Permission, Not Found, Empty, Offline, Loading

PAGE-{MOD}-002 — {Nome da Página}
- ...

#### Fluxos Contextuais Locais

FLX-NNN — {nome}
- Ocorre em: PAGE-{MOD}-NNN
- Impacto: {estado | UI | navegação}

#### Checklist §1 por Módulo
- Todos fluxos estruturais mapeados
- Page patterns do catálogo
- Justificativas com ancoragem
- Contextuais locais alocados
- Estados registrados

---

## §2 Fluxos Contextuais Globais [DERIVAR]

[INSTRUÇÃO] Derivar de D006 (fluxos classificados como Contextual Global).

[DENSIDADE]
- Cada fluxo global listado
- Páginas afetadas identificadas (PAGE-{MOD}-NNN)
- Tipo de influência declarado
- Nota para D008 registrada

Formato:

FLX-NNN — {nome}
- Páginas afetadas: PAGE-{MOD}-NNN, PAGE-{MOD}-NNN
- Influência: {estado | UI pattern | regra de navegação}
- Nota D008: {descrição do impacto esperado em UI patterns}

#### Checklist §2
- Todos fluxos contextuais globais processados
- Páginas afetadas identificadas
- Notas para D008 registradas

---

## §3 Fluxos Sistêmicos [DERIVAR]

[INSTRUÇÃO] Derivar de D006 (fluxos classificados como Sistêmico).

[DENSIDADE]
- Cada fluxo sistêmico resolvido ou escalado
- Se complexo: módulo proposto
- Se simples: registrado como dependência

Formato:

FLX-NNN — {nome}
- Resolução: {módulo proposto | dependência sistêmica}
- Páginas envolvidas: {PAGE-{MOD}-NNN ou "nenhuma — backend only"}

#### Checklist §3
- Todos fluxos sistêmicos resolvidos ou escalados
- Módulos novos processados na §1

---

## §4 Inventário de Páginas [DERIVAR]

[INSTRUÇÃO] Lista consolidada de todas as páginas do projeto. Gerar após validação de todas as seções anteriores.

[DENSIDADE]
- Todas páginas listadas com ID, nome, módulo, pattern, FLX de origem
- Contagem total de páginas
- Contagem por page pattern

Formato:

Total de páginas: {N}

Por pattern:
- PP-LIST-DETAIL: {n}
- PP-CATALOG: {n}
- PP-FORM: {n}
- PP-WIZARD: {n}
- PP-DASHBOARD: {n}
- PP-DETAIL: {n}
- PP-LANDING: {n}
- PP-CONVERSATION: {n}
- PP-FEED: {n}
- PP-SETTINGS: {n}

Lista completa:
- PAGE-{MOD}-NNN — {Nome} — MOD-NNN — PP-{X} — FLX-NNN

---

## §5 Decisões Emergentes [DERIVAR]

[INSTRUÇÃO] Registrar decisões tomadas durante o mapeamento que não estavam previstas nos documentos anteriores.
[DENSIDADE]
- Ausência declarada explicitamente quando nenhuma decisão emergiu
- Cada EMG-NNN com contexto, decisão e impacto
- Retroalimentações ou contradições sinalizadas quando existirem

EMG-NNN — {título}
- Contexto: {situação}
- Decisão: {o que foi decidido}
- Impacto: {D008 | D009 | outro}

#### Checklist §5
- Seção declarada ou "Nenhuma decisão emergente"
- Cada EMG com contexto, decisão e impacto
- Retroalimentações ou contradições sinalizadas

---

## §6 GAP Consolidado [DERIVAR]

[INSTRUÇÃO] Informações ausentes ou com confiança Baixa.
[DENSIDADE]
- Todo GAP relevante listado com origem, impacto e ação sugerida
- GAPs de seções anteriores consolidados sem duplicação
- Redução de confiança do documento refletida quando aplicável

- Item: {descrição}
- Origem: {seção}
- Impacto: {Alto | Médio | Baixo}
- Ação sugerida: {descrever}

[INSTRUÇÃO] Se §4 Inventário contém GAP → confiança do documento é reduzida.

#### Checklist §6
- GAPs listados ou "Nenhum GAP consolidado"
- Origem, impacto e ação sugerida por item
- Redução de confiança refletida quando aplicável

---

## Checklist Final
- Todas seções preenchidas
- Todos PAGE-{MOD}-NNN atribuídos
- Todos page patterns do catálogo oficial
- Inventário de Páginas gerado
- GAPs documentados
- Confiança geral atribuída

Confiança Geral: {Alta | Média | Baixa}

