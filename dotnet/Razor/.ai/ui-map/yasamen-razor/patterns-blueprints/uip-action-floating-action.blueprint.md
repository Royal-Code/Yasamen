# UIP-ACTION-FLOATING_ACTION - Blueprint resumido

## Pattern

UIP-ACTION-FLOATING_ACTION — Floating Action — ver `uip-action-floating-action.ui-map.md`

## Gap coberto

A lib não tem componente FAB dedicado. `Button` com `AdditionalClasses` de posicionamento CSS cobre o padrão. O gap é orientar o posicionamento correto, a variante de ícone-only (circular), e a proteção de sobreposição de conteúdo.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Button` + CSS `fixed bottom-6 right-6 z-50` + `rounded-full` para circular; nenhum componente adicional necessário.

## Componentes usados

- `Button` — papel: principal — ver `button.sample.md`
- `IconButton` — papel: composição (variante ícone-only) — ver `button.sample.md`

## Recursos visuais

- `fixed bottom-6 right-6` — posição padrão (baixo direito)
- `z-50` — acima do conteúdo e abaixo de modais
- `shadow-lg` — sombra que diferencia do conteúdo
- `rounded-full` — forma circular
- `pb-20` ou `mb-20` no conteúdo — margem para o FAB não sobrepor o último item

## Receita

`Button` com classes de posicionamento; padding no conteúdo para não cobrir o último item.

```razor
@* FAB com texto — ação primária da página *@
<Button Style="Themes.Primary"
        Icon="WellKnownIcons.Add"
        Label="Novo"
        AdditionalClasses="fixed bottom-6 right-6 z-50 shadow-lg"
        OnClick="AbrirCriacao" />

@* FAB circular (ícone apenas) — usar IconButton *@
<IconButton Icon="WellKnownIcons.Add"
            Style="Themes.Primary"
            AdditionalClasses="fixed bottom-6 right-6 z-50 shadow-lg
                               w-14 h-14 rounded-full"
            title="Criar novo item"
            OnClick="AbrirCriacao" />

@* FAB com mini-fab secundário (expandido) *@
@code {
    private bool fabExpandido;
}

<div class="fixed bottom-6 right-6 z-50 flex flex-col items-end gap-3">
    @if (fabExpandido)
    {
        <div class="flex flex-col items-end gap-2 animate-in fade-in">
            <div class="flex items-center gap-2">
                <span class="bg-white shadow px-3 py-1 rounded-full text-sm text-dark-600">
                    Importar
                </span>
                <IconButton Icon="WellKnownIcons.Upload" Style="Themes.Secondary"
                           AdditionalClasses="w-10 h-10 rounded-full shadow"
                           OnClick="Importar" />
            </div>
            <div class="flex items-center gap-2">
                <span class="bg-white shadow px-3 py-1 rounded-full text-sm text-dark-600">
                    Criar
                </span>
                <IconButton Icon="WellKnownIcons.Add" Style="Themes.Secondary"
                           AdditionalClasses="w-10 h-10 rounded-full shadow"
                           OnClick="AbrirCriacao" />
            </div>
        </div>
    }
    <IconButton Icon="@(fabExpandido ? WellKnownIcons.Close : WellKnownIcons.Add)"
               Style="Themes.Primary"
               AdditionalClasses="w-14 h-14 rounded-full shadow-lg"
               OnClick="() => fabExpandido = !fabExpandido" />
</div>

@* Compensar FAB no conteúdo scrollável *@
<div class="pb-24">
    @* conteúdo da lista *@
</div>
```

## Limites

- `z-50` pode não ser suficiente se houver modais ou overlays com `z` maior — ajustar para `z-40` ou menor conforme hierarquia;
- Bottom tab bar (mobile) e FAB podem colidir — usar `bottom-20` quando a tab bar estiver visível.
