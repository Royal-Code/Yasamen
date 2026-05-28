# UIP-DATA-LIST_ITEM - List Item

## Componentes

**Principais**:

1. Bar
- `cobertura`: layout horizontal com ícone/avatar/título no `StartContent` e ações/metadados no `EndContent`; hover via `AdditionalClasses="hover:bg-light-50"`; clique em todo o item via `@onclick` no wrapper;
- `limitações`: sem estado de seleção nativo; sem variante de lista nativa (sem elemento HTML `<li>` semântico);
- `nota`: 7;
- `justificativa`: container de item de lista — linha horizontal com zonas Start/End mapeia exatamente ao list item.

**Composição**:

1. Box
- `cobertura`: card de item com borda e padding; clique navegacional; `cursor-pointer` para item clicável;
- `nota`: 8;
- `justificativa`: item de lista em formato card com borda — mais visual que linha pura.

2. Badge
- `cobertura`: metadado de status por item; contagem de notificações não lidas; tag de categoria;
- `nota`: 9;
- `justificativa`: decoradores de estado e categorização por item.

3. DropIconButton
- `cobertura`: ações contextuais por item (editar, excluir, etc.) no EndContent;
- `nota`: 8;
- `justificativa`: overflow de ações por item sem ocupar espaço permanente.

4. Stack
- `cobertura`: sequência vertical de itens com espaçamento; `Gap.Small` para lista densa;
- `nota`: 9;
- `justificativa`: container da lista completa de itens.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `item de navegação (link)`: usar `<a href>` ou `NavigateTo` como wrapper;
  - `item selecionável`: estado `HashSet<id>` + `FieldCheckbox` no StartContent ou realce via `bg-primary-50`;
  - `skeleton de item`: div com `animate-pulse` por coluna do item.

- `tipo de adaptação`: composição direta
- `o que precisa ser feito`:
  - Para lista de cards: `Stack` com `Box` por item — `Bar` dentro do Box com conteúdo;
  - Para lista densa (sem borda): `Stack` com `Bar` por item + `hover:bg-light-50`;
  - `Badge` para status; `DropIconButton` para ações contextuais.

## Como usar

### Lista densa (sem borda, hover)

```razor
<Stack Gap="Gaps.None">
    @foreach (var item in itens)
    {
        <div class="border-b border-light-100 last:border-0">
            <Bar AdditionalClasses="px-4 py-3 hover:bg-light-50 cursor-pointer"
                 @onclick="() => Abrir(item.Id)">
                <StartContent>
                    <div class="flex items-center gap-3">
                        <div class="w-8 h-8 rounded-full bg-primary-100 flex items-center justify-center">
                            <span class="text-xs font-bold text-primary-600">
                                @item.Nome.Substring(0, 1).ToUpper()
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
```

### Lista de cards

```razor
<Stack Gap="Gaps.Small">
    @foreach (var item in itens)
    {
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-3 cursor-pointer hover:shadow-sm transition-shadow"
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
                    <span class="text-xs text-dark-300">@item.Data.ToString("dd/MM")</span>
                </EndContent>
            </Bar>
        </Box>
    }
</Stack>
```

## Decisão de uso

- `nota geral`: 5;
- `limitações`: sem componente de list item dedicado; `Bar` dentro de `Box` cobre bem o padrão mas sem semântica HTML `<li>`; sem skeleton nativo; seleção múltipla requer composição manual;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Stack` + `Box`/`Bar` + `Badge` + `DropIconButton` cobrem todas as variantes de list item;
  - Composição direta e eficiente — padrão recorrente no uso da lib;
  - Nota 5 reflete boa cobertura funcional sem abstração de list item dedicada.
