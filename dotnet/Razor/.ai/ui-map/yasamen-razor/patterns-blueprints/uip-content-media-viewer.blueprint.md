# UIP-CONTENT-MEDIA_VIEWER - Blueprint resumido

## Pattern

UIP-CONTENT-MEDIA_VIEWER — Media Viewer — ver `uip-content-media-viewer.ui-map.md`

## Gap coberto

A lib não tem media viewer. O gap é orientar: `<img>` em `Box` com skeleton de loading e estado de erro, `<video controls>` para vídeo nativo, e toolbar de controles com `Bar + IconButton`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: HTML nativo `<img>/<video>/<audio>` em `Box(overflow-hidden)` para reprodução; `Bar + IconButton` para toolbar de controles (download, fullscreen); `animate-pulse` para loading e `Feedback(Warning)` para erro.

## Componentes usados

- `Box` — papel: principal (container do viewer) — ver `box.sample.md`
- `Bar` — papel: composição (toolbar de controles) — ver `bar.sample.md`
- `IconButton` — papel: composição (download, fullscreen) — ver `button.sample.md`
- `Feedback` — papel: composição (erro de mídia) — ver `feedback.sample.md`

## Recursos visuais

- `overflow-hidden rounded-md` — confinamento visual da mídia
- `w-full object-contain max-h-96` — imagem responsiva com altura máxima
- `animate-pulse bg-light-100 h-48 rounded-md` — placeholder de loading

## Receita

HTML nativo para mídia; `Box` como container; skeleton/erro como estados; `Bar` para toolbar.

```razor
@inject IJSRuntime JS

@code {
    private bool carregando = true;
    private bool erroMidia;
    private ElementReference imgRef;

    private async Task AbrirFullscreen()
        => await JS.InvokeVoidAsync("document.querySelector('img').requestFullscreen");
}

@* Image viewer com loading, erro e toolbar *@
@if (carregando && !erroMidia)
{
    <Box AdditionalClasses="h-48 animate-pulse bg-light-100 rounded-md"></Box>
}
else if (erroMidia)
{
    <Feedback Style="Themes.Warning" Text="Não foi possível carregar a imagem." />
}

<img @ref="imgRef"
     src="@imagemUrl"
     alt="@descricao"
     class="w-full rounded-md object-contain max-h-96 @(carregando ? "hidden" : "")"
     @onload="() => carregando = false"
     @onerror="() => { erroMidia = true; carregando = false; }" />

@if (!carregando && !erroMidia)
{
    <Bar AdditionalClasses="mt-2">
        <StartContent>
            <p class="text-xs text-dark-400">@descricao</p>
        </StartContent>
        <EndContent>
            <IconButton Icon="WellKnownIcons.Expand" Style="Themes.Default"
                        OnClick="AbrirFullscreen" />
            <a href="@imagemUrl" download class="inline-flex">
                <IconButton Icon="WellKnownIcons.Download" Style="Themes.Default" />
            </a>
        </EndContent>
    </Bar>
}

@* Vídeo nativo *@
<Box AdditionalClasses="overflow-hidden rounded-md">
    <video class="w-full" controls preload="metadata" poster="@thumbnailUrl">
        <source src="@videoUrl" type="video/mp4" />
        Seu navegador não suporta reprodução de vídeo.
    </video>
</Box>
```

## Limites

- Sem lightbox, zoom ou galeria carousel — requer biblioteca externa (Swiper, lightGallery via JS interop);
- Controles de `<video>` são nativos do browser — aparência diverge do design system;
- `requestFullscreen` requer JS interop — fallback natural do browser pode ser suficiente;
- Para preview de PDF: `<iframe src="@pdfUrl">` ou biblioteca externa (PSPDFKit, PDF.js).
