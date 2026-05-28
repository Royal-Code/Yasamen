# UIP-FEEDBACK-TOAST_ALERT - Toast / Alert

## Componentes

**Principais**:

1. Notification (via NotificationService)
- `cobertura`: toast flutuante não bloqueante com 9 posições de grupo configuráveis; auto-fechável via timer com animação visual (scaleX barra de progresso); ícone colorido lateral (bg-400); borda lateral colorida por tema; suporte a todos os temas semânticos; empilhável (N notificações simultâneas); slide + fade de entrada/saída; conteúdo personalizado via ChildContent; acesso via injeção de `INotificationService` ou `NotificationService`; fechar manual via botão × nativo;
- `limitações`: sem ação de undo integrada como API (mas CTA pode ser filho do ChildContent); sem duração configurável por chamada de API direta — [inferido: duração pode ser via propriedade/parâmetro do Notification]; sem suporte explícito a notificação persistente que não feche sozinha sem intervenção (fechar manual via × ainda está disponível);
- `nota`: 9;
- `justificativa`: cobertura nativa excelente do toast — posições, temas semânticos, animações, empilhamento, auto-fechamento e ícone lateral.

2. Feedback
- `cobertura`: alert inline ou contextual persistente; título + texto + tema semântico; `Closeable=true` para alert dispensável; `Block=true` para largura total; adequado para alertas de zona, banners de aviso e erros contextuais;
- `limitações`: sem posicionamento de toast (não flutua); sem animação de entrada/saída; persistente por padrão (sem auto-fechamento); sem ícone de sistema nativo diferenciado por tipo;
- `nota`: 8;
- `justificativa`: cobre bem o alert inline e persistente; não tem comportamento de toast temporário.

**Composição**: nenhuma adicional necessária para os casos de uso principais.

**Descartados**:

1. Modal
- `motivo`: bloqueia a interface — oposto do padrão não bloqueante do toast/alert.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `undo inline no toast`: ação de undo não tem API dedicada — inserir Button no ChildContent da Notification;
  - `duração configurável por chamada`: duração padrão é via CSS animation — não confirmada via API pública [inferido: parâmetro Timer ou Duration pode existir];
  - `toast persistente (não fecha sozinho)`: fechar manual via × está disponível; para persistência sem fechamento automático, [inferido: desativar timer via propriedade].

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Para toast de resultado de ação: injetar `INotificationService` e chamar com tema semântico;
  - Para alert inline contextual: usar `<Feedback Style="Themes.*" Title="..." Text="..." />`;
  - Para toast com undo: colocar `Button` no `ChildContent` da `Notification`;
  - Para banner persistente de aviso: usar `Feedback` com `Closeable=false`.

## Como usar

### Toast de sucesso (mais comum)

```razor
@code {
    [Inject] INotificationService NotificationService { get; set; } = default!;

    private async Task Salvar()
    {
        await service.SalvarAsync(model);
        await NotificationService.ShowAsync("Registro salvo com sucesso.", Themes.Success);
    }
}
```

### Toast de erro de sistema (não bloqueante)

```razor
await NotificationService.ShowAsync("Erro de comunicação. Tente novamente.", Themes.Danger);
```

### Toast de aviso

```razor
await NotificationService.ShowAsync("Sessão expirando em 5 minutos.", Themes.Warning);
```

### Alert inline contextual persistente

```razor
@if (avisoAtivo)
{
    <Feedback Style="Themes.Warning" Title="Atenção" Closeable=true
              Text="Este módulo está em manutenção. Algumas funções podem estar indisponíveis."
              AdditionalClasses="mb-4" />
}
```

### Alert de erro de zona (persistente, sem fechar)

```razor
@if (!string.IsNullOrEmpty(erroZona))
{
    <Feedback Style="Themes.Danger" Title="Erro ao carregar" Text="@erroZona"
              Closeable=false AdditionalClasses="mb-4" />
}
```

### Banner informativo de cabeçalho

```razor
@if (sistemaEmManutencao)
{
    <Feedback Style="Themes.Info" Title="Manutenção programada"
              Text="O sistema estará em manutenção amanhã das 22h às 02h."
              AdditionalClasses="mb-6" />
}
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: ação de undo no toast requer Button em ChildContent (não é prop dedicada); duração configurável não confirmada via API pública; sem toast persistente sem timer por API declarativa — workaround via fechar manual;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `Notification` via `NotificationService` entrega cobertura nativa completa do toast: 9 posições, todos os temas semânticos, animação de entrada/saída, empilhamento, auto-fechamento com barra de timer visual, ícone lateral;
  - `Feedback` cobre o alert inline persistente com título, texto, closeable e ChildContent;
  - Juntos cobrem 100% dos cenários do pattern: toast temporário pós-ação, alert contextual persistente, banner de aviso global, erro não bloqueante de sistema;
  - Nota 9 justificada — dois componentes nativos cobrem todos os sub-tipos do pattern sem composição adicional.
