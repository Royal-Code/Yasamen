# UIP-INTERACTION-CROSS_WINDOW_DND - Cross Window Drag and Drop

**GAP — sem cobertura viável**

Arrastar e soltar entre janelas, apps ou arquivos não é suportado pela biblioteca e está além do escopo de componentes Blazor Web.

## Componentes

**Principais**: nenhum.
**Composição**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: nova implementação externa
- `o que precisa ser feito`: API de arquivo do browser (`window.ondrop` + `DataTransfer.files`) para drop de arquivos do SO; comunicação cross-window via `postMessage` JS.

## Como usar

```razor
@* Drop de arquivo do sistema (único caso web viável) *@
<div @ondragover:preventDefault="true"
     @ondrop="OnFileDrop"
     class="p-6 border-2 border-dashed border-light-200 text-center text-dark-600">
    Arraste arquivos aqui
</div>
@code {
    private async Task OnFileDrop(DragEventArgs e)
    {
        // DataTransfer.files via JS interop
    }
}
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: fora do escopo da lib e do modelo web de componentes Razor;
- `recomendação`: `evitar`
- `justificativa geral`: cross-window DnD requer APIs nativas do browser ou SO; não é coberto pela biblioteca.
