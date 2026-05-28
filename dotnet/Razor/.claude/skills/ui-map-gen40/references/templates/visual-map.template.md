# Visual Map — {biblioteca}

Este template é um **guia de cobertura** para o mapa de tradução visual→implementação. A IA pode reorganizar, fundir ou expandir seções conforme a tecnologia real, mas deve cobrir todos os blocos marcados como obrigatórios.

---

## Sistema de estilos — OBRIGATÓRIO

- Stack: `{CSS|SCSS|Tailwind|CSS-in-JS|theme API|Flutter theme|XAML resources|outro}`;
- Entrada pública: `{componentes, imports, providers, classes ou tokens}`;
- Base comum: `{setup, provider, import global ou equivalente}`;
- Regra geral de estilização: `{componentes são self-contained|estilização externa via X|misto}`;

---

## Tabela principal de mapeamento — OBRIGATÓRIO

| Eixo visual | Regra visual | Recurso concreto | Receita de uso | Origem | Força |
|---|---|---|---|---|---|
| `{eixo}` | `{regra do visual.language}` | `{token, classe, componente, prop ou variável}` | `{como aplicar}` | `{componente|token|config|SCSS|outro}` | `{forte|fraca|inconclusiva}` |

Cobertura mínima esperada na tabela:
- identidade visual / cor de marca;
- neutros e forma;
- feedback semântico;
- tipografia (componente e layout);
- ação principal, secundária, destrutiva;
- feedback temporal (loading, progress);
- spacing interno e externo;
- superfícies (card, modal, dropdown, tooltip);
- bordas e raios;
- profundidade / z-index;
- navegação (global e local);
- dados (tabular e escaneável);
- overlays;
- iconografia;
- responsividade.

---

## Gramática de layout para telas — OBRIGATÓRIO

{Regras de composição de página usando a tecnologia da biblioteca}

### Regras de composição

- **Zona de trabalho**: {como estruturar conteúdo principal};
- **Cabeçalho de página**: {título + ações — exemplo de layout};
- **Blocos relacionados**: {separação entre componentes e entre seções};
- **Filtros e dados**: {posicionamento relativo};
- **Formulários**: {grid, gap, ações};
- **Dashboards**: {métricas + gráficos};
- **List-detail**: {mobile vs desktop};

### Exemplos estruturais

```{linguagem}
// Cabeçalho de página com ação primária
{exemplo real com API válida}
```

```{linguagem}
// Formulário responsivo
{exemplo real com API válida}
```

```{linguagem}
// Filtro + dados
{exemplo real com API válida}
```

---

## Receitas operacionais — OBRIGATÓRIO

### {Cenário recorrente}

- Intenção: `{intenção visual}`;
- Componentes: `{componentes envolvidos}`;
- Recursos de estilo: `{tokens, classes, props}`;
- Limites: `{limitações ou -}`;

```{linguagem}
{exemplo com código real}
```

- Variações: {breakpoints, alternativas, regras}.

Cenários mínimos esperados:
- ação principal em listagem;
- ação destrutiva segura;
- formulário;
- busca e filtros acima de dados;
- tabela/grid operacional;
- dashboard com métricas;
- feedback proporcional;
- shell/navegação.

---

## Recursos visuais disponíveis — OBRIGATÓRIO

[INSTRUÇÃO] Usar nomenclatura nativa da stack conforme a família técnica:
- `web` — tokens, classes CSS, variáveis, utilitários Tailwind, mixins;
- `theme` — theme keys, color schemes, text themes, shape themes, modifiers;
- `ui-resources` — resource keys, brushes, styles, templates, static/dynamic resources;
- `presentation` — props, configs, palettes, layouts, slots, effects;
- genérico — qualquer recurso concreto identificável.

Organizar por família semântica (cores, tipografia, spacing, bordas, elevação, breakpoints, outros). A estrutura interna (tabela, árvore, lista) depende do que for mais natural para a stack.

### Cores

| Recurso | Tipo | Valor | Uso |
|---|---|---|---|
| `{nome}` | `{token|classe|prop|variável|brush|resource}` | `{valor}` | `{uso}` |

### Tipografia

| Recurso | Composição | Uso |
|---|---|---|
| `{nome}` | `{família peso size/line-height}` | `{uso}` |

### Espaçamento

| Recurso | Tipo | Valor | Uso |
|---|---|---|---|
| `{nome}` | `{inner|outer}` | `{valor}` | `{uso com classe/prop/key}` |

### Bordas, raios e elevação

| Recurso | Tipo | Valor | Uso |
|---|---|---|---|
| `{nome}` | `{radius|border|shadow|elevation}` | `{valor}` | `{uso}` |

### Breakpoints

| Nome | Valor | Contexto |
|---|---|---|
| `{nome}` | `{valor}` | `{dispositivo/contexto}` |

---

## Lacunas e alternativas

{Registrar quando a biblioteca não cobrir um eixo ou recurso visual necessário para implementação. Para cada lacuna: descrever o que falta, impacto na implementação e alternativa segura recomendada.}

| Eixo | O que falta | Impacto | Alternativa |
|---|---|---|---|
| `{eixo visual}` | `{recurso ou capacidade ausente}` | `{impacto na implementação}` | `{alternativa: CSS externo, primitivo nativo, workaround, ou \"sem alternativa\"}` |

### Outros recursos

{Opacidade, z-index, motion, density, device classes — quando existirem}

---

## Lacunas e alternativas — OBRIGATÓRIO

| Lacuna | Impacto | Alternativa |
|---|---|---|
| `{regra visual sem correspondência}` | `{o que pode dar errado}` | `{alternativa ou nenhuma}` |

---

## Critérios de uso por IA

{Como e quando a IA deve consultar este documento}
- Fluxo de consulta: visual.language (decidir intenção) → visual.map (escolher recurso) → props de componente → tokens para layout → validar contra anti-padrões.
- Usar componentes públicos antes de estilos customizados.
- Usar tokens oficiais para cor, tipografia, spacing, borda e elevação.
- Nunca inventar variantes, tokens ou classes sem evidência.
