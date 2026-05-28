# UIP-STRUCT-STACK_CONTAINER - Stack Container

## Componentes

**Principais**:

1. Stack
- `cobertura`: contêiner de flex vertical com `ya-stack`; organiza filhos em sequência vertical; espaçamento coerente via gap nativo do flex; sem lógica adicional; autocontido;
- `limitações`: sem separadores visuais entre filhos nativos; sem variante de espaçamento (spacing é uniforme por padrão — ajuste via `AdditionalClasses`); sem estado de loading/empty nativo; sem scroll próprio;
- `nota`: 9;
- `justificativa`: cobertura nativa e direta do pattern; Stack é exatamente um empilhamento vertical; gap entre filhos controlável via `gap-*` em `AdditionalClasses`.

**Composição**:

1. Box
- `cobertura`: envolve o Stack quando a zona precisa de borda, padding ou margem externos;
- `limitações`: adiciona camada de markup; não altera o comportamento de stack;
- `nota`: 8;
- `justificativa`: encaixe natural para delimitar visualmente a área do stack.

**Descartados**:

1. Container
- `motivo`: Container é grid, não stack; quando o layout é vertical e simples, Stack é preferível sem a semântica de grade.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `separadores entre filhos`: Stack não tem separador visual nativo — inserir `<hr class="border-light-200">` entre grupos quando necessário;
  - `espaçamento variável por grupo`: Stack tem gap uniforme — ajustar com `mb-*` em filhos específicos via `AdditionalClasses`.

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Usar `<Stack>` diretamente; ajustar gap via `AdditionalClasses="gap-4"` ou similar;
  - Para separadores visuais, inserir `<hr class="border-light-200 my-2">` como filho explícito;
  - Para grupos com espaçamento diferente, usar `mb-*` nos grupos de filhos.

## Como usar

### Stack simples

```razor
<Stack>
    <span class="text-sm text-dark-700">Campo 1</span>
    <span class="text-sm text-dark-700">Campo 2</span>
    <span class="text-sm text-dark-700">Campo 3</span>
</Stack>
```

### Stack com gap ajustado

```razor
<Stack AdditionalClasses="gap-4">
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
        <span class="text-sm font-semibold text-dark-600">Grupo A</span>
    </Box>
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
        <span class="text-sm font-semibold text-dark-600">Grupo B</span>
    </Box>
</Stack>
```

### Stack com separadores entre grupos

```razor
<Stack AdditionalClasses="gap-4 p-4">
    <div>
        <span class="text-xs text-dark-700 uppercase font-medium">Dados pessoais</span>
        @* campos *@
    </div>
    <hr class="border-light-200" />
    <div>
        <span class="text-xs text-dark-700 uppercase font-medium">Endereço</span>
        @* campos *@
    </div>
</Stack>
```

### Stack dentro de Box como card de detalhe

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4 mb-4">
    <Stack AdditionalClasses="gap-3">
        <span class="text-sm text-dark-700">@item.Nome</span>
        <Badge Style="@item.StatusTheme" Text="@item.Status" />
        <span class="text-xs text-dark-700">Criado em @item.CriadoEm.ToString("dd/MM/yyyy")</span>
    </Stack>
</Box>
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: sem separadores visuais nativos entre filhos (workaround: `<hr>` HTML); sem variante de espaçamento configu​rável via prop (workaround: `AdditionalClasses="gap-*"`); sem estado de loading/empty (inserir Feedback condicional);
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `Stack` é o componente nativo da biblioteca para empilhamento vertical — cobertura total do pattern;
  - Nota 9 porque o único gap é a ausência de espaçamento variável via prop dedicado e de separadores nativos, ambos facilmente contornáveis;
  - Sem necessidade de composição ou adaptação para o caso de uso central;
  - Combina naturalmente com `Box` para delimitar visualmente a área do stack.
