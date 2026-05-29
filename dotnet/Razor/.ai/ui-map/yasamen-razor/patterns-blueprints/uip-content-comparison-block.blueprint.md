# UIP-CONTENT-COMPARISON_BLOCK - Blueprint resumido

## Pattern

UIP-CONTENT-COMPARISON_BLOCK — Comparison Block — ver `uip-content-comparison-block.ui-map.md`

## Gap coberto

A lib não tem componente de comparison block. O gap é orientar dois cenários: comparação antes/depois com highlights de diferença via CSS de borda colorida, e tabela de comparação de planos com destaque de plano recomendado.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: grid CSS `grid-cols-2` com `Box` por lado; `Badge` para label de versão; `bg-success-50 border-l-2 border-success-400` para linhas adicionadas; `bg-danger-50 border-l-2 border-danger-400` para linhas removidas.

## Componentes usados

- `Box` — papel: principal (container de cada lado) — ver `box.sample.md`
- `Bar` — papel: composição (header e toolbar de ações) — ver `bar.sample.md`
- `Badge` — papel: composição (label de versão/estado) — ver `badge.sample.md`
- `Button` — papel: composição (aprovar/rejeitar) — ver `button.sample.md`

## Recursos visuais

- `grid grid-cols-1 sm:grid-cols-2 gap-4` — layout lado a lado responsivo
- `bg-success-50 border-l-2 border-success-400 pl-2 -ml-2` — linha adicionada
- `bg-danger-50 border-l-2 border-danger-400 pl-2 -ml-2` — linha removida
- `ring-2 ring-primary-200` — destaque de plano recomendado

## Receita

Grid CSS `cols-2` com `Box` por lado; CSS de borda colorida para highlights; `Badge` para labels.

```razor
@* Comparação antes/depois com diferenças *@
<div class="mb-4">
    <Bar AdditionalClasses="mb-3">
        <StartContent>
            <h3 class="text-sm font-semibold text-dark-600">Comparação de alterações</h3>
        </StartContent>
        <EndContent>
            <Button Style="Themes.Success" Label="Aprovar" OnClick="Aprovar" />
            <Button Style="Themes.Danger" Outline=true Label="Rejeitar" OnClick="Rejeitar" />
        </EndContent>
    </Bar>
    <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
        @* Lado atual *@
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <Bar AdditionalClasses="mb-3">
                <StartContent>
                    <Badge Style="Themes.Light" Text="Atual" />
                </StartContent>
            </Bar>
            <dl class="space-y-2">
                <div>
                    <dt class="text-xs text-dark-400">Nome</dt>
                    <dd class="text-sm text-dark-600">@versaoAtual.Nome</dd>
                </div>
                <div class="bg-danger-50 border-l-2 border-danger-400 pl-2 -ml-2">
                    <dt class="text-xs text-dark-400">Preço</dt>
                    <dd class="text-sm text-danger-700">@versaoAtual.Preco.ToString("C")</dd>
                </div>
            </dl>
        </Box>
        @* Lado proposto *@
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <Bar AdditionalClasses="mb-3">
                <StartContent>
                    <Badge Style="Themes.Primary" Text="Proposto" />
                </StartContent>
            </Bar>
            <dl class="space-y-2">
                <div>
                    <dt class="text-xs text-dark-400">Nome</dt>
                    <dd class="text-sm text-dark-600">@versaoNova.Nome</dd>
                </div>
                <div class="bg-success-50 border-l-2 border-success-400 pl-2 -ml-2">
                    <dt class="text-xs text-dark-400">Preço</dt>
                    <dd class="text-sm font-semibold text-success-700">
                        @versaoNova.Preco.ToString("C")
                    </dd>
                </div>
            </dl>
        </Box>
    </div>
</div>

@* Comparação de planos (tabela de pricing) *@
<div class="grid grid-cols-1 sm:grid-cols-3 gap-4 mb-6">
    @foreach (var plano in planos)
    {
        <Box Border="BorderBuilder.Box"
             AdditionalClasses="@($"p-4 {(plano.Destaque ? "border-primary-400 ring-2 ring-primary-200" : "")}")">
            @if (plano.Destaque)
            {
                <Badge Style="Themes.Primary" Text="Mais popular"
                       AdditionalClasses="mb-2 block text-center" />
            }
            <h4 class="font-semibold text-dark-600 mb-1">@plano.Nome</h4>
            <p class="text-2xl font-bold text-primary-600 mb-3">
                @plano.Preco.ToString("C")
                <span class="text-xs text-dark-400 font-normal">/mês</span>
            </p>
            <ul class="space-y-1 text-sm text-dark-500 mb-4">
                @foreach (var f in plano.Features)
                {
                    <li class="flex items-center gap-1">
                        <Icon Kind="WellKnownIcons.Check" class="text-success-500 text-xs" />
                        @f
                    </li>
                }
            </ul>
            <Button Style="@(plano.Destaque ? Themes.Primary : Themes.Secondary)"
                    Outline="@(!plano.Destaque)"
                    Label="Assinar"
                    AdditionalClasses="w-full"
                    OnClick="() => Assinar(plano.Id)" />
        </Box>
    }
</div>
```

## Limites

- Diff textual (word-level) requer biblioteca externa (diff-match-patch via JS interop) — highlights aqui são por linha/bloco manual;
- Para mobile: grid `cols-2` colapsa para `cols-1` (alternância "Atual"/"Proposto" via `ButtonGroup` oferece melhor UX).
