# UIP-INPUT-REPEATING_GROUP - Repeating Group

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de repeating group. Requer composição com `Stack` + `Box` + `Button` (adicionar/remover) + `@foreach` em lista C#.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Stack
- `cobertura`: sequência vertical dos itens repetíveis com espaçamento coerente;
- `nota`: 8;
- `justificativa`: container natural da lista de grupos.

2. Box
- `cobertura`: card de cada item repetível com borda visual; separa visualmente cada instância do grupo;
- `nota`: 8;
- `justificativa`: delimitação visual de cada item do grupo repetível.

3. Button / IconButton
- `cobertura`: ação "Adicionar item" e "Remover item" por índice; `Loading=true` durante operação;
- `nota`: 9;
- `justificativa`: ações de adição e remoção de itens da lista.

4. Bar
- `cobertura`: header do item repetível com número/título do item + ação de remover no EndContent;
- `nota`: 8;
- `justificativa`: cabeçalho de cada item com contexto + ação de remover.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `validação por item em EditForm`: usar `DataAnnotationsValidator` por item em `EditForm` aninhada ou validação manual;
  - `reorder de itens`: sem drag/drop nativo — usar botões ↑↓ para reordenação;
  - `limite mínimo/máximo de itens`: lógica de estado C# com `Disabled` no botão Adicionar/Remover.

- `tipo de adaptação`: composição + lógica C# de lista
- `o que precisa ser feito`:
  - Lista C# (ex: `List<ItemDto>`) com `Add`, `Remove`, `Insert` pelo app;
  - `@for` loop renderizando `Box` por item com `Bar` de header + campos + botão remover;
  - Botão "Adicionar item" fora do loop + controle de limite.

## Como usar

### Grupo de contatos repetível

```razor
@code {
    private List<ContatoDto> contatos = [new()];

    private void AdicionarContato() => contatos.Add(new());
    private void RemoverContato(int idx) => contatos.RemoveAt(idx);
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
                        <span class="text-sm font-semibold text-dark-600">Contato @(idx + 1)</span>
                    </StartContent>
                    <EndContent>
                        @if (contatos.Count > 1)
                        {
                            <IconButton Icon="WellKnownIcons.Trash" Style="Themes.Danger"
                                        Size="Sizes.Small" Outline=true
                                        OnClick="() => RemoverContato(idx)" />
                        }
                    </EndContent>
                </Bar>
                <div class="grid grid-cols-1 sm:grid-cols-2 gap-3">
                    <TextField @bind-Value="contatos[idx].Nome" Label="Nome" Required=true />
                    <TextField @bind-Value="contatos[idx].Telefone" Label="Telefone" />
                    <TextField @bind-Value="contatos[idx].Email" Label="E-mail"
                               AdditionalClasses="sm:col-span-2" />
                </div>
            </Box>
        }
    </Stack>
    <Button Style="Themes.Secondary" Outline=true Label="Adicionar contato"
            Icon="WellKnownIcons.Add" AdditionalClasses="mt-3"
            OnClick="AdicionarContato"
            Disabled="@(contatos.Count >= 5)" />
</div>
```

### Itens com reordenação manual

```razor
<Stack Gap="Gaps.Small">
    @for (int i = 0; i < itens.Count; i++)
    {
        var idx = i;
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
            <Bar>
                <StartContent>
                    <TextField @bind-Value="itens[idx].Descricao" Label="" Placeholder="Descrição" />
                </StartContent>
                <EndContent>
                    <ButtonGroup>
                        <IconButton Icon="WellKnownIcons.ChevronUp" Style="Themes.Default"
                                    Disabled="@(idx == 0)"
                                    OnClick="() => { var t = itens[idx]; itens.RemoveAt(idx); itens.Insert(idx-1, t); }" />
                        <IconButton Icon="WellKnownIcons.ChevronDown" Style="Themes.Default"
                                    Disabled="@(idx == itens.Count-1)"
                                    OnClick="() => { var t = itens[idx]; itens.RemoveAt(idx); itens.Insert(idx+1, t); }" />
                        <IconButton Icon="WellKnownIcons.Trash" Style="Themes.Danger"
                                    OnClick="() => itens.RemoveAt(idx)" />
                    </ButtonGroup>
                </EndContent>
            </Bar>
        </Box>
    }
</Stack>
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de repeating group nativo; toda estrutura é composição manual; validação por item requer EditForm aninhada ou validação manual; sem drag/drop para reorder — apenas botões ↑↓;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Stack` + `Box` + `Bar` + `Button` formam um repeating group funcional;
  - A lógica de lista (add, remove, reorder) é do app C# — a lib contribui com os containers e ações;
  - Nota 3 reflete que apenas primitivos genéricos cobrem o pattern sem abstração específica.
