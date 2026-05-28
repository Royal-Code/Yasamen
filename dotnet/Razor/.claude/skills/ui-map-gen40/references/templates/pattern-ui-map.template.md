# {Pattern ID} - {Pattern Name}

{informar os componentes de forma enumerada, conforme cada grupo}

## Componentes

**Principais**:

1. {nome do componente}
- `cobertura`: {tipo de cobertura: descrever resumidamente como o componente cobre cada um dos requisitos do pattern (nativo, composição, parcial, ausente)};
- `limitações`: {definir limitações de uso do componente em relação à adaptação ao pattern. O que não funciona, o que precisa de workaround, o que quebra em determinadas condições};
- `nota`: {nota 0-10, **Rubrica A — Componente Principal** do protocolo};
- `justificativa`: {justificar a nota e a escolha}.

**Composição**:

1. {nome do componente}
- `cobertura`: {tipo de cobertura: descrever resumidamente como o componente cobre os requisitos do pattern (nativo, composição, parcial, ausente)};
- `limitações`: {definir limitações de uso do componente em relação à adaptação ao pattern. O que não funciona, o que precisa de workaround, o que quebra em determinadas condições};
- `nota`: {nota 0-10, **Rubrica B — Componente em Composição** do protocolo};
- `justificativa`: {justificar a nota e a escolha}.

**Descartados**:

1. {nome do componente}
- `motivo`: {descrever o motivo do descarte}.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `{requisito}`: {observação curta; componente/recurso relacionado; impacto}

- `tipo de adaptação`: {descrever tipo de adaptação conforme protocolo}
- `o que precisa ser feito`: {descrever em bullets}
  - {descrever de forma direta};

## Como usar

{Ao menos um exemplo de código fonte válido para usar cada componente de forma a atender os requisitos do pattern}
{Cenários derivados da combinação de componentes principais e de composição}
{Seguir regras do template}
{Deve ser código real, funcional, usar a linguagem visual e as regras de estilo}
{Exemplos não podem inventar API nem comportamento não observado nos componentes. Se um comportamento for inferido, marcar explicitamente como `[inferido]`}

### {cenário ou componente}

```{linguagem}
{exemplo de uso}
```

## Decisão de uso

- `nota geral`: {nota 0-10, **Rubrica C — Nota Geral do pattern** do protocolo};
- `limitações`: {descrever limitações no geral para usar o pattern com os componentes, linguagem visual e visual.map}
- `recomendação`: `{usar direto|usar por composição|usar com adaptação|usar apenas como apoio|evitar}`
- `justificativa geral`: {bullets explicando **detalhadamente** o motivo da nota, recomendação, componentes usados, limitações. Não pode ser genérico. Deve mencionar o que o componente faz bem, o que falta, e por que a nota é essa e não outra}
