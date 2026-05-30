# SHP-TRANSACTIONAL_COMMERCE - Blueprint resumido

## Pattern

SHP-TRANSACTIONAL_COMMERCE — Transactional/Commerce — ver `shp-transactional-commerce.ui-map.md`

## Gap coberto

A lib cobre bem o fluxo de e-commerce. O gap é orientar: header de loja com `Bar + Badge` no carrinho, `OffCanvas(End)` como drawer do carrinho, `Container+Slot` para catálogo, `AuthorizeView` para link de conta, e integração do fluxo descoberta → carrinho → checkout.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `CommerceLayout.razor` com `Bar(header) + OffCanvas(carrinho) + Container(footer)`; catálogo usa `Container+Slot+Box`; checkout usa `PP-FORM` ou `PP-WIZARD`; rating e carrossel de produto são responsabilidade do app.

## Componentes usados

- `Bar` — papel: principal (header do shell) — ver `bar.sample.md`
- `Badge` — papel: composição (contador do carrinho) — ver `badge.sample.md`
- `OffCanvas` — papel: principal (drawer do carrinho) — ver `modal.sample.md`
- `Stack + Box` — papel: composição (itens do carrinho) — ver `box.sample.md`
- `IconButton` — papel: composição (trigger do carrinho) — ver `button.sample.md`
- `Button` — papel: composição (CTA de checkout, conta) — ver `button.sample.md`
- `Container + Slot` — papel: composição (footer editorial) — ver `container.sample.md`
- `Feedback` — papel: composição (carrinho vazio) — ver `feedback.sample.md`

## Recursos visuais

- `sticky top-0 z-10 bg-white border-b border-light-200 shadow-sm` — header fixo
- `absolute -top-1 -right-1` — badge de contagem sobreposto ao ícone do carrinho
- `max-w-7xl mx-auto px-4` — container de largura máxima no header

## Receita

`CommerceLayout.razor` com header fixo, drawer do carrinho e footer; catálogo e checkout nas páginas filhas.

```razor
@* CommerceLayout.razor *@
@inherits LayoutComponentBase
@inject NavigationManager Nav
@inject CarrinhoService CarrinhoService

@code {
    private readonly OffCanvasHandler carrinhoHandler = new();
    private int itensCarrinho;
    private List<ItemCarrinhoDto> itensDoCarrinho = [];
    private decimal totalCarrinho;
    private string busca = "";

    protected override async Task OnInitializedAsync()
    {
        itensCarrinho = await CarrinhoService.ContarItensAsync();
        CarrinhoService.OnChanged += AtualizarCarrinho;
    }

    private async void AtualizarCarrinho()
    {
        itensCarrinho = await CarrinhoService.ContarItensAsync();
        await InvokeAsync(StateHasChanged);
    }

    private async Task AbrirCarrinho()
    {
        itensDoCarrinho = await CarrinhoService.ObterItensAsync();
        totalCarrinho = itensDoCarrinho.Sum(i => i.PrecoTotal);
        await carrinhoHandler.Show();
    }

    private async Task RemoverDoCarrinho(int itemId)
    {
        await CarrinhoService.RemoverAsync(itemId);
        itensDoCarrinho = await CarrinhoService.ObterItensAsync();
        totalCarrinho = itensDoCarrinho.Sum(i => i.PrecoTotal);
        itensCarrinho = itensDoCarrinho.Count;
    }
}

<div class="min-h-screen flex flex-col">

    @* Header *@
    <header class="sticky top-0 z-10 bg-white border-b border-light-200 shadow-sm">
        <div class="max-w-7xl mx-auto px-4">
            <Bar AdditionalClasses="py-3">
                <StartContent>
                    <a href="/loja" class="font-bold text-dark-800 text-lg mr-6">Loja</a>
                    <nav class="hidden md:flex items-center gap-1">
                        <NavLink href="/loja/eletronicos"
                                 class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                            Eletrônicos
                        </NavLink>
                        <NavLink href="/loja/roupas"
                                 class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                            Roupas
                        </NavLink>
                    </nav>
                </StartContent>
                <EndContent>
                    <FieldText Placeholder="Buscar produtos..."
                               AdditionalClasses="w-56 hidden md:block"
                               @bind-Value="busca"
                               @oninput='e => Nav.NavigateTo($"/loja?q={e.Value}")' />

                    <AuthorizeView>
                        <Authorized>
                            <NavLink href="/minha-conta"
                                     class="text-sm text-dark-500 hover:text-dark-700">
                                Minha conta
                            </NavLink>
                        </Authorized>
                        <NotAuthorized>
                            <Button Style="Themes.Default" Size="Sizes.Small" Label="Entrar"
                                    OnClick='() => Nav.NavigateTo("/login")' />
                        </NotAuthorized>
                    </AuthorizeView>

                    <div class="relative">
                        <IconButton Icon="WellKnownIcons.ShoppingCart" Style="Themes.Default"
                                    OnClick="AbrirCarrinho" />
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

    @* Conteúdo — páginas filhas *@
    <main class="flex-1">
        @Body
    </main>

    @* Footer *@
    <footer class="border-t border-light-200 py-8 mt-8 bg-light-50">
        <div class="max-w-7xl mx-auto px-4">
            <Container Columns="4">
                @* Slots de colunas editoriais do footer *@
            </Container>
            <p class="text-xs text-dark-400 text-center mt-6">
                © 2026 Loja. Todos os direitos reservados.
            </p>
        </div>
    </footer>
</div>

@* Drawer do carrinho *@
<OffCanvas Handler="@carrinhoHandler" Title="Seu carrinho"
           Position="Positions.End">
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
                                        <p class="text-xs text-dark-400">Qtd: @item.Quantidade</p>
                                    </div>
                                </div>
                            </StartContent>
                            <EndContent>
                                <div class="text-right">
                                    <p class="text-sm font-semibold text-dark-700">
                                        @item.PrecoTotal.ToString("C")
                                    </p>
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
                OnClick="async () => await carrinhoHandler.Hide()" />
        <Button Style="Themes.Primary" Label="Finalizar compra"
                Disabled="@(!itensDoCarrinho.Any())"
                OnClick='async () => { await carrinhoHandler.Hide(); Nav.NavigateTo("/checkout"); }' />
    </FooterContent>
</OffCanvas>
```

## Limites

- Sem componente de rating/estrelas — implementação HTML com `☆★` ou lib externa;
- Sem carrossel de imagens de produto — `<img>` com seleção de thumbnail manual;
- Processamento de pagamento (Stripe, PagSeguro, etc.) é completamente externo;
- `CarrinhoService.OnChanged` requer `IDisposable` para desinscrição — adicionar `Dispose()` em produção;
- Menu de categorias mobile deve usar `OffCanvas(Start)` acionado por `IconButton(HamburgerMenu)`.
