# PP-LANDING - Blueprint resumido

## Pattern

PP-LANDING — Landing Page — ver `pp-landing.ui-map.md`

## Gap coberto

A lib é focada em apps operacionais. O gap é orientar o uso de `Button + Container+Slot + Box + Feedback` nos elementos reutilizáveis da landing (CTAs, grade de features, callouts) dentro de um esqueleto HTML/Tailwind.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: estrutura principal em HTML/Tailwind (hero, seções, footer); `Button(Primary)` para CTAs; `Container(Columns=3) + Slot + Box` para grade de features; `Feedback(Primary)` para callouts de destaque.

## Componentes usados

- `Button` — papel: principal (CTAs) — ver `button.sample.md`
- `Container + Slot` — papel: composição (grade de features) — ver `bar.sample.md`
- `Box` — papel: composição (card de feature) — ver `box.sample.md`
- `Bar` — papel: composição (header e footer da landing) — ver `bar.sample.md`
- `Feedback` — papel: composição (callout editorial) — ver `feedback.sample.md`

## Recursos visuais

- `bg-gradient-to-b from-primary-50 to-white` — fundo do hero
- `text-4xl font-bold text-dark-800` — headline do hero
- `sticky top-0 z-10 bg-white border-b border-light-200` — header fixo
- `max-w-2xl mx-auto` — container de conteúdo centralizado

## Receita

Header fixo com `Bar`; hero HTML; grade de features com `Container+Slot+Box`; callout com `Feedback`; CTA final.

```razor
@page "/"
@inject NavigationManager Nav

@* Header fixo *@
<header class="sticky top-0 z-10 bg-white border-b border-light-200 px-6 py-3">
    <Bar>
        <StartContent>
            <span class="font-bold text-dark-700">MeuApp</span>
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
            @foreach (var f in features)
            {
                <Slot>
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-6 text-center">
                        <div class="w-12 h-12 rounded-full bg-primary-100 flex items-center
                                    justify-center mx-auto mb-4 text-primary-600 text-xl">
                            <Icon Kind="@f.Icone" />
                        </div>
                        <h3 class="text-base font-semibold text-dark-700 mb-2">@f.Titulo</h3>
                        <p class="text-sm text-dark-400">@f.Descricao</p>
                    </Box>
                </Slot>
            }
        </Container>
    </div>
</section>

@* Callout de destaque *@
<section class="px-6 py-8 bg-light-50">
    <div class="max-w-3xl mx-auto">
        <Feedback Style="Themes.Primary">
            <ChildContent>
                <p class="font-semibold">Mais de 10.000 equipes já usam nossa plataforma.</p>
                <Button Style="Themes.Primary" Size="Sizes.Small"
                        Label="Junte-se a elas" AdditionalClasses="mt-2"
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

## Limites

- Lib foi projetada para apps operacionais — landing pages editoriais com animações, depoimentos, FAQ accordion, pricing table, etc. requerem componentes HTML/Tailwind adicionais;
- `AppLayout` não deve ser usado em landing pages — usar `@layout EmptyLayout` ou sem layout.
