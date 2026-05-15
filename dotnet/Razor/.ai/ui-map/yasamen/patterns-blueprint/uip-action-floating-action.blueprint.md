# UIP-ACTION-FLOATING_ACTION - Blueprint

## Identificação
- **Pattern**: UIP-ACTION-FLOATING_ACTION - Floating Action.
- **Nível final**: resumido.
- **Cobertura atual**: 5.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_action.pattern.md`, samples de `IconButton`, `Button`, `Modal`, `OffCanvas`, `visual.language.md` e `styles.map.md`.

## Gap resumido
`IconButton` pode flutuar com classes, mas faltam regra de posicionamento, colisão com shell e estado disabled/loading.

## Decisão arquitetural principal
Criar `[API proposta] FloatingAction` como wrapper posicionado sobre `IconButton` ou `Button`.

## Componentes reaproveitados
`IconButton` para ação circular, `Button` para ação estendida, `Modal`/`OffCanvas` como destino.

## Bloco principal de código

```razor
@* [API proposta] FloatingAction *@
<div class="fixed right-8 bottom-8 z-app-bar">
    <IconButton Icon="BsIconNames.Plus"
                Style="Themes.Primary"
                Size="Sizes.Large"
                OnClick="OnClick"
                AdditionalClasses="shadow-lg" />
</div>
```

## Exemplo principal de uso
Use para "novo item" em feed, catálogo ou board. Evitar em formulários, wizard e settings.

## Justificativa breve da cobertura proposta
A proposta define quando e onde usar, elevando a previsibilidade. O componente base já existe, mas o padrão flutuante não.

## Limitações remanescentes
- Não detecta colisão com footer/bottom nav.
- Label acessível precisa ser garantido pelo app.

## Pontos de adaptação
- Usar uma única ação dominante.
- Ocultar quando usuário não tiver permissão.
