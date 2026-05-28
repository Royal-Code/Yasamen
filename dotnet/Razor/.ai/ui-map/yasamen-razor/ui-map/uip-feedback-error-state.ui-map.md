# UIP-FEEDBACK-ERROR_STATE - Error State

## Componentes

**Principais**:

1. Feedback (Themes.Danger)
- `cobertura`: exibe título + texto de erro com fundo vermelho pastel e borda danger; `Closeable=true` para erros recuperáveis; suporta ChildContent para incluir ação de retry; cobre erro de submissão, erro de carregamento de zona e erro de validação geral; `Block=true` para ocupar largura total da zona;
- `limitações`: sem layout de "página de erro" centrado com ilustração; sem ação de retry integrada como prop — CTA deve ser filho; sem distinção automática de tipo de erro (rede, permissão, 404); sem estado de loading após retry;
- `nota`: 7;
- `justificativa`: cobre bem erro inline e de zona com título + texto; sem componente completo de página de erro, compensável com composição.

**Composição**:

1. Box
- `cobertura`: delimita a zona de erro com borda e padding; fornece container visual;
- `limitações`: sem semântica de erro;
- `nota`: 7;
- `justificativa`: natural para delimitar a área de erro de zona.

2. Stack
- `cobertura`: organiza ícone + título + texto + botão de retry verticalmente;
- `limitações`: sem semântica de erro;
- `nota`: 7;
- `justificativa`: bom organizador para erro de página com layout centrado.

3. Button
- `cobertura`: ação de retry / tentar novamente / voltar;
- `limitações`: nenhuma — botão padrão;
- `nota`: 9;
- `justificativa`: CTA de recuperação do erro.

4. Notification (Themes.Danger)
- `cobertura`: erro não bloqueante como toast — para erros de sistema que não impedem uso da zona;
- `limitações`: desaparece automaticamente — não adequado para erros persistentes que precisam de ação;
- `nota`: 6;
- `justificativa`: complementar para erros de sistema que não substituem o conteúdo da página.

**Descartados**:

1. Badge
- `motivo`: indicador de status, não de error state.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `erro de página completo com ilustração e retry centralizado`: Feedback não tem layout de página de erro — compor Box + Stack + ícone + heading + Button;
  - `distinção de tipo de erro (permissão vs rede vs não encontrado)`: variar texto e CTA por código; Feedback não distingue automaticamente;
  - `estado de loading após retry`: não nativo — controlar via bool em código.

- `tipo de adaptação`: componente principal + composição
- `o que precisa ser feito`:
  - Para erro inline de formulário: usar `Feedback` com Style Danger + Title + Text — direto;
  - Para erro de zona com retry: usar `Feedback` com `Closeable=false` + `ChildContent` contendo Button de retry;
  - Para erro de página: compor Box + Stack (centrado) + ícone + heading + Feedback + Button;
  - Para erro de sistema (não bloqueante): usar `NotificationService.ShowAsync(msg, Themes.Danger)`.

## Como usar

### Erro de submissão inline (mais comum)

```razor
@if (!string.IsNullOrEmpty(erroGeral))
{
    <Feedback Style="Themes.Danger" Title="Erro ao salvar"
              Text="@erroGeral" AdditionalClasses="mb-4" />
}
```

### Erro de zona com ação de retry

```razor
@if (erroCarregamento is not null)
{
    <Feedback Style="Themes.Danger" Title="Falha ao carregar os dados"
              Text="@erroCarregamento" Closeable=false>
        <Button Style="Themes.Danger" Outline=true Label="Tentar Novamente"
                OnClick="RetryCarregamento" AdditionalClasses="mt-3" />
    </Feedback>
}
```

### Erro de página (layout centrado)

```razor
@if (erroGlobal is not null)
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-8 mt-8">
        <Stack AdditionalClasses="items-center gap-4 py-6 text-center">
            @WellKnownIcons.Danger("text-4xl text-danger-400")
            <h2 class="text-xl font-semibold text-dark-600">
                @(erroGlobal.EhNotFound ? "Página não encontrada" : "Erro inesperado")
            </h2>
            <p class="text-sm text-dark-700 max-w-sm">@erroGlobal.Mensagem</p>
            <div class="flex gap-3">
                @if (erroGlobal.PodeRetry)
                {
                    <Button Style="Themes.Primary" Label="Tentar Novamente"
                            OnClick="RetryGlobal" />
                }
                <Button Style="Themes.Secondary" Outline=true Label="Voltar"
                        OnClick="Voltar" />
            </div>
        </Stack>
    </Box>
}
```

### Erro de permissão

```razor
@if (!temPermissao)
{
    <Feedback Style="Themes.Warning" Title="Acesso negado"
              Text="Você não tem permissão para realizar esta operação." />
}
```

### Erro de sistema não bloqueante (via serviço)

```razor
@code {
    [Inject] INotificationService NotificationService { get; set; } = default!;

    private async Task Salvar()
    {
        try { await service.SalvarAsync(model); }
        catch (Exception ex)
        {
            await NotificationService.ShowAsync(
                "Erro inesperado. Tente novamente.", Themes.Danger);
        }
    }
}
```

## Decisão de uso

- `nota geral`: 6;
- `limitações`: sem componente de erro de página com layout centrado e ilustração; ação de retry não é prop nativa do Feedback — inserir como filho; sem distinção automática de tipo de erro; Feedback é semanticamente para alertas, não exclusivamente para error state;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Feedback` com Style Danger cobre diretamente erro inline e de zona textual — nota 7 no componente;
  - Para erro de página com layout visual, compor Box + Stack + ícone + Button — 3-4 componentes sem CSS customizado;
  - `NotificationService` com Themes.Danger cobre erros de sistema não bloqueantes;
  - A nota 6 reflete que o erro inline é bem coberto, mas o error state completo de página requer composição manual — sem componente dedicado de "página de erro".
