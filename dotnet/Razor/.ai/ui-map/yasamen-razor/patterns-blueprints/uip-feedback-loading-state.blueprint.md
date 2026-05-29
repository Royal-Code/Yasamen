# UIP-FEEDBACK-LOADING_STATE - Blueprint resumido

## Pattern

UIP-FEEDBACK-LOADING_STATE — Loading State — ver `uip-feedback-loading-state.ui-map.md`

## Gap coberto

A lib cobre loading de botão via `RotationMotion + IconAnimation`, mas não tem componente de skeleton para listas e zonas de página. O gap é orientar os dois cenários: loading inline em ação (botão/ícone) e skeleton de zona/lista via `animate-pulse`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `RotationMotion` + `Button.IconAnimation` + `Button.Disabled` cobrem loading de ação; skeleton de zona usa `animate-pulse` + divs placeholder sem componente dedicado.

## Componentes usados

- `Button` — papel: principal (loading de ação) — ver `button.sample.md`
- `IconButton` — papel: composição — ver `button.sample.md`
- `RotationMotion` — papel: principal (spinner) — ver `rotate-effect.sample.md`

## Recursos visuais

- `animate-pulse` — animação de skeleton (Tailwind built-in)
- `bg-light-100`, `bg-light-200` — cores de placeholder de skeleton
- `rounded`, `rounded-full` — formas de skeleton

## Receita

Para ação: `RotationMotion` em `IconAnimation` + `Disabled`; para zona: placeholders com `animate-pulse`.

```razor
@code {
    private bool salvando;
    private bool carregando = true;

    private AnimationFragment? Girando =>
        salvando ? new RotationMotionFragment() : null;
}

@* Loading de ação em botão *@
<Button Style="Themes.Primary"
        Label="@(salvando ? "Salvando..." : "Salvar")"
        Icon="WellKnownIcons.Save"
        IconAnimation="@Girando"
        Disabled="@salvando"
        OnClick="Salvar" />

@* Skeleton de lista de itens *@
@if (carregando)
{
    <Stack Gap="Gaps.None">
        @for (int i = 0; i < 5; i++)
        {
            <div class="animate-pulse border-b border-light-100 px-4 py-3">
                <div class="flex items-center gap-3">
                    <div class="w-8 h-8 rounded-full bg-light-200 flex-shrink-0"></div>
                    <div class="flex-1 space-y-1.5">
                        <div class="h-3 bg-light-200 rounded w-3/4"></div>
                        <div class="h-2.5 bg-light-100 rounded w-1/2"></div>
                    </div>
                    <div class="h-5 w-14 bg-light-100 rounded-full"></div>
                </div>
            </div>
        }
    </Stack>
}
else
{
    @* conteúdo real *@
}

@* Skeleton de card de KPI *@
@if (carregando)
{
    <div class="animate-pulse p-4">
        <div class="h-3 bg-light-200 rounded w-1/2 mb-2"></div>
        <div class="h-7 bg-light-200 rounded w-3/4 mb-2"></div>
        <div class="h-4 w-16 bg-light-100 rounded-full"></div>
    </div>
}

@* Spinner de zona (ex: tabela recarregando) *@
@if (carregando)
{
    <div class="flex items-center justify-center py-12 text-dark-400 gap-2">
        <RotationMotion />
        <span class="text-sm">Carregando...</span>
    </div>
}
```

## Limites

- Skeleton não tem componente dedicado — shapes precisam ser ajustados manualmente para cada layout;
- `RotationMotion` como spinner standalone pode não existir como uso direto (verificar API — pode ser necessário via `Button.IconAnimation`).
