# YasamenStyles - Sample

## Contrato de uso

**Entrada pública**: `<YasamenStyles />` — namespace `RoyalCode.Razor.Styles`
**Grupo**: UI-SYSTEM
**Propósito**: Injeta o bundle CSS da biblioteca (Tailwind CSS + estilos de componentes) no `<head>` da aplicação via `<link>` tags.
**Patterns**:
- `implementa`: -
- `compõe`: -
**Setup necessário**: nenhum — é o próprio mecanismo de setup de CSS

## Regras rápidas

- **Use para**: configurar os estilos da biblioteca uma única vez, no `<head>` da aplicação host
- **Evite quando**: o CSS é gerenciado manualmente via bundle customizado ou CDN
- **Cuidado**: deve estar no `<head>` — em Blazor WebAssembly coloca em `wwwroot/index.html`; em Server/WebApp coloca em `App.razor` ou `_Layout.cshtml`

## Exemplos

### Configuração em App.razor (Blazor Web App / Interactive Server)

```razor
@* App.razor *@
<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Minha App</title>
    <YasamenStyles />
</head>
<body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>
</body>
</html>
```

**API usada**: sem parâmetros
**Nota**: Em modo debug (`Debugger.IsAttached`), injeta `yasamen.dist.css` + `styles.css` separados (útil para HMR do Tailwind). Em produção, injeta `styles.bundle.css` com fingerprint de asset via `Assets["..."]` para cache busting automático.

## API relevante

- **Props/parâmetros**: nenhum
- **Output HTML (debug)**: `<link href="/_content/RoyalCode.Razor.Styles/yasamen.dist.css">` + `<link href="/_content/RoyalCode.Razor.Styles/styles.css">`
- **Output HTML (produção)**: `<link href="/_content/RoyalCode.Razor.Styles/styles.bundle.css?v=...">` (com fingerprint)
