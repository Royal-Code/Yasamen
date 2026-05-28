# Visual Language — {biblioteca}

Este template é um **guia de cobertura**. A IA pode reorganizar, fundir ou expandir seções conforme a biblioteca real, mas não pode omitir nenhum eixo marcado como obrigatório.

Formato obrigatório para cada regra visual:
- **Regra**: {afirmação clara e acionável}
- **Força**: forte | fraca
- **Aplicação**: {o que fazer}
- **Evitar**: {o que não fazer}

Significado da força para IA consumidora:
- `forte` = regra confirmada por token, API ou documentação oficial — seguir sem ressalva.
- `fraca` = regra inferida de múltiplas evidências convergentes — usar como recomendação preferencial, não como certeza absoluta; quando em dúvida, preferir alternativa mais contida.

Usar tabelas quando reduzirem ambiguidade (escalas, tokens, variantes).

## Resumo executivo

{Parágrafo denso: identidade visual, forças, limitações, foco da biblioteca}

## Identidade visual dominante — OBRIGATÓRIO

{Personalidade, tom, filosofia de design — o que define visualmente esta biblioteca}
{Formato: regra com Força/Aplicação/Evitar}

## Princípios visuais observados — OBRIGATÓRIO

{Princípios transversais numerados — cada um como regra com Força/Aplicação/Evitar}

## Hierarquia perceptiva — OBRIGATÓRIO

{Como tamanho, peso, cor e posição constroem hierarquia}
{Hierarquia de ações por variante — tabela recomendada}
{Hierarquia tipográfica — tabela recomendada: nível, token, size, weight, uso}
{Status por cor vs importância por tamanho}

## Spacing, ritmo e densidade — OBRIGATÓRIO

{Escala de spacing com tabela: tipo, token, valor, uso típico}
{Regras de densidade: interno vs externo, separação de componentes vs seções}
{Posicionamento de ações (quando relevante)}

## Peso e proporção entre zonas — OBRIGATÓRIO

{Distribuição visual: shell, conteúdo principal, overlays, footer}
{Diagrama textual do layout quando ajudar}
{Regra de overlays e interrupção}

## Ação principal e ações secundárias — OBRIGATÓRIO

{Hierarquia de botões — tabela recomendada: posição, variante, visual, quando usar}
{Cancelar, editar, excluir}
{Ações em tabelas/listas}
{Feedback pós-ação}

## Tipografia, cor e superfície — OBRIGATÓRIO

### Tipografia
{Famílias, pesos, escala, line-height}
{Tabela recomendada: nível, família, peso, size, line-height, uso}

### Paleta de cores
{Semântica de cor — tabela por função (brand, neutral, feedback)}
{Padrão por nível (100=bg, 200=borda, 300=principal, 400=pressed)}

### Superfícies e profundidade
{Tabela: superfície, background, shadow, radius, uso}

### Bordas
{Padrões, estados, espessuras}

## Contenção ou ornamentação — OBRIGATÓRIO

{Nível de decoração vs minimalismo}
{Iconografia}
{Profundidade e elevação}
{Elementos de separação}

## Estados e interação — OBRIGATÓRIO

{Esquema de estados: tabela com estado → padrão visual}
{Regras de transição e motion}
{Feedback ao usuário: tabela tipo → componente → persistência}

## Responsividade e adaptação — OBRIGATÓRIO

{Breakpoints — tabela}
{Regras de adaptação: colapso, empilhamento, overflow}
{Limitações conhecidas}

## Padrões visuais recorrentes — OBRIGATÓRIO

{Patterns de composição e decisões de uso recorrentes da biblioteca}
{Não apenas inventário — deve ser decisório: quando usar X vs Y para o mesmo cenário}

Conteúdo mínimo esperado:
- shells e navegação (como a lib monta pages, headers, sidebars);
- dados (DataGrid vs Card vs TotalCard — quando cada um);
- formulários (patterns de layout, inputs, validação);
- feedback (Toast vs Alert vs Dialog vs Banner — quando cada um);
- ações (hierarquia de botões por contexto);
- overlays (Modal vs Drawer vs Dialog — limites e preferências);
- fluxos recorrentes de composição (CRUD, dashboard, detalhe, confirmação).

## Critérios de uso por IA — OBRIGATÓRIO

{Lista decisória numerada: como uma IA deve usar este documento ao planejar/implementar telas}
{Ordem de consulta}
{Regras de prioridade por tipo de tela}
{Alternativas seguras para dúvidas}

## Resolução de conflitos — OBRIGATÓRIO

{Regras explícitas de precedência quando fontes divergem}

Para **valor concreto** (cor, size, spacing, radius):
- Token prevalece sobre documentação.
- Documentação prevalece sobre padrão recorrente.
- Padrão com 3+ ocorrências prevalece sobre caso isolado.

Para **intenção de uso** (quando usar, onde posicionar, qual componente):
- Documentação oficial prevalece sobre padrão recorrente.
- Padrão recorrente prevalece sobre token isolado.
- Anti-padrão documentado prevalece sobre exemplo observado.

Quando valor e intenção parecerem conflitar, separar: um define *o quê* implementar, outro define *quando/como* usar.

## Limites, lacunas e anti-padrões — OBRIGATÓRIO

### Limites
{Capacidades ausentes da biblioteca — tabela quando muitos}

### Anti-padrões
{O que não fazer + por que é ruim + alternativa segura}

### Alternativas seguras
{Decisões default quando não souber o que usar}