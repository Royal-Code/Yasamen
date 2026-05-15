# SHP-TRANSACTIONAL_COMMERCE - Blueprint

## Identificação
- **Pattern**: SHP-TRANSACTIONAL_COMMERCE - Transactional/Commerce.
- **Nível final**: completo.
- **Cobertura atual**: 3.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `shell.pattern.md`, samples de `Button`, `ButtonGroup`, `TextField`, `Feedback`, `Modal`, `Pagination`, `Container`, `Slot`, `Box`, `Badge`, `DropIconButton`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen cobre ações, formulários, feedback, modal, paginação e layout, mas não possui carrinho, checkout, preço, resumo transacional ou fluxo de pedido. O blueprint propõe um shell transacional com descoberta, carrinho/resumo persistente e etapas de checkout, sem assumir pagamento ou regras de negócio como parte da biblioteca.

## Requisitos ainda não atendidos
- CTA de conversão persistente.
- Carrinho/resumo com itens, subtotal e estado.
- Checkout em etapas com validação.
- Feedback transacional de sucesso/erro.
- Continuidade entre catálogo, detalhe e confirmação.

## Diagnóstico estruturado do gap
`Button`, `TextField`, `Modal` e `Feedback` resolvem peças isoladas. `Container`, `Slot` e `Box` resolvem layout. Falta uma composição que conecte escolha, resumo, formulário, confirmação e estado de pedido.

## Justificativa detalhada da meta
A meta 8 é alcançável para shell transacional sem pagamento nativo. O blueprint orienta estrutura e estados, reaproveitando a linguagem visual e marcando carrinho/checkout como `[API proposta]`.

## Estratégia de composição
- `AppLayout` ou portal simples para descoberta.
- `Button` `Themes.Primary` para conversão.
- `Box` e `Badge` para cards de produto e status.
- `OffCanvas` ou `RightMenu` para resumo/carrinho.
- `Modal` para confirmação destrutiva ou aviso.
- `Feedback` e `Notify` para sucesso/erro.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] TransactionShell`: topbar, main, cart summary, checkout area.
- `[API proposta] CartSummary`: items, subtotal, taxes, action.
- `[API proposta] CheckoutStep`: title, valid, content, actions.
- `[API proposta] PriceBlock`: amount, currency, interval, discount.

## Aplicação objetiva da linguagem visual
Conversão usa `Themes.Primary`; cancelar/voltar usa `Themes.Light`; remover item usa `Themes.Danger`. Preço deve ser texto `dark-900` com peso médio, não badge colorido. Badges indicam disponibilidade, promoção ou status.

## Aplicação de estilos e tokens
Usar superfícies brancas e bordas claras para reduzir ruído. Em checkout, evitar muitas cores simultâneas; reservar `Danger` para erro/destruição e `Success` para confirmação.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] TransactionShell *@
<AppLayout AdditionalMainClasses="p-8 bg-light-100">
    <TopStart><strong>Loja</strong></TopStart>
    <TopEnd>
        <Button Label="@($"Carrinho ({CartCount})")" Style="Themes.Primary" Size="Sizes.Small" OnClick="OpenCart" />
    </TopEnd>
    <Main>
        <Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default" AdditionalClasses="gap-6">
            @CatalogContent
            @CheckoutContent
        </Container>
    </Main>
</AppLayout>
```

## Blocos principais de código

```razor
@* [API proposta] CartSummary usando Yasamen *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-5">
    <Bar>
        <Start><h2 class="font-medium text-dark-900">Resumo</h2></Start>
        <End><Badge Text="@CartCount.ToString()" Style="Themes.Primary" /></End>
    </Bar>

    <Stack AdditionalClasses="space-y-3">
        @foreach (var item in Items)
        {
            <div class="flex items-start justify-between gap-4 border-b border-light-300 pb-3">
                <div>
                    <div class="font-medium text-dark-900">@item.Name</div>
                    <div class="text-sm text-dark-500">@item.Quantity x @item.Price</div>
                </div>
                <IconButton Icon="BsIconNames.Trash" Style="Themes.Danger" OnClick="@(() => Remove(item))" />
            </div>
        }
    </Stack>

    <Button Label="Finalizar pedido" Style="Themes.Primary" Block="true" OnClick="GoToCheckout" />
</Box>
```

## Estados e comportamento responsivo
- Desktop: catálogo e resumo podem coexistir em duas zonas.
- Mobile: resumo vira `OffCanvas` ou etapa dedicada.
- Carrinho vazio: `Feedback Info` com CTA para voltar ao catálogo.
- Erro de pagamento: `Feedback Danger`; não usar `Alert` como erro destrutivo.
- Pedido concluído: `Feedback Success` e `Notify` quando disponível.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<TransactionShell Items="products"
                  Cart="cart"
                  CheckoutState="checkout"
                  OnAdd="AddToCart"
                  OnCheckout="SubmitOrder" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Ações e forms | bons | mantidos |
| Carrinho | ausente | `CartSummary` proposto |
| Checkout | manual | etapas propostas |
| Conversão | manual | CTA persistente |
| Pagamento | ausente | integração externa |

## Limitações remanescentes
- Pagamento, estoque, frete e impostos são regras externas.
- Segurança e PCI não entram no blueprint visual.
- Precificação complexa precisa contrato de domínio.

## Pontos de adaptação
- Conectar modelos de produto, carrinho e pedido.
- Escolher se checkout será wizard ou formulário único.
- Definir mensagens transacionais e política de retry.
