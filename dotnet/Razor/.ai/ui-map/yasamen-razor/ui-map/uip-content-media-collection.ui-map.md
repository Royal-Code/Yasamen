# UIP-CONTENT-MEDIA_COLLECTION - Media Collection

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de galeria ou coleção de mídias. Requer composição com `Container+Slot` (grade) ou `Stack`/`Box` (lista) + HTML nativo para thumbnails.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Container+Slot
- `cobertura`: grade de thumbnails 2-4 colunas; cada slot contém um item de mídia;
- `nota`: 7;
- `justificativa`: grade responsiva de itens de mídia.

2. Box
- `cobertura`: card de item de mídia com thumbnail, nome, tamanho e ações;
- `nota`: 7;
- `justificativa`: container de item individual da coleção.

3. Bar
- `cobertura`: header da coleção com título + ação "Adicionar" + contagem; cabeçalho de item com nome + ações;
- `nota`: 7;
- `justificativa`: toolbar da coleção e cabeçalho por item.

4. IconButton / Button
- `cobertura`: ações por item (download, remover, abrir) e ação global (adicionar);
- `nota`: 8;
- `justificativa`: controles de ação da coleção e por item.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `preview de imagem em thumbnail`: `<img>` HTML com `object-cover` no card;
  - `lightbox ao clicar`: JS interop ou biblioteca externa (lightGallery, PhotoSwipe);
  - `estado empty da coleção`: `Feedback Light` com CTA "Adicionar anexo".

- `tipo de adaptação`: composição + HTML nativo para thumbnails
- `o que precisa ser feito`:
  - Header com `Bar` (título + botão adicionar + contagem); itens em grade `Container+Slot` ou lista;
  - `Box` por item com `<img>` ou ícone de tipo de arquivo + nome + ações;
  - `Empty state` com `Feedback` quando coleção está vazia.

## Como usar

### Lista de anexos (documentos)

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <Bar AdditionalClasses="mb-3">
        <StartContent>
            <h3 class="text-sm font-semibold text-dark-600">Anexos</h3>
            <Badge Style="Themes.Light" Text="@($"{anexos.Count}")" AdditionalClasses="ml-2" />
        </StartContent>
        <EndContent>
            <Button Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                    Label="Adicionar" Icon="WellKnownIcons.Add" OnClick="AdicionarAnexo" />
        </EndContent>
    </Bar>
    
    @if (!anexos.Any())
    {
        <Feedback Style="Themes.Light" Text="Nenhum anexo vinculado." />
    }
    else
    {
        <Stack Gap="Gaps.Small">
            @foreach (var a in anexos)
            {
                <Box Border="BorderBuilder.Box" AdditionalClasses="p-2">
                    <Bar>
                        <StartContent>
                            <div class="flex items-center gap-2">
                                @WellKnownIcons.File("text-dark-400")
                                <div>
                                    <span class="text-sm text-dark-600">@a.Nome</span>
                                    <span class="text-xs text-dark-400 ml-2">@($"{a.TamanhoKb}KB")</span>
                                </div>
                            </div>
                        </StartContent>
                        <EndContent>
                            <IconButton Icon="WellKnownIcons.Download" Style="Themes.Default"
                                        Size="Sizes.Small" OnClick="() => Download(a)" />
                            <IconButton Icon="WellKnownIcons.Trash" Style="Themes.Danger"
                                        Size="Sizes.Small" Outline=true
                                        OnClick="() => Remover(a)" />
                        </EndContent>
                    </Bar>
                </Box>
            }
        </Stack>
    }
</Box>
```

### Galeria de imagens em grade

```razor
<div class="mb-4">
    <Bar AdditionalClasses="mb-3">
        <StartContent>
            <h3 class="text-sm font-semibold text-dark-600">Fotos (@fotos.Count)</h3>
        </StartContent>
    </Bar>
    <div class="grid grid-cols-3 sm:grid-cols-4 gap-2">
        @foreach (var foto in fotos)
        {
            <div class="relative group cursor-pointer rounded-md overflow-hidden"
                 @onclick="() => AbrirFoto(foto)">
                <img src="@foto.ThumbnailUrl" alt="@foto.Descricao"
                     class="w-full h-24 object-cover" />
                <div class="absolute inset-0 bg-black/0 group-hover:bg-black/20 
                            flex items-end p-1 opacity-0 group-hover:opacity-100 
                            transition-all">
                    <IconButton Icon="WellKnownIcons.Trash" Style="Themes.Danger"
                                Size="Sizes.Small"
                                OnClick:stopPropagation
                                OnClick="() => RemoverFoto(foto)" />
                </div>
            </div>
        }
    </div>
</div>
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de galeria/coleção nativo; thumbnails são HTML `<img>` manual; lightbox requer biblioteca externa; sem drag/drop reorder nativo; toda estrutura é composição manual;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Container+Slot` + `Box` + `Bar` + `IconButton` cobrem coleção de anexos e galeria funcional;
  - Para lightbox e preview avançado: biblioteca externa;
  - Nota 3 reflete composição completamente manual sem abstração de coleção de mídias.
