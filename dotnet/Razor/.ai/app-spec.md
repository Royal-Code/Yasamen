# Orquestrador de App Specs

> Use este arquivo como ponto de entrada para planejar apps consumidores, criar ou refinar `app specs` e preparar a base estrutural de projetos Blazor que usam Yasamen.

## Escopo

Este orquestrador trata:

- novo app consumidor que usa Yasamen;
- evolução estrutural de app consumidor existente;
- definição de shell, layout e navegação do app;
- definição de pacotes, serviços e estilos públicos;
- relação entre app, telas e `screen specs`;
- geração de `app spec`.

Ele não substitui:

- `.ai/screen-spec.md` para tela;
- `.ai/lib-spec.md` para expansão da biblioteca;
- `yasamen` para execução direta quando a solução já estiver clara.

## Roteamento de Intenções

### 1. Planejar um app consumidor

Pedido típico:

- `quero planejar um novo app com Yasamen`
- `planeje a base do app x`

Fluxo:

- `.ai/instructions/flows/apps/plan-app.md`

Regra:

- usar este fluxo quando o utilizador quiser planeamento explícito por gates;
- se a informação já for suficiente para abrir a `app spec`, preferir `.ai/instructions/flows/apps/create-app-spec.md`.

### 2. Criar uma app spec

Pedido típico:

- `crie a app spec x`
- `gere a spec do app x`

Fluxo:

- `.ai/instructions/flows/apps/create-app-spec.md`

Regra:

- este é o fluxo preferencial quando o utilizador quer “planejar” um app e já há informação suficiente para materializar a spec;
- se faltar informação, pedir lista enumerada do que falta para preencher os campos essenciais da spec.

### 3. Refinar uma app spec existente

Pedido típico:

- `refine a app spec x`
- `fortaleça a spec do app x`

Fluxo:

- `.ai/instructions/flows/apps/refine-app-spec.md`

### 4. Alterar um app existente

Pedido típico:

- `quero reorganizar o app x`
- `mude a base estrutural do app x`

Fluxo:

- se já existir `app spec`:
  - `.ai/instructions/flows/apps/refine-app-spec.md`
- se não existir:
  - capturar `As-Is`;
  - criar a app spec;
  - registrar o `To-Be`.

### 5. Desdobrar telas do app

Pedido típico:

- `quais telas esse app precisa`
- `quais screens devemos abrir`

Fluxo:

- fechar primeiro a `app spec`;
- depois derivar `screen specs` com `.ai/screen-spec.md`.

## Regras de Qualidade

- Usar sempre acentuação.
- Não detalhar componente dentro da `app spec`.
- Não esconder gap da biblioteca como convenção local do app.
- Fechar os checkpoints de `.ai/guides/rules/cross-cutting-app-decisions.md`.
- Encaminhar para `.ai/screen-spec.md` quando a dúvida ficar específica de uma tela.
- Encaminhar para `.ai/lib-spec.md` quando surgir expansão da biblioteca.
- Não responder só com explicação do fluxo quando já for possível abrir ou refinar a `app spec`.
- Quando faltar informação, pedir lista enumerada única do que precisa ser conhecido para continuar.
- Quando o pedido envolver app novo, a `app spec` deve cobrir criação do projeto, referências, `Program.cs`, `_Imports.razor`, estilos públicos e validação base.
- Quando o pedido envolver módulos corporativos, a `app spec` deve decidir explicitamente a estratégia inicial de dados, autenticação e integrações.
- Distinguir explicitamente referências e pacotes `confirmados` de referências e pacotes `candidatos`.
- Não usar exemplos de famílias de componentes do repositório para ancorar perguntas quando o utilizador já estiver a falar em módulos de negócio.
- Referências ao repositório atual podem entrar apenas como apoio técnico local, não como justificativa central do app.
- Ao criar a `app spec`, `tasks.md` deve nascer como backlog pendente, não como checklist já concluído.
- Ao criar a `app spec`, deixar claro que critérios marcados dizem respeito à completude da spec, não à implementação do app.

## Exemplos de Uso

```text
Leia `.ai/app-spec.md` e quero planejar um novo app Blazor administrativo com Yasamen.
```

```text
Leia `.ai/app-spec.md` e crie a app spec `backoffice-admin`.
```

```text
Leia `.ai/app-spec.md` e refine a app spec `portal-cliente`.
```
