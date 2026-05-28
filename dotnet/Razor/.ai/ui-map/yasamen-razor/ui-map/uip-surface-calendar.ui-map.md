# UIP-SURFACE-CALENDAR - Calendar Surface

**GAP — sem componente dedicado**

A biblioteca não tem componente de calendário temporal. Requer biblioteca externa de calendário (FullCalendar, Radzen Calendar, etc.) ou implementação customizada.

## Componentes

**Principais**: nenhum.

**Composição**:

1. Bar
- `cobertura`: barra de navegação de período (mês anterior/próximo, seleção de visão);
- `nota`: 5;
- `justificativa`: header de controle de período — não cobre a superfície temporal em si.

2. Badge / Button
- `cobertura`: indicadores de eventos por dia em grade simplificada;
- `nota`: 3;
- `justificativa`: elementos pontuais apenas — sem grade temporal completa.

**Descartados**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: biblioteca externa ou implementação customizada completa
- `o que precisa ser feito`:
  - Para calendário completo: integrar biblioteca externa (ex: FullCalendar via JS interop, Radzen.Blazor com componente de calendário, MudBlazor Calendar);
  - Para lista cronológica simples: substituir por `UIP-DATA-TIMELINE_ITEM` (lista de eventos com data);
  - Para grade de disponibilidade simples: grid HTML + Tailwind com `Container+Slot`;
  - Para seleção de data: usar `UIP-INPUT-DATE_PICKER` — não é este pattern.

## Como usar

### Lista cronológica como alternativa (sem lib externa)

```razor
@* Alternativa: Timeline de eventos — ver UIP-DATA-TIMELINE_ITEM *@
<Stack Gap="Gaps.Small">
    @foreach (var evento in eventosPorDia)
    {
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-3">
            <Bar>
                <StartContent>
                    <div class="flex flex-col">
                        <span class="text-xs text-dark-400">@evento.Data.ToString("ddd, dd MMM")</span>
                        <span class="font-semibold text-dark-600">@evento.Titulo</span>
                    </div>
                </StartContent>
                <EndContent>
                    <Badge Style="@evento.Tema" Text="@evento.Duracao" />
                </EndContent>
            </Bar>
        </Box>
    }
</Stack>
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: sem componente de calendário temporal na lib; grade de mês/semana/dia requer biblioteca externa ou implementação completa; apenas lista cronológica é viável com componentes existentes;
- `recomendação`: `evitar`
- `justificativa geral`:
  - A lib não provê superfície temporal — alternativa web é biblioteca externa com JS interop;
  - Para leitura simples de eventos por data, substituir por `UIP-DATA-TIMELINE_ITEM`;
  - Nota 0 reflete ausência total de suporte nativo.
