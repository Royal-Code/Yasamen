# UIP-DATA-LIST_ITEM - Blueprint resumido

## Pattern

UIP-DATA-LIST_ITEM — List Item — ver `uip-data-list-item.ui-map.md`

## Gap coberto

A lib não tem list item dedicado. O gap é orientar duas variantes: lista densa com `Bar` por item (sem borda) e lista de cards com `Box + Bar`, ambas com `Badge` de status e `DropIconButton` de ações contextuais.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Stack + Bar(hover:bg-light-50)` para lista densa; `Stack + Box + Bar` para lista de cards; `Badge` para status; `DropIconButton` para ações contextuais no `EndContent`.

## Componentes usados

- `Stack` — papel: principal (container da lista) — ver `bar.sample.md`
- `Bar` — papel: principal (linha do item) — ver `bar.sample.md`
- `Box` — papel: composição (card do item) — ver `box.sample.md`
- `Badge` — papel: composição (status do item) — ver `badge.sample.md`
- `DropIconButton` — papel: composição (ações contextuais) — ver `button.sample.md`

## Recursos visuais

- `hover:bg-light-50 cursor-pointer` — item interativo na lista densa
- `border-b border-light-100 last:border-0` — separador entre itens
- `hover:shadow-sm transition-shadow` — elevação sutil no card ao hover
- `w-8 h-8 rounded-full bg-primary-100` — avatar com inicial

## Receita

Lista densa com `Bar` + separador; lista de cards com `Box + Bar`; `Badge` para status; `DropIconButton` para ações.

```razor
@* Lista densa (sem borda, com hover) *@
<Stack Gap="Gaps.None">
    @foreach (var item in itens)
    {
        <div class="border-b border-light-100 last:border-0">
            <Bar AdditionalClasses="px-4 py-3 hover:bg-light-50 cursor-pointer"
                 @onclick="() => Abrir(item.Id)">
                <StartContent>
                    <div class="flex items-center gap-3">
                        <div class="w-8 h-8 rounded-full bg-primary-100 flex items-center
                                    justify-center flex-shrink-0">
                            <span class="text-xs font-bold text-primary-600">
                                @item.Nome[0].ToString().ToUpper()
                            </span>
                        </div>
                        <div>
                            <p class="text-sm font-medium text-dark-600">@item.Nome</p>
                            <p class="text-xs text-dark-400">@item.Email</p>
                        </div>
                    </div>
                </StartContent>
                <EndContent>
                    <Badge Style="@(item.Ativo ? Themes.Success : Themes.Light)"
                           Text="@(item.Ativo ? "Ativo" : "Inativo")" />
                    <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                   Style="Themes.Default" Size="Sizes.Small">
                        <DropItem Label="Editar" OnClick="() => Editar(item.Id)" />
                        <DropItem Label="Excluir" Style="Themes.Danger"
                                  OnClick="() => Excluir(item.Id)" />
                    </DropIconButton>
                </EndContent>
            </Bar>
        </div>
    }
</Stack>

@* Lista de cards *@
<Stack Gap="Gaps.Small">
    @foreach (var item in itens)
    {
        <Box Border="BorderBuilder.Box"
             AdditionalClasses="p-3 cursor-pointer hover:shadow-sm transition-shadow"
             @onclick="() => Abrir(item.Id)">
            <Bar>
                <StartContent>
                    <div>
                        <p class="font-semibold text-sm text-dark-600">@item.Titulo</p>
                        <p class="text-xs text-dark-400 mt-0.5">@item.Descricao</p>
                    </div>
                </StartContent>
                <EndContent>
                    <Badge Style="@item.StatusTema" Text="@item.Status" />
                    <span class="text-xs text-dark-300">
                        @item.Data.ToString("dd/MM")
                    </span>
                </EndContent>
            </Bar>
        </Box>
    }
</Stack>
```

## Limites

- Sem semântica HTML `<ul>/<li>` — envolver com `<ul>` e `<li>` se acessibilidade for prioritária;
- Seleção múltipla requer estado `HashSet<int>` + `InputCheckbox` manual no `StartContent`;
- Skeleton por item: `Box + animate-pulse` com divs de altura fixa por coluna do item.
