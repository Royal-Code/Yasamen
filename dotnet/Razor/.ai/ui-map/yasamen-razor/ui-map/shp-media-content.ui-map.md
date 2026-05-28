# SHP-MEDIA_CONTENT - Media/Content

## Componentes por zona funcional

### Zona: Shell (estrutura)

1. HTML layout (header leve + main + footer)
- `cobertura`: header com logo + busca + nav leve; área de conteúdo principal; sem AppLayout (sidebar de admin);
- `nota`: 6;
- `justificativa`: shell leve de catálogo/mídia — sem componente de shell público dedicado.

2. Bar (header de navegação)
- `cobertura`: logo, busca global, links de categoria, perfil do usuário;
- `nota`: 7;
- `justificativa`: header do shell de mídia.

3. OffCanvas (menu mobile)
- `cobertura`: menu de categorias em drawer para mobile;
- `nota`: 8;
- `justificativa`: navegação móvel do shell de mídia.

### Zona: Descoberta

1. FieldText (busca)
- `cobertura`: busca proeminente de conteúdo/catálogo;
- `nota`: 8;
- `justificativa`: busca de conteúdo.

2. Container+Slot + Box (UIP-DATA-CARD_GRID)
- `cobertura`: grade de itens de catálogo/mídia; destaques; seções editoriais;
- `nota`: 9;
- `justificativa`: grid de descoberta — cobertura excelente.

3. Stack + Box/Bar (UIP-DATA-LIST_ITEM)
- `cobertura`: feed de conteúdo; lista de artigos;
- `nota`: 8;
- `justificativa`: feed de conteúdo.

4. Pagination (UIP-NAV-PAGINATION)
- `cobertura`: paginação de catálogos e feeds;
- `nota`: 9;
- `justificativa`: navegação entre páginas de conteúdo.

### Zona: Consumo

1. Box + `@((MarkupString)html)` (detalhe de artigo)
- `cobertura`: conteúdo editorial renderizado; classes `prose` do Tailwind;
- `nota`: 6;
- `justificativa`: consumo de conteúdo textual.

2. HTML `<video>`/`<audio>` (mídia nativa)
- `cobertura`: player de vídeo/áudio nativo do browser;
- `nota`: 5;
- `justificativa`: consumo de mídia — sem componente de player dedicado.

3. Badge + Bar (metadados do conteúdo)
- `cobertura`: categoria, tags, data, autor;
- `nota`: 8;
- `justificativa`: metadados de item de conteúdo.

**Descartados**: AppSideBar (sidebar de app admin, não de catálogo de mídia).

## Estrutura de shell

```razor
@* MediaLayout.razor — shell de Media/Content *@
@inherits LayoutComponentBase

@code {
    private bool menuMobileAberto;
    private string busca = "";
}

<div class="min-h-screen flex flex-col">
    @* Header *@
    <header class="sticky top-0 z-10 bg-white border-b border-light-200 shadow-sm">
        <div class="max-w-7xl mx-auto px-4">
            <Bar AdditionalClasses="py-3">
                <StartContent>
                    <a href="/" class="font-bold text-dark-800 text-lg mr-6">MediaApp</a>

                    @* Navegação de categorias desktop *@
                    <nav class="hidden md:flex items-center gap-1">
                        <NavLink href="/filmes" class="text-sm px-3 py-1 rounded-md text-dark-500
                                                       hover:bg-light-50"
                                 ActiveClass="bg-primary-50 text-primary-700">
                            Filmes
                        </NavLink>
                        <NavLink href="/series" class="text-sm px-3 py-1 rounded-md text-dark-500
                                                       hover:bg-light-50"
                                 ActiveClass="bg-primary-50 text-primary-700">
                            Séries
                        </NavLink>
                        <NavLink href="/documentarios" class="text-sm px-3 py-1 rounded-md
                                                              text-dark-500 hover:bg-light-50"
                                 ActiveClass="bg-primary-50 text-primary-700">
                            Documentários
                        </NavLink>
                    </nav>
                </StartContent>
                <EndContent>
                    @* Busca *@
                    <TextField @bind-Value="busca" Placeholder="Buscar..."
                               @oninput="Buscar" AdditionalClasses="w-48" />

                    @* Perfil / Login *@
                    <AuthorizeView>
                        <Authorized>
                            <DropIconButton Icon="WellKnownIcons.User" Style="Themes.Default">
                                <DropItem Label="Minha lista" OnClick='() => Nav.NavigateTo("/lista")' />
                                <DropItem Label="Perfil" OnClick='() => Nav.NavigateTo("/perfil")' />
                                <DropItem Label="Sair" OnClick="Logout" />
                            </DropIconButton>
                        </Authorized>
                        <NotAuthorized>
                            <Button Style="Themes.Primary" Size="Sizes.Small" Label="Entrar"
                                    OnClick='() => Nav.NavigateTo("/login")' />
                        </NotAuthorized>
                    </AuthorizeView>

                    @* Menu mobile *@
                    <IconButton Icon="WellKnownIcons.Menu" Style="Themes.Default"
                               AdditionalClasses="md:hidden"
                               OnClick="() => menuMobileAberto = true" />
                </EndContent>
            </Bar>
        </div>
    </header>

    @* Conteúdo *@
    <main class="flex-1">
        @Body
    </main>

    @* Footer *@
    <footer class="border-t border-light-200 py-6 mt-8">
        <div class="max-w-7xl mx-auto px-4">
            <Bar>
                <StartContent>
                    <p class="text-xs text-dark-400">© 2026 MediaApp</p>
                </StartContent>
                <EndContent>
                    <a href="/privacidade" class="text-xs text-dark-400 hover:underline">
                        Privacidade
                    </a>
                    <a href="/termos" class="text-xs text-dark-400 hover:underline">Termos</a>
                </EndContent>
            </Bar>
        </div>
    </footer>
</div>

@* Menu mobile *@
<OffCanvas Title="Navegar" @bind-IsOpen="menuMobileAberto"
           Position="OffCanvasPosition.Start" Size="OffCanvasSize.Small">
    <ChildContent>
        <nav>
            <Stack Gap="Gaps.None">
                @foreach (var item in new[] { ("/","Início"), ("/filmes","Filmes"),
                    ("/series","Séries"), ("/documentarios","Documentários") })
                {
                    <a href="@item.Item1"
                       class="block px-4 py-3 text-sm text-dark-600 hover:bg-light-50
                              border-b border-light-100"
                       @onclick="() => menuMobileAberto = false">
                        @item.Item2
                    </a>
                }
            </Stack>
        </nav>
    </ChildContent>
</OffCanvas>
```

## Decisão de uso

- `nota geral`: 6;
- `limitações`: sem shell de mídia nativo; player de vídeo/áudio é HTML nativo sem controles customizados; sem componente de carrossel nativo; busca global requer implementação backend;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Container+Slot` + `Box` + `Bar` + `Pagination` cobrem o shell de mídia/catálogo com boa qualidade;
  - O `OffCanvas` para menu mobile + `Bar` para header completam a estrutura do shell;
  - Nota 6 reflete boa cobertura para catálogos e feeds, com limitação em players de mídia e carrosséis.
