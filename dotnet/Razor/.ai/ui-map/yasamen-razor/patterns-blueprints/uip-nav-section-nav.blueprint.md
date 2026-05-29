# UIP-NAV-SECTION_NAV - Blueprint resumido

## Pattern

UIP-NAV-SECTION_NAV — Section Nav — ver `uip-nav-section-nav.ui-map.md`

## Gap coberto

A lib não tem componente de navegação por seção com scroll suave (anchor links dentro de página). O gap é orientar o padrão de `Bar + Button(Active)` para indicação da seção atual e scroll para a âncora via JS.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Bar + Button(Active=true)` cobrem o indicador visual da seção ativa; scroll suave requer `JS.InvokeVoidAsync("scrollIntoView", ...)`.

## Componentes usados

- `Bar` — papel: principal (container da nav) — ver `bar.sample.md`
- `Button` — papel: composição (item de nav) — ver `button.sample.md`

## Recursos visuais

- `sticky top-0 z-10 bg-white` — navbar que gruda no topo ao fazer scroll
- `border-b border-light-200` — separador visual da nav
- `Button.Active` — indica seção corrente visualmente

## Receita

`Bar` sticky + `Button(Active)` por seção; scroll programático via JS ou links `href="#anchorId"`.

```razor
@inject IJSRuntime JS

@code {
    private string secaoAtiva = "resumo";

    private async Task Navegar(string secaoId)
    {
        secaoAtiva = secaoId;
        await JS.InvokeVoidAsync("document.getElementById(arguments[0]).scrollIntoView",
            new object[] { secaoId });
    }
}

@* Nav de seção sticky *@
<div class="sticky top-0 z-10 bg-white">
    <Bar AdditionalClasses="border-b border-light-200 px-1">
        <StartContent>
            @foreach (var (id, label) in new[] {
                ("resumo", "Resumo"),
                ("detalhes", "Detalhes"),
                ("historico", "Histórico"),
                ("anexos", "Anexos")
            })
            {
                <Button Label="@label"
                        Style="Themes.Default"
                        Active="@(secaoAtiva == id)"
                        Outline="@(secaoAtiva != id)"
                        Size="Sizes.Small"
                        OnClick="async () => await Navegar(id)" />
            }
        </StartContent>
    </Bar>
</div>

@* Conteúdo com âncoras *@
<div class="space-y-8 mt-4">
    <section id="resumo">
        <h2 class="text-base font-semibold text-dark-700 mb-3">Resumo</h2>
        @* conteúdo *@
    </section>
    <section id="detalhes">
        <h2 class="text-base font-semibold text-dark-700 mb-3">Detalhes</h2>
        @* conteúdo *@
    </section>
    <section id="historico">
        <h2 class="text-base font-semibold text-dark-700 mb-3">Histórico</h2>
        @* conteúdo *@
    </section>
    <section id="anexos">
        <h2 class="text-base font-semibold text-dark-700 mb-3">Anexos</h2>
        @* conteúdo *@
    </section>
</div>
```

## Limites

- Detecção automática da seção visível (IntersectionObserver) exige JS adicional — o padrão acima atualiza `secaoAtiva` apenas ao clicar, não ao fazer scroll manual;
- Para navegação entre páginas (não seções), usar `NavLink` Blazor em vez de `Button`.
