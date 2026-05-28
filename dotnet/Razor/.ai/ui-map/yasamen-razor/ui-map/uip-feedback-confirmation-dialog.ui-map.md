# UIP-FEEDBACK-CONFIRMATION_DIALOG - Confirmation Dialog

## Componentes

**Principais**:

1. Modal
- `cobertura`: overlay bloqueante com fases de abertura/fechamento (opening-start → opening → open → closing → closed); z-index 1070 acima de todo conteúdo; backdrop overlay; slide-down + fade de entrada; `ModalService` via DI para controle programático; `ModalHandler` para controle via referência; suporta título, conteúdo e rodapé (slots via ChildContent/HeaderContent/FooterContent — [inferido]); centralizado (ya-modal-center) ou posicionado; acesso via `@ref` + Open()/Close() ou via `ModalService`;
- `limitações`: sem prop dedicada de `Title` como no AsideBox — título deve ser inserido como ChildContent ou HeaderContent [inferido]; sem ação de confirmação integrada como prop — botões de confirmar/cancelar são filhos; sem estado de "processando" nativo após confirmar — controlar via Disabled no botão;
- `nota`: 9;
- `justificativa`: cobertura nativa excelente de diálogo de confirmação bloqueante — overlay, fases, z-index correto, controle programático.

**Composição**:

1. Button (Themes.Danger / Primary)
- `cobertura`: ação de confirmação do diálogo;
- `limitações`: sem estado "processando" nativo — controlar via `Disabled=true` + `IconAnimation` para loading;
- `nota`: 9;
- `justificativa`: ação de confirmação com feedback visual de estado.

2. Button (Themes.Secondary, Outline)
- `cobertura`: ação de cancelamento do diálogo;
- `limitações`: nenhuma;
- `nota`: 9;
- `justificativa`: cancelamento com hierarquia visual correta (outline para ação secundária).

3. Bar
- `cobertura`: organiza botões de confirmação e cancelamento no footer do modal com distribuição Start/End;
- `limitações`: requer que o Modal forneça slot de footer — comportamento exato depende da API do Modal [inferido];
- `nota`: 7;
- `justificativa`: bom para organizar o footer de ações do modal.

**Descartados**:

1. Feedback
- `motivo`: não bloqueia a interface — inadequado para confirmação que exige decisão explícita.

2. Notification
- `motivo`: não bloqueante e temporário — o oposto do que confirmation dialog exige.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `título do modal`: não confirmado como prop dedicada — inserir heading HTML no conteúdo [pode existir como parâmetro não documentado nos artefatos lidos];
  - `estado de processando após confirmar`: não nativo — usar `Disabled=@processando` + `IconAnimation` no botão de confirmação;
  - `confirmação digitada (tipo-para-confirmar)`: sem suporte nativo — compor `FieldText` dentro do Modal para capturar input de confirmação.

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Declarar `<Modal @ref="modal">` com conteúdo de texto + botões no footer;
  - Botão de confirmação com Style Danger (destrutivo) ou Primary (não destrutivo);
  - Botão de cancelamento com Style Secondary Outline;
  - Para estado de processando: `Disabled="@confirmando"` + `IconAnimation="@(confirmando ? Spinning : null)"` no botão de confirmação;
  - Para confirmação digitada: inserir `FieldText` com binding + validação de valor esperado antes de habilitar confirmação.

## Como usar

### Confirmação destrutiva (deletar)

```razor
<Modal @ref="modalDelete">
    <p class="text-dark-600">
        Tem certeza que deseja excluir <strong>@nomeItem</strong>?
        Esta ação não pode ser desfeita.
    </p>
    <div class="flex justify-end gap-3 mt-6">
        <Button Style="Themes.Secondary" Outline=true Label="Cancelar"
                OnClick="() => modalDelete.Close()" />
        <Button Style="Themes.Danger" Label="Excluir"
                Disabled="@excluindo"
                IconAnimation="@(excluindo ? Spinning : null)"
                Icon="WellKnownIcons.TrashIcon"
                OnClick="ConfirmarExclusao" />
    </div>
</Modal>

@* Abertura do modal ao clicar em excluir *@
<IconButton Style="Themes.Danger" Icon="WellKnownIcons.TrashIcon"
            OnClick="() => { nomeItem = item.Nome; itemId = item.Id; modalDelete.Open(); }" />

@code {
    private Modal modalDelete = default!;
    private bool excluindo = false;
    private AnimationFragment Spinning =>
        content => @<RotationMotion>@content</RotationMotion>;

    private async Task ConfirmarExclusao()
    {
        excluindo = true;
        try
        {
            await service.ExcluirAsync(itemId);
            modalDelete.Close();
            await NotificationService.ShowAsync("Registro excluído.", Themes.Success);
        }
        catch
        {
            await NotificationService.ShowAsync("Falha ao excluir. Tente novamente.", Themes.Danger);
        }
        finally { excluindo = false; }
    }
}
```

### Confirmação não destrutiva (publicar)

```razor
<Modal @ref="modalPublicar">
    <h3 class="text-lg font-semibold text-dark-600 mb-3">Publicar registro</h3>
    <p class="text-sm text-dark-600">
        Este registro será visível para todos os usuários após a publicação.
        Deseja continuar?
    </p>
    <div class="flex justify-end gap-3 mt-6">
        <Button Style="Themes.Secondary" Outline=true Label="Cancelar"
                OnClick="() => modalPublicar.Close()" />
        <Button Style="Themes.Primary" Label="Publicar"
                OnClick="ConfirmarPublicacao" />
    </div>
</Modal>
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: título do modal como prop não confirmado — inserir heading HTML no conteúdo; estado de processando não é prop nativa — controlar via Disabled+IconAnimation; confirmação digitada requer FieldText como filho; API exata do Modal (slots de header/footer) parcialmente inferida dos artefatos lidos;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `Modal` é o componente nativo da biblioteca para overlay bloqueante — fases, z-index 1070, backdrop, slide-down + fade, controle programático via handler;
  - Para diálogo de confirmação, basta declarar o `Modal` com texto de impacto + Button Danger (confirmar) + Button Secondary Outline (cancelar);
  - Nota 9 porque a cobertura é nativa e completa; as únicas lacunas são título sem prop dedicada e estado de processando sem gerenciamento automático — ambos resolvíveis com 1-2 linhas adicionais.
