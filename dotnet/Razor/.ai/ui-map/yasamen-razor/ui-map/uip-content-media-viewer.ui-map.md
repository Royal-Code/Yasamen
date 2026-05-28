# UIP-CONTENT-MEDIA_VIEWER - Media Viewer

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de media viewer. Imagens, vídeos e áudio são renderizados com HTML nativo (`<img>`, `<video>`, `<audio>`). Controles como lightbox ou zoom requerem JS interop ou biblioteca externa.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Box
- `cobertura`: container do viewer com borda, dimensões e overflow; `overflow-hidden` para conter a mídia;
- `nota`: 5;
- `justificativa`: container visual da área de mídia.

2. Bar
- `cobertura`: toolbar de controles do viewer (download, fullscreen, zoom, navegação);
- `nota`: 5;
- `justificativa`: barra de controles abaixo/acima do viewer.

3. IconButton / Button
- `cobertura`: controles de download, fullscreen (via JS), fechar, navegar;
- `nota`: 7;
- `justificativa`: ações de controle do viewer.

**Descartados**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: HTML nativo + JS interop para controles avançados
- `o que precisa ser feito`:
  - Imagem: `<img>` com `object-fit` CSS; clique para fullscreen via JS `requestFullscreen()`;
  - Vídeo: `<video controls>` HTML nativo — controles nativos do browser;
  - Áudio: `<audio controls>` HTML nativo;
  - Lightbox/galeria: biblioteca externa (Swiper, lightGallery via JS interop).

## Como usar

### Image viewer com ação de fullscreen

```razor
@inject IJSRuntime JS

<Box AdditionalClasses="overflow-hidden rounded-md border border-light-200">
    <img @ref="imgRef" src="@imagemUrl" alt="@descricao"
         class="w-full object-contain max-h-96 cursor-pointer"
         @onclick="AbrirFullscreen" />
</Box>
<Bar AdditionalClasses="mt-2">
    <EndContent>
        <IconButton Icon="WellKnownIcons.Expand" Style="Themes.Default"
                    OnClick="AbrirFullscreen" />
        <IconButton Icon="WellKnownIcons.Download" Style="Themes.Default">
            @* link de download *@
        </IconButton>
    </EndContent>
</Bar>

@code {
    private ElementReference imgRef;
    private async Task AbrirFullscreen()
        => await JS.InvokeVoidAsync("element.requestFullscreen", imgRef);
}
```

### Video player nativo

```razor
<Box AdditionalClasses="overflow-hidden rounded-md">
    <video class="w-full" controls preload="metadata" poster="@thumbnailUrl">
        <source src="@videoUrl" type="video/mp4" />
        Seu navegador não suporta reprodução de vídeo.
    </video>
</Box>
```

### Preview de imagem com estado de loading

```razor
@if (carregando)
{
    <Box AdditionalClasses="h-48 animate-pulse bg-light-100 rounded-md"></Box>
}
else if (erroMidia)
{
    <Feedback Style="Themes.Warning" Text="Não foi possível carregar a imagem." />
}
else
{
    <img src="@imagemUrl" alt="@descricao"
         class="w-full rounded-md object-cover max-h-80"
         @onerror="() => erroMidia = true"
         @onload="() => carregando = false" />
}
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem componente de media viewer nativo; lightbox, zoom e galeria requerem biblioteca externa ou JS interop; controles de imagem são HTML/CSS manual; vídeo e áudio usam controles nativos do browser;
- `recomendação`: `usar apenas como apoio`
- `justificativa geral`:
  - HTML nativo (`<img>`, `<video>`, `<audio>`) cobre reprodução básica; `Box` e `Bar` compõem o container e toolbar;
  - Para viewer avançado (lightbox, carousel, zoom): biblioteca externa necessária;
  - Nota 2 reflete que apenas primitivos de container e controles estão disponíveis na lib.
