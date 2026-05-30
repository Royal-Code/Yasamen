# SHP-PORTAL - Blueprint completo

## Pattern

SHP-PORTAL — Portal — ver `shp-portal.ui-map.md`

## Gap coberto

A lib é focada em apps operacionais. O gap é orientar o shell público (portal institucional) sem `AppLayout`: header com navegação desktop + `OffCanvas` para menu mobile, `Container+Slot+Box` para grades de conteúdo, footer editorial com `Container(Columns=4)`, e uso de `@layout EmptyLayout` ou `PortalLayout`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `PortalLayout.razor` com header `sticky top-0` + navegação desktop `hidden md:flex` + `IconButton(Menu)` mobile + `OffCanvas(Start)` para menu mobile; `Container+Slot+Box` para grades de seção; footer `bg-dark-800` com `Container(Columns=4)`; sem `AppLayout`.
- `eixos cobertos sem componente novo`:
  - header sticky → HTML `<header class="sticky top-0">` + `Bar`;
  - navegação desktop → `<nav class="hidden md:flex">` + `<a>` com classes Tailwind;
  - menu mobile → `IconButton(Menu) + OffCanvas(Start)`;
  - grades de conteúdo → `Container+Slot+Box`;
  - formulários leves → `EditForm + TextField + Button`;
  - footer → `Container(Columns=4)` + HTML.

## Componentes usados

- `Bar` — papel: principal (header do portal) — ver `bar.sample.md`
- `OffCanvas` — papel: principal (menu mobile) — ver `modal.sample.md`
- `Container + Slot` — papel: composição (grades de conteúdo e footer) — ver `container.sample.md`
- `Box` — papel: composição (cards de seção, feature, artigo) — ver `box.sample.md`
- `Button` — papel: composição (CTAs e ações) — ver `button.sample.md`
- `IconButton` — papel: composição (trigger do menu mobile) — ver `button.sample.md`
- `Stack` — papel: composição (links do menu mobile) — ver `stack.sample.md`
- `Feedback` — papel: composição (callouts editoriais) — ver `feedback.sample.md`

## Recursos visuais

- `sticky top-0 z-10 bg-white border-b border-light-200` — header fixo
- `max-w-6xl mx-auto px-4` — container de largura máxima
- `hidden md:flex` — elementos visíveis apenas em desktop
- `md:hidden` — elementos visíveis apenas em mobile
- `bg-dark-800 text-white` — footer escuro editorial

## Receita

### Estrutura base

`PortalLayout.razor` com header, menu mobile, conteúdo e footer.

```razor
@* PortalLayout.razor — shell de Portal público *@
@inherits LayoutComponentBase
@inject NavigationManager Nav

@code {
    private readonly OffCanvasHandler menuMobileHandler = new();
}

@* Header fixo *@
<header class="sticky top-0 z-10 bg-white border-b border-light-200 shadow-sm">
    <div class="max-w-6xl mx-auto px-4">
        <Bar AdditionalClasses="py-3">
            <StartContent>
                @* Logo *@
                <a href="/" class="flex items-center gap-2 mr-6">
                    <div class="w-8 h-8 rounded bg-primary-500 flex items-center justify-center">
                        <span class="text-white font-bold text-sm">P</span>
                    </div>
                    <span class="font-bold text-dark-700">Portal</span>
                </a>

                @* Navegação desktop *@
                <nav class="hidden md:flex items-center gap-1">
                    <a href="/sobre"
                       class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1 rounded-md hover:bg-light-50">
                        Sobre
                    </a>
                    <a href="/servicos"
                       class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1 rounded-md hover:bg-light-50">
                        Serviços
                    </a>
                    <a href="/blog"
                       class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1 rounded-md hover:bg-light-50">
                        Blog
                    </a>
                    <a href="/contato"
                       class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1 rounded-md hover:bg-light-50">
                        Contato
                    </a>
                </nav>
            </StartContent>
            <EndContent>
                @* CTAs desktop *@
                <div class="hidden md:flex items-center gap-2">
                    <a href="/login"
                       class="text-sm text-dark-500 hover:text-dark-700 px-3 py-1">
                        Entrar
                    </a>
                    <Button Style="Themes.Primary" Size="Sizes.Small" Label="Criar conta"
                            OnClick='() => Nav.NavigateTo("/registro")' />
                </div>

                @* Trigger menu mobile *@
                <IconButton Icon="WellKnownIcons.Menu" Style="Themes.Default"
                            AdditionalClasses="md:hidden"
                            OnClick="async () => await menuMobileHandler.Show()" />
            </EndContent>
        </Bar>
    </div>
</header>

@* Conteúdo da página *@
<main>
    @Body
</main>

@* Footer editorial *@
<footer class="bg-dark-800 text-white px-6 py-10 mt-16">
    <div class="max-w-6xl mx-auto">
        <Container Columns="4">
            <Slot>
                <div>
                    <p class="text-sm font-semibold text-white mb-3">Portal</p>
                    <p class="text-xs text-dark-400 leading-relaxed">
                        Sua plataforma para serviços e informações.
                    </p>
                </div>
            </Slot>
            <Slot>
                <div>
                    <p class="text-xs font-semibold text-dark-400 uppercase tracking-wide mb-3">
                        Serviços
                    </p>
                    <Stack Gap="Gaps.Small">
                        @foreach (var link in new[] { "Serviço A", "Serviço B", "Serviço C" })
                        {
                            <a href="/servicos" class="text-xs text-dark-400 hover:text-white">
                                @link
                            </a>
                        }
                    </Stack>
                </div>
            </Slot>
            <Slot>
                <div>
                    <p class="text-xs font-semibold text-dark-400 uppercase tracking-wide mb-3">
                        Empresa
                    </p>
                    <Stack Gap="Gaps.Small">
                        @foreach (var link in new[] { ("Sobre", "/sobre"), ("Blog", "/blog"),
                            ("Contato", "/contato") })
                        {
                            <a href="@link.Item2" class="text-xs text-dark-400 hover:text-white">
                                @link.Item1
                            </a>
                        }
                    </Stack>
                </div>
            </Slot>
            <Slot>
                <div>
                    <p class="text-xs font-semibold text-dark-400 uppercase tracking-wide mb-3">
                        Newsletter
                    </p>
                    <p class="text-xs text-dark-400 mb-2">
                        Receba novidades por e-mail.
                    </p>
                    <EditForm Model="newsletter" OnValidSubmit="AssinarNewsletter">
                        <div class="flex gap-2">
                            <TextField @bind-Value="newsletter.Email"
                                       Placeholder="seu@email.com" />
                            <Button Style="Themes.Primary" Size="Sizes.Small"
                                    Label="OK" Type="submit" />
                        </div>
                    </EditForm>
                </div>
            </Slot>
        </Container>
        <div class="border-t border-dark-700 mt-8 pt-4">
            <Bar>
                <StartContent>
                    <p class="text-xs text-dark-400">
                        © 2026 Portal. Todos os direitos reservados.
                    </p>
                </StartContent>
                <EndContent>
                    <a href="/privacidade"
                       class="text-xs text-dark-400 hover:text-white">Privacidade</a>
                    <a href="/termos"
                       class="text-xs text-dark-400 hover:text-white">Termos</a>
                </EndContent>
            </Bar>
        </div>
    </div>
</footer>

@* Menu mobile *@
<OffCanvas Handler="@menuMobileHandler" Title="Menu"
           Position="Positions.Start" BoxSize="Sizes.Small">
    <ChildContent>
        <nav>
            <Stack Gap="Gaps.None">
                @foreach (var item in new[] { ("/", "Início"), ("/sobre", "Sobre"),
                    ("/servicos", "Serviços"), ("/blog", "Blog"), ("/contato", "Contato") })
                {
                    <a href="@item.Item1"
                       class="block px-4 py-3 text-sm text-dark-600 hover:bg-light-50
                              border-b border-light-100 last:border-0"
                       @onclick="async () => await menuMobileHandler.Hide()">
                        @item.Item2
                    </a>
                }
            </Stack>
        </nav>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Entrar"
                OnClick='async () => { Nav.NavigateTo("/login"); await menuMobileHandler.Hide(); }' />
        <Button Style="Themes.Primary" Label="Criar conta"
                OnClick='async () => { Nav.NavigateTo("/registro"); await menuMobileHandler.Hide(); }' />
    </FooterContent>
</OffCanvas>
```

### Cenários de composição

#### Seção hero na página home

```razor
@* Seção hero — HTML direto, sem componentes da lib *@
<section class="px-4 py-20 text-center bg-gradient-to-b from-primary-50 to-white">
    <div class="max-w-2xl mx-auto">
        <h1 class="text-4xl font-bold text-dark-800 mb-4">
            Título impactante da proposta
        </h1>
        <p class="text-lg text-dark-500 mb-8">Subtítulo explicativo em uma linha.</p>
        <div class="flex items-center justify-center gap-3 flex-wrap">
            <Button Style="Themes.Primary" Label="Começar gratuitamente"
                    OnClick='() => Nav.NavigateTo("/registro")' />
            <Button Style="Themes.Default" Label="Saiba mais"
                    OnClick='() => Nav.NavigateTo("/sobre")' />
        </div>
    </div>
</section>

@* Grade de features *@
<section class="px-4 py-16">
    <div class="max-w-5xl mx-auto">
        <h2 class="text-2xl font-bold text-dark-700 text-center mb-10">Funcionalidades</h2>
        <Container Columns="3">
            @foreach (var feature in features)
            {
                <Slot>
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-6 text-center">
                        <p class="text-base font-semibold text-dark-700 mb-2">@feature.Titulo</p>
                        <p class="text-sm text-dark-400">@feature.Descricao</p>
                    </Box>
                </Slot>
            }
        </Container>
    </div>
</section>
```

### Estados de página

Não aplicável como padrão de página (é um shell). As páginas filhas usam os padrões de estado habituais.

## Limites

- Sem mega-menu nem subnav hierárquico nativo — navegação horizontal simples com `<a>` Tailwind;
- Sem hero, testimonials, pricing table, FAQ accordion nativos — HTML/Tailwind a cargo do app;
- `@layout PortalLayout` deve ser declarado nas páginas do portal; usar `@layout EmptyLayout` quando não houver layout dedicado;
- `AppLayout` NÃO deve ser usado em portais públicos — adiciona sidebar de app operacional;
- SEO e meta tags requerem `<HeadContent>` Blazor — fora do escopo da lib.

### Responsividade

Header: elementos desktop em `hidden md:flex`, trigger mobile em `md:hidden`. Grades: `Container(Columns=3)` colapsa automaticamente. Footer: `Container(Columns=4)` → 1 col no mobile.
