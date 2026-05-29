# UIP-CONTENT-MEDIA_COLLECTION - Blueprint resumido

## Pattern

UIP-CONTENT-MEDIA_COLLECTION — Media Collection — ver `uip-content-media-collection.ui-map.md`

## Gap coberto

A lib não tem galeria ou coleção de mídias. O gap é orientar: lista de anexos com `Box + Bar + IconButton`, galeria de imagens em grid CSS com hover de ações, e empty state com `Feedback`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: lista de anexos via `Stack + Box + Bar + IconButton(download/remover)`; galeria de imagens via `grid CSS + <img object-cover>` com overlay de ações no hover.

## Componentes usados

- `Box` — papel: principal (container da coleção e por item) — ver `box.sample.md`
- `Bar` — papel: composição (header da coleção e por item) — ver `bar.sample.md`
- `Stack` — papel: composição (lista de itens) — ver `bar.sample.md`
- `Badge` — papel: composição (contador de itens) — ver `badge.sample.md`
- `IconButton / Button` — papel: composição (ações por item e global) — ver `button.sample.md`
- `Feedback` — papel: composição (empty state) — ver `feedback.sample.md`

## Recursos visuais

- `grid grid-cols-3 sm:grid-cols-4 gap-2` — grade de thumbnails responsiva
- `w-full h-24 object-cover` — thumbnail com proporção fixa
- `group-hover:bg-black/20 group-hover:opacity-100` — overlay de ações no hover

## Receita

Lista de anexos com `Box + Bar`; galeria de imagens com grid CSS + overlay hover; empty state com `Feedback`.

```razor
@* Lista de anexos *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <Bar AdditionalClasses="mb-3">
        <StartContent>
            <h3 class="text-sm font-semibold text-dark-600">Anexos</h3>
            <Badge Style="Themes.Light" Text="@($"{anexos.Count}")"
                   AdditionalClasses="ml-2" />
        </StartContent>
        <EndContent>
            <Button Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                    Label="Adicionar" Icon="WellKnownIcons.Add"
                    OnClick="AdicionarAnexo" />
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
                            <Icon Kind="WellKnownIcons.File"
                                  class="text-dark-400 flex-shrink-0" />
                            <div class="ml-2">
                                <span class="text-sm text-dark-600">@a.Nome</span>
                                <span class="text-xs text-dark-400 ml-1">
                                    @($"{a.TamanhoKb}KB")
                                </span>
                            </div>
                        </StartContent>
                        <EndContent>
                            <IconButton Icon="WellKnownIcons.Download"
                                        Style="Themes.Default" Size="Sizes.Small"
                                        OnClick="() => Download(a)" />
                            <IconButton Icon="WellKnownIcons.Trash"
                                        Style="Themes.Danger" Size="Sizes.Small"
                                        Outline=true OnClick="() => Remover(a)" />
                        </EndContent>
                    </Bar>
                </Box>
            }
        </Stack>
    }
</Box>

@* Galeria de imagens em grade *@
<div class="mb-4">
    <Bar AdditionalClasses="mb-3">
        <StartContent>
            <h3 class="text-sm font-semibold text-dark-600">Fotos (@fotos.Count)</h3>
        </StartContent>
    </Bar>
    @if (!fotos.Any())
    {
        <Feedback Style="Themes.Light" Text="Nenhuma foto vinculada." />
    }
    else
    {
        <div class="grid grid-cols-3 sm:grid-cols-4 gap-2">
            @foreach (var foto in fotos)
            {
                <div class="relative group cursor-pointer rounded-md overflow-hidden"
                     @onclick="() => AbrirFoto(foto)">
                    <img src="@foto.ThumbnailUrl" alt="@foto.Descricao"
                         class="w-full h-24 object-cover" />
                    <div class="absolute inset-0 bg-black/0 group-hover:bg-black/20
                                opacity-0 group-hover:opacity-100 transition-all
                                flex items-end p-1">
                        <IconButton Icon="WellKnownIcons.Trash" Style="Themes.Danger"
                                    Size="Sizes.Small"
                                    @onclick:stopPropagation
                                    OnClick="() => RemoverFoto(foto)" />
                    </div>
                </div>
            }
        </div>
    }
</div>
```

## Limites

- Lightbox ao clicar na imagem requer JS interop ou biblioteca externa (PhotoSwipe, lightGallery);
- Drag/drop para reordenar fotos requer JS interop — não coberto aqui;
- Preview inline de PDF ou vídeo requer abordagem diferente (`<video>` ou biblioteca externa).
