# UIP-STRUCT-SCROLLABLE_REGION - Blueprint resumido

## Pattern

UIP-STRUCT-SCROLLABLE_REGION — Scrollable Region — ver `uip-struct-scrollable-region.ui-map.md`

## Gap coberto

A lib não oferece componente de região com scroll; toda a restrição de altura e ativação de scroll é feita via classes Tailwind diretamente no elemento container. O gap é documentar quais combinações de classes usar para os cenários mais comuns (vertical, horizontal, full-height).

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: gap é 100% CSS — `overflow-y-auto` + restrição de altura; nenhum componente da lib adiciona valor além de servir como container externo.

## Componentes usados

- `Box` — papel: composição — ver `box.sample.md` (opcional; qualquer elemento HTML funciona)
- `Stack` — papel: composição — ver `stack.sample.md` (container interno quando o conteúdo é uma lista)

## Recursos visuais

- `overflow-y-auto`, `overflow-x-auto`, `overflow-hidden` — controle de scroll por eixo
- `max-h-{n}`, `h-{n}`, `h-full`, `flex-1` — restrição de altura necessária para ativar o scroll
- `overscroll-contain` — evita scroll-chain em painéis aninhados

## Receita

Aplicar `overflow-y-auto` com restrição de altura ao container; o conteúdo interno cresce livremente.

```razor
@* Região com altura máxima fixa — scroll quando conteúdo ultrapassa *@
<div class="overflow-y-auto max-h-96">
    <Stack Gap="Gaps.None">
        @foreach (var item in itens)
        {
            <div class="py-2 border-b border-light-100">@item.Nome</div>
        }
    </Stack>
</div>

@* Painel que ocupa todo o espaço disponível no flex pai *@
<div class="flex-1 overflow-y-auto min-h-0">
    @* min-h-0 é necessário em filhos flex para que overflow funcione *@
    @ChildContent
</div>

@* Scroll horizontal (tabela ou board) *@
<div class="overflow-x-auto">
    <div class="min-w-max">
        @* conteúdo mais largo que o viewport *@
    </div>
</div>
```

## Limites

- `min-h-0` é obrigatório em filhos de flex quando usar `flex-1 overflow-y-auto` — sem ele o flex filho expande sem limite e o scroll não ativa;
- scroll com snap, scroll infinito ou scroll programático exigem JS interop externo.
