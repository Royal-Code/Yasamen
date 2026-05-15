# UIP-DATA-TIMELINE_ITEM - Blueprint

## Identificação
- **Pattern**: UIP-DATA-TIMELINE_ITEM - Timeline Item.
- **Nível final**: resumido.
- **Cobertura atual**: 2.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_data.pattern.md`, samples de `Box`, `Stack`, `Badge`, `Icon`, `DropIconButton`, `DropItem`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen não tem item cronológico, mas `Box`, `Badge`, `Icon` e `DropIconButton` compõem evento temporal com boa fidelidade.

## Decisão arquitetural principal
Criar `[API proposta] TimelineItem` com marker, timestamp, title, body, status e actions.

## Componentes reaproveitados
`Box` para conteúdo, `Badge` para tipo/status, `Icon` para marcador, `DropIconButton` para ações.

## Bloco principal de código

```razor
@* [API proposta] TimelineItem *@
<div class="grid grid-cols-[auto_1fr] gap-4">
    <div class="flex flex-col items-center">
        <div class="rounded-full bg-primary-100 text-primary-700 p-2">
            <Icon Kind="BsIconNames.InfoCircle" />
        </div>
        <div class="w-px flex-1 bg-light-300"></div>
    </div>
    <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-2">
        <div class="flex justify-between gap-3">
            <div>
                <div class="font-medium text-dark-900">@Title</div>
                <div class="text-sm text-dark-400">@Timestamp</div>
            </div>
            <DropIconButton Icon="BsIconNames.ThreeDots">@Actions</DropIconButton>
        </div>
        <p class="text-sm text-dark-600">@Body</p>
        <Badge Text="@Kind" Style="Themes.Info" Size="Sizes.Small" />
    </Box>
</div>
```

## Exemplo principal de uso
Use em feed, histórico de auditoria, atividade de entidade e eventos de dashboard.

## Justificativa breve da cobertura proposta
O blueprint formaliza marker, linha e conteúdo, que eram ausentes. A interação permanece simples.

## Limitações remanescentes
- Sem agrupamento por data nativo.
- Sem virtualização para histórico longo.

## Pontos de adaptação
- Escolher ícone e tema por tipo de evento.
- Usar menu contextual só para ações secundárias.
