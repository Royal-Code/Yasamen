# UI Map Manifest — {nome da biblioteca}

## Metadados

```yaml
manifest_version: 4
generated_at: "{YYYY-MM-DD}"
library:
  name: "{nome}"
  slug: "{slug-dash-case}"
  version: "{versão ou desconhecida}"
  source_ref: "{path|URI|desconhecido}"
  platforms: [Web] # Web|Mobile nativo|Desktop nativo
  technical_family: "{web|theme|ui-resources|presentation|none}"
auxiliary_libraries:
  - name: "{nome}"
    purpose: "{papel}"
    source_ref: "{referência}"
pattern_catalog:
  version: "{versão dos catálogos usados}"
```

## Resumo da rodada

- Componentes mapeados: `{n}`
- Patterns avaliados: `{n}`
- UI-Map gerados: `{n}`
- Samples gerados: `{n}`
- Blueprints gerados: `{n}`
- Rules corporativas: `{n}`
- Orientações de patterns: {n}

## Artefatos para consumo

| Artefato | Local | Utilidade |
|---|---|---|
| `visual.language.md` | `visual.language.md` | Linguagem visual consolidada da biblioteca. |
| `visual.map.md` | `visual.map.md` | Recursos visuais concretos disponíveis. |
| `patterns.table.md` | `ui-map/patterns.table.md` | Índice de cobertura entre patterns e componentes. |
| `patterns.orientations.md` | `patterns.orientations.md` | Preferências de uso de patterns para gerar telas alinhadas à biblioteca. |
| `ui-map` | `ui-map/*.ui-map.md` | Mapeamento detalhado por pattern. |
| `samples` | `samples/*.sample.md` | Exemplos operacionais de uso real dos componentes. |
| `blueprints.table.md` | `patterns-blueprints/blueprints.table.md` | Índice de blueprints gerados, reclassificados ou não gerados. |
| `blueprints` | `patterns-blueprints/*.blueprint.md` | Soluções para gaps e composições recomendadas. |
| `rules` | `rules/*.rules.md` | Regras corporativas consumíveis, quando existirem. |
