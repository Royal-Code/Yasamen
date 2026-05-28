# SHP-PORTAL - Portal

**GAP parcial — lib focada em apps operacionais**

A biblioteca não inclui componentes de header de site público, mega-menu ou rodapé editorial. SHP-PORTAL (conteúdo público/institucional) requer composição majoritariamente HTML/Tailwind, com a lib contribuindo apenas para cards, grids, formulários e overlays.

## Componentes por zona funcional

### Zona: Shell (header e navegação)

1. Bar (header superior)
- `cobertura`: barra superior com logo, links de navegação, CTAs ("Entrar", "Criar conta");
- `nota`: 6;
- `justificativa`: header básico — sem mega-menu nem navegação hierárquica nativa.

2. OffCanvas (menu mobile)
- `cobertura`: menu recolhível em drawer para mobile; `Position=Start`;
- `nota`: 8;
- `justificativa`: navegação móvel de portal.

### Zona: Conteúdo

1. Container+Slot (grade de seções)
- `cobertura`: grade de features, categorias, destaques; 2-4 colunas responsivas;
- `nota`: 9;
- `justificativa`: grade de conteúdo público.

2. Box (cards de seção)
- `cobertura`: cards de categoria, feature ou artigo com ações;
- `nota`: 8;
- `justificativa`: cards editoriais.

3. Pagination (UIP-NAV-PAGINATION)
- `cobertura`: paginação de catálogos públicos ou listas editoriais;
- `nota`: 9;
- `justificativa`: navegação de coleção pública.

### Zona: Formulários / CTAs

1. EditForm + FieldText + Button (formulário de contato, busca, newsletter)
- `cobertura`: formulário de contato, busca geral, inscrição em newsletter;
- `nota`: 8;
- `justificativa`: interação transacional leve do portal.

**Descartados**: nenhum.

## Estrutura de shell

```razor
@* PortalLayout.razor — shell de Portal *@
@inherits LayoutComponentBase

@code {
    private bool menuMobileAberto;
}

@* Header *@
<header class="sticky top-0 z-10 bg-white border-b border-light-200">
    <div class="max-w-6xl mx-auto px-4">
        <Bar AdditionalClasses="py-3">
            <StartContent>
                @* Logo *@
                <a href="/" class="flex items-center gap-2">
                    <div class="w-8 h-8 rounded bg-primary-500 flex items-center justify-center">
                        <span class="text-white font-bold text-sm">P</span>
                    </div>
                    <span class="font-bold text-dark-700">Portal</span>
                </a>

                @* Navegação desktop *@
                <nav class="hidden md:flex items-center gap-1 ml-6">
                    <a href="/sobre" class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                        Sobre
                    </a>
                    <a href="/servicos" class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                        Serviços
                    </a>
                    <a href="/blog" class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                        Blog
                    </a>
                    <a href="/contato" class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                        Contato
                    </a>
                </nav>
            </StartContent>
            <EndContent>
                <div class="hidden md:flex items-center gap-2">
                    <a href="/login" class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                        Entrar
                    </a>
                    <Button Style="Themes.Primary" Size="Sizes.Small" Label="Criar conta"
                            OnClick='() => Nav.NavigateTo("/registro")' />
                </div>
                @* Menu mobile *@
                <IconButton Icon="WellKnownIcons.Menu" Style="Themes.Default"
                           AdditionalClasses="md:hidden"
                           OnClick="() => menuMobileAberto = true" />
            </EndContent>
        </Bar>
    </div>
</header>

@* Menu mobile *@
<OffCanvas Title="Menu" @bind-IsOpen="menuMobileAberto"
           Position="OffCanvasPosition.Start" Size="OffCanvasSize.Small">
    <ChildContent>
        <nav>
            <Stack Gap="Gaps.None">
                @foreach (var link in new[] { ("/", "Início"), ("/sobre", "Sobre"),
                    ("/servicos", "Serviços"), ("/blog", "Blog"), ("/contato", "Contato") })
                {
                    <a href="@link.Item1"
                       class="block px-4 py-3 text-sm text-dark-600 hover:bg-light-50
                              border-b border-light-100 last:border-0"
                       @onclick="() => menuMobileAberto = false">
                        @link.Item2
                    </a>
                }
            </Stack>
        </nav>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Primary" Label="Criar conta" AdditionalClasses="w-full"
                OnClick='() => Nav.NavigateTo("/registro")' />
    </FooterContent>
</OffCanvas>

@* Conteúdo da página *@
<main>
    @Body
</main>

@* Footer *@
<footer class="bg-dark-800 text-white px-6 py-10 mt-16">
    <div class="max-w-6xl mx-auto">
        <Container Columns="4">
            @* colunas do footer *@
        </Container>
        <div class="border-t border-dark-700 mt-8 pt-4">
            <p class="text-xs text-dark-400 text-center">
                © 2026 Portal. Todos os direitos reservados.
            </p>
        </div>
    </div>
</footer>
```

## Decisão de uso

- `nota geral`: 4;
- `limitações`: sem navegação horizontal de site (mega-menu); sem componente de rodapé editorial; sem hero de site nativo; conteúdo editorial é HTML/Tailwind com a lib como suporte de cards e forms;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Bar` + `OffCanvas` (menu mobile) + `Container+Slot` + `Box` cobrem portal institucional simples;
  - A lib é suporte, não protagonista — estrutura do portal é HTML/Tailwind;
  - Nota 4 reflete cobertura parcial — adequado para portals simples, insuficiente para sites editoriais ricos.
