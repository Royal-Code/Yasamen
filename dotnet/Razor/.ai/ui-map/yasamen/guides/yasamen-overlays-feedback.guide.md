# Yasamen Overlays And Feedback Guide

## Objetivo
Orientar a IA a usar modal, offcanvas e notificações globais com os serviços, outlets e handlers próprios do Yasamen.

## Quando usar
Use este guide ao gerar:
- Modal de confirmação, edição, detalhe ou decisão bloqueante.
- Offcanvas lateral para menu, filtros, favoritos, ações contextuais ou painel auxiliar.
- Notificação global, toast, feedback de sucesso, erro, alerta ou aviso.
- Tela que use `Notify`, `ModalHandler`, `OffCanvasHandler`, `Modal`, `OffCanvas` ou `Notification`.

## Decisão corporativa
Overlays e feedback no Yasamen devem ser controlados por serviços registrados no DI e por handlers estáveis no componente. Telas devem preferir `AppLayout`/`AppMainLayout` porque eles já renderizam `ModalOutlet`, `OffCanvasOutlet` e `NotificationOutlet`. Notificações globais devem usar o serviço `Notify`; notificações inline podem usar componentes de notificação.

## Regras
- Registre `AddYasamenModal()` antes de usar `Modal` ou `ModalHandler`.
- Registre `AddYasamenOffCanvas()` antes de usar `OffCanvas` ou `OffCanvasHandler`.
- Registre `AddYasamenNotification()` antes de injetar `Notify` ou depender de `NotificationOutlet`.
- Use `AppLayout` ou `AppMainLayout` para telas com overlays; `AppLayout` inclui os outlets internos de modal, offcanvas e notificação.
- Para modal, defina sempre `Id`; o componente lança exceção quando `Id` está vazio.
- Para modal controlado por código, crie `private readonly ModalHandler handler = new();`, passe em `Handler` e abra com `await handler.OpenAsync()`.
- Não chame `ModalHandler.OpenAsync()` antes do `Modal` existir no render tree; o handler lança `InvalidOperationException` quando `Modal` ainda não foi associado.
- Quando fornecer `Handler` para `Modal`, reutilize a mesma instância para a mesma modal; trocar handler durante a vida do componente é inválido.
- Use `Closeable="false"` apenas quando a decisão for realmente bloqueante; por padrão, modal é fechável e centralizada.
- Para offcanvas, crie `private readonly OffCanvasHandler handler = new();`, passe em `Handler` e controle com `Toggle()`, `Show()` ou `Hide()`.
- `OffCanvasHandler.Show()` e `Hide()` ignoram chamadas se ainda não houver offcanvas associado; a IA não deve depender disso para fluxo crítico antes do primeiro render.
- Use `Position="Positions.Start"` para menus/painéis de navegação e `Positions.End` para painéis auxiliares de contexto quando fizer sentido visual.
- Use `CloseOffCanvasButton` dentro de offcanvas quando o painel deve ser fechado pelo usuário.
- Para feedback global, injete `Notify` e use `Notify.Success`, `Notify.Warning`, `Notify.Danger`, `Notify.Info` ou `Notify.ShowAsync(...)`.
- Use `Themes.Success` para operação concluída, `Themes.Warning` para atenção não bloqueante, `Themes.Danger` para erro crítico, `Themes.Alert` para alerta e `Themes.Info` para informação.
- Quando precisar controlar posição da notificação global, use o callback `configure` de `Notify.ShowAsync` e defina `Placement`.
- Não use `NotificationGroup` manual para feedback global simples; use o serviço `Notify`.

## Exemplos / Passo-a-passo

### Modal de confirmação

```razor
<Button Label="Excluir" Style="Themes.Danger" OnClick="OpenDeleteModal" />

<Modal Id="delete-customer-modal" Handler="deleteModal" Center="true">
    <Box AdditionalClasses="p-6 bg-white">
        <h2>Excluir cliente</h2>
        <p>Confirme a exclusão deste cliente.</p>
        <div class="flex justify-end gap-3 mt-6">
            <Button Label="Cancelar" Style="Themes.Secondary" OnClick="CloseDeleteModal" />
            <Button Label="Excluir" Style="Themes.Danger" OnClick="DeleteCustomerAsync" />
        </div>
    </Box>
</Modal>

@code {
    private readonly ModalHandler deleteModal = new();

    private Task OpenDeleteModal() => deleteModal.OpenAsync();

    private Task CloseDeleteModal() => deleteModal.CloseAsync();
}
```

### Offcanvas de filtros

```razor
<IconButton IconFragment="@WellKnownIcons.Filter" title="Filtros" OnClick="ToggleFilters" />

<OffCanvas Position="Positions.End" Handler="filtersHandler" Title="Filtros">
    <div class="p-4">
        <CloseOffCanvasButton />
        <TextField Label="Nome" @bind-Value="filterName" Placeholder="Filtrar por nome" />
    </div>
</OffCanvas>

@code {
    private readonly OffCanvasHandler filtersHandler = new();
    private string filterName = string.Empty;

    private async Task ToggleFilters()
    {
        await filtersHandler.Toggle();
    }
}
```

### Notificação global por serviço

```razor
@inject Notify Notify

<Button Label="Salvar" Style="Themes.Primary" OnClick="SaveAsync" />

@code {
    private async Task SaveAsync()
    {
        await Notify.Success(
            "Registro salvo",
            "As alterações foram persistidas com sucesso.");
    }
}
```

### Notificação global com posição

```razor
@inject Notify Notify

@code {
    private Task ShowErrorAsync()
    {
        return Notify.ShowAsync(
            Themes.Danger,
            "Falha ao salvar",
            "Revise os campos destacados e tente novamente.",
            item => item.Placement = Placements.TopEnd);
    }
}
```

## Anti-padrões
- Não abrir modal sem `Id`.
- Não criar `new ModalHandler()` ou `new OffCanvasHandler()` dentro do markup.
- Não trocar a instância de `ModalHandler` para a mesma modal depois do primeiro render.
- Não usar modal para filtros laterais; use offcanvas.
- Não usar offcanvas para decisão bloqueante que exige confirmação explícita; use modal.
- Não renderizar notificações globais criando manualmente `NotificationService`; injete `Notify`.
- Não gerar feedback visual silencioso; toda operação assíncrona de salvar, excluir ou falhar deve ter feedback claro quando a tela não muda de forma óbvia.

## Fontes
- `RoyalCode.Razor.Modals/Extensions/ModalServiceCollectionExtensions.cs`
- `RoyalCode.Razor.Modals/Components/Modal.razor`
- `RoyalCode.Razor.Modals/Components/ModalHandler.cs`
- `RoyalCode.Razor.Modals/Internal/Modals/ModalOutlet.razor`
- `RoyalCode.Razor.OffCanvas/Extensions/OffCanvasServiceCollectionExtensions.cs`
- `RoyalCode.Razor.OffCanvas/Components/OffCanvas.razor`
- `RoyalCode.Razor.OffCanvas/Components/OffCanvasHandler.cs`
- `RoyalCode.Razor.OffCanvas/Internal/OffCanvas/OffCanvasOutlet.razor`
- `RoyalCode.Razor.Alerts/Extensions/AlertServiceCollectionExtensions.cs`
- `RoyalCode.Razor.Alerts/Components/Notify.cs`
- `RoyalCode.Razor.Alerts/Internal/Notifications/NotificationOutlet.razor`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Pages/Demo/NotificationsPage.razor`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`
