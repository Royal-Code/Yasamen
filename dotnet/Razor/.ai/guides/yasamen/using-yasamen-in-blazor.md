# Using Yasamen in Blazor

> Guia de consumo da biblioteca Yasamen em projetos Blazor.

## Objetivo

Este guide existe para orientar a criação e a manutenção de projetos consumidores da biblioteca.

Ele cobre:

- instalação de pacotes;
- configuração básica de estilos e `_Imports`;
- registro de serviços;
- composição de telas com componentes Yasamen;
- organização de app consumidor em conjunto com convenções locais;
- limites entre consumo da biblioteca e expansão da biblioteca.

## Quando usar este guide

Use este guide quando o trabalho for:

- criar um novo projeto Blazor que usa Yasamen;
- instalar ou atualizar pacotes Yasamen em um app existente;
- criar ou editar telas consumidoras com componentes já disponíveis;
- configurar showcase, docs internas ou páginas de demonstração em um app consumidor.

Se o problema estiver no nível estrutural do app, combinar também com `consumer-app-conventions.md` e `app-spec`.

Não use este guide como substituto de `lib-spec` quando o trabalho for criar componente novo da biblioteca.

## Regras de consumo

- consumir apenas API pública dos pacotes;
- não usar namespaces `Internal.*` de Yasamen;
- não copiar CSS interno da biblioteca para o projeto consumidor;
- preferir temas, tamanhos e classes públicas já previstos pela biblioteca;
- se faltar componente ou padrão, registrar gap e encaminhar para `lib-spec`.

## Configuração mínima de um app consumidor

### Pacotes

Instalar apenas os pacotes necessários para a família de componentes usada.

Base comum em projetos visuais:

- `RoyalCode.Razor.Styles`
- `RoyalCode.Razor.Commons`

Pacotes adicionais conforme a necessidade:

- `RoyalCode.Razor.Buttons`
- `RoyalCode.Razor.Forms`
- `RoyalCode.Razor.Alerts`
- `RoyalCode.Razor.Navigation`
- outros pacotes da solução

Regra:

- distinguir no design do app o que é `base confirmada` do que é apenas `candidato por necessidade`;
- não tratar exemplos genéricos de pacote como lista confirmada da entrega.

### Estilos

O projeto consumidor deve carregar o CSS público da biblioteca, não recriar os tokens.

Regras:

- usar `yasamen.css` como base pública;
- sobrescritas locais devem respeitar os tokens e o contrato visual da biblioteca;
- não tratar `*.razor.css` internos da biblioteca como API.

### `_Imports.razor`

Adicionar apenas namespaces públicos necessários.

Base comum:

```razor
@using RoyalCode.Razor.Styles
@using RoyalCode.Razor.Commons
```

Adicionar pacotes específicos conforme a superfície usada.

### DI

Quando um pacote exigir registro explícito, usar apenas extensões públicas do tipo:

- `AddYasamenXyz(...)`

Não registrar tipos internos manualmente no app consumidor.

## Convenções de app consumidor

Antes de multiplicar telas, vale fechar:

- shell e layout principal;
- navegação global;
- convenção de rota;
- convenção de docs, demo ou showcase do projeto consumidor;
- política local de override visual.

Quando essas decisões ainda não estiverem claras:

- usar `consumer-app-conventions.md`;
- preferir `app-spec` antes de abrir várias `screen specs`.

Em apps com módulos de negócio, a lista inicial de perguntas deve preferir linguagem de domínio do utilizador, não exemplos de galeria de componentes da biblioteca.

Quando o pedido for apenas criar um projeto novo:

- perguntar só o necessário para a fundação do app;
- não exigir detalhamento de módulos, telas, dados ou integrações se o utilizador ainda não quiser fechar isso;
- materializar uma `app spec` de base e deixar o funcional para evolução posterior.

## Telas consumidoras

Ao criar ou editar uma tela:

- preferir composição com componentes já existentes;
- seguir `screen-spec` quando a tela ainda não estiver bem definida;
- seguir `yasamen` quando a tarefa for execução direta no repositório;
- registrar gaps de componente quando a biblioteca ainda não cobrir a necessidade.

## Showcase e docs em app consumidor

Se o projeto consumidor tiver área de demonstração ou docs:

- definir uma convenção local do próprio projeto consumidor para rotas, páginas e agrupamento;
- preferir reaproveitar componentes e layouts públicos da biblioteca, sem depender de guides internos de expansão;
- separar showcase de uso real da app, quando isso reduzir confusão;
- preferir exemplos funcionais, não galerias artificiais.

## Quando escalar para outro fluxo

Encaminhar para `lib-spec` quando:

- o projeto consumidor revelar um gap de componente reutilizável;
- for necessário criar pacote novo da biblioteca;
- a mudança deixar de ser consumo e virar expansão da biblioteca.

Encaminhar para `screen-spec` quando:

- a tela ainda exigir definição de shell, `Page Pattern`, zonas e `UIP-*`;
- a solução da página ainda estiver conceitualmente aberta.

Encaminhar para `app-spec` quando:

- o app ainda não tiver shell, layout, navegação e convenções locais estáveis;
- houver várias telas dependentes das mesmas decisões de app;
- o problema estiver no nível estrutural do app consumidor.


