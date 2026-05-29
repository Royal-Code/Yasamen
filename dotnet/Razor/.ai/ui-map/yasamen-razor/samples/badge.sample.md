# Badge - Sample

## Contrato de uso

**Entrada pública**: `<Badge>` — namespace `RoyalCode.Razor.Alerts`
**Grupo**: UI-CONTENT
**Propósito**: Rótulo/pill compacto para indicar estado, categoria, contagem ou classificação inline.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-DATA-LIST_ITEM, UIP-DATA-DATA_TABLE, UIP-DATA-CARD_GRID, UIP-CONTENT-CONTENT_HEADER, UIP-CONTENT-METRIC_CARD, UIP-NAV-STEPPER_INDICATOR, UIP-STRUCT-COLLAPSIBLE_SECTION, UIP-DATA-TIMELINE_ITEM, UIP-DATA-KANBAN_COLUMN
**Setup necessário**: `builder.Services.AddYasamenCommons()` + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: indicadores de status em listas/tabelas/cards, contadores de notificação, tags de categoria/classificação
- **Evite quando**: o texto é longo ou precisa de ação de fechar — use `Feedback`; para notificações temporárias — use `Notification`
- **Cuidado**: `IconPosition.Center` lança `InvalidOperationException` — use apenas `Start` ou `End`

## Exemplos

### `UIP-DATA-LIST_ITEM, UIP-DATA-DATA_TABLE, UIP-DATA-CARD_GRID` — Status em coleções de dados

Use `Themes.*` pelo significado semântico: Success=ativo/ok, Danger=erro/inativo, Warning=atenção, Default/Light=neutro.

```razor
@* Lista com badge de status *@
@foreach (var pedido in pedidos)
{
    <Bar AdditionalClasses="p-3 border-b border-light-100">
        <StartContent>
            <p class="text-sm font-semibold text-dark-700">#@pedido.Numero — @pedido.Cliente</p>
        </StartContent>
        <EndContent>
            <Badge Style="@StatusTema(pedido.Status)" Text="@pedido.Status" />
        </EndContent>
    </Bar>
}

@* Tabela com badge de quantidade *@
<td class="p-3">
    <Badge Style="@(produto.Estoque > 10 ? Themes.Success : Themes.Danger)"
           Text="@produto.Estoque.ToString()" />
</td>

@* Card com badge de categoria *@
<Box Border="BorderBuilder.Box">
    <Bar AdditionalClasses="p-3">
        <EndContent>
            <Badge Style="Themes.Info" Text="@item.Categoria" />
        </EndContent>
    </Bar>
</Box>
```

### `UIP-CONTENT-CONTENT_HEADER, UIP-CONTENT-METRIC_CARD` — Indicadores em cabeçalhos e cards de métrica

Badge de tendência (variação %) e badge de estado em headers de seção.

```razor
@* Cabeçalho de métrica com badge de variação *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <Bar AdditionalClasses="mb-2">
        <StartContent>
            <p class="text-xs text-dark-400 uppercase font-medium">Receita mensal</p>
        </StartContent>
        <EndContent>
            <Badge Style="@(variacaoReceita >= 0 ? Themes.Success : Themes.Danger)"
                   Icon="@(variacaoReceita >= 0 ? WellKnownIcons.TrendUp : WellKnownIcons.TrendDown)"
                   Text="@($"{variacaoReceita:+0.0;-0.0}%")" />
        </EndContent>
    </Bar>
    <p class="text-2xl font-semibold text-dark-700">R$ @receita.ToString("N2")</p>
</Box>

@* Header de página com badge de estado *@
<Bar AdditionalClasses="mb-7">
    <StartContent>
        <div class="flex items-center gap-3">
            <h1 class="text-xl font-semibold text-dark-600">Campanha de Verão</h1>
            <Badge Style="Themes.Warning" Text="Rascunho" />
        </div>
    </StartContent>
</Bar>
```

**API usada**: `Style`, `Icon`, `IconPosition` (default Start), `Text`

### `UIP-NAV-STEPPER_INDICATOR, UIP-STRUCT-COLLAPSIBLE_SECTION` — Badges em estruturas de navegação

Contador de itens em seção colapsável; badge de etapa ativa em indicador de passos.

```razor
@* Seção colapsável com contagem de itens *@
<Bar AdditionalClasses="p-3 cursor-pointer" @onclick="ToggleSecao">
    <StartContent>
        <p class="text-sm font-semibold text-dark-700">Permissões</p>
        <Badge Style="Themes.Secondary" Text="@($"{permissoes.Count}")" Size="Sizes.Small" />
    </StartContent>
    <EndContent>
        <Icon Kind="@(aberto ? WellKnownIcons.ChevronUp : WellKnownIcons.ChevronDown)" />
    </EndContent>
</Bar>

@* Indicador de passo em wizard *@
<div class="flex gap-2 items-center">
    @for (int i = 1; i <= totalPassos; i++)
    {
        int passo = i;
        <Badge Style="@(passo == passoAtual ? Themes.Primary : (passo < passoAtual ? Themes.Success : Themes.Light))"
               Text="@passo.ToString()" />
    }
</div>
```

**API usada**: `Style`, `Size`, `Text`

### `UIP-DATA-TIMELINE_ITEM, UIP-DATA-KANBAN_COLUMN` — Classificação em timeline e kanban

Badge como marcador de tipo/prioridade; combinação com ícone.

```razor
@* Item de timeline com badge de tipo *@
<Stack AdditionalClasses="gap-0">
    @foreach (var evento in eventos)
    {
        <div class="flex gap-3 pb-4">
            <div class="flex flex-col items-center">
                <Badge Style="@evento.TipoTema" Icon="@evento.Icone" />
                <div class="flex-1 w-px bg-light-200 mt-1"></div>
            </div>
            <div class="pb-2">
                <p class="text-sm font-semibold text-dark-700">@evento.Titulo</p>
                <p class="text-xs text-dark-400">@evento.Data.ToString("dd/MM/yyyy HH:mm")</p>
            </div>
        </div>
    }
</Stack>

@* Kanban: badge de prioridade no card *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-3 mb-2">
    <Badge Style="@(tarefa.Prioridade == "Alta" ? Themes.Danger : Themes.Default)"
           Text="@tarefa.Prioridade" Size="Sizes.Small" />
    <p class="text-sm text-dark-700 mt-1">@tarefa.Titulo</p>
</Box>
```

## API relevante

- **Props/parâmetros**: `Text: string?`, `Style: Themes`, `Size: Sizes`, `Icon: Enum?`, `IconPosition: Positions` (Start|End — Center inválido)
- **Slots**: `ChildContent: RenderFragment?` — conteúdo custom em vez de `Text`
- **Estados/variantes**: fallback automático para `ya-badge-secondary` quando `Style` não definido

## Limites e combinações frágeis

- `IconPosition.Center` lança `InvalidOperationException` em runtime — usar apenas `Start` ou `End`
- Badge não tem onClick nativo — para badges clicáveis, envolver em `<button>` com classe Tailwind ou usar um `Button` customizado
