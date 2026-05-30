# UIP-DATA-CARD_GRID - Blueprint resumido

## Pattern

UIP-DATA-CARD_GRID — Card Grid — ver `uip-data-card-grid.ui-map.md`

## Gap coberto

`Container+Slot` cobre a grade nativa com alta qualidade. O gap é orientar a composição do card interno com `Box + <img> + Bar + Badge`, o skeleton de loading, o empty state, e a `Pagination`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Container(Columns=3)` com `Slot` por item; `Box(overflow-hidden)` + `<img class="object-cover">` para imagem dominante; `Bar` no footer para ações; skeleton com `animate-pulse`.

## Componentes usados

- `Container + Slot` — papel: principal (grade responsiva) — ver `container.sample.md`
- `Box` — papel: composição (card individual) — ver `box.sample.md`
- `Bar` — papel: composição (header e footer do card) — ver `bar.sample.md`
- `Badge` — papel: composição (status do item) — ver `badge.sample.md`
- `Button / DropIconButton` — papel: composição (ações do card) — ver `button.sample.md`
- `Pagination` — papel: composição (navegação de páginas) — ver `pagination.sample.md`
- `Feedback` — papel: composição (empty state) — ver `feedback.sample.md`

## Recursos visuais

- `Container(Columns=3)` — grade de 3 colunas com responsividade automática
- `overflow-hidden` no Box — conter a imagem dentro das bordas arredondadas
- `w-full h-36 object-cover` — imagem dominante com altura fixa
- `hover:shadow-md transition-shadow` — elevação do card ao hover

## Receita

`Container + Slot + Box + Bar + Pagination`; skeleton de loading; empty state.

```razor
@code {
    private int pagina = 1;
    private int totalPaginas = 8;
}

<Bar AdditionalClasses="mb-4">
    <StartContent>
        <TextField @bind-Value="busca" Placeholder="Buscar..." @oninput="Buscar" />
    </StartContent>
</Bar>

@if (carregando)
{
    <Container Columns="3">
        @for (int i = 0; i < 6; i++)
        {
            <Slot>
                <Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
                    <div class="animate-pulse bg-light-200 h-36 w-full"></div>
                    <div class="p-3 space-y-2">
                        <div class="animate-pulse bg-light-200 h-4 rounded w-3/4"></div>
                        <div class="animate-pulse bg-light-100 h-3 rounded w-1/2"></div>
                    </div>
                </Box>
            </Slot>
        }
    </Container>
}
else if (!itens.Any())
{
    <Feedback Style="Themes.Light" Text="Nenhum item encontrado." />
}
else
{
    <Container Columns="3">
        @foreach (var item in itens)
        {
            <Slot>
                <Box Border="BorderBuilder.Box"
                     AdditionalClasses="overflow-hidden cursor-pointer hover:shadow-md transition-shadow"
                     @onclick="() => Abrir(item.Id)">
                    @if (item.ImagemUrl is not null)
                    {
                        <img src="@item.ImagemUrl" alt="@item.Nome"
                             class="w-full h-36 object-cover" />
                    }
                    <div class="p-3">
                        <Bar AdditionalClasses="mb-1">
                            <StartContent>
                                <p class="font-semibold text-sm text-dark-600">@item.Nome</p>
                            </StartContent>
                            <EndContent>
                                <Badge Style="@item.StatusTema" Text="@item.Status" />
                            </EndContent>
                        </Bar>
                        <p class="text-xs text-dark-400 line-clamp-2">@item.Descricao</p>
                        <Bar AdditionalClasses="mt-3">
                            <EndContent>
                                <Button Style="Themes.Primary" Size="Sizes.Small"
                                        Label="Ver detalhes"
                                        OnClick="() => Abrir(item.Id)" />
                                <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                               Style="Themes.Default" Size="Sizes.Small">
                                    <DropItem Label="Editar" OnClick="() => Editar(item.Id)" />
                                    <DropItem Label="Excluir" Style="Themes.Danger"
                                              OnClick="() => Excluir(item.Id)" />
                                </DropIconButton>
                            </EndContent>
                        </Bar>
                    </div>
                </Box>
            </Slot>
        }
    </Container>
    <Pagination CurrentPage="@pagina" TotalPages="@totalPaginas"
                OnPageChanged="OnPage" AdditionalClasses="mt-6" />
}
```

## Limites

- `line-clamp-2` requer Tailwind v3+ com `@tailwindcss/line-clamp` ou Tailwind v4 (incluído) — verificar configuração;
- Seleção múltipla de cards requer `InputCheckbox` flutuante no card + `HashSet<int>` no componente pai;
- `Container(Columns=3)` — verificar comportamento responsivo em 1-2 colunas para mobile.
