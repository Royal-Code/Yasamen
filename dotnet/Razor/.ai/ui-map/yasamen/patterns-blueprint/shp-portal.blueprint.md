# SHP-PORTAL - Blueprint

## Identificação
- **Pattern**: SHP-PORTAL - Portal.
- **Nível final**: resumido.
- **Cobertura atual**: 5.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `shell.pattern.md`, samples de `AppLayout`, `Button`, `Box`, `Container`, `Slot`, `Breadcrumb`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen monta header, conteúdo, footer, CTA e blocos informativos, mas não possui uma composição pronta para portal público com navegação superior simples, seções lineares, CTA dominante e rodapé informativo. O risco para outra IA é transformar o portal em shell administrativo ou landing ornamental fora da linguagem operacional da biblioteca.

## Decisão arquitetural principal
Criar uma composição de portal leve como peça de aplicação, não como componente oficial da biblioteca: `[API proposta] PortalShell`. Ela deve reaproveitar `AppLayout` quando houver necessidade de outlets globais, ou `Box`/HTML semântico quando a página for pública e simples.

## Componentes reaproveitados
- `AppLayout`: quando portal precisa de modal, offcanvas ou notification outlets já alinhados ao shell.
- `Container` e `Slot`: grade 4/8/12/16 para seções responsivas.
- `Box`: superfícies brancas com borda leve.
- `Button` e `ButtonGroup`: CTA principal e ações secundárias.
- `Breadcrumb` ou `DescribesBreadcrumbs`: páginas internas de portal, não hero inicial.
- `Feedback`: aviso institucional persistente.

## Peça proposta
`[API proposta] PortalShell` deve expor `Header`, `Main`, `Footer`, `NavItems`, `PrimaryAction` e `MobileMenu`. A peça não deve criar tema visual próprio; deve usar `bg-white`, `bg-light-100`, `border-light-300`, texto `dark` e `Themes.Primary` para CTA.

## Bloco principal de código

```razor
@* [API proposta] composição de portal baseada em Yasamen *@
<div class="min-h-screen bg-light-100 text-dark-900">
    <header class="sticky top-0 z-app-bar bg-white border-b border-light-300">
        <Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default" AdditionalClasses="items-center py-5">
            <Slot Span="2" LaptopSpan="3">
                <a class="font-semibold text-dark-900" href="/">Yasamen Portal</a>
            </Slot>
            <Slot Span="2" LaptopSpan="6">
                <nav class="hidden md:flex gap-6 text-sm text-dark-600">
                    <a href="/docs">Docs</a>
                    <a href="/components">Componentes</a>
                    <a href="/support">Suporte</a>
                </nav>
            </Slot>
            <Slot Span="4" LaptopSpan="3">
                <div class="flex justify-end">
                    <Button Label="Começar" Style="Themes.Primary" Size="Sizes.Small" />
                </div>
            </Slot>
        </Container>
    </header>

    <main>
        <section class="bg-white border-b border-light-300">
            <Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default" AdditionalClasses="py-10 gap-6">
                <Slot Span="4" LaptopSpan="7">
                    <div class="space-y-5">
                        <h1 class="text-3xl font-medium text-dark-900">Componentes Blazor para interfaces operacionais</h1>
                        <p class="text-dark-600 leading-base">Portal de entrada com CTA claro e progressão linear.</p>
                        <ButtonGroup AriaLabel="Ações principais">
                            <Button Label="Ver documentação" Style="Themes.Primary" />
                            <Button Label="Explorar exemplos" Style="Themes.Light" />
                        </ButtonGroup>
                    </div>
                </Slot>
                <Slot Span="4" LaptopSpan="5">
                    <Box AdditionalClasses="p-6 bg-light-100 border border-light-300 rounded-md">
                        <Feedback Style="Themes.Info" Title="Status" Text="Use este bloco para aviso público ou onboarding." Block="true" />
                    </Box>
                </Slot>
            </Container>
        </section>
    </main>
</div>
```

## Exemplo principal de uso
Use este blueprint para portal institucional, documentação pública, área de ajuda ou entrada de produto. Para páginas internas, adicione `Breadcrumb` antes do título e mantenha ações com `ButtonGroup`.

## Justificativa da cobertura proposta
A composição atende navegação superior, progressão linear, CTA, seções e responsividade sem inventar tokens. A cobertura não vira 9 porque Yasamen ainda não tem componente nativo de portal, menu mobile específico ou sistema editorial.

## Limitações remanescentes
- Menu mobile é composição proposta e precisa ser implementado com `OffCanvas` se houver muitos links.
- Hero editorial, imagens e mídia continuam fora da cobertura nativa.
- Não usar este shell para sistemas internos densos; nesse caso `SHP-WORKSPACE_ADMIN` já é melhor.

## Pontos de adaptação
- Trocar links e CTA por rotas do repositório destino.
- Substituir textos por conteúdo real e manter semântica de cor por `Themes`.
- Se o portal usar login, isolar a ação no `TopEnd` e evitar sidebar administrativa.
