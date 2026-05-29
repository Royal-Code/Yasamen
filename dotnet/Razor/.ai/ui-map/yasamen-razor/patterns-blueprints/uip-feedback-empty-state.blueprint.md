# UIP-FEEDBACK-EMPTY_STATE - Blueprint resumido

## Pattern

UIP-FEEDBACK-EMPTY_STATE — Empty State — ver `uip-feedback-empty-state.ui-map.md`

## Gap coberto

`Feedback` cobre o empty state básico com texto, mas não provê ação de recuperação embutida. O gap é orientar como combinar `Feedback` com `Button` (ação de recuperação) e quando usar `Box+Stack` centralizado em vez de `Feedback`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Feedback` + `ChildContent` cobre o padrão direto; `Box+Stack` para empty state de página inteira que precisa de mais controle visual.

## Componentes usados

- `Feedback` — papel: principal — ver `feedback.sample.md`
- `Button` — papel: composição (ação de recuperação) — ver `button.sample.md`
- `Box` — papel: composição (container de página inteira) — ver `box.sample.md`
- `Stack` — papel: composição — ver `stack.sample.md`

## Recursos visuais

- `flex-1 flex items-center justify-center` — centralização vertical em painel flex
- `Themes.Light` — tom neutro para empty state
- `WellKnownIcons.Inbox`, `WellKnownIcons.Search` — ícones semânticos de vazio

## Receita

Usar `Feedback` para empty states inline; `Box+Stack` centralizado para empty states de página inteira.

```razor
@* Empty state inline — dentro de lista ou painel *@
@if (!itens.Any())
{
    <Feedback Style="Themes.Light" Text="Nenhum item encontrado." />
}

@* Empty state com ação de recuperação *@
@if (!itens.Any())
{
    <Feedback Style="Themes.Light" Text="Nenhum resultado para os filtros aplicados.">
        <ChildContent>
            <Button Style="Themes.Default" Size="Sizes.Small"
                    Label="Limpar filtros" OnClick="LimparFiltros" />
        </ChildContent>
    </Feedback>
}

@* Empty state de página inteira (após loading) *@
@if (!itens.Any())
{
    <div class="flex-1 flex items-center justify-center p-8">
        <div class="text-center max-w-xs">
            <div class="w-16 h-16 rounded-full bg-light-100 flex items-center justify-center
                        mx-auto mb-4 text-dark-300">
                <Icon Kind="WellKnownIcons.Inbox" />
            </div>
            <h3 class="text-base font-semibold text-dark-600 mb-1">Nenhum item</h3>
            <p class="text-sm text-dark-400 mb-4">
                Crie o primeiro item para começar.
            </p>
            <Button Style="Themes.Primary" Label="Criar item" OnClick="AbrirCriacao" />
        </div>
    </div>
}

@* Empty state após busca sem resultados *@
@if (busca.Length > 0 && !itensFiltrados.Any())
{
    <Feedback Style="Themes.Light"
              Text="@($"Nenhum resultado para \"{busca}\".")">
        <ChildContent>
            <Button Style="Themes.Default" Size="Sizes.Small"
                    Label="Limpar busca" OnClick="() => busca = string.Empty" />
        </ChildContent>
    </Feedback>
}
```

## Limites

- `Feedback` não centraliza verticalmente em painéis flex — envolver com `flex items-center justify-center` quando necessário;
- Ilustrações/SVGs de empty state exigem assets externos não fornecidos pela lib.
