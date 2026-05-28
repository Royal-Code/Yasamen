# UIP-CONTENT-CALLOUT_BLOCK - Callout Block

## Componentes

**Principais**:

1. Feedback
- `cobertura`: bloco persistente de orientação contextual com tema semântico (`Info`, `Warning`, `Danger`, `Success`, `Light`); `Text` para mensagem curta; `ChildContent` para conteúdo mais rico (parágrafo + ação); ícone automático por tema; fundo colorido com borda lateral;
- `limitações`: sem ação inline nativa integrada ao componente; sem variante de "tip" ou "note" com visual de caderno;
- `nota`: 9;
- `justificativa`: cobertura nativa completa do callout block — semântica correta, visual adequado, temas por severidade.

**Composição**:

1. Button (dentro do Feedback via ChildContent)
- `cobertura`: ação secundária dentro do callout (ex: "Saiba mais", "Desfazer", "Documentação");
- `nota`: 8;
- `justificativa`: ação contextual associada ao callout.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `callout dispensável (dismissible)`: sem nativo — estado `bool visivel` + `IconButton X`;
  - `callout com link externo`: usar `<a>` dentro de `ChildContent`;
  - `callout lateral (aside)`: posicionamento com `float` ou grid CSS — não nativo.

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Usar `Feedback` com o tema correto para a severidade/intenção do callout;
  - `Text` para mensagem curta; `ChildContent` para callout com ação ou conteúdo estruturado;
  - Posicionar no fluxo da tela próximo à seção afetada.

## Como usar

### Callout informativo

```razor
<Feedback Style="Themes.Info"
          Text="Esta operação será processada em lote durante a próxima janela de manutenção." />
```

### Callout de aviso com ação

```razor
<Feedback Style="Themes.Warning" AdditionalClasses="mb-4">
    <ChildContent>
        <p class="text-sm">
            Este cliente possui 3 faturas em atraso. Revise antes de prosseguir com o pedido.
        </p>
        <Button Style="Themes.Warning" Outline=true Size="Sizes.Small"
                Label="Ver faturas em atraso" NavigateTo="@($"/clientes/{clienteId}/faturas")"
                AdditionalClasses="mt-2" />
    </ChildContent>
</Feedback>
```

### Callout de bloqueio parcial

```razor
<Feedback Style="Themes.Danger"
          Text="Você não tem permissão para alterar o status deste pedido. Contate o administrador." />
```

### Callout de sucesso contextual

```razor
<Feedback Style="Themes.Success"
          Text="Integração com o ERP configurada corretamente. Os dados serão sincronizados a cada 15 minutos." />
```

### Callout dispensável

```razor
@if (mostrarCallout)
{
    <Feedback Style="Themes.Info" AdditionalClasses="mb-4">
        <ChildContent>
            <div class="flex items-start justify-between gap-2">
                <p class="text-sm">
                    Dica: você pode arrastar colunas para reordenar a visualização da tabela.
                </p>
                <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                            Size="Sizes.Small"
                            OnClick="() => mostrarCallout = false" />
            </div>
        </ChildContent>
    </Feedback>
}
```

## Decisão de uso

- `nota geral`: 8;
- `limitações`: sem dismissible nativo; sem variante de "note/tip" com visual de caderno; ação integrada requer ChildContent manual;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `Feedback` cobre nativamente callout block em todas as variantes de severidade;
  - `ChildContent` permite enriquecer com texto estruturado e ações;
  - Nota 8 reflete cobertura nativa excelente com apenas dismissible não automático.
