# Yasamen Icons Guide

## Objetivo
Orientar a IA a usar ícones no Yasamen com o provider Bootstrap Icons, `WellKnownIcons`, `Icon` e `IconButton` sem combinações inválidas.

## Quando usar
Use este guide ao gerar:
- Botões com ícone.
- Ícones de ação, estado, menu, paginação, feedback ou usuário.
- Setup de Bootstrap Icons.
- Componentes que usam `Icon`, `IconButton`, `IconFragment`, `BsIconNames` ou `WellKnownIcons`.

## Decisão corporativa
Bootstrap Icons é o provider oficial evidenciado nesta rodada. A aplicação deve chamar `BootstrapIcons.Include()` e carregar o CSS de Bootstrap Icons. A IA deve preferir `WellKnownIcons` para ações comuns e usar `BsIconNames` quando precisar de um ícone Bootstrap específico.

## Regras
- Sempre inicialize ícones com `BootstrapIcons.Include();` no startup do app.
- Sempre carregue Bootstrap Icons CSS no app raiz ou por mecanismo equivalente do host.
- Para ações comuns, prefira `WellKnownIcons`: `Save`, `Cancel`, `Search`, `Filter`, `Success`, `Warning`, `Alert`, `Info`, `Menu`, `FavoriteOn`, `FavoriteOff`, `PaginationNext`, etc.
- Use `IconButton IconFragment="@WellKnownIcons.X"` quando o ícone vem de `WellKnownIcons`.
- Use `IconButton Icon="@BsIconNames.X"` quando o ícone vem diretamente do enum Bootstrap.
- Use `<Icon Fragment="@WellKnownIcons.Home" />` ou `<Icon Kind="@BsIconNames.House" />`; nunca defina `Kind` e `Fragment` ao mesmo tempo.
- Quando `Icon` recebe `Kind`, o enum deve ter factory registrada; `BootstrapIcons.Include()` registra factory para `BsIconNames`.
- Se aparecer o ícone fallback de banimento, trate como indício de provider não inicializado ou fragment ausente.
- O factory Bootstrap renderiza `<i class="bi-...">`; portanto o CSS Bootstrap Icons precisa estar carregado.
- Para ações em botões textuais, use `Button Icon="@BsIconNames.X"` quando for enum ou componha conteúdo se precisar de fragment.
- Não use SVG manual para ícones comuns já cobertos por `WellKnownIcons` ou `BsIconNames`.
- Não use `IconButton` sem `Icon` nem `IconFragment`; o componente exige um dos dois.

## Exemplos / Passo-a-passo

### Setup de provider

```csharp
using RoyalCode.Razor.Icons.Bootstrap;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

BootstrapIcons.Include();
```

```razor
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.13.1/font/bootstrap-icons.min.css">
<YasamenStyles />
```

### Ícone conhecido em botão de ícone

```razor
<IconButton IconFragment="@WellKnownIcons.Search"
            title="Buscar"
            OnClick="SearchAsync" />

@code {
    private Task SearchAsync()
    {
        return Task.CompletedTask;
    }
}
```

### Ícone Bootstrap específico

```razor
@using RoyalCode.Razor.Icons.Bootstrap

<Icon Kind="@BsIconNames.House" AdditionalClasses="text-primary-500" />

<IconButton Icon="@BsIconNames.Gear"
            title="Configurações"
            Style="Themes.Secondary" />
```

### Ícones de ação em botão textual

```razor
@using RoyalCode.Razor.Icons.Bootstrap

<Button Label="Salvar"
        Icon="@BsIconNames.Save"
        IconPosition="Positions.Start"
        Style="Themes.Primary"
        OnClick="SaveAsync" />
```

### Fragment conhecido em `Icon`

```razor
<Icon Fragment="@WellKnownIcons.Success" AdditionalClasses="text-success-600" />
```

## Anti-padrões
- Não passar `Kind` e `Fragment` simultaneamente para `Icon`; o componente lança `InvalidOperationException`.
- Não usar `IconButton` sem ícone; ele exige `Icon` ou `IconFragment`.
- Não usar `Icon="@WellKnownIcons.Save"` em `IconButton`, porque `Icon` espera `Enum`; use `IconFragment`.
- Não carregar `<YasamenStyles />` achando que isso substitui Bootstrap Icons CSS; o provider Bootstrap renderiza classes `bi-*`.
- Não duplicar SVGs manuais para ações comuns como salvar, cancelar, buscar, filtrar, menu, favorito e paginação.

## Fontes
- `RoyalCode.Razor.Icons.Bootstrap/BootstrapIcons.cs`
- `RoyalCode.Razor.Icons.Bootstrap/BootstrapIconContentFactory.cs`
- `RoyalCode.Razor.Icons.Bootstrap/BsIconNames.cs`
- `RoyalCode.Razor.Icons/Icons/Icon.cs`
- `RoyalCode.Razor.Icons/Icons/WellKnownIcons.cs`
- `RoyalCode.Razor.Buttons/Components/IconButton.razor`
- `RoyalCode.Razor.Buttons/Components/IconButton.razor.cs`
- `RoyalCode.Razor.Buttons/Components/Button.razor`
- `RoyalCode.Razor.Buttons/Components/Button.razor.cs`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Program.cs`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs/Components/App.razor`
