# Spec Station

> Use este arquivo como ponto único de entrada para interpretar o pedido do humano e encaminhar para o domínio correto de spec ou de execução no repositório.

## Objetivo

`Spec Station` fica acima dos orquestradores de domínio.

Ele não executa tudo diretamente. O papel dele é:

- interpretar o pedido;
- classificar o tipo de trabalho;
- escolher o orquestrador, instrução ou modo de execução mais adequado;
- manter a conversa curta e previsível na entrada.

Nesta organização, `station` é a porta de entrada portátil para:

- `screen-spec`
- `yasamen`

Expansão da biblioteca fica fora do escopo direto desta entrada e deve usar `.ai/lib-spec.md`.

Regra operacional:

- quando o pedido entra por `station`, a saída padrão é roteamento e próximo passo;
- `station` não deve scaffoldar projeto, editar código ou implementar diretamente por reflexo.

---

## Famílias Atuais

### 1. `screen-spec`

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

### 2. `yasamen`

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

- `app-spec`
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
- Quando houver spec existente, preferir reutilizá-la.
- Quando houver apenas requisitos vagos, preferir planeamento antes de implementação.
- Quando o pedido for de expansão da biblioteca, encaminhar para `.ai/lib-spec.md`.

---

## Exemplos de Uso

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

