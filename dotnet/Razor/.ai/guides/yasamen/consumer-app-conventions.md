# Convenções de App Consumidor com Yasamen

> Guide para definir convenções locais de um app Blazor que consome Yasamen, sem confundir consumo da biblioteca com expansão da biblioteca.

## Objetivo

Este guide existe para ajudar a fechar decisões de app consumidor que não pertencem a uma tela isolada.

Ele cobre:

- convenções de shell, layout e navegação;
- convenções de rota e agrupamento;
- convenções de pacotes, serviços e estilos;
- convenções de docs, demo ou showcase do projeto consumidor;
- limites entre `app-spec`, `screen-spec`, `yasamen` e `lib-spec`.

## Quando usar

Use este guide quando o trabalho for:

- criar um novo app Blazor que usa Yasamen;
- reorganizar um app consumidor existente;
- definir convenções antes de abrir várias `screen specs`;
- padronizar a forma de consumir Yasamen em um repositório de app.

Quando o pedido for só “criar um novo projeto”:

- fechar apenas a fundação do app;
- não forçar lista grande de módulos, telas, dados ou integrações;
- deixar o detalhe funcional para `screen-spec`, evolução da `app spec` ou implementação posterior.

## Decisões obrigatórias no app consumidor

### 1. Modelo do app

- `Blazor Web App`
- `Blazor Server`
- `Blazor WebAssembly`
- outro host equivalente

Registrar:

- tipo do app;
- contexto de deployment;
- nível de interatividade esperado;
- restrições relevantes.

### 2. Shell e navegação

Definir:

- shell principal;
- layout base;
- navegação global;
- agrupamento por módulo, área ou feature;
- convenção de rota.

Regra:

- o shell do app deve existir antes de multiplicar telas;
- se ainda não estiver claro, abrir `app-spec` antes de abrir várias `screen specs`.

### 3. Pacotes e estilos

Definir:

- pacotes Yasamen base confirmados para o app;
- pacotes adicionais candidatos por módulo ou tela;
- estratégia de carga de `yasamen.css`;
- política local de override visual.

Regras:

- consumir só API pública dos pacotes;
- não usar `Internal.*`;
- não copiar CSS interno da biblioteca;
- concentrar customizações locais no app consumidor.
- não promover pacote candidato a pacote confirmado sem apoio das telas, módulos ou shell já definidos.

### 4. Serviços públicos

Definir:

- quais serviços públicos de Yasamen precisam ser registrados;
- onde isso será feito;
- como o app organiza essa configuração.

Regra:

- registrar apenas extensões públicas do tipo `AddYasamenXyz(...)`.

### 5. Dados, autenticação e integrações

Definir:

- se a primeira entrega usa mock, estado local, backend real ou integração futura;
- se haverá autenticação real, fake ou nenhuma na primeira fase;
- quais dependências externas interferem no desenho do app.

Regra:

- não deixar esse ponto implícito quando o utilizador já estiver a definir escopo funcional do app;
- se o pedido ainda for só de fundação do projeto, registrar esse bloco como `adiado` é aceitável.

### 6. Docs, showcase e demo do app

Se o projeto consumidor tiver docs, showcase ou demo:

- definir convenção local de rota;
- definir layout local para demonstração;
- definir agrupamento por módulo ou família;
- separar, quando útil, showcase técnico de uso real do produto.

Regra:

- o app consumidor não depende do host interno de docs da biblioteca;
- showcase local é convenção do projeto consumidor.
- referência ao repositório atual pode ajudar no scaffold, mas não deve ditar o posicionamento do app consumidor.

## Escalonamento correto

Usar `app-spec` quando:

- o app ainda não tem convenções estáveis;
- várias telas dependem de decisões comuns;
- o problema é estrutural no nível do app.

Usar `screen-spec` quando:

- o app já tem convenções suficientes;
- a dúvida está numa tela específica.

Usar `yasamen` quando:

- a tarefa já está clara;
- o app já tem convenções estáveis;
- o trabalho é de execução direta.

Usar `lib-spec` quando:

- surgir gap de componente reutilizável;
- faltar pacote ou infraestrutura da biblioteca;
- o trabalho deixar de ser consumo e virar expansão.

## Checklist rápido

- [ ] O modelo do app foi definido?
- [ ] Shell, layout e navegação foram definidos?
- [ ] Convenção de rota foi definida?
- [ ] Pacotes e estilos de Yasamen foram definidos?
- [ ] Serviços públicos necessários foram definidos?
- [ ] Estratégia inicial de dados, autenticação e integrações foi definida?
- [ ] Convenção local de docs ou showcase foi definida, quando aplicável?
- [ ] Está claro quando escalar para `screen-spec` ou `lib-spec`?
