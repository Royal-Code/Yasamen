# UIP-INTERACTION-DRAG_DROP - Drag and Drop

**GAP — sem cobertura viável**

A biblioteca não provê suporte a arrastar e soltar. Requer HTML5 Drag and Drop API diretamente ou biblioteca JS externa.

## Componentes

**Principais**: nenhum.

**Composição**: nenhum com papel relevante em DnD.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `drag source`: sem componente — usar `draggable="true"` + `@ondragstart` HTML nativo;
  - `drop target`: sem componente — usar `@ondragover` + `@ondrop` HTML nativo;
  - `feedback visual de drag`: sem suporte nativo — implementar com classe CSS condicional e `DragEventArgs`;
  - `sortable list`: requer lib JS (SortableJS via interop ou Blazor.Sortable).

- `tipo de adaptação`: nova implementação + estilos
- `o que precisa ser feito`:
  - HTML5 DnD API com eventos Blazor (`@ondragstart`, `@ondragover`, `@ondrop`);
  - Para sortable list: usar SortableJS via JS interop ou biblioteca Blazor dedicada.

## Como usar

### Drag and drop básico com HTML5 API

```razor
@code {
    private string draggedItem = "";
    private bool isDragOver = false;
    
    private void OnDragStart(DragEventArgs e, string item)
        => draggedItem = item;
    
    private void OnDrop(DragEventArgs e)
    {
        // processar drop de draggedItem
        isDragOver = false;
    }
}

<div draggable="true"
     @ondragstart="e => OnDragStart(e, item.Id.ToString())"
     class="p-3 border border-light-200 rounded-md cursor-grab text-dark-600">
    @item.Nome
</div>

<div @ondragover:preventDefault="true"
     @ondrop="OnDrop"
     class="p-4 border-2 border-dashed @(isDragOver ? "border-primary-400 bg-primary-50" : "border-light-200")">
    Solte aqui
</div>
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: nenhum componente DnD nativo; implementação com HTML5 API funciona para casos simples mas tem limitações cross-browser em mobile; para sortable list, requer lib externa;
- `recomendação`: `evitar`
- `justificativa geral`:
  - A biblioteca não suporta drag and drop; implementação manual é necessária para qualquer cenário de arrastar e soltar.
