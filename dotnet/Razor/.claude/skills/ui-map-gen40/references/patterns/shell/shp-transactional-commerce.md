# SHP-TRANSACTIONAL_COMMERCE - Transactional/Commerce

## Definição

**Definição curta**: Shell para descoberta orientada à conversão, transação e acompanhamento de pedidos ou reservas.

**Objetivo estrutural**: Sustentar percurso de escolha, comparação, decisão, checkout e acompanhamento transacional.

**Interação dominante**: Transacional

**Não confundir com**: SHP-PORTAL (conteúdo público), SHP-MEDIA_CONTENT (consumo de mídia), SHP-WORKSPACE_ADMIN (operação interna).

## Decisão

**Sinais de escolha**:
- catálogo com intenção de compra ou reserva
- carrinho, checkout e pagamento
- histórico de pedidos
- conversão como objetivo principal

**Limites**: não é o shell adequado para gestão interna extensa ou para editores técnicos centrados em canvas.

**Grau de Rigidez**: Alto — o fluxo descoberta → decisão → checkout → acompanhamento é invariante; a composição de cada etapa varia.

## Navegação e Estrutura

**Modelo de navegação global**: navegação orientada a descoberta, carrinho, conta e estado transacional.

**Estrutura Desktop**: navegação clara para descoberta, conta e transação, com CTAs persistentes de conversão.

**Estrutura Mobile**: fluxo simplificado, CTA prioritário e transições curtas entre descoberta e checkout.

**Regra de transição**: reduzir fricção e preservar a continuidade do estado transacional em todas as faixas.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CATALOG, PP-DETAIL, PP-FORM, PP-WIZARD.

**Compatibilidade Secundária**: PP-LANDING, PP-CALENDAR.

**Incompatibilidades explícitas**: PP-DASHBOARD como experiência dominante de entrada.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: preservar a continuidade entre catálogo, detalhe, carrinho ou estado transacional e formulário.

**Adaptação Mobile nativo**: usar stack, tab bar quando houver destinos raiz e fluxos curtos entre descoberta e decisão; considerar permissões, deep links e lifecycle em pagamento, reserva ou conta.

**Adaptação Desktop nativo**: aplicar quando houver função transacional recorrente em app dedicado.
