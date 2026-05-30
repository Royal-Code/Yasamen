# Bootstrap — yasamen-razor

## Quando aplicar

Ao criar um projeto Blazor que usa yasamen-razor, ou ao adicionar novos pacotes da lib a um projeto existente.

## Regras

### DI — Registro de serviços

Registrar no `Program.cs` (ou equivalente) apenas os serviços dos pacotes que o projeto usa:

```csharp
// Obrigatório para DropButton, DropIconButton (detectar clique externo via JS)
builder.Services.AddYasamenCommons();

// Obrigatório para Notification / NotificationService
builder.Services.AddYasamenNotification();

// Obrigatório para Modal / ModalHandler
builder.Services.AddYasamenModal();

// Obrigatório para OffCanvas / OffCanvasHandler
builder.Services.AddYasamenOffCanvas();

// Obrigatório para AppMenu / MenuService
builder.Services.AddYasamenMenu();
```

**Nunca** omitir `AddYasamenCommons()` quando o projeto usa `DropButton` ou `DropIconButton` — sem esse registro, os drops não fecham ao clicar fora.

**Nunca** omitir `AddYasamenModal()` quando o projeto usa `Modal` — o modal não renderiza sem o serviço registrado.

### CSS — Injeção de estilos

Incluir `<YasamenStyles />` no `<head>` da aplicação (tipicamente em `App.razor` ou `_Host.cshtml`/`_Layout.cshtml`):

```razor
<head>
    ...
    <YasamenStyles />
</head>
```

Nunca referenciar `yasamen.css` diretamente por path — usar sempre o componente `<YasamenStyles />`.

### Outlets — Com AppLayout

Quando o projeto usa `AppLayout`, os outlets de `Modal`, `OffCanvas` e `Notification` são incluídos automaticamente. Nenhuma ação adicional é necessária.

### Outlets — Sem AppLayout

Quando o projeto **não** usa `AppLayout` (portais, kiosks, media apps, studio, communication — ver `shell-selection.rules.md`), os outlets **não** são inseridos automaticamente. Incluir manualmente no componente raiz da aplicação (`App.razor`, `MainLayout.razor` ou equivalente):

```razor
@* Incluir nos layouts/raiz que não usam AppLayout *@
<ModalOutlet />
<OffCanvasOutlet />
<NotificationOutlet />
```

Sem esses outlets, `Modal`, `OffCanvas` e `Notification` não renderizam — o erro é silencioso.

## Anti-padrões

- Incluir `<ModalOutlet />` dentro de uma página: colocar no nível do layout, não de página individual.
- Chamar `AddYasamenMenu()` sem usar `AppMenu`: não causa erro mas registra serviço desnecessário.
- Omitir `AddYasamenOffCanvas()` e tentar usar `OffCanvas`: lança exceção de serviço não registrado em runtime.
