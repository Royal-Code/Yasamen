# UIP-STRUCT-SCROLLABLE_REGION - Scrollable Region

**GAP — sem cobertura viável**

Nenhum componente da biblioteca implementa uma região com scroll próprio. A implementação requer CSS puro via classes Tailwind em elemento HTML.

## Componentes

**Principais**: nenhum.

**Composição**: nenhum.

**Descartados**:

1. Box
- `motivo`: Box não adiciona overflow ou height constraint — é apenas um container com borda/padding; não provê scroll independente nativamente.

2. Stack
- `motivo`: layout de flex vertical sem overflow próprio.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `scroll independente do scroll da página`: nenhum componente provê `overflow-y: auto` + `height`; requer CSS manual via `AdditionalClasses`;
  - `height constraint`: sem prop de altura máxima nos componentes; requer classe Tailwind `max-h-*` ou `h-*` no elemento;
  - `scroll virtualizado`: totalmente fora do escopo da biblioteca.

- `tipo de adaptação`: nova implementação + estilos
- `o que precisa ser feito`:
  - Usar elemento HTML `<div>` com `overflow-y-auto max-h-[valor]` via classes Tailwind;
  - Envolver o conteúdo rolável em `Box` + `AdditionalClasses="overflow-y-auto"` com uma altura máxima;
  - Para scroll de lista de dados, combinar com `Stack` interno para o conteúdo;
  - Para scroll com sticky header, usar `position: sticky` no header via CSS ad hoc.

## Como usar

### Região scrollável simples com Box

```razor
@* Box com scroll vertical limitado a 400px *@
<Box Border="BorderBuilder.Box" AdditionalClasses="overflow-y-auto max-h-[400px]">
    <Stack AdditionalClasses="p-2">
        @foreach (var item in itens)
        {
            <div class="p-2 border-b border-light-100 text-sm text-dark-600">
                @item.Nome
            </div>
        }
    </Stack>
</Box>
```

### Região scrollável para painel auxiliar em altura cheia

```razor
@* Painel lateral com scroll independente dentro de layout de altura fixa *@
<div class="flex h-screen overflow-hidden">
    <div class="w-64 overflow-y-auto border-r border-light-200 p-4">
        @* menu ou lista lateral *@
        <Stack>
            @foreach (var secao in secoes)
            {
                <Button Style="Themes.Default" Label="@secao.Nome" 
                        NavigateTo="@secao.Href" Block=true />
            }
        </Stack>
    </div>
    <div class="flex-1 overflow-y-auto p-6">
        @* conteúdo principal *@
        @Body
    </div>
</div>
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: a biblioteca não fornece componente para região scrollável — toda implementação depende de CSS Tailwind (`overflow-y-auto`, `max-h-*`, `h-*`) em elementos HTML; sem scroll virtualizado; sem comportamento pull-to-refresh; sem indicadores de scroll integrados;
- `recomendação`: `usar apenas como apoio`
- `justificativa geral`:
  - Nenhum componente `ya-*` endereça diretamente o padrão de região com scroll independente;
  - A alternativa é usar `Box` (ou `div`) com classes Tailwind `overflow-y-auto` + `max-h-[N]` — funciona, mas é implementação manual fora da API dos componentes;
  - Para scroll simples de lista ou painel, a abordagem CSS é suficiente e sem risco;
  - Para necessidades avançadas (virtualização, pull-to-refresh, scroll infinito), requer biblioteca JS externa;
  - Nota 2 reflete que apenas os primitivos CSS (tokens de tamanho Tailwind) são fornecidos, sem componente semântico.
