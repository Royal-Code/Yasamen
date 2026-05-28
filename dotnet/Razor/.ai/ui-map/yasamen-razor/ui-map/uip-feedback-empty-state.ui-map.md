# UIP-FEEDBACK-EMPTY_STATE - Empty State

## Componentes

**Principais**:

1. Feedback
- `cobertura`: exibe título + texto com cor semântica; `Closeable=true` para estados dispensáveis; temas Info, Warning, Secondary para vazio sem erro; inclui borda colorida e fundo pastel; adequado para estado vazio textual simples; não tem ícone ilustrativo, CTA como slot filho pode ser adicionado via ChildContent;
- `limitações`: não tem layout de "zona vazia" com ilustração e botão centrado; fundo pastel pode não ser o visual esperado para empty state neutro; sem ícone de placeholder próprio; o Feedback é semânticamente para alertas, não para estados de vazio;
- `nota`: 5;
- `justificativa`: cobre o caso de empty state textual simples com orientação; perde pontos porque não é um componente dedicado de empty state e não tem layout centrado com ilustração/ícone.

**Composição**:

1. Box
- `cobertura`: envolve a zona de empty state com borda e padding; delimita o espaço visual;
- `limitações`: sem comportamento de empty state nativo;
- `nota`: 7;
- `justificativa`: encaixe natural para delimitar a zona do estado vazio.

2. Stack
- `cobertura`: organiza ícone + título + texto + CTA verticalmente centralizado;
- `limitações`: sem centralização automática — requer `items-center` via `AdditionalClasses`;
- `nota`: 7;
- `justificativa`: organiza os elementos do empty state em sequência vertical.

3. Button
- `cobertura`: CTA do empty state (ex: "Criar Primeiro Registro", "Limpar Filtros");
- `limitações`: nenhuma — é apenas um botão;
- `nota`: 9;
- `justificativa`: ação de orientação do empty state.

**Descartados**:

1. Badge
- `motivo`: sem papel no empty state — indicador de status, não de estado de ausência.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `layout centrado com ícone + título + texto + CTA`: Feedback não tem layout centrado; requer Box + Stack + ícone manual + Button;
  - `variante por tipo de vazio` (primeiro uso, busca vazia, filtro ativo, permissão): Feedback não distingue tipos — necessário variar texto e CTA por código;
  - `ilustração de vazio`: nenhum componente tem ilustração; usar ícone via WellKnownIcons ou omitir.

- `tipo de adaptação`: componentes principais + composição
- `o que precisa ser feito`:
  - Para empty state simples textual: usar `Feedback` com Style Info/Warning + texto orientativo;
  - Para empty state com layout centrado: usar `Box` + `Stack` + ícone + heading HTML + `Button` CTA;
  - Distinguir variantes por tipo de vazio com texto/CTA diferentes no código da página;
  - Para zoom visual, envolver em `Box` com padding generoso (`p-8`) e `items-center`.

## Como usar

### Empty state com Feedback (simples)

```razor
@if (!itens.Any())
{
    <Feedback Style="Themes.Info" Title="Nenhum item encontrado"
              Text="Não há registros para exibir. Clique em 'Novo' para criar o primeiro."
              AdditionalClasses="mb-4" />
}
```

### Empty state com layout centrado (composição)

```razor
@if (!itens.Any())
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-8">
        <Stack AdditionalClasses="items-center gap-4 py-8 text-center">
            @WellKnownIcons.Info("text-4xl text-dark-300")
            <h3 class="text-lg font-semibold text-dark-600">Nenhum registro encontrado</h3>
            <p class="text-sm text-dark-700 max-w-sm">
                Você ainda não possui registros. Crie o primeiro para começar.
            </p>
            <Button Style="Themes.Primary" Label="Criar Primeiro Registro"
                    OnClick="IrParaCriacao" />
        </Stack>
    </Box>
}
```

### Empty state por filtro ativo

```razor
@if (!itens.Any() && filtroAtivo)
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-6">
        <Stack AdditionalClasses="items-center gap-3 py-4 text-center">
            <h3 class="text-base font-semibold text-dark-600">Sem resultados para o filtro aplicado</h3>
            <p class="text-sm text-dark-700">Ajuste os filtros para encontrar registros.</p>
            <Button Style="Themes.Secondary" Outline=true Label="Limpar Filtros"
                    OnClick="LimparFiltros" />
        </Stack>
    </Box>
}
```

### Empty state por permissão (sem CTA)

```razor
@if (!temPermissao)
{
    <Feedback Style="Themes.Warning" Title="Acesso insuficiente"
              Text="Você não tem permissão para visualizar este conteúdo. Contate o administrador." />
}
```

## Decisão de uso

- `nota geral`: 5;
- `limitações`: nenhum componente dedicado de empty state com layout centrado e ilustração; Feedback serve para variante textual simples mas não cobre empty state visual completo; layout centrado com ícone+título+CTA requer composição manual com Box+Stack+Button; sem distinção automática de variante (primeiro uso vs busca vs filtro);
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Feedback` com Style Info ou Warning cobre empty states textuais simples de forma direta — sem código extra;
  - Para empty states com layout centrado e ícone, compor `Box` + `Stack` + `@WellKnownIcons.*` + `Button` — 4 componentes, sem CSS customizado;
  - A ausência de um componente dedicado de empty state é a razão da nota 5 — o padrão visual não é nativo, precisa de composição manual;
  - O resultado visual da composição é coherente com a linguagem visual (tons suaves, tipografia semibold para título, Button Primary para CTA).
