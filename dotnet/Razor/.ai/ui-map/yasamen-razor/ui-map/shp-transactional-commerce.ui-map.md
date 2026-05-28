# SHP-TRANSACTIONAL_COMMERCE - Transactional/Commerce

## Componentes por zona funcional

### Zona: Shell (navegação)

1. Bar (header de e-commerce)
- `cobertura`: logo, busca, link de conta, ícone de carrinho com badge;
- `nota`: 8;
- `justificativa`: header de loja com elementos de conversão.

2. Badge (contador do carrinho)
- `cobertura`: contagem de itens no carrinho no ícone;
- `nota`: 9;
- `justificativa`: indicador de estado transacional no header.

3. OffCanvas (menu de categorias mobile)
- `cobertura`: categorias de produto em drawer para mobile;
- `nota`: 8;
- `justificativa`: navegação de categorias em mobile.

### Zona: Descoberta (PP-CATALOG)

1. Container+Slot + Box (grade de produtos)
- `cobertura`: grade responsiva 2-4 colunas; card de produto com imagem, preço, rating, botão;
- `nota`: 9;
- `justificativa`: catálogo de produtos — cobertura nativa excelente.

2. FieldText + OffCanvas (busca + filtros)
- `cobertura`: busca de produto + filtros de preço, categoria, disponibilidade;
- `nota`: 8;
- `justificativa`: busca e refinamento de catálogo.

3. Pagination (UIP-NAV-PAGINATION)
- `cobertura`: paginação do catálogo;
- `nota`: 9;
- `justificativa`: navegação entre páginas de catálogo.

### Zona: Detalhe do produto (PP-DETAIL)

1. Box + Bar + HTML (detalhe de produto)
- `cobertura`: imagem, título, preço, descrição, especificações, avaliações;
- `nota`: 7;
- `justificativa`: página de detalhe de produto.

2. Button Style=Primary (CTA "Adicionar ao carrinho")
- `cobertura`: botão de adição ao carrinho; feedback de adição;
- `nota`: 9;
- `justificativa`: CTA de conversão principal.

### Zona: Carrinho

1. OffCanvas (carrinho lateral)
- `cobertura`: drawer End com itens do carrinho, totais, botão de checkout;
- `nota`: 9;
- `justificativa`: carrinho em drawer — experiência sem abandonar a página.

2. Stack + Box/Bar (itens do carrinho)
- `cobertura`: lista de itens com imagem, nome, quantidade, preço, remoção;
- `nota`: 7;
- `justificativa`: itens do carrinho.

### Zona: Checkout (PP-WIZARD / PP-FORM)

1. FormGroup + FieldText/FieldSelect (endereço e pagamento)
- `cobertura`: endereço de entrega, dados de pagamento, revisão do pedido;
- `nota`: 8;
- `justificativa`: formulários de checkout.

2. Modal + Bar (resumo do pedido)
- `cobertura`: resumo antes de confirmar; confirmação de pedido após pagamento;
- `nota`: 9;
- `justificativa`: confirmação transacional.

### Zona: Acompanhamento (PP-DETAIL)

1. Stack + Box + Bar + Badge (histórico de pedidos)
- `cobertura`: lista de pedidos com status, data, total, link de acompanhamento;
- `nota`: 8;
- `justificativa`: histórico de pedidos do usuário.

**Descartados**: nenhum.

## Estrutura de shell

```razor
@* CommerceLayout.razor — shell de Transactional/Commerce *@
@inherits LayoutComponentBase

@inject CarrinhoService CarrinhoService

@code {
    private int itensCarrinho;
    private bool carrinhoAberto;

    protected override async Task OnInitializedAsync()
    {
        itensCarrinho = await CarrinhoService.ContarItensAsync();
    }
}

<div class="min-h-screen flex flex-col">
    @* Header *@
    <header class="sticky top-0 z-10 bg-white border-b border-light-200 shadow-sm">
        <div class="max-w-7xl mx-auto px-4">
            <Bar AdditionalClasses="py-3">
                <StartContent>
                    @* Logo *@
                    <a href="/loja" class="font-bold text-dark-800 text-lg mr-6">Loja</a>

                    @* Categorias desktop *@
                    <nav class="hidden md:flex items-center gap-1">
                        <NavLink href="/loja/eletronicos" class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                            Eletrônicos
                        </NavLink>
                        <NavLink href="/loja/roupas" class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                            Roupas
                        </NavLink>
                        <NavLink href="/loja/casa" class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                            Casa
                        </NavLink>
                    </nav>
                </StartContent>
                <EndContent>
                    @* Busca *@
                    <FieldText Placeholder="Buscar produtos..." AdditionalClasses="w-56 hidden md:block"
                               @bind-Value="busca" @oninput="Buscar" />

                    @* Conta *@
                    <AuthorizeView>
                        <Authorized>
                            <NavLink href="/minha-conta" class="text-sm text-dark-500 hover:text-dark-700">
                                Minha conta
                            </NavLink>
                        </Authorized>
                        <NotAuthorized>
                            <Button Style="Themes.Default" Size="Sizes.Small" Label="Entrar"
                                    OnClick='() => Nav.NavigateTo("/login")' />
                        </NotAuthorized>
                    </AuthorizeView>

                    @* Carrinho *@
                    <div class="relative">
                        <IconButton Icon="WellKnownIcons.ShoppingCart" Style="Themes.Default"
                                   OnClick="() => carrinhoAberto = true" />
                        @if (itensCarrinho > 0)
                        {
                            <span class="absolute -top-1 -right-1">
                                <Badge Style="Themes.Primary"
                                       Text="@itensCarrinho.ToString()" />
                            </span>
                        }
                    </div>
                </EndContent>
            </Bar>
        </div>
    </header>

    @* Conteúdo *@
    <main class="flex-1">
        @Body
    </main>

    @* Footer *@
    <footer class="border-t border-light-200 py-8 mt-8 bg-light-50">
        <div class="max-w-7xl mx-auto px-4">
            <Container Columns="4">
                @* Colunas de links do footer *@
            </Container>
        </div>
    </footer>
</div>

@* Drawer do carrinho *@
<OffCanvas Title="Seu carrinho" @bind-IsOpen="carrinhoAberto"
           Position="OffCanvasPosition.End" Size="OffCanvasSize.Medium">
    <ChildContent>
        @if (!itensDoCarrinho.Any())
        {
            <Feedback Style="Themes.Light" Text="Seu carrinho está vazio." />
        }
        else
        {
            <Stack Gap="Gaps.Small">
                @foreach (var item in itensDoCarrinho)
                {
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
                        <Bar>
                            <StartContent>
                                <div class="flex gap-2">
                                    <img src="@item.ImagemUrl" alt="@item.Nome"
                                         class="w-12 h-12 object-cover rounded" />
                                    <div>
                                        <p class="text-sm font-medium text-dark-600">@item.Nome</p>
                                        <p class="text-xs text-dark-400">@item.Variante</p>
                                    </div>
                                </div>
                            </StartContent>
                            <EndContent>
                                <div class="text-right">
                                    <p class="text-sm font-semibold text-dark-700">
                                        @item.PrecoTotal.ToString("C")
                                    </p>
                                    <p class="text-xs text-dark-400">Qtd: @item.Quantidade</p>
                                </div>
                                <IconButton Icon="WellKnownIcons.Trash" Style="Themes.Default"
                                           Size="Sizes.Small"
                                           OnClick="() => RemoverDoCarrinho(item.Id)" />
                            </EndContent>
                        </Bar>
                    </Box>
                }
            </Stack>
            <div class="border-t border-light-200 pt-3 mt-3">
                <Bar>
                    <StartContent>
                        <span class="text-sm font-semibold text-dark-700">Total</span>
                    </StartContent>
                    <EndContent>
                        <span class="text-lg font-bold text-dark-800">
                            @totalCarrinho.ToString("C")
                        </span>
                    </EndContent>
                </Bar>
            </div>
        }
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Continuar comprando"
                OnClick="() => carrinhoAberto = false" />
        <Button Style="Themes.Primary" Label="Finalizar compra"
                Disabled="@(!itensDoCarrinho.Any())"
                OnClick='() => { carrinhoAberto = false; Nav.NavigateTo("/checkout"); }' />
    </FooterContent>
</OffCanvas>
```

## Decisão de uso

- `nota geral`: 7;
- `limitações`: sem componente de rating/estrelas; sem carrossel de imagens de produto; processamento de pagamento (Stripe, PagSeguro) é externo; sem componente de comparação de produtos;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Container+Slot` + `Box` + `OffCanvas` (carrinho) + `FormGroup` (checkout) + `Pagination` + `Badge` cobrem SHP-TRANSACTIONAL_COMMERCE com boa qualidade;
  - O fluxo descoberta → carrinho (OffCanvas) → checkout (PP-FORM/WIZARD) → confirmação (Modal) é totalmente suportado;
  - Nota 7 reflete boa cobertura com limitações nos componentes específicos de e-commerce (rating, carrossel).
