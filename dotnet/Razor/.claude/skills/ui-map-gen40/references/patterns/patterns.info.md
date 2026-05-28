# Patterns — Como Ler

Protocolo de leitura e interpretação dos patterns para IA e humanos.

## O que é pattern

Pattern é intenção estrutural e comportamento esperado. Não é componente, não é estilo visual, não é implementação técnica.

- Pattern define **o que** a zona faz e **como** se comporta estruturalmente.
- Componente é **com o que** se implementa — decidido depois, via `ui-map`.
- Estilo visual é **como parece** — decidido por `visual.language.md`, `visual.map.md` ou design system.

Se algo foca em um componente específico de uma biblioteca, já não é pattern.

## Ordem recomendada de leitura

1. Carregue `patterns.list.md` para scan rápido de candidatos.
2. Carregue `patterns.group.md` se precisar entender a taxonomia.
3. Identifique a plataforma de destino (Web, Mobile nativo, Desktop nativo, etc.).
4. Escolha primeiro o `SHP-*` quando o shell afetar navegação global ou densidade da experiência.
5. Escolha um `PP-*` dominante para cada tela.
6. Use os `UIP-*` para compor zonas, navegação, dados, entrada, ações, feedback, conteúdo, superfícies e capacidades de sistema.
7. Use os campos `Plataformas` e `Adaptação por Plataforma` de cada pattern para filtrar e adaptar.
8. Só abra o arquivo detalhado do pattern quando ele for candidato real.
9. Só mapeie para componentes reais depois de consultar o `ui-map` da biblioteca alvo.

## Leitura staged — quando carregar o quê

| Fase | Arquivo | Propósito |
|------|---------|-----------|
| Scan inicial | `patterns.list.md` | Identificar candidatos por definição curta |
| Contexto macro | `patterns.group.md` | Entender grupos disponíveis |
| Validação | `{pattern}.md` individual | Validar candidato real pelos campos completos |
| Referência | `patterns.schema.md` | Consultar significado de campos e regras |
| Primeira vez | `patterns.info.md` (este arquivo) | Entender protocolo de leitura |

## Regras de interpretação

- Campos de estrutura e plataforma descrevem invariantes estruturais e variantes aceitáveis; não definem estilo visual, breakpoint concreto, componente de biblioteca ou implementação técnica.
- Campos de plataforma (`Plataformas`, `Adaptação por Plataforma`) filtram e adaptam o pattern por plataforma. Não criam regra visual.
- Plataformas, zonas e estados de página usam vocabulários canônicos fechados, definidos em `patterns.schema.md`. O encaixe de um UIP numa página é a interseção entre as zonas do PP e as `Zonas usuais` do UIP.
- Linguagem visual, tokens, cor, tipografia, espaçamento, densidade estética e estilo pertencem a `visual.language.md`, `visual.map.md` ou regras do design system.
- O componente real só deve ser escolhido depois de consultar o `ui-map` da biblioteca alvo.
- `Sinais de escolha` em bullets permitem matching individual: cruze cada bullet com evidências da demanda.
- `Grau de Rigidez` com nota contextual indica quanto se pode desviar da estrutura canônica (ver significado em `patterns.schema.md`).
- `UIPs frequentemente combinados` indica coocorrência usual, não obrigatoriedade.

## Decisão entre patterns vizinhos

Quando dois patterns parecem candidatos equivalentes, use:

1. `Sinais de escolha` — qual tem mais bullets matching com a demanda?
2. `Não confundir com` — há distinção explícita?
3. `Quando usar` vs `Quando evitar` — algum critério elimina um candidato?
4. `Compatibilidade` — qual se encaixa melhor no shell/page já escolhido?
5. `Grau de Rigidez` — qual dá mais ou menos liberdade conforme a necessidade?

## Composição de tela

A composição segue a hierarquia:

```
Shell (SHP-*) → Page (PP-*) → UI Patterns (UIP-*)
```

- Um shell contém múltiplas páginas.
- Uma página é composta por múltiplos UIPs.
- UIPs podem conter outros UIPs (container → leaf), declarado em `UI Patterns tipicamente contidos` do contêiner.
- Telas autônomas, sem navegação global — autenticação, erro em página cheia, splash, confirmação isolada — usam o shell mínimo `SHP-FOCUSED`. A hierarquia `SHP → PP → UIP` é sempre preservada; não há tela sem shell.
- `Compatibilidade Primária` e `Compatibilidade Secundária` são orientativas e ranqueiam escolhas. Só `Incompatibilidades explícitas` é eliminatória. Ver `patterns.schema.md`.
