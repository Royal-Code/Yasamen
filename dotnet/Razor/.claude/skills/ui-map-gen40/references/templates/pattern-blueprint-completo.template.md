# {Pattern ID} - Blueprint completo

{Arquivo destinado a IA consumidora (screen-coder, screen-designer). Code-first, autocontido, sem repetir pattern, ui-map ou sample. Para gap estrutural, comportamental, responsivo, de shell, navegação ou coordenação. Pode propor um ou mais componentes novos.}

## Pattern

{ID — Name} — ver `{pattern-id}.md`

## Gap coberto

{O que falta na lib: estrutural, comportamental, responsivo, shell, navegação ou coordenação. Resume o resultado da Lente 1 sem repetir o pattern em si.}

## Estratégia

- `tipo de artefato`: {composição apenas | wrapper/componente leve | componente novo único | compound de componente novo | conjunto de componentes novos atômicos coordenados | componente novo standalone}
- `decisão`: {1 frase amarrando nota do principal + tipo de gap + cobertura disponível → escolha}
- `eixos cobertos sem componente novo`:
  - {eixo} → {como será coberto: utility, composição, padrão de receita}

## Componentes propostos

{Omitir seção inteira quando o tipo de artefato for `composição apenas`. Quando o gap exige múltiplos componentes coordenados, listar cada um com seu contrato.}

### {ComponentName}

- `convenção de referência`: {nome de convenção + origem — ex: "Section — shadcn/HTML5 + estilo da biblioteca"}
- `responsabilidade`: {1 frase}
- `API proposta`:
  - props: {...}
  - eventos: {...}
  - slots/children: {...}
- `subcomponentes`: {lista ou `-`}
- `estados internos`: {lista ou `-`}

### Relação entre os propostos

{Omitir quando houver só um componente proposto. Descrever em bullets curtos como os componentes propostos compõem entre si e quais combinações cobrem quais cenários de tela.}

- {Component1 + Component2}: cobre {cenário};
- {Component1 sozinho}: cobre {cenário};

## Componentes usados

{Omitir quando não usar nenhum componente existente da lib.}

- `{Component}` — papel: principal | composição — ver `{component}.sample.md`

## Recursos visuais

- {tokens, classes, recursos} — ver `visual.map.md`

## Receita

### Estrutura base

{Esqueleto integrado mostrando como as partes se montam no cenário mais rico. Quando houver múltiplos componentes propostos, mostrar todos compondo aqui.}

```{linguagem}
{código integrado}
```

### Cenários de composição

{Omitir seção quando houver apenas um componente proposto e a receita for única. Quando o conjunto compõe de formas distintas para tipos de tela diferentes, mostrar 2-4 cenários canônicos.}

#### {cenário 1 — ex: tela simples}

```{linguagem}
{código mínimo}
```

#### {cenário 2 — ex: list-detail}

```{linguagem}
{código intermediário}
```

### Estados de página

{Omitir bullets não aplicáveis ao pattern. Omitir seção inteira se nenhum estado de página se aplica.}

## Limites

- {o que continua lacuna, exige decisão humana ou depende de tecnologia externa}

- `loading`:
```{linguagem}
{código}
```
- `empty`:
```{linguagem}
{código}
```
- `error`:
```{linguagem}
{código}
```
- `no-permission`:
```{linguagem}
{código}
```

### Interações

{Omitir quando o pattern não tem comportamento próprio relevante.}

```{linguagem}
{código}
```

### Coordenação

{Omitir quando não há orquestração entre componentes.}

```{linguagem}
{código}
```

### Responsividade

{Omitir quando não houver adaptação relevante. Pode ser código ou regras em prosa curta.}

```{linguagem ou descrição}
```

## Limites

- {o que continua lacuna};
- {o que depende de tecnologia externa};
- {o que depende de decisão humana ou de escopo do app consumidor}.
