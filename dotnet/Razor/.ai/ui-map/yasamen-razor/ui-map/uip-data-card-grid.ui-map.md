# UIP-DATA-CARD_GRID - Card Grid

## Componentes

**Principais**:

1. Container+Slot
- `cobertura`: grade responsiva de 2-4 colunas; breakpoints automáticos; cada `Slot` contém um card; `Columns` parametrizado;
- `nota`: 9;
- `justificativa`: grade nativa de alta qualidade para card grid — exatamente o padrão de colunas responsivas.

**Composição**:

1. Box
- `cobertura`: card individual com borda, padding e shadow opcional; `cursor-pointer` para card clicável; hover via `hover:shadow-md`; overflow hidden para imagem;
- `nota`: 9;
- `justificativa`: card individual da grade — container visual completo.

2. Bar
- `cobertura`: footer do card com ação primária + contextual menu;
- `nota`: 8;
- `justificativa`: toolbar do card com ações.

3. Badge
- `cobertura`: status, categoria, etiqueta por card;
- `nota`: 9;
- `justificativa`: decoradores de estado por card.

4. Pagination
- `cobertura`: paginação da grade;
- `nota`: 9;
- `justificativa`: navegação entre páginas da coleção.

5. Feedback / Stack (empty state + skeleton)
- `cobertura`: estado vazio da grade; skeleton de cards com `animate-pulse`;
- `nota`: 7;
- `justificativa`: estados de ausência de dados e loading.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `imagem dominante no card`: `<img>` HTML com `object-cover` no topo do Box;
  - `skeleton de cards`: `Box` com `animate-pulse` em `Container+Slot`;
  - `seleção de cards`: `FieldCheckbox` flutuante no card + estado `HashSet<id>`.

- `tipo de adaptação`: composição direta
- `o que precisa ser feito`:
  - `Container+Slot` como grade; `Box` como card; `Bar` no footer do card para ações;
  - `Badge` para status; `Pagination` abaixo da grade; `Feedback` para empty state.

## Como usar

### Grade de cards com imagem

```razor
@code {
    private int pagina = 1;
    private int totalPaginas = 8;
}

<Bar AdditionalClasses="mb-4">
    <StartContent>
        <FieldText @bind-Value="busca" Placeholder="Buscar..." @oninput="Buscar" />
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
                        <p class="text-xs text-dark-400">@item.Descricao</p>
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

## Decisão de uso

- `nota geral`: 7;
- `limitações`: sem componente de card dedicado — `Box` genérico como card; imagem no card requer HTML `<img>` manual; skeleton de cards manual; seleção múltipla manual;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Container+Slot` provê grade responsiva de alta qualidade nativa;
  - `Box` + `Bar` + `Badge` + `Pagination` completam o card grid com todos os elementos necessários;
  - Nota 7 reflete cobertura nativa sólida — `Container+Slot` é o ponto forte desta combinação.
