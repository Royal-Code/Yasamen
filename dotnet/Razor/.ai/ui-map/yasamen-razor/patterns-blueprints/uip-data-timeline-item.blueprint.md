# UIP-DATA-TIMELINE_ITEM - Blueprint resumido

## Pattern

UIP-DATA-TIMELINE_ITEM — Timeline Item — ver `uip-data-timeline-item.ui-map.md`

## Gap coberto

A lib não tem componente de timeline. O gap é orientar a estrutura CSS de linha vertical + ponto indicador + `Box + Bar + Badge` por item, e o agrupamento de eventos por data.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `border-l-2 border-light-200 ml-4` para linha vertical; `<div class="relative pl-6">` + `div.absolute.-left-2` para ponto indicador; `Box + Bar + Badge` por item; `Badge(Light)` com linha separadora para agrupamento por data.

## Componentes usados

- `Box` — papel: composição (card do evento) — ver `box.sample.md`
- `Bar` — papel: composição (linha de metadados do evento) — ver `bar.sample.md`
- `Badge` — papel: composição (tipo de evento e separador de data) — ver `badge.sample.md`

## Recursos visuais

- `border-l-2 border-light-200 ml-4` — linha vertical da timeline
- `absolute -left-2 top-1 w-4 h-4 rounded-full border-2 bg-white` — ponto indicador
- `border-primary-400` — ponto de evento normal; `border-danger-400` — evento de erro
- `flex-1 h-px bg-light-200` — linha horizontal para separador de data

## Receita

Linha vertical CSS + ponto absoluto + `Box + Bar + Badge` por item; agrupamento por data com separador.

```razor
@code {
    private Themes GetEventoTema(string tipo) => tipo switch
    {
        "erro" or "falha" => Themes.Danger,
        "sucesso" or "aprovado" => Themes.Success,
        "aviso" => Themes.Warning,
        _ => Themes.Light
    };
}

@* Timeline simples *@
<div class="relative border-l-2 border-light-200 ml-4 space-y-4 pb-4">
    @foreach (var evento in eventos.OrderByDescending(e => e.DataHora))
    {
        <div class="relative pl-6 -ml-px">
            <div class="absolute -left-2 top-1 w-4 h-4 rounded-full border-2 bg-white
                        @(evento.Tipo == "erro" ? "border-danger-400" : "border-primary-400")">
            </div>
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
                <Bar>
                    <StartContent>
                        <div>
                            <p class="text-sm font-medium text-dark-600">
                                @evento.Descricao
                            </p>
                            <p class="text-xs text-dark-400">
                                @evento.DataHora.ToString("dd/MM/yyyy HH:mm")
                            </p>
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

@* Timeline com agrupamento por data *@
@foreach (var grupo in eventos.GroupBy(e => e.DataHora.Date)
                               .OrderByDescending(g => g.Key))
{
    @* Separador de data *@
    <div class="flex items-center gap-2 my-3">
        <div class="flex-1 h-px bg-light-200"></div>
        <Badge Style="Themes.Light"
               Text="@grupo.Key.ToString("dd/MM/yyyy")" />
        <div class="flex-1 h-px bg-light-200"></div>
    </div>

    <div class="relative border-l-2 border-light-200 ml-4 space-y-3 pb-2">
        @foreach (var e in grupo.OrderByDescending(x => x.DataHora))
        {
            <div class="relative pl-6 -ml-px">
                <div class="absolute -left-2 top-1 w-4 h-4 rounded-full border-2 bg-white
                            border-primary-400"></div>
                <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
                    <Bar>
                        <StartContent>
                            <p class="text-sm text-dark-600">@e.Descricao</p>
                        </StartContent>
                        <EndContent>
                            <span class="text-xs text-dark-400">
                                @e.DataHora.ToString("HH:mm")
                            </span>
                        </EndContent>
                    </Bar>
                </Box>
            </div>
        }
    </div>
}
```

## Limites

- Linha vertical e ponto indicador são HTML/CSS manual — sem componente dedicado;
- `OrderByDescending` no `@foreach` deve ser executado antes da renderização (não diretamente no loop para evitar re-ordenação em cada render);
- Para timeline horizontal (processo/stepper): ver `uip-nav-stepper-indicator.blueprint.md`.
