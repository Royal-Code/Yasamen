# {Pattern ID} - Blueprint resumido

{Arquivo destinado a IA consumidora (screen-coder, screen-designer). Code-first, autocontido, sem repetir pattern, ui-map ou sample. Para gap localizado coberto por composição de componentes existentes + recursos visuais. Pode propor wrapper/componente leve quando isso for o menor artefato útil.}

## Pattern

{ID — Name} — ver `{pattern-id}.md`

## Gap coberto

{1 parágrafo curto: qual ponto específico do pattern a lib não cobre nativamente e que o blueprint resolve por composição}

## Estratégia

- `tipo de artefato`: {composição apenas | wrapper/componente leve}
- `decisão`: {1 frase amarrando gap localizado + cobertura disponível + escolha}

## Componente proposto

{Omitir seção inteira quando o tipo de artefato for `composição apenas`. Usar apenas para wrapper/componente leve.}

### {ComponentName}

- `convenção de referência`: {padrão da biblioteca ou fallback da stack}
- `responsabilidade`: {1 frase}
- `API proposta`:
  - props: {...}
  - eventos: {...}
  - slots/children: {...}

## Componentes usados

- `{Component}` — papel: principal | composição — ver `{component}.sample.md`

## Recursos visuais

- {token/classe/recurso} — ver `visual.map.md`

## Receita

{1 frase instrutiva curta antes do código. Quando houver componente proposto, declarar/usar a API proposta de forma consistente e usar API real dos componentes existentes internamente.}

```{linguagem}
{código real e válido — uma única receita cobrindo o gap}
```

## Limites

- {o que continua lacuna, exige decisão humana ou depende de tecnologia externa}
