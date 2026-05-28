# {Componente} - Sample

{Arquivo destinado a IA consumidora (screen-coder, screen-designer, patterns-blueprints). Code-first, autocontido, sem repetir ui-map nem summary.}

## Contrato de uso

**Entrada pública**: {import, tag, namespace, pacote ou módulo}
**Grupo**: {grupo funcional declarado em `components.summary.md`}
**Propósito**: {1 frase}
**Patterns**:
- `implementa`: {PATTERN_IDs separados por vírgula, ou `-`}
- `compõe`: {PATTERN_IDs separados por vírgula, ou `-`}
**Setup necessário**: {provider, tema, CSS global, namespace, plugin, serviço ou `-` quando só o import basta}
**Versão**: {adicionar **Versão** somente se a API demonstrada depender de versão específica.}

## Regras rápidas

- **Use para**: {cenário concreto curto}
- **Evite quando**: {cenário com alternativa concreta — sempre indicar o componente correto. Ex: "usar Badge como botão; use IconButton". Omitir bullet se não houver fronteira real}
- **Cuidado**: {limite, default ou combinação frágil de alto impacto. Omitir bullet se não houver}

## Exemplos

{Um exemplo por PATTERN_ID declarado em `implementa` ou `compõe`. Um exemplo pode cobrir múltiplos patterns quando o título declara todos. Exemplos adicionais somente para estado, evento, default ou combinação frágil crítica não coberta nos exemplos por pattern.}

### `{PATTERN_ID[, PATTERN_ID...]}` — {cenário curto}

{Uma frase instrutiva curta antes do código.}

```{linguagem}
{código real, válido, compilável; dados não-triviais mas controlados (2-4 itens, 3-5 campos); imports explícitos quando standalone}
```

**API usada**: {props/eventos/slots relevantes do exemplo, inline. Omitir quando o código for auto-evidente (3-4 linhas)}
**Nota**: {quirk, default não óbvio, comportamento `[inferido]` ou workaround relevante. Omitir quando não houver}

## API relevante

{Catálogo crítico do componente — complementa o `API usada` inline dos exemplos. `API usada` é scan local por exemplo; `API relevante` lista o que é crítico para evitar uso incorreto fora dos cenários mostrados. Declarar apenas a API usada nos exemplos OU crítica para evitar uso incorreto. Não catalogar API completa.

Componente simples: bullets curtos; tabela opcional.
Componente médio: bullets com tipo curto quando ajuda; tabela quando há props que interagem.
Componente complexo: tabela com `prop | quando usar | impacto` para props com default surpreendente, shapes complexos ou interações não-aditivas.}

- **Props/parâmetros**: {somente API usada nos exemplos ou crítica para evitar uso incorreto, ou `-`}
- **Eventos/comandos**: {somente relevantes, com payload quando não óbvio, ou `-`}
- **Slots/children/conteúdo**: {somente relevantes, ou `-`}
- **Estados/variantes**: {somente relevantes, ou `-`}

## Limites e combinações frágeis

{Comportamentos do próprio componente que falham, truncam ou exigem workaround, com evidência em código, docs ou stories. Não inventar. Omitir seção se não houver.}

- {limitação ou combinação frágil de alto impacto, com workaround quando existir}

## Defaults importantes

{Seção opcional. Incluir apenas quando o componente tem defaults que mudam comportamento relevante e o leitor pode errar por desconhecê-los. Omitir seção se não houver.}

- `{prop}` default `{valor}`: {impacto}
