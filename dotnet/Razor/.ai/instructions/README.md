# Instructions — RoyalCode.Razor

> Instruções operacionais reutilizáveis para iniciar novos chats com menos contexto manual.

## Arquivos Disponíveis

| Arquivo | Uso |
|---|---|
| `../spec.md` | Orquestrador de entrada única para escolher, planejar, criar, refinar ou implementar specs |
| `plan-spec.md` | Planejar uma spec em colaboração com o utilizador, por gates e etapas aprovadas |
| `create-spec.md` | Criar ou revisar uma spec completa a partir do template e dos guides |
| `refine-spec.md` | Fortalecer uma spec existente antes da implementação |
| `implement-spec.md` | Executar uma spec completa: ler, validar, implementar, testar, revisar e concluir |
| `select-next-spec.md` | Analisar o planeamento atual e recomendar a próxima spec a criar, refinar ou implementar |

## Uso Recomendado

Fluxo orquestrado de entrada única:

```text
Leia `.ai/spec.md` e quero planejar a próxima spec.
```

Ou:

```text
Leia `.ai/spec.md` e implemente a spec `pagination`.
```

Ou:

```text
Leia `.ai/spec.md` e refine a spec `tabs`.
```

Para planeamento colaborativo com gates:

```text
Leia `.ai/instructions/plan-spec.md` e planeje a spec `search-field`.
```

Ou:

```text
Leia `.ai/instructions/plan-spec.md` e planeje a próxima spec.
```

Em um novo chat, use também prompts curtos como:

```text
Leia `.ai/instructions/implement-spec.md` e implemente a spec `pagination`.
```

Ou:

```text
Leia `.ai/instructions/implement-spec.md` e execute a spec `docs-showcase-foundation`.
```

Para criar uma spec nova:

```text
Leia `.ai/instructions/create-spec.md` e crie a spec `search-field`.
```

Ou:

```text
Leia `.ai/instructions/create-spec.md` e crie a spec `tabs`.
```

Para refinar uma spec existente:

```text
Leia `.ai/instructions/refine-spec.md` e refine a spec `pagination`.
```

Ou:

```text
Leia `.ai/instructions/refine-spec.md` e fortaleça a spec `docs-showcase-foundation`.
```

Para decidir o próximo passo:

```text
Leia `.ai/instructions/select-next-spec.md` e diga qual deve ser a próxima spec.
```

Ou:

```text
Leia `.ai/instructions/select-next-spec.md` e diga se o próximo passo deve ser criar, refinar ou implementar alguma spec.
```

## Convenção

- O nome da spec corresponde à pasta em `.ai/specs/<nome-da-spec>/`.
- A instrução operacional é responsável por localizar e ler:
  - `requirements.md`
  - `design.md`
  - `tasks.md`
  - `delivery.md`
- Specs novas devem nascer a partir de `.ai/specs/_template/`.
- `plan-spec.md` é o fluxo colaborativo com gates.
- `create-spec.md` é o fluxo direto para gerar a spec inteira.
- `../spec.md` pode ser usado como ponto único de entrada para rotear o fluxo certo.
