# PP-LANDING - Blueprint

## Identificação
- **Pattern**: PP-LANDING.
- **Nível final**: resumido.
- **Cobertura atual**: 2.
- **Meta de cobertura proposta**: 7.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `Box`, `Container`, `Slot`, `Button`, `Badge`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen não tem linguagem editorial forte, hero visual, mídia ou seções de marketing. Ela pode sustentar uma landing operacional simples, mas não deve ser tratada como design system promocional completo.

## Decisão arquitetural principal
Gerar apenas uma composição leve `[API proposta] OperationalLanding`, com CTA, blocos e prova simples, preservando a estética clara e semântica da biblioteca.

## Componentes reaproveitados
- `Container` e `Slot`: seções responsivas.
- `Box`: blocos de prova, callout e conteúdo.
- `Button` e `ButtonGroup`: CTAs.
- `Badge`: marcador leve.
- `Feedback`: aviso ou banner institucional.

## Peça proposta
`OperationalLanding` com `Hero`, `Sections`, `PrimaryAction`, `SecondaryAction` e `ProofBlocks`. Não incluir hero com gradiente ou mídia inventada.

## Bloco principal de código

```razor
@* [API proposta] landing operacional, não marketing pesado *@
<main class="bg-light-100 text-dark-900">
    <section class="bg-white border-b border-light-300">
        <Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default" AdditionalClasses="py-10 gap-6">
            <Slot Span="4" LaptopSpan="7">
                <Stack AdditionalClasses="space-y-5">
                    <Badge Text="Blazor UI" Style="Themes.Info" />
                    <h1 class="text-3xl font-medium text-dark-900">Interfaces operacionais com componentes Yasamen</h1>
                    <p class="text-dark-600 leading-base">Uma entrada clara para documentação, produto interno ou autoatendimento simples.</p>
                    <ButtonGroup AriaLabel="Ações de entrada">
                        <Button Label="Começar" Style="Themes.Primary" />
                        <Button Label="Ver exemplos" Style="Themes.Light" />
                    </ButtonGroup>
                </Stack>
            </Slot>
            <Slot Span="4" LaptopSpan="5">
                <Box AdditionalClasses="p-6 bg-light-100 border border-light-300 rounded-md">
                    <Feedback Style="Themes.Info" Title="Destaque" Text="Use este espaço para prova, status ou resumo." Block="true" />
                </Box>
            </Slot>
        </Container>
    </section>
</main>
```

## Exemplo principal de uso
Use em página inicial de documentação, onboarding interno ou produto operacional. Para campanha visual rica, combinar com assets reais e validar direção visual fora do escopo Yasamen.

## Justificativa breve da cobertura proposta
A meta fica em 7 porque o pattern exige hero, prova e narrativa; Yasamen sustenta estrutura, mas não fornece mídia/branding editorial.

## Limitações remanescentes
- Sem componente de media viewer ou hero.
- Sem sistema de ilustração.
- Sem diretrizes de copy ou marketing.

## Pontos de adaptação
- Inserir imagem real quando o produto exigir inspeção visual.
- Manter CTA principal em `Themes.Primary`.
- Evitar transformar landing em dashboard ou workspace.
