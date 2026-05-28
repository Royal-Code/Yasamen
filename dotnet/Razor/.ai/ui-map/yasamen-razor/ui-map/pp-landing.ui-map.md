# PP-LANDING - Landing

**GAP parcial — lib focada em app operacional, não em landing pages editoriais**

A biblioteca foi construída para apps de negócio (CRUD, dashboards, formulários). Landing pages editoriais com hero, seções narrativas e CTAs de marketing requerem composição majoritariamente HTML/Tailwind, com os componentes de lib contribuindo apenas para primitivos de ação e conteúdo.

## Componentes por zona funcional

### Zona: Cabeçalho (Hero)

1. Box + HTML livre (hero section)
- `cobertura`: container do hero com padding e background; CTA com `Button Style=Primary`;
- `nota`: 5;
- `justificativa`: container estrutural do hero — texto, imagem e CTA são HTML/Tailwind.

### Zona: Conteúdo

1. Container+Slot (UIP-STRUCT-GRID_CONTAINER)
- `cobertura`: grade de 2-3 colunas para features, benefícios, cards editoriais;
- `nota`: 9;
- `justificativa`: grade responsiva de seção editorial.

2. Box (card de feature/benefício)
- `cobertura`: card visual com ícone, título e texto;
- `nota`: 7;
- `justificativa`: card de feature da landing.

3. `@((MarkupString)html)` (UIP-CONTENT-RICH_TEXT_BLOCK)
- `cobertura`: blocos de texto editorial com HTML pré-renderizado;
- `nota`: 6;
- `justificativa`: conteúdo editorial da seção.

4. Feedback Style=Light (callout/depoimento)
- `cobertura`: callout de benefício, alerta de promoção ou destaque editorial;
- `nota`: 6;
- `justificativa`: bloco de destaque editorial.

### Zona: Ações (CTAs)

1. Button Style=Primary (CTA primário)
- `cobertura`: botão de CTA principal ("Começar agora", "Criar conta", "Saiba mais");
- `nota`: 9;
- `justificativa`: CTA de conversão.

2. Bar + Button (barra de CTAs de seção)
- `cobertura`: toolbar de CTAs com primário + secundário;
- `nota`: 8;
- `justificativa`: ações de seção.

**Descartados**: AppLayout (navegação de app, não de landing); UIP-SURFACE-CHART, UIP-SURFACE-MAP (ver GAPs específicos).

## Composição completa da página

```razor
@page "/"

@* Navegação da landing *@
<header class="sticky top-0 z-10 bg-white border-b border-light-200 px-6 py-3">
    <Bar>
        <StartContent>
            <div class="flex items-center gap-2">
                <span class="font-bold text-dark-700">MeuApp</span>
            </div>
        </StartContent>
        <EndContent>
            <a href="/login" class="text-sm text-dark-500 hover:text-dark-700">Entrar</a>
            <Button Style="Themes.Primary" Size="Sizes.Small" Label="Começar grátis"
                    OnClick='() => Nav.NavigateTo("/registro")' />
        </EndContent>
    </Bar>
</header>

@* Hero *@
<section class="px-6 py-20 text-center bg-gradient-to-b from-primary-50 to-white">
    <div class="max-w-2xl mx-auto">
        <h1 class="text-4xl font-bold text-dark-800 mb-4">
            A plataforma que sua equipe precisa
        </h1>
        <p class="text-lg text-dark-500 mb-8">
            Gerencie seus projetos com facilidade e eficiência.
        </p>
        <div class="flex items-center justify-center gap-3 flex-wrap">
            <Button Style="Themes.Primary" Label="Começar gratuitamente"
                    OnClick='() => Nav.NavigateTo("/registro")' />
            <Button Style="Themes.Default" Label="Ver demonstração"
                    OnClick="AbrirDemo" />
        </div>
    </div>
</section>

@* Seção de features *@
<section class="px-6 py-16">
    <div class="max-w-5xl mx-auto">
        <h2 class="text-2xl font-bold text-dark-700 text-center mb-10">Por que escolher?</h2>
        <Container Columns="3">
            @foreach (var feature in features)
            {
                <Slot>
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-6 text-center">
                        <div class="w-12 h-12 rounded-full bg-primary-100 flex items-center
                                    justify-center mx-auto mb-4 text-primary-600 text-xl">
                            @feature.Icone
                        </div>
                        <h3 class="text-base font-semibold text-dark-700 mb-2">@feature.Titulo</h3>
                        <p class="text-sm text-dark-400">@feature.Descricao</p>
                    </Box>
                </Slot>
            }
        </Container>
    </div>
</section>

@* Callout de destaque *@
<section class="px-6 py-8 bg-light-50">
    <div class="max-w-3xl mx-auto">
        <Feedback Style="Themes.Primary" Text="Mais de 10.000 equipes já usam nossa plataforma.">
            <ChildContent>
                <Button Style="Themes.Primary" Size="Sizes.Small" Label="Junte-se a elas"
                        OnClick='() => Nav.NavigateTo("/registro")' />
            </ChildContent>
        </Feedback>
    </div>
</section>

@* CTA final *@
<section class="px-6 py-16 text-center">
    <div class="max-w-xl mx-auto">
        <h2 class="text-2xl font-bold text-dark-700 mb-3">Pronto para começar?</h2>
        <p class="text-dark-400 mb-6">Crie sua conta grátis em menos de 2 minutos.</p>
        <Button Style="Themes.Primary" Label="Criar conta gratuita"
                OnClick='() => Nav.NavigateTo("/registro")' />
    </div>
</section>

@* Footer *@
<footer class="border-t border-light-200 px-6 py-6">
    <Bar>
        <StartContent>
            <p class="text-xs text-dark-400">© 2026 MeuApp. Todos os direitos reservados.</p>
        </StartContent>
        <EndContent>
            <a href="/privacidade" class="text-xs text-dark-400 hover:underline">Privacidade</a>
            <a href="/termos" class="text-xs text-dark-400 hover:underline">Termos</a>
        </EndContent>
    </Bar>
</footer>
```

## Decisão de uso

- `nota geral`: 4;
- `limitações`: lib focada em apps operacionais, não em landing pages editoriais; hero, narrativa e seções editoriais são HTML/Tailwind puro; sem componentes de depoimento, FAQ accordion de marketing, planos de preço, etc.;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Container+Slot` + `Box` + `Button` + `Feedback` cobrem estrutura básica de landing simples;
  - Para landing pages editoriais complexas com mídia, animações e seções ricas, a lib tem papel secundário — a estrutura é HTML/Tailwind;
  - Nota 4 reflete que a lib não foi projetada para este padrão, mas viabiliza landing pages simples de forma funcional.
