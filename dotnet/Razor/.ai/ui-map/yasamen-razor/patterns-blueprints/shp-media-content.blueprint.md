# SHP-MEDIA_CONTENT - Blueprint completo

## Pattern

SHP-MEDIA_CONTENT — Media/Content — ver `shp-media-content.ui-map.md`

## Gap coberto

A lib é focada em apps operacionais. O gap é orientar o shell de catálogo/mídia sem `AppLayout`: header leve com busca proeminente + categorias com `NavLink` + `OffCanvas` mobile; `Container+Slot+Box` para grades de catálogo; `<video>/<audio>` HTML nativo para players; `@((MarkupString)html)` + classes `prose` para conteúdo editorial.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `MediaLayout.razor` com header `sticky` + categorias `NavLink(ActiveClass="bg-primary-50 text-primary-700")` + `OffCanvas(Start)` mobile; `Container+Slot+Box` para descoberta; conteúdo editorial via `Box + @((MarkupString)html)`; player via `<video controls>` nativo; sem `AppLayout`.
- `eixos cobertos sem componente novo`:
  - header leve → HTML `<header sticky>` + `Bar`;
  - categorias ativas → `NavLink ActiveClass`;
  - menu mobile → `IconButton(Menu) + OffCanvas(Start)`;
  - descoberta → `Container+Slot+Box + Badge(categoria) + Pagination`;
  - detalhe editorial → `Box + @((MarkupString)html)`;
  - player → `<video controls>` / `<audio controls>` HTML nativo;
  - perfil / auth → `AuthorizeView + DropIconButton`.

## Componentes usados

- `Bar` — papel: principal (header do shell) — ver `bar.sample.md`
- `OffCanvas` — papel: principal (menu mobile de categorias) — ver `modal.sample.md`
- `Container + Slot` — papel: composição (grade de catálogo) — ver `bar.sample.md`
- `Box` — papel: composição (card de item, detalhe editorial) — ver `box.sample.md`
- `Badge` — papel: composição (categoria, tags, metadados) — ver `badge.sample.md`
- `Pagination` — papel: composição (paginação de catálogo) — ver `bar.sample.md`
- `TextField` — papel: composição (busca global) — ver `field-text.sample.md`
- `DropIconButton` — papel: composição (menu de conta do usuário) — ver `button.sample.md`
- `Stack` — papel: composição (links do menu mobile) — ver `bar.sample.md`

## Recursos visuais

- `sticky top-0 z-10 bg-white border-b border-light-200 shadow-sm` — header fixo
- `ActiveClass="bg-primary-50 text-primary-700 font-medium"` — categoria ativa
- `max-w-7xl mx-auto px-4` — container de largura máxima
- `min-h-screen flex flex-col` — shell que ocupa viewport inteiro
- `prose prose-sm max-w-none` — tipografia editorial para conteúdo HTML

## Receita

### Estrutura base

`MediaLayout.razor` com header, menu mobile, conteúdo e footer.

```razor
@* MediaLayout.razor — shell de Media/Content *@
@inherits LayoutComponentBase
@inject NavigationManager Nav

@code {
    private bool menuMobileAberto;
    private string busca = "";

    private void Buscar(ChangeEventArgs e)
    {
        busca = e.Value?.ToString() ?? "";
        if (!string.IsNullOrEmpty(busca))
            Nav.NavigateTo($"/busca?q={Uri.EscapeDataString(busca)}");
    }
}

<div class="min-h-screen flex flex-col">

    @* Header fixo *@
    <header class="sticky top-0 z-10 bg-white border-b border-light-200 shadow-sm">
        <div class="max-w-7xl mx-auto px-4">
            <Bar AdditionalClasses="py-3">
                <StartContent>
                    <a href="/" class="font-bold text-dark-800 text-lg mr-6">MediaApp</a>

                    @* Navegação de categorias desktop *@
                    <nav class="hidden md:flex items-center gap-1">
                        <NavLink href="/filmes"
                                 class="text-sm px-3 py-1 rounded-md text-dark-500 hover:bg-light-50"
                                 ActiveClass="bg-primary-50 text-primary-700 font-medium">
                            Filmes
                        </NavLink>
                        <NavLink href="/series"
                                 class="text-sm px-3 py-1 rounded-md text-dark-500 hover:bg-light-50"
                                 ActiveClass="bg-primary-50 text-primary-700 font-medium">
                            Séries
                        </NavLink>
                        <NavLink href="/documentarios"
                                 class="text-sm px-3 py-1 rounded-md text-dark-500 hover:bg-light-50"
                                 ActiveClass="bg-primary-50 text-primary-700 font-medium">
                            Documentários
                        </NavLink>
                        <NavLink href="/podcasts"
                                 class="text-sm px-3 py-1 rounded-md text-dark-500 hover:bg-light-50"
                                 ActiveClass="bg-primary-50 text-primary-700 font-medium">
                            Podcasts
                        </NavLink>
                    </nav>
                </StartContent>
                <EndContent>
                    @* Busca global *@
                    <TextField @bind-Value="busca" Placeholder="Buscar conteúdo..."
                               @oninput="Buscar" AdditionalClasses="w-48 hidden sm:block" />

                    @* Perfil / Auth *@
                    <AuthorizeView>
                        <Authorized>
                            <DropIconButton Icon="WellKnownIcons.User" Style="Themes.Default">
                                <DropItem Label="Minha lista"
                                          OnClick='() => Nav.NavigateTo("/minha-lista")' />
                                <DropItem Label="Perfil"
                                          OnClick='() => Nav.NavigateTo("/perfil")' />
                                <hr class="my-1 border-light-200" />
                                <DropItem Label="Sair" Style="Themes.Danger"
                                          OnClick="Logout" />
                            </DropIconButton>
                        </Authorized>
                        <NotAuthorized>
                            <Button Style="Themes.Primary" Size="Sizes.Small" Label="Entrar"
                                    OnClick='() => Nav.NavigateTo("/login")' />
                        </NotAuthorized>
                    </AuthorizeView>

                    @* Trigger menu mobile *@
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

    @* Footer leve *@
    <footer class="border-t border-light-200 py-6 mt-8 bg-light-50">
        <div class="max-w-7xl mx-auto px-4">
            <Bar>
                <StartContent>
                    <p class="text-xs text-dark-400">© 2026 MediaApp</p>
                </StartContent>
                <EndContent>
                    <a href="/privacidade"
                       class="text-xs text-dark-400 hover:underline">Privacidade</a>
                    <a href="/termos"
                       class="text-xs text-dark-400 hover:underline">Termos</a>
                    <a href="/contato"
                       class="text-xs text-dark-400 hover:underline">Contato</a>
                </EndContent>
            </Bar>
        </div>
    </footer>
</div>

@* Menu mobile de categorias *@
<OffCanvas Title="Navegar" @bind-IsOpen="menuMobileAberto"
           Position="OffCanvasPosition.Start" Size="OffCanvasSize.Small">
    <ChildContent>
        <div class="px-3 py-2 border-b border-light-100">
            <TextField @bind-Value="busca" Placeholder="Buscar..." @oninput="Buscar" />
        </div>
        <nav>
            <Stack Gap="Gaps.None">
                @foreach (var item in new[] { ("/", "Início"), ("/filmes", "Filmes"),
                    ("/series", "Séries"), ("/documentarios", "Documentários"),
                    ("/podcasts", "Podcasts") })
                {
                    <a href="@item.Item1"
                       class="block px-4 py-3 text-sm text-dark-600 hover:bg-light-50
                              border-b border-light-100 last:border-0"
                       @onclick="() => menuMobileAberto = false">
                        @item.Item2
                    </a>
                }
            </Stack>
        </nav>
    </ChildContent>
</OffCanvas>
```

### Cenários de composição

#### Grade de catálogo em página de listagem

```razor
@* Página de catálogo — usa Container+Slot+Box *@
@page "/filmes"
@layout MediaLayout

<div class="max-w-7xl mx-auto px-4 py-8">
    <Bar AdditionalClasses="mb-6">
        <StartContent>
            <h1 class="text-xl font-bold text-dark-700">Filmes</h1>
        </StartContent>
        <EndContent>
            <DropButton Label="Ordenar" Style="Themes.Default">
                <DropItem Label="Mais recentes" OnClick="() => ordenar = "recentes"" />
                <DropItem Label="Melhor avaliados" OnClick="() => ordenar = "avaliados"" />
                <DropItem Label="Alfabético" OnClick="() => ordenar = "az"" />
            </DropButton>
        </EndContent>
    </Bar>

    <Container Columns="4" AdditionalClasses="mb-8">
        @foreach (var item in filmes)
        {
            <Slot>
                <Box Border="BorderBuilder.None"
                     AdditionalClasses="overflow-hidden cursor-pointer hover:shadow-md transition-shadow rounded-lg"
                     @onclick='() => Nav.NavigateTo($"/filmes/{item.Id}")'>
                    <img src="@item.ThumbnailUrl" alt="@item.Titulo"
                         class="w-full h-48 object-cover" />
                    <div class="p-3">
                        <p class="text-sm font-semibold text-dark-700 truncate">@item.Titulo</p>
                        <div class="flex items-center gap-2 mt-1">
                            <Badge Style="Themes.Light" Text="@item.Ano.ToString()" />
                            <Badge Style="@item.GeneroTema" Text="@item.Genero" />
                        </div>
                    </div>
                </Box>
            </Slot>
        }
    </Container>

    <Pagination CurrentPage="@pagina" TotalPages="@totalPaginas"
                OnPageChanged="MudarPagina" />
</div>
```

#### Detalhe de artigo editorial

```razor
@* Detalhe de artigo com conteúdo HTML *@
<div class="max-w-3xl mx-auto px-4 py-8">
    <Bar AdditionalClasses="mb-6">
        <StartContent>
            <div>
                <div class="flex gap-2 mb-2">
                    <Badge Style="Themes.Primary" Text="@artigo.Categoria" />
                    <span class="text-xs text-dark-400">
                        @artigo.PublicadoEm.ToString("dd/MM/yyyy")
                    </span>
                </div>
                <h1 class="text-2xl font-bold text-dark-800">@artigo.Titulo</h1>
            </div>
        </StartContent>
    </Bar>
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-6">
        <div class="prose prose-sm max-w-none text-dark-600">
            @((MarkupString)artigo.ConteudoHtml)
        </div>
    </Box>
</div>
```

### Estados de página

- `loading` (grade): `Container(Columns=4)` com `Slot + Box animate-pulse h-64` por item;
- `empty` (sem resultados): `Feedback(Light) "Nenhum conteúdo encontrado."`;
- `error`: `Feedback(Danger)` com `Button "Tentar novamente"`.

## Limites

- Sem carrossel de destaques nativo — implementar com CSS `overflow-x-scroll snap-x` ou biblioteca externa;
- Player de vídeo `<video controls>` sem customização visual — aparência varia por browser;
- `@((MarkupString)html)` requer sanitização do HTML antes de renderizar — risco XSS;
- `Container(Columns=4)` para catálogo: colapsa para 1 coluna no mobile — considerar `Columns=2` em telas médias via layout dedicado;
- `AppLayout` NÃO deve ser usado neste shell.

### Responsividade

Header: categorias `hidden md:flex`, trigger mobile `md:hidden`. Grade: `Container(Columns=4)` → 1 col mobile, 2 col tablet, 4 col desktop (automático). Busca: `hidden sm:block` no header desktop, disponível no OffCanvas mobile.
