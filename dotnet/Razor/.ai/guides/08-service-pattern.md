# Guide 08 — Padrão Service + Outlet

> Como funciona o padrão de sobreposições globais (Notifications, Modals, OffCanvas). Como criar novos pares Service+Outlet.

---

## Conceito

Componentes "globais" (toasts, modais, painéis laterais) não podem ser instanciados onde são invocados — eles precisam renderizar no topo da árvore DOM. O padrão usado é:

```
Service (Scoped DI)
  ├── mantém estado (lista de items, se está aberto, etc.)
  ├── notifica Outlet via evento/action
  └── API pública para abrir/fechar/adicionar

Outlet (.razor — fica no AppLayout ou em App.razor)
  ├── injeta o Service
  ├── subscreve os eventos dele
  └── renderiza o markup baseado no estado

Consumer (qualquer componente)
  └── injeta o Service e chama a API
```

Cada par usa `SectionOutlet`/`SectionContent` do Blazor para renderizar no lugar correto (do AppLayout para dentro do componente).

---

## Padrão de Notificações

### `NotificationService` (estado interno)

```csharp
public class NotificationService
{
    private readonly List<NotificationEntry> entries = new();
    internal event Action? OnChange;

    internal IReadOnlyList<NotificationEntry> Entries => entries;

    internal void Add(NotificationEntry entry)
    {
        entries.Add(entry);
        OnChange?.Invoke();
    }

    internal void Remove(NotificationEntry entry)
    {
        entries.Remove(entry);
        OnChange?.Invoke();
    }
}
```

### `Notify` (API pública)

```csharp
// Scoped — é o que os consumidores injetam
public class Notify
{
    private readonly NotificationService service;

    public Notify(NotificationService service)
    {
        this.service = service;
    }

    public void Success(string message, string? title = null)
        => service.Add(new NotificationEntry(message, title, Themes.Success));

    public void Error(string message, string? title = null)
        => service.Add(new NotificationEntry(message, title, Themes.Danger));

    public void Warning(string message, string? title = null)
        => service.Add(new NotificationEntry(message, title, Themes.Warning));

    public void Info(string message, string? title = null)
        => service.Add(new NotificationEntry(message, title, Themes.Info));
}
```

### `NotificationOutlet.razor`

```razor
@inject NotificationService Service
@implements IDisposable

@foreach (var entry in Service.Entries)
{
    <Notification @key="entry" Entry="@entry" OnDismiss="@(() => Service.Remove(entry))" />
}

@code {
    protected override void OnInitialized()
    {
        Service.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        Service.OnChange -= StateHasChanged;
    }
}
```

### Registro DI

```csharp
// AlertServiceCollectionExtensions.cs
namespace Microsoft.Extensions.DependencyInjection;

public static class AlertServiceCollectionExtensions
{
    public static IServiceCollection AddYasamenNotification(
        this IServiceCollection services)
    {
        services.AddScoped<NotificationService>();
        services.AddScoped<Notify>();
        return services;
    }
}
```

### Uso no AppLayout

```razor
@* MainLayout.razor *@
<div class="ya-app-layout">
    @Body
</div>

<NotificationOutlet />
```

### Uso no Consumer

```razor
@inject Notify Notify

<Button Label="Salvar" OnClick="@Save" />

@code {
    async Task Save()
    {
        await DataService.SaveAsync();
        Notify.Success("Salvo com sucesso!");
    }
}
```

---

## Padrão de Modal

### `ModalHandler` (controle de uma modal)

```csharp
// Criado pelo consumer e passado para Modal
public class ModalHandler
{
    internal event Action<bool>? OnVisiblityChange;

    public bool IsOpen { get; private set; }

    public void Open()
    {
        IsOpen = true;
        OnVisiblityChange?.Invoke(true);
    }

    public void Close()
    {
        IsOpen = false;
        OnVisiblityChange?.Invoke(false);
    }
}
```

### `Modal.razor` (o componente)

```razor
@if (State.IsVisible)
{
    <div class="ya-modal-backdrop" @onclick="HandleBackdropClick">
        <div class="ya-modal @Classes" @onclick:stopPropagation>
            @if (Header.IsNotEmptyFragment())
            {
                <div class="ya-modal-header">
                    @Header
                    <button class="ya-modal-close" @onclick="() => Handler?.Close()">
                        <Icon Kind="WellKnownIcons.Close" />
                    </button>
                </div>
            }
            <div class="ya-modal-body">
                @ChildContent
            </div>
            @if (Footer.IsNotEmptyFragment())
            {
                <div class="ya-modal-footer">
                    @Footer
                </div>
            }
        </div>
    </div>
}

@code {
    [Parameter, EditorRequired]
    public ModalHandler? Handler { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public RenderFragment Header { get; set; } = EmptyFragment.Delegate;

    [Parameter]
    public RenderFragment Footer { get; set; } = EmptyFragment.Delegate;

    [Parameter]
    public bool CloseOnBackdrop { get; set; } = true;

    [Parameter]
    public string? AdditionalClasses { get; set; }

    private VisibleState State { get; } = new();

    protected override void OnParametersSet()
    {
        if (Handler is not null)
            Handler.OnVisiblityChange += OnVisibilityChange;
    }

    private void OnVisibilityChange(bool visible)
    {
        if (visible) State.Show(); else State.Hide();
        StateHasChanged();
    }

    private void HandleBackdropClick()
    {
        if (CloseOnBackdrop)
            Handler?.Close();
    }

    private string Classes => "ya-modal-content"
        .AddClass(AdditionalClasses);
}
```

### Uso no Consumer

```razor
@code {
    private readonly ModalHandler editModal = new();
}

<Button Label="Editar" OnClick="editModal.Open" />

<Modal Handler="editModal">
    <Header>Editar Item</Header>
    <ChildContent>
        <EditForm Model="@item" OnValidSubmit="Save">
            <TextField @bind-Value="item.Name" Label="Nome" />
            <Button Type="ButtonTypes.Submit" Label="Salvar" />
        </EditForm>
    </ChildContent>
    <Footer>
        <Button Label="Cancelar" OnClick="editModal.Close" />
    </Footer>
</Modal>
```

---

## Padrão de OffCanvas

### `OffCanvasHandler` (controle do painel)

```csharp
public class OffCanvasHandler
{
    internal event Action<bool>? OnVisibilityChange;

    public bool IsVisible { get; private set; }

    public void Show()
    {
        IsVisible = true;
        OnVisibilityChange?.Invoke(true);
    }

    public void Hide()
    {
        IsVisible = false;
        OnVisibilityChange?.Invoke(false);
    }

    public void Toggle()
    {
        if (IsVisible) Hide(); else Show();
    }
}
```

### `OffCanvas.razor` (o componente)

```razor
<div class="ya-offcanvas @PositionClass @VisibilityClass" 
     @onclick:stopPropagation="true">
    @if (Header.IsNotEmptyFragment())
    {
        <div class="ya-offcanvas-header">
            @Header
            <CloseOffCanvasButton Handler="@Handler" />
        </div>
    }
    <div class="ya-offcanvas-body">
        @ChildContent
    </div>
</div>

@if (State.IsVisible)
{
    <div class="ya-offcanvas-backdrop" @onclick="HandleBackdropClick" />
}

@code {
    [Parameter, EditorRequired]
    public OffCanvasHandler? Handler { get; set; }

    [Parameter]
    public OffCanvasPositions Position { get; set; } = OffCanvasPositions.End;

    [Parameter]
    public bool CloseOnBackdrop { get; set; } = true;

    [Parameter]
    public RenderFragment Header { get; set; } = EmptyFragment.Delegate;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private VisibleState State { get; } = new();

    private string PositionClass => Position switch
    {
        OffCanvasPositions.Start => "ya-offcanvas-start",
        OffCanvasPositions.Top   => "ya-offcanvas-top",
        OffCanvasPositions.Bottom => "ya-offcanvas-bottom",
        _ => "ya-offcanvas-end"
    };

    private string VisibilityClass => State.IsVisible ? "ya-offcanvas-show" : "";

    protected override void OnParametersSet()
    {
        if (Handler is not null)
            Handler.OnVisibilityChange += OnVisibilityChange;
    }

    private void OnVisibilityChange(bool visible)
    {
        if (visible) State.Show(); else State.Hide();
        StateHasChanged();
    }

    private void HandleBackdropClick()
    {
        if (CloseOnBackdrop)
            Handler?.Hide();
    }
}
```

### Uso no Consumer

```razor
@code {
    private readonly OffCanvasHandler filterPanel = new();
}

<Button Label="Filtros" OnClick="filterPanel.Show" />

<OffCanvas Handler="filterPanel" Position="OffCanvasPositions.End">
    <Header>Filtros</Header>
    <ChildContent>
        <TextField @bind-Value="filter.Name" Label="Nome" />
        <Button Label="Aplicar" OnClick="ApplyFilter" />
    </ChildContent>
</OffCanvas>
```

---

## `AsideBox` — Painel Lateral Persistente

`AsideBox` é diferente: ele **não** usa Handler. É uma div lateral sempre presente no layout, controlada pelo AppLayout:

```razor
<AsideBox Position="OffCanvasPositions.End"
          Title="Propriedades"
          Visible="@showProperties">
    @* conteúdo sempre montado *@
</AsideBox>
```

---

## Como Criar um Novo Par Service + Outlet

### 1. Criar o entry/state model

```csharp
// ToastEntry.cs (ou qualquer nome)
internal sealed class ToastEntry
{
    public string Message { get; init; } = "";
    public Themes Theme { get; init; } = Themes.Info;
    public int Duration { get; init; } = 5000; // ms
}
```

### 2. Criar o Service interno

```csharp
// ToastService.cs (internal)
internal sealed class ToastService
{
    private readonly List<ToastEntry> items = new();
    internal event Action? Changed;
    internal IReadOnlyList<ToastEntry> Items => items;

    internal void Push(ToastEntry entry)
    {
        items.Add(entry);
        Changed?.Invoke();
    }

    internal void Dismiss(ToastEntry entry)
    {
        items.Remove(entry);
        Changed?.Invoke();
    }
}
```

### 3. Criar a API pública

```csharp
// Toast.cs (public façade)
public sealed class Toast
{
    private readonly ToastService svc;
    internal Toast(ToastService svc) => this.svc = svc;

    public void Show(string message, Themes theme = Themes.Info, int duration = 5000)
        => svc.Push(new ToastEntry { Message = message, Theme = theme, Duration = duration });
}
```

### 4. Criar o Outlet

```razor
@* ToastOutlet.razor *@
@inject ToastService Service
@implements IDisposable

<div class="ya-toast-container">
    @foreach (var item in Service.Items)
    {
        <Toast @key="item" Entry="@item" OnDismiss="() => Service.Dismiss(item)" />
    }
</div>

@code {
    protected override void OnInitialized() => Service.Changed += StateHasChanged;
    public void Dispose() => Service.Changed -= StateHasChanged;
}
```

### 5. Registrar no DI

```csharp
// ToastServiceCollectionExtensions.cs
namespace Microsoft.Extensions.DependencyInjection;

public static class ToastServiceCollectionExtensions
{
    public static IServiceCollection AddYasamenToast(this IServiceCollection services)
    {
        services.AddScoped<ToastService>();
        services.AddScoped<Toast>();
        return services;
    }
}
```

### 6. Adicionar o Outlet no AppLayout

```razor
@* MainLayout.razor *@
<ToastOutlet />
```

---

## Referência Rápida

| Sobreposição | Handler criado por | Controle | DI necessário |
|---|---|---|---|
| **Notification** | (não tem Handler) | via `Notify` injetado | `AddYasamenNotification()` |
| **Modal** | Consumer (`new ModalHandler()`) | `Handler.Open()` / `Close()` | não precisa de DI |
| **OffCanvas** | Consumer (`new OffCanvasHandler()`) | `Handler.Show()` / `Hide()` | não precisa de DI |

**Regra:**  
- Sobreposições **globais** (não ligadas a um componente específico) → Service + Outlet + DI  
- Sobreposições **locais** (ligadas a um botão específico) → Handler inline, sem DI

---

## Checklist para Novo Overlay/Service

- [ ] Entry model `internal sealed` com propriedades `init`
- [ ] Service `internal sealed` com `event Action? Changed` e lista interna
- [ ] Façade pública com método semântico (`Show`, `Push`, `Add`)
- [ ] Outlet `.razor` injeta Service interno (não a façade), assina `Changed`, dispose correto
- [ ] DI extension em namespace `Microsoft.Extensions.DependencyInjection`
- [ ] Ambos `Service` e Façade registrados como `Scoped`
- [ ] Outlet adicionado ao `AppLayout` ou `App.razor`
