# Stack - Sample

## Contrato de uso

**Entrada pública**: `<Stack>` — namespace `RoyalCode.Razor.Layouts`
**Grupo**: UI-STRUCT
**Propósito**: Container vertical flex para empilhar elementos na direção de coluna. Base para listas verticais, campos de formulário e seções de conteúdo.
**Patterns**:
- `implementa`: UIP-STRUCT-STACK_CONTAINER
- `compõe`: UIP-INPUT-FORM_FIELD_GROUP, UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-ERROR_STATE, UIP-CONTENT-METRIC_CARD, UIP-CONTENT-COMMENT_THREAD, UIP-DATA-TREE_VIEW, UIP-DATA-TIMELINE_ITEM, UIP-DATA-KANBAN_COLUMN
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: empilhamento vertical de campos de formulário, itens de lista, seções de card, threads de comentários
- **Evite quando**: a distribuição é horizontal — use `Bar`; quando precisa de grid responsivo — use `Container`+`Slot`
- **Cuidado**: aplica `w-100` (largura total) por default — evitar dentro de contextos inline onde largura limitada é desejada

## Exemplos

### `UIP-STRUCT-STACK_CONTAINER, UIP-INPUT-FORM_FIELD_GROUP` — Campos de formulário empilhados

Stack é o container padrão para grupos de campos em formulários; use `AdditionalClasses="gap-4"` para espaçamento entre campos.

```razor
@* Grupo de campos — Stack como container de form fields *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-6">
    <h2 class="text-base font-semibold text-dark-700 mb-4">Dados pessoais</h2>
    <Stack AdditionalClasses="gap-4">
        <TextField @bind-Value="model.Nome" Label="Nome completo" required />
        <TextField @bind-Value="model.Email" Label="E-mail" required />
        <TextField @bind-Value="model.Telefone" Label="Telefone" />
    </Stack>
</Box>

@* Seção de endereço separada *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-6 mt-4">
    <h2 class="text-base font-semibold text-dark-700 mb-4">Endereço</h2>
    <Stack AdditionalClasses="gap-4">
        <TextField @bind-Value="model.Logradouro" Label="Logradouro" />
        <Container>
            <Slot Span="8"><TextField @bind-Value="model.Cidade" Label="Cidade" /></Slot>
            <Slot Span="4"><TextField @bind-Value="model.Cep" Label="CEP" /></Slot>
        </Container>
    </Stack>
</Box>
```

**API usada**: `AdditionalClasses="gap-4"` para espaçamento entre filhos

### `UIP-DATA-TIMELINE_ITEM, UIP-CONTENT-COMMENT_THREAD` — Listas verticais sequenciais

Stack é ideal para timelines e threads onde a ordem vertical é semântica.

```razor
@* Timeline de eventos *@
<Stack AdditionalClasses="gap-0">
    @foreach (var evento in eventos)
    {
        <div class="flex gap-3 pb-4">
            <div class="flex flex-col items-center shrink-0">
                <Badge Style="@evento.TipoTema" Icon="@evento.Icone" />
                <div class="flex-1 w-px bg-light-200 mt-1"></div>
            </div>
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-3 flex-1 mb-2">
                <p class="text-sm font-semibold text-dark-700">@evento.Titulo</p>
                <p class="text-xs text-dark-400">@evento.Data.ToString("dd/MM/yyyy HH:mm")</p>
                <p class="text-sm text-dark-600 mt-1">@evento.Descricao</p>
            </Box>
        </div>
    }
</Stack>

@* Thread de comentários *@
<Stack AdditionalClasses="gap-3">
    @foreach (var comentario in comentarios)
    {
        <div class="flex gap-3">
            <div class="w-8 h-8 rounded-full bg-primary-100 flex items-center justify-center shrink-0">
                <span class="text-xs font-semibold text-primary-700">@comentario.Iniciais</span>
            </div>
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-3 flex-1">
                <Bar AdditionalClasses="mb-1">
                    <StartContent>
                        <span class="text-sm font-semibold text-dark-700">@comentario.Autor</span>
                    </StartContent>
                    <EndContent>
                        <span class="text-xs text-dark-400">@comentario.Data.ToString("HH:mm")</span>
                    </EndContent>
                </Bar>
                <p class="text-sm text-dark-600">@comentario.Texto</p>
            </Box>
        </div>
    }
</Stack>
```

### `UIP-DATA-KANBAN_COLUMN, UIP-DATA-TREE_VIEW, UIP-FEEDBACK-EMPTY_STATE` — Colunas e estados

```razor
@* Kanban column — Stack de cards *@
<div class="w-64 shrink-0">
    <p class="text-sm font-semibold text-dark-500 uppercase mb-3">@coluna.Nome</p>
    <Stack AdditionalClasses="gap-2">
        @if (!coluna.Tarefas.Any())
        {
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4 text-center">
                <p class="text-xs text-dark-300">Nenhuma tarefa</p>
            </Box>
        }
        @foreach (var tarefa in coluna.Tarefas)
        {
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-3 cursor-pointer hover:shadow-sm">
                <Badge Style="@tarefa.PrioridadeTema" Text="@tarefa.Prioridade" Size="Sizes.Small" />
                <p class="text-sm font-semibold text-dark-700 mt-1">@tarefa.Titulo</p>
            </Box>
        }
    </Stack>
</div>
```

## API relevante

- **Props/parâmetros**: `AdditionalClasses: string?` — comum para `gap-2`, `gap-4`, `gap-6` (espaçamento vertical entre filhos)
- **Slots**: `ChildContent: RenderFragment`
- **Base CSS**: `ya-stack flex flex-col w-100` — flex vertical, largura total

## Limites e combinações frágeis

- Stack aplica `w-100` (largura total) — dentro de contextos inline, pode expandir demais; use `AdditionalClasses="w-auto"` para sobrescrever se necessário
- Sem parâmetro `Gap` nativo — usar `AdditionalClasses="gap-{N}"` com classes Tailwind para espaçamento entre filhos
