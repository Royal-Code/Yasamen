# TEMPLATE D008 - UI-PATTERNS, VALIDAÇÃO E TECH PRESET

nome: "template ui-patterns"
versão: 5.0.0

[INSTRUÇÃO] Nome do artefato:
`{nome_do_projeto}_D008_I{NNN}_{plataforma}_ui_patterns.md`

[INSTRUÇÃO] IDs a gerenciar neste documento:
- Selecionados do Catálogo Global: UIP-{GRUPO}-{NOME_CANONICO}
- Reutilizados: PAGE-{MOD}-NNN (D007), MOD-NNN (D006), SHL-NNN (D006), FLX-NNN (D003)
- Emergentes: EMG-NNN (decisões emergentes)

[INSTRUÇÃO] Regra de densidade: cada página deve ter — zonas funcionais identificadas, UI patterns atribuídos por zona com justificativa. Ausência → seção inválida.

## CABEÇALHO

[INSTRUÇÃO] Cabeçalho em formato simples, seguindo o padrão dos demais templates.

id: D008
projeto: {nome do projeto}
plataforma: {WEB | MOB | DESK}
versão: 1.0
criado_em: {data}
deriva_de: D005 + D006 + D007 + Catalogo Global de UI Patterns

## REGRAS DO TEMPLATE

[INSTRUÇÃO] Consolidar todas as seções abaixo com o conteúdo validado pelo humano.

[INSTRUÇÃO] Consultar obrigatoriamente `c2ab_8_catalogo_ui.md` para selecionar UI patterns.
[INSTRUÇÃO] D008 não cria nem redefine UIP. Apenas seleciona padrões oficiais do catálogo global.
[INSTRUÇÃO] Se nenhum padrão oficial atender, registrar EMG-NNN e escalar ao humano.

[INSTRUÇÃO] Zonas funcionais por Page Pattern:
- PP-LIST-DETAIL → Header, Filter, List, Detail-Panel, Actions
- PP-CATALOG → Header, Search, Filter-Bar, Grid, Pagination
- PP-FORM → Header, Form-Body, Validation, Actions
- PP-WIZARD → Header, Step-Indicator, Step-Body, Navigation
- PP-DASHBOARD → Header, KPI-Row, Chart-Area, Table-Area
- PP-DETAIL → Header, Content-Body, Sidebar, Actions
- PP-LANDING → Hero, Features, CTA, Footer
- PP-CONVERSATION → Header, Thread-List, Message-Area, Input
- PP-FEED → Header, Feed-List, Actions
- PP-SETTINGS → Header, Nav-Sidebar, Form-Area, Actions

---

## §1 Composição por Módulo [DERIVAR]

[INSTRUÇÃO] Processar módulo a módulo. Para cada módulo, listar páginas e sua composição.

[DENSIDADE]
- Módulo identificado (MOD-NNN)
- Cada página com zonas e UI patterns
- Justificativa por UI pattern
- Seleção ancorada no Catálogo Global

### Módulo: {Nome} (MOD-NNN)

#### PAGE-{MOD}-NNN — {Nome da Página}
- Page Pattern: PP-{X}
- Confiança: {Alta | Média | Baixa}

**Zona: {nome}**
- UIP-{GRUPO}-{NOME_CANONICO} — {justificativa}
- UIP-{GRUPO}-{NOME_CANONICO} — {justificativa}

**Zona: {nome}**
- UIP-{GRUPO}-{NOME_CANONICO} — {justificativa}

#### Checklist §1 por Módulo
- Todas páginas do módulo compostas
- Zonas derivadas do page pattern
- UI patterns do Catálogo Global
- Justificativas com ancoragem

---

## §2 Fluxos Contextuais Globais — Impacto UI [DERIVAR]

[INSTRUÇÃO] Derivar das notas de D007 sobre fluxos contextuais globais.

[DENSIDADE]
- Cada fluxo global com impacto UI listado
- UI patterns adicionais ou modificados declarados
- Páginas afetadas
- Seleção ancorada no Catálogo Global

FLX-NNN — {nome}
- Páginas afetadas: PAGE-{MOD}-NNN
- UI patterns adicionais: UIP-{GRUPO}-{NOME_CANONICO}
- Descrição do impacto: {como afeta a composição}

#### Checklist §2
- Todos contextuais globais com impacto UI processados
- UI patterns adicionais registrados

---

## §3 Validação da Cadeia [DERIVAR]

[INSTRUÇÃO] Validar integridade da cadeia: SHL → MOD → PAGE → PP → ZONA → UIP.

[DENSIDADE]
- Cada nível da cadeia verificado
- Quebras listadas ou cadeia declarada íntegra
- Compatibilidade e incompatibilidades do catálogo verificadas

Resultado da validação:
- Cadeia íntegra: {Sim | Não}
- Quebras encontradas: {lista ou "nenhuma"}
- Ações corretivas: {se aplicável}

#### Checklist §3
- Cadeia validada nível a nível
- Compatibilidade dos UIP com PP verificada no Catálogo Global
- Quebras resolvidas ou autorizadas

---

## §4 Tech Preset [DERIVAR]

[INSTRUÇÃO] Preset declarativo de UI — sem código.

[DENSIDADE]
- Design Tokens definidos
- Responsive definido
- Accessibility definido
- Motion definido

### Design Tokens
- Paleta: primary, secondary, neutral, semantic (success, warning, error, info)
- Tipografia: font-family, escala tipográfica, line-height
- Espaçamento: base unit, escala
- Bordas: border-radius padrão
- Sombras: elevation levels

### Responsive
- Breakpoints: mobile ({px}), tablet ({px}), desktop ({px}), wide ({px})
- Comportamento por tipo de página: {regras}

### Accessibility
- Nível alvo: {WCAG AA | AAA}
- Contraste mínimo: {ratio}
- Requisitos por categoria de UI pattern: {lista}

### Motion
- Duração padrão: {ms}
- Easing: {tipo}
- Regras de aplicação: {quando animar}

#### Checklist §4
- Design Tokens definidos
- Responsive com breakpoints
- Accessibility com nível alvo
- Motion com regras

---

## §5 SES — Steering Export Sections [DERIVAR]

[INSTRUÇÃO] Exportar seções para frontend.steering.md. Contém tudo necessário para iniciar implementação frontend.

[DENSIDADE]
- Inventário de páginas com zonas e UI patterns
- Tech Preset completo
- Convenções relevantes de D005
- Cadeia validada
- UI patterns globais selecionados e rastreáveis

### Conteúdo do SES

#### Inventário de Páginas (resumo)
- PAGE-{MOD}-NNN — {Nome} — PP-{X} — {zonas resumidas}

#### Tech Preset (completo)
- {copiar §4}

#### Convenções Frontendistas (de D005)
- {naming, idioma, extensão, etc.}

#### Cadeia Validada
- SHL-NNN → MOD-NNN → PAGE-{MOD}-NNN → PP-{X} → ZONA → UIP

#### UI Mapping para Biblioteca
- UIP-{GRUPO}-{NOME_CANONICO} | Componente da biblioteca | Notas

#### Checklist §5
- SES completo
- Pronto para frontend.steering.md

---

## §6 Decisões Emergentes [DERIVAR]

[DENSIDADE]
- Ausência declarada explicitamente quando nenhuma decisão emergiu
- Cada EMG-NNN com contexto, decisão e impacto
- Retroalimentações ou contradições sinalizadas quando existirem

EMG-NNN — {título}
- Contexto: {situação}
- Decisão: {o que foi decidido}
- Impacto: {D009 | implementação | outro}

#### Checklist §6
- Seção declarada ou "Nenhuma decisão emergente"
- Cada EMG com contexto, decisão e impacto
- Retroalimentações ou contradições sinalizadas

---

## §7 GAP Consolidado [DERIVAR]

[INSTRUÇÃO] Informações ausentes ou com confiança Baixa.
[DENSIDADE]
- Todo GAP relevante listado com origem, impacto e ação sugerida
- GAPs de seções anteriores consolidados sem duplicação
- Redução de confiança do documento refletida quando aplicável

- Item: {descrição}
- Origem: {seção}
- Impacto: {Alto | Médio | Baixo}
- Ação sugerida: {descrever}

#### Checklist §7
- GAPs listados ou "Nenhum GAP consolidado"
- Origem, impacto e ação sugerida por item
- Redução de confiança refletida quando aplicável

---

## Checklist Final
- Todas páginas compostas com UI patterns por zona
- Contextuais globais processados
- Cadeia SHL→MOD→PAGE→PP→ZONA→UIP validada
- Tech Preset completo
- SES gerado
- GAPs documentados
- Confiança geral atribuída

Confiança Geral: {Alta | Média | Baixa}

