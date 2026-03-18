# Padrões Reais de Service, Handler e Outlet

> Como os overlays e componentes globais são implementados hoje na biblioteca. Este guide descreve o estado real de `Notification`, `Modal` e `OffCanvas`.

---

## Papel Deste Guide

Este guide é factual.

Ele existe para responder:

- como os overlays do repositório funcionam hoje;
- quais tipos públicos e internos existem;
- como DI, handler, state service e outlet se conectam;
- o que o layout realmente precisa hospedar.

Para decidir **qual** padrão usar em um overlay novo, o guide principal é [outlet-patterns.md](outlet-patterns.md).

---

## Visão Geral

Não existe um único padrão universal de `Service + Outlet` na biblioteca.

Hoje há duas famílias reais:

1. `Notification`: serviço global + façade pública + outlet global.
2. `Modal` e `OffCanvas`: componente declarado + handler público + service interno + projeção via `SectionContent` / `SectionOutlet`.

O erro mais comum é assumir que todos os overlays funcionam do mesmo jeito.

---

## Família A - `Notification`

### Surface pública

- `Notify`
- extensão de DI `AddYasamenNotification()`

### Tipos internos centrais

- `NotificationService`
- `NotificationOutlet`
- `NotificationGroup`
- `NotificationItem`

### Fluxo real

```text
Consumer
  -> injeta Notify
  -> chama Success / Warning / Danger / ShowAsync(...)

Notify
  -> cria e configura NotificationItem
  -> delega para NotificationService

NotificationService
  -> organiza itens por Placement
  -> coordena re-render

NotificationOutlet
  -> renderiza grupos por Placement
```

### Observações factuais

- `Notification` não usa `SectionContent` / `SectionOutlet`;
- o service mantém agrupamento por `Placements`;
- a API pública aceita callback `configure`;
- o placement já é configurável por item.

### Registro DI

```csharp
builder.Services.AddYasamenNotification();
```

Isso registra:

- `NotificationService` como `Scoped`;
- `Notify` como `Scoped`.

### Outlet no layout

```razor
<RoyalCode.Razor.Internal.Notifications.NotificationOutlet />
```

### Exemplo de uso

```razor
@inject Notify Notify

<Button Label="Salvar" OnClick="@SaveAsync" />

@code {
    private async Task SaveAsync()
    {
        await SaveDataAsync();

        await Notify.Success(
            "Dados salvos com sucesso.",
            configure: item => item.Placement = Placements.BottomEnd);
    }
}
```

---

## Família B - `Modal`

### Surface pública

- componente `<Modal>`
- `ModalHandler`
- extensão de DI `AddYasamenModal()`

### Tipos internos centrais

- `ModalService`
- `ModalState`
- `ModalOutlet`

### Fluxo real

```text
Consumer
  -> declara <Modal Handler="...">
  -> mantém ModalHandler
  -> chama OpenAsync / CloseAsync

Modal
  -> cria estado interno
  -> registra ModalState em ModalService
  -> projeta markup com SectionContent

ModalOutlet
  -> renderiza estados registrados com SectionOutlet
```

### Observações factuais

- a instância do componente existe no markup do consumidor;
- o conteúdo é declarativo;
- a renderização final ocorre por projeção;
- o handler público é assíncrono.

### Registro DI

```csharp
builder.Services.AddYasamenModal();
```

### Outlet no layout

```razor
<RoyalCode.Razor.Internal.Modals.ModalOutlet />
```

### Exemplo de uso

```razor
@code {
    private readonly ModalHandler editModal = new();
}

<Button Label="Editar" OnClick="@editModal.OpenAsync" />

<Modal Handler="editModal">
    <Body>
        <TextField @bind-Value="model.Name" Label="Nome" />
    </Body>
</Modal>
```

---

## Família B - `OffCanvas`

### Surface pública

- componente `<OffCanvas>`
- `OffCanvasHandler`
- extensão de DI `AddYasamenOffCanvas()`

### Tipos internos centrais

- `OffCanvasService`
- `OffCanvasState`
- `OffCanvasOutlet`

### Fluxo real

```text
Consumer
  -> declara <OffCanvas Handler="...">
  -> mantém OffCanvasHandler
  -> chama Show / Hide / Toggle

OffCanvas
  -> cria estado interno
  -> registra OffCanvasState em OffCanvasService
  -> projeta markup com SectionContent

OffCanvasOutlet
  -> renderiza estados registrados com SectionOutlet
```

### Observações factuais

- o componente é declarado pelo consumidor;
- o state service coordena as instâncias registradas;
- o handler público é síncrono no caso principal;
- a renderização final também ocorre por projeção.

### Registro DI

```csharp
builder.Services.AddYasamenOffCanvas();
```

### Outlet no layout

```razor
<RoyalCode.Razor.Internal.OffCanvas.OffCanvasOutlet />
```

### Exemplo de uso

```razor
@code {
    private readonly OffCanvasHandler filters = new();
}

<Button Label="Filtros" OnClick="@filters.Show" />

<OffCanvas Handler="filters" Position="Positions.End">
    <Body>
        <TextField @bind-Value="search" Label="Busca" />
    </Body>
</OffCanvas>
```

---

## Comparação Factual

| Caso | Surface pública | Estado principal | Outlet | Projeção |
|---|---|---|---|---|
| `Notification` | `Notify` | `NotificationService` | `NotificationOutlet` | Não |
| `Modal` | `ModalHandler` + `<Modal>` | `ModalService` + `ModalState` | `ModalOutlet` | Sim |
| `OffCanvas` | `OffCanvasHandler` + `<OffCanvas>` | `OffCanvasService` + `OffCanvasState` | `OffCanvasOutlet` | Sim |

---

## Requisitos Reais de Layout

Hoje o layout de aplicação hospeda os outlets internos correspondentes aos recursos usados:

```razor
<RoyalCode.Razor.Internal.Modals.ModalOutlet />
<RoyalCode.Razor.Internal.OffCanvas.OffCanvasOutlet />
<RoyalCode.Razor.Internal.Notifications.NotificationOutlet />
```

Se um pacote exigir outlet, a presença dele no layout faz parte do contrato operacional do pacote.

---

## Regras Factuais Observadas no Repositório

- `Notification` usa façade pública e service global;
- `Modal` e `OffCanvas` usam componente declarado + handler + service interno;
- services de estado de UI continuam `Scoped`;
- services e outlets internos ficam em `RoyalCode.Razor.Internal.*`;
- a surface pública deve continuar mínima.

---

## Checklist

- [ ] O overlay estudado é `Notification`, `Modal` ou `OffCanvas`?
- [ ] A surface pública real está clara?
- [ ] O service interno real está identificado?
- [ ] O layout que hospeda o outlet foi identificado?
- [ ] O fluxo real usa ou não usa `SectionContent` / `SectionOutlet`?
- [ ] A leitura factual está alinhada com o guide 12 para decisão futura?




