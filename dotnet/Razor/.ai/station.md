# Spec Station

> Use este arquivo como ponto único de entrada para interpretar o pedido do humano e encaminhar para o domínio correto de spec ou de execução no repositório.

## Objetivo

`Spec Station` fica acima dos orquestradores de domínio.

Ele não executa tudo diretamente. O papel dele é:

- interpretar o pedido;
- classificar o tipo de trabalho;
- escolher o orquestrador, instrução ou modo de execução mais adequado;
- manter a conversa curta e previsível na entrada.

Regra operacional:

- quando o pedido entra por `station`, a saída padrão é roteamento e próximo passo;
- `station` não deve scaffoldar projeto, editar código ou implementar diretamente por reflexo.

---

## Famílias Atuais

### 1. `lib-spec`

Usar para:

- componentes novos da biblioteca;
- specs de componente;
- specs de pacote;
- criação orientada por spec de pacote de biblioteca `RoyalCode.Razor.*`;
- implementação de spec técnica já existente.

Entrada:

- `.ai/lib-spec.md`

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

### Pedido de componente ou pacote da biblioteca

Fluxo:

- `.ai/lib-spec.md`

Regra:

- pedido de pacote ou projeto novo entra em `lib-spec` por padrão como fluxo orientado por spec;
- scaffolding direto só deve acontecer quando o utilizador pedir isso explicitamente ou chamar `.ai/instructions/expand/create-library-project.md`.

### Pedido de tela ou página

Fluxo:

- `.ai/screen-spec.md`

### Pedido de ajuste direto no repositório

Fluxo:

- `yasamen`, com apoio de guides, specs e instruções já existentes.

### Pedido de domínio ainda não formalizado

Fluxo:

- explicar que a família ainda não existe como orquestrador;
- sugerir formalização da família antes de escalar o sistema;
- quando possível, apoiar com `yasamen` ou com spec de domínio embrionária.

---

## Regras de Qualidade

- Usar sempre acentuação.
- Preferir orquestradores de domínio a instruções soltas.
- Não misturar tela com componente.
- Não misturar pedido de execução direta com criação automática de spec sem necessidade.
- Pedido de projeto novo via `station` deve ser tratado como `spec-first` por padrão.
- Quando houver spec existente, preferir reutilizá-la.
- Quando houver apenas requisitos vagos, preferir planeamento antes de implementação.

---

## Exemplos de Uso

```text
Leia `.ai/station.md` e quero planejar a tela de listagem de clientes.
```

```text
Leia `.ai/station.md` e crie o componente `button-group`.
```

```text
Leia `.ai/station.md` e quero um novo pacote `RoyalCode.Razor.Navigation`; primeiro planeje ou crie a spec e depois prepare o projeto.
```

```text
Leia `.ai/station.md` e implemente a spec `pagination`.
```

```text
Leia `.ai/station.md` e ajuste a documentação atual do Docs.Client sem criar spec nova.
```

