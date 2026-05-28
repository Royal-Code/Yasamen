# UIP-NAV-SECTION_NAV - Section Nav

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de navegação por seções/âncoras. Requer composição manual com Bar + Button e CSS para scrollspy.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Bar
- `cobertura`: barra de links de seção em linha horizontal com Start/Center/End; adequado para navegação horizontal de seções;
- `limitações`: sem comportamento de scroll-to-anchor; sem destaque automático de seção ativa;
- `nota`: 5;
- `justificativa`: bom container visual mas sem lógica de navegação por seção.

2. Button
- `cobertura`: link de seção com estilo visual de ativo/inativo via `Active=true`;
- `limitações`: sem scroll automático — requer JS interop; sem detecção de seção ativa;
- `nota`: 5;
- `justificativa`: item de navegação com estado ativo controlável.

**Descartados**: nenhum relevante.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `scroll para seção ao clicar`: requer JS interop `scrollIntoView`;
  - `destaque automático da seção ativa (scrollspy)`: não suportado — implementar com `IntersectionObserver` JS ou controlar manualmente via scroll events;
  - `nav sticky`: requer CSS `position: sticky` via `AdditionalClasses`.

- `tipo de adaptação`: composição + estilos
- `o que precisa ser feito`:
  - Barra de links: `Bar` com `Button` por seção (`Active="@(secaoAtiva==i)"`);
  - Scroll ao clicar: `JS.InvokeVoidAsync("document.getElementById(...).scrollIntoView")`;
  - Sticky: `AdditionalClasses="sticky top-[60px] z-10 bg-white"` na Bar.

## Como usar

### Navegação por seções (composição manual)

```razor
@code {
    private string secaoAtiva = "dados";
    
    private async Task ScrollParaSecao(string secaoId)
    {
        secaoAtiva = secaoId;
        await JS.InvokeVoidAsync("eval", 
            $"document.getElementById('{secaoId}').scrollIntoView({{behavior:'smooth'}})");
    }
}

<Bar AdditionalClasses="sticky top-[60px] z-10 bg-white border-b border-light-200 mb-4">
    <StartContent>
        <ButtonGroup>
            <Button Label="Dados" Active="@(secaoAtiva=="dados")"
                    Style="Themes.Default"
                    OnClick="() => ScrollParaSecao("dados")" />
            <Button Label="Endereço" Active="@(secaoAtiva=="endereco")"
                    Style="Themes.Default"
                    OnClick="() => ScrollParaSecao("endereco")" />
            <Button Label="Histórico" Active="@(secaoAtiva=="historico")"
                    Style="Themes.Default"
                    OnClick="() => ScrollParaSecao("historico")" />
        </ButtonGroup>
    </StartContent>
</Bar>

<div id="dados"><h2 class="text-lg font-semibold mb-4">Dados</h2>@* ... *@</div>
<div id="endereco"><h2 class="text-lg font-semibold mb-4">Endereço</h2>@* ... *@</div>
<div id="historico"><h2 class="text-lg font-semibold mb-4">Histórico</h2>@* ... *@</div>
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de section nav; scroll para âncora requer JS interop; scrollspy requer implementação JS de IntersectionObserver; sticky requer classe CSS manual;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Bar` + `Button Active` fornecem a estrutura visual básica de navegação por seções;
  - Toda a lógica de scroll, destaque ativo e sticky é implementação manual;
  - Nota 3 reflete que apenas o container visual é coberto — sem comportamento de section nav.
