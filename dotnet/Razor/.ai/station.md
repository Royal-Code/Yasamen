# Spec Station

> Use este arquivo como ponto único de entrada para interpretar o pedido do humano e encaminhar para o domínio correto de spec ou de execução no repositório.

## Objetivo

`Spec Station` fica acima dos orquestradores de domínio.

Ele não deve parar na explicação do roteamento. O papel dele é:

- interpretar o pedido;
- classificar o tipo de trabalho;
- escolher o orquestrador, instrução ou modo de execução mais adequado;
- manter a conversa curta e previsível na entrada;
- executar o fluxo escolhido até onde for seguro avançar.

Nesta organização, `station` é a porta de entrada portátil para:

- `app-spec`
- `screen-spec`
- `yasamen`

Expansão da biblioteca fica fora do escopo direto desta entrada e deve usar `.ai/lib-spec.md`.

Regra operacional:

- quando o pedido entra por `station`, o roteamento pode ser silencioso;
- a saída padrão deve ser seguir o fluxo escolhido, não apenas explicá-lo;
- se houver informação suficiente, materializar o próximo artefato ou etapa do fluxo;
- se faltar informação, listar em uma resposta enumerada tudo o que precisa ser conhecido para executar a próxima etapa;
- `station` não deve scaffoldar projeto, editar código ou implementar diretamente por reflexo.

---

## Famílias Atuais

### 1. `app-spec`

Usar para:

- novo app consumidor com Yasamen;
- reorganização estrutural de app existente;
- shell, layout, navegação e convenções do app;
- relação entre app, telas, pacotes e serviços públicos;
- `app specs`.

Entrada:

- `.ai/app-spec.md`

### 2. `screen-spec`

Usar para:

- telas novas;
- alteração de telas existentes;
- `Page Pattern`;
- zonas funcionais;
- `UIP-*`;
- mapeamento de tela para Yasamen;
- `screen specs`.

Entrada:

- `.ai/screen-spec.md`

### 3. `yasamen`

Usar para:

- implementação direta no repositório;
- ajustes, refactors, docs, showcase e revisão;
- execução guiada por specs já existentes;
- tarefas que precisam seguir guides e instruções, mas sem abrir spec nova por padrão.

Regra:

- `yasamen` segue guides, specs existentes e instruções aplicáveis;
- não cria spec nova por padrão, a menos que o utilizador peça isso explicitamente.

### Fora do escopo desta entrada: `lib-spec`

Usar `.ai/lib-spec.md` diretamente para:

- componentes novos da biblioteca;
- specs de componente;
- specs de pacote;
- criação orientada por spec de pacote de biblioteca `RoyalCode.Razor.*`;
- implementação de spec técnica de expansão da biblioteca.

---

## Famílias Planejadas

Estas famílias ainda não estão formalizadas, mas o `Spec Station` já deve tratá-las como expansão natural do sistema:

- `api-spec`
- `domain-spec`
- `use-case-spec`
- `ef-spec`
- `messaging-spec`

Se o pedido cair em uma dessas famílias:

- deixar explícito que o domínio ainda não está formalizado;
- não fingir que já existe orquestrador completo;
- sugerir o próximo passo mais próximo disponível.

---

## Roteamento de Intenções

### Pedido de tela ou página

Fluxo:

- `.ai/screen-spec.md`

Regra:

- se houver informação suficiente para abrir a `screen spec`, seguir direto para isso;
- se faltar informação, pedir lista enumerada do que falta;
- usar o fluxo puramente colaborativo só quando o utilizador pedir planeamento iterativo.

### Pedido de app consumidor

Fluxo:

- `.ai/app-spec.md`

Regra:

- se houver informação suficiente para abrir a `app spec`, seguir direto para isso;
- se faltar informação para abrir a `app spec` ou para preparar o projeto, pedir lista enumerada do que falta;
- usar o fluxo puramente colaborativo de planeamento só quando o utilizador pedir isso explicitamente ou quando o problema ainda estiver muito aberto.

### Pedido de ajuste direto no repositório

Fluxo:

- `yasamen`, com apoio de guides, specs e instruções já existentes.

### Pedido de expansão da biblioteca

Fluxo:

- `.ai/lib-spec.md`

Regra:

- `station` não executa nem orquestra expansão da biblioteca por padrão;
- quando o pedido for de componente, pacote ou spec de expansão, a saída deve ser encaminhar para `.ai/lib-spec.md`;
- scaffolding direto continua fora do `station` e só deve acontecer por pedido explícito.

### Pedido de domínio ainda não formalizado

Fluxo:

- explicar que a família ainda não existe como orquestrador;
- sugerir formalização da família antes de escalar o sistema;
- quando possível, apoiar com `yasamen` ou com spec de domínio embrionária.

---

## Regras de Qualidade

- Usar sempre acentuação.
- Preferir orquestradores de domínio a instruções soltas.
- Não misturar tela com componente ou expansão da biblioteca.
- Não misturar pedido de execução direta com criação automática de spec sem necessidade.
- Não responder apenas com “o fluxo correto é x” quando já for possível executar `x`.
- Quando houver spec existente, preferir reutilizá-la.
- Quando houver apenas requisitos vagos, preferir planeamento antes de implementação.
- Quando o pedido for de expansão da biblioteca, encaminhar para `.ai/lib-spec.md`.
- Não inventar informação ausente só para completar template ou flow.
- Quando faltar informação, perguntar em lista enumerada única, não uma pergunta por vez.

---

## Exemplos de Uso

```text
Leia `.ai/station.md` e quero planejar um novo app Blazor administrativo com Yasamen.
```

```text
Leia `.ai/station.md` e quero planejar a tela de listagem de clientes.
```

```text
Leia `.ai/station.md` e quero criar ou editar uma tela de pedidos usando Yasamen.
```

```text
Leia `.ai/station.md` e quero ajustar uma tela existente de pedidos sem abrir spec nova.
```

```text
Leia `.ai/station.md` e ajuste a documentação atual do Docs.Client sem criar spec nova.
```

```text
Leia `.ai/station.md` e quero criar um componente novo da biblioteca; encaminhe para o fluxo correto.
```

