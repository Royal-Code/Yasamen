# Modal - Sample

## Visão geral
- **Propósito**: modal programático com handler, centro, closeable e eventos.
- **Complexidade**: 7
- **Patterns cobertos**: UIP-FEEDBACK-CONFIRMATION_DIALOG, PP-FORM, SHP-WORKSPACE_ADMIN
- **Variações demonstradas**: abrir/fechar, confirmação, modal não closeable.

## Exemplos

### UIP-FEEDBACK-CONFIRMATION_DIALOG

**Objetivo**: confirmação de ação destrutiva.

```razor
<Button Label="Excluir" Style="Themes.Danger" OnClick="@(async _ => await confirm.OpenAsync())" />

<Modal Id="delete-confirm" Handler="confirm">
    <Box AdditionalClasses="p-6 bg-white rounded-md space-y-4">
        <Feedback Style="Themes.Warning" Title="Confirmar exclusão" Text="Esta ação não pode ser desfeita." />
        <ButtonGroup>
            <Button Label="Cancelar" Style="Themes.Light" OnClick="@(async _ => await confirm.CloseAsync())" />
            <Button Label="Excluir" Style="Themes.Danger" />
        </ButtonGroup>
    </Box>
</Modal>

@code {
    private readonly ModalHandler confirm = new();
}
```

**Props usadas**: `Id`, `Handler`, `ChildContent`.  
**Eventos relevantes**: métodos do `ModalHandler`.  
**Por que atende o pattern**: bloqueia a tarefa até decisão explícita.

### Modal de formulário

**Objetivo**: edição curta em overlay.

```razor
<Button Label="Editar" OnClick="@(async _ => await edit.OpenAsync())" />
<Modal Id="edit-modal" Handler="edit" Center="true">
    <Box AdditionalClasses="p-6 bg-white rounded-md space-y-4">
        <TextField Label="Nome" @bind-Value="name" />
        <Button Label="Salvar" Style="Themes.Primary" />
    </Box>
</Modal>

@code {
    private readonly ModalHandler edit = new();
    private string name = string.Empty;
}
```

**Props usadas**: `Center`, `Handler`.  
**Eventos relevantes**: handler.  
**Por que atende o pattern**: permite foco temporário para edição curta.

### Modal não fechável

**Objetivo**: impedir fechamento por decisão externa.

```razor
<Modal Id="blocking-modal" Handler="blocking" Closeable="false">
    <Box AdditionalClasses="p-6 bg-white rounded-md">
        <Feedback Style="Themes.Info" Text="Processando operação crítica." />
    </Box>
</Modal>

@code {
    private readonly ModalHandler blocking = new();
}
```

**Props usadas**: `Closeable`.  
**Eventos relevantes**: `OnOpenClose` disponível.  
**Por que atende o pattern**: preserva bloqueio quando a operação exige.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Id` | `string` | sempre | identidade do modal |
| `Handler` | `ModalHandler?` | controle externo | abrir/fechar |
| `Closeable` | `bool` | bloquear fechamento | backdrop/escape |
| `Center` | `bool` | alinhamento | centro ou padrão |
| `OnOpenClose` | `EventCallback<ModalEventArgs>` | observar estado | eventos |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnOpenClose` | abertura/fechamento | sincronizar estado |

## Limitações
- Não há componente pronto de confirmação com resultado.

## Combinações frágeis
- Conteúdo sem superfície branca pode perder legibilidade sobre backdrop.
