# UIP-INPUT-REPEATING_GROUP - Blueprint resumido

## Pattern

UIP-INPUT-REPEATING_GROUP — Repeating Group — ver `uip-input-repeating-group.ui-map.md`

## Gap coberto

A lib não tem componente de repeating group. O gap é orientar a composição com `Stack + Box + Bar + Button` para lista dinâmica de grupos de campos com adicionar/remover/reordenar.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `List<T>` em C# como fonte de dados; `@for` com `Box + Bar` por item; `Button(Add)` fora do loop; `IconButton(Trash)` por item; botões ↑↓ para reordenação.

## Componentes usados

- `Stack` — papel: principal (container da lista de itens) — ver `stack.sample.md`
- `Box` — papel: composição (card de cada item) — ver `box.sample.md`
- `Bar` — papel: composição (cabeçalho do item com ação remover) — ver `bar.sample.md`
- `Button / IconButton` — papel: composição (adicionar/remover/reordenar) — ver `button.sample.md`
- `ButtonGroup` — papel: composição (ações de reordenação agrupadas) — ver `button.sample.md`

## Recursos visuais

- `@for (int i = 0; i < lista.Count; i++)` — capturar `idx = i` para closures corretas
- `Disabled="@(lista.Count >= maxItens)"` — limite máximo no botão Adicionar
- `Disabled="@(lista.Count <= 1)"` — mínimo de 1 no botão Remover

## Receita

`List<T>` + `@for` com `Box/Bar` por item; Add fora do loop; Trash no `EndContent` do `Bar`.

```razor
@code {
    private List<ContatoDto> contatos = [new()];
    private const int MaxContatos = 5;

    private void AdicionarContato() => contatos.Add(new());
    private void RemoverContato(int idx) => contatos.RemoveAt(idx);

    private void MoverAcima(int idx)
    {
        if (idx <= 0) return;
        var t = contatos[idx]; contatos.RemoveAt(idx); contatos.Insert(idx - 1, t);
    }

    private void MoverAbaixo(int idx)
    {
        if (idx >= contatos.Count - 1) return;
        var t = contatos[idx]; contatos.RemoveAt(idx); contatos.Insert(idx + 1, t);
    }
}

<div class="mb-4">
    <label class="text-sm font-medium text-dark-600 block mb-2">Contatos</label>
    <Stack Gap="Gaps.Medium">
        @for (int i = 0; i < contatos.Count; i++)
        {
            var idx = i;
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <Bar AdditionalClasses="mb-3">
                    <StartContent>
                        <span class="text-sm font-semibold text-dark-600">
                            Contato @(idx + 1)
                        </span>
                    </StartContent>
                    <EndContent>
                        <ButtonGroup>
                            <IconButton Icon="WellKnownIcons.ChevronUp"
                                        Style="Themes.Default" Size="Sizes.Small"
                                        Disabled="@(idx == 0)"
                                        OnClick="() => MoverAcima(idx)" />
                            <IconButton Icon="WellKnownIcons.ChevronDown"
                                        Style="Themes.Default" Size="Sizes.Small"
                                        Disabled="@(idx == contatos.Count - 1)"
                                        OnClick="() => MoverAbaixo(idx)" />
                            <IconButton Icon="WellKnownIcons.Trash"
                                        Style="Themes.Danger" Size="Sizes.Small"
                                        Outline=true
                                        Disabled="@(contatos.Count <= 1)"
                                        OnClick="() => RemoverContato(idx)" />
                        </ButtonGroup>
                    </EndContent>
                </Bar>
                <div class="grid grid-cols-1 sm:grid-cols-2 gap-3">
                    <TextField @bind-Value="contatos[idx].Nome" Label="Nome" required />
                    <TextField @bind-Value="contatos[idx].Telefone" Label="Telefone" />
                    <TextField @bind-Value="contatos[idx].Email" Label="E-mail"
                               AdditionalClasses="sm:col-span-2" />
                </div>
            </Box>
        }
    </Stack>
    <Button Style="Themes.Secondary" Outline=true
            Label="Adicionar contato"
            Icon="WellKnownIcons.Add"
            AdditionalClasses="mt-3"
            Disabled="@(contatos.Count >= MaxContatos)"
            OnClick="AdicionarContato" />
</div>
```

## Limites

- Validação por item em `EditForm`: `DataAnnotationsValidator` valida o model raiz — validação por item requer `EditForm` aninhada ou validação manual com `IValidatableObject`;
- Sem drag/drop para reordenação — botões ↑↓ como alternativa funcional mas inferior UX;
- Closures no `@for` requerem `var idx = i` — nunca usar `i` diretamente nos callbacks.
