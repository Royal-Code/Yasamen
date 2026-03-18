# Como Escolher Padrões de Outlet

> Como decidir entre serviço global, componente com handler + outlet ou comportamento local ao modelar overlays e componentes interativos semelhantes.

---

## Papel Deste Guide

Este guide é decisório.

Ele existe para responder:

- qual família de arquitetura escolher para um recurso novo;
- quais sinais indicam o padrão certo;
- quais sintomas mostram modelagem errada.

Para ver como os casos reais do repositório já funcionam, usar [service-pattern.md](service-pattern.md).

---

## Três Famílias Relevantes

Hoje a biblioteca já sugere três famílias arquiteturais:

1. serviço global com outlet global;
2. componente declarado com handler e outlet;
3. componente com comportamento local, sem outlet global.

No repositório atual:

- `Notification` representa a família 1;
- `Modal` e `OffCanvas` representam a família 2;
- `Drop` é o melhor exemplo aproximado da família 3.

---

## Perguntas de Decisão

Antes de criar um overlay ou recurso semelhante, responda:

1. o conteúdo existe como instância declarada pelo consumidor?
2. o recurso precisa ser disparado por DI de qualquer lugar?
3. ele precisa renderizar fora do ponto onde foi declarado?
4. ele precisa coordenar pilha, backdrop, placement ou exclusão entre instâncias?
5. ele vive naturalmente no próprio local do componente?

As respostas definem a tendência do padrão.

---

## Padrão A - Serviço Global + Outlet Global

### Quando usar

Use quando o recurso:

- é global à sessão ou à árvore de UI;
- pode ser disparado por DI a partir de qualquer lugar;
- não depende de `Handler` por instância;
- funciona como fila, coleção ou canal global.

### Características esperadas

- façade pública pequena;
- service `Scoped`;
- outlet hospedado no layout;
- item ou estado interno enxuto;
- re-render coordenado centralmente.

### Exemplo atual

Ver `Notification` no guide 08.

---

## Padrão B - Componente Declarado + Handler + Outlet

### Quando usar

Use quando o recurso:

- é declarado pelo consumidor no markup;
- possui `ChildContent`, slots ou parâmetros próprios;
- precisa abrir e fechar por uma surface pública simples;
- precisa renderizar em outra região da árvore;
- mantém ciclo de vida identificável por instância.

### Características esperadas

- componente público declarado;
- handler público mínimo;
- service interno `Scoped`;
- projeção com `SectionContent` / `SectionOutlet`, quando aplicável;
- layout hospeda o outlet correspondente.

### Exemplos atuais

Ver `Modal` e `OffCanvas` no guide 08.

---

## Padrão C - Comportamento Local sem Outlet Global

### Quando usar

Use quando o recurso:

- vive onde foi declarado;
- não precisa ser global;
- não precisa de renderização deslocada por layout;
- depende mais de comportamento local do que de orquestração global.

### Características esperadas

- componente público direto;
- parâmetros e eventos como surface principal;
- interações locais;
- service interno apenas se realmente necessário;
- nenhum outlet global no layout.

### Exemplo aproximado

`Drop`

---

## Matriz de Decisão

| Pergunta | Se sim | Tendência |
|---|---|---|
| Pode ser disparado por DI de qualquer lugar? | Sim | Padrão A |
| O consumidor precisa declarar conteúdo próprio no markup? | Sim | Padrão B |
| Precisa renderizar fora do ponto de declaração? | Sim | Padrão B ou A |
| Existe instância pública identificável com ciclo próprio? | Sim | Padrão B |
| O comportamento é estritamente local ao componente? | Sim | Padrão C |

---

## Surface Pública Mínima

### Padrão A

- façade pública;
- extensão de DI;
- nada de namespace interno na surface do consumidor.

### Padrão B

- componente público;
- handler público;
- extensão de DI;
- nada além disso.

### Padrão C

- componente público;
- parâmetros e eventos;
- serviços internos só se houver motivo técnico real.

---

## Regras Arquiteturais

### Namespaces

- público: `RoyalCode.Razor.Components`;
- interno: `RoyalCode.Razor.Internal.*`.

### Layout

Se o padrão exigir outlet, a presença dele no layout faz parte do contrato do pacote.

Isso deve aparecer:

- na spec;
- no showcase;
- na documentação do pacote;
- e na instalação, quando necessário.

### State service

Para UI state compartilhado:

- usar `Scoped`;
- manter o estado enxuto;
- não misturar regra de negócio com estado de exibição;
- manter a API interna coerente com o padrão escolhido.

---

## Sinais de Erro de Modelagem

Há forte chance de o padrão estar errado quando:

1. um overlay global exige `Handler` por instância sem necessidade;
2. um componente declarado tenta ser disparado só por DI e perde seu conteúdo declarativo;
3. um componente local cria outlet global sem precisar;
4. o consumidor precisa tocar em namespace `Internal`;
5. o layout recebe outlet sem que o recurso realmente exija projeção ou coordenação global.

---

## Relação com Showcase e CSS

Mesmo em overlays:

- a API pública demonstrada no showcase deve usar apenas surface pública;
- o showcase deve deixar claro se existe `Handler`, `Notify`, `Outlet` ou requisito de layout;
- o contrato visual continua seguindo os guides de CSS e contrato público.

Este guide não detalha a mecânica de CSS nem a implementação concreta dos overlays existentes.

---

## Checklist

- [ ] O recurso é global, declarado ou local?
- [ ] O padrão escolhido é A, B ou C?
- [ ] A surface pública ficou mínima?
- [ ] O layout recebe outlet apenas quando isso faz parte do contrato?
- [ ] Services e outlets internos ficaram em `RoyalCode.Razor.Internal.*`?
- [ ] O showcase usa apenas a API pública correta?
- [ ] O caso foi comparado com o guide 08 antes de implementar?




