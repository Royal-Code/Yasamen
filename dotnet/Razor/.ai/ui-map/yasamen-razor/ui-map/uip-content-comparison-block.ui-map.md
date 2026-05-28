# UIP-CONTENT-COMPARISON_BLOCK - Comparison Block

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de comparison block. Requer composição com `Container+Slot` (lado a lado) ou `Stack`/`Box` (empilhado) + HTML para highlights de diferença.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Container+Slot (2 colunas)
- `cobertura`: layout lado a lado para comparação; cada slot contém um bloco de detalhe;
- `nota`: 7;
- `justificativa`: grid de 2 colunas para comparação paralela.

2. Box
- `cobertura`: container de cada lado da comparação com borda e padding; realce via `AdditionalClasses="border-success-400"` para adicionado, `"border-danger-400"` para removido;
- `nota`: 7;
- `justificativa`: delimitação visual de cada lado com possibilidade de realce semântico.

3. Badge
- `cobertura`: label de versão/estado no header de cada lado ("Atual", "Novo", "v1.0", "v2.0");
- `nota`: 8;
- `justificativa`: identificador visual de cada item na comparação.

4. Bar
- `cobertura`: header de cada lado com label/versão + badge de status; toolbar de ações (aceitar, rejeitar);
- `nota`: 7;
- `justificativa`: cabeçalho de cada coluna e toolbar de ação da comparação.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `diff textual com realce de palavras`: sem nativo — biblioteca externa (diff-match-patch via JS interop) ou CSS de realce manual;
  - `highlights de linhas adicionadas/removidas`: `bg-success-50 border-l-2 border-success-400` para adicionado, `bg-danger-50 border-l-2 border-danger-400` para removido;
  - `aceitar/rejeitar alteração por item`: botões por linha com lógica de merge no app.

- `tipo de adaptação`: composição direta
- `o que precisa ser feito`:
  - Layout lado a lado: `Container+Slot cols=2` com `Box` por lado;
  - Para mobile: `Bar` com `ButtonGroup` "Atual"/"Novo" para alternância + conteúdo condicional;
  - Highlights de diferença via CSS de borda colorida.

## Como usar

### Comparação lado a lado (antes/depois)

```razor
<div class="mb-4">
    <Bar AdditionalClasses="mb-3">
        <StartContent>
            <h3 class="text-sm font-semibold text-dark-600">Comparação de alterações</h3>
        </StartContent>
        <EndContent>
            <Button Style="Themes.Success" Label="Aprovar alterações" OnClick="Aprovar" />
            <Button Style="Themes.Danger" Outline=true Label="Rejeitar" OnClick="Rejeitar" />
        </EndContent>
    </Bar>
    <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <Bar AdditionalClasses="mb-3">
                <StartContent>
                    <Badge Style="Themes.Light" Text="Atual" />
                </StartContent>
            </Bar>
            <dl class="space-y-2">
                <div>
                    <dt class="text-xs text-dark-400">Nome</dt>
                    <dd class="text-sm text-dark-600">@versaoAtual.Nome</dd>
                </div>
                <div class="bg-danger-50 border-l-2 border-danger-400 pl-2 -ml-2">
                    <dt class="text-xs text-dark-400">Preço</dt>
                    <dd class="text-sm text-dark-600">@versaoAtual.Preco.ToString("C")</dd>
                </div>
            </dl>
        </Box>
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <Bar AdditionalClasses="mb-3">
                <StartContent>
                    <Badge Style="Themes.Primary" Text="Proposto" />
                </StartContent>
            </Bar>
            <dl class="space-y-2">
                <div>
                    <dt class="text-xs text-dark-400">Nome</dt>
                    <dd class="text-sm text-dark-600">@versaoNova.Nome</dd>
                </div>
                <div class="bg-success-50 border-l-2 border-success-400 pl-2 -ml-2">
                    <dt class="text-xs text-dark-400">Preço</dt>
                    <dd class="text-sm font-semibold text-success-700">@versaoNova.Preco.ToString("C")</dd>
                </div>
            </dl>
        </Box>
    </div>
</div>
```

### Comparação de planos (marketing)

```razor
<div class="grid grid-cols-1 sm:grid-cols-3 gap-4 mb-6">
    @foreach (var plano in planos)
    {
        <Box Border="BorderBuilder.Box"
             AdditionalClasses="@($"p-4 {(plano.Destaque ? "border-primary-400 ring-2 ring-primary-200" : "")}")">
            <Bar AdditionalClasses="mb-3">
                <StartContent>
                    <div>
                        <h4 class="font-semibold text-dark-600">@plano.Nome</h4>
                        <p class="text-2xl font-bold text-primary-600">@plano.Preco.ToString("C")<span class="text-xs text-dark-400">/mês</span></p>
                    </div>
                </StartContent>
            </Bar>
            @if (plano.Destaque)
            {
                <Badge Style="Themes.Primary" Text="Mais popular" AdditionalClasses="mb-2" />
            }
            @* features do plano *@
            <Button Style="@(plano.Destaque ? Themes.Primary : Themes.Secondary)"
                    Outline="@(!plano.Destaque)"
                    Label="Assinar" OnClick="() => Assinar(plano.Id)"
                    AdditionalClasses="w-full mt-4" />
        </Box>
    }
</div>
```

## Decisão de uso

- `nota geral`: 4;
- `limitações`: sem componente de comparison block nativo; diff textual requer biblioteca externa; layout lado a lado funcional via grid CSS mas totalmente manual; sem abstração de "aceitar/rejeitar por item";
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Container+Slot` + `Box` + `Bar` + `Badge` cobrem comparação lado a lado e tabela de planos;
  - CSS de highlight (borders coloridas) para realce de diferenças;
  - Nota 4 reflete composição manual funcional sem abstração dedicada de comparação.
