# UIP-INTERACTION-SWIPE_ACTION - Swipe Action

**GAP — sem cobertura viável**

Gestos de swipe para revelar ações em itens de lista não são suportados pela biblioteca. Requer JavaScript ou biblioteca de gestos.

## Componentes

**Principais**: nenhum.
**Composição**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: nova implementação externa
- `o que precisa ser feito`:
  - Touch events via JS interop (`touchstart`, `touchmove`, `touchend`);
  - Ou lib de gestos como Hammer.js via interop.

## Como usar

```razor
@* Sem implementação suportada pela biblioteca *@
@* Padrão mobile — usar DropIconButton como alternativa acessível para mobile web *@
<div class="flex items-center justify-between p-3 border-b border-light-100">
    <span class="text-sm text-dark-600">@item.Nome</span>
    <DropIconButton Icon="WellKnownIcons.More" Style="Themes.Default">
        <DropItem Text="Editar" OnClick="@(() => Editar(item.Id))" />
        <DropItem Text="Excluir" OnClick="@(() => Excluir(item.Id))" />
    </DropIconButton>
</div>
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: sem suporte nativo; alternativa web: DropIconButton com ações contextuais;
- `recomendação`: `evitar`
- `justificativa geral`: gestos de swipe requerem JS nativo ou lib externa; `DropIconButton` é alternativa adequada para web.
