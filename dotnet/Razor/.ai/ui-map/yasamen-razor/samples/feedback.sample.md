# Feedback - Sample

## Contrato de uso

**Entrada pública**: `<Feedback>` — namespace `RoyalCode.Razor.Alerts`
**Grupo**: UI-FEEDBACK
**Propósito**: Painel de feedback inline com título, texto, ícone e botão de fechar opcional. Comunica resultado, erro, aviso ou informação contextual em tela.
**Patterns**:
- `implementa`: UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-TOAST_ALERT, UIP-INPUT-VALIDATION_SUMMARY, UIP-CONTENT-CALLOUT_BLOCK
- `compõe`: UIP-SYSTEM-OFFLINE_SYNC, UIP-SYSTEM-AUTH_SESSION, UIP-SYSTEM-PERMISSION_FLOW
**Setup necessário**: `builder.Services.AddYasamenCommons()` + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: resultado de operações, alertas contextuais inline, mensagens de aviso não-bloqueantes, estado vazio de coleção, resumo de erros de validação
- **Evite quando**: feedback é temporário (auto-dismiss) — use `Notification`; para pequenos indicadores de status inline — use `Badge`
- **Cuidado**: `Block=true` é o default — o componente ocupa largura total; use `Block=false` apenas quando precisar de largura de conteúdo

## Exemplos

### `UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-ERROR_STATE` — Estado vazio e erro de coleção

Use `Style="Themes.Light"` para empty state neutro; `Themes.Danger` para erro crítico. `ChildContent` permite adicionar ação de recuperação.

```razor
@* Empty state com botão de ação *@
@if (!itens.Any() && !carregando)
{
    <Feedback Style="Themes.Light"
              Title="Nenhum resultado"
              Text="Não há itens para os filtros aplicados.">
        <ChildContent>
            <Button Style="Themes.Default" Size="Sizes.Small"
                    Label="Limpar filtros" OnClick="LimparFiltros" />
        </ChildContent>
    </Feedback>
}

@* Erro de carregamento com ação de retry *@
@if (erroCarregamento is not null)
{
    <Feedback Style="Themes.Danger"
              Title="Erro ao carregar"
              Text="@erroCarregamento"
              Closeable=true
              OnClose="() => erroCarregamento = null">
        <ChildContent>
            <Button Style="Themes.Danger" Outline=true Size="Sizes.Small"
                    Label="Tentar novamente" OnClick="Carregar" />
        </ChildContent>
    </Feedback>
}
```

**API usada**: `Style`, `Title`, `Text`, `Closeable`, `OnClose`, `ChildContent`

### `UIP-FEEDBACK-TOAST_ALERT, UIP-CONTENT-CALLOUT_BLOCK` — Alerta inline e callout informativo

`Closeable=true` para alertas dispensáveis; sem `Title` para mensagens compactas.

```razor
@* Alerta de aviso com fechamento *@
@if (mostrarAviso)
{
    <Feedback Style="Themes.Warning"
              Text="Esta ação enviará e-mails para todos os usuários ativos."
              Closeable=true
              OnClose="() => mostrarAviso = false"
              AdditionalClasses="mb-6" />
}

@* Callout informativo em seção de conteúdo *@
<Feedback Style="Themes.Info"
          Title="Sobre a cobrança"
          Text="O valor será debitado somente após a confirmação do pedido.
                Cancelamentos até 24h antes não geram cobrança." />

@* Confirmação de operação bem-sucedida *@
<Feedback Style="Themes.Success"
          Title="Configurações salvas"
          Text="As alterações foram aplicadas e estão em vigor."
          Closeable=true />
```

**API usada**: `Style`, `Title`, `Text`, `Closeable`, `OnClose`, `AdditionalClasses`

### `UIP-INPUT-VALIDATION_SUMMARY` — Resumo de erros de validação em formulário

Use dentro de `EditForm` acima ou abaixo dos campos para resumir erros de submissão.

```razor
@code {
    private string? erroSubmissao;

    private async Task Submeter()
    {
        erroSubmissao = null;
        try { await Service.SalvarAsync(model); }
        catch (ValidationException ex) { erroSubmissao = ex.Message; }
    }
}

<EditForm Model="model" OnValidSubmit="Submeter">
    <DataAnnotationsValidator />

    @if (erroSubmissao is not null)
    {
        <Feedback Style="Themes.Danger"
                  Title="Erro de validação"
                  Text="@erroSubmissao"
                  AdditionalClasses="mb-4" />
    }

    <TextField @bind-Value="model.Nome" Label="Nome" required />
    <TextField @bind-Value="model.Email" Label="E-mail" required />

    <Bar AdditionalClasses="mt-4">
        <EndContent>
            <Button Style="Themes.Primary" Label="Salvar" Type="ButtonTypes.Submit" />
        </EndContent>
    </Bar>
</EditForm>
```

### `UIP-SYSTEM-OFFLINE_SYNC, UIP-SYSTEM-AUTH_SESSION, UIP-SYSTEM-PERMISSION_FLOW` — Feedback de estados de sistema

Contextos de sistema onde Feedback comunica estado operacional crítico.

```razor
@* Offline sync — banner de aviso de conectividade *@
@if (!online)
{
    <Feedback Style="Themes.Warning"
              Text="Sem conexão. As alterações serão sincronizadas ao reconectar."
              Block=true />
}

@* Auth session — sessão expirada *@
@if (sessaoExpirada)
{
    <Feedback Style="Themes.Danger"
              Title="Sessão expirada"
              Text="Sua sessão expirou por inatividade. Faça login novamente.">
        <ChildContent>
            <Button Style="Themes.Primary" Label="Fazer login"
                    NavigateTo="/login" />
        </ChildContent>
    </Feedback>
}

@* Permission flow — acesso negado *@
@if (!temPermissao)
{
    <Feedback Style="Themes.Warning"
              Title="Acesso restrito"
              Text="Você não tem permissão para acessar esta seção. Contate o administrador." />
}
```

## API relevante

| Parâmetro | Tipo | Default | Uso |
|---|---|---|---|
| `Title` | `string?` | null | Título (tag h varia com Size) |
| `Text` | `string?` | null | Texto descritivo |
| `Style` | `Themes` | — | Cor semântica |
| `Size` | `Sizes` | Medium | Tamanho geral (afeta heading e padding) |
| `Icon` | `Enum?` | null | Ícone customizado (substituí ícone automático de tema) |
| `Closeable` | `bool` | false | Exibe botão fechar |
| `OnClose` | `EventCallback` | — | Callback ao clicar em fechar |
| `Block` | `bool` | **true** | Largura total (w-full) |
| `ChildContent` | `RenderFragment?` | null | Conteúdo adicional (ex: botão de ação) |

## Defaults importantes

- `Block` default `true`: Feedback sempre ocupa 100% da largura do container por default — use `Block=false` apenas para feedback inline pequeno
- Fechar via `Closeable=true` é estado local interno (`closed`); para controlar externamente, use `@if` em volta do componente com `OnClose` que muda o estado externo
