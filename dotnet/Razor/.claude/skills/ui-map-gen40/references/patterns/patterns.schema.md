# Patterns — Schema

Campos por tipo de pattern e vocabulários canônicos. Campo que referencia um vocabulário aceita só seus tokens.

## Plataformas — vocabulário canônico

Campos `Plataformas *` de SHP, PP e UIP usam só estes tokens. Viewport (tablet, foldable) é tratado nos campos de Estrutura; modo de implantação (PWA, kiosk) não é plataforma.

| Token | Significado |
|-------|-------------|
| **Web** | Navegador, qualquer viewport. |
| **Mobile nativo** | App nativo de smartphone ou tablet (iOS/Android). |
| **Desktop nativo** | App de desktop (Windows, macOS, Linux). |

Cada pattern declara `Plataformas aplicáveis` (onde pode ser usado) e `Plataformas primárias` (plataformas naturais). Restrição específica de uma plataforma vai em `Adaptação por Plataforma`.

## Vocabulário de Zonas

Campos `Zonas funcionais obrigatórias` (PP) e `Zonas usuais` (UIP) usam só estes tokens. Conjunto fechado; nova zona só neste arquivo.

| Token | Significado |
|-------|-------------|
| **Cabeçalho** | Identidade, título, contexto e status do nível atual. |
| **Navegação** | Acesso a destinos, seções, vistas, etapas ou níveis. |
| **Filtros** | Refino de coleção por atributos, facetas ou busca. |
| **Coleção** | Listagem, grade ou tabela de itens. |
| **Detalhe** | Visualização ou edição do item em foco. |
| **Conteúdo** | Corpo principal de leitura, formulário ou composição. |
| **Superfície** | Superfície especializada: canvas, mapa, gráfico, viewer. |
| **Ações** | Comandos sobre a página, a seleção ou a entidade. |
| **Painel Auxiliar** | Área complementar persistente: inspector, sidebar secundária. |
| **Overlay** | Superfície sobreposta temporária: modal, drawer, sheet, popover. |
| **Rodapé** | Informações finais, status global ou navegação inferior. |

## Estados de Página — vocabulário canônico

Campo `Reação a estados da página` (UIP) usa só estes estados.

| Estado | Significado | Renderizado por |
|--------|-------------|-----------------|
| **loading** | Conteúdo ou ação em carregamento. | UIP-FEEDBACK-LOADING_STATE |
| **empty** | Ausência de dados, sem falha. | UIP-FEEDBACK-EMPTY_STATE |
| **error** | Falha técnica ou recuperação necessária. | UIP-FEEDBACK-ERROR_STATE |
| **no-permission** | Acesso insuficiente. | Variante `permission empty` de UIP-FEEDBACK-EMPTY_STATE; ou zona oculta/desabilitada; ou UIP-FEEDBACK-ERROR_STATE em sessão expirada. |

Precedência: `loading` > `error` > `empty`. `no-permission` resolve conforme a causa.

## Grau de Rigidez

Quanto a estrutura canônica tolera variação na composição.

| Grau | Significado |
|------|-------------|
| **Alto** | Estrutura, zonas e comportamento invariantes. Varia só estilo, plataforma e componente. |
| **Médio** | Zonas e comportamento principal estáveis. Variantes reconhecidas alteram composição secundária. |
| **Baixo** | Só a intenção é fixa. Estrutura interna varia por contexto e plataforma. |

Formato: `**Grau de Rigidez**: {Alto|Médio|Baixo} — {nota contextual curta}`. A nota diz o que pode ou não variar naquele pattern.

## Natureza da Compatibilidade

- `Compatibilidade Primária` e `Secundária`: orientativas, ranqueiam escolhas. Declaração unilateral; ausência não é proibição.
- `Incompatibilidades explícitas`: eliminatória. Declaração unilateral basta para bloquear.

Só `Incompatibilidades explícitas` proíbe uma combinação.

## Campos de SHP-* (Shell Patterns)

| Campo | Obrigatório | Tipo | Semântica |
|-------|-------------|------|-----------|
| Definição curta | Sim | Texto curto | Âncora semântica do shell |
| Objetivo estrutural | Sim | Texto | Responsabilidade estrutural |
| Interação dominante | Sim | Keyword | Modo principal de uso |
| Não confundir com | Sim | Lista | Shells próximos não equivalentes; ver `Formato de Não Confundir com` |
| Sinais de escolha | Sim | Bullets | Evidências para selecionar o shell |
| Limites | Sim | Texto | Quando não usar ou deixa de ser dominante |
| Grau de Rigidez | Sim | Alto/Médio/Baixo + nota | Quanto tolera variação |
| Modelo de navegação global | Sim | Texto | Forma de navegação |
| Compatibilidade Primária | Sim | Lista de PP-* | Page patterns centrais |
| Compatibilidade Secundária | Sim | Lista de PP-* | Page patterns possíveis |
| Incompatibilidades explícitas | Sim | Lista de PP-* | Page patterns inadequados como dominante |
| Estrutura Desktop | Sim | Texto | Estrutura em viewport ampla |
| Estrutura Mobile | Sim | Texto | Estrutura em viewport estreita |
| Regra de transição | Sim | Texto | Invariantes desktop/mobile |
| Plataformas aplicáveis | Sim | Lista do vocabulário | Plataformas onde pode ser usado |
| Plataformas primárias | Sim | Lista do vocabulário | Plataformas naturais |
| Adaptação por Plataforma | Sim | Campos por plataforma | Instruções de adaptação |

## Campos de PP-* (Page Patterns)

| Campo | Obrigatório | Tipo | Semântica |
|-------|-------------|------|-----------|
| Definição curta | Sim | Texto curto | Âncora semântica da página |
| Objetivo estrutural | Sim | Texto | Problema estrutural que resolve |
| Interação dominante | Sim | Keyword | Modo principal de interação |
| Não confundir com | Sim | Lista | Pages próximos não equivalentes; ver `Formato de Não Confundir com` |
| Sinais de escolha | Sim | Bullets | Evidências para selecionar o page pattern |
| Limites | Sim | Texto | Quando não usar |
| Grau de Rigidez | Sim | Alto/Médio/Baixo + nota | Quanto tolera variação |
| Zonas funcionais obrigatórias | Sim | Lista do Vocabulário de Zonas | Zonas que devem existir |
| UI Patterns tipicamente obrigatórios | Sim | Lista de UIP-* | UIPs esperados na composição |
| Compatibilidade Primária | Sim | Lista de SHP-* | Shells naturais |
| Compatibilidade Secundária | Sim | Lista de SHP-* | Shells possíveis |
| Incompatibilidades explícitas | Sim | Lista | Shells inadequados |
| Estrutura Desktop | Sim | Texto | Organização em viewport ampla |
| Estrutura Mobile | Sim | Texto | Organização em viewport estreita |
| Regra de transição | Sim | Texto | Invariantes desktop/mobile |
| Plataformas aplicáveis | Sim | Lista do vocabulário | Plataformas onde pode ser usado |
| Plataformas primárias | Sim | Lista do vocabulário | Plataformas naturais |
| Adaptação por Plataforma | Sim | Campos por plataforma | Instruções de adaptação |

## Campos de UIP-* (UI Patterns)

| Campo | Obrigatório | Tipo | Semântica |
|-------|-------------|------|-----------|
| Categoria | Sim | Keyword | Grupo funcional |
| Definição curta | Sim | Texto curto | Âncora semântica |
| Objetivo estrutural | Sim | Texto | Problema que resolve |
| Não confundir com | Sim | Lista | Patterns próximos não equivalentes; ver `Formato de Não Confundir com` |
| Nível composicional possível | Sim | Root/Container/Leaf | Posição na hierarquia |
| Quando usar | Sim | Texto | Condições positivas |
| Quando evitar | Sim | Texto | Condições negativas |
| Alternativas próximas | Sim | Lista de IDs de pattern | Patterns vizinhos navegáveis; ver `Formato de Não Confundir com` |
| Sinais de escolha | Sim | Bullets | Evidências de seleção |
| Grau de Rigidez | Sim | Alto/Médio/Baixo + nota | Quanto tolera variação |
| Zonas usuais | Sim | Lista do Vocabulário de Zonas | Zonas onde o pattern aparece |
| Variantes reconhecidas | Sim | Lista | Variantes estruturais; ver `Formato de Variantes reconhecidas` |
| UI Patterns tipicamente contidos | Condicional | Lista de UIP-* | Filhos aninhados; obrigatório quando container com filhos |
| UIPs frequentemente combinados | Condicional | Lista de UIP-* | UIPs que coexistem na mesma zona, sem aninhar |
| Compatibilidade com Shell Patterns | Opcional | Seção | Shells compatíveis |
| Compatibilidade com Page Patterns | Sim | Seção | Pages compatíveis |
| Compatibilidade Primária | Sim | Lista de PP-* | Pages típicas |
| Compatibilidade Secundária | Sim | Lista de PP-* | Pages possíveis |
| Incompatibilidades explícitas | Sim | Lista | Contextos incompatíveis |
| Estrutura Desktop | Sim | Texto | Organização em viewport ampla |
| Estrutura Mobile | Sim | Texto | Organização em viewport estreita |
| Regra de Transição | Sim | Texto | Invariantes desktop/mobile |
| Estados próprios | Sim | Lista | Estados percebidos pelo usuário |
| Reação a estados da página | Sim | Texto | Comportamento nos Estados de Página |
| Plataformas aplicáveis | Sim | Lista do vocabulário | Plataformas onde pode ser usado |
| Plataformas primárias | Sim | Lista do vocabulário | Plataformas naturais |
| Adaptação por Plataforma | Sim | Campos por plataforma | Instruções de adaptação |

### `tipicamente contidos` vs `frequentemente combinados`

- `tipicamente contidos`: filhos aninhados. Relação contêiner → filho. O hospedeiro é o inverso; não se declara no filho.
- `frequentemente combinados`: UIPs que coexistem na mesma zona ou página, sem aninhar.

UIP que entra dentro de outro vai em `tipicamente contidos` do contêiner.

## Formato de Sinais de Escolha

Bullets, cada um uma condição independente:

```markdown
**Sinais de escolha**:
- evidência concreta 1
- evidência concreta 2
```

Múltiplos sinais reforçam a escolha; um sinal forte pode bastar.

## Formato de Não Confundir com / Alternativas próximas

- `Alternativas próximas`: só IDs de pattern (UIP-*, PP-*, SHP-*), com glosa entre parênteses. Sem conceitos.
- `Não confundir com`: IDs de pattern com glosa, ou conceitos fora do catálogo marcados `(fora do catálogo)`.

Nunca usar nome de pattern sem ID.

## Formato de Variantes reconhecidas

Obrigatório em todo UIP-*. Variantes estruturais separadas por `;`. Pattern abstrato sem variantes: valor literal `Nenhuma reconhecida — pattern abstrato`. Nunca omitir.
