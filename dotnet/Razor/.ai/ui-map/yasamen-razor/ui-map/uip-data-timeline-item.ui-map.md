# UIP-DATA-TIMELINE_ITEM - Timeline Item

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de timeline. Requer composição com HTML CSS para a linha vertical + `Box`/`Bar` para cada item cronológico.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Stack
- `cobertura`: sequência vertical de itens de timeline com espaçamento coerente;
- `nota`: 7;
- `justificativa`: container da lista cronológica.

2. Bar
- `cobertura`: linha do item com ícone de evento + conteúdo principal + timestamp;
- `nota`: 6;
- `justificativa`: layout horizontal de linha de timeline.

3. Badge
- `cobertura`: tipo de evento, status do item, agrupador de data;
- `nota`: 7;
- `justificativa`: classificação visual do tipo de evento na timeline.

**Descartados**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: composição + CSS para linha vertical
- `o que precisa ser feito`:
  - Linha vertical de timeline: `<div class="relative">` com `border-l border-light-300` + posicionamento do ponto indicador;
  - Cada item: `<div class="relative pl-6">` + ponto `before:absolute before:left-0` + conteúdo;
  - Agrupamento por data: `Badge Style=Light` como separador de dia.

## Como usar

### Timeline de histórico de atividade

```razor
<div class="relative border-l-2 border-light-200 ml-4 space-y-4 pb-4">
    @foreach (var evento in eventos.OrderByDescending(e => e.DataHora))
    {
        <div class="relative pl-6 -ml-px">
            @* Ponto indicador *@
            <div class="absolute -left-2 top-1 w-4 h-4 rounded-full border-2 border-primary-400 
                        bg-white @(evento.Tipo == "erro" ? "border-danger-400" : "")">
            </div>
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
                <Bar>
                    <StartContent>
                        <div>
                            <p class="text-sm font-medium text-dark-600">@evento.Descricao</p>
                            <p class="text-xs text-dark-400">@evento.DataHora.ToString("dd/MM/yyyy HH:mm")</p>
                        </div>
                    </StartContent>
                    <EndContent>
                        <Badge Style="@GetEventoTema(evento.Tipo)" Text="@evento.Tipo" />
                    </EndContent>
                </Bar>
                @if (evento.Detalhes is not null)
                {
                    <p class="text-xs text-dark-400 mt-1">@evento.Detalhes</p>
                }
            </Box>
        </div>
    }
</div>
```

### Timeline com agrupamento por data

```razor
@foreach (var grupo in eventos.GroupBy(e => e.DataHora.Date).OrderByDescending(g => g.Key))
{
    <div class="flex items-center gap-2 my-3">
        <div class="flex-1 h-px bg-light-200"></div>
        <Badge Style="Themes.Light" Text="@grupo.Key.ToString("dd/MM/yyyy")" />
        <div class="flex-1 h-px bg-light-200"></div>
    </div>
    @foreach (var e in grupo.OrderByDescending(x => x.DataHora))
    {
        @* item de timeline *@
    }
}
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de timeline nativo; linha vertical requer CSS manual; agrupamento por data manual; toda estrutura é composição HTML + Tailwind;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Stack` + `Box` + `Bar` + `Badge` + CSS de linha vertical cobrem timeline funcional;
  - A lib contribui com primitivos de card e badge — estrutura cronológica é HTML/CSS manual;
  - Nota 3 reflete composição manual sem abstração de timeline na lib.
