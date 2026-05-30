# UI Map Manifest — yasamen-razor

## Metadados

```yaml
manifest_version: 4
generated_at: "2026-05-28"
library:
  name: "yasamen-razor"
  slug: "yasamen-razor"
  version: "desconhecida"
  source_ref: "repo local"
  platforms: [Web]
  technical_family: "web"
auxiliary_libraries: []
pattern_catalog:
  version: "desconhecida"
```

## Resumo da rodada

- Componentes mapeados: `40`
- Patterns avaliados: `105`
- UI-Maps gerados: `98`
- Samples gerados: `40`
- Blueprints gerados: `66`
- Rules corporativas: `3` (índice + 2 específicas)
- Orientações de patterns: `13 tipos de tela`

## Artefatos para consumo

| Artefato | Local | Utilidade |
|---|---|---|
| `visual.language.md` | `visual.language.md` | Linguagem visual consolidada — paleta semântica, tokens, enums, builders e padrões de estilo da biblioteca. |
| `visual.map.md` | `visual.map.md` | Recursos visuais concretos por intenção de tela — classes, tokens e combinações prontas para aplicar. |
| `components.summary.md` | `components.summary.md` | Inventário de todos os 40 componentes com papel, API resumida e padrões de uso. |
| `patterns.table.md` | `ui-map/patterns.table.md` | Índice de cobertura: 105 patterns × componentes yasamen-razor, com nota, gap e recomendação. |
| `patterns.orientations.md` | `patterns.orientations.md` | Preferências de uso de patterns por tipo de tela, combinações recomendadas e patterns a evitar. |
| `ui-maps` | `ui-map/*.ui-map.md` | Mapeamento detalhado por pattern — cobertura, limitações, nota e exemplo de uso. |
| `samples` | `samples/*.sample.md` | 40 samples operacionais — API real, variantes, comportamentos e exemplos prontos por componente. |
| `blueprints.table.md` | `patterns-blueprints/blueprints.table.md` | Índice de blueprints: triagem, classificação final, tipo de artefato e limites declarados. |
| `blueprints` | `patterns-blueprints/*.blueprint.md` | 66 blueprints de composição — receitas para gaps estruturais, shells, patterns de página e coordenação de componentes. |
| `corporate.rules.md` | `rules/corporate.rules.md` | Índice de rules corporativas: roteamento, regras transversais e ordem de leitura por tarefa. |
| `bootstrap.rules.md` | `rules/bootstrap.rules.md` | Regras de bootstrap: registro de serviços DI, injeção de CSS e placement de outlets. |
| `shell-selection.rules.md` | `rules/shell-selection.rules.md` | Regras de seleção de shell: quando usar AppLayout vs shell customizado por tipo de aplicação. |
