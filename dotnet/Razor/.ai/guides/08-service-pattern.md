# Guide 08 - Service, Outlet and Handler Patterns

> Como a biblioteca implementa overlays e componentes globais hoje. Este guide documenta o padrao real de `Notification`, `Modal` e `OffCanvas`.

---

## Visao Geral

Nao existe um unico padrao universal de "Service + Outlet" na biblioteca.

Hoje ha dois modelos reais:

1. `Notification`: servico global + facade publica + outlet global.
2. `Modal` e `OffCanvas`: instancia declarada no componente + handler publico + servico interno + projecao via `SectionContent` / `SectionOutlet`.

O erro mais comum e tentar forcar um novo overlay a caber no modelo errado.

---

## Padrao A - Servico Global + Outlet Global

Este e o caso de `Notification`.

### Quando usar

Use este modelo quando o overlay:

- nao pertence a uma instancia especifica declarada na pagina;
- precisa ser disparado de qualquer lugar por DI;
- funciona como fila ou agrupamento global da sessao;
- nao depende de um `Handler` por instancia.

### Fluxo real

```text
Consumer
  -> injeta Notify
  -> chama Success / Danger / ShowAsync(...)

Notify
  -> cria/configura NotificationItem
  -> delega para NotificationService

NotificationService
  -> organiza itens por Placement
  -> pede re-render ao NotificationOutlet

NotificationOutlet
  -> renderiza NotificationGroup por Placement
  -> cada grupo renderiza NotificationSection / Notification
```

### Peculiaridades importantes

- `Notification` nao usa `SectionContent` / `SectionOutlet`.
- O `NotificationService` mantem um dicionario por `Placements`.
- A API publica `Notify` aceita callback `configure` para customizar cada item.
- O posicionamento ja e configuravel por `NotificationItem.Placement`.

### Registro DI

```csharp
builder.Services.AddYasamenNotification();
```

Isso registra:

- `NotificationService` como `Scoped`
- `Notify` como `Scoped`

### Outlet no layout

O layout hospeda o outlet interno:

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

## Padrao B - Componente Declarado + Handler + Servico Interno + Outlet

Este e o caso de `Modal` e `OffCanvas`.

### Quando usar

Use este modelo quando o overlay:

- existe como componente declarado pelo consumidor;
- precisa de parametros, slots e conteudo definidos no ponto de uso;
- precisa de um `Handler` publico para abrir e fechar;
- precisa renderizar visualmente em outra parte da arvore DOM.

### Fluxo real

```text
Consumer
  -> declara <Modal ...> ou <OffCanvas ...>
  -> mantem ModalHandler ou OffCanvasHandler
  -> chama handler.OpenAsync / CloseAsync ou handler.Show / Hide / Toggle

Component instance
  -> cria estado interno
  -> registra estado no servico interno
  -> projeta markup com SectionContent

Internal service
  -> coordena abertura/fechamento
  -> controla backdrop, pilha ou exclusao por lado

Outlet
  -> renderiza SectionOutlet para estados registrados
```

### Como `Modal` funciona

- o consumidor declara `<Modal Handler="...">`;
- o componente registra um `ModalState` no `ModalService`;
- o markup do modal e projetado com `SectionContent`;
- `ModalOutlet` renderiza os estados registrados com `SectionOutlet`;
- `ModalHandler` expoe `OpenAsync()` e `CloseAsync()`.

Registro DI:

```csharp
builder.Services.AddYasamenModal();
```

Outlet no layout:

```razor
<RoyalCode.Razor.Internal.Modals.ModalOutlet />
```

### Como `OffCanvas` funciona

- o consumidor declara `<OffCanvas Handler="...">`;
- o componente registra um `OffCanvasState` no `OffCanvasService`;
- o markup e projetado com `SectionContent`;
- `OffCanvasOutlet` renderiza os estados registrados com `SectionOutlet`;
- `OffCanvasHandler` expoe `Show()`, `Hide()` e `Toggle()`.

Registro DI:

```csharp
builder.Services.AddYasamenOffCanvas();
```

Outlet no layout:

```razor
<RoyalCode.Razor.Internal.OffCanvas.OffCanvasOutlet />
```

### Exemplo de uso

```razor
@code {
    private readonly ModalHandler editModal = new();
    private readonly OffCanvasHandler filters = new();
}

<Button Label="Editar" OnClick="@editModal.OpenAsync" />
<Button Label="Filtros" OnClick="@filters.Show" />

<Modal Handler="editModal">
    <Body>
        <TextField @bind-Value="model.Name" Label="Nome" />
    </Body>
</Modal>

<OffCanvas Handler="filters" Position="Positions.End">
    <Body>
        <TextField @bind-Value="search" Label="Busca" />
    </Body>
</OffCanvas>
```

---

## Diferencas Praticas

| Caso | Surface publica | Estado principal | Outlet | Section projection |
|---|---|---|---|---|
| `Notification` | `Notify` | `NotificationService` | `NotificationOutlet` | Nao |
| `Modal` | `ModalHandler` + `<Modal>` | `ModalService` + `ModalState` | `ModalOutlet` | Sim |
| `OffCanvas` | `OffCanvasHandler` + `<OffCanvas>` | `OffCanvasService` + `OffCanvasState` | `OffCanvasOutlet` | Sim |

---

## Regras para Novos Overlays

1. Nao assumir que todo overlay precisa de `SectionOutlet`.
2. Se o recurso for global e disparado por DI, prefira facade publica + servico + outlet global.
3. Se o recurso for uma instancia declarada com conteudo proprio, prefira componente + handler + servico interno + `SectionContent` / `SectionOutlet`.
4. `Service` interno e `Outlet` interno devem ficar em namespace `RoyalCode.Razor.Internal.*`.
5. A surface publica deve expor apenas o que o consumidor precisa usar: componente, handler e extensao DI.
6. Services de estado de UI continuam `Scoped`.

---

## Regras de Layout

O layout de aplicacao precisa hospedar os outlets internos correspondentes aos recursos usados. Hoje o conjunto esperado e:

```razor
<RoyalCode.Razor.Internal.Modals.ModalOutlet />
<RoyalCode.Razor.Internal.OffCanvas.OffCanvasOutlet />
<RoyalCode.Razor.Internal.Notifications.NotificationOutlet />
```

Se um novo overlay exigir outlet, a presenca dele no layout faz parte do contrato do pacote.

---

## Checklist

- [ ] O overlay e global ou pertence a uma instancia declarada?
- [ ] Existe necessidade de `Handler` publico?
- [ ] O layout precisa hospedar um outlet?
- [ ] O service de estado deve ser `Scoped`?
- [ ] O namespace interno ficou em `RoyalCode.Razor.Internal.*`?
- [ ] A API publica exposta esta minima e coerente com o padrao escolhido?
